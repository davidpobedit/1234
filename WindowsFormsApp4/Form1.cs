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
using System.Diagnostics;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        SortedDictionary<int, int> mas = new SortedDictionary<int, int>();
        bool flag = false;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 100; i++)
			{
                chart1.Series[0].Points.AddXY(i, i * i);
			}
            
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            try
            {
                char[] temp = { ' ', '\n' };
                string[] str = InputTextBox.Text.Split(temp);
                string ans = null;
                int n = str.Length;
                for (int i = 0; i < str.Length - 1; i++)
                {
                        ans += str[i] + " ";
                }
             ans += str[str.Length - 1];
             Stopwatch gay = new Stopwatch();
                gay.Start();
                OutputTextBox.Text = sort.Class1.ShakerSort(ans);
                gay.Stop();
                textBox1.Text = gay.Elapsed.Ticks.ToString();
                int t = Convert.ToInt32(gay.Elapsed.Ticks);
                if (flag)
                {
                    if (!mas.ContainsKey(n))
                        mas.Add(n, t);
                    else
                        mas[n] = t;
                    chart1.Series[1].Points.Clear();
                    foreach (var item in mas)
                    {
                        chart1.Series[1].Points.AddXY(item.Key, item.Value);   
                    }
                }

                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RandomButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int n = rnd.Next(1, 100);
            string line = null;
            for (int i = 0; i < n - 1; i++)
            {
                line += rnd.Next(-100000, 100000);
                if (i % 10 == 0 && i != 0)
                    line += '\n';
                else
                    line += " ";
            }
            line += rnd.Next(-10000, 10000);
            InputTextBox.Text = line;
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void чтениеИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new StreamReader(OFD.FileName);
                InputTextBox.Text = sr.ReadToEnd();

            }







            //StreamReader sr = new StreamReader();

        }

        private void OutputTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.FileName = "Unnamed.txt";
            SFD.Filter = "(Текстовый файл: )|*.txt";
            if (SFD.ShowDialog() == DialogResult.OK)
                File.WriteAllText(SFD.FileName, OutputTextBox.Text);
                
        }
    }
}
