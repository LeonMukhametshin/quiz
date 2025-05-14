namespace quiz
{
    partial class RegistrationForm
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
            userNameField = new TextBox();
            userSurnameField = new TextBox();
            btnStart = new CustomControls.RJControls.RJButton();
            SuspendLayout();
            // 
            // userNameField
            // 
            userNameField.Font = new Font("Segoe UI", 21.75F);
            userNameField.Location = new Point(75, 107);
            userNameField.Name = "userNameField";
            userNameField.Size = new Size(250, 46);
            userNameField.TabIndex = 0;
            userNameField.TextChanged += userNameField_TextChanged;
            userNameField.Enter += userNameField_Enter;
            userNameField.Leave += userNameField_Leave;
            // 
            // userSurnameField
            // 
            userSurnameField.Font = new Font("Segoe UI", 21.75F);
            userSurnameField.Location = new Point(75, 194);
            userSurnameField.Name = "userSurnameField";
            userSurnameField.Size = new Size(250, 46);
            userSurnameField.TabIndex = 1;
            userSurnameField.Enter += userSurnameField_Enter;
            userSurnameField.Leave += userSurnameField_Leave;
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
            btnStart.Location = new Point(75, 312);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(250, 62);
            btnStart.TabIndex = 9;
            btnStart.Text = "Начать";
            btnStart.TextColor = Color.White;
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 400);
            Controls.Add(btnStart);
            Controls.Add(userSurnameField);
            Controls.Add(userNameField);
            Name = "RegistrationForm";
            Text = "Регистрация";
            Load += RegistrationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox userNameField;
        private TextBox userSurnameField;
        private CustomControls.RJControls.RJButton btnStart;
    }
}