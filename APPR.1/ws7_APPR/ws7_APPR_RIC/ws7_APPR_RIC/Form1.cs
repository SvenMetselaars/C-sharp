using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ws7_APPR_RIC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnError_Click(object sender, EventArgs e)
        {
            scrolltocaret();

            rtbLogging.SelectionColor = Color.Red;
            rtbLogging.AppendText("this could be error info" + "\n");
        }

        private void btnWarning_Click(object sender, EventArgs e)
        {
            scrolltocaret();
            rtbLogging.SelectionColor = Color.Orange;
            rtbLogging.AppendText("this could be warning info" + "\n");
        }

        private void btnAllok_Click(object sender, EventArgs e)
        {
            scrolltocaret();
            rtbLogging.SelectionColor = Color.Green;
            rtbLogging.AppendText("this could be ok info" + "\n");
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            scrolltocaret();
            rtbLogging.SelectionColor = Color.Blue;
            rtbLogging.AppendText("created bij pattje72" + "\n");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbLogging.Clear();

            scrolltocaret();
            rtbLogging.SelectionColor = Color.Black;
            rtbLogging.AppendText("logging cleared" + "\n");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "richtextlogging";
        }

        private void scrolltocaret()
        {
            if(checkBox1.Checked == true)
            {
                rtbLogging.ScrollToCaret();
            }
        }
    }
}
