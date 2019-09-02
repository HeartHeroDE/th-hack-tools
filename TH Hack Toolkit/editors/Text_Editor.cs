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

namespace th_hack_tools.editors
{
    public partial class Text_Editor : Form
    {

        private TableController current_controller;
        private int current_table;
        private int current_archive;
        private int search_index = 0;

        public Text_Editor()
        {
            InitializeComponent();
        }

        private void write_controller()
        {
            Program.THData.controller.Main_Tables[current_table] = new TableController(current_controller.Write().ToArray());
        }

        private void Text_Editor_Load(object sender, EventArgs e)
        {
            foreach (int index in Program.THData.controller.Main_Tables.Keys)
            {
                if (Program.THData.controller.Main_Tables[index].Tables[0] is TextTable)
                Box_Tables.Items.Add(index.ToString("X4"));
            }
            Box_Tables.SelectedIndex = 0;
        }

        private void TableTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            load_archive(e.Node);
        }

        private void Box_Tables_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_table = int.Parse(Box_Tables.SelectedItem.ToString(), System.Globalization.NumberStyles.HexNumber);
            current_controller = Program.THData.controller.Main_Tables[current_table];
            load_table();
        }

        private void load_archive(TreeNode current)
        {
            List_Strings.BeginUpdate();
            List_Strings.Items.Clear();

            if (current.Parent != null)
            {
                Split.Panel2.Enabled = true;
                
                current_table = int.Parse(current.Parent.Text.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                current_archive = int.Parse(current.Text, System.Globalization.NumberStyles.HexNumber);

                TextTable table = (TextTable)current_controller.Tables[current_table];
                List<string> current_strings = table.get_contents(current_archive);

                for (int i = 0; i < current_strings.Count; i++)
                {
                    ListViewItem listview_item = new ListViewItem();
                    listview_item.Text = i.ToString("X2");
                    listview_item.SubItems.Add(current_strings[i]);
                    List_Strings.Items.Add(listview_item);
                }
            }
            else
            {
                Split.Panel2.Enabled = false;
            }
            List_Strings.EndUpdate();
        }

        private void load_table()
        {
            TableTree.BeginUpdate();
            TableTree.Nodes.Clear();

            List_Strings.Items.Clear();
            Split.Panel2.Enabled = false;

            for (int i = 0; i < current_controller.Tables.Count; i++)
            {

                TreeNode main = new TreeNode(i.ToString("X2"));

                TextTable table = (TextTable)current_controller.Tables[i];

                string lang = "";
                switch (main.Text)
                {
                    case "00":
                        lang = "JPN";
                        break;
                    case "01":
                        lang = "ENG_E";
                        break;
                    case "02":
                        lang = "ENG_U";
                        break;
                    case "03":
                        lang = "DEU";
                        break;
                    case "04":
                        lang = "FRA_E";
                        break;
                    case "05":
                        lang = "FRA_U";
                        break;
                    case "06":
                        lang = "ES_E";
                        break;
                    case "07":
                        lang = "ES_U";
                        break;
                    case "08":
                        lang = "IT";
                        break;
                    case "09":
                        lang = "KOR";
                        break;
                    case "0A":
                        lang = "ZH_TW";
                        break;
                    case "0B":
                        lang = "ZH_CN";
                        break;
                }

                main.Text += " (" + lang + ")";

                for (int i2 = 0; i2 < table.archives.Count; i2++)
                {
                    main.Nodes.Add("archive_" + i2, i2.ToString("X2"), 1);
                }
                TableTree.Nodes.Add(main);
            }
            TableTree.EndUpdate();
        }

        private void search_text()
        {
            int last_index = search_index;
            for (int i = search_index; i < List_Strings.Items.Count; i++)
            {
                if (List_Strings.Items[i].SubItems[1].Text.Contains(SearchBox.Text))
                {
                    List_Strings.Items[i].Selected = true;
                    List_Strings.Select();
                    List_Strings.EnsureVisible(i);
                    search_index = i + 1;
                    break;
                }
            }

            if (last_index == search_index)
                search_index = 0;

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            search_text();
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                search_text();
        }

        private void Button_DumpTable_Click(object sender, EventArgs e)
        {
            SaveFileDialog FileDialog = new SaveFileDialog
            {
                FileName = "table.bin",
                Title = "Save active controller for text tables.",

                CheckPathExists = true,

                Filter = "Binary File|*.bin",
                RestoreDirectory = true,
            };

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] table = current_controller.Write().ToArray();
                File.WriteAllBytes(FileDialog.FileName, table);
            }
        }

        private void Button_ImportTable_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Import TableController",

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
                    byte[] import_data = File.ReadAllBytes(FileDialog.FileName);
                    current_controller = new TableController(import_data);
                    write_controller();
                    load_table();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error importing table file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Button_SaveClose_Click(object sender, EventArgs e)
        {
            write_controller();
            Close();
        }

        private void Button_ExportArchive_Click(object sender, EventArgs e)
        {
            SaveFileDialog FileDialog = new SaveFileDialog
            {
                FileName = "File.txt",
                Title = "Save text archive.",

                CheckPathExists = true,

                Filter = "Text File|*.txt",
                RestoreDirectory = true,
            };

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(FileDialog.FileName, FileMode.Create, FileAccess.Write);
                TextTable text_table = (TextTable)current_controller.Tables[current_table];
                List<string> strings = text_table.get_contents(current_archive);

                for (int i=0;i<strings.Count;i++)
                {
                    string s = strings[i].Replace("\n", "\\n");
                    byte[] s_bytes = Encoding.UTF8.GetBytes(s+"\n");
                    fs.Write(s_bytes, 0, s_bytes.Length);
                }

                fs.Close();
            }
        }

        private void Button_ImportArchive_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Import Text Archive.",

                CheckFileExists = true,
                CheckPathExists = true,

                Filter = "Text File|*.txt",
                RestoreDirectory = true
            };

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] archive_data = File.ReadAllLines(FileDialog.FileName);

                    for (int i = 0; i < archive_data.Length; i++)
                    {
                        archive_data[i] = archive_data[i].Replace("\\n", "\n");
                    }

                    

                    TextTable text_table = (TextTable)current_controller.Tables[current_table];
                    List<string> test_data = text_table.get_contents(current_archive);

                    text_table.set_contents(current_archive, archive_data.ToList());

                    current_controller.Tables[current_table] = text_table;
                    write_controller();

                    load_archive(TableTree.SelectedNode);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error importing text archive.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Button_SaveArchive_Click(object sender, EventArgs e)
        {
            List<string> new_contents = new List<string>();

            foreach(ListViewItem item in List_Strings.Items)
            {
                new_contents.Add(item.SubItems[1].Text);
            }

            TextTable text_table = (TextTable)current_controller.Tables[current_table];
            text_table.set_contents(current_archive, new_contents);
            current_controller.Tables[current_table] = text_table;
        }

        private void List_Strings_ItemActivate(object sender, EventArgs e)
        {

            if (List_Strings.SelectedItems.Count > 0)
            {
                TextTable text_table = (TextTable)current_controller.Tables[current_table];
                ListViewItem item = List_Strings.SelectedItems[0];
                int index = int.Parse(item.SubItems[0].Text, System.Globalization.NumberStyles.HexNumber);

                List<string> archive_strings = text_table.get_contents(current_archive);
                string active_string = archive_strings[index];

                Form archive_box;
                if (text_table.get_type(current_archive) == 1)
                {
                    archive_box = new Text_Edit_ArchiveT1(active_string);
                }
                else {
                    int character = text_table.get_args(current_archive, index,1);
                    int voice = text_table.get_args(current_archive, index,2);
                    archive_box = new Text_Edit_ArchiveT2(active_string,character,voice);
                }

                using (var form = archive_box)
                {

                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        ArchiveEdit data = (ArchiveEdit)form;
                        archive_strings[index] = data.ArchiveText;

                        text_table.set_contents(current_archive, archive_strings);
                        text_table.set_args(current_archive, index, data.ArchiveArg1, 1);
                        text_table.set_args(current_archive, index, data.ArchiveArg2, 2);

                        current_controller.Tables[current_table] = text_table;
                        item.SubItems[1].Text = data.ArchiveText;
                        List_Strings.Update();
                    }

                }
            }

        }
    }
}