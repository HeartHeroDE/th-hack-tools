using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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
    }
}
