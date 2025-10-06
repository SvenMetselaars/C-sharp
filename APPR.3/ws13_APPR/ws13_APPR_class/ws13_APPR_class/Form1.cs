using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ws13_APPR_class
{
    public partial class Form1 : Form
    {
        Class1[] obtheshipscrewnr = new Class1[4];

        int crashwebsiteint = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void InitObjects()
        {
            for (int m_index = 0; m_index< obtheshipscrewnr.Length; m_index++)
            {
                obtheshipscrewnr[m_index] = new Class1();
            }
        }
        












































        private void crashwebsite()
        {
            if (crashwebsiteint == 100) 
            {
                MessageBox.Show("oi meneer");

                crashwebsite();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitObjects();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            for (int m_index = 0; m_index < obtheshipscrewnr.Length; m_index++)
            {
                UpdateLog(obtheshipscrewnr[m_index].sailorName + ", " +
                    obtheshipscrewnr[m_index].sailorName + ", " +
                    obtheshipscrewnr[m_index].GetSailorAgeInYears());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            obtheshipscrewnr[0].sailorName = "jan";
            obtheshipscrewnr[0].SailorRank = "matroos";
            obtheshipscrewnr[0].SailorAgeInYears = 19;

            obtheshipscrewnr[1].sailorName = "pier";
            obtheshipscrewnr[1].SailorRank = "kapitein";
            obtheshipscrewnr[1].SailorAgeInYears = 38;

            obtheshipscrewnr[2].sailorName = "tjores";
            obtheshipscrewnr[2].SailorRank = "bootsman";
            obtheshipscrewnr[2].SailorAgeInYears = 28;

            UpdateLog("Object data added.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            for (int m_index = 0; m_index < obtheshipscrewnr.Length; m_index++)
            {
                if (obtheshipscrewnr[m_index].sailorName.IndexOf(textBox1.Text) >= 0)
                {
                    UpdateLog(obtheshipscrewnr[m_index].sailorName);
                }
            }
        }

        private void UpdateLog(string a_text)
        {
            richTextBox1.ScrollToCaret();
            richTextBox1.AppendText(a_text + "\n");
        }
    }
}
