using MaterialSkin.Controls;
using MaterialSkin;
using System.Text;
using Timer = System.Windows.Forms.Timer;

namespace quiz
{
    public partial class Form1 : MaterialForm
    {
        // Настройки таймера
        private int timeLeft;
        private int questionTime = 20; 

        // Существующие поля
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        private int questionCount;
        private int correctAnswers;
        private int wrongAnswers;
        private string[] questions;
        private int correctAnswersNumber;
        private int selecetResponse;
        private StreamReader Read;
        private readonly Color DEFAULT_BUTTON_COLOR = Color.FromArgb(51, 153, 254);
        private readonly Color DISABLED_BUTTON_COLOR = Color.FromArgb(255, 128, 128);
        private bool showFeedback = true;

        private readonly string resultsFilePath = Path.Combine(Environment.GetFolderPath(
           Environment.SpecialFolder.MyDocuments), "TestResults.txt");

        public Form1(QuizSettings settings = null)
        {
            settings = settings ?? QuizSettings.Load();

            InitializeComponent();

            this.UserFirstName = settings.LastFirstName;
            this.UserLastName = settings.LastLastName;
            this.showFeedback = settings.ShowFeedback;
            this.questionTime = settings.QuestionTime;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue800,
                Primary.BlueGrey500, Accent.LightBlue200,
                TextShade.WHITE);

            InitializeTimer();
        }

        private void InitializeTimer()
        {

            timerLabel.Text = $"Время: {questionTime} сек";
            this.Controls.Add(timerLabel);

            questionTimer = new Timer();
            questionTimer.Interval = 1000; 
            questionTimer.Tick += QuestionTimer_Tick;
        }

        private void QuestionTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            UpdateTimerDisplay();

            if (timeLeft <= 0)
            {
                questionTimer.Stop();
                ProcessTimeout();
            }
        }

        private void UpdateTimerDisplay()
        {
            timerLabel.Text = $"Осталось: {timeLeft} сек";

            // Меняем цвет при малом времени
            if (timeLeft <= 5)
            {
                timerLabel.ForeColor = Color.Red;
                timerLabel.Font = new Font(timerLabel.Font, FontStyle.Bold);
            }
            else
            {
                timerLabel.ForeColor = SystemColors.ControlText;
                timerLabel.Font = new Font(timerLabel.Font, FontStyle.Regular);
            }
        }

        private void Start()
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "t.txt");
                Read = new StreamReader(filePath, Encoding.GetEncoding(65001));
                this.Text = Read.ReadLine();

                questionCount = 0;
                correctAnswers = 0;
                wrongAnswers = 0;
                questions = new string[10];

                // Запускаем первый вопрос
                Question();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки теста: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void Question()
        {
            try
            {
                // Сбрасываем таймер для нового вопроса
                timeLeft = questionTime;
                UpdateTimerDisplay();
                questionTimer.Start();

                // Загрузка вопроса
                label1.Text = Read.ReadLine() ?? "Нет текста вопроса";
                radioButton1.Text = Read.ReadLine() ?? "Вариант 1";
                radioButton2.Text = Read.ReadLine() ?? "Вариант 2";
                radioButton3.Text = Read.ReadLine() ?? "Вариант 3";
                radioButton4.Text = Read.ReadLine() ?? "Вариант 4";

                if (int.TryParse(Read.ReadLine(), out correctAnswersNumber))
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;

                    button1.Enabled = false;
                    button1.BackColor = DISABLED_BUTTON_COLOR;
                    questionCount++;

                    if (Read.EndOfStream)
                    {
                        button1.Text = "Завершить";
                        button1.BackColor = Color.FromArgb(255, 128, 128);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка чтения вопроса: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessTimeout()
        {
            if (showFeedback)
            {
                ShowAnswerFeedback(false);
            }

            // Засчитываем как неправильный ответ
            if (selecetResponse != correctAnswersNumber)
            {
                wrongAnswers++;
                questions[wrongAnswers] = label1.Text;
            }

            // Переход к следующему вопросу
            MoveToNextQuestion();
        }

        private void ShowAnswerFeedback(bool isCorrect)
        {
            var feedbackPanel = new Panel
            {
                BackColor = isCorrect ? Color.LimeGreen : Color.IndianRed,
                Size = new Size(300, 100),
                Location = new Point(
                    (this.ClientSize.Width - 300) / 2,
                    (this.ClientSize.Height - 100) / 2),
                Anchor = AnchorStyles.None
            };

            var label = new Label
            {
                Text = isCorrect ? "✓ ПРАВИЛЬНО" : "✗ ОШИБКА",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            feedbackPanel.Controls.Add(label);
            this.Controls.Add(feedbackPanel);
            feedbackPanel.BringToFront();

            var timer = new Timer { Interval = 1500 };
            timer.Tick += (s, e) =>
            {
                this.Controls.Remove(feedbackPanel);
                timer.Stop();
            };
            timer.Start();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Останавливаем таймер при ответе
            questionTimer.Stop();

            bool isCorrect = (selecetResponse == correctAnswersNumber);

            if (showFeedback)
            {
                ShowAnswerFeedback(isCorrect);
            }

            if (isCorrect)
            {
                correctAnswers++;
            }
            else
            {
                wrongAnswers++;
                questions[wrongAnswers] = label1.Text;
            }

            if (button1.Text == "Заново")
            {
                ResetTest();
                return;
            }

            if (button1.Text == "Завершить")
            {
                Read.Close();
                ShowResults();
                ResetTestUI();
                return;
            }

            if (button1.Text == "Следующий")
            {
                MoveToNextQuestion();
            }
        }

        private void MoveToNextQuestion()
        {
            // Запускаем таймер для нового вопроса
            timeLeft = questionTime;
            UpdateTimerDisplay();
            Question();
        }

        private void ResetTest()
        {
            button1.Text = "Следующий";
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            Start();
        }
        private void ResetTestUI()
        {
            button1.Text = "Заново";
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
        }

        private void StateOfSwitch(object sender, EventArgs e)
        {
            var selectedRadio = (RadioButton)sender;
            selecetResponse = int.Parse(selectedRadio.Name.Substring(11));

            button1.Enabled = true;
            button1.BackColor = DEFAULT_BUTTON_COLOR;
            button1.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Следующий";
            button2.Text = "Выход";
            radioButton1.CheckedChanged += StateOfSwitch;
            radioButton2.CheckedChanged += StateOfSwitch;
            radioButton3.CheckedChanged += StateOfSwitch;
            radioButton4.CheckedChanged += StateOfSwitch;
            Start();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowResults()
        {
            SaveTestResults();
            // Создаем новую форму для отображения результатов
            var resultsForm = new Form
            {
                Width = 500,
                Height = 600,
                Text = "Результаты тестирования",
                StartPosition = FormStartPosition.CenterParent
            };

            var resultText = new Label
            {
                Text = $"ТЕСТИРОВАНИЕ ЗАВЕРШЕНО\n\n" +
                      $"Участник: {UserLastName} {UserFirstName}\n\n" +
                      $"Результаты:\n" +
                      $"• Правильных ответов: {correctAnswers} из {questionCount}\n" +
                      $"• Процент выполнения: {correctAnswers * 100 / questionCount}%\n" +
                      $"• Набранные баллы: {(float)correctAnswers * 5f / questionCount:F2}\n\n" +
                      $"Дата: {DateTime.Now:dd.MM.yyyy HH:mm}",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12)
            };

            if (wrongAnswers > 0)
            {
                var errorText = new StringBuilder("\nОшибки в вопросах:\n");
                for (int i = 1; i <= wrongAnswers; i++)
                {
                    errorText.AppendLine($"• {questions[i]}");
                }
                resultText.Text += errorText.ToString();
            }

            var closeButton = new Button
            {
                Text = "Закрыть",
                Dock = DockStyle.Bottom,
                Size = new Size(100, 40)
            };
            closeButton.Click += (s, e) => resultsForm.Close();

            resultsForm.Controls.Add(resultText);
            resultsForm.Controls.Add(closeButton);
            resultsForm.ShowDialog();
        }

        private void SaveTestResults()
        {
            var settings = new QuizSettings
            {
                LastFirstName = this.UserFirstName,
                LastLastName = this.UserLastName,
                ShowFeedback = this.showFeedback,
                QuestionTime = this.questionTime
            };
            settings.Save();

            try
            {
                // Создаем строку с результатами
                string resultData = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]\n" +
                                   $"Участник: {UserLastName} {UserFirstName}\n" +
                                   $"Правильных ответов: {correctAnswers}/{questionCount}\n" +
                                   $"Процент правильных: {correctAnswers * 100 / questionCount}%\n" +
                                   $"Набранные баллы: {(float)correctAnswers * 5f / questionCount:F2}\n" +
                                   $"Ошибки: {wrongAnswers}\n";

                if (wrongAnswers > 0)
                {
                    resultData += "Ошибочные вопросы:\n";
                    for (int i = 1; i <= wrongAnswers; i++)
                    {
                        resultData += $"- {questions[i]}\n";
                    }
                }
                resultData += new string('-', 40) + "\n\n";

                // Создаем директорию, если не существует
                Directory.CreateDirectory(Path.GetDirectoryName(resultsFilePath));

                // Записываем в файл (добавляем к существующим данным)
                File.AppendAllText(resultsFilePath, resultData, Encoding.UTF8);

                MessageBox.Show("Результаты сохранены в:\n" + resultsFilePath,
                                      "Сохранено",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения результатов:\n{ex.Message}",
                                      "Ошибка",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
            }
        }

        #region Пустые методы
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
