using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace th_hack_tools
{
    /// <summary>
    /// Reads the file structure of DATA1.bin by using DATA0.bin
    /// </summary>
    public class th_structure
    {
        public string path;

        public List<long> offsets = new List<long>();
        public List<int> lengths = new List<int>();
        public List<int> lengths2 = new List<int>();
        public List<bool> unknown = new List<bool>();

        // TODO: Understand how the two lengths work, doesn't matter for table data though.

        public th_structure(string file)
        {
            path = file;

            using (FileStream reader = new FileStream(file, FileMode.Open, FileAccess.Read))
            {

                byte[] buffer = new Byte[32];
                int bytesRead;

                while ((bytesRead =
                        reader.Read(buffer, 0, 32)) > 0)
                {
                    long current_offset = BitConverter.ToInt64(buffer, 0);
                    int current_length = BitConverter.ToInt32(buffer, 8);
                    int current_length2 = BitConverter.ToInt32(buffer, 16);
                    bool current_unknown = BitConverter.ToBoolean(buffer, 24);
                    offsets.Add(current_offset);
                    lengths.Add(current_length);
                    lengths2.Add(current_length2);
                    unknown.Add(current_unknown);
                }

                reader.Close();
            }
        }

        public void Write(string file, th_structure old_structure)
        {
            using (FileStream writer = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                int offset_difference = 0;
                for (int i = 0; i < offsets.Count; i++)
                {
                    offsets[i] += offset_difference;

                    writer.Write(BitConverter.GetBytes(offsets[i]), 0, 8);

                    writer.Write(BitConverter.GetBytes(lengths[i]), 0, 4);
                    writer.Write(new byte[4] { 0, 0, 0, 0 }, 0, 4);

                    writer.Write(BitConverter.GetBytes(lengths2[i]), 0, 4);
                    writer.Write(new byte[4] { 0, 0, 0, 0 }, 0, 4);

                    writer.Write(BitConverter.GetBytes(unknown[i]), 0, 1);
                    writer.Write(new byte[7] { 0, 0, 0, 0, 0, 0, 0 }, 0, 7);

                    offset_difference += lengths[i] - old_structure.lengths[i];
                }
                writer.Close();
            }
        }

    }

    /// <summary>
    /// Manages the entire read/write processes
    /// </summary>
    public class FileController
    {
        public SortedList<int, TableController> Main_Tables = new SortedList<int, TableController>();

        private th_structure Structure;
        private FileStream fs;
        private BackgroundWorker worker;

        string data_0 = "";
        string data_1 = "";
        string writing_directory = "";

        public FileController(string directory)
        {
            data_0 = directory + Path.DirectorySeparatorChar + "DATA0.bin";
            data_1 = directory + Path.DirectorySeparatorChar + "DATA1.bin";

            if (File.Exists(data_0))
                Structure = new th_structure(data_0);
            else
                throw new ArgumentException("Couldn't find Data0.bin", "FileController");

            if (File.Exists(data_1))
                fs = new FileStream(directory + Path.DirectorySeparatorChar + "DATA1.bin", FileMode.Open, FileAccess.Read);
            else
                throw new ArgumentException("Couldn't find Data1.bin", "FileController");

            // Add Tables to list

            Main_Tables.Add(0, new TableController(fs, Structure.offsets[0]));
            Main_Tables.Add(1, new TableController(fs, Structure.offsets[1]));
            Main_Tables.Add(2, new TableController(fs, Structure.offsets[2]));
            Main_Tables.Add(3, new TableController(fs, Structure.offsets[3]));
            Main_Tables.Add(4, new TableController(fs, Structure.offsets[4]));

            Main_Tables.Add(11, new TableController(fs, Structure.offsets[11]));
            Main_Tables.Add(12, new TableController(fs, Structure.offsets[12]));

            fs.Close();

            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = false;
            worker.WorkerReportsProgress = true;
            worker.DoWork += DoWork;
        }

        private void write_nullbytes(int key, FileStream writer)
        {
            int nullbytes = (int)(Structure.offsets[key + 1] - Structure.offsets[key] - Structure.lengths[key]);
            for (int i = 0; i < nullbytes; i++)
                writer.WriteByte(0);
        }

        public void Write(string directory)
        {

            if (directory == Path.GetDirectoryName(data_1))
            {
                throw new ArgumentException("Overwriting source files is not possible.\nChoose another location.", "FileController");
            }
            else
            {
                writing_directory = directory;
                worker.RunWorkerAsync();
            }

        }

        byte[] read_seek(long offset, int length)
        {
            byte[] bits = new byte[length];
            fs.Seek(offset, SeekOrigin.Begin);
            fs.Read(bits, 0, length);
            return bits;
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            string data_0_new = writing_directory + Path.DirectorySeparatorChar + "DATA0.bin";
            string data_1_new = writing_directory + Path.DirectorySeparatorChar + "DATA1.bin";

            fs = new FileStream(data_1, FileMode.Open, FileAccess.Read);

            // Begin writing DATA1.bin

            using (FileStream writer = new FileStream(data_1_new, FileMode.Create, FileAccess.Write))
            {
                // Write table data

                for (int i = 0; i < Main_Tables.Count; i++)
                {
                    KeyValuePair<int, TableController> entry = Main_Tables.ElementAt(i);
                    List<byte> current_table = entry.Value.Write();

                    writer.Write(current_table.ToArray(), 0, current_table.Count);
                    write_nullbytes(entry.Key, writer);

                    // Write chunks from original file if files are getting skipped
                    if (!Main_Tables.ContainsKey(entry.Key + 1) && i < Main_Tables.Count - 1)
                    {

                        int current_entry = entry.Key;
                        int next_entry = Main_Tables.ElementAt(i + 1).Key;

                        int chunk_area = (int)(Structure.offsets[next_entry] - Structure.offsets[current_entry + 1]);
                        byte[] chunks = read_seek(Structure.offsets[current_entry + 1], chunk_area);
                        writer.Write(chunks, 0, chunk_area);

                    }

                }

                // Begin appending old, unedited data to new file
                fs.Seek(Structure.offsets[Main_Tables.Last().Key + 1], SeekOrigin.Begin);

                // create a buffer to hold the bytes 
                int bufferSize = 1024;
                byte[] buffer = new byte[bufferSize];

                int bytesRead = -1;
                long totalReads = 0;
                int prevPercent = 0;
                long totalBytes = fs.Length;

                // while the read method returns bytes
                // keep writing them to the output stream
                while ((bytesRead = fs.Read(buffer, 0, bufferSize)) > 0)
                {
                    writer.Write(buffer, 0, bytesRead);
                    totalReads += bytesRead;
                    int percent = Convert.ToInt32(((decimal)totalReads / (decimal)totalBytes) * 100);
                    if (percent != prevPercent)
                    {
                        worker.ReportProgress(percent);
                        prevPercent = percent;
                    }
                }

                writer.Close();

            }

            // Begin writing DATA0.bin

            th_structure Structure_New = new th_structure(data_0);

            foreach (KeyValuePair<int, TableController> entry in Main_Tables)
            {
                Structure_New.lengths[entry.Key] = entry.Value.total_length;
            }

            Structure_New.Write(data_0_new, Structure);

            fs.Close();
        }

        public event ProgressChangedEventHandler ProgressChanged
        {
            add { worker.ProgressChanged += value; }
            remove { worker.ProgressChanged -= value; }
        }

        public event RunWorkerCompletedEventHandler Completed
        {
            add { worker.RunWorkerCompleted += value; }
            remove { worker.RunWorkerCompleted -= value; }
        }

    }

    /// <summary>
    /// Provides help functions for easily accessing information from tables
    /// </summary>
    public class th_data
    {
        public FileController controller;

        //public List<string> text_en = new List<string>();

        public th_data(string directory)
        {
            controller = new FileController(directory);

            Console.WriteLine("Initiated TH Data.");
        }

        public TableController get_character_table()
        {
            return controller.Main_Tables[12];
        }

        public TableController get_class_table()
        {
            return controller.Main_Tables[11];
        }

        Dictionary<int, string> read_archive(string[] strings, int start = 0, int items = 1)
        {
            Dictionary<int, string> NameTable = new Dictionary<int, string>();

            int index = 0;
            for (int i=start; i < start + items; i++)
            {
                NameTable.Add(index, strings[i]);
                index++;
            }

            return NameTable;

        }

        public Dictionary<int, string> get_character_strings(string[] strings)
        {
            Dictionary<int, string> Characters = read_archive(strings, 1156, 522);
            Characters[0] = Characters[0] + " (Male)";
            Characters[1] = Characters[1] + " (Female)";
            return Characters;
        }

        public Dictionary<int, string> get_class_strings(string[] strings)
        {
            return read_archive(strings, 3452, 90);
        }

        public Dictionary<int, string> get_crest_strings(string[] strings)
        {
            Dictionary<int, string> Crests = read_archive(strings, 9556, 48);
            Crests.Add(0xFF, "No Crest");
            return Crests;
        }

        public Dictionary<int, string> get_spell_strings(string[] strings)
        {
            Dictionary<int, string> Spells = read_archive(strings, 7802, 38);
            Spells.Add(0xFF, "No Spell");
            return Spells;
        }
        public Dictionary<int, string> get_skill_strings(string[] strings)
        {
            Dictionary<int, string> Skills = read_archive(strings, 7202, 238);
            Skills.Add(0xFF, "No Skill");
            return Skills;
        }

        public Dictionary<int, string> get_art_strings(string[] strings)
        {
            Dictionary<int, string> Arts = read_archive(strings, 5980, 77);
            Arts.Add(0xFF, "No Art");
            return Arts;
        }

        public Dictionary<int, string> get_item_strings(string[] strings)
        {
            Dictionary<int, string> Items = read_archive(strings, 4622, 26);
            Items.Add(0xFF, "No Item");
            return Items;
        }

    }

    public class THint
    {
        private int Offset;
        public int Value;

        public THint(int offset, byte[] data, bool signed=true)
        {
            Offset = offset;
            if (signed)
            {
                Value = (sbyte)data[offset];
            }
            else
            {
                Value = (byte)data[offset];
            }
            
        }

        public void Save(ref byte[] data)
        {
            data[Offset] = (byte)Value;
        }

    }

    public class THObject
    {
        public byte[] RAW;
        public Dictionary<string, THint> Values = new Dictionary<string, THint>();

        public byte[] Save()
        {
            foreach (KeyValuePair<string, THint> entry in Values)
            {
                entry.Value.Save(ref RAW);
            }
            return RAW;
        }

    }

    public class THClassLevels : THObject
    {
        public THClassLevels(ITable data)
        {
            RAW = new byte[data.contents.Count];
            for (int i=0;i<RAW.Length;i++)
            {
                RAW[i] = data.contents[i][0];
            }
            Values.Add("lv_beginner", new THint(1, RAW));
            Values.Add("lv_intermediate", new THint(2, RAW));
            Values.Add("lv_advanced", new THint(3, RAW));
            Values.Add("lv_master", new THint(4, RAW));
        }

        public void Write(ref TableController controller)
        {

            Save();

            for (int i = 0; i < RAW.Length; i++)
            {
                controller.Tables[2].contents[i][0] = RAW[i];
            }

        }

    }

    public class THClass : THObject
    {

        public int index;

        public THClassSkills skills;
        public THClassRequirements requirements;

        public THClass(TableController data, int class_index)
        {

            index = class_index;
            RAW = data.Tables[0].contents[index];

            skills = new THClassSkills(data.Tables[3], index);
            requirements = new THClassRequirements(data.Tables[1], index);

            Values.Add("growth_hp", new THint(20, RAW));
            Values.Add("growth_str", new THint(21, RAW));
            Values.Add("growth_mag", new THint(22, RAW));
            Values.Add("growth_dex", new THint(23, RAW));
            Values.Add("growth_spd", new THint(24, RAW));
            Values.Add("growth_lck", new THint(25, RAW));
            Values.Add("growth_def", new THint(26, RAW));
            Values.Add("growth_res", new THint(27, RAW));
            Values.Add("growth_mov", new THint(28, RAW));
            Values.Add("growth_cha", new THint(29, RAW));

            Values.Add("base_hp", new THint(76, RAW, false));
            Values.Add("base_str", new THint(85, RAW, false));
            Values.Add("base_mag", new THint(86, RAW, false));
            Values.Add("base_dex", new THint(87, RAW, false));
            Values.Add("base_spd", new THint(88, RAW, false));
            Values.Add("base_lck", new THint(89, RAW, false));
            Values.Add("base_def", new THint(90, RAW, false));
            Values.Add("base_res", new THint(91, RAW, false));
            Values.Add("base_mov", new THint(92, RAW, false));
            Values.Add("base_cha", new THint(93, RAW, false));

            Values.Add("exp_sword", new THint(57, RAW));
            Values.Add("exp_lance", new THint(58, RAW));
            Values.Add("exp_axe", new THint(59, RAW));
            Values.Add("exp_bow", new THint(60, RAW));
            Values.Add("exp_brawl", new THint(61, RAW));
            Values.Add("exp_reason", new THint(62, RAW));
            Values.Add("exp_faith", new THint(63, RAW));
            Values.Add("exp_authority", new THint(64, RAW));
            Values.Add("exp_armor", new THint(65, RAW));
            Values.Add("exp_riding", new THint(66, RAW));
            Values.Add("exp_flying", new THint(67, RAW));

            Values.Add("exp_mastery", new THint(74, RAW,false));

        }

        public void Write(ref TableController controller)
        {

            Save();
            skills.Save();
            requirements.Save();

            // Write to Table Controller

            controller.Tables[0].contents[index] = this.RAW;
            controller.Tables[1].contents[index] = requirements.RAW;
            controller.Tables[3].contents[index] = skills.RAW;

        }

    }

    public class THClassSkills : THObject
    {

        public THClassSkills(ITable data, int class_index)
        {
            RAW = data.contents[class_index].ToArray();

            Values.Add("mastery_skill", new THint(0, RAW,false));
            Values.Add("mastery_art", new THint(1, RAW, false));

            Values.Add("class_skill_1", new THint(2, RAW, false));
            Values.Add("class_skill_2", new THint(3, RAW, false));
            Values.Add("class_skill_3", new THint(4, RAW, false));

        }

    }

    public class THClassRequirements : THObject
    {

        public THClassRequirements(ITable data, int class_index)
        {
            RAW = data.contents[class_index].ToArray();

            Values.Add("genderlock", new THint(3, RAW, false));

            Values.Add("req_sword", new THint(4, RAW, false));
            Values.Add("req_lance", new THint(5, RAW, false));
            Values.Add("req_axe", new THint(6, RAW, false));
            Values.Add("req_bow", new THint(7, RAW, false));
            Values.Add("req_brawl", new THint(8, RAW, false));
            Values.Add("req_reason", new THint(9, RAW, false));
            Values.Add("req_faith", new THint(10, RAW, false));
            Values.Add("req_authority", new THint(11, RAW, false));
            Values.Add("req_armor", new THint(12, RAW, false));
            Values.Add("req_riding", new THint(13, RAW, false));
            Values.Add("req_flying", new THint(14, RAW, false));

        }

    }

    public class THCombatArtList : THObject
    {
        public THCombatArtList(ITable data, int character_index)
        {
            RAW = data.contents[character_index].ToArray();

            Values.Add("art_1", new THint(1, RAW, false));
            Values.Add("art_2", new THint(2, RAW, false));
            Values.Add("art_3", new THint(3, RAW, false));
            Values.Add("art_4", new THint(4, RAW, false));
            Values.Add("art_5", new THint(5, RAW, false));

            Values.Add("art_1_category", new THint(11, RAW, false));
            Values.Add("art_2_category", new THint(12, RAW, false));
            Values.Add("art_3_category", new THint(13, RAW, false));
            Values.Add("art_4_category", new THint(14, RAW, false));
            Values.Add("art_5_category", new THint(15, RAW, false));

            Values.Add("art_1_requirement", new THint(21, RAW, false));
            Values.Add("art_2_requirement", new THint(22, RAW, false));
            Values.Add("art_3_requirement", new THint(23, RAW, false));
            Values.Add("art_4_requirement", new THint(24, RAW, false));
            Values.Add("art_5_requirement", new THint(25, RAW, false));
        }
    }

    public class THSkillList : THObject
    {

        public THSkillList(ITable data, int character_index)
        {
            RAW = data.contents[character_index].ToArray();

            Values.Add("skill_personal", new THint(20, RAW, false));
            Values.Add("skill_timeskip", new THint(21, RAW, false));

            Values.Add("skill_3", new THint(22, RAW, false));
            Values.Add("skill_4", new THint(23, RAW, false));
            Values.Add("skill_5", new THint(24, RAW, false));
            Values.Add("skill_6", new THint(25, RAW, false));
            Values.Add("skill_7", new THint(26, RAW, false));
            Values.Add("skill_8", new THint(27, RAW, false));
            Values.Add("skill_9", new THint(28, RAW, false));

            Values.Add("skill_category3", new THint(0, RAW, false));
            Values.Add("skill_category4", new THint(1, RAW, false));
            Values.Add("skill_category5", new THint(2, RAW, false));
            Values.Add("skill_category6", new THint(3, RAW, false));
            Values.Add("skill_category7", new THint(4, RAW, false));
            Values.Add("skill_category8", new THint(5, RAW, false));
            Values.Add("skill_category9", new THint(6, RAW, false));

            Values.Add("skill_requirement3", new THint(42, RAW, false));
            Values.Add("skill_requirement4", new THint(43, RAW, false));
            Values.Add("skill_requirement5", new THint(44, RAW, false));
            Values.Add("skill_requirement6", new THint(45, RAW, false));
            Values.Add("skill_requirement7", new THint(46, RAW, false));
            Values.Add("skill_requirement8", new THint(47, RAW, false));
            Values.Add("skill_requirement9", new THint(48, RAW, false));

        }

    }

    public class THSpellList : THObject
    {

        public THSpellList(ITable data, int character_index)
        {
            RAW = data.contents[character_index].ToArray();

            Values.Add("spell_reason_1", new THint(5, RAW, false));
            Values.Add("spell_reason_2", new THint(6, RAW, false));
            Values.Add("spell_reason_3", new THint(7, RAW, false));
            Values.Add("spell_reason_4", new THint(8, RAW, false));
            Values.Add("spell_reason_5", new THint(9, RAW, false));

            Values.Add("spell_faith_1", new THint(10, RAW, false));
            Values.Add("spell_faith_2", new THint(11, RAW, false));
            Values.Add("spell_faith_3", new THint(12, RAW, false));
            Values.Add("spell_faith_4", new THint(13, RAW, false));
            Values.Add("spell_faith_5", new THint(14, RAW, false));

        }

    }

    public class THCharacter : THObject
    {

        private int index;

        public THSpellList spells;
        public THSkillList skills;
        public THCombatArtList arts;

        public THCharacter(TableController data, int character_index)
        {
            index = character_index;
            RAW = data.Tables[0].contents[index];
            spells = new THSpellList(data.Tables[4], index);
            skills = new THSkillList(data.Tables[5], index);
            arts = new THCombatArtList(data.Tables[7], index);

            Values.Add("3d_model", new THint(24, RAW, false));

            Values.Add("age", new THint(27, RAW, false));
            Values.Add("birth_day", new THint(29, RAW, false));
            Values.Add("birth_month", new THint(30, RAW, false));

            Values.Add("height", new THint(44, RAW, false));
            Values.Add("height_ts", new THint(45, RAW, false));

            Values.Add("base_hp", new THint(39, RAW, false));
            Values.Add("base_str", new THint(48, RAW, false));
            Values.Add("base_mag", new THint(49, RAW, false));
            Values.Add("base_dex", new THint(50, RAW, false));
            Values.Add("base_spd", new THint(51, RAW, false));
            Values.Add("base_lck", new THint(52, RAW, false));
            Values.Add("base_def", new THint(53, RAW, false));
            Values.Add("base_res", new THint(54, RAW, false));
            Values.Add("base_mov", new THint(55, RAW, false));
            Values.Add("base_cha", new THint(56, RAW, false));

            Values.Add("max_hp", new THint(34, RAW, false));
            Values.Add("max_str", new THint(66, RAW, false));
            Values.Add("max_mag", new THint(67, RAW, false));
            Values.Add("max_dex", new THint(68, RAW, false));
            Values.Add("max_spd", new THint(69, RAW, false));
            Values.Add("max_lck", new THint(70, RAW, false));
            Values.Add("max_def", new THint(71, RAW, false));
            Values.Add("max_res", new THint(72, RAW, false));
            Values.Add("max_mov", new THint(73, RAW, false));
            Values.Add("max_cha", new THint(74, RAW, false));

            Values.Add("growth_hp", new THint(37, RAW));
            Values.Add("growth_str", new THint(57, RAW));
            Values.Add("growth_mag", new THint(58, RAW));
            Values.Add("growth_dex", new THint(59, RAW));
            Values.Add("growth_spd", new THint(60, RAW));
            Values.Add("growth_lck", new THint(61, RAW));
            Values.Add("growth_def", new THint(62, RAW));
            Values.Add("growth_res", new THint(63, RAW));
            Values.Add("growth_mov", new THint(64, RAW));
            Values.Add("growth_cha", new THint(65, RAW));

            Values.Add("crest_first", new THint(41, RAW, false));
            Values.Add("crest_second", new THint(42, RAW, false));

            Values.Add("character_class", new THint(28, RAW, false));

        }

        public void Write(ref TableController controller)
        {

            Save();
            spells.Save();
            skills.Save();
            arts.Save();

            // Write to Table Controller

            controller.Tables[0].contents[index] = this.RAW;
            controller.Tables[4].contents[index] = spells.RAW;
            controller.Tables[5].contents[index] = skills.RAW;
            controller.Tables[7].contents[index] = arts.RAW;
            
        }

    }
}
