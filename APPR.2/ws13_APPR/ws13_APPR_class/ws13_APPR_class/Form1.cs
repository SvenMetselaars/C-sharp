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
        Class1 obJan = new Class1();
        Class1 obPier = new Class1();
        Class1 obTjoress = new Class1();

        int crashwebsiteint = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == obJan.sailorName)
            {
                updateLog(obJan.sailorName + " > " + obJan.SailorRank + " > " + obJan.GetSailorAgeInYears());
            }
            else if(textBox1.Text == obPier.sailorName)
            {
                updateLog(obPier.sailorName + " > " + obPier.SailorRank + " > " + obPier.GetSailorAgeInYears());
            }
            else if (textBox1.Text == obTjoress.sailorName)
            {
                updateLog(obTjoress.sailorName + " > " + obTjoress.SailorRank + " > " + obTjoress.GetSailorAgeInYears());
            }
            else
            {
                updateLog("Error: name not as object available!!!1!!1");
            }

            crashwebsiteint++;
            crashwebsite();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateLog(obJan.sailorName + " > " + obJan.SailorRank + " > " + obJan.GetSailorAgeInYears());
            updateLog(obPier.sailorName + " > " + obPier.SailorRank + " > " + obPier.GetSailorAgeInYears());
            updateLog(obTjoress.sailorName + " > " + obTjoress.SailorRank + " > " + obTjoress.GetSailorAgeInYears());
            crashwebsiteint++;
            crashwebsite();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            obJan.sailorName = "Jan";
            obJan.SailorRank = "matroos";
            obJan.SailorAgeInYears = 18;

            obPier.sailorName = "jack sparow";
            obPier.SailorRank = "kapitein";
            obPier.SailorAgeInYears = 38;

            obTjoress.sailorName = "Tjores";
            obTjoress.SailorRank = "bootsman";
            obTjoress.SailorAgeInYears = 28;

            updateLog("Object data added.");
            crashwebsiteint++;
            crashwebsite();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            crashwebsiteint++;

            crashwebsite();
        }
        private void updateLog(string a_text)
        {
            richTextBox1.ScrollToCaret();
            richTextBox1.AppendText (a_text + "\n");
        }












































        private void crashwebsite()
        {
            if (crashwebsiteint == 100) 
            {
                MessageBox.Show("oi meneer");

                crashwebsite();
            }
        }
        
    }
}
