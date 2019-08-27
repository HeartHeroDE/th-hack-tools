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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private string current_file;

        private void Button_OpenFile_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            Update();

            if (current_file == null)
            {
                OpenFileDialog FileDialog = new OpenFileDialog
                {
                    InitialDirectory = @"C:\",
                    Title = "Open Data1",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "bin",
                    RestoreDirectory = true,

                    ShowReadOnly = false
                };

                if (FileDialog.ShowDialog() == DialogResult.OK)
                {
                    //try
                    //{
                        Program.THData = new th_data(FileDialog.FileName);
                        current_file = FileDialog.FileName;

                        Text = current_file + " - " + "TH Hacking Toolkit";
                        Button_OpenFile.Text = "Save File";
                        Group_Editors.Enabled = true;
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("This program only opens Data1.bin/Linkdata.bin files.", "File opening error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
            }
            else
            {
                SaveFileDialog FileDialog = new SaveFileDialog
                {
                    FileName = current_file,
                    Title = "Open Data1",

                    CheckPathExists = true,

                    Filter = "Binary File|*.bin",
                    RestoreDirectory = true,
                };

                if (FileDialog.ShowDialog() == DialogResult.OK)
                {
                    current_file = FileDialog.FileName;
                    Text = current_file + " - " + "TH Hacking Toolkit";
                    Program.THData.Save(current_file);

                    MessageBox.Show("Your changes have been saved.", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.THData = new th_data(current_file);
                }
            }
            UseWaitCursor = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/HeartHeroDE/th-hack-tools");
        }

        private void Button_CharacterEditor_Click(object sender, EventArgs e)
        {
            Character_Editor editor = new Character_Editor();
            editor.ShowDialog();
        }

        private void Button_ClassEditor_Click(object sender, EventArgs e)
        {
            Class_Editor editor = new Class_Editor();
            editor.ShowDialog();
        }
    }
}
