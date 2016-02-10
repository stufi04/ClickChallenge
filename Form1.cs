using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Select();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button b = (Button) sender;
            int x = Convert.ToInt32(b.Tag);
            Form2 f = new Form2(x);
            f.Show();
            this.Hide();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click Challenge version 1.9 is created by Elitsa Bankova and Stefan Ivanov. All rights reserved 2013"); 
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click on all the colored squares in the time given. Red, blue, green and yellow boxes are clicked once. Double click boxes of other colors. Choose level of difficulty to play.");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
