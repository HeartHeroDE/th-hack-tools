using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace th_hack_tools.editors.audio
{

    public partial class KTSS_Interpreter : Form
    {
        OpusObject opusstream;

        public KTSS_Interpreter()
        {
            InitializeComponent();
        }

        private void KTSS_Interpreter_Load(object sender, EventArgs e)
        {

            

            /*
            fs = new FileStream(@"Y:\Switch Hacking\TH\kvs-tools-master\VGMStream\128.kns",FileMode.Open,FileAccess.Read);
            byte[] buffer = new byte[4];

            fs.Read(buffer, 0x0, 4);

            if (Encoding.ASCII.GetString(buffer) != "KTSS")
                throw new ArgumentException("Signature invalid.", "SIGNATURE_ERROR");

            total_length = BitConverter.ToUInt32(read_seek(0x4,4), 0);
            version = read_seek(0x22, 1)[0];

            if (version != 3)
                throw new ArgumentException("Invalid KTSS file.", "VERSION_ERROR");

            int coef_start_offset = 0x5c;
            int coef_spacing = 0x60;

            byte channel_multiplier = read_seek(0x28, 1)[0];
            int channel_count = read_seek(0x29, 1)[0] * channel_multiplier;

            uint num_samples = BitConverter.ToUInt32(read_seek(0x30, 4), 0);
            ushort sample_rate = BitConverter.ToUInt16(read_seek(0x2c, 2), 0);

            uint loop_start_sample = BitConverter.ToUInt32(read_seek(0x34, 4), 0);
            uint loop_end_sample = loop_start_sample + loop_length;

            fs.Close();
            */
            Console.Write("Finished");
        }

        private void Button_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog FileDialog = new SaveFileDialog
            {
                FileName = "new.ktss",
                Title = "Save KTSS file",

                CheckPathExists = true,

                Filter = "Koei Tecmo Sound Stream|*.ktss",
                RestoreDirectory = true,
            };

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (Check_Loop.Checked)
                        opusstream.Write(FileDialog.FileName, (int)Value_LoopStart.Value, (int)Value_LoopLength.Value);
                    else
                        opusstream.Write(FileDialog.FileName);

                    MessageBox.Show("Successfully exported audio as KTSS.", "Export finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "File save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void Button_Import_Click(object sender, EventArgs e)
        {

            OpenFileDialog FileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Import audio file",

                CheckFileExists = true,
                CheckPathExists = true,

                Filter = "Audio Files(*.wav;*.aiff;*.flac;*.ogg;*.opus)|*.WAV;*.AIFF;*.FLAC;*.OGG;*.OPUS",
                RestoreDirectory = true,

                ShowReadOnly = false
            };

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (Path.GetExtension(FileDialog.FileName) == ".opus")
                    {
                        opusstream = new OpusObject(FileDialog.FileName);
                    }
                    else
                    {
                        string opusenc_path = AppDomain.CurrentDomain.BaseDirectory + "editors" + Path.DirectorySeparatorChar + "audio" + Path.DirectorySeparatorChar + "opusenc.exe";
                        string tempfile = Path.GetDirectoryName(opusenc_path) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(FileDialog.FileName) + ".opus";

                        Process p = new Process();
                        p.StartInfo.FileName = opusenc_path;
                        p.StartInfo.Arguments = "--bitrate 192 --padding 0 --hard-cbr --framesize 20 \"" + FileDialog.FileName + "\" \"" + tempfile + "\"";
                        p.Start();

                        p.WaitForExit();

                        opusstream = new OpusObject(tempfile);
                    }

                    Box_Info.Text = opusstream.Print_info();
                    Group_Export.Enabled = true;
                        
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "File opening error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void Check_Loop_CheckedChanged(object sender, EventArgs e)
        {
            Panel_Loop.Enabled = Check_Loop.Checked;
        }
    }
}
