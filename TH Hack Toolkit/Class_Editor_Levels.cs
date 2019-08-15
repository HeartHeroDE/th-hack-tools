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
        public Class_Editor_Levels()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Box_Beginner_ValueChanged(object sender, EventArgs e)
        {
            Program.THData.ClassLevels.Values["lv_beginner"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Intermediate_ValueChanged(object sender, EventArgs e)
        {
            Program.THData.ClassLevels.Values["lv_intermediate"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Advanced_ValueChanged(object sender, EventArgs e)
        {
            Program.THData.ClassLevels.Values["lv_advanced"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Box_Master_ValueChanged(object sender, EventArgs e)
        {
            Program.THData.ClassLevels.Values["lv_master"].Value = ComboBoxHex((ComboBox)sender);
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Class_Editor_Levels_Load(object sender, EventArgs e)
        {
            Box_Beginner.Value = Program.THData.ClassLevels.Values["lv_beginner"].Value;
            Box_Intermediate.Value = Program.THData.ClassLevels.Values["lv_intermediate"].Value;
            Box_Advanced.Value = Program.THData.ClassLevels.Values["lv_advanced"].Value;
            Box_Master.Value = Program.THData.ClassLevels.Values["lv_master"].Value;
        }
    }
}
