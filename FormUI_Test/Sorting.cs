using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FormUI_Test
{
    public partial class Sorting : Form
    {
        public Sorting()
        {
            InitializeComponent();

            button2.Enabled = false;

            chart1.ChartAreas["ChartArea1"].BackColor = Color.FromArgb(10, 145, 171);
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;

            btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            btnExit.FlatAppearance.MouseDownBackColor = btnExit.BackColor;
            btnExit.BackColorChanged += (s, e) => {
                btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            };
        }
        int oszlopszam;
        List<int> ertekek = new List<int>();
        Random rnd = new Random();
        int tDelay;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            button2.Enabled = true;
            ertekek.Clear();
            label1.Text = "Size: " + trackBar1.Value;
            oszlopszam = trackBar1.Value;
            chart1.Series["s1"].Points.Clear();
            for (int i = 0; i < oszlopszam; i++)
            {
                int x = rnd.Next(1, 50);
                ertekek.Add(x);
                chart1.Series["s1"].Points.AddXY(i, x);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bubbleSort();
        }
        private async void bubbleSort()
        {
            int temp;
            for (int i = 0; i < ertekek.Count - 1; i++)
            {
                for (int j = 0; j < ertekek.Count - 1; j++)
                {
                    if (ertekek[j] > ertekek[j + 1])
                    {
                        temp = ertekek[j + 1];
                        ertekek[j + 1] = ertekek[j];
                        ertekek[j] = temp;
                        chart1.Series["s1"].Points.Clear();
                        for (int k = 0; k < ertekek.Count; k++)
                        {
                            chart1.Series["s1"].Points.AddXY(k, ertekek[k]);
                        }
                        await Task.Delay(tDelay);
                    }
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            selectionSort();
            
            chart1.Series["s1"].Points.Clear();
            for (int k = 0; k < ertekek.Count; k++)
            {
                chart1.Series["s1"].Points.AddXY(k, ertekek[k]);
            }
        }
        private async void selectionSort()
        {
            for (var i = 0; i < ertekek.Count; i++)
            {
                var min = i;
                for (var j = i + 1; j < ertekek.Count; j++)
                {
                    if (ertekek[min] > ertekek[j])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    var lowerValue = ertekek[min];
                    ertekek[min] = ertekek[i];
                    ertekek[i] = lowerValue;
                }
                chart1.Series["s1"].Points.Clear();
                for (int k = 0; k < ertekek.Count; k++)
                {
                    chart1.Series["s1"].Points.AddXY(k, ertekek[k]);
                }
                await Task.Delay(tDelay);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            heapSortNow();

            chart1.Series["s1"].Points.Clear();
            for (int i = 0; i < oszlopszam; i++)
            {
                chart1.Series["s1"].Points.AddXY(i, ertekek[i]);
            }
        }

        private async void heapSortNow()
        {
            int iValue;

            for (int i = oszlopszam / 2; i >= 0; i--)
            {

                adjust(i, oszlopszam - 1);
                chart1.Series["s1"].Points.Clear();
                for (int h = 0; h < oszlopszam; h++)
                {
                    chart1.Series["s1"].Points.AddXY(h, ertekek[h]);

                }
                await Task.Delay(tDelay);
            }

            for (int i = oszlopszam - 2; i >= 0; i--)
            {
                iValue = ertekek[i + 1];
                ertekek[i + 1] = ertekek[0];
                ertekek[0] = iValue;
                adjust(0, i);
                chart1.Series["s1"].Points.Clear();
                for (int h = 0; h < oszlopszam; h++)
                {
                    chart1.Series["s1"].Points.AddXY(h, ertekek[h]);

                }
                await Task.Delay(tDelay);

            }
        }

        private void adjust(int i, int n)
        {
            int iPosition;
            int iChange;

            iPosition = ertekek[i];
            iChange = 2 * i;
            while (iChange <= n)
            {
                if (iChange < n && ertekek[iChange] < ertekek[iChange + 1])
                {
                    iChange++;
                }
                if (iPosition >= ertekek[iChange])
                {
                    break;
                }
                ertekek[iChange / 2] = ertekek[iChange];
                iChange *= 2;
            }
            ertekek[iChange / 2] = iPosition;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Speed: " + trackBar2.Value + "ms";
            tDelay = trackBar2.Value;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            chart1.Series["s1"].Points.Clear();
            this.Close();
        }

        private void Sorting_Load(object sender, EventArgs e)
        {
            
        }
    }
}
