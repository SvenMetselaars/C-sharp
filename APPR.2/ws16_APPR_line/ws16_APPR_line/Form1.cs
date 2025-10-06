using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ws16_APPR_line
{
    public partial class Form1 : Form
    {
        int xNewPos;
        int yNewPos;
        int xPreviousPos;
        int yPreviousPos;

        int xToPos;
        int yToPos;
        int xFromPos;
        int yFromPos;

        Random CreateRandomValue = new Random();
        int randomValue;

        System.Drawing.Pen DrawingPen = new System.Drawing.Pen(System.Drawing.Color.DarkBlue, 0.1f);
        System.Drawing.Graphics formGraphics;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "drawingLines";
            InitGraph();
            InitGlobals();
        }

        private void InitGraph()
        {
            formGraphics = panel1.CreateGraphics();
            DrawingPen.Width = 1;
        }
        
        private void InitGlobals()
        {
            xNewPos = panel1.Left;
            yNewPos = panel1.Height;
            xPreviousPos = panel1.Left;
            yPreviousPos = panel1.Height;
        }

        private void DrawGraphHorizontally()
        {
            if (xToPos < panel1.Width - 10)
            {
                randomValue = CreateRandomValue.Next(-1, panel1.Height);

                xToPos = xToPos + 1;
                yToPos = randomValue;

                formGraphics.DrawLine(DrawingPen, xFromPos, yFromPos, xToPos, yToPos);

                xFromPos = xFromPos + 1;
                yFromPos = randomValue;
            }
            else
            {
                label2.Text = "the end...";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            label2.Text = "running...";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawGraphHorizontally();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            string m_x;
            string m_y;

            m_x = Convert.ToString(Cursor.Position.X - this.Left - 17);
            m_y = Convert.ToString(Cursor.Position.Y - this.Top - 41);

            label4.Text = m_x;
            label6.Text = m_y;
        }
    }
}
