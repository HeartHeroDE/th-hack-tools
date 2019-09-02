using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace th_hack_tools.editors
{

    public interface ArchiveEdit
    {
        string ArchiveText { get; set; }
        int ArchiveArg1 { get; set; }
        int ArchiveArg2 { get; set; }
    }

    public partial class Text_Edit_ArchiveT1 : THForm, ArchiveEdit
    {

        public string ArchiveText { get; set; }
        public int ArchiveArg1 { get; set; }
        public int ArchiveArg2 { get; set; }

        public Text_Edit_ArchiveT1(string message)
        {
            ArchiveText = decode_msgcode(message);

            InitializeComponent();
        }

        private void Text_Edit_ArchiveT1_Load(object sender, EventArgs e)
        {
            ArchiveBox.Text = ArchiveText;
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button_SaveClose_Click(object sender, EventArgs e)
        {
            ArchiveText = encode_msgcode(ArchiveBox.Text);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
