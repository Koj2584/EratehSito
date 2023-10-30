using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prvocislo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool PrimeNumber(int x)
        {
            bool b = !(x == 0 || x == 1) && !(x%2==0 && x!=2) && x>0;
            for(int i = 3; i < Math.Sqrt(x) && b; i += 2)
                b = x%i!=0;
            return b;
        }

        List<int> Erath(int n)
        {
            if (n >= 2)
            {
                List<int> list = new List<int>();
                list.Add(2);
                for (int i = 3; i <= n; i++)
                {
                    bool prvocislo = true;
                    for (int x = 0; x < list.Count && prvocislo; x++)
                    {
                        if (i % list[x] == 0)
                            prvocislo = false;
                    }
                    if (prvocislo)
                        list.Add(i);
                }
                return list;
            }
            else
                return new List<int>();
        }

        Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                int n = int.Parse(textBox1.Text);
                List<int> prvocisla = Erath(n);
                foreach(int x in prvocisla)
                {
                    listBox1.Items.Add(x);
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Špatná hodnota "+ex);
            }
        }
    }
}
