using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace abstract_classes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt16(textBox1.Text);
            NasPunkt[] a = new NasPunkt[n * 2];
            double max = 0;
            for (int i = 0; i < 2 * n; i = i + 2)
            {
                a[i] = new Selo(i + 1, i + 15);
                a[i + 1] = new Misto(i + 2, i + 25);

            }
            dataGridView1.Rows.Clear();
            foreach (NasPunkt el in a)
            {
                el.Show(dataGridView1);
                if (max < el.S())
                {
                    max = el.S();
                }
            }
            label2.Text = "max population density: " + max.ToString();

        }
        abstract class NasPunkt
        {
            public string naz;
            public double pl;


            public abstract void Show(DataGridView dg);

            public abstract double S();


        }


        class Selo : NasPunkt
        {
            private int AmountOfHouses;
            private int AmountOfPeopleInHouses;
            public Selo(int xn, int xk)
            {
                Random ran = new Random();
                AmountOfHouses = ran.Next(xk * 10, xk * 25);
                AmountOfPeopleInHouses = ran.Next(xn, xk);
                pl = ran.Next(xn * 5, xk * 2);
                naz = "Village";
            }
            public override double S()
            {
                double sch;
                sch = AmountOfHouses * AmountOfPeopleInHouses / pl;
                return sch;
            }
            public override void Show(DataGridView dg)
            {

                dg.Rows.Add("Name", naz);
                dg.Rows.Add("Square", pl);
                dg.Rows.Add("Amount of houses", AmountOfHouses);
                dg.Rows.Add("Amount of people in houses", AmountOfPeopleInHouses);
                dg.Rows.Add("Population density", S());
            }
        }

        class Misto : NasPunkt
        {
            private int AmountOfPeople;
            Random ran = new Random();
            public Misto(int xn, int xk)
            {
                AmountOfPeople = ran.Next(xn * 3333, xk * 5000);
                pl = ran.Next(xn, xk);
                naz = "Misto";
            }
            public override double S()
            {
                double s;
                s = AmountOfPeople / pl;
                return s;
            }
            public override void Show(DataGridView dg)
            {

                dg.Rows.Add("Name", naz);
                dg.Rows.Add("Square", pl);
                dg.Rows.Add("Amount of people", AmountOfPeople.ToString());
                dg.Rows.Add("Population density", S());
            }

        }
    }
}
