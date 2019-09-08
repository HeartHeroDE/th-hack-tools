namespace th_hack_tools.editors.audio
{
    partial class KTSL2STBIN_Extractor
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
            this.label1 = new System.Windows.Forms.Label();
            this.Box_Input = new System.Windows.Forms.TextBox();
            this.Box_Output = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Button_Input = new System.Windows.Forms.Button();
            this.Button_Output = new System.Windows.Forms.Button();
            this.Button_Extract = new System.Windows.Forms.Button();
            this.Progress_Extract = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input File";
            // 
            // Box_Input
            // 
            this.Box_Input.Location = new System.Drawing.Point(110, 28);
            this.Box_Input.Name = "Box_Input";
            this.Box_Input.Size = new System.Drawing.Size(128, 21);
            this.Box_Input.TabIndex = 1;
            this.Box_Input.TextChanged += new System.EventHandler(this.Box_Input_TextChanged);
            // 
            // Box_Output
            // 
            this.Box_Output.Location = new System.Drawing.Point(110, 64);
            this.Box_Output.Name = "Box_Output";
            this.Box_Output.Size = new System.Drawing.Size(128, 21);
            this.Box_Output.TabIndex = 2;
            this.Box_Output.TextChanged += new System.EventHandler(this.Box_Output_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output Folder";
            // 
            // Button_Input
            // 
            this.Button_Input.Location = new System.Drawing.Point(244, 27);
            this.Button_Input.Name = "Button_Input";
            this.Button_Input.Size = new System.Drawing.Size(75, 23);
            this.Button_Input.TabIndex = 4;
            this.Button_Input.Text = "Open";
            this.Button_Input.UseVisualStyleBackColor = true;
            this.Button_Input.Click += new System.EventHandler(this.Button_Input_Click);
            // 
            // Button_Output
            // 
            this.Button_Output.Location = new System.Drawing.Point(244, 63);
            this.Button_Output.Name = "Button_Output";
            this.Button_Output.Size = new System.Drawing.Size(75, 23);
            this.Button_Output.TabIndex = 5;
            this.Button_Output.Text = "Choose";
            this.Button_Output.UseVisualStyleBackColor = true;
            this.Button_Output.Click += new System.EventHandler(this.Button_Output_Click);
            // 
            // Button_Extract
            // 
            this.Button_Extract.Enabled = false;
            this.Button_Extract.Location = new System.Drawing.Point(110, 135);
            this.Button_Extract.Name = "Button_Extract";
            this.Button_Extract.Size = new System.Drawing.Size(209, 23);
            this.Button_Extract.TabIndex = 6;
            this.Button_Extract.Text = "Extract KTSS files";
            this.Button_Extract.UseVisualStyleBackColor = true;
            this.Button_Extract.Click += new System.EventHandler(this.Button_Extract_Click);
            // 
            // Progress_Extract
            // 
            this.Progress_Extract.Location = new System.Drawing.Point(17, 98);
            this.Progress_Extract.Name = "Progress_Extract";
            this.Progress_Extract.Size = new System.Drawing.Size(302, 23);
            this.Progress_Extract.TabIndex = 7;
            // 
            // KTSL2STBIN_Extractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 170);
            this.Controls.Add(this.Progress_Extract);
            this.Controls.Add(this.Button_Extract);
            this.Controls.Add(this.Button_Output);
            this.Controls.Add(this.Button_Input);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Box_Output);
            this.Controls.Add(this.Box_Input);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "KTSL2STBIN_Extractor";
            this.Text = "KTSL2STBIN Extractor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Box_Input;
        private System.Windows.Forms.TextBox Box_Output;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Button_Input;
        private System.Windows.Forms.Button Button_Output;
        private System.Windows.Forms.Button Button_Extract;
        private System.Windows.Forms.ProgressBar Progress_Extract;
    }
}