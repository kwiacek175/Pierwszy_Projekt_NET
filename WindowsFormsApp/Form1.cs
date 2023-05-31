using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab1_NET;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);
            Knapsack knapsack = new Knapsack(n);
            int cap = int.Parse(textBox2.Text);
            Problem problem = new Problem(cap, knapsack);
            label1.Text = problem.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
