using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace quiz
{
    public partial class SettingsForm : MaterialForm
    {
        public QuizSettings CurrentSettings { get; private set; }
        private MaterialRadioButton rb10sec, rb20sec, rb30sec;
        private MaterialCheckBox cbFeedback;

        public SettingsForm(QuizSettings currentSettings)
        {
            CurrentSettings = currentSettings ?? new QuizSettings();
            InitializeComponent();
            InitializeMaterialSkin();
            InitializeControls();
            LoadCurrentSettings();
        }

        private void InitializeMaterialSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue800,
                Primary.BlueGrey500, Accent.LightBlue200,
                TextShade.WHITE);
        }

        private void InitializeControls()
        {
            // Настройка размеров формы
            this.ClientSize = new Size(450, 350);
            this.Text = "Настройки тестирования";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Чекбокс для показа уведомлений
            cbFeedback = new MaterialCheckBox
            {
                Text = "Показывать уведомления Correct/Incorrect",
                Location = new Point(20, 80),
                Size = new Size(400, 30),
                Checked = true
            };

            // Группа радиокнопок для времени
            var timeLabel = new MaterialLabel
            {
                Text = "Время на вопрос:",
                Location = new Point(20, 130),
                Size = new Size(200, 30)
            };

            rb10sec = new MaterialRadioButton
            {
                Text = "10 секунд",
                Location = new Point(40, 170),
                Size = new Size(150, 30),
                Tag = 10
            };

            rb20sec = new MaterialRadioButton
            {
                Text = "20 секунд (по умолчанию)",
                Location = new Point(40, 210),
                Size = new Size(200, 30),
                Tag = 20
            };

            rb30sec = new MaterialRadioButton
            {
                Text = "30 секунд",
                Location = new Point(40, 250),
                Size = new Size(150, 30),
                Tag = 30
            };

            // Кнопка сохранения
            var btnSave = new Button
            {
                Text = "Сохранить настройки",
                Size = new Size(180, 40),
                Location = new Point(50, 300)
            };
            btnSave.Click += BtnSave_Click;

            // Кнопка возврата
            var btnBack = new Button
            {
                Text = "Отмена",
                Size = new Size(180, 40),
                Location = new Point(240, 300)
            };
            btnBack.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] {
                cbFeedback,
                timeLabel,
                rb10sec, rb20sec, rb30sec,
                btnSave, btnBack
            });
        }

        private void LoadCurrentSettings()
        {
            cbFeedback.Checked = CurrentSettings.ShowFeedback;

            switch (CurrentSettings.QuestionTime)
            {
                case 10: rb10sec.Checked = true; break;
                case 20: rb20sec.Checked = true; break;
                case 30: rb30sec.Checked = true; break;
                default: rb20sec.Checked = true; break;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            CurrentSettings.ShowFeedback = cbFeedback.Checked;

            if (rb10sec.Checked) CurrentSettings.QuestionTime = 10;
            else if (rb20sec.Checked) CurrentSettings.QuestionTime = 20;
            else if (rb30sec.Checked) CurrentSettings.QuestionTime = 30;

            CurrentSettings.Save();

            MessageBox.Show("Настройки успешно сохранены!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    public class QuizSettings
    {
        public bool ShowFeedback { get; set; } = true;
        public int QuestionTime { get; set; } = 20;
        public string LastFirstName { get; set; } = "";
        public string LastLastName { get; set; } = "";

        private const string SETTINGS_FILE = "quiz_settings.json";

        public void Save()
        {
            try
            {
                File.WriteAllText(SETTINGS_FILE, JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented));
            }
            catch
            {
                // Логирование ошибок при необходимости
            }
        }

        public static QuizSettings Load()
        {
            try
            {
                if (File.Exists(SETTINGS_FILE))
                {
                    return JsonConvert.DeserializeObject<QuizSettings>(File.ReadAllText(SETTINGS_FILE));
                }
            }
            catch
            {
                // Логирование ошибок при необходимости
            }

            return new QuizSettings(); // Возвращаем настройки по умолчанию
        }

    }
}


