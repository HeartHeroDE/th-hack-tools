using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace th_hack_tools
{

    public partial class Character_Editor : THForm
    {

        public THCharacter current_character;
        public bool reload = false;

        public Character_Editor()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            foreach(string character in Program.THData.Characters.Values)
            {
                List_Characters.Items.Add(character);
            }

            foreach (int crest in Program.THData.Crests.Keys)
            {
                Box_CrestFirst.Items.Add("0x" + crest.ToString("X2") + " " + Program.THData.Crests[crest]);
                Box_CrestSecond.Items.Add("0x" + crest.ToString("X2") + " " + Program.THData.Crests[crest]);
            }

            foreach (int character_class in Program.THData.Classes.Keys)
            {
                Box_Classes.Items.Add("0x" + character_class.ToString("X2") + " " + Program.THData.Classes[character_class]);
            }

            foreach (int spell in Program.THData.Spells.Keys)
            {
                Box_SpellFaith1.Items.Add("0x" + spell.ToString("X2") + " " + Program.THData.Spells[spell]);
                Box_SpellFaith2.Items.Add("0x" + spell.ToString("X2") + " " + Program.THData.Spells[spell]);
                Box_SpellFaith3.Items.Add("0x" + spell.ToString("X2") + " " + Program.THData.Spells[spell]);
                Box_SpellFaith4.Items.Add("0x" + spell.ToString("X2") + " " + Program.THData.Spells[spell]);
                Box_SpellFaith5.Items.Add("0x" + spell.ToString("X2") + " " + Program.THData.Spells[spell]);

                Box_SpellReason1.Items.Add("0x" + spell.ToString("X2") + " " + Program.THData.Spells[spell]);
                Box_SpellReason2.Items.Add("0x" + spell.ToString("X2") + " " + Program.THData.Spells[spell]);
                Box_SpellReason3.Items.Add("0x" + spell.ToString("X2") + " " + Program.THData.Spells[spell]);
                Box_SpellReason4.Items.Add("0x" + spell.ToString("X2") + " " + Program.THData.Spells[spell]);
                Box_SpellReason5.Items.Add("0x" + spell.ToString("X2") + " " + Program.THData.Spells[spell]);
            }

            foreach (int skill in Program.THData.Skills.Keys)
            {
                Box_SkillPersonal.Items.Add("0x" + skill.ToString("X2") + " " + Program.THData.Skills[skill]);
                Box_SkillTimeskip.Items.Add("0x" + skill.ToString("X2") + " " + Program.THData.Skills[skill]);

                Box_Skill3.Items.Add("0x" + skill.ToString("X2") + " " + Program.THData.Skills[skill]);
                Box_Skill4.Items.Add("0x" + skill.ToString("X2") + " " + Program.THData.Skills[skill]);
                Box_Skill5.Items.Add("0x" + skill.ToString("X2") + " " + Program.THData.Skills[skill]);
                Box_Skill6.Items.Add("0x" + skill.ToString("X2") + " " + Program.THData.Skills[skill]);
                Box_Skill7.Items.Add("0x" + skill.ToString("X2") + " " + Program.THData.Skills[skill]);
                Box_Skill8.Items.Add("0x" + skill.ToString("X2") + " " + Program.THData.Skills[skill]);
                Box_Skill9.Items.Add("0x" + skill.ToString("X2") + " " + Program.THData.Skills[skill]);
            }

            foreach (int art in Program.THData.Arts.Keys)
            {
                Box_CombatArt1.Items.Add("0x" + art.ToString("X2") + " " + Program.THData.Arts[art]);
                Box_CombatArt2.Items.Add("0x" + art.ToString("X2") + " " + Program.THData.Arts[art]);
                Box_CombatArt3.Items.Add("0x" + art.ToString("X2") + " " + Program.THData.Arts[art]);
                Box_CombatArt4.Items.Add("0x" + art.ToString("X2") + " " + Program.THData.Arts[art]);
                Box_CombatArt5.Items.Add("0x" + art.ToString("X2") + " " + Program.THData.Arts[art]);
            }

        }

        private void List_Characters_SelectedIndexChanged(object sender, EventArgs e)
        {
            reload = true;
            string character_name = List_Characters.SelectedItem.ToString();
            current_character = Program.THData.get_character(character_name);

            pictureBox1.Image = GetImageByName(character_name + "_s");
            Text_Name.Text = character_name;

            Box_Age.Value = current_character.Values["age"].Value;
            Box_Height.Value = current_character.Values["height"].Value;
            Box_Height_TS.Value = current_character.Values["height_ts"].Value;

            Box_Birthmonth.Value = current_character.Values["birth_month"].Value;
            Box_Birthday.Value = current_character.Values["birth_day"].Value;

            Box_BaseHP.Value = current_character.Values["base_hp"].Value;
            Box_BaseSTR.Value = current_character.Values["base_str"].Value;
            Box_BaseMAG.Value = current_character.Values["base_mag"].Value;
            Box_BaseDEX.Value = current_character.Values["base_dex"].Value;
            Box_BaseSPD.Value = current_character.Values["base_spd"].Value;
            Box_BaseLCK.Value = current_character.Values["base_lck"].Value;
            Box_BaseDEF.Value = current_character.Values["base_def"].Value;
            Box_BaseRES.Value = current_character.Values["base_res"].Value;
            Box_BaseMOV.Value = current_character.Values["base_mov"].Value;
            Box_BaseCHA.Value = current_character.Values["base_cha"].Value;

            Box_MaxHP.Value = current_character.Values["max_hp"].Value;
            Box_MaxSTR.Value = current_character.Values["max_str"].Value;
            Box_MaxMAG.Value = current_character.Values["max_mag"].Value;
            Box_MaxDEX.Value = current_character.Values["max_dex"].Value;
            Box_MaxSPD.Value = current_character.Values["max_spd"].Value;
            Box_MaxLCK.Value = current_character.Values["max_lck"].Value;
            Box_MaxDEF.Value = current_character.Values["max_def"].Value;
            Box_MaxRES.Value = current_character.Values["max_res"].Value;
            Box_MaxMOV.Value = current_character.Values["max_mov"].Value;
            Box_MaxCHA.Value = current_character.Values["max_cha"].Value;

            Box_GrowthHP.Value = current_character.Values["growth_hp"].Value;
            Box_GrowthSTR.Value = current_character.Values["growth_str"].Value;
            Box_GrowthMAG.Value = current_character.Values["growth_mag"].Value;
            Box_GrowthDEX.Value = current_character.Values["growth_dex"].Value;
            Box_GrowthSPD.Value = current_character.Values["growth_spd"].Value;
            Box_GrowthLCK.Value = current_character.Values["growth_lck"].Value;
            Box_GrowthDEF.Value = current_character.Values["growth_def"].Value;
            Box_GrowthRES.Value = current_character.Values["growth_res"].Value;
            Box_GrowthMOV.Value = current_character.Values["growth_mov"].Value;
            Box_GrowthCHA.Value = current_character.Values["growth_cha"].Value;

            ComboBoxSelect(Box_CrestFirst, current_character.Values["crest_first"].Value);
            ComboBoxSelect(Box_CrestSecond, current_character.Values["crest_second"].Value);

            ComboBoxSelect(Box_SpellFaith1, current_character.spells.Values["spell_faith_1"].Value);
            ComboBoxSelect(Box_SpellFaith2, current_character.spells.Values["spell_faith_2"].Value);
            ComboBoxSelect(Box_SpellFaith3, current_character.spells.Values["spell_faith_3"].Value);
            ComboBoxSelect(Box_SpellFaith4, current_character.spells.Values["spell_faith_4"].Value);
            ComboBoxSelect(Box_SpellFaith5, current_character.spells.Values["spell_faith_5"].Value);

            ComboBoxSelect(Box_SpellReason1, current_character.spells.Values["spell_reason_1"].Value);
            ComboBoxSelect(Box_SpellReason2, current_character.spells.Values["spell_reason_2"].Value);
            ComboBoxSelect(Box_SpellReason3, current_character.spells.Values["spell_reason_3"].Value);
            ComboBoxSelect(Box_SpellReason4, current_character.spells.Values["spell_reason_4"].Value);
            ComboBoxSelect(Box_SpellReason5, current_character.spells.Values["spell_reason_5"].Value);

            ComboBoxSelect(Box_SkillPersonal, current_character.skills.Values["skill_personal"].Value);
            ComboBoxSelect(Box_SkillTimeskip, current_character.skills.Values["skill_timeskip"].Value);

            ComboBoxSelect(Box_Skill3, current_character.skills.Values["skill_3"].Value);
            ComboBoxSelect(Box_Skill4, current_character.skills.Values["skill_4"].Value);
            ComboBoxSelect(Box_Skill5, current_character.skills.Values["skill_5"].Value);
            ComboBoxSelect(Box_Skill6, current_character.skills.Values["skill_6"].Value);
            ComboBoxSelect(Box_Skill7, current_character.skills.Values["skill_7"].Value);
            ComboBoxSelect(Box_Skill8, current_character.skills.Values["skill_8"].Value);
            ComboBoxSelect(Box_Skill9, current_character.skills.Values["skill_9"].Value);

            ComboBoxSelect(Box_Skill3Category, current_character.skills.Values["skill_category3"].Value);
            ComboBoxSelect(Box_Skill4Category, current_character.skills.Values["skill_category4"].Value);
            ComboBoxSelect(Box_Skill5Category, current_character.skills.Values["skill_category5"].Value);
            ComboBoxSelect(Box_Skill6Category, current_character.skills.Values["skill_category6"].Value);
            ComboBoxSelect(Box_Skill7Category, current_character.skills.Values["skill_category7"].Value);
            ComboBoxSelect(Box_Skill8Category, current_character.skills.Values["skill_category8"].Value);
            ComboBoxSelect(Box_Skill9Category, current_character.skills.Values["skill_category9"].Value);

            ComboBoxSelect(Box_Skill3Requirement, current_character.skills.Values["skill_requirement3"].Value);
            ComboBoxSelect(Box_Skill4Requirement, current_character.skills.Values["skill_requirement4"].Value);
            ComboBoxSelect(Box_Skill5Requirement, current_character.skills.Values["skill_requirement5"].Value);
            ComboBoxSelect(Box_Skill6Requirement, current_character.skills.Values["skill_requirement6"].Value);
            ComboBoxSelect(Box_Skill7Requirement, current_character.skills.Values["skill_requirement7"].Value);
            ComboBoxSelect(Box_Skill8Requirement, current_character.skills.Values["skill_requirement8"].Value);
            ComboBoxSelect(Box_Skill9Requirement, current_character.skills.Values["skill_requirement9"].Value);

            ComboBoxSelect(Box_CombatArt1, current_character.arts.Values["art_1"].Value);
            ComboBoxSelect(Box_CombatArt2, current_character.arts.Values["art_2"].Value);
            ComboBoxSelect(Box_CombatArt3, current_character.arts.Values["art_3"].Value);
            ComboBoxSelect(Box_CombatArt4, current_character.arts.Values["art_4"].Value);
            ComboBoxSelect(Box_CombatArt5, current_character.arts.Values["art_5"].Value);

            ComboBoxSelect(Box_CombatArt1_Category, current_character.arts.Values["art_1_category"].Value);
            ComboBoxSelect(Box_CombatArt2_Category, current_character.arts.Values["art_2_category"].Value);
            ComboBoxSelect(Box_CombatArt3_Category, current_character.arts.Values["art_3_category"].Value);
            ComboBoxSelect(Box_CombatArt4_Category, current_character.arts.Values["art_4_category"].Value);
            ComboBoxSelect(Box_CombatArt5_Category, current_character.arts.Values["art_5_category"].Value);

            ComboBoxSelect(Box_CombatArt1_Requirement, current_character.arts.Values["art_1_requirement"].Value);
            ComboBoxSelect(Box_CombatArt2_Requirement, current_character.arts.Values["art_2_requirement"].Value);
            ComboBoxSelect(Box_CombatArt3_Requirement, current_character.arts.Values["art_3_requirement"].Value);
            ComboBoxSelect(Box_CombatArt4_Requirement, current_character.arts.Values["art_4_requirement"].Value);
            ComboBoxSelect(Box_CombatArt5_Requirement, current_character.arts.Values["art_5_requirement"].Value);

            ComboBoxSelect(Box_Classes, current_character.Values["character_class"].Value);

            splitContainer1.Panel2.Enabled = true;
            reload = false;

        }

        private void Box_Classes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["character_class"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_CrestFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["crest_first"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_CrestSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["crest_second"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_SpellFaith1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.spells.Values["spell_faith_1"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_SpellFaith2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.spells.Values["spell_faith_2"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_SpellFaith3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.spells.Values["spell_faith_3"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_SpellFaith4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.spells.Values["spell_faith_4"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_SpellFaith5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.spells.Values["spell_faith_5"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_SpellReason1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.spells.Values["spell_reason_1"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_SpellReason2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.spells.Values["spell_reason_2"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_SpellReason3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.spells.Values["spell_reason_3"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_SpellReason4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.spells.Values["spell_reason_4"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_SpellReason5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.spells.Values["spell_reason_5"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_SkillPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_personal"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_SkillTimeskip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_timeskip"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_3"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_4"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_5"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_6"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_7"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_8"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_9"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill3Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_category3"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill4Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_category4"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill5Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_category5"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill6Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_category6"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill7Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_category7"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill8Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_category8"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill9Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_category9"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill3Requirement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_requirement3"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill4Requirement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_requirement4"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill5Requirement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_requirement5"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill6Requirement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_requirement6"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill7Requirement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_requirement7"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill8Requirement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_requirement8"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill9Requirement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.skills.Values["skill_requirement9"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Age_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["age"].Value = (int)Box_Age.Value;
        }

        private void Box_Birthday_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["birth_day"].Value = (int)Box_Birthday.Value;
        }

        private void Box_Birthmonth_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["birth_month"].Value = (int)Box_Birthmonth.Value;
        }

        private void Box_Height_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["height"].Value = (int)Box_Height.Value;
        }

        private void Box_Height_TS_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["height_ts"].Value = (int)Box_Height_TS.Value;
        }

        private void Box_BaseHP_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["base_hp"].Value = (int)Box_BaseHP.Value;
        }

        private void Box_BaseSTR_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["base_str"].Value = (int)Box_BaseSTR.Value;
        }

        private void Box_BaseMAG_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["base_mag"].Value = (int)Box_BaseMAG.Value;
        }

        private void Box_BaseDEX_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["base_dex"].Value = (int)Box_BaseDEX.Value;
        }

        private void Box_BaseSPD_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["base_spd"].Value = (int)Box_BaseSPD.Value;
        }

        private void Box_BaseLCK_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["base_lck"].Value = (int)Box_BaseLCK.Value;
        }

        private void Box_BaseDEF_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["base_def"].Value = (int)Box_BaseDEF.Value;
        }

        private void Box_BaseRES_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["base_res"].Value = (int)Box_BaseRES.Value;
        }

        private void Box_BaseMOV_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["base_mov"].Value = (int)Box_BaseMOV.Value;
        }

        private void Box_BaseCHA_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["base_cha"].Value = (int)Box_BaseCHA.Value;
        }

        private void Box_MaxHP_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["max_hp"].Value = (int)Box_MaxHP.Value;
        }

        private void Box_MaxSTR_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["max_str"].Value = (int)Box_MaxSTR.Value;
        }

        private void Box_MaxMAG_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["max_mag"].Value = (int)Box_MaxMAG.Value;
        }

        private void Box_MaxDEX_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["max_dex"].Value = (int)Box_MaxDEX.Value;
        }

        private void Box_MaxSPD_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["max_spd"].Value = (int)Box_MaxSPD.Value;
        }

        private void Box_MaxLCK_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["max_lck"].Value = (int)Box_MaxLCK.Value;
        }

        private void Box_MaxDEF_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["max_def"].Value = (int)Box_MaxDEF.Value;
        }

        private void Box_MaxRES_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["max_res"].Value = (int)Box_MaxRES.Value;
        }

        private void Box_MaxMOV_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["max_mov"].Value = (int)Box_MaxMOV.Value;
        }

        private void Box_MaxCHA_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["max_cha"].Value = (int)Box_MaxCHA.Value;
        }

        private void Box_GrowthHP_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["growth_hp"].Value = (int)Box_GrowthHP.Value;
        }

        private void Box_GrowthSTR_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["growth_str"].Value = (int)Box_GrowthSTR.Value;
        }

        private void Box_GrowthMAG_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["growth_mag"].Value = (int)Box_GrowthMAG.Value;
        }

        private void Box_GrowthDEX_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["growth_dex"].Value = (int)Box_GrowthDEX.Value;
        }

        private void Box_GrowthSPD_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["growth_spd"].Value = (int)Box_GrowthSPD.Value;
        }

        private void Box_GrowthLCK_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["growth_lck"].Value = (int)Box_GrowthLCK.Value;
        }

        private void Box_GrowthDEF_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["growth_def"].Value = (int)Box_GrowthDEF.Value;
        }

        private void Box_GrowthRES_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["growth_res"].Value = (int)Box_GrowthRES.Value;
        }

        private void Box_GrowthMOV_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["growth_mov"].Value = (int)Box_GrowthMOV.Value;
        }

        private void Box_GrowthCHA_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.Values["growth_cha"].Value = (int)Box_GrowthCHA.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.THData.initiate_data();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Box_CombatArt1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.arts.Values["art_1"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_CombatArt2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.arts.Values["art_2"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_CombatArt3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.arts.Values["art_3"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_CombatArt4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.arts.Values["art_4"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_CombatArt5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.arts.Values["art_5"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_CombatArt1_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.arts.Values["art_1_category"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_CombatArt2_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.arts.Values["art_2_category"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_CombatArt3_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.arts.Values["art_3_category"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_CombatArt4_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.arts.Values["art_4_category"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_CombatArt5_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.arts.Values["art_5_category"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_CombatArt1_Requirement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.arts.Values["art_1_requirement"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_CombatArt2_Requirement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.arts.Values["art_2_requirement"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_CombatArt3_Requirement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.arts.Values["art_3_requirement"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_CombatArt4_Requirement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.arts.Values["art_4_requirement"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_CombatArt5_Requirement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_character.arts.Values["art_5_requirement"].Value = ComboBoxHex((ComboBox)sender);
        }
    }
}
