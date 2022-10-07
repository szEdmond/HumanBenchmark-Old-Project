using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FormUI_Test
{
    public partial class Form1 : Form
    {
        private static Scores user = new Scores();
        internal static Scores User { get => user; set => user = value; }
        int Sp; int Fl; int Pr; int Re; int Se; int Nu; int Ch;
        string[] labels = { "Speed", "Precision", "Flick", "Reaction", "Sequence", "NumMem", "Chimp" };

        public Form1()
        {
            InitializeComponent();

            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataVisualize();
            customizeDesign();
            hideSubMenu();
            feltolt();
            radarChart();
            FirstLoad();
            
            label1.Text = "Hi, " + User.Nev;
            label2.Text = "Welcome, " + User.Nev;
        }

        private void dataVisualize()
        {
            string sSp, sFl, sPr, sRe, sSe, sNu, sCh;
            if (User.Speed.Equals(9999)) sSp = "X";
            else sSp = Sp.ToString();
            if (User.Flick.Equals(0)) sFl = "X";
            else sFl = Fl.ToString();
            if (User.Precision.Equals(0)) sPr = "X";
            else sPr = Pr.ToString();
            if (User.Reaction.Equals(9999)) sRe = "X";
            else sRe = Re.ToString();
            if (User.SequenceMemory.Equals(0)) sSe = "X";
            else sSe = Se.ToString();
            if (User.NumberMemory.Equals(0)) sNu = "X";
            else sNu = Nu.ToString();
            if (User.Chimp.Equals(0)) sCh = "X";
            else sCh = Ch.ToString();
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelSlide.Left -= 2;
            chart1.Update();
            if (labelSlide.Left < -1300)
            {
                labelSlide.Location = new Point(750, 13);
                for (int i = 0; i < labels.Length; i++)
                {

                }
                string sSp, sFl, sPr, sRe, sSe, sNu, sCh;
                if (User.Speed.Equals(9999)) sSp = "X";
                else sSp = user.Speed.ToString();
                if (User.Flick.Equals(0)) sFl = "X";
                else sFl = user.Flick.ToString();
                if (User.Precision.Equals(0)) sPr = "X";
                else sPr = user.Precision.ToString();
                if (User.Reaction.Equals(9999)) sRe = "X";
                else sRe = user.Reaction.ToString();
                if (User.SequenceMemory.Equals(0)) sSe = "X";
                else sSe = user.SequenceMemory.ToString();
                if (User.NumberMemory.Equals(0)) sNu = "X";
                else sNu = user.NumberMemory.ToString();
                if (User.Chimp.Equals(0)) sCh = "X";
                else sCh = user.Chimp.ToString();

                labelSlide.Text = "Speed: " + sSp + " || Flick: " + sFl + " || Precision: " + sPr + " || Reaction Time: " +
                                sRe + " || Number Memory: " + sNu + " || Sequence Memory: " + sSe + " || Chimp Test: " + sCh;

                radarChart();
            }
        }//kepernyo aljan szöveg "Kúszik" jobbrol balra Timer-rel... Kiirja a jelenlegi eredményeit a jatekosnak
        // + radar diagramm frissitese

        private void FirstLoad()
        {
            panelStats.Visible = true;
            labelSlide.Text = "Speed: " + User.Speed + " || Flick: " + User.Flick + " || Precision: " + User.Precision + " || Reaction Time: " + 
                                User.Reaction + " || Number Memory: " + User.NumberMemory + " || Sequence Memory: " + User.SequenceMemory + " || Chimp Test: " + User.Chimp;
            timer1.Start();
            
        }

        
        private void radarChart()//radar diagramm kirajzolas
        {
            if (User.Speed < 370) Sp = 5;
            else if (User.Speed < 400) Sp = 4;
            else if (User.Speed < 480) Sp = 3;
            else if (User.Speed < 600) Sp = 2;
            else if (User.Speed < 8888) Sp = 1;
            else Sp = 0;

            if (User.Flick > 15) Fl = 5;
            else if (User.Flick > 12) Fl = 4;
            else if (User.Flick > 10) Fl = 3;
            else if (User.Flick > 7) Fl = 2;
            else if (User.Flick > 0) Fl = 1;
            else Fl = 0;

            if (User.Precision > 100) Pr = 5;
            else if (User.Precision > 50) Pr = 4;
            else if (User.Precision > 35) Pr = 3;
            else if (User.Precision > 25) Pr = 2;
            else if (User.Precision > 0) Pr = 1;
            else Pr = 0;

            if (User.Reaction < 190) Re = 5;
            else if (User.Reaction < 260) Re = 4;
            else if (User.Reaction < 280) Re = 3;
            else if (User.Reaction < 300) Re = 2;
            else if (User.Reaction < 8888) Re = 1;
            else Re = 0;

            if (User.SequenceMemory > 9) Se = 5;
            else if (User.SequenceMemory > 8) Se = 4;
            else if (User.SequenceMemory > 7) Se = 3;
            else if (User.SequenceMemory > 5) Se = 2;
            else if (User.SequenceMemory > 1) Se = 1;
            else Se = 0;

            if (User.NumberMemory > 9) Nu = 5;
            else if (User.NumberMemory > 8) Nu = 4;
            else if (User.NumberMemory > 7) Nu = 3;
            else if (User.NumberMemory > 4) Nu = 2;
            else if (User.NumberMemory > 1) Nu = 1;
            else Nu = 0;

            if (User.Chimp > 9) Ch = 5;
            else if (User.Chimp > 7) Ch = 4;
            else if (User.Chimp > 5) Ch = 3;
            else if (User.Chimp > 3) Ch = 2;
            else if (User.Chimp > 1) Ch = 1;
            else Ch = 0;

            
            if (Sp == 0 && Fl == 0 && Pr == 0 && Re == 0 && Se == 0 && Nu == 0 && Ch == 0)
            {
                chart1.Visible = false;
                pb_FirstTime.Visible = true;
            }
            else {
                chart1.Visible = true;
                pb_FirstTime.Visible = false;
                double[] eredmenyek = { Sp, Fl, Pr, Re, Se, Nu, Ch };
                //chart1.Series["s1"].Points.AddXY("Speed", Sp);
                //chart1.Series["s1"].Points.AddXY("Flick", Fl);
                //chart1.Series["s1"].Points.AddXY("Precision",Pr);
                //chart1.Series["s1"].Points.AddXY("Reaction", Re);
                //chart1.Series["s1"].Points.AddXY("Sequence", Se);
                //chart1.Series["s1"].Points.AddXY("NumMemory", Nu);
                //chart1.Series["s1"].Points.AddXY("Chimp", Ch);
                chart1.Series["s1"].Points.Clear();
                for (int i = 0; i < eredmenyek.Length; i++)
                {
                    chart1.Series["s1"].Points.AddXY(labels[i], eredmenyek[i]);
                }
            }

        }

        private void feltolt()//adatok beolvasasa
        {
            Scores score;
            score = new Scores();
            StreamReader file = new StreamReader("Score.txt", Encoding.UTF8);

            while (!file.EndOfStream)
            {
                string sor = file.ReadLine();
                string[] adatok = sor.Split(';');
                if (adatok[0] == Login.nick)
                {
                    score.Nev = Convert.ToString(adatok[0]);
                    score.Speed = Convert.ToDouble(adatok[1]);
                    score.Flick = Convert.ToInt32(adatok[2]);
                    score.Precision = Convert.ToDouble(adatok[3]);
                    score.Reaction = Convert.ToDouble(adatok[4]);
                    score.NumberMemory = Convert.ToInt32(adatok[5]);
                    score.SequenceMemory = Convert.ToInt32(adatok[6]);
                    score.Chimp = Convert.ToInt32(adatok[7]);
                }
            }
            User = score;     // osztaly tipusu Adott felhasznalo adatai
            file.Close();
        }

        private void customizeDesign()
        {
            panelPrecision.Visible = false;  //submenu, lenyithato menusor...
        }

        // Side Bar "Menu"
        #region SIDE BAR MENU 
        private void hideSubMenu()
        {
            if (panelPrecision.Visible == true)
                panelPrecision.Visible = false;
        }
        
        private void showSubMenu(Panel subMenu) //panel Tipusu, SubMenu nev
        {
            if(subMenu.Visible == false)
            {
                hideSubMenu();                  //eltuntetunk minden submenut
                subMenu.Visible = true;         // ezt a submenut megjelenitjuk
            }
            else {
                subMenu.Visible = false;        //ha mar latszik a submenu es ujrakatt akkor eltunteti...
            }
        }

        private void btnPrecision_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPrecision);
        }

        #region PrecisionSubmenu
        private void button2_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new Speed());
            //
            //
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new Flick());
            //
            //
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new Precision());
            //
            hideSubMenu();
        }
        #endregion

        private void btnReaction_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new Reaction());
            //
            hideSubMenu();
        }

        private void btnNumMemory_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new NumberMemory());
            //
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new Sequence());
            //
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new ChimpTest());
            //
            hideSubMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new Leaderboard());
            //
            hideSubMenu();
        }

        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //code
            openChildForm(new Sorting());
            //
            hideSubMenu();
            MessageBox.Show("Do not leave while Sorting is running");
        }

        private Form activeForm = null;

        #endregion 

        
        private void openChildForm(Form childForm)//megnyitja a tobbi "ChildForm-t"
        {
            if (activeForm != null)
            {
                activeForm.Close();           //if there is an active form, close it...?
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login frm = new Login();
            frm.ShowDialog();
            this.Close();
        }
    }
}
