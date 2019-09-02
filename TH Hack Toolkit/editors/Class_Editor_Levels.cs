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
    public partial class Class_Editor_Levels : THForm
    {

        public THClassLevels ClassLevels;

        public Class_Editor_Levels()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableController new_classtable = Program.THData.controller.Main_Tables[11];
            ClassLevels.Write(ref new_classtable);
            Program.THData.controller.Main_Tables[11] = new_classtable;
            Close();
        }

        private void Box_Beginner_ValueChanged(object sender, EventArgs e)
        {
            ClassLevels.Values["lv_beginner"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_Intermediate_ValueChanged(object sender, EventArgs e)
        {
            ClassLevels.Values["lv_intermediate"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_Advanced_ValueChanged(object sender, EventArgs e)
        {
            ClassLevels.Values["lv_advanced"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Box_Master_ValueChanged(object sender, EventArgs e)
        {
            ClassLevels.Values["lv_master"].Value = (int)((NumericUpDown)sender).Value;
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Class_Editor_Levels_Load(object sender, EventArgs e)
        {
            ClassLevels = new THClassLevels(Program.THData.get_class_table().Tables[2]);

            Box_Beginner.Value = ClassLevels.Values["lv_beginner"].Value;
            Box_Intermediate.Value = ClassLevels.Values["lv_intermediate"].Value;
            Box_Advanced.Value = ClassLevels.Values["lv_advanced"].Value;
            Box_Master.Value = ClassLevels.Values["lv_master"].Value;
        }
    }
}
