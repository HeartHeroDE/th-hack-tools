namespace th_hack_tools.editors.audio
{
    partial class KTSS_Interpreter
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
            this.Button_Import = new System.Windows.Forms.Button();
            this.Box_Info = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Button_Export = new System.Windows.Forms.Button();
            this.Group_Export = new System.Windows.Forms.GroupBox();
            this.Check_Loop = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Value_LoopStart = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.Value_LoopLength = new System.Windows.Forms.NumericUpDown();
            this.Panel_Loop = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.Group_Export.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Value_LoopStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value_LoopLength)).BeginInit();
            this.Panel_Loop.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_Import
            // 
            this.Button_Import.Location = new System.Drawing.Point(12, 17);
            this.Button_Import.Name = "Button_Import";
            this.Button_Import.Size = new System.Drawing.Size(121, 23);
            this.Button_Import.TabIndex = 0;
            this.Button_Import.Text = "Import File";
            this.Button_Import.UseVisualStyleBackColor = true;
            this.Button_Import.Click += new System.EventHandler(this.Button_Import_Click);
            // 
            // Box_Info
            // 
            this.Box_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Box_Info.Enabled = false;
            this.Box_Info.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Box_Info.Location = new System.Drawing.Point(9, 22);
            this.Box_Info.Multiline = true;
            this.Box_Info.Name = "Box_Info";
            this.Box_Info.Size = new System.Drawing.Size(235, 166);
            this.Box_Info.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Box_Info);
            this.groupBox1.Location = new System.Drawing.Point(139, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(9);
            this.groupBox1.Size = new System.Drawing.Size(253, 197);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opus Information";
            // 
            // Button_Export
            // 
            this.Button_Export.Location = new System.Drawing.Point(6, 131);
            this.Button_Export.Name = "Button_Export";
            this.Button_Export.Size = new System.Drawing.Size(109, 23);
            this.Button_Export.TabIndex = 3;
            this.Button_Export.Text = "Export KTSS";
            this.Button_Export.UseVisualStyleBackColor = true;
            this.Button_Export.Click += new System.EventHandler(this.Button_Export_Click);
            // 
            // Group_Export
            // 
            this.Group_Export.Controls.Add(this.Panel_Loop);
            this.Group_Export.Controls.Add(this.Check_Loop);
            this.Group_Export.Controls.Add(this.Button_Export);
            this.Group_Export.Enabled = false;
            this.Group_Export.Location = new System.Drawing.Point(12, 46);
            this.Group_Export.Name = "Group_Export";
            this.Group_Export.Size = new System.Drawing.Size(121, 163);
            this.Group_Export.TabIndex = 4;
            this.Group_Export.TabStop = false;
            this.Group_Export.Text = "Export settings";
            // 
            // Check_Loop
            // 
            this.Check_Loop.AutoSize = true;
            this.Check_Loop.Location = new System.Drawing.Point(10, 25);
            this.Check_Loop.Name = "Check_Loop";
            this.Check_Loop.Size = new System.Drawing.Size(81, 17);
            this.Check_Loop.TabIndex = 4;
            this.Check_Loop.Text = "Loop Track";
            this.Check_Loop.UseVisualStyleBackColor = true;
            this.Check_Loop.CheckedChanged += new System.EventHandler(this.Check_Loop_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Start:";
            // 
            // Value_LoopStart
            // 
            this.Value_LoopStart.Location = new System.Drawing.Point(50, 8);
            this.Value_LoopStart.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.Value_LoopStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Value_LoopStart.Name = "Value_LoopStart";
            this.Value_LoopStart.Size = new System.Drawing.Size(59, 20);
            this.Value_LoopStart.TabIndex = 6;
            this.Value_LoopStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Length:";
            // 
            // Value_LoopLength
            // 
            this.Value_LoopLength.Location = new System.Drawing.Point(50, 40);
            this.Value_LoopLength.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.Value_LoopLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Value_LoopLength.Name = "Value_LoopLength";
            this.Value_LoopLength.Size = new System.Drawing.Size(59, 20);
            this.Value_LoopLength.TabIndex = 8;
            this.Value_LoopLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Panel_Loop
            // 
            this.Panel_Loop.Controls.Add(this.label1);
            this.Panel_Loop.Controls.Add(this.Value_LoopLength);
            this.Panel_Loop.Controls.Add(this.Value_LoopStart);
            this.Panel_Loop.Controls.Add(this.label2);
            this.Panel_Loop.Enabled = false;
            this.Panel_Loop.Location = new System.Drawing.Point(6, 48);
            this.Panel_Loop.Name = "Panel_Loop";
            this.Panel_Loop.Size = new System.Drawing.Size(109, 69);
            this.Panel_Loop.TabIndex = 9;
            // 
            // KTSS_Interpreter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 221);
            this.Controls.Add(this.Group_Export);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Button_Import);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "KTSS_Interpreter";
            this.Text = "KTSS Exporter";
            this.Load += new System.EventHandler(this.KTSS_Interpreter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Group_Export.ResumeLayout(false);
            this.Group_Export.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Value_LoopStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value_LoopLength)).EndInit();
            this.Panel_Loop.ResumeLayout(false);
            this.Panel_Loop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_Import;
        private System.Windows.Forms.TextBox Box_Info;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Button_Export;
        private System.Windows.Forms.GroupBox Group_Export;
        private System.Windows.Forms.NumericUpDown Value_LoopStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Check_Loop;
        private System.Windows.Forms.Panel Panel_Loop;
        private System.Windows.Forms.NumericUpDown Value_LoopLength;
        private System.Windows.Forms.Label label2;
    }
}