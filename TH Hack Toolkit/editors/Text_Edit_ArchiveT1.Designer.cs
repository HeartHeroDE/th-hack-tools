namespace th_hack_tools.editors
{
    partial class Text_Edit_ArchiveT1
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
            this.Button_SaveClose = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.ArchiveBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Button_SaveClose
            // 
            this.Button_SaveClose.Location = new System.Drawing.Point(250, 242);
            this.Button_SaveClose.Name = "Button_SaveClose";
            this.Button_SaveClose.Size = new System.Drawing.Size(122, 27);
            this.Button_SaveClose.TabIndex = 0;
            this.Button_SaveClose.Text = "Save and Close";
            this.Button_SaveClose.UseVisualStyleBackColor = true;
            this.Button_SaveClose.Click += new System.EventHandler(this.Button_SaveClose_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Location = new System.Drawing.Point(12, 242);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(122, 27);
            this.Button_Cancel.TabIndex = 1;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // ArchiveBox
            // 
            this.ArchiveBox.Location = new System.Drawing.Point(12, 12);
            this.ArchiveBox.Multiline = true;
            this.ArchiveBox.Name = "ArchiveBox";
            this.ArchiveBox.Size = new System.Drawing.Size(360, 224);
            this.ArchiveBox.TabIndex = 2;
            // 
            // Text_Edit_ArchiveT1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 281);
            this.Controls.Add(this.ArchiveBox);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_SaveClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Text_Edit_ArchiveT1";
            this.Text = "Edit Text Archive (Type 1)";
            this.Load += new System.EventHandler(this.Text_Edit_ArchiveT1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_SaveClose;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.TextBox ArchiveBox;
    }
}