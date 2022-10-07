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
    public partial class Leaderboard : Form
    {
        public Leaderboard()
        {
            InitializeComponent();

            //tablazat formazasa
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(10, 145, 171);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(10, 145, 171);
            dataGridView1.DefaultCellStyle.Font = new Font("MS Sans Serif", 8, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            btnExit.FlatAppearance.MouseDownBackColor = btnExit.BackColor;
            btnExit.BackColorChanged += (s, e) => {
                btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            };
        }

        private void toltes()
        {
                StreamReader file = new StreamReader("Score.txt", Encoding.UTF8);
                //n sor amiben a jelenlegi felhasznalo van
                int n = 0;
                while (!file.EndOfStream)
                {
                    string sor = file.ReadLine();
                    string[] adatok = sor.Split(';');
                    dataGridView1.Rows.Add(adatok[0], adatok[1], adatok[2], adatok[3], adatok[4], adatok[5], adatok[6],adatok[7]);
                if (Form1.User.Nev == adatok[0])
                    dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 69);
                    n++;
                }
                file.Close();

         

        }

        private void Leaderboard_Load(object sender, EventArgs e)
        {
            toltes();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
