using System;
using System.Collections;
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
    public partial class ChimpTest : Form
    {
        Random rnd = new Random();

        List<string> used = new List<string>(); //már felhasznált poziciok a gombok számára ("koordinata")
        List<int> player = new List<int>(); // player általi sorrend
        List<Button> gombok = new List<Button>(); // gombok
        int number = 5; // hány darab gomb legyen az elsõ szinten
        int level = 0; // szint

        public ChimpTest()
        {
            InitializeComponent();

            btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            btnExit.FlatAppearance.MouseDownBackColor = btnExit.BackColor;
            btnExit.BackColorChanged += (s, e) => {
                btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            };
        }

        //start btn
        private void button1_Click(object sender, EventArgs e)
        {
            #region formazas
            btnExit.Visible = false;
            labelHelp.Visible = false;

            used.Clear();
            gombok.Clear();
            player.Clear();
            label1.Visible = false;
            button1.Visible = false;
            #endregion

            for (int i = 0; i < number; i++)
            {
                
                Button btn = new Button();
                btn.Text = (i + 1).ToString();
                btn.Name = (i + 1).ToString();

                btn.Size = new Size(65, 65);
                btn.Font = new Font("Arial", 25, FontStyle.Bold, GraphicsUnit.Point);
                btn.ForeColor = Color.White;
                btn.TabStop = false;

                gombok.Add(btn);
                int locX;
                int locY;

                do
                {
                    locX = rnd.Next(1, 9);
                    locY = rnd.Next(1, 7);
                } while (used.Contains(Convert.ToString(locX) + Convert.ToString(locY)));
                    
                btn.Location = new Point(70*(locX), 70*(locY));//(X: 1-es 8 kozott ||Y: 1 es 6 kozott random)
                used.Add(locX.ToString() + locY.ToString());

                btn.Click += new EventHandler(this.button_click);
                Controls.Add(btn);


            }
        }

        // szam btn
        void button_click(object sender, EventArgs e)
        {
            //Get the button clicked
            Button btn = sender as Button;
            player.Add(Convert.ToInt32(btn.Text));
            //MessageBox.Show(btn.Name + " Clicked");
            bool gameover = false;
            btn.Visible = false;


            if (player[0] != 1)
                GameOver();
            if (Convert.ToInt32(btn.Text) == 1)
            {
                foreach (Button i in gombok)
                    i.BackColor = Color.White;
            }
            if (player.Count == number)
            {
                for (int i = 0; i < number; i++)
                {
                    if (player[i] != i+1)
                        gameover = true;
                }
                if (gameover)
                    GameOver();
                else
                {
                    player.Clear();
                    number++;
                    label1.Text = "Great job!";
                    label1.Visible = true;
                    button1.Text = "Next";
                    button1.Visible = true;
                    level++;
                }
            }

        }

        private void GameOver()
        {
            foreach (Button i in gombok)
            {
                i.Hide();
            }
            label1.Text = "Game Over!";
            label1.Visible = true;
            button1.Text = "Try Again";
            button1.Visible = true;

            labelHelp.Visible = true;
            btnExit.Visible = true;

            if (level > Form1.User.Chimp)
            {
                Form1.User.Chimp = level;
                //új rekord
                label1.Text = "New Record! Game Over";
                beolvas();
                ujrair();
            }
            number = 5;
            level = 0;
            player.Clear();
            gombok.Clear();
        }


        //beolvassa a fajlt hogy ujrairhassa azt
        #region olvas
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
        #endregion

        private void ujrair()
        {
            StreamWriter writer = new StreamWriter("Score.txt", false, Encoding.UTF8);
            foreach (Scores n in Nevek)
            {
                if (n.Nev.Equals(Form1.User.Nev))
                {
                    writer.WriteLine(n.Nev + ";" + n.Speed + ";" + n.Flick + ";" + n.Precision + ";" + n.Reaction + ";" + n.NumberMemory + ";" + n.SequenceMemory + ";" + level);
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
    }
}
