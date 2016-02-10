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
    public partial class Form2 : Form
    {
        int n, br=1, m, p;
        double totTime = 0;
        int pushedButtons = 0, totalPush=0;
        Form1 f = new Form1();
        int[] used = new int[128];
        Random r = new Random();
        Button[] B = new Button[128];
        Color[] C = { Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Pink, Color.Aqua, Color.Orange, Color.Purple };
        int cconst;
        public Form2(int x)
        {
            InitializeComponent();
            n = x;
            //m = x-2;
            if (n == 3 || n == 4) m = 1;
            else m = 2;
            if (x == 10) { n = 4; m = 3; cconst = r.Next(0, 4);}

            // making buttons and shit
            /*for (int i = 0; i <= 6; i++)
                used[i] = 0;
            c[0] = Color.LightGray;
            for (int i = 1; i <= m; i++) {
                int temp;
                while (1 == 1)
                {
                    temp= r.Next(0, 7);
                    if (used[temp] == 0) break;
                }
                used[temp] = 1;
                c[i] = C[temp];
            }*/
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Button b = new Button();
                    b.Parent = this;
                    b.Size = new System.Drawing.Size((8-n)*15,(8-n)*15);
                    b.Location = new System.Drawing.Point(30 + (i - 1) * (8 - n) * 17, 50 + (j - 1) * (8 - n) * 17);
                    b.Tag = 0;
                    b.BackColor = Color.LightGray;
                    B[(i - 1) * n + j] = b;
                    b.Click+=new EventHandler(Form2_Click);
                    this.Controls.Add(b);
                }
            }
            Size s = new Size(60 + n * (8 - n) * 17, 100 + n * (8 - n) * 17);
            this.Size = s;
            label1.Location = new System.Drawing.Point((s.Width-label1.Width)/2,(50-label1.Height)/2);
            label1.Select();
            play(1);
        }
        private void ending(int type)
        {
            timer1.Enabled = false;
            string s = "You ";
            if (type == 1) s += "win!";
            else
            {
                s += "lose! ";
                if (type == 2) s += "Be faster!";
                else s += "Watch where you click!";
            }
            s += "\r\nYour score is: " + (totalPush * 1000 + totTime * 100).ToString();
            MessageBox.Show(s);
            this.Close();
        }
        private void play (int k)
        {
             br = k;
             int num;
             for (int j = 1; j <= n * n; j++)
                 used[j] = 0;
             for (int j=1;j<=k;j++)
             {
                 while (1 == 1)
                 {
                     num = r.Next(1, n * n + 1);
                     if (used[num] == 0) { used[num] = 1; break; }
                 }
                 int randColor;
                 if (m == 1) randColor = r.Next(0, 4);
                 else randColor=r.Next(0,8);
                 if (m == 3)
                 {
                     if (randColor < 4) randColor = cconst;
                     else randColor = cconst+4;
                 }
                 B[num].BackColor = C[randColor];
                 B[num].Tag = randColor;
                 /*B[num].BackColor = c[m];*/

             }
             label1.Text = (1 + 0.2 * (k - 1)).ToString();
             timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double d;
            d = double.Parse(label1.Text);
            d=d*1000-timer1.Interval;
            label1.Text = (d / 1000).ToString();
            if (d == 0) ending(2);
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            label1.Select();
            if (sender is Button)
            {
                Button b = (Button)sender;
                if (b.BackColor==Color.LightGray) ending(3);
                else
                {
                    if ((int)b.Tag <= 3)
                    {
                        pushedButtons++;
                        totalPush++;
                    }
                    if ((int)b.Tag > 3) { b.BackColor = C[(int)b.Tag - 4]; b.Tag = (int)b.Tag - 4; }
                    else b.BackColor = Color.LightGray;
                    if (pushedButtons == br)
                    {
                        if (br < n * n) { pushedButtons = 0; totTime += double.Parse(label1.Text);play(br + 1); }
                        else ending(1);
                    }
                }
            }
            else ending(3);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f = new Form1(); 
            f.Show();
        }
    }
}
