using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace APPR_Shooting_Pictures_22SD_CasWesterlo
{
    public partial class Form1 : Form
    {
        bool racerResetted = false;
        bool racerFinished = false;
        bool racerStarted = false;
        int racingTime = 0;
        int racerPosition = 7;

        int speedUpSteps = 0;

        //game control
        string pressedKey = "";
        int flakVertPosition = 0;
        int flakHorizPosition = 0;
        public Form1()
        {
            InitializeComponent();

            tmrMain.Interval = trbTmrMainIntervalCwes.Value;

            speedUpSteps = Convert.ToInt32(nudSpeedUpCwes.Value);

            flakHorizPosition = pnlFlakBatteryCwes.Left - 20;
            flakVertPosition = pnlFlakBatteryCwes.Top;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Moving pictures";
        }
        private void btnStartCwes_Click(object sender, EventArgs e)
        {
            Random GenerateRandomTopPosition = new Random();

            if(racerResetted == true)
            {
                racerStarted = true;
                pbxRacerCwes.Top = GenerateRandomTopPosition.Next(pnlFlakBatteryCwes.Top, pnlFlakBatteryCwes.Top + pnlFlakBatteryCwes.Height - pbxRacerCwes.Height);
            }
            else
            {
                MessageBox.Show("Reset the racer first.", "ERROR");
            }
        }
        private void btnResetCwes_Click(object sender, EventArgs e)
        {
            ResetRacer();

            UpdateView();
        }
        void ResetRacer()
        {
            racerResetted = true;
            racerFinished = false;
            racerStarted = false;
            racingTime = 0;
            racerPosition = 7;
        }
        void UpdateView()
        {
            lblFinishedCwes.Text = racerFinished.ToString();
            lblRaceTimeCwes.Text = racingTime.ToString();
            lblRacerPositionCwes.Text = racerPosition.ToString();

            pbxRacerCwes.Left = racerPosition;
        }
        private void tmrMain_Tick(object sender, EventArgs e)
        {
            if(racerStarted == true)
            {
                racerPosition = racerPosition + speedUpSteps;
                racingTime++;

                if(racerPosition > pnlFinishLineCwes.Left + 5)
                {
                    racerFinished = true;
                    racerResetted = false;
                    tmrMain.Enabled = false;
                }
                if(cbxRefresh.Checked == true)
                {
                    Refresh();
                }

                UpdateView();
                HandleGameKeys();

                //use the return boolean to make the racer invisible
                CollisionDetected();
                LockOnTargetDetector();
            }
            ToggleTimerMonitor();
        }
        private void ToggleTimerMonitor()
        {
            if(pnlTmrMainMonitor.BackColor == Color.Orange)
            {
                pnlTmrMainMonitor.BackColor = Color.Yellow;
            }
            else
            {
                pnlTmrMainMonitor.BackColor = Color.Orange;
            }
        }
        private bool CollisionDetected()
        {
            bool m_collisionDetected = false;

            return m_collisionDetected;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            pressedKey = e.KeyCode.ToString();
            lblActiveKeyCwes.Text = pressedKey;
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKey = "";
            lblActiveKeyCwes.Text = pressedKey;
        }
        private void HandleGameKeys()
        {
            MoveFlak();
        }
        private void MoveFlak()
        {
            string m_shift = "";
            if(Control.ModifierKeys == Keys.Shift)
            {
                m_shift = "SHIFT";
            }
            switch(pressedKey)
            {
                case "W":
                    if(flakVertPosition > pnlFlakBatteryCwes.Top)
                    {
                        if(m_shift == "SHIFT")
                        {
                            flakVertPosition = flakVertPosition - 3;
                        }
                        else
                        {
                            flakVertPosition--;
                        }
                    }
                    break;
                case "A":
                    if(flakHorizPosition > pnlFlakBatteryCwes.Left + pnlFlakBatteryCwes.Width - 100)
                    {
                        flakHorizPosition--;
                    }
                    break;
                case "S":
                    if (flakVertPosition < (pnlFlakBatteryCwes.Top + pnlFlakBatteryCwes.Height - pbxFlakCwes.Height))
                    {
                        if (m_shift == "SHIFT")
                        {
                            flakVertPosition = flakVertPosition + 3;
                        }
                        else
                        {
                            flakVertPosition++;
                        }
                    }
                    break;
                case "D":
                    if (flakHorizPosition < pnlFlakBatteryCwes.Left - 20)
                    {
                        flakHorizPosition++;
                    }
                    break;
                case "X":
                    break;
                case "SHIFT":
                    break;
            }

            pbxFlakCwes.Top = flakHorizPosition;
            pbxFlakCwes.Left = flakHorizPosition;

            pnlCrossHairCwes.Top = flakVertPosition + 9;

            lblXyPosFlakCwes.Text = flakHorizPosition.ToString() + "," + flakVertPosition.ToString();
            lblLockOnTargetCwes.Text = LockOnTargetDetector().ToString();
        }
        private bool LockOnTargetDetector()
        {
            bool m_lockOnTarget = false;
            if (pbxRacerCwes.Top >= pbxFlakCwes.Top &&
               pbxRacerCwes.Top <= pbxFlakCwes.Top + pbxRacerCwes.Height)
            {
                m_lockOnTarget = true;
            }

            return m_lockOnTarget;
        }

        private void trbTmrMainIntervalCwes_Scroll(object sender, EventArgs e)
        {
            tmrMain.Interval = trbTmrMainIntervalCwes.Value;
            lblTmrMainIntervalCwes.Text = trbTmrMainIntervalCwes.Value.ToString();
        }

        private void nudSpeedUpCwes_ValueChanged(object sender, EventArgs e)
        {
            if(cbxSpeedUpCwes.Checked == true)
            {
                speedUpSteps = Convert.ToInt32(nudSpeedUpCwes.Value);
            }
        }

        private void cbxSpeedUpCwes_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxSpeedUpCwes.Checked == true)
            {
                nudSpeedUpCwes.Enabled = true;
                speedUpSteps = Convert.ToInt32(nudSpeedUpCwes.Value);
            }
            else
            {
                nudSpeedUpCwes.Enabled = false;
                speedUpSteps = 1;
            }
        }
        private void btnStartTimerCwes_Click(object sender, EventArgs e)
        {
            tmrMain.Enabled = true;
        }
    }
}
