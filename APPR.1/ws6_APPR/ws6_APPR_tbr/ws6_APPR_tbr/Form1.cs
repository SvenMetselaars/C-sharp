using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ws6_APPR_tbr
{
    public partial class Form1 : Form
    {
        int maxvalue = 0;
        int actualvalue = 0;
        int absolutedistance = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;
            MessageBox.Show("idk what to say goodbye");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                maxvalue = Convert.ToInt32(textBox1.Text);

                SetLimit();
            }
            catch
            {
                if (DialogResult.OK == MessageBox.Show("not valid value. do you want standard one?"))
                {
                    maxvalue = 11;
                    textBox1.Text = maxvalue.ToString();
                    SetLimit();
                }
            }

        }
        private void SetLimit()
        {
            trackBar1.Maximum = maxvalue;
            label11.Text = maxvalue.ToString();
            progressBar1.Maximum = maxvalue * 2;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            actualvalue = actualvalue + 1;
            updateview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            actualvalue = actualvalue - 1;
            updateview();
        }
        private void updateview()
        {
            label10.ForeColor = Color.Black;
            if (actualvalue == trackBar1.Maximum)
            {
                trackBar1.Value = actualvalue;
                label10.Text = "touch down";
                label10.ForeColor = Color.Green;
            }
            else if (actualvalue > trackBar1.Maximum)
            {
                trackBar1.Value = trackBar1.Maximum - (actualvalue - trackBar1.Maximum);
                if (trackBar1.Value == 0)
                {
                    label10.Text = "warning";
                    MessageBox.Show("dont increase the value!");
                }
                else
                {
                    label10.Text = "higher";
                }
            }
            else if ( actualvalue < trackBar1.Minimum)
            {
                if (trackBar1.Value == 0)
                {
                    label10.Text = "warning";
                    MessageBox.Show("dont increase the value!");
                }
                else
                {
                    label10.Text = "higher";
                }
            }
            else 
            {
                trackBar1.Value = actualvalue;
                label10.Text = "lower";
            }
            absolutedistance = trackBar1.Maximum - trackBar1.Value;
            label4.Text = absolutedistance.ToString();

            progressBar1.Value = actualvalue;
            label3.Text = actualvalue.ToString();
        }
    }
}
