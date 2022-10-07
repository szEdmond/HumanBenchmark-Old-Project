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
    public partial class Login : Form
    {
        internal List<Nevek> Nevek { get; set; } = new List<Nevek>();
        public static string nick;
        public Login()
        {
            InitializeComponent();
            tbJelszo.PasswordChar = '*';
            beolvas();
        }

        private void beolvas() // listaba rajka az osszes combo-t
        {
            Nevek.Clear();
            StreamReader file = new StreamReader("Combo.txt", Encoding.UTF8);
            Nevek nev;
            while (!file.EndOfStream)
            {
                string sor = file.ReadLine();
                string[] adatok = sor.Split(';');
                nev = new Nevek();
                nev.Nev = adatok[0];
                nev.Jelszo = adatok[1];
                Nevek.Add(nev);
            }
            file.Close();
        }

        private void btnBejelentkez_Click(object sender, EventArgs e) // Login combo ellenorzese 
        {
            bool sikeres = false;
            foreach(Nevek n in Nevek)
            {
                if(n.Nev.Equals(tbNev.Text) && n.Jelszo.Equals(tbJelszo.Text))
                {
                    nick = tbNev.Text; // felhasznalonev atadasa
                    sikeres = true;
                    this.Hide();
                    Form1 frm = new Form1();
                    frm.ShowDialog();
                    this.Close();
                    
                }
            }
            if (!sikeres)
            {
                MessageBox.Show("Jelszo vagy Felhasznalonev hibás!");
            }
        }

        private void btnReg_Click(object sender, EventArgs e) // Regisztracios felulet elohozasa
        {
            this.Hide();
            Reg frm = new Reg();
            frm.ShowDialog();
            this.Close();
        }
    }
}
