using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quiz
{
    public partial class RegistrationForm : MaterialForm
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public RegistrationForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue400, Primary.Blue800, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            userNameField.Text = "Введите имя";
            userNameField.ForeColor = Color.Gray;
            userSurnameField.Text = "Введите фамилию";
            userSurnameField.ForeColor = Color.Gray;

            userNameField.TabStop = false;
            userSurnameField.TabStop = false;
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void userNameField_TextChanged(object sender, EventArgs e)
        {

        }

        private void userNameField_Enter(object sender, EventArgs e)
        {
            if (userNameField.Text == "Введите имя")
            {
                userNameField.Text = "";
                userNameField.ForeColor = Color.Black;
            }
        }

        private void userNameField_Leave(object sender, EventArgs e)
        {
            if (userNameField.Text == "")
            {
                userNameField.Text = "Введите имя";
                userNameField.ForeColor = Color.Gray;
            }
        }

        private void userSurnameField_Enter(object sender, EventArgs e)
        {
            if (userSurnameField.Text == "Введите фамилию")
            {
                userSurnameField.Text = "";
                userSurnameField.ForeColor = Color.Black;
            }
        }

        private void userSurnameField_Leave(object sender, EventArgs e)
        {
            if (userSurnameField.Text == "")
            {
                userSurnameField.Text = "Введите фамилию";
                userSurnameField.ForeColor = Color.Gray;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userNameField.Text) ||
                string.IsNullOrWhiteSpace(userSurnameField.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя и фамилию",
                                     "Ошибка ввода",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(userNameField.Text, @"^[а-яА-ЯёЁa-zA-Z]+$") ||
                !System.Text.RegularExpressions.Regex.IsMatch(userSurnameField.Text, @"^[а-яА-ЯёЁa-zA-Z]+$"))
            {
                MessageBox.Show("Имя и фамилия должны содержать только буквы",
                                     "Некорректный ввод",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning);
                return;
            }

            FirstName = userNameField.Text.Trim();
            LastName = userSurnameField.Text.Trim();

            this.Hide();
            var settings = QuizSettings.Load();
            var form = new Form1(settings);
            form.Show();
        }
    }
}