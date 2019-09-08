using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace th_hack_tools
{
    // This class should be used for common functions that are used between various classes
    // It will mostly consist of byte and streaming functions

    public static class th_utils
    {

        public static byte[] read_seek(FileStream fs, int offset, int length, SeekOrigin origin = SeekOrigin.Begin)
        {
            byte[] buffer = new byte[length];
            fs.Seek(offset, origin);
            fs.Read(buffer, 0, length);
            return buffer;
        }

    }
}
