namespace th_hack_tools
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Button_ClassEditor = new System.Windows.Forms.Button();
            this.Button_ItemEditor = new System.Windows.Forms.Button();
            this.Button_CharacterEditor = new System.Windows.Forms.Button();
            this.Panel_ROM = new System.Windows.Forms.TableLayoutPanel();
            this.Button_OpenFile = new System.Windows.Forms.Button();
            this.Button_Github = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Progress_Save = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Panel_Audio = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Button_KTSL2STBIN_Extractor = new System.Windows.Forms.Button();
            this.Button_KTSS_Exporter = new System.Windows.Forms.Button();
            this.Panel_ROM.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Panel_Audio.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_ClassEditor
            // 
            this.Button_ClassEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_ClassEditor.Location = new System.Drawing.Point(9, 55);
            this.Button_ClassEditor.Name = "Button_ClassEditor";
            this.Button_ClassEditor.Size = new System.Drawing.Size(316, 40);
            this.Button_ClassEditor.TabIndex = 1;
            this.Button_ClassEditor.Text = "Class Editor";
            this.Button_ClassEditor.UseVisualStyleBackColor = true;
            this.Button_ClassEditor.Click += new System.EventHandler(this.Button_ClassEditor_Click);
            // 
            // Button_ItemEditor
            // 
            this.Button_ItemEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_ItemEditor.Location = new System.Drawing.Point(9, 101);
            this.Button_ItemEditor.Name = "Button_ItemEditor";
            this.Button_ItemEditor.Size = new System.Drawing.Size(316, 40);
            this.Button_ItemEditor.TabIndex = 2;
            this.Button_ItemEditor.Text = "Text Editor";
            this.Button_ItemEditor.UseVisualStyleBackColor = true;
            this.Button_ItemEditor.Click += new System.EventHandler(this.Button_ItemEditor_Click);
            // 
            // Button_CharacterEditor
            // 
            this.Button_CharacterEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_CharacterEditor.Location = new System.Drawing.Point(9, 9);
            this.Button_CharacterEditor.Name = "Button_CharacterEditor";
            this.Button_CharacterEditor.Size = new System.Drawing.Size(316, 40);
            this.Button_CharacterEditor.TabIndex = 0;
            this.Button_CharacterEditor.Text = "Character Editor";
            this.Button_CharacterEditor.UseVisualStyleBackColor = true;
            this.Button_CharacterEditor.Click += new System.EventHandler(this.Button_CharacterEditor_Click);
            // 
            // Panel_ROM
            // 
            this.Panel_ROM.ColumnCount = 1;
            this.Panel_ROM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Panel_ROM.Controls.Add(this.Button_CharacterEditor, 0, 0);
            this.Panel_ROM.Controls.Add(this.Button_ItemEditor, 0, 2);
            this.Panel_ROM.Controls.Add(this.Button_ClassEditor, 0, 1);
            this.Panel_ROM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_ROM.Enabled = false;
            this.Panel_ROM.Location = new System.Drawing.Point(3, 3);
            this.Panel_ROM.Name = "Panel_ROM";
            this.Panel_ROM.Padding = new System.Windows.Forms.Padding(6);
            this.Panel_ROM.RowCount = 3;
            this.Panel_ROM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.Panel_ROM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.Panel_ROM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.Panel_ROM.Size = new System.Drawing.Size(334, 149);
            this.Panel_ROM.TabIndex = 0;
            // 
            // Button_OpenFile
            // 
            this.Button_OpenFile.Location = new System.Drawing.Point(19, 52);
            this.Button_OpenFile.Name = "Button_OpenFile";
            this.Button_OpenFile.Size = new System.Drawing.Size(219, 86);
            this.Button_OpenFile.TabIndex = 5;
            this.Button_OpenFile.Text = "Open File";
            this.Button_OpenFile.UseVisualStyleBackColor = true;
            this.Button_OpenFile.Click += new System.EventHandler(this.Button_OpenFile_Click);
            // 
            // Button_Github
            // 
            this.Button_Github.Location = new System.Drawing.Point(19, 159);
            this.Button_Github.Name = "Button_Github";
            this.Button_Github.Size = new System.Drawing.Size(219, 39);
            this.Button_Github.TabIndex = 6;
            this.Button_Github.Text = "Github";
            this.Button_Github.UseVisualStyleBackColor = true;
            this.Button_Github.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Version 0.5";
            // 
            // Progress_Save
            // 
            this.Progress_Save.Location = new System.Drawing.Point(19, 205);
            this.Progress_Save.Name = "Progress_Save";
            this.Progress_Save.Size = new System.Drawing.Size(589, 27);
            this.Progress_Save.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.Panel_Audio);
            this.tabControl1.Location = new System.Drawing.Point(264, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(348, 183);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Panel_ROM);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(340, 155);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ROM Editors";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Panel_Audio
            // 
            this.Panel_Audio.Controls.Add(this.tableLayoutPanel1);
            this.Panel_Audio.Location = new System.Drawing.Point(4, 24);
            this.Panel_Audio.Name = "Panel_Audio";
            this.Panel_Audio.Padding = new System.Windows.Forms.Padding(3);
            this.Panel_Audio.Size = new System.Drawing.Size(340, 155);
            this.Panel_Audio.TabIndex = 1;
            this.Panel_Audio.Text = "Audio Tools";
            this.Panel_Audio.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Button_KTSL2STBIN_Extractor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Button_KTSS_Exporter, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(334, 149);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Button_KTSL2STBIN_Extractor
            // 
            this.Button_KTSL2STBIN_Extractor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_KTSL2STBIN_Extractor.Location = new System.Drawing.Point(9, 9);
            this.Button_KTSL2STBIN_Extractor.Name = "Button_KTSL2STBIN_Extractor";
            this.Button_KTSL2STBIN_Extractor.Size = new System.Drawing.Size(316, 40);
            this.Button_KTSL2STBIN_Extractor.TabIndex = 0;
            this.Button_KTSL2STBIN_Extractor.Text = "KTSL2STBIN Extractor";
            this.Button_KTSL2STBIN_Extractor.UseVisualStyleBackColor = true;
            this.Button_KTSL2STBIN_Extractor.Click += new System.EventHandler(this.Button_KTSL2STBIN_Extractor_Click);
            // 
            // Button_KTSS_Exporter
            // 
            this.Button_KTSS_Exporter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_KTSS_Exporter.Location = new System.Drawing.Point(9, 55);
            this.Button_KTSS_Exporter.Name = "Button_KTSS_Exporter";
            this.Button_KTSS_Exporter.Size = new System.Drawing.Size(316, 40);
            this.Button_KTSS_Exporter.TabIndex = 1;
            this.Button_KTSS_Exporter.Text = "KTSS Exporter";
            this.Button_KTSS_Exporter.UseVisualStyleBackColor = true;
            this.Button_KTSS_Exporter.Click += new System.EventHandler(this.Button_KTSS_Exporter_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 247);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Progress_Save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button_Github);
            this.Controls.Add(this.Button_OpenFile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "TH Hacking Toolkit";
            this.Panel_ROM.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.Panel_Audio.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_CharacterEditor;
        private System.Windows.Forms.Button Button_ClassEditor;
        private System.Windows.Forms.Button Button_ItemEditor;
        private System.Windows.Forms.TableLayoutPanel Panel_ROM;
        private System.Windows.Forms.Button Button_OpenFile;
        private System.Windows.Forms.Button Button_Github;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar Progress_Save;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage Panel_Audio;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Button_KTSL2STBIN_Extractor;
        private System.Windows.Forms.Button Button_KTSS_Exporter;
    }
}