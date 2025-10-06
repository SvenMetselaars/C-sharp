using DragRacerPrep;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//FileHandling
using System.Diagnostics;



namespace oprdracht2_APPR_race
{
    public partial class Form1 : Form
    {
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string strCommand, StringBuilder strReturn, int iReturnLenght, IntPtr hwndCalling);

        bool audiostop;

        System.Drawing.Pen DrawingPen = new System.Drawing.Pen(System.Drawing.Color.DarkBlue, 0.1f);
        System.Drawing.Graphics formGraphics;

        int drawracer1;

        // to use class
        csRacerBase obRacer1 = new csRacerBase();
        csRacerBase obRacer2 = new csRacerBase();
        csRacerBase obRacer3 = new csRacerBase();
        csRacerBase obRacer4 = new csRacerBase();

        #region all the variables

        int finishedPosition = 0;

        bool btnGoUsed = false;

        bool againSound = false;

        int tmrpbxchange;

        int raceTime;

        int racingTimeMin = 0;

        int racerRanking = 0;

        int racesRaced = 0; 

        bool racer1Reset = false;
        bool racer2Reset = false;
        bool racer3Reset = false;
        bool racer4Reset = false;

        bool racer1Finished = false;
        bool racer2Finished = false;
        bool racer3Finished = false;
        bool racer4Finished = false;

        string Racer1Name = "";
        string Racer2Name = "";
        string Racer3Name = "";
        string Racer4Name = "";

        string relativeFileDirectory = "";

        int racer1Wins;
        int racer2Wins;
        int racer3Wins;
        int racer4Wins;

        double racerOneTotalPositions = 0;//store total of all races
        double racerTwoTotalPositions = 0;
        double racerThreeTotalPositions = 0;
        double racerFourTotalPositions = 0;
        double thisRacerAveragerRacePosition = 0; //used for all racers once finished
        int nrOfRaces = 1;//start with the first race, this is not zero

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "the race";

            pbxStartScreen2SM.Visible = false;
            tmrStartScreenSM.Enabled = true;

            // to hide the tabs
            tbcMainSM.Appearance = TabAppearance.FlatButtons;
            tbcMainSM.ItemSize = new Size(0, 1);
            tbcMainSM.SizeMode = TabSizeMode.Fixed;

            // to select tab start
            tbcMainSM.SelectedTab = tbpstartSM;

            // to set the amount of coins in the casino
            lblCoinsSM.Text = casinoCoins.ToString();

            // to set their maximums
            tbrMaxSpeedSM.Maximum = 1000;
            tbrMinSpeedSM.Maximum = 1000;

            // to center to screen
            this.CenterToScreen();

            // to set everything on its place
            resetRace();

            // for paint
            InitGraph();

            relativeFileDirectory = Application.StartupPath + "\\...\\..\\doc\\";

            // in the trello list
            MessageBox.Show("the race " + DateTime.Now.ToString());

        }

        private void InitGraph()
        {
            // to say where to paint
            formGraphics = pnlpaintSM.CreateGraphics();
            DrawingPen.Width = 1;
        }

        private void btnDefaultSM_Click(object sender, EventArgs e)
        {
            // to set default speeds
            txbMaxSpeedSM.Text = "800";

            txbMinSpeedSM.Text = "500";

            // logging of items 
            loggingsettings(Color.Black, "setting the default settings");
        }
        private void tbrMinSpeedSM_ValueChanged(object sender, EventArgs e)
        {
            txbMinSpeedSM.Text = Convert.ToString(tbrMinSpeedSM.Value);
        }
        private void tbrMaxSpeedSM_ValueChanged_1(object sender, EventArgs e)
        {
            txbMaxSpeedSM.Text = Convert.ToString(tbrMaxSpeedSM.Value);
        }
        private void txbMaxSpeedSM_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tbrMaxSpeedSM.Value = Convert.ToInt32(txbMaxSpeedSM.Text);
            }
            catch { }
        }
        private void txbMinSpeedSM_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tbrMinSpeedSM.Value = Convert.ToInt32(txbMinSpeedSM.Text);
            }
            catch { }
        }
        private void btnSetupRacers_Click(object sender, EventArgs e)
        {
            // to give random speed
            ModelRacer();

            // to look if racer was named or needs a default name
            RacerNames();

            // to make the speed visible
            ViewRacers();

            // logging of items
            loggingsettings(Color.Black, "setting up the racers");
        }

        private void RacerNames()
        {
            try
            {   
                // to look if racer was named or needs a default name
                if (txbRacerName1SM.Text == "")
                {
                    txbRacerName1SM.Text = "racer 1";
                }
                if (txbRacerName2SM.Text == "")
                {
                    txbRacerName2SM.Text = "racer 2";
                }
                if (txbRacerName3SM.Text == "")
                {
                    txbRacerName3SM.Text = "racer 3";
                }
                if (txbRacerName4SM.Text == "")
                {
                    txbRacerName4SM.Text = "Max Verstappen";
                }
                Racer1Name = txbRacerName1SM.Text;
                Racer2Name = txbRacerName2SM.Text;
                Racer3Name = txbRacerName3SM.Text;
                Racer4Name = txbRacerName4SM.Text;

                // give the tbx a color so you know who is what color
                txbRacerName1SM.BackColor = Color.Red;
                txbRacerName2SM.BackColor = Color.Green;
                txbRacerName3SM.BackColor = Color.Blue;
                txbRacerName4SM.BackColor = Color.Orange;

                lblRacer1NameSM.Text = Racer1Name;
                lblRacer1NameSM.ForeColor = Color.Red;

                lblRacer2NameSM.Text = Racer2Name;
                lblRacer2NameSM.ForeColor = Color.Green;

                lblRacer3NameSM.Text = Racer3Name;
                lblRacer3NameSM.ForeColor = Color.Blue;

                lblRacer4NameSM.Text = Racer4Name;
                lblRacer4NameSM.ForeColor = Color.Orange;

            }
            catch
            {
                // logging of items
                MessageBox.Show("please use a usable name");
                loggingsettings(Color.Black, "please use a usable name");
            }
        }

        private void ViewRacers()
        {
            // to show what the speed is for racers 1 to 4
            lblStapsizeTick1SM.Text = obRacer1.GetStepSizePerTick.ToString();
            lblEngine1SM.Text = obRacer1.GetTunedRacerSpeed.ToString();

            lblStapsizeTick2SM.Text = obRacer2.GetStepSizePerTick.ToString();
            lblEngine2SM.Text = obRacer2.GetTunedRacerSpeed.ToString();

            lblStapsizeTick3SM.Text = obRacer3.GetStepSizePerTick.ToString();
            lblEngine3SM.Text = obRacer3.GetTunedRacerSpeed.ToString();

            lblStapsizeTick4SM.Text = obRacer4.GetStepSizePerTick.ToString();
            lblEngine4SM.Text = obRacer4.GetTunedRacerSpeed.ToString();
        }

        private void ModelRacer()
        {
            int m_minspeed;
            int m_maxspeed;
            // 31,1 by try catch if it "craches" trying to convert to int then it goes in the catch and gives a message
            try
            {
                // get the min and max speed out of the textbox
                m_minspeed = Convert.ToInt32(txbMinSpeedSM.Text);
                m_maxspeed = Convert.ToInt32(txbMaxSpeedSM.Text);

                // to see if they did it wrong way around
                if (m_minspeed > m_maxspeed)
                {
                    // for logging of items
                    MessageBox.Show("please dont use a higer min speed than max speed");
                    loggingsettings(Color.Black, "please dont use a higer min speed than max speed");
                }
                else
                {
                    // to give it a random speed
                    obRacer1.setSpeed(m_minspeed, m_maxspeed);
                    obRacer2.setSpeed(m_minspeed, m_maxspeed);
                    obRacer3.setSpeed(m_minspeed, m_maxspeed);
                    obRacer4.setSpeed(m_minspeed, m_maxspeed);

                    // to calculate how big the track is
                    obRacer1.calculateStepSize(pnlFinishSM.Left);
                    obRacer2.calculateStepSize(pnlFinishSM.Left);
                    obRacer3.calculateStepSize(pnlFinishSM.Left);
                    obRacer4.calculateStepSize(pnlFinishSM.Left);
                }
            }
            catch
            {
                // logging of items
                MessageBox.Show("please fill in with numbers");
                loggingsettings(Color.Black, "please fill in with numbers");
            }
        }

        private void tmrRaceSM_Tick(object sender, EventArgs e)
        {
            // to see how long we are racing for
            raceTime++;

            // to make random speeds in the race in the trello list
            if (raceTime == 201 || raceTime == 401 || raceTime == 601)
            {
                ViewRacers();

                ModelRacer();
            }

            // to set it on a label
            lblRaceTimeSM.Text = raceTime.ToString();

            // to make them move
            updateRacer4();

            updateRacer3();

            updateRacer2();

            updateRacer1();

            //to draw the speeds of racers 1 to 4 and give them the color
            drawingspeedsRacer(obRacer1, Color.Red);
            drawingspeedsRacer(obRacer2, Color.Green);
            drawingspeedsRacer(obRacer3, Color.Blue);
            drawingspeedsRacer(obRacer4, Color.Orange);

            // to check if they all finished
            stopRace();

        }

        // to make it look like less code
        #region racers

        /// <summary>
        /// this is to make the racers move and for the ranking.
        /// this is also for the betting system and to give the coins if they win
        /// </summary>
        private void updateRacer1()
        {
            double m_prevRacerAveragePosition = 0;

            // to see if they finished if not they go in the if
            if (obRacer1.GetActualPositionInLaneRounded < pnlFinishSM.Left + 5 - 80)
            {
                // to see where he is
                obRacer1.calculateCurrentPosition();

                // to make move
                pbxRacer1SM.Left = obRacer1.GetActualPositionInLaneRounded;
                if (pbxRacer1TrailSM.Width == 100)
                {
                    // to make follow its in the trello list
                    pbxRacer1TrailSM.Left = pbxRacer1SM.Left - 100;
                }
                else
                {
                    // to make width in the trello list
                    pbxRacer1TrailSM.Width = obRacer1.GetActualPositionInLaneRounded;
                }
            }
            // if they finished they go in here
            else
            {
                finishedPosition++;

                racerOneTotalPositions = racerOneTotalPositions + finishedPosition;
                m_prevRacerAveragePosition = thisRacerAveragerRacePosition;//save prev result and compare later
                thisRacerAveragerRacePosition = Math.Round(racerOneTotalPositions / nrOfRaces, 1);

                if (thisRacerAveragerRacePosition > m_prevRacerAveragePosition)
                {
                    lbl1RankUpDownSM.Text = "up";
                    lbl1RankUpDownSM.ForeColor = Color.Lime;
                }
                else if (thisRacerAveragerRacePosition < m_prevRacerAveragePosition)
                {
                    lbl1RankUpDownSM.Text = "down";
                    lbl1RankUpDownSM.ForeColor = Color.Red;
                }
                else
                {
                    lbl1RankUpDownSM.Text = "same";
                    lbl1RankUpDownSM.ForeColor = Color.Blue;
                }

                if (racer1Finished == false)
                {
                    racer1Finished = true;

                    racerRanking++;

                    // if racerranking is 1 they go in here
                    if (racerRanking == 1)
                    {
                        tmrTrailSM.Enabled = true;

                        // to show how good they finished
                        lblRank1SM.Text = "1";

                        // to put them on the podium
                        pbxRacer1SM.Left = 208;
                        pbxRacer1SM.Top = 287;

                        // for the rcs(idk what its called)
                        racer1Wins++;

                        // logging of items
                        rtbSettingsSM.SelectionColor = Color.Green;
                        rtbSettingsSM.AppendText(Racer1Name + " won the race \n");
                        rtbSettingsSM.SelectionColor = Color.Black;
                        scrolltocaret();

                        //if they put a bet on racer one they go in here
                        if (casinoBetting1 == true)
                        {
                            // logging of items
                            MessageBox.Show("you won your bet");
                            loggingCasino(Color.Gold, "you won your bet");

                            // to calculate their new money
                            casinoCoins = casinoCoins + casinoBet1Coins * 2;

                            // to show their new money
                            lblCoinsSM.Text = casinoCoins.ToString();

                            // to stop the bet
                            casinoBetting1 = false;

                            // to set their bet to 0
                            tbxBet1SM.Text = "";

                            // to show they won their bet
                            betWon();
                        }
                    }

                    else if (racerRanking == 2)
                    {
                        // if they got second
                        lblRank1SM.Text = "2";

                        // to put them on the podium
                        pbxRacer1SM.Left = 122;
                        pbxRacer1SM.Top = 327;

                        // if they betted
                        if (casinoBetting1 == true)
                        {
                            // logging of items
                            MessageBox.Show("you lost your bet");
                            loggingCasino(Color.Red, "you lost your bet");

                            // to set it to 0
                            tbxBet1SM.Text = "";

                            // to stop the bet
                            casinoBetting1 = false;

                            // to show they lost their bet
                            betLost();
                        }
                    }

                    else if (racerRanking == 3)
                    {
                        // if they got 3th
                        lblRank1SM.Text = "3";

                        // to put them on the podium
                        pbxRacer1SM.Left = 295;
                        pbxRacer1SM.Top = 368;

                        if (casinoBetting1 == true)
                        {
                            // logging of items
                            MessageBox.Show("you lost your bet");
                            loggingCasino(Color.Red, "you lost your bet");

                            // to set it to 0
                            tbxBet1SM.Text = "";

                            // to stop the bet
                            casinoBetting1 = false;

                            // to show they lost their bet
                            betLost();
                        }
                    }

                    else if (racerRanking == 4)
                    {
                        // if they got 4th
                        lblRank1SM.Text = "4";

                        // to put them on the podium
                        pbxRacer1SM.Left = 381;
                        pbxRacer1SM.Top = 409;

                        if (casinoBetting1 == true)
                        {
                            // logging of items
                            MessageBox.Show("you lost your bet");
                            loggingCasino(Color.Red, "you lost your bet");

                            // to set it to 0
                            tbxBet1SM.Text = "";

                            // to stop the bet
                            casinoBetting1 = false;

                            // to show they lost their bet
                            betLost();
                        }
                    }
                }
            }
        }
        // if not understand read update racer1(is same code but for diferent racer)
        private void updateRacer2()
        {
            double m_prevRacerAveragePosition = 0;

            if (obRacer2.GetActualPositionInLaneRounded < pnlFinishSM.Left + 5 - 80)
            {
                obRacer2.calculateCurrentPosition();

                pbxRacer2SM.Left = obRacer2.GetActualPositionInLaneRounded;
                if (pbxRacer2TrailSM.Width == 100)
                {
                    //to make it follow
                    pbxRacer2TrailSM.Left = pbxRacer2SM.Left - 100;
                }
                else
                {                    
                    // to change the width
                    pbxRacer2TrailSM.Width = obRacer2.GetActualPositionInLaneRounded;
                }
            }
            else
            {
                finishedPosition++;

                racerTwoTotalPositions = racerTwoTotalPositions + finishedPosition;
                m_prevRacerAveragePosition = thisRacerAveragerRacePosition;//save prev result and compare later
                thisRacerAveragerRacePosition = Math.Round(racerTwoTotalPositions / nrOfRaces, 1);


                if (thisRacerAveragerRacePosition > m_prevRacerAveragePosition)
                {
                    lbl2RankUpDownSM.Text = "up";
                    lbl2RankUpDownSM.ForeColor = Color.Lime;
                }
                else if (thisRacerAveragerRacePosition < m_prevRacerAveragePosition)
                {
                    lbl2RankUpDownSM.Text = "down";
                    lbl2RankUpDownSM.ForeColor = Color.Red;
                }
                else
                {
                    lbl2RankUpDownSM.Text = "same";
                    lbl2RankUpDownSM.ForeColor = Color.Blue;
                }

                if (racer2Finished == false)
                {
                    //to determent rank
                    racerRanking++;

                    racer2Finished = true;

                    if (racerRanking == 1)
                    {
                        lblRank2SM.Text = "1";

                        tmrTrailSM.Enabled = true;

                        pbxRacer2SM.Left = 208;
                        pbxRacer2SM.Top = 287;

                        rtbSettingsSM.SelectionColor = Color.Green;
                        rtbSettingsSM.AppendText(Racer2Name + " won the race \n");
                        rtbSettingsSM.SelectionColor = Color.Black;
                        scrolltocaret();

                        racer2Wins++;

                        if (casinoBetting2 == true)
                        {
                            MessageBox.Show("you won your bet");
                            loggingCasino(Color.Gold, "you won your bet");

                            casinoCoins = casinoCoins + casinoBet2Coins * 2;

                            lblCoinsSM.Text = casinoCoins.ToString();

                            casinoBetting2 = false;

                            tbxBet2SM.Text = "";

                            betWon();
                        }
                    }

                    else if (racerRanking == 2)
                    {
                        lblRank2SM.Text = "2";

                        pbxRacer2SM.Left = 122;
                        pbxRacer2SM.Top = 327;


                        if (casinoBetting2 == true)
                        {
                            MessageBox.Show("you lost your bet");
                            loggingCasino(Color.Red, "you lost your bet");

                            tbxBet2SM.Text = "";

                            casinoBetting2 = false;

                            betLost();
                        }
                    }

                    else if (racerRanking == 3)
                    {
                        lblRank2SM.Text = "3";

                        pbxRacer2SM.Left = 295;
                        pbxRacer2SM.Top = 368;

                        if (casinoBetting2 == true)
                        {
                            MessageBox.Show("you lost your bet");
                            loggingCasino(Color.Red, "you lost your bet");

                            tbxBet2SM.Text = "";

                            casinoBetting2 = false;

                            betLost();
                        }
                    }

                    else if (racerRanking == 4)
                    {
                        lblRank2SM.Text = "4";

                        pbxRacer2SM.Left = 381; 
                        pbxRacer2SM.Top = 409;

                        if (casinoBetting2 == true)
                        {
                            MessageBox.Show("you lost your bet");
                            loggingCasino(Color.Red, "you lost your bet");

                            tbxBet2SM.Text = "";

                            casinoBetting2 = false;

                            betLost();
                        }
                    }
                }
            }
        }

        // if not understand read update racer1(is same code but for diferent racer)
        private void updateRacer3()
        {
            double m_prevRacerAveragePosition = 0;

            if (obRacer3.GetActualPositionInLaneRounded < pnlFinishSM.Left + 5 - 80)
            {
                obRacer3.calculateCurrentPosition();

                pbxRacer3SM.Left = obRacer3.GetActualPositionInLaneRounded;

                if (pbxRacer3TrailSM.Width == 100)
                {
                    //to make it follow
                    pbxRacer3TrailSM.Left = pbxRacer3SM.Left - 100;
                }
                else
                {
                    // to change the width
                    pbxRacer3TrailSM.Width = obRacer3.GetActualPositionInLaneRounded;
                }
            }
            else
            {
                finishedPosition++;

                racerThreeTotalPositions = racerThreeTotalPositions + finishedPosition;
                m_prevRacerAveragePosition = thisRacerAveragerRacePosition; //save prev result and compare later
                thisRacerAveragerRacePosition = Math.Round(racerThreeTotalPositions / nrOfRaces, 1);

                if (thisRacerAveragerRacePosition > m_prevRacerAveragePosition)
                {
                    lbl3RankUpDownSM.Text = "up";
                    lbl3RankUpDownSM.ForeColor = Color.Lime;
                }
                else if (thisRacerAveragerRacePosition < m_prevRacerAveragePosition)
                {
                    lbl3RankUpDownSM.Text = "down";
                    lbl3RankUpDownSM.ForeColor = Color.Red;
                }
                else
                {
                    lbl3RankUpDownSM.Text = "same";
                    lbl3RankUpDownSM.ForeColor = Color.Blue;
                }

                if (racer3Finished == false)
                {
                    // to determent rank
                    racerRanking++;

                    racer3Finished = true;

                    if (racerRanking == 1)
                    {
                        if (casinoBetting3 == true)
                        {
                            MessageBox.Show("you won your bet");
                            loggingCasino(Color.Gold, "you Won your bet");

                            casinoCoins = casinoCoins + casinoBet3Coins * 2;

                            lblCoinsSM.Text = casinoCoins.ToString();

                            casinoBetting3 = false;

                            tbxBet3SM.Text = "";

                            betWon();
                        }

                        lblRank3SM.Text = "1";

                        tmrTrailSM.Enabled = true;

                        pbxRacer3SM.Left = 208;
                        pbxRacer3SM.Top = 287;

                        rtbSettingsSM.SelectionColor = Color.Green;
                        rtbSettingsSM.AppendText(Racer3Name + " won the race \n");
                        rtbSettingsSM.SelectionColor = Color.Black;
                        scrolltocaret();

                        racer3Wins++;

                    }

                    else if (racerRanking == 2)
                    {
                        if (casinoBetting3 == true)
                        {
                            MessageBox.Show("you lost your bet");
                            loggingCasino(Color.Red, "you lost your bet");

                            tbxBet3SM.Text = "";

                            casinoBetting3 = false;

                            betLost();
                        }

                        lblRank3SM.Text = "2";

                        pbxRacer3SM.Left = 122;
                        pbxRacer3SM.Top = 327;
                    }

                    else if (racerRanking == 3)
                    {
                        if (casinoBetting3 == true)
                        {
                            MessageBox.Show("you lost your bet");
                            loggingCasino(Color.Red, "you lost your bet");

                            tbxBet3SM.Text = "";

                            casinoBetting3 = false;

                            betLost();
                        }
                        lblRank3SM.Text = "3";

                        pbxRacer3SM.Left = 295;
                        pbxRacer3SM.Top = 368;
                    }

                    else if (racerRanking == 4)
                    {
                        if (casinoBetting3 == true)
                        {
                            MessageBox.Show("you lost your bet");
                            loggingCasino(Color.Red, "you lost your bet ");

                            tbxBet3SM.Text = "";

                            casinoBetting3 = false;

                            betLost();
                        }
                        lblRank3SM.Text = "4";

                        pbxRacer3SM.Left = 381;
                        pbxRacer3SM.Top = 409;
                    }
                }
            }
        
        }

        // if not understand read update racer1(is same code but for diferent racer)
        private void updateRacer4()
        {
            double m_prevRacerAveragePosition = 0;

            if (obRacer4.GetActualPositionInLaneRounded < pnlFinishSM.Left + 5 - 80)
            {
                obRacer4.calculateCurrentPosition();

                pbxRacer4SM.Left = obRacer4.GetActualPositionInLaneRounded;

                if (pbxRacer4TrailSM.Width == 100)
                {
                    //to make it follow
                    pbxRacer4TrailSM.Left = pbxRacer4SM.Left - 100;
                }
                else
                {
                    // to change the width
                    pbxRacer4TrailSM.Width = obRacer4.GetActualPositionInLaneRounded;
                }
            }
            else
            {
                finishedPosition++;

                racerFourTotalPositions = racerFourTotalPositions + finishedPosition;
                m_prevRacerAveragePosition = thisRacerAveragerRacePosition; //save prev result and compare later
                thisRacerAveragerRacePosition = Math.Round(racerFourTotalPositions / nrOfRaces, 1);

                if (thisRacerAveragerRacePosition > m_prevRacerAveragePosition)
                {
                    lbl4RankUpDownSM.Text = "up";
                    lbl4RankUpDownSM.ForeColor = Color.Lime;
                }
                else if (thisRacerAveragerRacePosition < m_prevRacerAveragePosition)
                {
                    lbl4RankUpDownSM.Text = "down";
                    lbl4RankUpDownSM.ForeColor = Color.Red;
                }
                else
                {
                    lbl4RankUpDownSM.Text = "same";
                    lbl4RankUpDownSM.ForeColor = Color.Blue;
                }

                if (racer4Finished == false)
                {
                    racerRanking++;

                    racer4Finished = true;

                    if (racerRanking == 1)
                    {
                        if (casinoBetting4 == true)
                        {
                            MessageBox.Show("you won your bet");
                            loggingCasino(Color.Gold, "you won your bet");

                            casinoCoins = casinoCoins + casinoBet4Coins * 2;

                            lblCoinsSM.Text = casinoCoins.ToString();

                            casinoBetting4 = false;

                            tbxBet4SM.Text = "";

                            betWon();
                        }
                        lblRank4SM.Text = "1";

                        tmrTrailSM.Enabled = true;

                        pbxRacer4SM.Left = 208;
                        pbxRacer4SM.Top = 287;

                        racer4Wins++;

                        stopaudio();
                        playmax();

                        loggingsettings(Color.Green, "tu tu tu tu max verstappen tu tu tu tu max verstappen");
                    }

                    else if (racerRanking == 2)
                    {
                        if (casinoBetting4 == true)
                        {
                            MessageBox.Show("you lost your bet");
                            loggingCasino(Color.Red, "you lost your bet");

                            tbxBet4SM.Text = "";

                            casinoBetting4 = false;

                            betLost();
                        }
                        lblRank4SM.Text = "2";

                        pbxRacer4SM.Left = 122;
                        pbxRacer4SM.Top = 327;
                    }

                    else if (racerRanking == 3)
                    {
                        if (casinoBetting4 == true)
                        {
                            MessageBox.Show("you lost your bet");
                            loggingCasino(Color.Red, "you lost your bet");

                            tbxBet4SM.Text = "";

                            casinoBetting4 = false;

                            betLost();
                        }
                        lblRank4SM.Text = "3";

                        pbxRacer4SM.Left = 295;
                        pbxRacer4SM.Top = 368;
                    }

                    else if (racerRanking == 4)
                    {
                        if (casinoBetting4 == true)
                        {
                            MessageBox.Show("you lost your bet");
                            loggingCasino(Color.Red, "you lost your bet");

                            tbxBet4SM.Text = "";

                            casinoBetting4 = false;

                            betLost();
                        }
                        lblRank4SM.Text = "4";

                        pbxRacer4SM.Left = 381;
                        pbxRacer4SM.Top = 409;
                    }
                }
                
            }
        }
        #endregion

        private void tmrTrailSM_Tick(object sender, EventArgs e)
        {
            if (racer1Finished == true)
            {
                pbxRacer1TrailSM.Width = pbxRacer1TrailSM.Width - 3;
                pbxRacer1TrailSM.Left = pbxRacer1TrailSM.Left + 3;
            }
            if (racer2Finished == true)
            {
                pbxRacer2TrailSM.Width = pbxRacer2TrailSM.Width - 3;
                pbxRacer2TrailSM.Left = pbxRacer2TrailSM.Left + 3;
            }
            if (racer3Finished == true)
            {
                pbxRacer3TrailSM.Width = pbxRacer3TrailSM.Width - 3;
                pbxRacer3TrailSM.Left = pbxRacer3TrailSM.Left + 3;
            }
            if (racer4Finished == true)
            {
                pbxRacer4TrailSM.Width = pbxRacer4TrailSM.Width - 3;
                pbxRacer4TrailSM.Left = pbxRacer4TrailSM.Left + 3;
            }
            if (pbxRacer1TrailSM.Width == 0 && pbxRacer2TrailSM.Width == 0 && pbxRacer1TrailSM.Width == 0 && pbxRacer2TrailSM.Width == 0)
            {
                tmrTrailSM.Enabled = false;
                pbxRacer1TrailSM.Visible = false;
                pbxRacer2TrailSM.Visible = false;
                pbxRacer3TrailSM.Visible = false;
                pbxRacer4TrailSM.Visible = false;
            }
        }
        private void drawingspeedsRacer(csRacerBase a_obRacerNr, Color a_Pen)
        {
            int m_offSetY = 0;
            double m_offSetX = 0;
            int xToPos = 0;
            int xFromPos = 0;
            double panelWidth = 0;
            double thisWidth = 0;

            // to give the pen a color
            DrawingPen.Color = a_Pen;
            // to give the pen a witdh
            DrawingPen.Width = 1;

            // to calculate the place where to start
            panelWidth = pnlpaintSM.Width;
            thisWidth = this.Width;

            // to calculate the place where to start
            m_offSetY = pnlpaintSM.Height + ((pnlpaintSM.Height / 2) - 50) - (a_obRacerNr.GetTunedRacerSpeed / 5);
            m_offSetX = panelWidth / thisWidth;

            // to calculate their speed
            xFromPos = Convert.ToInt32(a_obRacerNr.previousPosition * m_offSetX);
            xToPos = Convert.ToInt32(a_obRacerNr.GetActualPositionInLaneRounded * m_offSetX);

            // to draw everything
            formGraphics.DrawLine(DrawingPen, xFromPos, m_offSetY, xToPos, m_offSetY);
        }

        private void btnGoSM_Click(object sender, EventArgs e)
        {
            // to see if they receted the racer
            if (racer1Reset == false || racer2Reset == false || racer3Reset == false || racer4Reset == false)
            {
                // logging of items
                MessageBox.Show("reset the racers first");
                loggingsettings(Color.Black, "reset the racers first");
            }
            // to see if they filled in the settings if didnt they get error message 31,1
            else if (lblEngine1SM.Text == "---")
            {
                // logging of items
                MessageBox.Show("fill in the settings first");
                loggingsettings(Color.Black, "fill in the settings first");
            }
            else
            {
                // to make sure they dont change this while racing
                txbMaxSpeedSM.Enabled = false;
                txbMinSpeedSM.Enabled = false; 
                btnDefaultSM.Enabled = false;

                // to enable timer
                tmrRaceSM.Enabled = true;
                tmrRaceSM.Interval = 1;

                // to reset their position 
                obRacer1.resetPosition(20);
                obRacer2.resetPosition(20);
                obRacer3.resetPosition(20);
                obRacer4.resetPosition(20);

                // for if they use the again button (that button doesnt work if the go button hasnt been pressed)
                btnGoUsed = true;

                stopaudio();
                playVroemVoem();

                // to unreset the racers
                racer1Reset = false;
                racer2Reset = false;
                racer3Reset = false;
                racer4Reset = false;

                //loggingg of items
                loggingsettings(Color.Black, "starting the race");
                loggingCasino(Color.Black, "starting the race");
            }

        }

        #region menu
        private void theRaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // to switch to the race with the tool strip
            tbcMainSM.SelectedTab = tbpMainRaceSM;

            tmrStartScreenSM.Enabled = false;

            thiswidht();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // to switch to the settings with the tool strip
            tbcMainSM.SelectedTab = tbpMainSettingsSM;

            tmrStartScreenSM.Enabled = false;

            thiswidht();
        }

        private void loggingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbcMainSM.SelectedTab = tbpMainAllLoggingSM;

            tmrStartScreenSM.Enabled = false;

            thiswidht();
        }

        private void casinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // to switch to the casino with the tool strip
            tbcMainSM.SelectedTab = tbpMainCasinoSM;

            tmrStartScreenSM.Enabled = false;

            thiswidht();
        }
        private void btnStartScreen_Click(object sender, EventArgs e)
        {
            // to switch to the race with the button
            tbcMainSM.SelectedTab = tbpMainRaceSM;

            tmrStartScreenSM.Enabled = false;

            thiswidht();
        }
        private void creatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // to give info about the creator
            MessageBox.Show("made by Sven Metselaars\n" +
                "thanks to Dkal");
        }
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text file|*.txt|All files(*.*)|*.*";
                openFileDialog.FileName = "logging.txt";
                openFileDialog.InitialDirectory = @"C:\Users\svenm\OneDrive\Bureaublad\APPR.2\oprdracht2_APPR_race\doc\logging.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string content = File.ReadAllText(openFileDialog.FileName);
                        Console.WriteLine("File content:\n" + content);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Operation canceled by the user.");
                }
            }
        }

        private void thiswidht()
        {
            // in the trello list 
            this.Width = tbcMainSM.Width + 50;
            this.Height = tbcMainSM.Height + 50;
        }
        #endregion

        private void btnResetSM_Click(object sender, EventArgs e)
        {
            if (racer1Reset == false && racer2Reset == false && racer3Reset == false && racer4Reset == false)
            {
                // to reset the race track
                resetRace();

                pbxRacer1SM.Left = pnlFinishSM.Left + 5;
                pbxRacer1SM.Top = 6;

                pbxRacer2SM.Left = pnlFinishSM.Left + 5;
                pbxRacer2SM.Top = 70;

                pbxRacer3SM.Left = pnlFinishSM.Left + 5;
                pbxRacer3SM.Top = 134;

                pbxRacer4SM.Left = pnlFinishSM.Left + 5;
                pbxRacer4SM.Top = 198;

                tmrResetSM.Enabled = true;
                tmrResetSM.Interval = 1;

                // for if they want to use again button
                btnGoUsed = false;

                btnResetSM.Enabled = false;
                btnAgainSM.Enabled = false;
                btnGoSM.Enabled = false;
            }
        }

        private void resetRacers()
        {
            // to reset their position
            obRacer1.resetPosition(20);
            obRacer2.resetPosition(20);
            obRacer3.resetPosition(20);
            obRacer4.resetPosition(20);
            
            // to calculate thair current position
            obRacer1.calculateCurrentPosition();
            obRacer2.calculateCurrentPosition();
            obRacer3.calculateCurrentPosition();
            obRacer4.calculateCurrentPosition();
        }

        private void resetRace()
        {
            // to make it startable
            racer1Reset = true;
            racer2Reset = true;
            racer3Reset = true;
            racer4Reset = true;

            // to unfinish them
            racer1Finished = false;
            racer2Finished = false;
            racer3Finished = false;
            racer4Finished = false;

            // to make them useable
            txbMaxSpeedSM.Enabled = true;
            txbMinSpeedSM.Enabled = true;
            btnDefaultSM.Enabled = true;

            // to reset the textboxes
            txbMaxSpeedSM.Text = "";
            txbMinSpeedSM.Text = "";

            // to rest these lables
            lblEngine1SM.Text = "---";
            lblEngine2SM.Text = "---";
            lblEngine3SM.Text = "---";
            lblEngine4SM.Text = "---";
            lblStapsizeTick1SM.Text = "---";
            lblStapsizeTick2SM.Text = "---";
            lblStapsizeTick3SM.Text = "---";
            lblStapsizeTick4SM.Text = "---";

            // to recet their name
            txbRacerName1SM.Text = "";
            txbRacerName2SM.Text = "";
            txbRacerName3SM.Text = "";
            txbRacerName4SM.Text = "";

            // to reset the drawing
            Refresh();

            // to reset the racer ranking
            racerRanking = 0;

            // to set it back
            raceTime = 0;
            racingTimeMin = 0;
            tmrRaceSM.Enabled = false;

            // to reset the label with time
            lblRaceTimeSM.Text = "---";
        }

        private void stopRace()
        {
            // to see if everyone finished
            if (racer1Finished == true && racer2Finished == true && racer3Finished == true && racer4Finished == true)
            {
                // so it stops
                tmrRaceSM.Enabled = false;

                // it doesnt work otherwise (idk what this changes but it looks if someone ended first)
                if (racer1Wins != 0 || racer2Wins != 0 || racer3Wins != 0 || racer4Wins != 0) 
                {
                    // 11,1
                    // to save it somewhere
                    StreamWriter WriteFileThing = new StreamWriter("C:\\Users\\svenm\\OneDrive\\Bureaublad\\APPR.2\\oprdracht2_APPR_race\\doc\\logging.txt", true);

                    WriteFileThing.WriteLine(racer1Wins + ";" + racer2Wins + ";" + racer3Wins + ";" + racer4Wins);

                    WriteFileThing.Close();

                    // logging of items
                    loggingsettings(Color.Black, "race ended");

                    racesRaced = Convert.ToInt32(lblRacesRacedSM.Text);
                    racesRaced++;
                    lblRacesRacedSM.Text = racesRaced.ToString();

                    stopaudio();

                }

                // to set them to 0 again
                racer1Wins = 0;
                racer2Wins = 0;
                racer3Wins = 0;
                racer4Wins = 0;
            }
        }

        // if they pressed the again button
        private void btnAgainSM_click(object sender, EventArgs e)
        {
            // if they didnt fill in the settings
            if (lblEngine1SM.Text == "---")
            {
                // logging of items
                MessageBox.Show("fill in the settings first");
                loggingsettings(Color.Black, "fill in the settings first");
            }
            // to make sure they used the go button
            else if (btnGoUsed == false)
            {
                // logging of items
                MessageBox.Show("please start the race first before you press again");
                loggingsettings(Color.Black, "please start the race first before you press againt");
            }
            else
            {
                // to make it startable
                racer1Reset = true;
                racer2Reset = true;
                racer3Reset = true;
                racer4Reset = true;

                againSound = true;

                // to unfinish them
                racer1Finished = false;
                racer2Finished = false;
                racer3Finished = false;
                racer4Finished = false;

                pbxRacer1SM.Left = pnlFinishSM.Left + 5;
                pbxRacer1SM.Top = 6;

                pbxRacer2SM.Left = pnlFinishSM.Left + 5;
                pbxRacer2SM.Top = 70;

                pbxRacer3SM.Left = pnlFinishSM.Left + 5;
                pbxRacer3SM.Top = 134;

                pbxRacer4SM.Left = pnlFinishSM.Left + 5;
                pbxRacer4SM.Top = 198;

                tmrResetSM.Enabled = true;
                tmrResetSM.Interval = 1;

                // make visible
                pbxRacer1TrailSM.Visible = true;
                pbxRacer2TrailSM.Visible = true;
                pbxRacer3TrailSM.Visible = true;
                pbxRacer4TrailSM.Visible = true;

                // to set it back
                raceTime = 0;
                racingTimeMin = 0;

                // to reset racer ranking
                racerRanking = 0;

                // reset the drawing
                Refresh();

                // to reset the race track
                resetRacers();
            }
        }
        private void tmrStartScreenSM_Tick(object sender, EventArgs e)
        {
            tmrpbxchange++;

            if (tmrpbxchange == 100 && pbxStartScreen2SM.Visible == false)
            {
                tmrpbxchange = 0;
                pbxStartScreen2SM.Visible = true;
                pbxstartSM.Visible = false;
            }
            else if (tmrpbxchange == 100 && pbxStartScreen2SM.Visible == true)
            {
                tmrpbxchange = 0;
                pbxStartScreen2SM.Visible = false;
                pbxstartSM.Visible = true;
            }
        }
        private void pbxStartScreen2SM_Click(object sender, EventArgs e)
        {
            pbxStartScreen2SM.Visible = false;
            pbxstartSM.Visible = true;
        }
        private void pbxstartSM_Click(object sender, EventArgs e)
        {
            pbxStartScreen2SM.Visible = true;
            pbxstartSM.Visible = false;
        }

        private void tmrResetSM_Tick(object sender, EventArgs e)
        {
            if (pbxRacer1SM.Left != 6)
            {
                pbxRacer1SM.Left--;
            }
            if (pbxRacer2SM.Left != 6)
            {
                pbxRacer2SM.Left--;
            }
            if (pbxRacer3SM.Left != 6)
            {
                pbxRacer3SM.Left--;
            }
            if (pbxRacer4SM.Left != 6)
            {
                pbxRacer4SM.Left--;
            }

            if (pbxRacer1SM.Left == 6 && pbxRacer1SM.Left == 6 && pbxRacer1SM.Left == 6 && pbxRacer1SM.Left == 6)
            {
                // to make them visible again
                pbxRacer1TrailSM.Visible = true;
                pbxRacer2TrailSM.Visible = true;
                pbxRacer3TrailSM.Visible = true;
                pbxRacer4TrailSM.Visible = true;

                pbxRacer1TrailSM.Left = 6;
                pbxRacer2TrailSM.Left = 6;
                pbxRacer3TrailSM.Left = 6;
                pbxRacer4TrailSM.Left = 6;

                btnResetSM.Enabled = true;
                btnAgainSM.Enabled = true;
                btnGoSM.Enabled = true;

                // to reset the racers
                resetRacers();

                tmrResetSM.Enabled = false;

                if (againSound == true)
                {
                    stopaudio();
                    playVroemVoem();

                    againSound = false;

                    // to enamble timmer again
                    tmrRaceSM.Enabled = true;
                }
            }
        }

        #region logging
            private void scrolltocaret()
        {
            // to make it look nice
            rtbSettingsSM.ScrollToCaret();
            rtbCasinoSM.ScrollToCaret();
        }
        private void loggingsettings(Color LoggingColor, string LoggingText)
        {
            // logging of items
            rtbSettingsSM.SelectionColor = LoggingColor;
            rtbSettingsSM.AppendText(LoggingText + "\n");
            rtbAllLoggingSM.SelectionColor = LoggingColor;
            rtbAllLoggingSM.AppendText(LoggingText + "\n");
            scrolltocaret();
        }
        private void loggingCasino(Color LoggingColor, string LoggingText)
        {
            // logging of items
            rtbCasinoSM.SelectionColor = LoggingColor;
            rtbCasinoSM.AppendText(LoggingText + "\n");
            rtbAllLoggingSM.SelectionColor = LoggingColor;
            rtbAllLoggingSM.AppendText(LoggingText + "\n");
            scrolltocaret();
        }
        #endregion

        #region audio
        private void playVroemVoem()
        {
            // for sound
            string m_location;
            m_location = Application.StartupPath;

            m_location = m_location + "\\..\\..\\snd\\carGoesVroemVroem.mp3";

            mciSendString("open \"" + m_location + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);

            mciSendString("play MediaFile", null, 0, IntPtr.Zero);

            audiostop = false;
        }
        private void playmax()
        {
            // for sound
            string m_location;
            m_location = Application.StartupPath;

            m_location = m_location + "\\..\\..\\snd\\max.mp3";

            mciSendString("open \"" + m_location + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);

            mciSendString("play MediaFile", null, 0, IntPtr.Zero);

            audiostop = false;
        }
        private void stopaudio()
        {
            // to end sound
            mciSendString("close MediaFile", null, 0, IntPtr.Zero);

            audiostop = true;
        }
        #endregion

        #region Help

        // to give information if someone doesnt understand
        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbcMainSM.SelectedTab = tbpMainHelpSM;

            gbxHelpRaceSM.Visible = true;
            gbxHelpRaceSM.Width = 921;
            gbxHelpRaceSM.Height = 490;
            gbxHelpRaceSM.Left = 0;
            gbxHelpRaceSM.Top = 0;

            thiswidht();

            tmrStartScreenSM.Enabled = false;

            gbxHelpSettingsSM.Visible = false;
            gbxHelpCasinoSM.Visible = false;

            MessageBox.Show("click the outlined picture boxes for information about that item \n" +
                            "and click the next button to go to the next page");
        }

        private void pbxHelpRaceSM_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this is the race itself \nthe f1 cars are the racers and the first one over the line wins");
        }
        private void pbxhelpBtnSM_Click(object sender, EventArgs e)
        {
            MessageBox.Show("these are the start reset and again button\n" +
                "when you press the start button the racers start racing (if the settings are put in)\n" +
                "when you press the reset button everything resets (also the settings)\n" +
                "when you press the again button the racers race again with the same settings");
        }

        private void pbxHelpRankingSM_Click(object sender, EventArgs e)
        {
            MessageBox.Show("here you see the racers finished position");
        }

        private void pbxHelpStageSM_Click(object sender, EventArgs e)
        {
            MessageBox.Show("here are the racers placed when they finish (first one to finish on gold extra)");
        }

        private void pbxHelpDrawSM_Click(object sender, EventArgs e)
        {
            MessageBox.Show("here you can see the racers their speeds\n (this is only seen in and after the race)");
        }

        private void pbxHelpTimeSM_Click(object sender, EventArgs e)
        {
            MessageBox.Show("here you can see the race time");
        }
        private void btnToSettingsSM_Click(object sender, EventArgs e)
        {
            gbxHelpRaceSM.Visible = false;
            gbxHelpRaceSM.Width = 50;
            gbxHelpRaceSM.Height = 50;
            gbxHelpRaceSM.Left = 400;

            gbxHelpSettingsSM.Visible = true;
            gbxHelpSettingsSM.Width = 918; 
            gbxHelpSettingsSM.Height = 487;
            gbxHelpSettingsSM.Left = 0;
            gbxHelpSettingsSM.Top = 0;

            
        }
        private void pbxHelpSpeedSM_Click(object sender, EventArgs e)
        {
            MessageBox.Show("here you can chose the min speed (the slowest they can go)\n" +
                "and the max speed (the fastest they can go)");
        }

        private void pbxHelpSetupSM_Click(object sender, EventArgs e)
        {
            MessageBox.Show("here they have been given a random speed\n" +
                "and a collor (this is to see their speed on the race tab)");
        }

        private void pbxHelpSloggingSM_Click(object sender, EventArgs e)
        {
            MessageBox.Show("here you can see who won and what to do if you do something that isnt the thing you are suppost to do (this is only on the settings tab)");
        }
        private void btnToCasinoSM_Click(object sender, EventArgs e)
        {
            gbxHelpSettingsSM.Visible = false;
            gbxHelpSettingsSM.Width = 50;
            gbxHelpSettingsSM.Height = 50;
            gbxHelpSettingsSM.Left = 400;

            gbxHelpCasinoSM.Visible = true;
            gbxHelpCasinoSM.Width = 921; 
            gbxHelpCasinoSM.Height = 490;
            gbxHelpCasinoSM.Left = 0;
            gbxHelpCasinoSM.Top = 0;
        }
        private void pbxHelpCloggingSM_Click(object sender, EventArgs e)
        {
            MessageBox.Show("here you can see if you won and what you can and cant do");
        }

        private void pbxHelpCoinsSM_Click(object sender, EventArgs e)
        {
            MessageBox.Show("here you see your amount of coins");
        }

        private void pbxHelpBetSM_Click(object sender, EventArgs e)
        {
            MessageBox.Show("here you can bet on racers with your coins and see who you betted on");
        }

        private void pbxHelpWonSM_Click(object sender, EventArgs e)
        {
            MessageBox.Show("here you can see how much you lost and won");
        }

        private void pbxHelpRouletteSM_Click(object sender, EventArgs e)
        {
            MessageBox.Show("here you can play roulette by putting coins in on the number that is going to win)");
        }

        private void btnToRaceSM_Click(object sender, EventArgs e)
        {
            gbxHelpCasinoSM.Visible = false;
            gbxHelpCasinoSM.Width = 50;
            gbxHelpCasinoSM.Height = 50;
            gbxHelpCasinoSM.Left = 400;

            tbcMainSM.SelectedTab = tbpMainRaceSM;
        }
        #endregion

        #region casino

        Random generateRandomValue = new Random();

        int casinoCoins = 50;
        int casinoBet1Coins = 0;
        int casinoBet2Coins = 0;
        int casinoBet3Coins = 0;
        int casinoBet4Coins = 0;
        int betsWon = 0;
        int betsLost = 0;

        bool casinoBetting1 = false;
        bool casinoBetting2 = false;
        bool casinoBetting3 = false;
        bool casinoBetting4 = false;

        int rouletteMax = 37;
        int rouletteNumber = 1;
        int rouletteInterval = 1;
        int rouletteBet = 0;
        int rouletteTiles = 0;

        int roulettechoise = 0;
        int rouletteBet1 = 37;
        int rouletteBet2 = 37;
        int rouletteBet3 = 37;
        int rouletteBet4 = 37;
        int rouletteBet5 = 37;
        int rouletteInzet = 0;
        int rouletteInzet1 = 0;
        int rouletteInzet2 = 0;
        int rouletteInzet3 = 0;
        int rouletteInzet4 = 0;
        int rouletteInzet5 = 0;

        //casion part
        private void btnBet1SM_Click(object sender, EventArgs e)
        {
            try
            {
                casinoBet1Coins = Convert.ToInt32(tbxBet1SM.Text);

                if(casinoBet1Coins <= 0 )
                {
                    MessageBox.Show("please use a higher number");
                    loggingCasino(Color.Black, "please use a higher number");
                }
                else if(casinoBet1Coins > casinoCoins) 
                {
                    MessageBox.Show("please use a lower number");
                    loggingCasino(Color.Black, "please use a lower number");
                }
                else if (casinoBetting2 == true || casinoBetting2 == true || casinoBetting3 == true)
                {
                    MessageBox.Show("you can only bet once");
                    loggingCasino(Color.Black, "you can only bet once");
                }
                else if (casinoBetting1 == true)
                {
                    MessageBox.Show("you can only bet once");
                    loggingCasino(Color.Black, "you can only bet once");
                }
                else
                {
                    casinoCoins = casinoCoins - casinoBet1Coins;

                    lblCoinsSM.Text = casinoCoins.ToString();

                    casinoBetting1 = true;

                    lblBettingOnSM.Text = "racer 1";

                }
            }
            catch
            {
                MessageBox.Show("please only use numbers");
                loggingCasino(Color.Black, "please only use numbers");
            }
        }

        private void btnBet2SM_Click(object sender, EventArgs e)
        {
            try
            {
                casinoBet2Coins = Convert.ToInt32(tbxBet2SM.Text);

                if (casinoBet2Coins <= 0)
                {
                    MessageBox.Show("please use a higher number");
                    loggingCasino(Color.Black, "please use a higher number");
                }
                else if (casinoBet2Coins > casinoCoins)
                {
                    MessageBox.Show("please use a lower number");
                    loggingCasino(Color.Black, "please use a lower number");
                }
                else if (casinoBetting1 == true || casinoBetting3 == true || casinoBetting3 == true)
                {
                    MessageBox.Show("you can only bet once");
                    loggingCasino(Color.Black, "you can only bet once");
                }
                else if (casinoBetting2 == true)
                {
                    MessageBox.Show("you can only bet once");
                    loggingCasino(Color.Black, "you can only bet once");
                }
                else
                {
                    casinoCoins = casinoCoins - casinoBet2Coins;

                    lblCoinsSM.Text = casinoCoins.ToString();

                    casinoBetting2 = true;

                    lblBettingOnSM.Text = "racer 2";

                }
            }
            catch
            {
                MessageBox.Show("please only use numbers");
                loggingCasino(Color.Black, "please only use numbers");
            }
        }

        private void btnBet3SM_Click(object sender, EventArgs e)
        {
            try
            {
                casinoBet3Coins = Convert.ToInt32(tbxBet3SM.Text);

                if (casinoBet3Coins <= 0)
                {
                    MessageBox.Show("please use a higher number");
                    loggingCasino(Color.Black, "please use a higher number");
                }
                else if (casinoBet3Coins > casinoCoins)
                {
                    MessageBox.Show("please use a lower number");
                    loggingCasino(Color.Black, "please use a lower number");
                }
                else if (casinoBetting1 == true || casinoBetting2 == true || casinoBetting4 == true)
                {
                    MessageBox.Show("you can only bet once");
                    loggingCasino(Color.Black, "you can only bet once");
                }
                else if (casinoBetting3 == true)
                {
                    MessageBox.Show("you can only bet once");
                    loggingCasino(Color.Black, "you can only bet once");
                }
                else
                {
                    casinoCoins = casinoCoins - casinoBet3Coins;

                    lblCoinsSM.Text = casinoCoins.ToString();

                    casinoBetting3 = true;

                    lblBettingOnSM.Text = "racer 3";

                }
            }
            catch
            {
                MessageBox.Show("please only use numbers");
                loggingCasino(Color.Black, "please only use numbers");
            }
        }

        private void btnBet4SM_Click(object sender, EventArgs e)
        {
            try
            {
                casinoBet4Coins = Convert.ToInt32(tbxBet4SM.Text);

                if (casinoBet4Coins <= 0)
                {
                    MessageBox.Show("please use a higher number");
                    loggingCasino(Color.Black, "please use a higher number");
                }
                else if (casinoBet4Coins > casinoCoins)
                {
                    MessageBox.Show("please use a lower number");
                    loggingCasino(Color.Black, "please use a lower number");
                }
                else if (casinoBetting1 == true || casinoBetting2 == true || casinoBetting3 == true)
                {
                    MessageBox.Show("you can only bet once");
                    loggingCasino(Color.Black, "you can only bet once");
                }
                else if (casinoBetting4 == true)
                {
                    MessageBox.Show("you can only bet once");
                }
                else
                {
                    casinoCoins = casinoCoins - casinoBet4Coins;

                    lblCoinsSM.Text = casinoCoins.ToString();

                    casinoBetting4 = true;

                    lblBettingOnSM.Text = "racer 4";

                }
            }
            catch
            {
                MessageBox.Show("please only use numbers");
                loggingCasino(Color.Black, "please only use numbers");
            }
        }

        void betWon()
        {
            betsWon = Convert.ToInt32(lblBetsWonSM.Text);
            betsWon++;
            lblBetsWonSM.Text = betsWon.ToString();
        }

        void betLost()
        {
            betsLost = Convert.ToInt32(lblBetsLostSM.Text);
            betsLost++;
            lblBetsLostSM.Text = betsLost.ToString();
        }

        private void tmrRoulette_Tick(object sender, EventArgs e)
        {
            rouletteInterval = rouletteInterval + 10;
            tmrRouletteSM.Interval = rouletteInterval;

            lblRoulette0SM.Visible = false;
            lblRoulette1SM.Visible = false;
            lblRoulette2SM.Visible = false;
            lblRoulette3SM.Visible = false;
            lblRoulette4SM.Visible = false;
            lblRoulette5SM.Visible = false;
            lblRoulette6SM.Visible = false;
            lblRoulette7SM.Visible = false;
            lblRoulette8SM.Visible = false;
            lblRoulette9SM.Visible = false;
            lblRoulette10SM.Visible = false;
            lblRoulette11SM.Visible = false;
            lblRoulette12SM.Visible = false;
            lblRoulette13SM.Visible = false;
            lblRoulette14SM.Visible = false;
            lblRoulette15SM.Visible = false;
            lblRoulette16SM.Visible = false;
            lblRoulette17SM.Visible = false;
            lblRoulette18SM.Visible = false;
            lblRoulette19SM.Visible = false;
            lblRoulette20SM.Visible = false;
            lblRoulette21SM.Visible = false;
            lblRoulette22SM.Visible = false;
            lblRoulette23SM.Visible = false;
            lblRoulette24SM.Visible = false;
            lblRoulette25SM.Visible = false;
            lblRoulette26SM.Visible = false;
            lblRoulette27SM.Visible = false;
            lblRoulette28SM.Visible = false;
            lblRoulette29SM.Visible = false;
            lblRoulette30SM.Visible = false;
            lblRoulette31SM.Visible = false;
            lblRoulette32SM.Visible = false;
            lblRoulette33SM.Visible = false;
            lblRoulette34SM.Visible = false;
            lblRoulette35SM.Visible = false;
            lblRoulette36SM.Visible = false;

            rouletteNumber = generateRandomValue.Next(rouletteMax);
            if (rouletteNumber == 0)
            {
                lblRoulette0SM.Visible = true;
            }
            else if(rouletteNumber == 1)
            {
                lblRoulette1SM.Visible = true;
            }
            else if(rouletteNumber == 2)
            {
                lblRoulette2SM.Visible = true;
            }
            else if (rouletteNumber == 3)
            {
                lblRoulette3SM.Visible = true;
            }
            else if (rouletteNumber == 4)
            {
                lblRoulette4SM.Visible = true;
            }
            else if (rouletteNumber == 5)
            {
                lblRoulette5SM.Visible = true;
            }
            else if (rouletteNumber == 6)
            {
                lblRoulette6SM.Visible = true;
            }
            else if (rouletteNumber == 7)
            {
                lblRoulette7SM.Visible = true;
            }
            else if (rouletteNumber == 8)
            {
                lblRoulette8SM.Visible = true;
            }
            else if (rouletteNumber == 9)
            {
                lblRoulette9SM.Visible = true;
            }
            else if (rouletteNumber == 10)
            {
                lblRoulette10SM.Visible = true;
            }
            else if (rouletteNumber == 11)
            {
                lblRoulette11SM.Visible = true;
            }
            else if (rouletteNumber == 12)
            {
                lblRoulette12SM.Visible = true;
            }
            else if (rouletteNumber == 13)
            {
                lblRoulette13SM.Visible = true;
            }
            else if (rouletteNumber == 14)
            {
                lblRoulette14SM.Visible = true;
            }
            else if (rouletteNumber == 15)
            {
                lblRoulette15SM.Visible = true;
            }
            else if (rouletteNumber == 16)
            {
                lblRoulette16SM.Visible = true;
            }
            else if (rouletteNumber == 17)
            {
                lblRoulette17SM.Visible = true;
            }
            else if (rouletteNumber == 18)
            {
                lblRoulette18SM.Visible = true;
            }
            else if (rouletteNumber == 19)
            {
                lblRoulette19SM.Visible = true;
            }
            else if (rouletteNumber == 20)
            {
                lblRoulette20SM.Visible = true;
            }
            else if (rouletteNumber == 21)
            {
                lblRoulette21SM.Visible = true;
            }
            else if (rouletteNumber == 22)
            {
                lblRoulette22SM.Visible = true;
            }
            else if (rouletteNumber == 23)
            {
                lblRoulette23SM.Visible = true;
            }
            else if (rouletteNumber == 24)
            {
                lblRoulette24SM.Visible = true;
            }
            else if (rouletteNumber == 25)
            {
                lblRoulette25SM.Visible = true;
            }
            else if (rouletteNumber == 26)
            {
                lblRoulette26SM.Visible = true;
            }
            else if (rouletteNumber == 27)
            {
                lblRoulette27SM.Visible = true;
            }
            else if (rouletteNumber == 28)
            {
                lblRoulette28SM.Visible = true;
            }
            else if (rouletteNumber == 29)
            {
                lblRoulette29SM.Visible = true;
            }
            else if (rouletteNumber == 30)
            {
                lblRoulette30SM.Visible = true;
            }
            else if (rouletteNumber == 31)
            {
                lblRoulette31SM.Visible = true;
            }
            else if (rouletteNumber == 32)
            {
                lblRoulette32SM.Visible = true;
            }
            else if (rouletteNumber == 33)
            {
                lblRoulette33SM.Visible = true;
            }
            else if (rouletteNumber == 34)
            {
                lblRoulette34SM.Visible = true;
            }
            else if (rouletteNumber == 35)
            {
                lblRoulette35SM.Visible = true;
            }
            else if (rouletteNumber == 36)
            {
                lblRoulette36SM.Visible = true;
            }

            if (rouletteInterval > 500)
            {
                tmrRouletteSM.Enabled = false;

                if (rouletteNumber == rouletteBet1)
                {
                    MessageBox.Show("you won");
                    loggingCasino(Color.Black, "you won");

                    gbxrouletteSM.Enabled = true;
                    btnRouletteGoSM.Enabled = true;

                    casinoCoins = casinoCoins + rouletteInzet1 * 20;

                    lblCoinsSM.Text = casinoCoins.ToString();

                    betWon();

                    rouletteReset();
                }
                else if (rouletteNumber == rouletteBet2)
                {
                    MessageBox.Show("you won");
                    loggingCasino(Color.Gold, "you won");

                    gbxrouletteSM.Enabled = true;
                    btnRouletteGoSM.Enabled = true;

                    casinoCoins = casinoCoins + rouletteInzet2 * 20;

                    lblCoinsSM.Text = casinoCoins.ToString();

                    betWon();

                    rouletteReset();
                }
                else if (rouletteNumber == rouletteBet3)
                {
                    MessageBox.Show("you won");
                    loggingCasino(Color.Gold, "you won");

                    gbxrouletteSM.Enabled = true;
                    btnRouletteGoSM.Enabled = true;

                    casinoCoins = casinoCoins + rouletteInzet3 * 20;

                    lblCoinsSM.Text = casinoCoins.ToString();

                    betWon();

                    rouletteReset();
                }
                else if (rouletteNumber == rouletteBet4)
                {
                    MessageBox.Show("you won");
                    loggingCasino(Color.Gold, "you won");

                    gbxrouletteSM.Enabled = true;
                    btnRouletteGoSM.Enabled = true;

                    casinoCoins = casinoCoins + rouletteInzet4 * 20;

                    lblCoinsSM.Text = casinoCoins.ToString();

                    betWon();

                    rouletteReset();
                }
                else if (rouletteNumber == rouletteBet5)
                {
                    MessageBox.Show("you won");
                    loggingCasino(Color.Gold, "you won");

                    gbxrouletteSM.Enabled = true;
                    btnRouletteGoSM.Enabled = true;

                    casinoCoins = casinoCoins + rouletteInzet5 * 20;

                    lblCoinsSM.Text = casinoCoins.ToString();

                    betWon();

                    rouletteReset();
                }
                else
                {
                    MessageBox.Show("you lost");
                    loggingCasino(Color.Red, "you lost");

                    gbxrouletteSM.Enabled = true;
                    btnRouletteGoSM.Enabled = true;

                    betLost();

                    rouletteReset();
                }
            }
        }

        void rouletteReset()
        {
            lblRoulette0SM.Visible = true;
            lblRoulette1SM.Visible = true;
            lblRoulette2SM.Visible = true;
            lblRoulette3SM.Visible = true;
            lblRoulette4SM.Visible = true;
            lblRoulette5SM.Visible = true;
            lblRoulette6SM.Visible = true;
            lblRoulette7SM.Visible = true;
            lblRoulette8SM.Visible = true;
            lblRoulette9SM.Visible = true;
            lblRoulette10SM.Visible = true;
            lblRoulette11SM.Visible = true;
            lblRoulette12SM.Visible = true;
            lblRoulette13SM.Visible = true;
            lblRoulette14SM.Visible = true;
            lblRoulette15SM.Visible = true;
            lblRoulette16SM.Visible = true;
            lblRoulette17SM.Visible = true;
            lblRoulette18SM.Visible = true;
            lblRoulette19SM.Visible = true;
            lblRoulette20SM.Visible = true;
            lblRoulette21SM.Visible = true;
            lblRoulette22SM.Visible = true;
            lblRoulette23SM.Visible = true;
            lblRoulette24SM.Visible = true;
            lblRoulette25SM.Visible = true;
            lblRoulette26SM.Visible = true;
            lblRoulette27SM.Visible = true;
            lblRoulette28SM.Visible = true;
            lblRoulette29SM.Visible = true;
            lblRoulette30SM.Visible = true;
            lblRoulette31SM.Visible = true;
            lblRoulette32SM.Visible = true;
            lblRoulette33SM.Visible = true;
            lblRoulette34SM.Visible = true;
            lblRoulette35SM.Visible = true;
            lblRoulette36SM.Visible = true;

            rouletteBet1 = 37;
            rouletteBet2 = 37;
            rouletteBet3 = 37;
            rouletteBet4 = 37;
            rouletteBet5 = 37;

            rouletteInzet1 = -1;
            rouletteInzet2 = -1;
            rouletteInzet3 = -1;
            rouletteInzet4 = -1;
            rouletteInzet5 = -1;

            rouletteInterval = 1;

            rouletteTiles = 0;

            rouletteFalse();
        }

        void rouletteFalse()
        {
            rbnRoulette0SM.Checked = false;
            rbnRoulette1SM.Checked = false;
            rbnRoulette2SM.Checked = false;
            rbnRoulette3SM.Checked = false;
            rbnRoulette4SM.Checked = false;
            rbnRoulette5SM.Checked = false;
            rbnRoulette6SM.Checked = false;
            rbnRoulette7SM.Checked = false;
            rbnRoulette8SM.Checked = false;
            rbnRoulette9SM.Checked = false;
            rbnRoulette10SM.Checked = false;
            rbnRoulette11SM.Checked = false;
            rbnRoulette12SM.Checked = false;
            rbnRoulette13SM.Checked = false;
            rbnRoulette14SM.Checked = false;
            rbnRoulette15SM.Checked = false;
            rbnRoulette16SM.Checked = false;
            rbnRoulette17SM.Checked = false;
            rbnRoulette18SM.Checked = false;
            rbnRoulette19SM.Checked = false;
            rbnRoulette20SM.Checked = false;
            rbnRoulette21SM.Checked = false;
            rbnRoulette22SM.Checked = false;
            rbnRoulette23SM.Checked = false;
            rbnRoulette24SM.Checked = false;
            rbnRoulette25SM.Checked = false;
            rbnRoulette26SM.Checked = false;
            rbnRoulette27SM.Checked = false;
            rbnRoulette28SM.Checked = false;
            rbnRoulette29SM.Checked = false;
            rbnRoulette30SM.Checked = false;
            rbnRoulette31SM.Checked = false;
            rbnRoulette32SM.Checked = false;
            rbnRoulette33SM.Checked = false;
            rbnRoulette34SM.Checked = false;
            rbnRoulette35SM.Checked = false;
            rbnRoulette36SM.Checked = false;

            rouletteTiles = 0;
        }
        void rouletteBack()
        {
            if(rouletteInzet1 != -1)
            {
                casinoCoins = casinoCoins + rouletteInzet1;
                lblCoinsSM.Text = casinoCoins.ToString();
            }
            if (rouletteInzet2 != -1)
            {
                casinoCoins = casinoCoins + rouletteInzet2;
                lblCoinsSM.Text = casinoCoins.ToString();
            }
            if (rouletteInzet3 != -1)
            {
                casinoCoins = casinoCoins + rouletteInzet3;
                lblCoinsSM.Text = casinoCoins.ToString();
            }
            if (rouletteInzet4 != -1)
            {
                casinoCoins = casinoCoins + rouletteInzet4;
                lblCoinsSM.Text = casinoCoins.ToString();
            }
            if (rouletteInzet5 != -1)
            {
                casinoCoins = casinoCoins + rouletteInzet5;
                lblCoinsSM.Text = casinoCoins.ToString();
            }
        }

        private void btnRouletteGoSM_Click(object sender, EventArgs e)
        {
            try
            {               
                tmrRouletteSM.Enabled = true;
                tmrRouletteSM.Interval = rouletteInterval;

                gbxrouletteSM.Enabled = false;

                btnRouletteGoSM.Enabled = false;

            }
            catch 
            {
                MessageBox.Show("please only use numbers");
                loggingCasino(Color.Black, "please only use numbers");
            }
        }

        void rouletteRules()
        {
            try
            {
                rouletteBet = Convert.ToInt32(tbxRouletteSM.Text);

                if (rouletteBet <= 0)
                {
                    MessageBox.Show("please use a higher number");
                    loggingCasino(Color.Black, "please use a higer number");

                    rouletteBack();

                    rouletteFalse();
                }
                else if (rouletteBet > casinoCoins)
                {
                    MessageBox.Show("please use a lower posible number");
                    loggingCasino(Color.Black, "please use a posible number");

                    rouletteBack();

                    rouletteFalse();
                }
                else
                {
                    casinoCoins = casinoCoins - rouletteBet;

                    lblCoinsSM.Text = casinoCoins.ToString();
                }

                if (rouletteBet1 == 37)
                {
                    rouletteBet1 = roulettechoise;

                    rouletteInzet1 = rouletteBet;
                }
                else if (rouletteBet2 == 37)
                {
                    rouletteBet2 = roulettechoise;

                    rouletteInzet2 = rouletteBet;
                }
                else if (rouletteBet3 == 37)
                {
                    rouletteBet3 = roulettechoise;

                    rouletteInzet3 = rouletteBet;
                }
                else if (rouletteBet4 == 37)
                {
                    rouletteBet4 = roulettechoise;

                    rouletteInzet4 = rouletteBet;
                }
                else if (rouletteBet5 == 37)
                {
                    rouletteBet5 = roulettechoise;

                    rouletteInzet5 = rouletteBet;
                }
            }
            catch 
            {

                if (rbnRoulette0SM.Checked == true)
                {
                    if (tbxRouletteSM.Text == "pattje72")
                    {
                        casinoCoins = 999;
                        lblCoinsSM.Text = casinoCoins.ToString();
                    }
                    else
                    {
                        MessageBox.Show("please only use numbers");
                        loggingCasino(Color.Black, "please only use numbers");
                    }
                }
                rouletteFalse();            
            }
        }

        private void rbnRoulette1SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette1SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette1SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 1;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette2SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette2SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {

                    rbnRoulette2SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 2;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette3SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette3SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette3SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 3;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette4SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette4SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette4SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 4;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette5SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette5SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette5SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 5;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette6SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette6SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette6SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 6;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette7SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette7SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette7SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 7;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette8SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette8SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette8SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 8;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette9SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette9SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette9SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 9;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette10SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette10SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette10SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 10;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette11SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette11SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette11SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;

                }
                else
                {
                    roulettechoise = 11;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette12SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette12SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette12SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 12;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette13SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette13SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette13SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 13;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette14SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette14SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette14SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 14;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette15SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette15SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette15SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 15;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette16SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette16SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette16SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 16;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette17SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette17SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette17SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 17;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette18SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette18SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette18SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 18;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette19SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette19SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette19SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 19;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette20SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette20SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette20SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 20;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette21SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette21SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette21SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 21;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette22SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette22SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette22SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 22;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette23SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette23SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette23SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 23;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette24SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette24SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette24SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 24;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette25SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette25SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette25SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;    
                }
                else
                {
                    roulettechoise = 25;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette26SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette26SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette26SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 26;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette27SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette27SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette27SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 27;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette28SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette28SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette28SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 28;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette29SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette29SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette29SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 29;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette30SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette30SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette30SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 30;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette31SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette31SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette31SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 31;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette32SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette32SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette32SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 32;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette33SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette33SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette33SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 33;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette34SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette34SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette34SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 34;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }

        }

        private void rbnRoulette35SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette35SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette35SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 35;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette36SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette36SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette36SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 36;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }

        private void rbnRoulette0SM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRoulette0SM.Checked == true)
            {
                rouletteTiles++;

                if (rouletteTiles > 5)
                {
                    rbnRoulette0SM.Checked = false;

                    MessageBox.Show("you can only pick 5 tiles");
                    loggingCasino(Color.Black, "you can only pick 5 tiles");

                    rouletteTiles--;
                }
                else
                {
                    roulettechoise = 0;

                    rouletteRules();

                    roulettechoise = 0;
                }
            }
        }




        //end casino part
        #endregion


        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("close aplication?",
                                                   "quit?",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question))
            {
                if (DialogResult.Yes == MessageBox.Show("you sure?!",
                                                        "oimeneer",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question))
                {
                    this.Close();
                }
            }

        }
    }
}
