using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ws4_APPR_ran
{
    public partial class Form1 : Form
    {
        Random GenerateRandomValue = new Random();
        int maxValue = 0;
        int randomValue = 0;
        public Form1()
        {
            InitializeComponent();
            this.Text = "randomizer";
            this.CenterToScreen();
            this.Width = 150;
            this.Height = 125;
        }

        private void btnran_Click(object sender, EventArgs e)
        {
            maxValue = Convert.ToInt32(tbx.Text);
            randomValue = GenerateRandomValue.Next(maxValue);
            MessageBox.Show("the random value is: " + randomValue.ToString());
            lblvalue.Text = randomValue.ToString();

        }
    }
}
