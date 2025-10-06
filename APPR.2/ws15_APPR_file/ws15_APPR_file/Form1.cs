using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;

namespace ws15_APPR_file
{
    public partial class Form1 : Form
    {
        csSubscriptionForm obMemberOne = new csSubscriptionForm(0, "Jan", "Rotterdam", "Kapitein");

        string relativeFileDirectory = "";
        string storedFileName = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            relativeFileDirectory = Application.StartupPath + "\\..\\..\\doc\\";

            this.Text = "FileHandling with members class";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(obMemberOne.MemberNr.ToString() + ";" +
                                    obMemberOne.memberName + ";" +
                                    obMemberOne.memberCity + ";" +
                                    obMemberOne.memberOccupation + ";\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            diaFileSave.FileName = "test.txt";
            diaFileSave.Filter = "Text file"
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

    }
}
