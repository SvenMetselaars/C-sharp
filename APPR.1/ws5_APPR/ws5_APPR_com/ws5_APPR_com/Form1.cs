using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ws5_APPR_com
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "select collor";
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeBackGroundColor();
        }
        private void ChangeBackGroundColor()
        {
            int m_SelectedIndex = 0;
            m_SelectedIndex = comboBox1.SelectedIndex;
            switch (m_SelectedIndex) 
            {

                case 0:
                    this.BackColor = Color.LightGray;
                    break;
                case 1:
                    this.BackColor = Color.Red;
                    break;
                case 2:
                    this.BackColor = Color.Green;
                    break;
                case 3: 
                    this.BackColor = Color.Blue;
                    break; 
                case 4:
                    this.BackColor = Color.Cyan;
                    break;
                case 5: 
                    this.BackColor = Color.Yellow;
                    break;
                case 6:
                    this.BackColor = Color.Magenta;
                    break;
                


                    //else

                    //this.BackColor = Color.Blue;
            }

        lblcollorplay.Text = this.BackColor.ToString();
            lblzero.Text = comboBox1.Text;
        }
}
}
