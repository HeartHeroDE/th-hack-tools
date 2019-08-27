using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace th_hack_tools
{
    public class th_data
    {
        private TableController CharacterTable;
        private TableController ClassTable;
        private TableController StringTable;
        private TextTable texts;

        FileStream fs;

        private List<THCharacter> Character_data;
        private List<THClass> Class_data;
        public THClassLevels ClassLevels;

        int string_table_end = 0;      // Offset for chunks after string table
        int chunks_between = 0x8AFBD4; // Chunks between text and class data
        int edit_size = 0;             // Total area of bytes that is editable starting from top

        /// <summary>
        /// Loads Three Houses Data with support for expansions
        /// </summary>
        /// <param name="file">Path to Data1.bin</param>
        public th_data(string file)
        {
            int relative_offset = 0;

            fs = new FileStream(file, FileMode.Open);
            StringTable = new TableController(fs, relative_offset);

            string_table_end = StringTable.total_length;
            relative_offset += string_table_end + chunks_between;
            ClassTable = new TableController(fs, relative_offset);

            relative_offset += ClassTable.total_length;
            CharacterTable = new TableController(fs, relative_offset);
            edit_size = relative_offset + CharacterTable.total_length;

            fs.Close();
            initiate_data();

            Console.WriteLine("Initiated TH Data.");
        }

        public void initiate_data()
        {
            texts = (TextTable)StringTable.Tables[1];

            Character_data = new List<THCharacter>();
            for (int i = 0; i < get_character_strings().Count; i++)
            {
                Character_data.Add(new THCharacter(CharacterTable, i));
            }


            Class_data = new List<THClass>();
            for (int i = 0; i < get_class_strings().Count; i++)
            {
                Class_data.Add(new THClass(ClassTable, i));
            }
            ClassLevels = new THClassLevels(ClassTable.Tables[2]);
        }

        Dictionary<int, string> read_name_table(Text_Archive archive, int start = 0, int items = 1)
        {
            Dictionary<int, string> NameTable = new Dictionary<int, string>();

            int index = 0;
            for (int i=start; i < start + items; i++)
            {
                NameTable.Add(index, archive.contents[i]);
                index++;
            }

            return NameTable;

        }

        byte[] read_seek(int offset, int length)
        {
            byte[] bits = new byte[length];
            fs.Seek(offset, SeekOrigin.Begin);
            fs.Read(bits, 0, length);
            return bits;
        }

        public THCharacter get_character(int index)
        {
            return Character_data[index];
        }

        public THClass get_class(int index)
        {
            return Class_data[index];
        }

        public Dictionary<int, string> get_character_strings()
        {
            Dictionary<int, string> Characters = read_name_table(texts.archives[2], 1156, 37);
            Characters[0] = Characters[0] + " (Male)";
            Characters[1] = Characters[1] + " (Female)";
            return Characters;
        }

        public Dictionary<int, string> get_class_strings()
        {
            return read_name_table(texts.archives[2], 3452, 90);
        }

        public Dictionary<int, string> get_crest_strings()
        {
            Dictionary<int, string> Crests = read_name_table(texts.archives[2], 9556, 48);
            Crests.Add(0xFF, "No Crest");
            return Crests;
        }

        public Dictionary<int, string> get_spell_strings()
        {
            Dictionary<int, string> Spells = read_name_table(texts.archives[2], 7802, 38);
            Spells.Add(0xFF, "No Spell");
            return Spells;
        }
        public Dictionary<int, string> get_skill_strings()
        {
            Dictionary<int, string> Skills = read_name_table(texts.archives[2], 7202, 238);
            Skills.Add(0xFF, "No Skill");
            return Skills;
        }

        public Dictionary<int, string> get_art_strings()
        {
            Dictionary<int, string> Arts = read_name_table(texts.archives[2], 5980, 77);
            Arts.Add(0xFF, "No Art");
            return Arts;
        }

        public Dictionary<int, string> get_item_strings()
        {
            Dictionary<int, string> Items = read_name_table(texts.archives[2], 4622, 26);
            Items.Add(0xFF, "No Item");
            return Items;
        }

        public void Save(string file)
        {

            fs = new FileStream(fs.Name, FileMode.Open);
            byte[] chunks = read_seek(string_table_end, chunks_between);

            foreach (THCharacter character in Character_data)
            {
                character.Write(ref CharacterTable);
            }

            foreach (THClass current_class in Class_data)
            {
                current_class.Write(ref ClassTable);
            }

            // Writing files in correct order

            using (FileStream writer = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                List<byte> strings = StringTable.Write(file);
                writer.Write(strings.ToArray(), 0, strings.Count);

                writer.Write(chunks, 0, chunks_between);

                ClassLevels.Write(ref ClassTable);

                List<byte> classes = ClassTable.Write(file);
                writer.Write(classes.ToArray(), 0, classes.Count);

                List<byte> characters = CharacterTable.Write(file);
                writer.Write(characters.ToArray(), 0, characters.Count);


                // Begin appending old, unedited data to new file
                fs.Seek(edit_size, SeekOrigin.Begin);

                // create a buffer to hold the bytes 
                byte[] buffer = new Byte[1024];
                int bytesRead;

                // while the read method returns bytes
                // keep writing them to the output stream
                while ((bytesRead =
                        fs.Read(buffer, 0, 1024)) > 0)
                {
                    writer.Write(buffer, 0, bytesRead);
                }

                writer.Close();
            }

            fs.Close();
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
