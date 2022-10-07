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
    public partial class Speed : Form
    {
        DateTime startTime, endTime;                            //reszido szamitas
        Random rand = new Random();
        int x, y;                                               //random location for target
        int szamlalo = 0;
        int miss = 0;
        double atlag = 0;
        List<double> Reszidok = new List<double>();
        double reszido = 0;

        public Speed()
        {
            InitializeComponent();
            FirstLoad();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FirstLoad() //elso toltes, mi lathato es mi nem
        {
            btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            btnExit.FlatAppearance.MouseDownBackColor = btnExit.BackColor;
            btnExit.BackColorChanged += (s, e) => {
                btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            };

            btnTarget.Visible = false;
            btnStart.Visible = true;
            labelTitle.Visible = true;
            btnExit.Visible = true;

        }

        private void btnTarget_MouseDown(object sender, MouseEventArgs e)
        {
            // idomeres, atvaltas millisec-be, listaba rakas
            endTime = DateTime.Now;
            Double elapsedMillisecs = ((TimeSpan)(endTime - startTime)).TotalMilliseconds;
            Reszidok.Add(elapsedMillisecs);
            startTime = DateTime.Now;
            szamlalo++; //hit

            //20x kell eltalalni
            if (szamlalo <20)
            {
                x = rand.Next(ClientSize.Width - btnTarget.Width);
                y = rand.Next(ClientSize.Height - btnTarget.Height);
                btnTarget.Location = new Point(x, y);
            }

            else
            {
                // atlag ido szamitasa ket celtabla kozott 
                foreach (var item in Reszidok)
                {
                    reszido += item; 
                }
                atlag = Math.Round(reszido / 20, 2); //reszidok atlaga

                double osszes = szamlalo + miss; //osszes kattintas szama
                double precision = szamlalo / osszes * 100;
                
                // megjelenitesek
                btnTarget.Visible = false;
                labelTitle.Text = "Game Over!\n"+"Hit: "+szamlalo+" / Miss: "+miss+"\nPrecision: "+precision.ToString("0.00")+"%"+"\nTime between Targets: "+atlag + "ms";
                btnStart.Text = "Try Again";
                if (atlag < Form1.User.Speed) // ellenorzi hogy rekord-e
                {
                    Form1.User.Speed = atlag;
                    labelTitle.Text = "New Record! Játék vége!\n"+"Hit: "+szamlalo+" / Miss: "+miss+"\nPrecision: "+precision.ToString("0.00")+" % "+"\nTime between Targets: "+atlag + "ms";
                    Beolvas();
                    Ujrair();
                }

                labelTitle.Visible = true;
                btnExit.Visible = true;
                btnStart.Visible = true;
                label1.Visible = true;
            }

        }

        // Rekord eseten beolvasas...ujrairas
        #region adatFrissites
        internal List<Scores> Nevek { get; set; } = new List<Scores>(); //Scores osztalyu lista 

        private void Beolvas() // beolvasas uj rekord eseten 
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
                score.NumberMemory = Convert.ToInt32(adatok[6]);
                score.NumberMemory = Convert.ToInt32(adatok[7]);
                Nevek.Add(score);
            }
            file.Close();
            
        }

        private void Ujrair() // beolvasas utan ujrairas uj rekord eseten
        {
            StreamWriter writer = new StreamWriter("Score.txt", false, Encoding.UTF8);
            foreach (Scores n in Nevek)
            {
                if (n.Nev.Equals(Form1.User.Nev))
                {
                    writer.WriteLine(n.Nev + ";" + atlag + ";" + n.Flick + ";" + n.Precision + ";" + n.Reaction + ";" + n.NumberMemory + ";" + n.SequenceMemory + ";" + n.Chimp);
                }
                else
                    writer.WriteLine(n.Nev + ";" + n.Speed + ";" + n.Flick + ";" + n.Precision + ";" + n.Reaction + ";" + n.NumberMemory + ";" + n.SequenceMemory + ";" + n.Chimp);

            }
            writer.Close();
        }
        #endregion

        #region tooltip
        private void label1_MouseHover(object sender, EventArgs e)
        {
            labelToolTip.Visible = true;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            labelToolTip.Visible = false;
        }
        #endregion

        private void Precision1_MouseClick(object sender, MouseEventArgs e) // mellékattintas(miss) 
        {
            miss++;
        }

        private void btnStart_Click(object sender, EventArgs e) // Start, alapállás
        {
            label1.Visible = false;
            labelTitle.Visible = false;
            btnStart.Visible = false;
            btnExit.Visible = false;
            // reszido lista torlese
            Reszidok.Clear();           
            
            // Target Gomb elhelyezese random helyre
            x = rand.Next(ClientSize.Width - btnTarget.Width);
            y = rand.Next(ClientSize.Height - btnTarget.Height);
            btnTarget.Location = new Point(x, y);
            btnTarget.Visible = true;

            szamlalo = 0;
            miss = 0;

            // reszido nullázás és idozito inditása
            reszido = 0;
            startTime = DateTime.Now;
            
        }
    }
}
