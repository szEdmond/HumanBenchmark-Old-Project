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
    public partial class Precision : Form
    {
        internal List<RoundButton> Gombok { get; set; } = new List<RoundButton>();
        Random rand = new Random();
        int x, y;                                               // random location for target
        int szamlalo = 0;
        int miss = 0;

        public Precision()
        {
            InitializeComponent();
            FirstLoad();
        }

        private void FirstLoad() //betoltes, lathatosagok, gomblista 
        {
            #region gombok listaba/eltuntetes
            rBtn1.Visible = false;
            rBtn2.Visible = false;
            rBtn3.Visible = false;
            rBtn4.Visible = false;
            rBtn5.Visible = false;
            label1.Visible = true;
            btnStart.Visible = true;
            Gombok.Add(rBtn1);
            Gombok.Add(rBtn2);
            Gombok.Add(rBtn3);
            Gombok.Add(rBtn4);
            Gombok.Add(rBtn5);
            #endregion

            // exit gomb Hover/Click színe
            btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            btnExit.FlatAppearance.MouseDownBackColor = btnExit.BackColor;
            btnExit.BackColorChanged += (s, e) => {
                btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            };

        } 

        private void btnStart_Click(object sender, EventArgs e) // start gomb 
        {
            labelLives.Visible = true;
            labelHits.Visible = true;
            //stat = 0
            szamlalo = 0;
            miss = 0;

            label1.Visible = false;
            btnStart.Visible = false;
            btnExit.Visible = false;
            labelHelp.Visible = false;
            //timer indul
            timer1.Start();

            foreach (var n in Gombok)
            {
                n.Width = 100;
                n.Height = 100;
                //random hely generalas
                x = rand.Next(ClientSize.Width - n.Width);
                y = rand.Next(ClientSize.Height - n.Height);
                n.Location = new Point(x, y);
                n.Visible = true;
                wait(1000); 
            }

        } 

        private void timer1_Tick(object sender, EventArgs e) // gomb meretet csokkenti, es a csokkenes sebesseget valtoztatja 
        {
            if (miss < 3)
            {
            foreach (var n in Gombok)
            {
                if (n.Visible)
                {
                    //szamlalo = hit
                    if (szamlalo < 25) { 
                        n.Width -= 1;
                        n.Height -= 1;
                    }
                    else {
                        n.Width -= 2;
                        n.Height -= 2;       
                    }
                    if (n.Height <= 12)
                    {
                        miss++;
                            labelLives.Text = "Missed: " + miss;
                            n.Visible = false;
                            n.Width = 100;
                            n.Height = 100;
                            wait(200);
                            x = rand.Next(ClientSize.Width - n.Width);
                            y = rand.Next(ClientSize.Height - n.Height);
                            n.Location = new Point(x, y);
                            n.Visible = true;
                     }
                }
            }
            }
            //3. hiba eseten
            if (miss==3) {
                vege();
                rBtn1.Visible = false;
                rBtn2.Visible = false;
                rBtn3.Visible = false;
                rBtn4.Visible = false;
                rBtn5.Visible = false;

            }
        } 

        private void vege() // 3 "hiba" esetén vége 
        {
            
            timer1.Stop();
            foreach (var n in Gombok)
            {
                n.Visible = false;
            }
            label1.Text = "Game Over! Number of Hits: " + szamlalo;
            label1.Visible = true;
            btnStart.Text = "Again!";
            btnStart.Visible = true;

            labelLives.Visible = false;
            labelHits.Visible = false;
            btnExit.Visible = true;
            labelHelp.Visible = true;

            if (szamlalo > Form1.User.Precision)
            {
                Form1.User.Precision = szamlalo;
                label1.Text = "New Record! Number of Hits: " + szamlalo;
                Beolvas();
                Ujrair();
            }
            

        } 

        // beolvassa a fajlt hogy ujrairhassa azt
        #region olvas
        internal List<Scores> Nevek { get; set; } = new List<Scores>();
        private void Beolvas()
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
                score.Reaction = Convert.ToInt32(adatok[5]);
                score.SequenceMemory = Convert.ToInt32(adatok[6]);
                score.Chimp = Convert.ToInt32(adatok[7]);
                Nevek.Add(score);
            }
            file.Close();
        }
        #endregion

        private void Ujrair() // fajl Frissitese/ujrairasa az uj adatokkal 
        {
            StreamWriter writer = new StreamWriter("Score.txt", false, Encoding.UTF8);
            foreach (Scores n in Nevek)
            {
                if (n.Nev.Equals(Form1.User.Nev))
                {
                    writer.WriteLine(n.Nev + ";" + n.Speed + ";" + n.Flick + ";" + szamlalo + ";" + n.Reaction + ";" + n.NumberMemory + ";" + n.SequenceMemory + ";" + n.Chimp);
                }
                else
                    writer.WriteLine(n.Nev + ";" + n.Speed + ";" + n.Flick + ";" + n.Precision + ";" + n.Reaction + ";" + n.NumberMemory + ";" + n.SequenceMemory + ";" + n.Chimp);
            }
            writer.Close();
        } 

        private void onHit() // találat... vár egy minimálisat mielott megjelenik a kovetkezo 
        {
            szamlalo++;
            labelHits.Text = "Hits: " + szamlalo;
            int t = 250;
            if (t > 51) { 
                if (szamlalo % 5 == 0)
                {
                    t -= 50;
                }
            }
            wait(t);
        }

        #region Gombok
        private void rBtn1_Click(object sender, EventArgs e)
        {
            rBtn1.Visible = false;
            onHit();
            rBtn1.Width = 100;
            rBtn1.Height = 100;
            x = rand.Next(ClientSize.Width - rBtn1.Width);
            y = rand.Next(ClientSize.Height - rBtn1.Height);
            rBtn1.Location = new Point(x, y);
            rBtn1.Visible = true;
        }

        private void rBtn2_Click(object sender, EventArgs e)
        {
            rBtn2.Visible = false;
            onHit();
            rBtn2.Width = 100;
            rBtn2.Height = 100;
            x = rand.Next(ClientSize.Width - rBtn2.Width);
            y = rand.Next(ClientSize.Height - rBtn2.Height);
            rBtn2.Location = new Point(x, y);
            rBtn2.Visible = true;
        }

        private void rBtn3_Click(object sender, EventArgs e)
        {
            rBtn3.Visible = false;
            onHit();
            rBtn3.Width = 100;
            rBtn3.Height = 100;
            x = rand.Next(ClientSize.Width - rBtn3.Width);
            y = rand.Next(ClientSize.Height - rBtn3.Height);
            rBtn3.Location = new Point(x, y);
            rBtn3.Visible = true;
        }

        private void rBtn4_Click(object sender, EventArgs e)
        {
            rBtn4.Visible = false;
            onHit();
            rBtn4.Width = 100;
            rBtn4.Height = 100;
            x = rand.Next(ClientSize.Width - rBtn4.Width);
            y = rand.Next(ClientSize.Height - rBtn4.Height);
            rBtn4.Location = new Point(x, y);
            rBtn4.Visible = true;
        }

        private void rBtn5_Click(object sender, EventArgs e)
        {
            rBtn5.Visible = false;
            onHit();
            rBtn5.Width = 100;
            rBtn5.Height = 100;
            x = rand.Next(ClientSize.Width - rBtn5.Width);
            y = rand.Next(ClientSize.Height - rBtn5.Height);
            rBtn5.Location = new Point(x, y);
            rBtn5.Visible = true;
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

        public void wait(int milliseconds) // várakozás millisecond
    {
        var timer1 = new System.Windows.Forms.Timer();
        if (milliseconds == 0 || milliseconds < 0) return;

        // Console.WriteLine("start wait timer");
        timer1.Interval = milliseconds;
        timer1.Enabled = true;
        timer1.Start();

        timer1.Tick += (s, e) =>
        {
            timer1.Enabled = false;
            timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

        while (timer1.Enabled)
        {
            Application.DoEvents();
        }
    }
}
}

