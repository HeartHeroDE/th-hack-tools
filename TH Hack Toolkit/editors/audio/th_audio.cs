using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using th_hack_tools;

namespace th_hack_tools.editors.audio
{
    public class OpusObject
    {
        FileStream fs;
        public List<byte> stream = new List<byte>();

        byte version = 0;
        public byte channel_count = 0;
        ushort preskip = 0;
        public uint input_sample_rate = 0;
        short output_gain = 0;
        byte channel_mapping_family = 0;

        int pages = 2;
        public int packets = 0;
        List<string> OpusTags = new List<string>();

        public OpusObject(string file)
        {
            // OGG Container read based on RFC 3533 -> https://www.ietf.org/rfc/rfc3533.txt
            // OPUS Codec read based on RFC 7845 -> https://www.ietf.org/rfc/rfc7845.txt

            if (Path.GetExtension(file) != ".opus")
                throw new ArgumentException("Unsupported file ending.", "FILE_READ_ERROR");

            fs = new FileStream(file, FileMode.Open, FileAccess.Read);

            byte[] buffer = th_utils.read_seek(fs, 0, 27);

            if (Encoding.ASCII.GetString(buffer, 0, 4) != "OggS")
                throw new ArgumentException("Invalid container format.", "OGG_READ_ERROR");

            if (buffer[4] != 0)
                throw new ArgumentException("Invalid container version.", "OGG_READ_ERROR");

            // Skip number of page segments
            fs.Seek(buffer[0x1A], SeekOrigin.Current);

            // OpusHead
            buffer = th_utils.read_seek(fs, 0, 19, SeekOrigin.Current);

            if (Encoding.ASCII.GetString(buffer, 0, 8) != "OpusHead")
                throw new ArgumentException("Invalid opus header.", "OPUS_READ_ERROR");

            version = buffer[8];
            channel_count = buffer[9];
            preskip = BitConverter.ToUInt16(buffer, 10);
            input_sample_rate = BitConverter.ToUInt32(buffer, 12);
            output_gain = BitConverter.ToInt16(buffer, 13);
            channel_mapping_family = buffer[15];

            // Skip next OggS header

            buffer = th_utils.read_seek(fs, 0, 27, SeekOrigin.Current);
            fs.Seek(buffer[0x1A], SeekOrigin.Current);

            // OpusTags
            buffer = th_utils.read_seek(fs, 0, 8, SeekOrigin.Current);

            if (Encoding.ASCII.GetString(buffer, 0, 8) != "OpusTags")
                throw new ArgumentException("Missing tag information.", "OPUS_READ_ERROR");

            buffer = th_utils.read_seek(fs, 0, 4, SeekOrigin.Current);
            uint string_length = BitConverter.ToUInt32(buffer, 0);

            buffer = th_utils.read_seek(fs, 0, (int)string_length, SeekOrigin.Current);
            OpusTags.Add(Encoding.ASCII.GetString(buffer));

            buffer = th_utils.read_seek(fs, 0, 4, SeekOrigin.Current);
            uint user_comments = BitConverter.ToUInt32(buffer, 0);

            for (int i = 0; i < user_comments; i++)
            {
                buffer = th_utils.read_seek(fs, 0, 4, SeekOrigin.Current);
                string_length = BitConverter.ToUInt32(buffer, 0);

                buffer = th_utils.read_seek(fs, 0, (int)string_length, SeekOrigin.Current);
                OpusTags.Add(Encoding.ASCII.GetString(buffer));
            }

            // Write stream in SwitchOpus format

            int bytesRead = -1;

            while (true)
            {

                buffer = new byte[4];
                fs.Read(buffer, 0, 4);
                fs.Seek(-4, SeekOrigin.Current);

                if (Encoding.ASCII.GetString(buffer, 0, 4) == "OggS")
                {
                    // OggS Header Skip
                    buffer = new byte[0x1B];
                    fs.Read(buffer, 0, 0x1B);
                    fs.Seek(buffer[0x1A], SeekOrigin.Current);
                    pages++;
                }

                // Opus Stream Write
                buffer = new byte[480];
                bytesRead = fs.Read(buffer, 0, 480);

                if (bytesRead > 4)
                {
                    // These bytes are still unknown, however no bugs were encountered using this octet of bytes
                    // It's probably a checksum for OPUS packets to avoid packet loss
                    stream.AddRange(new byte[8] { 0x0, 0x0, 0x1, 0xE0, 0x1, 0x0, 0x0, 0x0 });
                    stream.AddRange(buffer);
                    packets++;
                }
                else
                {
                    break;
                }

            }
            fs.Close();
        }

        public string Print_info()
        {
            string info = fs.Name + "\r\n" + "\r\n";
            info += "Samples: " + (packets * channel_count * 480) + "\r\n";
            info += "Sampling rate: " + input_sample_rate + "Hz \r\n";
            info += "Channels: " + channel_count + "\r\n";

            return info;
        }

        public void Write(string file, int loop_start = 0, int loop_length = 0)
        {
            using (FileStream writer = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                int count = stream.Count;

                // Magic signature
                writer.Write(new byte[4] { 0x4B, 0x54, 0x53, 0x53 }, 0, 4);
                writer.Write(BitConverter.GetBytes(count + 0x70), 0, 4);

                for (int i = 0; i < 0x18; i++)
                    writer.WriteByte(0);

                writer.Write(new byte[12] { 0x09, 0x00, 0x03, 0x03, 0x50, 0x00, 0x00, 0x00, 0x01, channel_count, 0x00, 0x00 }, 0, 12);
                writer.Write(BitConverter.GetBytes(input_sample_rate), 0, 4);

                int samples = packets * channel_count * 480;
                writer.Write(BitConverter.GetBytes(samples), 0, 4);

                writer.Write(BitConverter.GetBytes(loop_start), 0, 4);
                writer.Write(BitConverter.GetBytes(loop_length), 0, 4);

                writer.Write(new byte[4] { 0x00, 0x00, 0x00, 0x00 }, 0, 4);

                writer.Write(new byte[4] { 0x70, 0x00, 0x00, 0x00 }, 0, 4);
                writer.Write(BitConverter.GetBytes(count), 0, 4);

                for (int i = 0; i < 0x4; i++)
                    writer.WriteByte(0);

                writer.Write(BitConverter.GetBytes(packets), 0, 4);

                writer.Write(new byte[4] { 0xE8, 0x01, 0xC0, 0x03 }, 0, 4);
                writer.Write(BitConverter.GetBytes(input_sample_rate), 0, 4);

                writer.Write(new byte[8] { 0x78, 0x00, 0x01, 0x01, 0x00, 0x01, 0x00, 0x00 }, 0, 8);

                for (int i = 0; i < 0x10; i++)
                    writer.WriteByte(0);

                writer.Write(stream.ToArray(), 0, count);

                for (int i = 0; i < count%16; i++)
                    writer.WriteByte(0);

                writer.Close();
            }
        }

    }

    public class KTSL2STBIN
    {

        private BackgroundWorker worker;
        private FileStream fs;
        private int file_length;
        private byte[] buffer;

        private string output;

        public KTSL2STBIN()
        {
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = false;
            worker.WorkerReportsProgress = true;
            worker.DoWork += DoWork;
        }

        public void Extract(string input, string _output)
        {

            fs = new FileStream(input, FileMode.Open, FileAccess.Read);

            buffer = th_utils.read_seek(fs, 0, 0x10);

            if (BitConverter.ToString(buffer).Replace("-", "") != "4B5453520294DDFC01000004CE7456B7")
                throw new ArgumentException("Invalid data format.");

            buffer = th_utils.read_seek(fs, 0, 0x10, SeekOrigin.Current);

            file_length = BitConverter.ToInt32(buffer, 0x8);
            buffer = th_utils.read_seek(fs, 0x40, 0x40, SeekOrigin.Begin);
            output = _output;
            worker.RunWorkerAsync();
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            int jump_size = 0;
            int current_chunk = 0;
            int prevPercent = 0;

            while (fs.Position < file_length)
            {
                if (buffer.Length == 0x40)
                {
                    int ktss_length = BitConverter.ToInt32(buffer, 0x10);
                    jump_size = BitConverter.ToInt32(buffer, 0x4) - ktss_length - 0x40;
                    buffer = th_utils.read_seek(fs, 0, ktss_length, SeekOrigin.Current);
                    File.WriteAllBytes(output + Path.DirectorySeparatorChar + current_chunk.ToString("X8") + ".ktss", buffer);
                    current_chunk++;

                    int percent = Convert.ToInt32(((decimal)fs.Position / (decimal)file_length) * 100);
                    if (percent != prevPercent)
                    {
                        worker.ReportProgress(percent);
                        prevPercent = percent;
                    }

                }
                else
                {
                    buffer = th_utils.read_seek(fs, jump_size, 0x40, SeekOrigin.Current);
                }
            }
        }

        public event ProgressChangedEventHandler ProgressChanged
        {
            add { worker.ProgressChanged += value; }
            remove { worker.ProgressChanged -= value; }
        }

        public event RunWorkerCompletedEventHandler Completed
        {
            add { worker.RunWorkerCompleted += value; }
            remove { worker.RunWorkerCompleted -= value; }
        }

    }

}
