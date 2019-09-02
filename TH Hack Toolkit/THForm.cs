using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace th_hack_tools
{
    /// <summary>
    /// Form with helper classes for displaying HEX data
    /// </summary>
    public class THForm : Form
    {

        public static Bitmap GetImageByName(string imageName)
        {
            return (Bitmap)Properties.Resources.ResourceManager.GetObject(imageName);

        }

        public void ComboBoxSelect(ComboBox box, int value)
        {
            box.SelectedIndex = box.Items.Count - 1;
            for (int i = 0; i < box.Items.Count; i++)
            {

                if (HexItem(box.Items[i].ToString()) == value)
                {
                    box.SelectedIndex = i;
                }

            }
        }

        public int HexItem(string item)
        {
            string[] split = item.Split(' ');
            return int.Parse(split[0].Substring(2), System.Globalization.NumberStyles.HexNumber);
        }

        public int ComboBoxHex(ComboBox box)
        {
            return HexItem(box.SelectedItem.ToString());
        }

        public string decode_msgcode(string input)
        {
            byte[] utf = Encoding.UTF8.GetBytes(input);
            string new_string = Encoding.UTF8.GetString(utf);

            new_string = new_string.Replace("\n", "\r\n");
            new_string = new Regex("[\x1b](C[0-9])(.*?)\x1bR", RegexOptions.Singleline).Replace(new_string, "<$1>$2</$1>");
            new_string = new Regex("[\x1b]EK([0-9]{2})(.*?)[\x1b]EL[0-9]{2}(.*?)[\x1b]EM[0-9]{2}", RegexOptions.Singleline).Replace(new_string, "<ismale character=\"$1\">$2<else/>$3</ismale>");
            new_string = new Regex("[\x1b]S([0-9])").Replace(new_string, "<string id=\"$1\"/>");
            new_string = new Regex("\x1b%").Replace(new_string, "\\%");
            return new_string;
        }

        public string encode_msgcode(string input)
        {
            byte[] utf = Encoding.UTF8.GetBytes(input);
            string new_string = Encoding.UTF8.GetString(utf);

            new_string = new_string.Replace("\r\n", "\n");
            new_string = new Regex("<C([0-9])>(.*?)<\\/C[0-9]>").Replace(new_string, "\x001bC$1$2\x001bR");
            new_string = new Regex("<ismale character=\"([0-9]{2})\">(.*?)<else/>(.*?)</ismale>").Replace(new_string, "\x001bEK$1$2\x001bEL$1$3\x001bEM$1");
            new_string = new Regex("<string id=\"([0-9])\" />").Replace(new_string, "\x001bS$1");
            new_string = new Regex("\\%").Replace(new_string, "\x001b%");
            return new_string;
        }

    }
}
