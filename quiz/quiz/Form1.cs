using MaterialSkin.Controls;
using MaterialSkin;
using System.Text;

namespace quiz
{
    public partial class Form1 : MaterialForm
    {
        private int questionCount;
        private int correctAnswers;
        private int wrongAnswers;

        private string[] questions;

        private int correctAnswersNumber;
        private int selecetResponse;

        private StreamReader Read;

        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue400, Primary.Blue800, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Start()
        {
            var Encoding = System.Text.Encoding.GetEncoding(65001);
            try
            {

                Read = new System.IO.StreamReader(
                Directory.GetCurrentDirectory() + @"\t.txt", Encoding);
                this.Text = Read.ReadLine();

                questionCount = 0;
                correctAnswers = 0;
                wrongAnswers = 0;

                questions = new String[10];
            }
            catch (Exception)
            {
                MessageBox.Show("������ 1");
            }
            Question();
        }

        private void Question()
        {
            label1.Text = Read.ReadLine();

            radioButton1.Text = Read.ReadLine();
            radioButton2.Text = Read.ReadLine();
            radioButton3.Text = Read.ReadLine();
            radioButton4.Text = Read.ReadLine();

            correctAnswersNumber = int.Parse(Read.ReadLine());

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            button1.Enabled = false;
            questionCount = questionCount + 1;

            if (Read.EndOfStream == true) button1.Text = "���������";
        }

        void StateOfSwitch(object sender, EventArgs e)
        {
            button1.Enabled = true; button1.Focus();
            RadioButton ������������� = (RadioButton)sender;
            var tmp = �������������.Name;

            selecetResponse = int.Parse(tmp.Substring(11));
        }

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

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "���������";
            button2.Text = "�����";

            radioButton1.CheckedChanged += new EventHandler(StateOfSwitch);
            radioButton2.CheckedChanged += new EventHandler(StateOfSwitch);
            radioButton3.CheckedChanged += new EventHandler(StateOfSwitch);
            radioButton4.CheckedChanged += new EventHandler(StateOfSwitch);
            Start();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (selecetResponse == correctAnswersNumber) correctAnswers++;

            if (selecetResponse != correctAnswersNumber)
            {
                wrongAnswers++;

                questions[wrongAnswers] = label1.Text;
            }
            if (button1.Text == "������")
            {
                button1.Text = "���������";

                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;

                Start();
                return;
            }

            if (button1.Text == "���������")
            {
                Read.Close();

                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;

                label1.Text = String.Format("������������ ���������.\n" +
                    "���������� �������: {0} �� {1}.\n" +
                    "��������� ����: {2:F2}.", correctAnswers,
                    questionCount, (correctAnswers * 5.0F) / questionCount);

                button1.Text = "������";

                var Str = "������ ������ " + ":\n\n";
                for (int i = 1; i <= wrongAnswers; i++)
                {
                    Str = Str + questions[i] + "\n";
                }

                if (wrongAnswers != 0) MessageBox.Show(Str, "������������ ���������");
            }
            if (button1.Text == "���������") Question();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
