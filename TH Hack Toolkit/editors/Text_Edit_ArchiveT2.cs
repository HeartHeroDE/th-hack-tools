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
    public partial class Text_Edit_ArchiveT2 : THForm, ArchiveEdit
    {

        public string ArchiveText { get; set; }
        public int ArchiveArg1 { get; set; }
        public int ArchiveArg2 { get; set; }

        public Text_Edit_ArchiveT2(string message, int arg1, int arg2)
        {
            ArchiveText = decode_msgcode(message);
            ArchiveArg1 = arg1;
            ArchiveArg2 = arg2;

            InitializeComponent();
        }

        private void Text_Edit_ArchiveT2_Load(object sender, EventArgs e)
        {

            Number_Arg1.Value = ArchiveArg1;
            Number_Arg2.Value = ArchiveArg2;

            ArchiveBox.Text = ArchiveText;
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button_SaveClose_Click(object sender, EventArgs e)
        {
            ArchiveText = encode_msgcode(ArchiveBox.Text);
            ArchiveArg1 = (int)Number_Arg1.Value;
            ArchiveArg2 = (int)Number_Arg2.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
