namespace th_hack_tools
{
    partial class Class_Editor_Levels
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Box_Master = new System.Windows.Forms.NumericUpDown();
            this.Box_Advanced = new System.Windows.Forms.NumericUpDown();
            this.Box_Intermediate = new System.Windows.Forms.NumericUpDown();
            this.Box_Beginner = new System.Windows.Forms.NumericUpDown();
            this.Button_Save = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Box_Master)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box_Advanced)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box_Intermediate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box_Beginner)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Box_Master, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Box_Advanced, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Box_Intermediate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Box_Beginner, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 107);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Beginner";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Intermediate";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Advanced";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Master";
            // 
            // Box_Master
            // 
            this.Box_Master.Location = new System.Drawing.Point(103, 81);
            this.Box_Master.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Box_Master.Name = "Box_Master";
            this.Box_Master.Size = new System.Drawing.Size(94, 20);
            this.Box_Master.TabIndex = 4;
            this.Box_Master.ValueChanged += new System.EventHandler(this.Box_Master_ValueChanged);
            // 
            // Box_Advanced
            // 
            this.Box_Advanced.Location = new System.Drawing.Point(103, 55);
            this.Box_Advanced.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Box_Advanced.Name = "Box_Advanced";
            this.Box_Advanced.Size = new System.Drawing.Size(94, 20);
            this.Box_Advanced.TabIndex = 5;
            this.Box_Advanced.ValueChanged += new System.EventHandler(this.Box_Advanced_ValueChanged);
            // 
            // Box_Intermediate
            // 
            this.Box_Intermediate.Location = new System.Drawing.Point(103, 29);
            this.Box_Intermediate.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Box_Intermediate.Name = "Box_Intermediate";
            this.Box_Intermediate.Size = new System.Drawing.Size(94, 20);
            this.Box_Intermediate.TabIndex = 6;
            this.Box_Intermediate.ValueChanged += new System.EventHandler(this.Box_Intermediate_ValueChanged);
            // 
            // Box_Beginner
            // 
            this.Box_Beginner.Location = new System.Drawing.Point(103, 3);
            this.Box_Beginner.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Box_Beginner.Name = "Box_Beginner";
            this.Box_Beginner.Size = new System.Drawing.Size(94, 20);
            this.Box_Beginner.TabIndex = 7;
            this.Box_Beginner.ValueChanged += new System.EventHandler(this.Box_Beginner_ValueChanged);
            // 
            // Button_Save
            // 
            this.Button_Save.Location = new System.Drawing.Point(115, 125);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(97, 23);
            this.Button_Save.TabIndex = 1;
            this.Button_Save.Text = "Save and close";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Class_Editor_Levels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 162);
            this.Controls.Add(this.Button_Save);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Class_Editor_Levels";
            this.Text = "Class Mastery Levels";
            this.Load += new System.EventHandler(this.Class_Editor_Levels_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Box_Master)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box_Advanced)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box_Intermediate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box_Beginner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown Box_Master;
        private System.Windows.Forms.NumericUpDown Box_Advanced;
        private System.Windows.Forms.NumericUpDown Box_Intermediate;
        private System.Windows.Forms.NumericUpDown Box_Beginner;
        private System.Windows.Forms.Button Button_Save;
    }
}