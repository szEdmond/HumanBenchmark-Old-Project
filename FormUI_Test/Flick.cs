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
    public partial class Flick : Form
    {
        public Flick()
        {
            InitializeComponent();
            StartUp();
        }

        int szamlalo = 0;
        Random rand = new Random();
        int x, y;

        //format
        private void StartUp()
        {
            btnReset.Visible = false;
            btnTarget.Visible = false;
            btnStart.Visible = true;
            label1.Visible = true;

            // exit gomb Hover, Click színe
            btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            btnExit.FlatAppearance.MouseDownBackColor = btnExit.BackColor;
            btnExit.BackColorChanged += (s, e) => {
                btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            };
        }

        //Kurzor vissza kozepre minden talalat utan
        private void btnReset_MouseMove(object sender, MouseEventArgs e) //on Hover: target uj helyre helyezese es megjelenitese 
        {
            btnReset.Visible = false;

            x = rand.Next(ClientSize.Width - btnTarget.Width);
            y = rand.Next(ClientSize.Height - btnTarget.Height);
            btnTarget.Location = new Point(x, y);
            btnTarget.Visible = true;
        }

        private void btnTarget_MouseDown(object sender, MouseEventArgs e) // találat 
        {
            szamlalo++;
            btnTarget.Visible = false;
            btnReset.Visible = true;
        } 

        private void timer1_Tick(object sender, EventArgs e) //timer, alul megy a csik, ha végére ér "lejárt" az ido 
        {
            panelProgress.Left += ClientSize.Width/400;

            if (panelProgress.Left >= ClientSize.Width-panelProgress.Width)
            {
                timer1.Stop();
                btnReset.Visible = false;
                btnTarget.Visible = false;
                btnStart.Visible = true;
                label1.Visible = true;
                btnExit.Visible = true;
                labelHelp.Visible = true;

                if (szamlalo > Form1.User.Flick) {
                    Form1.User.Flick = szamlalo;
                    label1.Text = "Új Rekord! Targets hit: " + szamlalo;

                    Beolvas();
                    Ujrair();
                }
                else
                    label1.Text = "Targets hit: " + szamlalo;
            }
        }  

        //beolvassa a fajlt hogy ujrairhassa azt
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
                score.NumberMemory = Convert.ToInt32(adatok[5]);
                score.SequenceMemory = Convert.ToInt32(adatok[6]);
                score.Chimp = Convert.ToInt32(adatok[7]);
                Nevek.Add(score);
            }
            file.Close();
        }
        #endregion

        private void Ujrair()
        {
            StreamWriter writer = new StreamWriter("Score.txt", false, Encoding.UTF8);
            foreach (Scores n in Nevek)
            {
                if (n.Nev.Equals(Form1.User.Nev))
                {
                    writer.WriteLine(n.Nev + ";" + n.Speed + ";" + szamlalo + ";" + n.Precision + ";" + n.Reaction + ";" + n.NumberMemory + ";" + n.SequenceMemory + ";" + n.Chimp);
                }
                else
                    writer.WriteLine(n.Nev + ";" + n.Speed + ";" + n.Flick + ";" + n.Precision + ";" + n.Reaction + ";" + n.NumberMemory + ";" + n.SequenceMemory + ";" + n.Chimp);
            }
            writer.Close();
        } //fajl Frissitese/ujrairasa az uj adatokkal

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

        //start, reset + timer start
        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
            szamlalo = 0;
            btnExit.Visible = false;
            labelHelp.Visible = false;
            btnStart.Visible = false;
            label1.Visible = false;
            btnReset.Visible = true;
            panelProgress.Left = 0;
        } //start gomb
    }
}
