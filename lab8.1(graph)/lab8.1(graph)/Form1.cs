using System.Text.RegularExpressions;

namespace lab8._1_graph_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string text = textBox1.Text;


                MatchCollection matches;
                Regex reg = new Regex(@"[0-3][0-9].[0-1][0-9].[1,2][9,0][0-9][0-9]");
                matches = reg.Matches(text);

                {
                    for (int i = 0; i < matches.Count; i++)
                    {
                        string[] hhss = matches[i].Value.Split('.');
                        int dd = Convert.ToInt32(hhss[0]);
                        int mm = Convert.ToInt32(hhss[1]);
                        int gg = Convert.ToInt32(hhss[2]);
                        

                        if (dd > 31 || mm > 12 || gg < 1900 && gg > 2010)
                        {
                            text = "Такой даты не существует!";
                        }
                        else
                        {
                            string updDate = DateTime.Parse(matches[i].Value).AddDays(-1).ToShortDateString();
                            text = text.Replace(matches[i].Value, updDate);
                        }
                    }
                    textBox2.Text += $"Дата предыдущенго дня {text}" + Environment.NewLine;
                }

            }
            catch
            {
                MessageBox.Show("Некорректный ввод или такой даты не существует!", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}