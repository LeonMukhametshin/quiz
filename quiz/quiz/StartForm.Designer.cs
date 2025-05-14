namespace quiz
{
    partial class StartForm
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
            btnStart = new CustomControls.RJControls.RJButton();
            btnRegistration = new CustomControls.RJControls.RJButton();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom;
            btnStart.BackColor = SystemColors.MenuHighlight;
            btnStart.BackgroundColor = SystemColors.MenuHighlight;
            btnStart.BorderColor = Color.MediumBlue;
            btnStart.BorderRadius = 10;
            btnStart.BorderSize = 1;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI Symbol", 15.75F, FontStyle.Bold);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(50, 120);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(250, 60);
            btnStart.TabIndex = 8;
            btnStart.Text = "Пройти тест";
            btnStart.TextColor = Color.White;
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnRegistration
            // 
            btnRegistration.Anchor = AnchorStyles.Bottom;
            btnRegistration.BackColor = SystemColors.MenuHighlight;
            btnRegistration.BackgroundColor = SystemColors.MenuHighlight;
            btnRegistration.BorderColor = Color.MediumBlue;
            btnRegistration.BorderRadius = 10;
            btnRegistration.BorderSize = 1;
            btnRegistration.FlatAppearance.BorderSize = 0;
            btnRegistration.FlatStyle = FlatStyle.Flat;
            btnRegistration.Font = new Font("Segoe UI Symbol", 15.75F, FontStyle.Bold);
            btnRegistration.ForeColor = Color.White;
            btnRegistration.Location = new Point(50, 230);
            btnRegistration.Name = "btnRegistration";
            btnRegistration.Size = new Size(250, 60);
            btnRegistration.TabIndex = 9;
            btnRegistration.Text = "Настройки";
            btnRegistration.TextColor = Color.White;
            btnRegistration.UseVisualStyleBackColor = false;
            btnRegistration.Click += btnRegistration_Click;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 350);
            Controls.Add(btnRegistration);
            Controls.Add(btnStart);
            Name = "StartForm";
            Text = "StartForm";
            Load += StartForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.RJControls.RJButton btnStart;
        private CustomControls.RJControls.RJButton btnRegistration;
    }
}