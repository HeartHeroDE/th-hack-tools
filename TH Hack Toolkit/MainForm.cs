using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            if (current_file == null)
            {
                OpenFileDialog FileDialog = new OpenFileDialog
                {
                    InitialDirectory = @"C:\",
                    Title = "Open Data1/Data0",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "bin",
                    RestoreDirectory = true,

                    ShowReadOnly = false
                };

                if (FileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Program.THData = new th_data(Path.GetDirectoryName(FileDialog.FileName));
                        current_file = FileDialog.FileName;

                        Text = current_file + " - " + "TH Hacking Toolkit";
                        Button_OpenFile.Text = "Save File";
                        Group_Editors.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "File opening error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                SaveFileDialog FileDialog = new SaveFileDialog
                {
                    FileName = current_file,
                    Title = "Choose a folder for DATA1.bin/DATA0.bin",

                    CheckPathExists = true,

                    Filter = "Binary File|*.bin",
                    RestoreDirectory = true,
                };

                if (FileDialog.ShowDialog() == DialogResult.OK)
                {
                    current_file = FileDialog.FileName;
                    Text = current_file + " - " + "TH Hacking Toolkit";

                    Program.THData.controller.Completed += SaveCompleted;
                    Program.THData.controller.ProgressChanged += SaveProgressChanged;
                    Program.THData.controller.Write(Path.GetDirectoryName(current_file));
                }
            }

        }

        private void SaveCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.Dispose();
            MessageBox.Show("Your changes have been saved.", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Progress_Save.Value = 0;
        }

        private void SaveProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progress_Save.Value = e.ProgressPercentage;
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
            using (Class_Editor editor = new Class_Editor())
            {
                editor.ShowDialog();
            }
        }

        private void Button_ItemEditor_Click(object sender, EventArgs e)
        {
            using (editors.Text_Editor editor = new editors.Text_Editor())
            {
                editor.ShowDialog();
            }
        }
    }
}
