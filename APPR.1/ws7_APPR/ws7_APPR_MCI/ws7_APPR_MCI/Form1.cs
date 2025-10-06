using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ws7_APPR_MCI
{
    public partial class Form1 : Form
    {
        [DllImport("winmm.dll")]

        private static extern int mciSendString(string strCommand, StringBuilder strReturn, int iReturnLenght, IntPtr hwndCalling);

        bool audioIsGestopt;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "The Sound";
        }
        private void btnMoof_Click(object sender, EventArgs e)
        {
            stopAudio();
            playMoof();
        }

        private void btnTemple_Click(object sender, EventArgs e)
        {
            stopAudio();
            playTemple();
        }

        private void playTemple()
        {
            if (cbxSound.Checked == false)
            {
                string m_location;

                if (audioIsGestopt == false)
                {
                    UpdateInformation("AUDIO IS NOG NIET GESTOPT!!\n");
                }

                m_location = Application.StartupPath;

                m_location = m_location + "\\..\\..\\snd\\temple.aiff";

                UpdateInformation("plaats van het geluidje:\n");
                UpdateInformation(m_location + "\n");

                mciSendString("open \"" + m_location + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);

                mciSendString("play MediaFile", null, 0, IntPtr.Zero);

                audioIsGestopt = false;
            }
        }

        private void stopAudio()
        {
            if (cbxSound.Checked == false)
            {
                UpdateInformation("stop Audio!\n");

                mciSendString("close MediaFile", null, 0, IntPtr.Zero);

                audioIsGestopt = true;
            }        
        }

        private void playMoof()
        {
            if (cbxSound.Checked == false)
            {
                string m_location;

                if (cbxSound.Checked == false)
                {
                    UpdateInformation("AUDIO IS NOG NIET GESTOPT!!\n");
                }

                m_location = Application.StartupPath;

                m_location = m_location + "\\..\\..\\snd\\moof.aiff";

                UpdateInformation("plaats van het geluidje:\n");
                UpdateInformation(m_location + "\n");

                mciSendString("open \"" + m_location + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);

                mciSendString("play Mediafile", null, 0 , IntPtr.Zero);

                audioIsGestopt = false;
            }
        }

        private void UpdateInformation (string a_info)
        {
            rtbLogging.AppendText(a_info);
            rtbLogging.ScrollToCaret();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbLogging.Clear();
        }

        private void cbxWrapText_CheckedChanged(object sender, EventArgs e)
        {
            rtbLogging.WordWrap = cbxWrapText.Checked;
        }
    }
}
