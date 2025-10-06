using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ws4_APPR_cal
{
    public partial class Form1 : Form
    {
        double value1Dkal = 0;
        double value2Dkal = 0;
        double resultDkal = 0;
        public Form1()
        {
            InitializeComponent();

            this.Text = "calculator";

            this.CenterToScreen();

            this.Width = 155; 
            this.Height = 165;
        }

        private void btnplus_Click(object sender, EventArgs e)
        {
            value1Dkal = Convert.ToDouble(tbx1.Text);
            value2Dkal = Convert.ToDouble(tbx2.Text);

            resultDkal = value1Dkal + value2Dkal;

            lblanser.Text = Convert.ToString(resultDkal);
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            value1Dkal = Convert.ToDouble(tbx1.Text);
            value2Dkal = Convert.ToDouble(tbx2.Text);

            resultDkal = value1Dkal - value2Dkal;

            lblanser.Text = Convert.ToString(resultDkal);
        }

        private void btnkeer_Click(object sender, EventArgs e)
        {
            value1Dkal = Convert.ToDouble(tbx1.Text);
            value2Dkal = Convert.ToDouble(tbx2.Text);

            resultDkal = value1Dkal * value2Dkal;

            lblanser.Text = Convert.ToString(resultDkal);
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
            value1Dkal = Convert.ToDouble(tbx1.Text);
            value2Dkal = Convert.ToDouble(tbx2.Text);

            resultDkal = value1Dkal / value2Dkal;

            lblanser.Text = Convert.ToString(resultDkal);
        }
    }
}
