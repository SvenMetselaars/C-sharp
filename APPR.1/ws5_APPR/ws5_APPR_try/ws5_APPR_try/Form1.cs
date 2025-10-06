using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ws5_APPR_try
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btndays_Click(object sender, EventArgs e)
        {
            double m_ageyears = 0;
            double m_agedays = 0;
            
            try
            {
                m_ageyears = Convert.ToDouble(textBox1.Text);
                m_agedays = m_ageyears * 365;
                lbldays.Text = m_agedays.ToString();
            }
            catch 
            {
                MessageBox.Show("ERROR, please dont use letters!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "to day converter";
        }
    }
}
