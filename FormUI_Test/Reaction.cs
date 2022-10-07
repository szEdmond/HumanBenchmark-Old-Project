using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI_Test
{
    public partial class Reaction : Form
    {
        //(211,69,69) #d34545  --- RED
        //(39,196,107) #27c46b --- GREEN
        //(6, 84, 113) //BLUE
        Random rnd = new Random();
        DateTime startTime, endTime;
        List<double> FiveTries = new List<double>();
        int szamlalo = 1;
        bool idoben = false;
        double atlag;
        public Reaction()
        {
            InitializeComponent();
            firstLoad();
        }

        private void firstLoad()//elso megjelenes
        {
            btnStart.Visible = true;
            btnReactionButton.Text = "Click on Green!";
            FiveTries.Clear();
            btnReactionButton.Visible = false;
            label2.Text = "play area";

            btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            btnExit.FlatAppearance.MouseDownBackColor = btnExit.BackColor;
            btnExit.BackColorChanged += (s, e) => {
                btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            };
        }


        private async void btnStart_Click(object sender, EventArgs e)
        {
            btnExit.Visible = false;
            labelHelp.Visible = false;
            label2.Text = "";
            //5. probalkozas utan gomb atvalt "show result"
            if (szamlalo == 5)
            {
                btnStart.Text = "Show Results: ";
                btnReactionButton.BackColor = Color.FromArgb(12, 34, 51);
            }
            //ha meg nem volt meg az 5 probalkozas
            if (szamlalo <= 5)
            {
                btnStart.Visible = false;
                btnReactionButton.Visible = true;
                btnReactionButton.BackColor = Color.FromArgb(12, 34, 51);
                int x = rnd.Next(500, 5000);
                await Task.Delay(x);
                idoben = true;
                btnReactionButton.BackColor = Color.FromArgb(6, 113, 35);
                startTime = DateTime.Now;
            }
            else
            {
                if (btnStart.Text == "New Game")
                {
                    szamlalo = 1;
                    FiveTries.Clear();
                }
                else { 
                btnStart.Text = "New Game";
                btnExit.Visible = true;
                labelHelp.Visible = true;
                btnReactionButton.Visible = false;
                atlag = (FiveTries[0] + FiveTries[1] + FiveTries[2] + FiveTries[3] + FiveTries[4]) / 5;
                label2.Text = (
                    "AVARAGE: " + atlag.ToString() + "ms" + "\n" +
                    FiveTries[0].ToString() + "ms" + "\n" +
                    FiveTries[1].ToString() + "ms" + "\n" +
                    FiveTries[2].ToString() + "ms" + "\n" +
                    FiveTries[3].ToString() + "ms" + "\n" +
                    FiveTries[4].ToString() + "ms");
                if (atlag < Form1.User.Reaction)
                {
                    Form1.User.Reaction = atlag;
                    label2.Text = (
                    "Új Rekord!\n" +
                    "AVARAGE: " + atlag.ToString() + "ms" + "\n" +
                    FiveTries[0].ToString() + "ms" + "\n" +
                    FiveTries[1].ToString() + "ms" + "\n" +
                    FiveTries[2].ToString() + "ms" + "\n" +
                    FiveTries[3].ToString() + "ms" + "\n" +
                    FiveTries[4].ToString() + "ms");
                    beolvas();
                    ujrair();
                }
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
        private void ujrair() // fajl Frissitese/ujrairasa az uj adatokkal 
        {
            StreamWriter writer = new StreamWriter("Score.txt", false, Encoding.UTF8);
            foreach (Scores n in Nevek)
            {
                if (n.Nev.Equals(Form1.User.Nev))
                {
                    writer.WriteLine(n.Nev + ";" + n.Speed + ";" + n.Flick + ";" + n.Precision + ";" + atlag + ";" + n.NumberMemory + ";" + n.SequenceMemory + ";" + n.Chimp);
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

        private async void btnReactionButton_Click(object sender, MouseEventArgs e)
        {
            if (idoben)
            {
                idoben = false;
                endTime = DateTime.Now;
                Double elapsedMillisecs = ((TimeSpan)(endTime - startTime)).TotalMilliseconds;
                label2.Text = elapsedMillisecs.ToString() + "ms";
                btnReactionButton.Visible = false;
                btnStart.Visible = true;
                btnReactionButton.BackColor = Color.FromArgb(12, 34, 51);
                FiveTries.Add(Math.Round(elapsedMillisecs,2));
                label3.Text = "Try: "+ szamlalo.ToString();
                szamlalo++;
            }
            else 
            {
                idoben = false;
                endTime = DateTime.Now;
                btnReactionButton.Visible = false;
                label2.Text = "You pressed too early\nNow you have to wait for Task.Delay :)";
                await Task.Delay(5000);
                btnStart.Visible = true;
            }
        }





        /*
    if(szamlalo==5)
    { 
        double atlag = (FiveTries[0] + FiveTries[1] + FiveTries[2] + FiveTries[3] + FiveTries[4])/5;
        label2.Visible = true;
        label2.Text = (
            "AVARAGE: " + atlag.ToString() + "ms" + "\n" + 
            FiveTries[0].ToString() + "\n" + "ms" +
            FiveTries[1].ToString() + "\n" + "ms" +
            FiveTries[2].ToString() + "\n" + "ms" +
            FiveTries[3].ToString() + "\n" + "ms" +
            FiveTries[4].ToString() + "ms");
    }
    */
    }
}
