using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ws6_APPR_up
{
    public partial class Form1 : Form
    {
        int startvalue = 0;
        int actualvalue = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "going up and down";
            textBox1.Text = Convert.ToString(startvalue);
        }

        private void btnkies_Click(object sender, EventArgs e)
        {
            startvalue = Convert.ToInt32(textBox1.Text);
            actualvalue = startvalue;
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            actualvalue--;
            lblspel.Text = actualvalue.ToString();
        }

        private void btnplus_Click(object sender, EventArgs e)
        {
            actualvalue++;
            lblspel.Text = actualvalue.ToString();
        }
    }
}
