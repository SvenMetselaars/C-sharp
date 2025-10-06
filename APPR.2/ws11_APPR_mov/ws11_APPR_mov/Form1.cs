using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ws11_APPR_mov
{
    public partial class Form1 : Form
    {
        Random GenerateRandomValue = new Random();
        int timeinterval3 = 100;
        int timeinterval2 = 25;
        int timeinterval = 100;
        int racingtime = 0;
        int racingtime2 = 0;
        int racerposition = 7;
        int racerposition2 = 7;
        bool racerresset = false;
        bool racerfinished = false;
        bool racerfinished2 = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "moving pictures";
            resetracer();
            updatevieuw();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                timeinterval3 = GenerateRandomValue.Next(timeinterval2);
                textBox2.Text = timeinterval3.ToString();
                tmrmain2.Interval = timeinterval3;

                timeinterval = GenerateRandomValue.Next(timeinterval2);
                textBox1.Text= timeinterval.ToString();
                tmrmain.Interval = timeinterval;

                if(timeinterval3 == 0)
                {
                    timeinterval3 = 10;
                }
                else if (timeinterval == 0)
                {
                    timeinterval = 10;
                }

                if(racerresset == false)
                {
                    MessageBox.Show("please reset the racer first");
                }
                else
                {
                    if(timeinterval > 100 && timeinterval3 > 100)
                    {
                        MessageBox.Show("please use a higher value");
                    }
                    else
                    {
                        tmrmain.Enabled = true;
                        tmrmain2.Enabled = true;
                    }
                    
                }
            }
            catch 
            {
                MessageBox.Show("please only use numbers");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetracer();

            updatevieuw();
        }
        void resetracer()
        {
            racerresset = true; 
            racerfinished = false;
            racerfinished2 = false;
            racingtime = 0;
            racingtime2 = 0;
            racerposition = 7;
            racerposition2 = 7;
        }
        void updatevieuw()
        {
            label6.Text = racerfinished.ToString();
            label2.Text = racingtime.ToString();
            label4.Text = racerposition.ToString();
            label7.Text = racerposition2.ToString();
            label8.Text = racingtime2.ToString();

            pictureBox1.Left = racerposition;
            pictureBox2.Left = racerposition2;
        }
        private void tmrmain2_Tick(object sender, EventArgs e)
        {
            interval2();

            tmrmain2.Interval = timeinterval3;
            if (racingtime == 200)
            {

                timeinterval3 = GenerateRandomValue.Next(timeinterval2);
                interval2();
                textBox2.Text = timeinterval3.ToString();
                tmrmain2.Interval = timeinterval3;
            }
            else if (racingtime == 400)
            {

                timeinterval3 = GenerateRandomValue.Next(timeinterval2);
                interval2();
                textBox2.Text = timeinterval3.ToString();
                tmrmain2.Interval = timeinterval3;

            }
            else if (racingtime == 600)
            {

                timeinterval3 = GenerateRandomValue.Next(timeinterval2);
                interval2();
                textBox2.Text = timeinterval3.ToString();
                tmrmain2.Interval = timeinterval3;

            }
            else if (racingtime == 800)
            {

                timeinterval3 = GenerateRandomValue.Next(timeinterval2);
                interval2();
                textBox2.Text = timeinterval3.ToString();
                tmrmain2.Interval = timeinterval3;

            }
            racingtime2++;
            racerposition2++;

            if (racerposition2 > panel5.Left + 5)
            {
                racerfinished2 = true;
                racerresset = false;
                tmrmain2.Enabled = false;

                if (racerfinished2 = true && racerfinished == false)
                {
                    label10.Left = 1085;
                    label10.Top = 403;
                    label10.Visible = true;
                }
                else if (racerfinished2 = true && racerfinished == true)
                {
                    label11.Left = 1085;
                    label11.Top = 403;
                    label11.Visible = true;
                }
            }
            updatevieuw();

        }
        private void tmrmain_Tick(object sender, EventArgs e)
        {
            interval();
            tmrmain.Interval = timeinterval;
            if (racingtime == 200)
            {

                timeinterval = GenerateRandomValue.Next(timeinterval2);
                interval();
                if (timeinterval < 1)
                {
                    timeinterval = 10;
                }
                textBox1.Text = timeinterval.ToString();
                tmrmain.Interval = timeinterval;


            }
            else if (racingtime == 400)
            {

                timeinterval = GenerateRandomValue.Next(timeinterval2);
                interval();
                if (timeinterval < 1)
                {
                    timeinterval = 10;
                }
                textBox1.Text = timeinterval.ToString();
                tmrmain.Interval = timeinterval;


            }
            else if (racingtime == 600)
            {

                timeinterval = GenerateRandomValue.Next(timeinterval2);
                interval();
                if (timeinterval < 1)
                {
                    timeinterval = 10;
                }
                textBox1.Text = timeinterval.ToString();
                tmrmain.Interval = timeinterval;


            }
            else if (racingtime == 800)
            {
                timeinterval = GenerateRandomValue.Next(timeinterval2);
                interval();
                if (timeinterval < 1)
                {
                    timeinterval = 10;
                }
                textBox1.Text = timeinterval.ToString();
                tmrmain.Interval = timeinterval;
            }

                racerposition++;
                racingtime++;

                if (racerposition > panel3.Left + 5)
                {
                    racerfinished = true;
                    racerresset = false;
                    tmrmain.Enabled = false;


                    if (racerfinished = true && racerfinished2 == false)
                    {
                        label10.Left = 1085;
                        label10.Top = 189;
                        label10.Visible = true;
                    }
                    else if (racerfinished2 = true && racerfinished == true)
                    {
                        label11.Left = 1085;
                        label11.Top = 189;
                        label11.Visible = true;
                    }
                }
                updatevieuw();
            
            
        }
        private void interval()
        {
            if (timeinterval < 1)
            {
                timeinterval = 10;
                textBox1.Text = timeinterval.ToString();
                tmrmain.Interval = timeinterval;
            }
        }
        private void interval2()
        {
            if (timeinterval3 < 1)
            {
                timeinterval3 = 10;
                textBox2.Text = timeinterval3.ToString();
                tmrmain2.Interval = timeinterval3;
            }
        }
    }
}
