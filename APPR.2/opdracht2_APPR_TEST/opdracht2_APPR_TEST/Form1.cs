using DragRacerPrep;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opdracht2_APPR_TEST
{
    public partial class Form1 : Form
    {
        csRacerBase obRacer1 = new csRacerBase();
        csRacerBase obRacer2 = new csRacerBase();

        int raceTime;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnDefault_Click(object sender, EventArgs e)
        {
            txbMinSpeed.Text = "500";
            txbMaxSpeed.Text = "800";

        }

        private void btnSetupRacers_Click(object sender, EventArgs e)
        {
            ModelRacer();

            ViewRacers();
        }

        private void ViewRacers()
        {
            lblPerTick.Text = obRacer1.GetStepSizePerTick.ToString();
            lblEngine.Text = obRacer1.GetTunedRacerSpeed.ToString();

            lblPerTick2.Text = obRacer2.GetStepSizePerTick.ToString();
            lblEngine2.Text = obRacer2.GetTunedRacerSpeed.ToString();
        }

        private void ModelRacer()
        {
            int m_minspeed;
            int m_maxspeed;

            m_minspeed = Convert.ToInt32(txbMinSpeed.Text);
            m_maxspeed = Convert.ToInt32(txbMaxSpeed.Text);

            obRacer1.setSpeed(m_minspeed, m_maxspeed);
            obRacer2.setSpeed(m_minspeed, m_maxspeed);

            obRacer1.calculateStepSize(pnlFinish.Left);
            obRacer2.calculateStepSize(pnlFinish.Left);
        }

        private void tmrRacer_Tick(object sender, EventArgs e)
        {
            raceTime++;

            lblRaceTime.Text = raceTime.ToString();

            updateRacer1();

            updateRacer2();
        }
        private void updateRacer1()
        {
            if (obRacer1.GetActualPositionInLaneRounded < pnlFinish.Left + 5)
            {
                obRacer1.calculateCurrentPosition();

                pbxRacer1.Left = obRacer1.GetActualPositionInLaneRounded;
            }
        }
        private void updateRacer2()
        {
            if (obRacer2.GetActualPositionInLaneRounded < pnlFinish.Left + 5)
            {
                obRacer2.calculateCurrentPosition();

                pbxRacer2.Left = obRacer2.GetActualPositionInLaneRounded;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            tmrRacer.Enabled = true;
            tmrRacer.Interval = 1;

            obRacer1.resetPosition(20);
            obRacer2.resetPosition(20);

        }
    }
}
