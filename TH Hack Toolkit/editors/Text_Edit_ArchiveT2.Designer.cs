namespace th_hack_tools.editors
{
    partial class Text_Edit_ArchiveT2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Number_Arg2 = new System.Windows.Forms.NumericUpDown();
            this.Number_Arg1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Arg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Arg1)).BeginInit();
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
            this.ArchiveBox.Location = new System.Drawing.Point(12, 54);
            this.ArchiveBox.Multiline = true;
            this.ArchiveBox.Name = "ArchiveBox";
            this.ArchiveBox.Size = new System.Drawing.Size(360, 182);
            this.ArchiveBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Arg 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Arg 2:";
            // 
            // Number_Arg2
            // 
            this.Number_Arg2.Hexadecimal = true;
            this.Number_Arg2.Location = new System.Drawing.Point(232, 16);
            this.Number_Arg2.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.Number_Arg2.Name = "Number_Arg2";
            this.Number_Arg2.Size = new System.Drawing.Size(92, 21);
            this.Number_Arg2.TabIndex = 6;
            // 
            // Number_Arg1
            // 
            this.Number_Arg1.Hexadecimal = true;
            this.Number_Arg1.Location = new System.Drawing.Point(56, 16);
            this.Number_Arg1.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.Number_Arg1.Name = "Number_Arg1";
            this.Number_Arg1.Size = new System.Drawing.Size(92, 21);
            this.Number_Arg1.TabIndex = 7;
            // 
            // Text_Edit_ArchiveT2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 281);
            this.Controls.Add(this.Number_Arg1);
            this.Controls.Add(this.Number_Arg2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ArchiveBox);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_SaveClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Text_Edit_ArchiveT2";
            this.Text = "Edit Text Archive (Type 2)";
            this.Load += new System.EventHandler(this.Text_Edit_ArchiveT2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Number_Arg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Arg1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_SaveClose;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.TextBox ArchiveBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Number_Arg2;
        private System.Windows.Forms.NumericUpDown Number_Arg1;
    }
}