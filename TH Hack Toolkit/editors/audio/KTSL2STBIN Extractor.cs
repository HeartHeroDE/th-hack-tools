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

namespace th_hack_tools.editors.audio
{
    public partial class KTSL2STBIN_Extractor : Form
    {
        public KTSL2STBIN_Extractor()
        {
            InitializeComponent();
        }

        private void export_check()
        {
            if (Box_Input.Text != "" && Box_Output.Text != "")
                Button_Extract.Enabled = true;
            else
                Button_Extract.Enabled = false;
        }

        private void SaveCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.Dispose();
            MessageBox.Show("All files have been extracted.", "Extraction successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Progress_Extract.Value = 0;
            this.Enabled = true;
        }

        private void SaveProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progress_Extract.Value = e.ProgressPercentage;
        }

        private void Button_Input_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog
            {
                InitialDirectory = Box_Input.Text,
                Title = "Import audio archive",

                CheckFileExists = true,
                CheckPathExists = true,

                Filter = "KTSL2STBIN Files|*.KTSL2STBIN",
                RestoreDirectory = true,

                ShowReadOnly = false
            };

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                Box_Input.Text = FileDialog.FileName;
                export_check();
            }

        }

        private void Button_Output_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FileDialog = new FolderBrowserDialog
            {
                SelectedPath = Box_Output.Text
            };

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                Box_Output.Text = FileDialog.SelectedPath;
                export_check();
            }
        }

        private void Button_Extract_Click(object sender, EventArgs e)
        {
            string output_folder = Box_Output.Text;
            string input_file = Box_Input.Text;

            if (!Directory.Exists(output_folder))
            {
                MessageBox.Show("The directory doesn't exist", "Extract Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!File.Exists(input_file))
            {
                MessageBox.Show("File doesn't exist", "Extract Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try {
                KTSL2STBIN extractor = new KTSL2STBIN();

                extractor.Completed += SaveCompleted;
                extractor.ProgressChanged += SaveProgressChanged;
                extractor.Extract(input_file, output_folder);

                this.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Extract Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Box_Output_TextChanged(object sender, EventArgs e)
        {
            export_check();
        }

        private void Box_Input_TextChanged(object sender, EventArgs e)
        {
            export_check();
        }
    }
}
