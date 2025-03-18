using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
      
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            long seed = Convert.ToInt64(Seed.Text);
            long increment = Convert.ToInt64(Increment.Text);
            long multiplier = Convert.ToInt64(Multiplier.Text);
            long moduls = Convert.ToInt64(Moduls.Text);
            long iter = Convert.ToInt64(Iterations.Text);
            Generator RandomNumber = new Generator(seed,multiplier,increment,moduls);
            Seed.Text = "";
            Increment.Text = "";
            Multiplier.Text = "";
            Moduls.Text = "";
            Iterations.Text = "";
            DataTable table = new DataTable();
            table.Columns.Add("Random Numbers", typeof(long));
            for (int i = 0; i < iter; i++)
            {
                table.Rows.Add(RandomNumber.Next());
            }
            dataGridView1.DataSource = table;
            Period.Text = Convert.ToString(RandomNumber.CycleLength());
        }
    }
}
