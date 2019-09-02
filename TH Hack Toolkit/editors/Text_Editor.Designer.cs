namespace th_hack_tools.editors
{
    partial class Text_Editor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Text_Editor));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Button_SaveClose = new System.Windows.Forms.Button();
            this.Button_ImportTable = new System.Windows.Forms.Button();
            this.Button_DumpTable = new System.Windows.Forms.Button();
            this.Split = new System.Windows.Forms.SplitContainer();
            this.Box_Tables = new System.Windows.Forms.ComboBox();
            this.TableTree = new System.Windows.Forms.TreeView();
            this.TreeImages = new System.Windows.Forms.ImageList(this.components);
            this.List_Strings = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Archive_Toolstrip = new System.Windows.Forms.ToolStrip();
            this.Button_ExportArchive = new System.Windows.Forms.ToolStripButton();
            this.Button_ImportArchive = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.SearchBox = new System.Windows.Forms.ToolStripTextBox();
            this.SearchButton = new System.Windows.Forms.ToolStripButton();
            this.Button_SaveArchive = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Split)).BeginInit();
            this.Split.Panel1.SuspendLayout();
            this.Split.Panel2.SuspendLayout();
            this.Split.SuspendLayout();
            this.Archive_Toolstrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Button_SaveClose);
            this.panel1.Controls.Add(this.Button_ImportTable);
            this.panel1.Controls.Add(this.Button_DumpTable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 427);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 40);
            this.panel1.TabIndex = 0;
            // 
            // Button_SaveClose
            // 
            this.Button_SaveClose.Location = new System.Drawing.Point(506, 7);
            this.Button_SaveClose.Name = "Button_SaveClose";
            this.Button_SaveClose.Size = new System.Drawing.Size(120, 23);
            this.Button_SaveClose.TabIndex = 2;
            this.Button_SaveClose.Text = "Save and close";
            this.Button_SaveClose.UseVisualStyleBackColor = true;
            this.Button_SaveClose.Click += new System.EventHandler(this.Button_SaveClose_Click);
            // 
            // Button_ImportTable
            // 
            this.Button_ImportTable.Location = new System.Drawing.Point(132, 7);
            this.Button_ImportTable.Name = "Button_ImportTable";
            this.Button_ImportTable.Size = new System.Drawing.Size(120, 23);
            this.Button_ImportTable.TabIndex = 1;
            this.Button_ImportTable.Text = "Import File";
            this.Button_ImportTable.UseVisualStyleBackColor = true;
            this.Button_ImportTable.Click += new System.EventHandler(this.Button_ImportTable_Click);
            // 
            // Button_DumpTable
            // 
            this.Button_DumpTable.Location = new System.Drawing.Point(6, 7);
            this.Button_DumpTable.Name = "Button_DumpTable";
            this.Button_DumpTable.Size = new System.Drawing.Size(120, 23);
            this.Button_DumpTable.TabIndex = 0;
            this.Button_DumpTable.Text = "Dump File";
            this.Button_DumpTable.UseVisualStyleBackColor = true;
            this.Button_DumpTable.Click += new System.EventHandler(this.Button_DumpTable_Click);
            // 
            // Split
            // 
            this.Split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Split.Location = new System.Drawing.Point(0, 0);
            this.Split.Name = "Split";
            // 
            // Split.Panel1
            // 
            this.Split.Panel1.Controls.Add(this.Box_Tables);
            this.Split.Panel1.Controls.Add(this.TableTree);
            this.Split.Panel1.Padding = new System.Windows.Forms.Padding(6);
            // 
            // Split.Panel2
            // 
            this.Split.Panel2.Controls.Add(this.List_Strings);
            this.Split.Panel2.Controls.Add(this.Archive_Toolstrip);
            this.Split.Panel2.Enabled = false;
            this.Split.Panel2.Padding = new System.Windows.Forms.Padding(6);
            this.Split.Size = new System.Drawing.Size(638, 427);
            this.Split.SplitterDistance = 160;
            this.Split.TabIndex = 1;
            // 
            // Box_Tables
            // 
            this.Box_Tables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Box_Tables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Box_Tables.FormattingEnabled = true;
            this.Box_Tables.Location = new System.Drawing.Point(6, 6);
            this.Box_Tables.Name = "Box_Tables";
            this.Box_Tables.Size = new System.Drawing.Size(148, 21);
            this.Box_Tables.TabIndex = 1;
            this.Box_Tables.SelectedIndexChanged += new System.EventHandler(this.Box_Tables_SelectedIndexChanged);
            // 
            // TableTree
            // 
            this.TableTree.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TableTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableTree.FullRowSelect = true;
            this.TableTree.ImageIndex = 0;
            this.TableTree.ImageList = this.TreeImages;
            this.TableTree.ItemHeight = 24;
            this.TableTree.Location = new System.Drawing.Point(6, 31);
            this.TableTree.Name = "TableTree";
            this.TableTree.SelectedImageIndex = 2;
            this.TableTree.Size = new System.Drawing.Size(148, 390);
            this.TableTree.TabIndex = 0;
            this.TableTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TableTree_NodeMouseClick);
            // 
            // TreeImages
            // 
            this.TreeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeImages.ImageStream")));
            this.TreeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeImages.Images.SetKeyName(0, "database.png");
            this.TreeImages.Images.SetKeyName(1, "table.png");
            this.TreeImages.Images.SetKeyName(2, "arrow.png");
            // 
            // List_Strings
            // 
            this.List_Strings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.List_Strings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.List_Strings.FullRowSelect = true;
            this.List_Strings.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.List_Strings.Location = new System.Drawing.Point(6, 31);
            this.List_Strings.MultiSelect = false;
            this.List_Strings.Name = "List_Strings";
            this.List_Strings.ShowGroups = false;
            this.List_Strings.Size = new System.Drawing.Size(462, 390);
            this.List_Strings.TabIndex = 1;
            this.List_Strings.UseCompatibleStateImageBehavior = false;
            this.List_Strings.View = System.Windows.Forms.View.Details;
            this.List_Strings.ItemActivate += new System.EventHandler(this.List_Strings_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Index";
            this.columnHeader1.Width = 48;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Text";
            this.columnHeader2.Width = 392;
            // 
            // Archive_Toolstrip
            // 
            this.Archive_Toolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Button_ExportArchive,
            this.Button_ImportArchive,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.SearchBox,
            this.SearchButton,
            this.Button_SaveArchive});
            this.Archive_Toolstrip.Location = new System.Drawing.Point(6, 6);
            this.Archive_Toolstrip.Name = "Archive_Toolstrip";
            this.Archive_Toolstrip.Size = new System.Drawing.Size(462, 25);
            this.Archive_Toolstrip.TabIndex = 0;
            this.Archive_Toolstrip.Text = "toolStrip1";
            // 
            // Button_ExportArchive
            // 
            this.Button_ExportArchive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_ExportArchive.Image = ((System.Drawing.Image)(resources.GetObject("Button_ExportArchive.Image")));
            this.Button_ExportArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_ExportArchive.Name = "Button_ExportArchive";
            this.Button_ExportArchive.Size = new System.Drawing.Size(23, 22);
            this.Button_ExportArchive.Text = "Export Archive";
            this.Button_ExportArchive.Click += new System.EventHandler(this.Button_ExportArchive_Click);
            // 
            // Button_ImportArchive
            // 
            this.Button_ImportArchive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_ImportArchive.Image = ((System.Drawing.Image)(resources.GetObject("Button_ImportArchive.Image")));
            this.Button_ImportArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_ImportArchive.Name = "Button_ImportArchive";
            this.Button_ImportArchive.Size = new System.Drawing.Size(23, 22);
            this.Button_ImportArchive.Text = "Import Archive";
            this.Button_ImportArchive.Click += new System.EventHandler(this.Button_ImportArchive_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel1.Text = "Search:";
            // 
            // SearchBox
            // 
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(100, 25);
            this.SearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBox_KeyDown);
            // 
            // SearchButton
            // 
            this.SearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SearchButton.Image = ((System.Drawing.Image)(resources.GetObject("SearchButton.Image")));
            this.SearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(23, 22);
            this.SearchButton.Text = "Search text";
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // Button_SaveArchive
            // 
            this.Button_SaveArchive.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Button_SaveArchive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_SaveArchive.Image = ((System.Drawing.Image)(resources.GetObject("Button_SaveArchive.Image")));
            this.Button_SaveArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_SaveArchive.Name = "Button_SaveArchive";
            this.Button_SaveArchive.Size = new System.Drawing.Size(23, 22);
            this.Button_SaveArchive.Text = "Save archive";
            this.Button_SaveArchive.Click += new System.EventHandler(this.Button_SaveArchive_Click);
            // 
            // Text_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 467);
            this.Controls.Add(this.Split);
            this.Controls.Add(this.panel1);
            this.Name = "Text_Editor";
            this.Text = "Text_Editor";
            this.Load += new System.EventHandler(this.Text_Editor_Load);
            this.panel1.ResumeLayout(false);
            this.Split.Panel1.ResumeLayout(false);
            this.Split.Panel2.ResumeLayout(false);
            this.Split.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Split)).EndInit();
            this.Split.ResumeLayout(false);
            this.Archive_Toolstrip.ResumeLayout(false);
            this.Archive_Toolstrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer Split;
        private System.Windows.Forms.Button Button_DumpTable;
        private System.Windows.Forms.TreeView TableTree;
        private System.Windows.Forms.Button Button_SaveClose;
        private System.Windows.Forms.Button Button_ImportTable;
        private System.Windows.Forms.ToolStrip Archive_Toolstrip;
        private System.Windows.Forms.ToolStripButton Button_ExportArchive;
        private System.Windows.Forms.ToolStripButton Button_ImportArchive;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox SearchBox;
        private System.Windows.Forms.ToolStripButton SearchButton;
        private System.Windows.Forms.ToolStripButton Button_SaveArchive;
        private System.Windows.Forms.ImageList TreeImages;
        private System.Windows.Forms.ListView List_Strings;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ComboBox Box_Tables;
    }
}