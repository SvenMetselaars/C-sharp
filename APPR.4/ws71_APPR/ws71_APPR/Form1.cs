using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ws71_APPR
{
    public partial class Form1: Form
    {
        PictureBox pcbFrom = null;
        PictureBox pcbTo = null;

        Class1 fighterOne = null;
        Class1 fighterTwo = null;
        Class1 fighterThree = null;

        int correctAnswercount = 0;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            fighterOne = null;
            fighterTwo = null;
            fighterThree = null;

            foreach (PictureBox pcb in groupBox3.Controls.OfType<PictureBox>())
            {
                pcb.BackColor = Color.Transparent;
            }
            foreach (PictureBox pcb in GroupBox1.Controls.OfType<PictureBox>())
            {
                pcb.BackColor = Color.Transparent;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckCorrect(pictureBox4, fighterOne);
            CheckCorrect(pictureBox5, fighterTwo);
            CheckCorrect(pictureBox6, fighterThree);

            if (correctAnswercount == 0)
            {
                MessageBox.Show("To bad, you guessed nothing correct");
            }
            else if (correctAnswercount == 1 || correctAnswercount == 2)
            {
                MessageBox.Show("well done, you guessed " + correctAnswercount + " correct");
            }
            else
            {
                MessageBox.Show("very nice, you guesed them all right");
            }
            ResetGame();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pcbFrom = (PictureBox)sender;

            if (pcbFrom.BackColor == Color.Transparent)
            {
                foreach (PictureBox pcb in groupBox3.Controls.OfType<PictureBox>())
                {
                    if (pcb.Image == null)
                    {
                        pcb.BackColor = Color.Green;
                    }
                }
                pcbFrom.DoDragDrop(pcbFrom.Image, DragDropEffects.Copy);
            }
        }

        private void pictureBox9_DragDrop(object sender, DragEventArgs e)
        {
            pcbTo = (PictureBox)sender;
            Image getimage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            pcbTo.Image = getimage;

            if (pcbTo.Tag.ToString() == "1")
            {
                fighterOne = new Class1(pcbFrom.Name.Remove(0, 3));
                fighterOne.SetOnBoard(true, 1);
            }
            else if (pcbTo.Tag.ToString() == "2")
            {
                fighterTwo = new Class1(pcbFrom.Name.Remove(0, 3));
                fighterTwo.SetOnBoard(true, 2);
            }
            else if (pcbTo.Tag.ToString() == "3")
            {
                fighterThree = new Class1(pcbFrom.Name.Remove(0, 3));
                fighterThree.SetOnBoard(true, 3);
            }

            ClearBoardcolors();

            if (fighterOne != null && fighterTwo != null && fighterThree != null)
            {
                button2.Enabled = true;
            }
        }

        private void pictureBox9_DragOver(object sender, DragEventArgs e)
        {
            pcbTo = (PictureBox)sender;
            if (pcbTo.BackColor == Color.Green)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ResetGame()
        {
            correctAnswercount = 0;
            button2.Enabled = false;
            button1.Enabled = true;

            foreach (PictureBox pcb in groupBox3.Controls.OfType<PictureBox>())
            {
                pcb.BackColor = Color.Gray;
                pcb.Image = null;
                pcb.AllowDrop = true;
            }

            foreach(PictureBox pcb in groupBox2.Controls.OfType<PictureBox>())
            {
                pcb.BackColor = Color.Gray;
                pcb.Image = null;
            }

            foreach (PictureBox pcb in GroupBox1.Controls.OfType<PictureBox>())
            {
                pcb.BackColor = Color.Gray;
            }
        }

        private void ClearBoardcolors()
        {
            foreach (PictureBox pcb in groupBox3.Controls.OfType<PictureBox>())
            {
                pcb.BackColor = Color.Gray;
            }
        }

        private void CheckCorrect(PictureBox pcbToCheck, Class1 fighertToCheck)
        {
            int randomNumber = random.Next(1, 4);
            string randomName = "";

            if (randomNumber == 1)
            {
                randomName = "Rock";
            }
            else if (randomNumber == 2)
            {
                randomName = "Paper";
            }
            else if (randomNumber == 3)
            {
                randomName = "Scissor";
            }

            Bitmap bm = new Bitmap("C:\\Users\\svenm\\OneDrive - ROC Ter AA\\APPR.4\\ws71_APPR\\img\\" + randomName + ".png");
            pcbToCheck.Image = bm;

            if (randomName == fighertToCheck.GetName())
            {
                correctAnswercount++;
                pcbToCheck.BackColor = Color.LightGreen;
            }
            else
            {
                pcbToCheck.BackColor = Color.Red;
            }
        }
    }
}
