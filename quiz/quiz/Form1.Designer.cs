namespace quiz
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            button1 = new CustomControls.RJControls.RJButton();
            button2 = new CustomControls.RJControls.RJButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 81);
            label1.Name = "label1";
            label1.Size = new Size(1076, 103);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // radioButton1
            // 
            radioButton1.Anchor = AnchorStyles.Left;
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 21.75F);
            radioButton1.Location = new Point(12, 223);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(203, 44);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.Text = "radioButton1";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.Anchor = AnchorStyles.Left;
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI", 21.75F);
            radioButton2.Location = new Point(12, 278);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(203, 44);
            radioButton2.TabIndex = 2;
            radioButton2.TabStop = true;
            radioButton2.Text = "radioButton2";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton3
            // 
            radioButton3.Anchor = AnchorStyles.Left;
            radioButton3.AutoSize = true;
            radioButton3.Font = new Font("Segoe UI", 21.75F);
            radioButton3.Location = new Point(12, 333);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(203, 44);
            radioButton3.TabIndex = 3;
            radioButton3.TabStop = true;
            radioButton3.Text = "radioButton3";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // radioButton4
            // 
            radioButton4.Anchor = AnchorStyles.Left;
            radioButton4.AutoSize = true;
            radioButton4.Font = new Font("Segoe UI", 21.75F);
            radioButton4.Location = new Point(12, 388);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(203, 44);
            radioButton4.TabIndex = 6;
            radioButton4.TabStop = true;
            radioButton4.Text = "radioButton4";
            radioButton4.UseVisualStyleBackColor = true;
            radioButton4.CheckedChanged += radioButton4_CheckedChanged;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom;
            button1.BackColor = SystemColors.MenuHighlight;
            button1.BackgroundColor = SystemColors.MenuHighlight;
            button1.BorderColor = Color.MediumBlue;
            button1.BorderRadius = 10;
            button1.BorderSize = 1;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Symbol", 15.75F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(150, 505);
            button1.Name = "button1";
            button1.Size = new Size(250, 62);
            button1.TabIndex = 7;
            button1.Text = "Следующий";
            button1.TextColor = Color.White;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom;
            button2.BackColor = SystemColors.MenuHighlight;
            button2.BackgroundColor = SystemColors.MenuHighlight;
            button2.BorderColor = Color.MediumBlue;
            button2.BorderRadius = 10;
            button2.BorderSize = 1;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Symbol", 15.75F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(670, 505);
            button2.Name = "button2";
            button2.Size = new Size(250, 62);
            button2.TabIndex = 0;
            button2.Text = "Выход";
            button2.TextColor = Color.White;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 600);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(radioButton4);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(1100, 600);
            MinimumSize = new Size(1100, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private CustomControls.RJControls.RJButton button1;
        private CustomControls.RJControls.RJButton button2;
    }
}
