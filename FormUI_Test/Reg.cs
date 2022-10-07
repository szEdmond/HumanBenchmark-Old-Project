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
    public partial class Reg : Form
    {
        Nevek combo = new Nevek();
        internal Nevek Combo { get; set; }
        Scores felhasznalo = new Scores();

        internal List<string> username { get; set; }
        public Reg()
        {
            InitializeComponent();
            tbJelszo.PasswordChar = '*';
            tbJelszo2.PasswordChar = '*';
            beolvas();
        }

        private void beolvas() //beolvassa a felhasznaloneveket es listaba rakja(ne legyen megegyezo) 
        {
            username = new List<string>();
            username.Clear();
            StreamReader file = new StreamReader("Combo.txt", Encoding.UTF8);

            while (!file.EndOfStream)
            {
                string sor = file.ReadLine();
                string[] adatok = sor.Split(';');
                username.Add(adatok[0]);
            }
            file.Close();
        } 

        private void btnReg_Click(object sender, EventArgs e) //regisztracios feltetelk ellenorzese 
        {
            if (!username.Contains(tbNev.Text)) { 
                if(tbJelszo.Text.Length >= 4)
                {
                    if(!tbNev.Text.Equals("") && !tbJelszo.Text.Equals("") && tbJelszo.Text.Equals(tbJelszo2.Text))
                    {
                        comboWrite();

                        MessageBox.Show("Sikeres regisztracio");

                        scoreWrite();

                        this.Hide();
                        Login frm = new Login();
                        frm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nev, Jelszo mezo nem lehet üres, Jelszónak egyeznie kell!");
                    }
                }
                else
                {
                    MessageBox.Show("Jelszó minimum 4 karakter");
                }
            }
            else
            {
                MessageBox.Show("Ez a felhasznalonev mar foglalt.");
            }
        } 

        private void scoreWrite() // score.txt-t feltolti alapértékekkel 
        {
            Scores felhasznalo = new Scores();
            felhasznalo.Nev = tbNev.Text;
            StreamWriter writer = new StreamWriter("Score.txt", true, Encoding.UTF8);
            writer.WriteLine(
                felhasznalo.Nev + ";" + 
                felhasznalo.Speed + ";" + 
                felhasznalo.Precision + ";" + 
                felhasznalo.Flick + ";" + 
                felhasznalo.Reaction + ";" +
                felhasznalo.NumberMemory + ";" +
                felhasznalo.SequenceMemory + ";" +
                felhasznalo.Chimp);


            writer.Close();
        }

        private void comboWrite() // felhasznalonev;jelszo combo elmentése 
        {
            combo.Nev = tbNev.Text;
            combo.Jelszo = tbJelszo.Text;
            StreamWriter writer = new StreamWriter("Combo.txt", true, Encoding.UTF8); //append uj combo
            writer.WriteLine(combo.Nev + ";" + combo.Jelszo);
            writer.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login frm = new Login();
            frm.ShowDialog();
            this.Close();
        }
    }
}
