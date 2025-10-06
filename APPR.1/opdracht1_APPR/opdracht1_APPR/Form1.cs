using Microsoft.VisualBasic.Devices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms.VisualStyles;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace opdracht1_APPR
{
    public partial class Form1 : Form
    {
        [DllImport("winmm.dll")]

        private static extern int mciSendString(string strCommand, StringBuilder? strReturn, int iReturnLenght, IntPtr hwndCalling);

        bool audiostop;

        Random GenerateRandomValue = new Random();
        int stopatrandom = 101;
        int attemptsrandom = 21;
        int stopplayrandom = 0;
        int randomValue = 0;
        int guess = 0;
        int attempts = 0;
        int stopint = 0;
        int randomvalue2 = 0;
        int randomvalue3 = 0;
        string nickname = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // wat een leleke kleur
            this.BackColor = Color.LightBlue;
            this.Width = 324;
            this.Height = 520;
            this.Text = "Mystery Number sven";
            this.CenterToScreen();

            // to fix ugly background
            lblnicknameSM.BackColor = Color.White;

            // to have everything on its place
            pbxstartSM.Left = 12;
            pbxstartSM.Top = 12;
            btnstartSM.Left = 26;
            btnstartSM.Top = 370;
            tbxnicknameSM.Left = 98;
            tbxnicknameSM.Top = 264;
            lblnicknameSM.Left = 116;
            lblnicknameSM.Top = 244;
            lblname.Left = 6;
            lblname.Top = 0;

            // to make everything right size
            pbxstartSM.Width = 282;
            pbxstartSM.Height = 446;
            btnstartSM.Width = 252;
            btnstartSM.Height = 58;

            // to make everything invisible
            lblgameSM.Visible = false;
            lblgame2SM.Visible = false;
            lblgame3SM.Visible = false;
            gbxplaySM.Visible = false;
            gbxinformationSM.Visible = false;
            gbxsetupSM.Visible = false;
            pbxrightSM.Visible = false;
            pbxwrongSM.Visible = false;
            btnagainSM.Visible = false;
            btnstopSM.Visible = false;

            // for sound
            stopaudio();
            playTemple();

        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            try
            {
                nickname = Convert.ToString(tbxnicknameSM.Text);

                if (nickname == "")
                {
                    MessageBox.Show("please fill in a nickname");
                }
                else
                {
                    if (nickname == "pattje72")
                    {
                        this.BackColor = Color.White;
                        this.Text = "mystery number";
                    }

                    // to make things visible 
                    btnstartSM.Visible = false;
                    pbxstartSM.Visible = false;
                    tbxnicknameSM.Visible = false;
                    lblnicknameSM.Visible = false;
                    lblname.Visible = false;
                    gbxsetupSM.Visible = true;
                    gbxinformationSM.Visible = true;
                    gbxplaySM.Visible = true;

                    // to make things invisible
                    gbxplaySM.Enabled = false;

                    // to make things not useable
                    tbxstartSM.ReadOnly = true;
                    rtbinformationSM.ReadOnly = true;

                    // to make it less ugly
                    gbxinformationSM.BackColor = Color.White;
                    gbxplaySM.BackColor = Color.White;
                    gbxsetupSM.BackColor = Color.White;

                    // to set everything on its place
                    gbxsetupSM.Left = 21;
                    gbxsetupSM.Top = 19;
                    gbxplaySM.Left = 21;
                    gbxplaySM.Top = 141;
                    gbxinformationSM.Left = 21;
                    gbxinformationSM.Top = 297;

                    // to set all the buttons on their place
                    btnrandomSM.Left = 198;
                    btnrandomSM.Top = 83;
                    btngoSM.Left = 198;
                    btngoSM.Top = 38;
                    btnaboutSM.Left = 6;
                    btnaboutSM.Top = 115;
                    btnlocateSM.Left = 69;
                    btnlocateSM.Top = 115;
                    btncheatSM.Left = 137;
                    btncheatSM.Top = 115;
                    btnclearSM.Left = 200;
                    btnclearSM.Top = 115;
                    btnguessSM.Left = 96;
                    btnguessSM.Top = 41;

                    // to set all labels on their place
                    lblhotSM.Left = 200;
                    lblhotSM.Top = 119;
                    lblcoldSM.Left = 200;
                    lblcoldSM.Top = 18;
                    lblstartSM.Left = 6;
                    lblstartSM.Top = 24;
                    lblstopSM.Left = 6;
                    lblstopSM.Top = 55;
                    lblattemptsSM.Left = 6;
                    lblattemptsSM.Top = 88;
                    lblguessSM.Left = 6;
                    lblguessSM.Top = 18;
                    lblattemptsleftSM.Left = 6;
                    lblattemptsleftSM.Top = 84;
                    lblleftSM.Left = 6;
                    lblleftSM.Top = 119;
                    lblwrongSM.Left = 94;
                    lblwrongSM.Top = 119;
                    lblwrongplaySM.Left = 140;
                    lblwrongplaySM.Top = 119;
                    lblrightSM.Left = 132;
                    lblrightSM.Top = 119;
                    lblrightplaySM.Left = 169;
                    lblrightplaySM.Top = 119;
                    lbldifficultySM.Left = 197;
                    lbldifficultySM.Top = 1;

                    // to set all textboxes on their place
                    tbxguessSM.Left = 108;
                    tbxguessSM.Top = 15;
                    tbxstopSM.Left = 108;
                    tbxstopSM.Top = 52;
                    tbxstartSM.Left = 108;
                    tbxstartSM.Top = 21;

                    // to set all radiobuttons on their place
                    rbteasySM.Left = 193;
                    rbteasySM.Top = 21;
                    rbtmediumSM.Left = 216;
                    rbtmediumSM.Top = 21;
                    rbthardSM.Left = 239;
                    rbthardSM.Top = 21;

                    // to set the rest on their place
                    rtbinformationSM.Left = 4;
                    rtbinformationSM.Top = 21;
                    cbxattemptsSM.Left = 108;
                    cbxattemptsSM.Top = 83;
                    tbrtemperatureSM.Left = 200;
                    tbrtemperatureSM.Top = 41;
                    pgrattemptsSM.Left = 96;
                    pgrattemptsSM.Top = 84;

                    // to make the buttons their size
                    btngoSM.Width = 50;
                    btngoSM.Height = 45;
                    btnaboutSM.Width = 57;
                    btnaboutSM.Height = 29;
                    btnlocateSM.Width = 57;
                    btnlocateSM.Height = 29;
                    btncheatSM.Width = 57;
                    btncheatSM.Height = 29;
                    btnclearSM.Width = 57;
                    btnclearSM.Height = 29;
                    btnguessSM.Width = 93;
                    btnguessSM.Height = 37;

                    // to make textboxes their size
                    tbxguessSM.Width = 78;
                    tbxguessSM.Height = 27;
                    tbxstopSM.Width = 78;
                    tbxstopSM.Height = 27;
                    tbxstartSM.Width = 78;
                    tbxstartSM.Height = 25;

                    // to make the rest their size
                    rtbinformationSM.Width = 254;
                    rtbinformationSM.Height = 88;
                    cbxattemptsSM.Width = 79;
                    cbxattemptsSM.Height = 28;
                    tbrtemperatureSM.Width = 56;
                    tbrtemperatureSM.Height = 78;
                    pgrattemptsSM.Width = 95;
                    pgrattemptsSM.Height = 16;

                    // to make these lbl invisible
                    lblrightSM.Visible = false;
                    lblrightplaySM.Visible = false;
                }
            }
            catch
            {
                MessageBox.Show("please fill in a nickname");
            }
        }

        private void btngo_Click(object sender, EventArgs e)
        {
            // so the game doesnt crash
            try
            {
                // to make people not use to low numbers
                stopint = Convert.ToInt32(tbxstopSM.Text);
                attempts = Convert.ToInt32(cbxattemptsSM.Text);

                // to make random number
                stopplayrandom = Convert.ToInt32(tbxstopSM.Text);
                randomValue = GenerateRandomValue.Next(stopplayrandom);
                lblgameSM.Text = randomValue.ToString();

                // so people dont use to low numbers
                if (stopint < 5)
                {
                    rtbinformationSM.SelectionColor = Color.Black;
                    rtbinformationSM.AppendText("please use a higher number than 5" + "\n");
                    scrolltocaret();
                }
                // so people dont use to low numbers
                else if (attempts < 1)
                {
                    rtbinformationSM.SelectionColor = Color.Black;
                    rtbinformationSM.AppendText("please use more attempts than 0" + "\n");
                    scrolltocaret();
                }
                // if they dont have to low numbers
                else
                {
                    // if they select dificulty medium
                    if (rbtmediumSM.Checked == true)
                    {
                        randomvalue2 = GenerateRandomValue.Next(stopplayrandom);

                        // so it loops till they arent the same
                        while (randomvalue2 == randomValue)
                        {
                            randomvalue2 = GenerateRandomValue.Next(stopplayrandom);
                        }

                        // so i have a place to find it easy
                        lblgame2SM.Text = randomvalue2.ToString();

                        // to set these aside and make place for lblright and lblrightplay
                        lblwrongSM.Left = 64;
                        lblwrongSM.Top = 119;
                        lblwrongplaySM.Left = 109;
                        lblwrongplaySM.Top = 119;
                        lblrightplaySM.Visible = true;
                        lblrightSM.Visible = true;

                        // so people can see how many lives they have and have used
                        lblleftplaySM.Text = cbxattemptsSM.Text;
                        lblwrongplaySM.Text = "0";

                        // so people can use these boxes
                        gbxsetupSM.Enabled = false;
                        gbxplaySM.Enabled = true;

                        // to make the progressbars ready
                        pgrattemptsSM.Maximum = attempts;
                        pgrattemptsSM.Value = attempts;
                        pgrwrongSM.Maximum = attempts;
                        pgrplayedSM.Maximum = 100;

                        // to give them there color
                        lblcoldSM.ForeColor = Color.Blue;
                        lblhotSM.ForeColor = Color.Red;

                        // to give it its max and value
                        tbrtemperatureSM.Maximum = stopint;
                        tbrtemperatureSM.Value = stopint;

                        // to give people information
                        rtbinformationSM.SelectionColor = Color.Black;
                        rtbinformationSM.AppendText("creating 2 numbers" + "\n");
                        scrolltocaret();
                    }
                    // if they chose dificulty hard
                    else if (rbthardSM.Checked == true)
                    {
                        // create 2 more random value's 
                        randomvalue2 = GenerateRandomValue.Next(stopplayrandom);
                        randomvalue3 = GenerateRandomValue.Next(stopplayrandom);

                        // so it loops till they arent the same
                        while (randomvalue2 == randomvalue3 || randomvalue2 == randomValue || randomvalue3 == randomValue)
                        {
                            randomvalue2 = GenerateRandomValue.Next(stopplayrandom);
                            randomvalue3 = GenerateRandomValue.Next(stopplayrandom);
                        }
                        lblgame2SM.Text = randomvalue2.ToString();
                        lblgame3SM.Text = randomvalue3.ToString();

                        // to set these aside and make place for lblright and lblrightplay
                        lblwrongSM.Left = 64;
                        lblwrongSM.Top = 119;
                        lblwrongplaySM.Left = 109;
                        lblwrongplaySM.Top = 119;
                        lblrightplaySM.Visible = true;
                        lblrightSM.Visible = true;

                        // so people can see how many lives they have and have used
                        lblleftplaySM.Text = cbxattemptsSM.Text;
                        lblwrongplaySM.Text = "0";

                        // so people can use these boxes
                        gbxsetupSM.Enabled = false;
                        gbxplaySM.Enabled = true;

                        // to make the progressbar ready
                        pgrattemptsSM.Maximum = attempts;
                        pgrattemptsSM.Value = attempts;
                        pgrwrongSM.Maximum = attempts;
                        pgrplayedSM.Maximum = 100;

                        // to give them there color
                        lblcoldSM.ForeColor = Color.Blue;
                        lblhotSM.ForeColor = Color.Red;

                        // to give it its max and value
                        tbrtemperatureSM.Maximum = stopint;
                        tbrtemperatureSM.Value = stopint;

                        // to give people information
                        rtbinformationSM.SelectionColor = Color.Black;
                        rtbinformationSM.AppendText("creating 3 numbers" + "\n");
                        scrolltocaret();
                    }
                    // if they dont chose a dificulty
                    else
                    {
                        // so people can see how many lives they have and have used
                        lblleftplaySM.Text = cbxattemptsSM.Text;
                        lblwrongplaySM.Text = "0";

                        // so people can use these boxes
                        gbxsetupSM.Enabled = false;
                        gbxplaySM.Enabled = true;

                        // to make these invisible
                        lblrightSM.Visible = false;
                        lblrightplaySM.Visible = false;

                        // to make the progressbar ready
                        pgrattemptsSM.Maximum = attempts;
                        pgrattemptsSM.Value = attempts;
                        pgrwrongSM.Maximum = attempts;
                        pgrplayedSM.Maximum = 100;

                        // to set them on there place if they used a dificulty before
                        lblwrongSM.Left = 94;
                        lblwrongSM.Top = 119;
                        lblwrongplaySM.Left = 140;
                        lblwrongplaySM.Top = 119;

                        // to give them there color
                        lblcoldSM.ForeColor = Color.Blue;
                        lblhotSM.ForeColor = Color.Red;

                        // to give it its max and value
                        tbrtemperatureSM.Maximum = stopint;
                        tbrtemperatureSM.Value = stopint;

                        // to give people information
                        rtbinformationSM.SelectionColor = Color.Black;
                        rtbinformationSM.AppendText("creating a number" + "\n");
                        scrolltocaret();
                    }
                }

            }
            // if they dont use numbers
            catch
            {
                rtbinformationSM.SelectionColor = Color.Black;
                rtbinformationSM.AppendText("please only use numbers" + "\n");
                scrolltocaret();
            }
        }

        // if they click button about
        private void btnabout_Click(object sender, EventArgs e)
        {
            // to give information
            rtbinformationSM.SelectionColor = Color.Black;
            rtbinformationSM.AppendText("this is a game called mystery number put the dificulty in you want and start guessing \n");
            scrolltocaret();
        }
        // if they click button clear
        private void btnclear_Click(object sender, EventArgs e)
        {
            // to reset text
            tbxstopSM.ResetText();
            cbxattemptsSM.ResetText();
            tbxguessSM.ResetText();
            rtbinformationSM.ResetText();

            // to let them know they reset it
            rtbinformationSM.SelectionColor = Color.Black;
            rtbinformationSM.AppendText("clearing" + "\n");
            scrolltocaret();

            // to make the numbers go away or reset text
            lblgameSM.Text = "create a number first";
            lblgame2SM.Text = "create a number first";
            lblgame3SM.Text = "create a number first";
            lblleftplaySM.Text = "...";
            lblwrongplaySM.Text = "...";
            lblrightplaySM.Text = "0";

            // to enable or disable groupboxes
            gbxsetupSM.Enabled = true;
            gbxplaySM.Enabled = false;

            // to get rid of lives
            pgrattemptsSM.Maximum = 0;
            pgrwrongSM.Maximum = 0;

            // no sound
            stopaudio();
        }
        // if they clicked random number
        private void btnrandom_Click(object sender, EventArgs e)
        {
            // to make random numbers they can use in the game
            randomValue = GenerateRandomValue.Next(stopatrandom);
            tbxstopSM.Text = randomValue.ToString();

            randomValue = GenerateRandomValue.Next(attemptsrandom);
            cbxattemptsSM.Text = randomValue.ToString();

            // to give information
            rtbinformationSM.SelectionColor = Color.Black;
            rtbinformationSM.AppendText("creating random numbers" + "\n");
            scrolltocaret();
        }
        // if they click button cheat
        private void btncheat_Click(object sender, EventArgs e)
        {
            if (lblgameSM.Text == "create a number first")
            {
                // so it doesnt say "create a number first" more than once if they have medium or hard dificulty
                rtbinformationSM.SelectionColor = Color.Black;
                rtbinformationSM.AppendText(lblgameSM.Text + "\n");
                scrolltocaret();
            }
            else
            {
                if (rbtmediumSM.Checked == true)
                {
                    // if they used the medium dificulty they get both numbers
                    rtbinformationSM.SelectionColor = Color.Black;
                    rtbinformationSM.AppendText(lblgameSM.Text + "\n" + lblgame2SM.Text + "\n");
                    scrolltocaret();
                }
                else if (rbthardSM.Checked == true)
                {
                    // if they used the hard dificulty they get all numbers
                    rtbinformationSM.SelectionColor = Color.Black;
                    rtbinformationSM.AppendText(lblgameSM.Text + "\n" + lblgame2SM.Text + "\n" + lblgame3SM.Text + "\n");
                    scrolltocaret();
                }
                else
                {
                    // to give the number if they didnt chose a dificulty
                    rtbinformationSM.SelectionColor = Color.Black;
                    rtbinformationSM.AppendText(lblgameSM.Text + "\n");
                    scrolltocaret();
                }
            }

        }
        // if they presed button locate
        private void btnlocate_Click(object sender, EventArgs e)
        {
            // to give them the information
            rtbinformationSM.SelectionColor = Color.Black;
            rtbinformationSM.AppendText(Application.StartupPath + "\n");
            scrolltocaret();
        }

        private void btnguess_Click(object sender, EventArgs e)
        {
            int m_guess = 0;
            int m_awnser = 0;
            int m_minint = 0;
            int m_plusint = 0;
            int m_rightplus = 0;
            int m_played = 0;

            // so they have to use numbers
            try
            {
                m_awnser = Convert.ToInt32(lblgameSM.Text);
                m_guess = Convert.ToInt32(tbxguessSM.Text);
                guess = Convert.ToInt32(tbxguessSM.Text);

                // cheat code for fun
                if (tbxguessSM.Text == "69420")
                {
                    // sound casino
                    stopaudio();
                    playcasino();

                    // to give more lives
                    attempts = 999;
                    pgrattemptsSM.Maximum = attempts;
                    pgrattemptsSM.Value = attempts;
                    lblleftplaySM.Text = attempts.ToString();
                    pgrwrongSM.Maximum = attempts;
                    lblwrongplaySM.Text = "0";

                    // to make form color gold
                    this.BackColor = Color.Gold;

                    // to say they have more lives
                    rtbinformationSM.SelectionColor = Color.Gold;
                    rtbinformationSM.AppendText("setting lives to 999" + "\n");
                    scrolltocaret();
                    rtbinformationSM.SelectionColor = Color.Black;
                }
                // if they didnt use the cheat code
                else
                {
                    // if they gues higer then the limit
                    if (guess > stopint)
                    {
                        // to say they have to use a lower number
                        rtbinformationSM.SelectionColor = Color.Black;
                        rtbinformationSM.AppendText("please use a lower number" + "\n");
                        scrolltocaret();
                    }
                    // if they used the right number
                    else
                    {
                        // if they have a number right
                        if ((lblrightplaySM.Text == "0" && m_guess == randomValue) || (lblrightplaySM.Text == "1" && m_guess == randomvalue2) || (lblrightplaySM.Text == "2" && m_guess == randomvalue3))
                        {
                            // if they selected medium dificulty
                            if (rbtmediumSM.Checked == true)
                            {
                                // if this is the first number that they have right 
                                if (lblrightplaySM.Text == "0")
                                {
                                    // sound right
                                    stopaudio();
                                    playright();

                                    // to give the information
                                    rtbinformationSM.SelectionColor = Color.Green;
                                    rtbinformationSM.AppendText("good job" + nickname + "\n" + "the first number was: \n" + lblgameSM.Text + "\n");
                                    scrolltocaret();
                                    rtbinformationSM.SelectionColor = Color.Black;

                                    // so they know they have it right
                                    m_rightplus = 1;
                                    lblrightplaySM.Text = m_rightplus.ToString();

                                    // to make back color green
                                    this.BackColor = Color.Green;

                                    if (nickname == "pattje72")
                                    {
                                        this.BackColor = Color.White;
                                    }
                                }
                                // if this is the second number they have right last one on medium dificulty
                                else if (lblrightplaySM.Text == "1")
                                {
                                    // play right
                                    stopaudio();
                                    playright();

                                    // to say to them they have won
                                    rtbinformationSM.SelectionColor = Color.Green;
                                    rtbinformationSM.AppendText("good job " + nickname + "\n" + "the numbers were \n" + lblgameSM.Text + "\n" + lblgame2SM.Text + "\n");
                                    scrolltocaret();
                                    rtbinformationSM.SelectionColor = Color.Black;

                                    // win sound
                                    stopaudio();
                                    playTemple();

                                    // reset text
                                    tbxguessSM.ResetText();

                                    // to reset text
                                    lblgameSM.Text = "create a number first";
                                    lblgame2SM.Text = "create a number first";
                                    lblgame3SM.Text = "create a number first";
                                    lblleftplaySM.Text = "...";
                                    lblrightplaySM.Text = "0";

                                    // to enable or disable
                                    gbxsetupSM.Enabled = true;
                                    gbxplaySM.Enabled = false;

                                    // to make it cold
                                    tbrtemperatureSM.Value = stopint;

                                    // to set lives to 0
                                    pgrattemptsSM.Value = 0;
                                    lblrightplaySM.Text = "0";

                                    // to make lblplayed have higer number
                                    m_played = Convert.ToInt32(lblplayedSM.Text);
                                    m_played++;
                                    lblplayedSM.Text = m_played.ToString();
                                    pgrplayedSM.Value = m_played;

                                    // make pic visible
                                    pbxrightSM.Visible = true;

                                    // set it on right place
                                    pbxrightSM.Left = 12;
                                    pbxrightSM.Top = 12;

                                    btnagainSM.Visible = true;
                                    btnagainSM.Left = 24;
                                    btnagainSM.Top = 24;

                                    btnstopSM.Visible = true;
                                    btnstopSM.Left = 174;
                                    btnstopSM.Top = 24;


                                    if (pgrplayedSM.Value == 10)
                                    {
                                        rtbinformationSM.SelectionColor = Color.Black;
                                        rtbinformationSM.AppendText("you have played 10 games now go for 100 \n");
                                        scrolltocaret();
                                    }

                                    // to make back color green
                                    this.BackColor = Color.Green;

                                    if (nickname == "pattje72")
                                    {
                                        this.BackColor = Color.White;
                                    }
                                }
                            }
                            // if they chose hard
                            else if (rbthardSM.Checked == true)
                            {
                                // if this is the first number they have right
                                if (lblrightplaySM.Text == "0")
                                {
                                    // sound right
                                    stopaudio();
                                    playright();

                                    // to give information
                                    rtbinformationSM.SelectionColor = Color.Green;
                                    rtbinformationSM.AppendText("good job " + nickname + "\n" + "the first number was: \n" + lblgameSM.Text + "\n");
                                    scrolltocaret();
                                    rtbinformationSM.SelectionColor = Color.Black;

                                    // to say they have one right
                                    m_rightplus = 1;
                                    lblrightplaySM.Text = m_rightplus.ToString();

                                    // to make back color green
                                    this.BackColor = Color.Green;

                                    if (nickname == "pattje72")
                                    {
                                        this.BackColor = Color.White;
                                    }
                                }
                                // if this is the second number they have right
                                else if (lblrightplaySM.Text == "1")
                                {
                                    // sound right
                                    stopaudio();
                                    playright();

                                    // to give information
                                    rtbinformationSM.SelectionColor = Color.Green;
                                    rtbinformationSM.AppendText("good job " + nickname + "\n" + "the second number was: \n" + lblgame2SM.Text + "\n");
                                    scrolltocaret();
                                    rtbinformationSM.SelectionColor = Color.Black;

                                    // to say they have 2 right
                                    m_rightplus = 2;
                                    lblrightplaySM.Text = m_rightplus.ToString();

                                    // to make back color green
                                    this.BackColor = Color.Green;

                                    if (nickname == "pattje72")
                                    {
                                        this.BackColor = Color.White;
                                    }
                                }
                                // if they have 3 right last one on hard dificulty
                                else if (lblrightplaySM.Text == "2")
                                {
                                    // to give informatino
                                    rtbinformationSM.SelectionColor = Color.Green;
                                    rtbinformationSM.AppendText("good job " + nickname + "\n" + "the numbers were \n" + lblgameSM.Text + "\n" + lblgame2SM.Text + "\n" + lblgame3SM.Text + "\n");
                                    scrolltocaret();
                                    rtbinformationSM.SelectionColor = Color.Black;

                                    // win sound
                                    stopaudio();
                                    playTemple();

                                    // reset text
                                    tbxguessSM.ResetText();

                                    // reset text
                                    lblgameSM.Text = "create a number first";
                                    lblgame2SM.Text = "create a number first";
                                    lblgame3SM.Text = "create a number first";
                                    lblleftplaySM.Text = "...";
                                    lblwrongplaySM.Text = "...";
                                    lblrightplaySM.Text = "0";

                                    // to enable or disable
                                    gbxsetupSM.Enabled = true;
                                    gbxplaySM.Enabled = false;

                                    // to set it to cold
                                    tbrtemperatureSM.Value = stopint;

                                    // to make lives 0
                                    pgrattemptsSM.Value = 0;
                                    lblrightplaySM.Text = "0";

                                    // to make lblplayed have higer number
                                    m_played = Convert.ToInt32(lblplayedSM.Text);
                                    m_played++;
                                    lblplayedSM.Text = m_played.ToString();
                                    pgrplayedSM.Value = m_played;

                                    // make pic visible
                                    pbxrightSM.Visible = true;

                                    // set it on right place
                                    pbxrightSM.Left = 12;
                                    pbxrightSM.Top = 12;

                                    btnagainSM.Visible = true;
                                    btnagainSM.Left = 24;
                                    btnagainSM.Top = 24;

                                    btnstopSM.Visible = true;
                                    btnstopSM.Left = 174;
                                    btnstopSM.Top = 24;

                                    if (pgrplayedSM.Value == 10)
                                    {
                                        rtbinformationSM.SelectionColor = Color.Black;
                                        rtbinformationSM.AppendText("you have played 10 games now go for 100 \n");
                                        scrolltocaret();
                                    }

                                    // to make back color green
                                    this.BackColor = Color.Green;

                                    if (nickname == "pattje72")
                                    {
                                        this.BackColor = Color.White;
                                    }
                                }
                            }
                            // if they didnt chose a dificulty or chose easy
                            else
                            {
                                // to give information they won
                                rtbinformationSM.SelectionColor = Color.Green;
                                rtbinformationSM.AppendText("good job  " + nickname + "\n" + "the number was \n" + lblgameSM.Text + "\n");
                                scrolltocaret();
                                rtbinformationSM.SelectionColor = Color.Black;

                                // win sound
                                stopaudio();
                                playTemple();

                                // to reset text
                                tbxguessSM.ResetText();

                                // to reset text
                                lblgameSM.Text = "create a number first";
                                lblgame2SM.Text = "create a number first";
                                lblgame3SM.Text = "create a number first";
                                lblleftplaySM.Text = "...";
                                lblwrongplaySM.Text = "...";
                                lblrightplaySM.Text = "0";

                                // to enable or disable
                                gbxsetupSM.Enabled = true;
                                gbxplaySM.Enabled = false;

                                // to make cold
                                tbrtemperatureSM.Value = stopint;

                                // to set lives at 0
                                pgrattemptsSM.Value = 0;
                                lblrightplaySM.Text = "0";

                                // to make back color green
                                this.BackColor = Color.Green;

                                if (nickname == "pattje72")
                                {
                                    this.BackColor = Color.White;
                                }

                                // to make lblplayed have higer number
                                m_played = Convert.ToInt32(lblplayedSM.Text);
                                m_played++;
                                lblplayedSM.Text = m_played.ToString();
                                pgrplayedSM.Value = m_played;

                                // make pic visible
                                pbxrightSM.Visible = true;

                                // set it on right place
                                pbxrightSM.Left = 12;
                                pbxrightSM.Top = 12;

                                btnagainSM.Visible = true;
                                btnagainSM.Left = 24;
                                btnagainSM.Top = 24;

                                btnstopSM.Visible = true;
                                btnstopSM.Left = 174;
                                btnstopSM.Top = 24;

                                if (pgrplayedSM.Value == 10)
                                {
                                    rtbinformationSM.SelectionColor = Color.Black;
                                    rtbinformationSM.AppendText("you have played 10 games now go for 100 \n");
                                    scrolltocaret();
                                }
                            }
                        }
                        // if they got it wrong
                        else
                        {
                            // to get rid of one live
                            m_minint = Convert.ToInt32(lblleftplaySM.Text);
                            m_minint--;
                            lblleftplaySM.Text = m_minint.ToString();

                            // to set wrong one higher
                            m_plusint = Convert.ToInt32(lblwrongplaySM.Text);
                            m_plusint++;
                            lblwrongplaySM.Text = m_plusint.ToString();

                            // to say they lost
                            rtbinformationSM.SelectionColor = Color.Red;
                            rtbinformationSM.AppendText("Wrong try again" + "\n");
                            scrolltocaret();
                            rtbinformationSM.SelectionColor = Color.Black;

                            // to make progressbar one live less
                            pgrattemptsSM.Value--;

                            // to make progressbar one more
                            pgrwrongSM.Value = m_plusint;

                            // fail sound
                            stopaudio();
                            playfail();

                            // to make back color red
                            this.BackColor = Color.Red;

                            if (nickname == "pattje72")
                            {
                                this.BackColor = Color.White;
                            }

                            // if they have it wrong on the first number
                            if (lblrightplaySM.Text == "0" && m_awnser > m_guess)
                            {
                                // so they know how close they are
                                tbrtemperatureSM.Value = m_awnser - m_guess;
                            }
                            // if they have it wrong on the first number
                            else if (lblrightplaySM.Text == "0" && m_awnser < m_guess)
                            {
                                // so they know how close they are
                                tbrtemperatureSM.Value = m_guess - m_awnser;
                            }
                            // if they have it wrong on the second number
                            else if (lblrightplaySM.Text == "1" && (rbtmediumSM.Checked == true || rbthardSM.Checked == true) && randomvalue2 < m_guess)
                            {
                                // so they know how close they are
                                tbrtemperatureSM.Value = m_guess - randomvalue2;
                            }
                            // if they have it wrong on the second number
                            else if (lblrightplaySM.Text == "1" && (rbtmediumSM.Checked == true || rbthardSM.Checked == true) && randomvalue2 > m_guess)
                            {
                                // so they know how close they are
                                tbrtemperatureSM.Value = randomvalue2 - m_guess;
                            }
                            // if they have it wrong on the third number
                            else if (lblrightplaySM.Text == "2" && rbthardSM.Checked == true && randomvalue3 < m_guess)
                            {
                                // so they know how close they are
                                tbrtemperatureSM.Value = m_guess - randomvalue3;
                            }
                            // if they have it wrong on the third number
                            else if (lblrightplaySM.Text == "2" && rbthardSM.Checked == true && randomvalue3 > m_guess)
                            {
                                // so they know how close they are
                                tbrtemperatureSM.Value = randomvalue3 - m_guess;
                            }
                            // if they lost on easy difficulty
                            if (m_minint == 0 && rbteasySM.Checked == true)
                            {
                                // to say they lost
                                rtbinformationSM.SelectionColor = Color.Red;
                                rtbinformationSM.AppendText("game over \n");
                                scrolltocaret();
                                rtbinformationSM.SelectionColor = Color.Black;
                                rtbinformationSM.AppendText("i am sorry " + nickname + "\nthe number was \n" + lblgameSM.Text + "\n");
                                scrolltocaret();

                                // to reset text
                                tbxstopSM.ResetText();
                                cbxattemptsSM.ResetText();
                                tbxguessSM.ResetText();

                                // to reset text
                                lblgameSM.Text = "create a number first";
                                lblgame2SM.Text = "create a number first";
                                lblgame3SM.Text = "create a number first";
                                lblleftplaySM.Text = "...";
                                lblwrongplaySM.Text = "...";
                                lblrightplaySM.Text = "0";

                                // to disable or enable
                                gbxsetupSM.Enabled = true;
                                gbxplaySM.Enabled = false;

                                // to give them no lives
                                pgrattemptsSM.Value = 0;
                                pgrwrongSM.Value = 0;
                                pgrwrongSM.Value = 0;
                                lblrightplaySM.Text = "0";

                                // to make lblplayed have higer number
                                m_played = Convert.ToInt32(lblplayedSM.Text);
                                m_played++;
                                lblplayedSM.Text = m_played.ToString();
                                pgrplayedSM.Value = m_played;

                                // make pic visible
                                pbxwrongSM.Visible = true;

                                // set it on right place
                                pbxwrongSM.Left = 12;
                                pbxwrongSM.Top = 12;

                                btnagainSM.Visible = true;
                                btnagainSM.Left = 24;
                                btnagainSM.Top = 24;

                                btnstopSM.Visible = true;
                                btnstopSM.Left = 174;
                                btnstopSM.Top = 24;

                                if (pgrplayedSM.Value == 10)
                                {
                                    rtbinformationSM.SelectionColor = Color.Black;
                                    rtbinformationSM.AppendText("you have played 10 games now go for 100 \n");
                                    scrolltocaret();
                                }
                            }
                            // if they lost on medium dificulty
                            else if (m_minint == 0 && rbtmediumSM.Checked == true)
                            {
                                // to say they lost
                                rtbinformationSM.SelectionColor = Color.Red;
                                rtbinformationSM.AppendText("game over \n");
                                scrolltocaret();
                                rtbinformationSM.SelectionColor = Color.Black;
                                rtbinformationSM.AppendText("i am sorry " + nickname + "\nthe numbers were \n" + lblgameSM.Text + "\n" + lblgame2SM.Text + "\n");
                                scrolltocaret();

                                // to reset text
                                tbxstopSM.ResetText();
                                cbxattemptsSM.ResetText();
                                tbxguessSM.ResetText();

                                // to reset text
                                lblgameSM.Text = "create a number first";
                                lblgame2SM.Text = "create a number first";
                                lblgame3SM.Text = "create a number first";
                                lblleftplaySM.Text = "...";
                                lblwrongplaySM.Text = "...";
                                lblrightplaySM.Text = "0";

                                // to enable or disable
                                gbxsetupSM.Enabled = true;
                                gbxplaySM.Enabled = false;

                                // to set lives to zero
                                pgrattemptsSM.Value = 0;
                                pgrwrongSM.Value = 0;
                                lblrightplaySM.Text = "0";

                                // to make lblplayed have higer number
                                m_played = Convert.ToInt32(lblplayedSM.Text);
                                m_played++;
                                lblplayedSM.Text = m_played.ToString();
                                pgrplayedSM.Value = m_played;

                                // make pic visible
                                pbxwrongSM.Visible = true;

                                // set it on right place
                                pbxwrongSM.Left = 12;
                                pbxwrongSM.Top = 12;

                                btnagainSM.Visible = true;
                                btnagainSM.Left = 24;
                                btnagainSM.Top = 24;

                                btnstopSM.Visible = true;
                                btnstopSM.Left = 174;
                                btnstopSM.Top = 24;

                                if (pgrplayedSM.Value == 10)
                                {
                                    rtbinformationSM.SelectionColor = Color.Black;
                                    rtbinformationSM.AppendText("you have played 10 games now go for 100 \n");
                                    scrolltocaret();
                                }
                            }
                            // if they lost on hard dificulty
                            else if (m_minint == 0 && rbthardSM.Checked == true)
                            {
                                // to say they lost
                                rtbinformationSM.SelectionColor = Color.Red;
                                rtbinformationSM.AppendText("game over \n");
                                scrolltocaret();
                                rtbinformationSM.SelectionColor = Color.Black;
                                rtbinformationSM.AppendText("i am sorry " + nickname + "\nthe numbers were \n" + lblgameSM.Text + "\n" + lblgame2SM.Text + "\n" + lblgame3SM.Text + "\n");
                                scrolltocaret();

                                // to reset text
                                tbxstopSM.ResetText();
                                cbxattemptsSM.ResetText();
                                tbxguessSM.ResetText();

                                // to reset text
                                lblgameSM.Text = "create a number first";
                                lblgame2SM.Text = "create a number first";
                                lblgame3SM.Text = "create a number first";
                                lblleftplaySM.Text = "...";
                                lblwrongplaySM.Text = "...";
                                lblrightplaySM.Text = "0";

                                // to enable or disable
                                gbxsetupSM.Enabled = true;
                                gbxplaySM.Enabled = false;

                                // to set lives to 0
                                pgrattemptsSM.Value = 0;
                                pgrwrongSM.Value = 0;
                                lblrightplaySM.Text = "0";

                                // to make lblplayed have higer number
                                m_played = Convert.ToInt32(lblplayedSM.Text);
                                m_played++;
                                lblplayedSM.Text = m_played.ToString();
                                pgrplayedSM.Value = m_played;

                                // make pic visible
                                pbxwrongSM.Visible = true;

                                // set it on right place
                                pbxwrongSM.Left = 12;
                                pbxwrongSM.Top = 12;

                                btnagainSM.Visible = true;
                                btnagainSM.Left = 24;
                                btnagainSM.Top = 24;

                                btnstopSM.Visible = true;
                                btnstopSM.Left = 174;
                                btnstopSM.Top = 24;

                                if (pgrplayedSM.Value == 10)
                                {
                                    rtbinformationSM.SelectionColor = Color.Black;
                                    rtbinformationSM.AppendText("you have played 10 games now go for 100 \n");
                                    scrolltocaret();
                                }
                            }
                        }
                    }
                }
            }
            // if they didnt use numbers
            catch
            {
                // to say they didnt use numbers
                rtbinformationSM.SelectionColor = Color.Black;
                rtbinformationSM.AppendText("please use a number" + "\n");
                scrolltocaret();
            }

        }
        // if they got it wrong sound
        private void playfail()
        {
            string m_location;
            m_location = Application.StartupPath;

            m_location = m_location + "\\..\\..\\..\\snd\\failsound.mp3";

            mciSendString("open \"" + m_location + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);

            mciSendString("play Mediafile", null, 0, IntPtr.Zero);

            audiostop = false;
        }
        // if they won sound
        private void playTemple()
        {
            string m_location;
            m_location = Application.StartupPath;

            m_location += "\\..\\..\\..\\snd\\temple.aiff";

            mciSendString("open \"" + m_location + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);

            mciSendString("play MediaFile", null, 0, IntPtr.Zero);

            audiostop = false;
        }
        // if they did the cheat code
        private void playcasino()
        {
            string m_location;
            m_location = Application.StartupPath;

            m_location = m_location + "\\..\\..\\..\\snd\\casinosound.wav";

            mciSendString("open \"" + m_location + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);

            mciSendString("play MediaFile", null, 0, IntPtr.Zero);

            audiostop = false;
        }
        // if they got it right
        private void playright()
        {
            string m_location;
            m_location = Application.StartupPath;

            m_location = m_location + "\\..\\..\\..\\snd\\right.wav";

            mciSendString("open \"" + m_location + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);

            mciSendString("play MediaFile", null, 0, IntPtr.Zero);

            audiostop = false;
        }
        // to stop the sound
        private void stopaudio()
        {
            mciSendString("close MediaFile", null, 0, IntPtr.Zero);

            audiostop = true;
        }
        // so the richtextbox scrolls with them
        private void scrolltocaret()
        {
            rtbinformationSM.ScrollToCaret();
        }

        private void btnagainSM_Click(object sender, EventArgs e)
        {
            pbxrightSM.Visible = false;
            pbxwrongSM.Visible = false;
            btnagainSM.Visible = false;
            btnstopSM.Visible = false;
        }

        private void btnstopSM_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this game was made by \nsven metselaars");

            this.Close();
        }
    }
}