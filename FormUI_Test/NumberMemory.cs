using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI_Test
{
    public partial class NumberMemory : Form
    {
        int level = 0;
        int timer = 10;
        string result;
        Random rnd = new Random();
        List<int> Szamok = new List<int>();
        public NumberMemory()
        {
            InitializeComponent();
            firstLoad();
        }

        private void firstLoad()
        {
            timer = 10;

            label1.Visible = false;
            textBox1.Visible = false;
            btnStart.Visible = true;
            panelProgressBar.Visible = false;
            textBox1.Enabled = true;

            btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            btnExit.FlatAppearance.MouseDownBackColor = btnExit.BackColor;
            btnExit.BackColorChanged += (s, e) => {
                btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            };
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //progress bar reset(elése)
            panelProgress.Width = 0;

            panelProgressBar.Visible = true;
            textBox1.Visible = false;
            label1.Visible = true;
            btnStart.Visible = false;
            textBox1.Enabled = true;

            btnExit.Visible = false;
            labelHelp.Visible = false;

            //1. szám letrehozasa
            if (level == 0)
            {
                int x = rnd.Next(0, 10);
                Szamok.Add(x);
            }

            result = string.Join(",", Szamok).Replace(",", "");
            label1.Text = result.ToString();

            this.timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e) //"progress bar"
        {
            panelProgress.Width += panelProgressBar.Width / timer; //10 = 1s || 20 = 2s ...
            if (panelProgress.Width >= panelProgressBar.Width) //"progresbar" full
            {
                label1.Text = "";
                panelProgressBar.Visible = false;
                panelProgress.Width = 0;
                textBox1.Visible = true;
                timer1.Stop();
            }
        }

        //input mezo (enter-submit)
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // enter == submit
            {
                // ne legyen error hang
                e.Handled = true;
                e.SuppressKeyPress = true; 
                try
                {
                    int temp = Convert.ToInt32(textBox1.Text); //beirt szam
                    int y = Int32.Parse(textBox1.Text);

                    if (y == Int32.Parse(result))
                    {
                        level++;
                        //minel nagyobb szam annal tobb ido megjegyzesre
                        timer += 10;

                        textBox1.Text = "";
                        textBox1.Enabled = false;
                        btnStart.Text = "Level: " + level + "\nNext";
                        btnStart.Visible = true;
                        label1.Text = "Number: " + result + "\nYour Answer:" + y + "\n" + "Level: " + level;
                        label1.Visible = true;
                        Szamok.Clear();

                        //uj random szam "level" hosszusaggal(+1)
                        for (int i = 0; i < level + 1; i++)
                        {
                            int x = rnd.Next(0, 10);
                            Szamok.Add(x);
                        }
                    }
                    else
                    {
                        label1.Text = "Game over!\nLevel: "+level+"\nNumber: " + result + "\nYour Answer:" + y;
                        label1.Visible = true;
                        //ha rekord
                        if (level > Form1.User.NumberMemory)
                        {
                            Form1.User.NumberMemory = level;
                            label1.Text = "New Record!\nLevel: " + level + "\nNumber: " + result + "\nYour Answer:" + y;
                            beolvas();
                            ujrair();
                        }

                        btnStart.Text = "Try Again!";
                        btnStart.Visible = true;
                        panelProgressBar.Visible = false;
                        textBox1.Enabled = false;
                        labelHelp.Visible = true;
                        btnExit.Visible = true;

                        //reset
                        Szamok.Clear();
                        timer = 10;
                        level = 0;
                    }
                }
                catch (Exception h)
                {
                    MessageBox.Show("Only Numbers"); //csak szam input
                }

            }
        }

        internal List<Scores> Nevek { get; set; } = new List<Scores>();
        private void beolvas()
        {
            Nevek.Clear();
            StreamReader file = new StreamReader("Score.txt", Encoding.UTF8);
            Scores score;

            while (!file.EndOfStream)
            {
                string sor = file.ReadLine();
                string[] adatok = sor.Split(';');
                score = new Scores();
                score.Nev = Convert.ToString(adatok[0]);
                score.Speed = Convert.ToDouble(adatok[1]);
                score.Flick = Convert.ToInt32(adatok[2]);
                score.Precision = Convert.ToDouble(adatok[3]);
                score.Reaction = Convert.ToDouble(adatok[4]);
                score.NumberMemory = Convert.ToInt32(adatok[5]);
                score.SequenceMemory = Convert.ToInt32(adatok[6]);
                score.Chimp = Convert.ToInt32(adatok[7]);
                Nevek.Add(score);
            }
            file.Close();
        }

        private void ujrair()
        {
            StreamWriter writer = new StreamWriter("Score.txt", false, Encoding.UTF8);
            foreach (Scores n in Nevek)
            {
                if (n.Nev.Equals(Form1.User.Nev))
                {
                    writer.WriteLine(n.Nev + ";" + n.Speed + ";" + n.Flick + ";" + n.Precision + ";" + n.Reaction + ";" + level + ";" + n.SequenceMemory + ";" + n.Chimp);
                }
                else
                    writer.WriteLine(n.Nev + ";" + n.Speed + ";" + n.Flick + ";" + n.Precision + ";" + n.Reaction + ";" + n.NumberMemory + ";" + n.SequenceMemory + ";" + n.Chimp);
            }
            writer.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelHelp_MouseHover(object sender, EventArgs e)
        {
            labelToolTip.Visible = true;
        }

        private void labelHelp_MouseLeave(object sender, EventArgs e)
        {
            labelToolTip.Visible = false;
        }
    }
}
