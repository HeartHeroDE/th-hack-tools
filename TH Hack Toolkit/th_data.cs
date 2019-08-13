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
        private byte[] CharacterTable;

        FileStream fs;
        private string opened_file;

        private int character_table_offset = 0x10EA800;
        private int character_table_length = 0x1CD74;

        public Dictionary<int, string> Characters;
        public Dictionary<int, string> Classes;
        public Dictionary<int, string> Crests;
        public Dictionary<int,string> Spells;
        public Dictionary<int, string> Skills;

        private List<THCharacter> Character_data;

        public th_data(string file)
        {
            // Read the file into <bits>
            fs = new FileStream(file, FileMode.Open);
            TextTable = read_seek(0, 0x83580C);
            CharacterTable = read_seek(character_table_offset, character_table_length);
            fs.Close();

            // Check if file is valid
            byte[] Data1Signature = new byte[10] { 18,0,0,0,148,0,0,0,164,58 };
            if (string.Join("",CharacterTable.Take(10)) != string.Join("",Data1Signature))
            {
                throw new ArgumentException("Invalid file", "th_data");
            }

            // Get data from text tables
            Character_data = new List<THCharacter>();
            Characters = read_name_table(TextTable, 0x47CF7);

            Crests = read_name_table(TextTable, 0x1178A6, 0x117C5D);
            Crests.Add(0xFF, "No Crest");

            Spells = read_name_table(TextTable, 0x111B7B, 0x111CBB);
            Spells.Add(0xFF, "No Spell");

            Skills = read_name_table(TextTable, 0x10DB28, 0x10E856);
            Skills.Add(0xFF, "No Skill");

            Classes = read_name_table(TextTable, 0x4A3FA, 0x4A852);

            initiate_data();

            opened_file = file;
        }

        public void initiate_data()
        {
            Character_data.Clear();
            for (int i = 0; i < Characters.Count; i++)
            {
                Character_data.Add(new THCharacter(CharacterTable, i));
            }
        }

        Dictionary<int, string> read_name_table (byte[] table, int offset, int end = 0)
        {
            Dictionary<int,string> NameTable = new Dictionary<int, string>();
            List<byte> current_name = new List<byte>();
            int i = 0;

            while (!(table[offset] == 0 && table[offset - 1] == 0) && offset != end)
            {
                if (table[offset] == 0)
                {
                    NameTable.Add(i,Encoding.UTF8.GetString(current_name.ToArray()));
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

        byte[] read_seek (int offset, int length)
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
            if (file != opened_file)
                File.Copy(opened_file, file, true);

            foreach (THCharacter character in Character_data)
            {
                character.Save(ref CharacterTable);
            }

            using (var mmf = MemoryMappedFile.CreateFromFile(file, FileMode.Open, "character_table"))
            {
                using (var accessor = mmf.CreateViewAccessor(character_table_offset, character_table_length))
                {

                    // Make changes to the view.
                    for (int i = 0; i < character_table_length; i++)
                    {
                        accessor.Write(i, CharacterTable[i]);
                    }
                }
            }

        }

    }

    public class THint
    {
        private int Offset;
        public int Value;

        public THint(int offset, int value)
        {
            Offset = offset;
            Value = value;
        }

        public byte[] Save(ref byte[] data)
        {
            data[Offset] = (byte)Value;
            return data;
        }

    }

    public class THSkillList
    {
        public byte[] RAW;
        public Dictionary<string, THint> Values = new Dictionary<string, THint>();

        public THSkillList(byte[] data, int offset)
        {
            RAW = new byte[62];
            Array.Copy(data, offset, RAW, 0, 62);

            Values.Add("skill_personal", new THint(20, RAW[20]));
            Values.Add("skill_timeskip", new THint(21, RAW[21]));

            Values.Add("skill_3", new THint(22, RAW[22]));
            Values.Add("skill_4", new THint(23, RAW[23]));
            Values.Add("skill_5", new THint(24, RAW[24]));
            Values.Add("skill_6", new THint(25, RAW[25]));
            Values.Add("skill_7", new THint(26, RAW[26]));
            Values.Add("skill_8", new THint(27, RAW[27]));
            Values.Add("skill_9", new THint(28, RAW[28]));

            Values.Add("skill_category3", new THint(0, RAW[0]));
            Values.Add("skill_category4", new THint(1, RAW[1]));
            Values.Add("skill_category5", new THint(2, RAW[2]));
            Values.Add("skill_category6", new THint(3, RAW[3]));
            Values.Add("skill_category7", new THint(4, RAW[4]));
            Values.Add("skill_category8", new THint(5, RAW[5]));
            Values.Add("skill_category9", new THint(6, RAW[6]));

            Values.Add("skill_requirement3", new THint(42, RAW[42]));
            Values.Add("skill_requirement4", new THint(43, RAW[43]));
            Values.Add("skill_requirement5", new THint(44, RAW[44]));
            Values.Add("skill_requirement6", new THint(45, RAW[45]));
            Values.Add("skill_requirement7", new THint(46, RAW[46]));
            Values.Add("skill_requirement8", new THint(47, RAW[47]));
            Values.Add("skill_requirement9", new THint(48, RAW[48]));

        }

        public byte[] Save()
        {
            foreach (KeyValuePair<string, THint> entry in Values)
            {
                entry.Value.Save(ref RAW);
            }
            return RAW;
        }

    }

    public class THSpellList
    {
        public byte[] RAW;
        public Dictionary<string, THint> Values = new Dictionary<string, THint>();

        public THSpellList(byte[] data, int offset)
        {
            RAW = new byte[20];
            Array.Copy(data, offset, RAW, 0, 20);

            Values.Add("spell_reason_1", new THint(6, RAW[6]));
            Values.Add("spell_reason_2", new THint(7, RAW[7]));
            Values.Add("spell_reason_3", new THint(8, RAW[8]));
            Values.Add("spell_reason_4", new THint(9, RAW[9]));
            Values.Add("spell_reason_5", new THint(10, RAW[10]));

            Values.Add("spell_faith_1", new THint(11, RAW[11]));
            Values.Add("spell_faith_2", new THint(12, RAW[12]));
            Values.Add("spell_faith_3", new THint(13, RAW[13]));
            Values.Add("spell_faith_4", new THint(14, RAW[14]));
            Values.Add("spell_faith_5", new THint(15, RAW[15]));

        }

        public byte[] Save()
        {

            foreach (KeyValuePair<string, THint> entry in Values)
            {
                entry.Value.Save(ref RAW);
            }
            return RAW;
        }

    }

    public class THCharacter
    {
        byte[] RAW;
        int index;

        public Dictionary<string, THint> Values = new Dictionary<string, THint>();

        public THSpellList spells;
        public THSkillList skills;

        public THCharacter(byte[] data, int character_index)
        {
            RAW = new byte[76];
            index = character_index;

            int offset = 0xD3 + index * 76;
            
            Array.Copy(data, offset, RAW, 0, 76);

            Values.Add("age",new THint(28, RAW[28]));
            Values.Add("birth_day",new THint(30, RAW[30]));
            Values.Add("birth_month", new THint(31, RAW[31]));

            Values.Add("height", new THint(45, RAW[45]));
            Values.Add("height_ts", new THint(46, RAW[46]));

            Values.Add("base_hp", new THint(40, RAW[40]));
            Values.Add("base_str", new THint(49, RAW[49]));
            Values.Add("base_mag", new THint(50, RAW[50]));
            Values.Add("base_dex", new THint(51, RAW[51]));
            Values.Add("base_spd", new THint(52, RAW[52]));
            Values.Add("base_lck", new THint(53, RAW[53]));
            Values.Add("base_def", new THint(54, RAW[54]));
            Values.Add("base_res", new THint(55, RAW[55]));
            Values.Add("base_mov", new THint(56, RAW[56]));
            Values.Add("base_cha", new THint(57, RAW[57]));

            Values.Add("max_hp", new THint(35, RAW[35]));
            Values.Add("max_str", new THint(67, RAW[67]));
            Values.Add("max_mag", new THint(68, RAW[68]));
            Values.Add("max_dex", new THint(69, RAW[69]));
            Values.Add("max_spd", new THint(70, RAW[70]));
            Values.Add("max_lck", new THint(71, RAW[71]));
            Values.Add("max_def", new THint(72, RAW[72]));
            Values.Add("max_res", new THint(73, RAW[73]));
            Values.Add("max_mov", new THint(74, RAW[74]));
            Values.Add("max_cha", new THint(75, RAW[75]));

            Values.Add("growth_hp", new THint(38, RAW[38]));
            Values.Add("growth_str", new THint(58, RAW[58]));
            Values.Add("growth_mag", new THint(59, RAW[59]));
            Values.Add("growth_dex", new THint(60, RAW[60]));
            Values.Add("growth_spd", new THint(61, RAW[61]));
            Values.Add("growth_lck", new THint(62, RAW[62]));
            Values.Add("growth_def", new THint(63, RAW[63]));
            Values.Add("growth_res", new THint(64, RAW[64]));
            Values.Add("growth_mov", new THint(65, RAW[65]));
            Values.Add("growth_cha", new THint(66, RAW[66]));

            Values.Add("crest_first", new THint(42, RAW[42]));
            Values.Add("crest_second", new THint(43, RAW[43]));

            Values.Add("character_class", new THint(29, RAW[29]));

            offset = 0x169C3 + index * 20;
            spells = new THSpellList(data,offset);

            offset = 0x16CE8 + index * 62;
            skills = new THSkillList(data, offset);

        }

        public void Save(ref byte[] table)
        {

            // Trigger saves

            foreach (KeyValuePair<string, THint> entry in Values)
            {
                entry.Value.Save(ref RAW);
            }

            // Write to Byte Array

            int offset = 0xD3 + index * 76;
            Array.Copy(RAW, 0, table, offset, 76);

            offset = 0x169C3 + index * 20;
            Array.Copy(spells.Save(), 0, table, offset, 20);

            offset = 0x16CE8 + index * 62;
            Array.Copy(skills.Save(), 0, table, offset, 62);

        }

    }
}
