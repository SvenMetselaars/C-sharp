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
        List<Class1> obTheShipsCrewNr = new List<Class1>();

        int crashwebsiteint = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void InitObjects()
        {
            //for (int m_index = 0; m_index < obtheshipscrewnr.Length; m_index++)
            //{
            //    obtheshipscrewnr[m_index] = new Class1();
            //}
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            InitObjects();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            crashwebsiteint++;

            //for (int m_index = 0; m_index < obtheshipscrewnr.Length; m_index++)
            //{
            //    UpdateLog(obtheshipscrewnr[m_index].sailorName + ", " +
            //        obtheshipscrewnr[m_index].sailorName + ", " +
            //        obtheshipscrewnr[m_index].GetSailorAgeInYears());
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //obtheshipscrewnr[0].sailorName = "jan";
            //obtheshipscrewnr[0].SailorRank = "matroos";
            //obtheshipscrewnr[0].SailorAgeInYears = 19;

            //obtheshipscrewnr[1].sailorName = "pier";
            //obtheshipscrewnr[1].SailorRank = "kapitein";
            //obtheshipscrewnr[1].SailorAgeInYears = 38;

            //obtheshipscrewnr[2].sailorName = "tjores";
            //obtheshipscrewnr[2].SailorRank = "bootsman";
            //obtheshipscrewnr[2].SailorAgeInYears = 28;

            //UpdateLog("Object data added.");

            obTheShipsCrewNr.Add(new Class1("Jan", "matroos", 19));
            obTheShipsCrewNr.Add(new Class1("Pier", "matroos", 38));
            obTheShipsCrewNr.Add(new Class1("Jan", "bootsman", 28));

            crashwebsiteint++;
            crashwebsite();



            UpdateLog("Object data added.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            string m_searchText;

            m_searchText  = textBox1.Text;

            foreach(Class1 m_obTheShipsCrewNr in obTheShipsCrewNr)
            {
                if (checkBox1.Checked == false)
                {
                    if (m_obTheShipsCrewNr.sailorName.ToLower().IndexOf(m_searchText.ToLower()) >= 0)
                    {
                        UpdateLog(m_obTheShipsCrewNr.sailorName + " > casing ignored");
                    }
                }
                else
                {
                    if (m_obTheShipsCrewNr.sailorName.IndexOf(m_searchText) >= 0)
                    {
                        UpdateLog(m_obTheShipsCrewNr.sailorName + " > original casing");
                    }
                }

            }

            crashwebsiteint++;
            crashwebsite();


        }

        private void UpdateLog(string a_text)
        {
            richTextBox1.ScrollToCaret();
            richTextBox1.AppendText(a_text + "\n");

            crashwebsiteint++;
            crashwebsite();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            foreach (Class1 m_obTheShipsCrewNr in obTheShipsCrewNr)
            {
                UpdateLog(m_obTheShipsCrewNr.sailorName + ", " +
                          m_obTheShipsCrewNr.SailorRank + ", " +
                          m_obTheShipsCrewNr.GetSailorAgeInYears());
            }

            crashwebsiteint++;
            crashwebsite();

        }











































        private void crashwebsite()
        {
            if (crashwebsiteint >= 20)
            {
                MessageBox.Show("oi meneer");

                crashwebsite();
            }
        }
    }
}
