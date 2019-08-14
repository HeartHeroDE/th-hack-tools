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
        private byte[] TextTable;
        private TableController CharacterTable;
        private TableController ClassTable;

        FileStream fs;

        public Dictionary<int, string> Characters;
        public Dictionary<int, string> Classes;
        public Dictionary<int, string> Crests;
        public Dictionary<int, string> Spells;
        public Dictionary<int, string> Skills;
        public Dictionary<int, string> Arts;
        public Dictionary<int, string> Items;

        private List<THCharacter> Character_data;
        private List<THClass> Class_data;

        public th_data(string file)
        {
            // Read the file into <bits>
            fs = new FileStream(file, FileMode.Open);
            TextTable = read_seek(0, 0x83580C);
            CharacterTable = new TableController(fs, 0x10EA800);
            ClassTable = new TableController(fs, 0x10E53E0);
            fs.Close();

            // Check if file is valid
            /*byte[] Data1Signature = new byte[10] { 18, 0, 0, 0, 148, 0, 0, 0, 164, 58 };
            if (string.Join("", CharacterTable.Take(10)) != string.Join("", Data1Signature))
            {
                throw new ArgumentException("Invalid file", "th_data");
            }*/

            // Get data from text tables
            Character_data = new List<THCharacter>();
            Characters = read_name_table(TextTable, 0x47CF7);

            Crests = read_name_table(TextTable, 0x1178A6, 0x117C5D);
            Crests.Add(0xFF, "No Crest");

            Spells = read_name_table(TextTable, 0x111B7B, 0x111CBB);
            Spells.Add(0xFF, "No Spell");

            Skills = read_name_table(TextTable, 0x10DB28, 0x10E856);
            Skills.Add(0xFF, "No Skill");

            Arts = read_name_table(TextTable, 0x10B759, 0x10BB0A);
            Arts.Add(0xFF, "No Art");

            Items = read_name_table(TextTable, 0xFFC3E, 0x100829);
            Items.Add(0xFF, "No Item");

            Class_data = new List<THClass>();
            Classes = read_name_table(TextTable, 0x4A3FA, 0x4A852);

            initiate_data();

            Console.WriteLine("Initiated TH Data.");
        }

        public void initiate_data()
        {
            Character_data.Clear();
            for (int i = 0; i < Characters.Count; i++)
            {
                Character_data.Add(new THCharacter(CharacterTable, i));
            }

            /*
            Class_data.Clear();
            for (int i = 0; i < Characters.Count; i++)
            {
                Class_data.Add(new THClass(ClassTable, i));
            }*/
        }

        Dictionary<int, string> read_name_table(byte[] table, int offset, int end = 0)
        {
            Dictionary<int, string> NameTable = new Dictionary<int, string>();
            List<byte> current_name = new List<byte>();
            int i = 0;

            while (!(table[offset] == 0 && table[offset - 1] == 0) && offset != end)
            {
                if (table[offset] == 0)
                {
                    NameTable.Add(i, Encoding.UTF8.GetString(current_name.ToArray()));
                    current_name.Clear();
                    i++;
                }
                else
                {
                    current_name.Add(table[offset]);
                }
                offset++;
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

        public THCharacter get_character(string name)
        {
            int index = Characters.FirstOrDefault(s => s.Value == name).Key;
            return Character_data[index];
        }

        public void Save(string file)
        {
            
            if (file != fs.Name)
                File.Copy(fs.Name, file, true);

            foreach (THCharacter character in Character_data)
            {
                character.Write(ref CharacterTable);
            }

            CharacterTable.Write(file);
            
        }

    }

    /// <summary>
    /// Loads an entire binary table and reads/writes all subtables.
    /// TODO: Add support for TEXT-Tables
    /// </summary>
    public class TableController
    {

        public Table[] Tables;
        int offset;

        public TableController(FileStream stream, int _offset)
        {
            offset = _offset;
            byte[] bits = new byte[4];
            stream.Seek(offset, SeekOrigin.Begin);
            stream.Read(bits, 0, 4);

            Tables = new Table[BitConverter.ToInt32(bits,0)];

            for (int i=0;i<Tables.Length;i++)
            {
                byte[] table;
                byte[] table_offset = new byte[4];
                byte[] table_length = new byte[4];

                stream.Seek(offset + 4 + i*8, SeekOrigin.Begin);
                stream.Read(table_offset, 0, 4);
                stream.Read(table_length, 0, 4);

                table = new byte[BitConverter.ToInt32(table_length, 0)];

                stream.Seek(offset + BitConverter.ToInt32(table_offset, 0), SeekOrigin.Begin);
                stream.Read(table, 0, table.Length);

                Tables[i] = new Table(table);

            }

        }

        public void Write(string file)
        {
            List<byte> new_header = new List<byte>();
            List<byte> new_data = new List<byte>();

            int test = Tables.Length;

            new_header.AddRange(BitConverter.GetBytes(Tables.Length));

            int table_offset = 4 + Tables.Length * 8;
            foreach (Table table in Tables)
            {
                List<byte> new_table = table.Save();

                new_header.AddRange(BitConverter.GetBytes(table_offset));
                new_header.AddRange(BitConverter.GetBytes(new_table.Count));

                while (new_table.Count % 4 != 0)
                {
                    new_table.Add((byte)0);
                }

                new_data.AddRange(new_table);
                table_offset += new_table.Count;
            }

            new_header.AddRange(new_data);

            using (var mmf = MemoryMappedFile.CreateFromFile(file, FileMode.Open, "table_"+offset))
            {
                using (var accessor = mmf.CreateViewAccessor(offset, new_header.Count))
                {

                    // Make changes to the view.
                    for (int i = 0; i < new_header.Count; i++)
                    {
                        accessor.Write(i, new_header[i]);
                    }
                }
            }

            Console.Write("Wrote Table Controller.");
        }

    }

    /// <summary>
    /// Reads/Writes binay subtables.
    /// </summary>
    public class Table
    {
        byte[] header = new byte[64];
        public List<byte[]> contents = new List<byte[]>();

        int unknown;
        int item_count;
        int item_length;

        public Table(byte[] data)
        {
            Array.Copy(data, 0, header, 0, header.Length);
            unknown = BitConverter.ToInt32(header, 0);
            item_count = BitConverter.ToInt32(header,4);
            item_length = BitConverter.ToInt32(header, 8);

            for(int i=0;i<item_count;i++)
            {
                byte[] item = new byte[item_length];
                int index = header.Length + item_length * i;
                Array.Copy(data, index, item, 0, item.Length);
                contents.Add(item);
            }
        }

        public List<byte> Save()
        {
            item_count = contents.Count;
            byte[] item_count_raw = BitConverter.GetBytes(item_count);
            Array.Copy(item_count_raw, 0, header, 4, 4);

            List<byte> new_table = new List<byte>();
            new_table.AddRange(header);

            foreach (byte[] item in contents)
            {
                new_table.AddRange(item);
            }

            return new_table;
        }

    }

    public class THint
    {
        private int Offset;
        public int Value;

        public THint(int offset, byte[] data)
        {
            Offset = offset;
            Value = data[offset];
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

    public class THClass : THObject
    {

        int index;

        public THClass(byte[] data, int class_index)
        {

            RAW = new byte[108];
            index = class_index;

            int offset = 0x94 + index * 108;
            Array.Copy(data, offset, RAW, 0, 30);

            //Values.Add("art_1", new THint(1, RAW));

        }
    }

    public class THCombatArtList : THObject
    {
        public THCombatArtList(Table data, int character_index)
        {
            RAW = data.contents[character_index].ToArray();

            Values.Add("art_1", new THint(1, RAW));
            Values.Add("art_2", new THint(2, RAW));
            Values.Add("art_3", new THint(3, RAW));
            Values.Add("art_4", new THint(4, RAW));
            Values.Add("art_5", new THint(5, RAW));

            Values.Add("art_1_category", new THint(11, RAW));
            Values.Add("art_2_category", new THint(12, RAW));
            Values.Add("art_3_category", new THint(13, RAW));
            Values.Add("art_4_category", new THint(14, RAW));
            Values.Add("art_5_category", new THint(15, RAW));

            Values.Add("art_1_requirement", new THint(21, RAW));
            Values.Add("art_2_requirement", new THint(22, RAW));
            Values.Add("art_3_requirement", new THint(23, RAW));
            Values.Add("art_4_requirement", new THint(24, RAW));
            Values.Add("art_5_requirement", new THint(25, RAW));
        }
    }

    public class THSkillList : THObject
    {

        public THSkillList(Table data, int character_index)
        {
            RAW = data.contents[character_index].ToArray();

            Values.Add("skill_personal", new THint(20, RAW));
            Values.Add("skill_timeskip", new THint(21, RAW));

            Values.Add("skill_3", new THint(22, RAW));
            Values.Add("skill_4", new THint(23, RAW));
            Values.Add("skill_5", new THint(24, RAW));
            Values.Add("skill_6", new THint(25, RAW));
            Values.Add("skill_7", new THint(26, RAW));
            Values.Add("skill_8", new THint(27, RAW));
            Values.Add("skill_9", new THint(28, RAW));

            Values.Add("skill_category3", new THint(0, RAW));
            Values.Add("skill_category4", new THint(1, RAW));
            Values.Add("skill_category5", new THint(2, RAW));
            Values.Add("skill_category6", new THint(3, RAW));
            Values.Add("skill_category7", new THint(4, RAW));
            Values.Add("skill_category8", new THint(5, RAW));
            Values.Add("skill_category9", new THint(6, RAW));

            Values.Add("skill_requirement3", new THint(42, RAW));
            Values.Add("skill_requirement4", new THint(43, RAW));
            Values.Add("skill_requirement5", new THint(44, RAW));
            Values.Add("skill_requirement6", new THint(45, RAW));
            Values.Add("skill_requirement7", new THint(46, RAW));
            Values.Add("skill_requirement8", new THint(47, RAW));
            Values.Add("skill_requirement9", new THint(48, RAW));

        }

    }

    public class THSpellList : THObject
    {

        public THSpellList(Table data, int character_index)
        {
            RAW = data.contents[character_index].ToArray();

            Values.Add("spell_reason_1", new THint(5, RAW));
            Values.Add("spell_reason_2", new THint(6, RAW));
            Values.Add("spell_reason_3", new THint(7, RAW));
            Values.Add("spell_reason_4", new THint(8, RAW));
            Values.Add("spell_reason_5", new THint(9, RAW));

            Values.Add("spell_faith_1", new THint(10, RAW));
            Values.Add("spell_faith_2", new THint(11, RAW));
            Values.Add("spell_faith_3", new THint(12, RAW));
            Values.Add("spell_faith_4", new THint(13, RAW));
            Values.Add("spell_faith_5", new THint(14, RAW));

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

            Values.Add("age", new THint(27, RAW));
            Values.Add("birth_day", new THint(29, RAW));
            Values.Add("birth_month", new THint(30, RAW));

            Values.Add("height", new THint(44, RAW));
            Values.Add("height_ts", new THint(45, RAW));

            Values.Add("base_hp", new THint(39, RAW));
            Values.Add("base_str", new THint(48, RAW));
            Values.Add("base_mag", new THint(49, RAW));
            Values.Add("base_dex", new THint(50, RAW));
            Values.Add("base_spd", new THint(51, RAW));
            Values.Add("base_lck", new THint(52, RAW));
            Values.Add("base_def", new THint(53, RAW));
            Values.Add("base_res", new THint(54, RAW));
            Values.Add("base_mov", new THint(55, RAW));
            Values.Add("base_cha", new THint(56, RAW));

            Values.Add("max_hp", new THint(34, RAW));
            Values.Add("max_str", new THint(66, RAW));
            Values.Add("max_mag", new THint(67, RAW));
            Values.Add("max_dex", new THint(68, RAW));
            Values.Add("max_spd", new THint(69, RAW));
            Values.Add("max_lck", new THint(70, RAW));
            Values.Add("max_def", new THint(71, RAW));
            Values.Add("max_res", new THint(72, RAW));
            Values.Add("max_mov", new THint(73, RAW));
            Values.Add("max_cha", new THint(74, RAW));

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

            Values.Add("crest_first", new THint(41, RAW));
            Values.Add("crest_second", new THint(42, RAW));

            Values.Add("character_class", new THint(28, RAW));

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
