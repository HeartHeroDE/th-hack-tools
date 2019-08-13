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
            this.Group_Editors = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Button_OpenFile = new System.Windows.Forms.Button();
            this.Button_Github = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Group_Editors.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_ClassEditor
            // 
            this.Button_ClassEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_ClassEditor.Enabled = false;
            this.Button_ClassEditor.Location = new System.Drawing.Point(3, 43);
            this.Button_ClassEditor.Name = "Button_ClassEditor";
            this.Button_ClassEditor.Size = new System.Drawing.Size(182, 34);
            this.Button_ClassEditor.TabIndex = 1;
            this.Button_ClassEditor.Text = "Class Editor";
            this.Button_ClassEditor.UseVisualStyleBackColor = true;
            // 
            // Button_ItemEditor
            // 
            this.Button_ItemEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_ItemEditor.Enabled = false;
            this.Button_ItemEditor.Location = new System.Drawing.Point(3, 83);
            this.Button_ItemEditor.Name = "Button_ItemEditor";
            this.Button_ItemEditor.Size = new System.Drawing.Size(182, 34);
            this.Button_ItemEditor.TabIndex = 2;
            this.Button_ItemEditor.Text = "Item Editor";
            this.Button_ItemEditor.UseVisualStyleBackColor = true;
            // 
            // Button_CharacterEditor
            // 
            this.Button_CharacterEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_CharacterEditor.Location = new System.Drawing.Point(3, 3);
            this.Button_CharacterEditor.Name = "Button_CharacterEditor";
            this.Button_CharacterEditor.Size = new System.Drawing.Size(182, 34);
            this.Button_CharacterEditor.TabIndex = 0;
            this.Button_CharacterEditor.Text = "Character Editor";
            this.Button_CharacterEditor.UseVisualStyleBackColor = true;
            this.Button_CharacterEditor.Click += new System.EventHandler(this.Button_CharacterEditor_Click);
            // 
            // Group_Editors
            // 
            this.Group_Editors.Controls.Add(this.tableLayoutPanel1);
            this.Group_Editors.Enabled = false;
            this.Group_Editors.Location = new System.Drawing.Point(210, 12);
            this.Group_Editors.Name = "Group_Editors";
            this.Group_Editors.Padding = new System.Windows.Forms.Padding(6);
            this.Group_Editors.Size = new System.Drawing.Size(200, 145);
            this.Group_Editors.TabIndex = 4;
            this.Group_Editors.TabStop = false;
            this.Group_Editors.Text = "Editors";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Button_CharacterEditor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Button_ItemEditor, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Button_ClassEditor, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(188, 120);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Button_OpenFile
            // 
            this.Button_OpenFile.Location = new System.Drawing.Point(16, 34);
            this.Button_OpenFile.Name = "Button_OpenFile";
            this.Button_OpenFile.Size = new System.Drawing.Size(188, 74);
            this.Button_OpenFile.TabIndex = 5;
            this.Button_OpenFile.Text = "Open File";
            this.Button_OpenFile.UseVisualStyleBackColor = true;
            this.Button_OpenFile.Click += new System.EventHandler(this.Button_OpenFile_Click);
            // 
            // Button_Github
            // 
            this.Button_Github.Location = new System.Drawing.Point(16, 114);
            this.Button_Github.Name = "Button_Github";
            this.Button_Github.Size = new System.Drawing.Size(188, 34);
            this.Button_Github.TabIndex = 6;
            this.Button_Github.Text = "Github";
            this.Button_Github.UseVisualStyleBackColor = true;
            this.Button_Github.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Version 0.1a";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 170);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button_Github);
            this.Controls.Add(this.Button_OpenFile);
            this.Controls.Add(this.Group_Editors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "TH Hacking Toolkit";
            this.Group_Editors.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_CharacterEditor;
        private System.Windows.Forms.Button Button_ClassEditor;
        private System.Windows.Forms.Button Button_ItemEditor;
        private System.Windows.Forms.GroupBox Group_Editors;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Button_OpenFile;
        private System.Windows.Forms.Button Button_Github;
        private System.Windows.Forms.Label label1;
    }
}