using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace th_hack_tools
{
    public partial class Class_Editor : THForm
    {

        public THClass current_class;
        public bool reload = false;

        public Class_Editor()
        {
            InitializeComponent();
        }

        private void Class_Editor_Load(object sender, EventArgs e)
        {
            foreach (int current_class in Program.THData.Classes.Keys)
            {
                List_Classes.Items.Add("0x" + current_class.ToString("X2") + " " + Program.THData.Classes[current_class]);
            }

            foreach (int skill in Program.THData.Skills.Keys)
            {
                Box_Skill_Mastery.Items.Add("0x" + skill.ToString("X2") + " " + Program.THData.Skills[skill]);
                Box_Skill_1.Items.Add("0x" + skill.ToString("X2") + " " + Program.THData.Skills[skill]);
                Box_Skill_2.Items.Add("0x" + skill.ToString("X2") + " " + Program.THData.Skills[skill]);
                Box_Skill_3.Items.Add("0x" + skill.ToString("X2") + " " + Program.THData.Skills[skill]);
            }

            foreach (int art in Program.THData.Arts.Keys)
            {
                Box_Art_Mastery.Items.Add("0x" + art.ToString("X2") + " " + Program.THData.Arts[art]);
            }

        }

        private void List_Classes_SelectedIndexChanged(object sender, EventArgs e)
        {
            reload = true;
            string class_name = List_Classes.SelectedItem.ToString();
            current_class = Program.THData.get_class(List_Classes.SelectedIndex);

            Text_Name.Text = class_name;

            Box_BaseHP.Value = current_class.Values["base_hp"].Value;
            Box_BaseSTR.Value = current_class.Values["base_str"].Value;
            Box_BaseMAG.Value = current_class.Values["base_mag"].Value;
            Box_BaseDEX.Value = current_class.Values["base_dex"].Value;
            Box_BaseSPD.Value = current_class.Values["base_spd"].Value;
            Box_BaseLCK.Value = current_class.Values["base_lck"].Value;
            Box_BaseDEF.Value = current_class.Values["base_def"].Value;
            Box_BaseRES.Value = current_class.Values["base_res"].Value;
            Box_BaseMOV.Value = current_class.Values["base_mov"].Value;
            Box_BaseCHA.Value = current_class.Values["base_cha"].Value;

            Box_GrowthHP.Value = current_class.Values["growth_hp"].Value;
            Box_GrowthSTR.Value = current_class.Values["growth_str"].Value;
            Box_GrowthMAG.Value = current_class.Values["growth_mag"].Value;
            Box_GrowthDEX.Value = current_class.Values["growth_dex"].Value;
            Box_GrowthSPD.Value = current_class.Values["growth_spd"].Value;
            Box_GrowthLCK.Value = current_class.Values["growth_lck"].Value;
            Box_GrowthDEF.Value = current_class.Values["growth_def"].Value;
            Box_GrowthRES.Value = current_class.Values["growth_res"].Value;
            Box_GrowthMOV.Value = current_class.Values["growth_mov"].Value;
            Box_GrowthCHA.Value = current_class.Values["growth_cha"].Value;

            Box_EXP_Sword.Value = current_class.Values["exp_sword"].Value;
            Box_EXP_Lance.Value = current_class.Values["exp_lance"].Value;
            Box_EXP_Axe.Value = current_class.Values["exp_axe"].Value;
            Box_EXP_Bow.Value = current_class.Values["exp_bow"].Value;
            Box_EXP_Brawl.Value = current_class.Values["exp_brawl"].Value;
            Box_EXP_Reason.Value = current_class.Values["exp_reason"].Value;
            Box_EXP_Faith.Value = current_class.Values["exp_faith"].Value;
            Box_EXP_Authority.Value = current_class.Values["exp_authority"].Value;
            Box_EXP_Armor.Value = current_class.Values["exp_armor"].Value;
            Box_EXP_Riding.Value = current_class.Values["exp_riding"].Value;
            Box_EXP_Flying.Value = current_class.Values["exp_flying"].Value;

            ComboBoxSelect(Box_Skill_Mastery, current_class.skills.Values["mastery_skill"].Value);
            ComboBoxSelect(Box_Art_Mastery, current_class.skills.Values["mastery_art"].Value);

            ComboBoxSelect(Box_Skill_1, current_class.skills.Values["class_skill_1"].Value);
            ComboBoxSelect(Box_Skill_2, current_class.skills.Values["class_skill_2"].Value);
            ComboBoxSelect(Box_Skill_3, current_class.skills.Values["class_skill_3"].Value);

            ComboBoxSelect(Box_Lock, current_class.requirements.Values["genderlock"].Value);
            Box_Mastery_EXP.Value = current_class.Values["exp_mastery"].Value;

            ComboBoxSelect(Box_Requirement_Sword, current_class.requirements.Values["req_sword"].Value);
            ComboBoxSelect(Box_Requirement_Lance, current_class.requirements.Values["req_lance"].Value);
            ComboBoxSelect(Box_Requirement_Axe, current_class.requirements.Values["req_axe"].Value);
            ComboBoxSelect(Box_Requirement_Bow, current_class.requirements.Values["req_bow"].Value);
            ComboBoxSelect(Box_Requirement_Brawl, current_class.requirements.Values["req_brawl"].Value);
            ComboBoxSelect(Box_Requirement_Reason, current_class.requirements.Values["req_reason"].Value);
            ComboBoxSelect(Box_Requirement_Faith, current_class.requirements.Values["req_faith"].Value);
            ComboBoxSelect(Box_Requirement_Authority, current_class.requirements.Values["req_authority"].Value);
            ComboBoxSelect(Box_Requirement_Armor, current_class.requirements.Values["req_armor"].Value);
            ComboBoxSelect(Box_Requirement_Riding, current_class.requirements.Values["req_riding"].Value);
            ComboBoxSelect(Box_Requirement_Flying, current_class.requirements.Values["req_flying"].Value);

            splitContainer1.Panel2.Enabled = true;

            reload = false;

        }

        private void Box_Skill_Mastery_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["mastery_skill"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Art_Mastery_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["mastery_art"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["class_skill_1"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["class_skill_2"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Skill_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["class_skill_3"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_BaseHP_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["base_hp"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_BaseSTR_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["base_str"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_BaseMAG_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["base_mag"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_BaseDEX_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["base_dex"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_BaseSPD_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["base_spd"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_BaseLCK_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["base_lck"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_BaseDEF_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["base_def"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_BaseRES_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["base_res"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_BaseMOV_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["base_mov"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_BaseCHA_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["base_cha"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_GrowthHP_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["growth_hp"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_GrowthSTR_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["growth_str"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_GrowthMAG_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["growth_mag"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_GrowthDEX_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["growth_dex"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_GrowthSPD_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["growth_spd"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_GrowthLCK_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["growth_lck"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_GrowthDEF_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["growth_def"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_GrowthRES_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["growth_res"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_GrowthMOV_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["growth_mov"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_GrowthCHA_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["growth_cha"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_EXP_Sword_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["exp_sword"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_EXP_Lance_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["exp_lance"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_EXP_Axe_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["exp_axe"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_EXP_Bow_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["exp_bow"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_EXP_Brawl_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["exp_brawl"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_EXP_Reason_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["exp_reason"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_EXP_Faith_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["exp_faith"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_EXP_Authority_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["exp_authority"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_EXP_Armor_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["exp_armor"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_EXP_Riding_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["exp_riding"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_EXP_Flying_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["exp_flying"].Value = (int)((NumericUpDown)sender).Value;
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

        private void Box_Requirement_Sword_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.requirements.Values["req_sword"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Requirement_Lance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.requirements.Values["req_lance"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Requirement_Axe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.requirements.Values["req_axe"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Requirement_Bow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.requirements.Values["req_bow"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Requirement_Brawl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.requirements.Values["req_brawl"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Requirement_Reason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.requirements.Values["req_reason"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Requirement_Faith_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.requirements.Values["req_faith"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Requirement_Authority_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.requirements.Values["req_authority"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Requirement_Armor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.requirements.Values["req_armor"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Requirement_Riding_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.requirements.Values["req_riding"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Requirement_Flying_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.requirements.Values["req_flying"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Mastery_EXP_ValueChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.Values["exp_mastery"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_Lock_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!reload)
                current_class.requirements.Values["genderlock"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class_Editor_Levels class_editor_levels = new Class_Editor_Levels();
            class_editor_levels.ShowDialog();
        }
    }
}
