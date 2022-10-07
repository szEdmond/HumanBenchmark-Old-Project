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
    public partial class Sequence : Form
    {
        Random rnd = new Random();
        int level = 0;
        List<Label> gombok = new List<Label>();
        List<int> simon = new List<int>();
        List<int> player = new List<int>();

        public Sequence()
        {
            InitializeComponent();
            listaTolt();
            labelTitle.Text = "Sequence Memory\nRepeat the pattern on the screen";

            btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            btnExit.FlatAppearance.MouseDownBackColor = btnExit.BackColor;
            btnExit.BackColorChanged += (s, e) => {
                btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            };
        }

        private void listaTolt()
        {
            gombok.Add(label1);
            gombok.Add(label2);
            gombok.Add(label3);
            gombok.Add(label4);
            gombok.Add(label5);
            gombok.Add(label6);
            gombok.Add(label7);
            gombok.Add(label8);
            gombok.Add(label9);
        }

        private void btnStart_MouseClick(object sender, MouseEventArgs e)
        {
            btnExit.Visible = false;
            labelHelp.Visible = false;

            //van [0,1,2,3,4,5,6,7,8

            level = 0;
            simon.Clear();
            player.Clear();
            //szam hozzaadas
            addToSimon();

            btnStart.Visible = false;

            playSequence();

            labelLevel.Visible = true;
            labelLevel.Text = "Level: " + level;

        }

        private void addToSimon()
        {
            simon.Add(rnd.Next(0, 9));
        }

        //computer plays sequence
        private async void playSequence()
        {
            tableLayoutPanel1.Enabled = false;
            await Task.Delay(500);
            foreach (var n in simon)
            {
                gombok[n].BackColor = Color.FromArgb(255,255,255);
                await Task.Delay(1000);
                gombok[n].BackColor = Color.FromArgb(10, 145, 171);
                await Task.Delay(100);
            }
            tableLayoutPanel1.Enabled = true;
        }

        private void klikkEvent(int x)
        {
            
            player.Add(x); //adott gomb erteket player listaba
            bool gameover = false;
            //ha lenyomta a szintnek megfelelo mennyisegu gombot - ellenorzes
            if (player.Count == simon.Count)
            {
                tableLayoutPanel1.Enabled = false;

                for (int i = 0; i < player.Count; i++)
                {
                    if (player[i] != simon[i])
                    {
                        gameover = true;
                    }
                }
                //bad ending
                if (gameover)
                {
                    gameOver();
                }
                //good ending
                else
                {
                tableLayoutPanel1.Enabled = true;
                player.Clear();
                addToSimon();
                playSequence();
                level++;
                labelLevel.Text = "Level: " + level;
                }
            }
        }

        private void gameOver()
        {
            btnExit.Visible = true;
            labelHelp.Visible = true;

            tableLayoutPanel1.Enabled = false;
            btnStart.Text = "Try Again!";
            btnStart.Visible = true;
            MessageBox.Show("Game over!");
            labelLevel.Visible = false;
            labelTitle.Text = "Sequence memory\n" + level + ". level";
            if(level > Form1.User.SequenceMemory)
            {
                Form1.User.SequenceMemory = level;
                labelTitle.Text = "Sequence memory\nNew Record! " + level + ". level!";
                beolvas();
                ujrair();
            }
            level = 0;
        }

        private void ujrair()
        {
            StreamWriter writer = new StreamWriter("Score.txt", false, Encoding.UTF8);
            foreach (Scores n in Nevek)
            {
                if (n.Nev.Equals(Form1.User.Nev))
                {
                    writer.WriteLine(n.Nev + ";" + n.Speed + ";" + n.Flick + ";" + n.Precision + ";" + n.Reaction + ";" + n.NumberMemory + ";" + level + ";" + n.Chimp);
                }
                else
                    writer.WriteLine(n.Nev + ";" + n.Speed + ";" + n.Flick + ";" + n.Precision + ";" + n.Reaction + ";" + n.NumberMemory + ";" + n.SequenceMemory + ";" + n.Chimp);

            }
            writer.Close();
        }

        internal List<Scores> Nevek { get; set; } = new List<Scores>(); //Scores osztalyu lista 
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

        //bruteforce(ish)(megnemis).exe
        #region buttons
        private async void label1_Click(object sender, EventArgs e)
        {
            //kattintaskor feher szinre valtas egy pillanatra
            label1.BackColor = Color.FromArgb(255, 255, 255);
            await Task.Delay(10);
            label1.BackColor = Color.FromArgb(10, 145, 171);
            klikkEvent(0);
        }

        private async void label2_Click(object sender, EventArgs e)
        {
            
            label2.BackColor = Color.FromArgb(255, 255, 255);
            await Task.Delay(10);
            label2.BackColor = Color.FromArgb(10, 145, 171);
            klikkEvent(1);
        }

        private async void label3_Click(object sender, EventArgs e)
        {
            
            label3.BackColor = Color.FromArgb(255, 255, 255);
            await Task.Delay(10);
            label3.BackColor = Color.FromArgb(10, 145, 171);
            klikkEvent(2);
        }

        private async void label4_Click(object sender, EventArgs e)
        {
            
            label4.BackColor = Color.FromArgb(255, 255, 255);
            await Task.Delay(10);
            label4.BackColor = Color.FromArgb(10, 145, 171);
            klikkEvent(3);
        }

        private async void label5_Click(object sender, EventArgs e)
        {
            
            label5.BackColor = Color.FromArgb(255, 255, 255);
            await Task.Delay(10);
            label5.BackColor = Color.FromArgb(10, 145, 171);
            klikkEvent(4);
        }

        private async void label6_Click(object sender, EventArgs e)
        {
            
            label6.BackColor = Color.FromArgb(255, 255, 255);
            await Task.Delay(10);
            label6.BackColor = Color.FromArgb(10, 145, 171);
            klikkEvent(5);
        }

        private async void label7_Click(object sender, EventArgs e)
        {
            
            label7.BackColor = Color.FromArgb(255, 255, 255);
            await Task.Delay(10);
            label7.BackColor = Color.FromArgb(10, 145, 171);
            klikkEvent(6);
        }

        private async void label8_Click(object sender, EventArgs e)
        {
            
            label8.BackColor = Color.FromArgb(255, 255, 255);
            await Task.Delay(10);
            label8.BackColor = Color.FromArgb(10, 145, 171);
            klikkEvent(7);
        }

        private async void label9_Click(object sender, EventArgs e)
        {
            
            label9.BackColor = Color.FromArgb(255, 255, 255);
            await Task.Delay(10);
            label9.BackColor = Color.FromArgb(10, 145, 171);
            klikkEvent(8);
        }
        #endregion

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
