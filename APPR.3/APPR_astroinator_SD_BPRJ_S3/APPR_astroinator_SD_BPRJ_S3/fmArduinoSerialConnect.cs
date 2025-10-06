using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//for the Arduino Serial project
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

using APPR_Astroidinator_23SD_WstPrepSerTabs;

namespace APPR_astroinator_SD_BPRJ_S3
{
    public partial class fmArduinoSerialConnect : Form
    {
        fmLogging fmLoggingWindow = new fmLogging();

        List<csAstroid> obAstroid = new List<csAstroid>();
        List<csAstroid> obAstroidBoss = new List<csAstroid>();
        List<csPhotonTorpedo> obPhotonTorpedo = new List<csPhotonTorpedo>();
        List<csPhotonTorpedo> obPhotonTorpedo2Power = new List<csPhotonTorpedo>();
        List<csPhotonTorpedo> obPhotonTorpedoEnemy = new List<csPhotonTorpedo>();

        private delegate void SafeCallDelegate();

        Random GenerateRandomTop = new Random();
        String receivedString = "";
        String receivedStringLast = "";
        string pressedKey = "";

        int amountOfAstroids = 0;
        int astroidPlus = 0;

        int flakVertPosition = 288;
        int flakHorPosition = 58;
        int flakVertPosition2 = 212;
        int flakHorPosition2 = 58;
        int flakVertPosition2M = 302;
        int flakHorPosition2M = 1167;

        int PhotonTorpedoNr = 0;
        int PhotonTorpedoNrEnemy = 0;
        int PhotonTorpedoNr2Power = 0;

        int shotsFired = 100;

        int killCount = 0;
        int missCount = 0;
        int deathCount = 0;

        bool beGreen = false;
        bool beGreen2 = false;
        bool gothit = false;
        bool extraHeartSpawned = false;

        bool PowerUp1Active = false;
        bool PowerUp2Active = false;

        int thorpedoSpeed = 5;

        int safetime = 0;
        int suppostKillCount = 10;
        int suppostKillCountB = 10;
        int suppostKillCountM = 15;
        int suppostKillCountH = 20;
        int astroidTpTime = 0;
        int astroidShotTime = 99;
        int astroidShotTimeBoss = 99;

        int bossHitPointsB = 50;
        int bossHitPointsM = 75;
        int bossHitPointsH = 100;

        string playerName = "player";
        int highScore1 = 0;
        int highScore2 = 0;
        int highScore3 = 0;
        string playerName1 = "";
        string playerName2 = "";
        string playerName3 = "";

        bool bossGoingDown = false;

        bool endmessageSend = false;

        int explosionTime = 0;

        bool seccondPlayerActive = false;
        

        #region dkal
        public fmArduinoSerialConnect()
        {
            InitializeComponent();
        }

        private void fmArduinoSerialConnect_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;

            this.Width = 657;
            this.Height = 401;
            tbcMain.Width = 628;
            tbcMain.Height = 328;

            btnPlayAgainSM.Visible = false;

            pbxgreyheart1SM.Visible = false;
            pbxgreyheart2SM.Visible = false;
            pbxgreyheart3SM.Visible = false;
            pbxExtraHartSM.Visible = false;

            pbxPowerUp1SM.Visible = false;
            pbxPowerUp2SM.Visible = false;

            pbxSpaceShip2SM.Visible = false;
            pnlLockOnTarget2SM.Visible = false;

            btn1v1SM.Visible = false;

            InitTabs();
        }

        private void InitTabs()
        {
            //setup the tabcontrol that the tabs will not show, dirty trick but..
            tbcMain.Appearance = TabAppearance.FlatButtons;
            tbcMain.ItemSize = new Size(0, 1);
            tbcMain.SizeMode = TabSizeMode.Fixed;
            tbcMain.SelectedTab = tbpStartUpScreen;
        }

        #region Serial Handling and basics
        public void PrintLn(string a_text, string a_color)
        {
            string m_color;

            m_color = a_color.ToUpper();//eliminate a possible problem of the letter casing

            switch (a_color)
            {
                case "R": rtbLogging.SelectionColor = Color.Red; break;
                case "G": rtbLogging.SelectionColor = Color.Green; break;
                case "B": rtbLogging.SelectionColor = Color.Blue; break;
                case "Y": rtbLogging.SelectionColor = Color.Orange; break;
                default: rtbLogging.SelectionColor = Color.Black; break;
            }

            rtbLogging.AppendText(a_text + "\n");
            rtbLogging.ScrollToCaret();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnScanPortsDkal_Click(object sender, EventArgs e)
        {
            ScanComPortsDkal();

            //btnSerialPortOpenDkal.Enabled = true;
        }

        private void ScanComPortsDkal()
        {
            String[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            string m_portWithOutLastCharacter;

            if (serialPortArduinoConnection.IsOpen)
            {
                PrintLn("Connection was open. Closing..", "B");
                serialPortArduinoConnection.Close();
            }
            cbbSerialPortsDkal.Items.Clear();

            foreach (String port in ports)
            {
                if (cbSelectIfDangerShieldIsUsed.Checked == true)
                {
                    m_portWithOutLastCharacter = port.Substring(0, port.Length - 1);
                }
                else
                {
                    m_portWithOutLastCharacter = port;
                }

                cbbSerialPortsDkal.Items.Add(m_portWithOutLastCharacter);
                PrintLn("Found port:" + m_portWithOutLastCharacter.ToString(), "W");
            }

            //if (cbbBaudRateDkal.Items.Count > 0)
            //{
            //	cbbSerialPortsDkal.Text = "Select!";
            //	cbbSerialPortsDkal.Enabled = true;
            //}
            //else
            //{
            //	cbbSerialPortsDkal.Text = "N.A.";
            //	cbbSerialPortsDkal.Enabled = false;

            //	PrintLn("ERROR: no ports found!", "R");
            //}
        }

        private void btnSerialPortOpenDkal_Click(object sender, EventArgs e)
        {
            if (!serialPortArduinoConnection.IsOpen)
            {
                try
                {
                    serialPortArduinoConnection.Open();

                    serialPortArduinoConnection.RtsEnable = true;
                    serialPortArduinoConnection.DtrEnable = true;

                    Thread.Sleep(200); //wait 100 ms to open port

                    this.Text = "Main - using com port: " + cbbSerialPortsDkal.Text;
                    PrintLn("Using com port: " + cbbSerialPortsDkal.Text, "W");
                }
                catch
                {
                    //MessageBox.Show("ERROR. Please make sure that the correct port was selected, and the device, plugged in.", "Serial port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PrintLn("ERROR: Please make sure that the correct port was selected, and the device, plugged in.", "R");
                }
            }
        }

        private void cbbSerialPortsDkal_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPortArduinoConnection.PortName = cbbSerialPortsDkal.Text;

            PrintLn("Port selected: " + serialPortArduinoConnection.PortName, "W");
            PrintLn("Default baudrate: " + serialPortArduinoConnection.BaudRate.ToString(), "W");

            cbbBaudRateDkal.Text = serialPortArduinoConnection.BaudRate.ToString();

            //btnSerialPortOpenDkal.Enabled = true;
        }

        private void cbbBaudRateDkal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbBaudRateDkal.Text != "select..")
            {
                serialPortArduinoConnection.BaudRate = Convert.ToInt32(cbbBaudRateDkal.Text);
                btnSerialPortOpenDkal.Enabled = true;
                PrintLn("Selected baudrate: " + serialPortArduinoConnection.BaudRate.ToString(), "W");
            }
            else
            {
                PrintLn("ERROR: Select the correct baudrate!", "R");
            }
        }

        public void WriteArduino(string a_action)
        {
            int m_length = a_action.Length;
            char[] m_data = new char[m_length];

            String m_carriageReturn = "\r";
            char[] m_cr = new char[2];

            String m_newLine = "\n";
            char[] m_nl = new char[2];

            for (int m_index = 0; m_index < m_length; m_index++)
            {
                m_data[m_index] = Convert.ToChar(a_action[m_index]);
            }

            for (int m_index = 0; m_index < 1; m_index++)
            {
                m_cr[m_index] = Convert.ToChar(m_carriageReturn[m_index]);
            }

            for (int m_index = 0; m_index < 1; m_index++)
            {
                m_nl[m_index] = Convert.ToChar(m_newLine[m_index]);
            }

            if (serialPortArduinoConnection.IsOpen == true)
            {
                serialPortArduinoConnection.Write(m_data, 0, m_length);

                if (cbxCarriageReturn.Checked == true)
                {
                    serialPortArduinoConnection.Write(m_cr, 0, 2);
                }

                if (cbxNewLine.Checked == true)
                {
                    serialPortArduinoConnection.Write(m_nl, 0, 2);
                }

                PrintLn("Transmitted message from Main: " + a_action, "Y");
            }
            else
            {
                //MessageBox.Show("ERROR. Please make sure that the correct port was selected, and the device, plugged in.", "Serial port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PrintLn("ERROR. Please make sure that the correct port was selected, and the device, plugged in.", "R");
            }
        }
        private void serialPortArduinoConnection_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //delegate void SafeCallDelegate(long prime);
            //if (PrimeListBox.InvokeRequired)
            //{
            //	var d = new SafeCallDelegate(SendToUI);
            //	PrimeListBox.Invoke(d, new object[] { prime });
            //}
            //else
            //{
            //	PrimeListBox.Items.Add(prime.ToString());
            //}
            HandleReceivedData();
        }

        private void HandleReceivedData()
        {
            if (serialPortArduinoConnection.IsOpen)
            {
                try
                {
                    if (rtbLogging.InvokeRequired) //check if this is the same thread
                    {
                        var d = new SafeCallDelegate(HandleReceivedData);
                        rtbLogging.Invoke(d, new object[] { });//allow changes in this thread from another thread
                    }
                    else
                    {
                        receivedString = serialPortArduinoConnection.ReadLine();
                        PrintLn(receivedString, "G");
                        //receivedString = string.Empty;
                    }
                }
                catch
                {
                    PrintLn("ERROR: Time out of: " + serialPortArduinoConnection.ReadTimeout.ToString() + "ms. Data read failed", "R");
                }
            }
        }
        public string ReadArduino()
        {
            UpdateReceivedString();

            return receivedString; 
        }

        private void OldUpdateReceivedString()
        {
            if (receivedString != "")
            {
                if (receivedString != receivedStringLast)
                {
                    PrintLn(receivedString, "G");
                }


                receivedStringLast = receivedString;
            }
        }

        private void UpdateReceivedString()
        {
            if (receivedString != receivedStringLast)
            {
                PrintLn(receivedString, "G");
            }

            receivedStringLast = receivedString;
        }

        private void rtbLogging_DoubleClick(object sender, EventArgs e)
        {
            rtbLogging.Clear();
        }

        private void btClearInOutBuffer_Click(object sender, EventArgs e)
        {
            serialPortArduinoConnection.DiscardInBuffer();
            serialPortArduinoConnection.DiscardOutBuffer();

            PrintLn("IN and out buffers discarded", "B");
        }

        private void btnAboutDkal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by : Dick van Kalsbeek\n" +
                            "Initial: 14aug2020" +
                            "Last update: 27dec2022" +
                            "Information: basic application to send to and receive from Arduino",
                            "About..", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnStartApplication_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tbpSerCom;
        }
        private void msiLogging_Click(object sender, EventArgs e)
        {
            if (msiLogging.Checked)
            {
                fmLoggingWindow.Show();
                msiLogging.Text = "Logging*";
            }
            else
            {
                fmLoggingWindow.Hide();
                msiLogging.Text = "Logging";
            }
        }

        private void msiScaQuit_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Clicking OK will close the application. Since nothing is saved your work will be lost.",
                                                "Quit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void msiViewTestGround_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tbpTestGround;
            this.Width = 657;
            this.Height = 401;
            tbcMain.Width = 628; 
            tbcMain.Height = 328;
        }

        private void msiViewCustom_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tbpCustomApplication;

            this.Width = 1330;
            this.Height = 788;
            tbcMain.Width = 1294;
            tbcMain.Height = 723;
        }

        private void msiQuickGuide_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tbpQuickGuide;

            this.Width = 657;
            this.Height = 401;
            tbcMain.Width = 628;
            tbcMain.Height = 328;
        }

        private void msiViewSerialCommunication_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tbpSerCom;
            this.Width = 657;
            this.Height = 401;
            tbcMain.Width = 628;
            tbcMain.Height = 328;
        }
        #endregion

        //THIS WAY THE REGION BOUNDARIES CAN BE FOUND EASIER

        #region Test Ground

        private void btnWrite_Click(object sender, EventArgs e)
        {
            ExecuteWriteAfterEnter();
        }

        private void ExecuteWriteAfterEnter()
        {
            WriteArduino(txbWriteCustom.Text);
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            lblReturned.Text = ReadArduino();
        }


        private void btnWriteDefault_Click(object sender, EventArgs e)
        {
            String m_testText = "Test";

            WriteArduino(m_testText);
            lblSent.Text = m_testText;
        }

        private void btnResetArduino_Click(object sender, EventArgs e)
        {
            WriteArduino("Reset");
        }

        private void txbWriteCustom_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExecuteWriteAfterEnter();
            }
        }


        #endregion

        #endregion

        //THIS WAY THE REGION BOUNDARIES CAN BE FOUND EASIER

        #region Custom

        #region normal
        /// <summary>
        /// handles keyboard keys or arduino commands bassed on the timer
        /// </summary>     
        private void HandleGameKeys()
        {
            switch(pressedKey)
            {
                case "W":
                    if(flakVertPosition > pnlplayingfieldSM.Top)
                    {
                        flakVertPosition = flakVertPosition - 5;
                    }
                    break;
                case "A":
                    if(pnlplayingfieldSM.Left + 6 <= flakHorPosition)
                    {
                        flakHorPosition = flakHorPosition - 7;
                    }
                    break;
                case "S":
                    if (flakVertPosition + pbxSpaceShipSM.Height < pnlplayingfieldSM.Bottom)
                    {
                        flakVertPosition = flakVertPosition + 5;
                    }
                    break;
                case "D":
                    if (pnlplayingfieldSM.Right - pbxSpaceShipSM.Width - 7 >= flakHorPosition + pbxSpaceShipSM.Width)
                    {
                        flakHorPosition = flakHorPosition + 7;
                    }
                    break;
                default:
                    break;           
            }


            if (seccondPlayerActive == false)
            {
                switch (receivedString)
                {
                    case "W\r":
                        if (flakVertPosition > pnlplayingfieldSM.Top)
                        {
                            flakVertPosition = flakVertPosition - 5;
                        }
                        break;
                    case "A\r":
                        if (pnlplayingfieldSM.Left + 6 <= flakHorPosition)
                        {
                            flakHorPosition = flakHorPosition - 7;
                        }
                        break;
                    case "S\r":
                        if (flakVertPosition + pbxSpaceShipSM.Height < pnlplayingfieldSM.Bottom)
                        {
                            flakVertPosition = flakVertPosition + 5;
                        }
                        break;
                    case "D\r":
                        if (pnlplayingfieldSM.Right - pbxSpaceShipSM.Width - 7 >= flakHorPosition + pbxSpaceShipSM.Width)
                        {
                            flakHorPosition = flakHorPosition + 7;
                        }
                        break;
                    case "Stop\r":
                        flakHorPosition = pbxSpaceShipSM.Left;
                        flakVertPosition = pbxSpaceShipSM.Top;
                        break;
                    case "Shot\r":
                        PhotonTorpedo();
                        break;
                    case "ShotStop\r":
                        break;
                    default:
                        break;
                }
            }

            if (seccondPlayerActive == true)
            {
                switch (receivedString)
                {
                    case "W\r":
                        if (flakVertPosition2 > pnlplayingfieldSM.Top)
                        {
                            flakVertPosition2 = flakVertPosition2 - 5;
                        }
                        break;
                    case "A\r":
                        if (pnlplayingfieldSM.Left + 6 <= flakHorPosition2)
                        {
                            flakHorPosition2 = flakHorPosition2 - 7;
                        }
                        break;
                    case "S\r":
                        if (flakVertPosition2 + pbxSpaceShip2SM.Height < pnlplayingfieldSM.Bottom)
                        {
                            flakVertPosition2 = flakVertPosition2 + 5;
                        }
                        break;
                    case "D\r":
                        if (pnlplayingfieldSM.Right - pbxSpaceShip2SM.Width - 7 >= flakHorPosition2 + pbxSpaceShip2SM.Width)
                        {
                            flakHorPosition2 = flakHorPosition2 + 7;
                        }
                        break;
                    case "Stop\r":
                        flakHorPosition2 = pbxSpaceShip2SM.Left;
                        flakVertPosition2 = pbxSpaceShip2SM.Top;
                        break;
                    case "Shot\r":
                        PhotonTorpedo2();
                        break;
                    case "ShotStop\r":
                        break;
                    default:
                        break;
                }
            }

            pbxSpaceShipSM.Left = flakHorPosition;
            pbxSpaceShipSM.Top = flakVertPosition;
            pnlLockOnTargetSM.Left = pbxSpaceShipSM.Right;
            pnlLockOnTargetSM.Top = pbxSpaceShipSM.Top + pbxSpaceShipSM.Height / 2;

            pbxSpaceShip2SM.Left = flakHorPosition2;
            pbxSpaceShip2SM.Top = flakVertPosition2;
            pnlLockOnTarget2SM.Left = pbxSpaceShip2SM.Right;
            pnlLockOnTarget2SM.Top = pbxSpaceShip2SM.Top + pbxSpaceShip2SM.Height / 2;

        }

        private void FmArduinoSerialConnect_MouseClick(object sender, MouseEventArgs e)
        {
            PhotonTorpedo();
        }

        /// <summary>
        /// handles moving of flak and shoting
        /// </summary>
        private void ControleFlakFireTorpedo()
        {
            foreach(csPhotonTorpedo m_obPhotonTorpedo in obPhotonTorpedo)
            {
                m_obPhotonTorpedo.pnlPhotoTorpedo.Left = m_obPhotonTorpedo.photonTorpedoHorPos;

                m_obPhotonTorpedo.photonTorpedoHorPos = m_obPhotonTorpedo.photonTorpedoHorPos + thorpedoSpeed;

                if(m_obPhotonTorpedo.pnlPhotoTorpedo.Left == pnlplayingfieldSM.Right)
                {
                    m_obPhotonTorpedo.pnlPhotoTorpedo.Visible = false;

                    pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedo.pnlPhotoTorpedo);
                }
            }

            foreach (csPhotonTorpedo m_obPhotonTorpedoEnemy in obPhotonTorpedoEnemy)
            {
                m_obPhotonTorpedoEnemy.pnlPhotoTorpedo.Left = m_obPhotonTorpedoEnemy.photonTorpedoHorPos;

                m_obPhotonTorpedoEnemy.photonTorpedoHorPos = m_obPhotonTorpedoEnemy.photonTorpedoHorPos - thorpedoSpeed;

                if (m_obPhotonTorpedoEnemy.pnlPhotoTorpedo.Right == pnlplayingfieldSM.Left)
                {
                    m_obPhotonTorpedoEnemy.pnlPhotoTorpedo.Visible = false;
                    pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedoEnemy.pnlPhotoTorpedo);
                }
            }

            foreach (csPhotonTorpedo m_obPhotonTorpedo2Power in obPhotonTorpedo2Power)
            {
                m_obPhotonTorpedo2Power.pnlPhotoTorpedo.Left = m_obPhotonTorpedo2Power.photonTorpedoHorPos;

                m_obPhotonTorpedo2Power.photonTorpedoHorPos = m_obPhotonTorpedo2Power.photonTorpedoHorPos - thorpedoSpeed;

                if (m_obPhotonTorpedo2Power.pnlPhotoTorpedo.Right == pnlplayingfieldSM.Left)
                {
                    m_obPhotonTorpedo2Power.pnlPhotoTorpedo.Visible = false;
                    pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedo2Power.pnlPhotoTorpedo);
                }
            }
        }

        /// <summary>
        /// to shoot the photonTorpedo
        /// </summary>
        private void PhotonTorpedo()
        {
            if ((PowerUp1Active == false) && (PowerUp2Active == false))
            {
                obPhotonTorpedo.Add(new csPhotonTorpedo(pbxSpaceShipSM.Top, pbxSpaceShipSM.Height, pbxSpaceShipSM.Right));
                CreateTorpedo();
            }

            if (PowerUp1Active == true)
            {
                obPhotonTorpedo.Add(new csPhotonTorpedo(pbxSpaceShipSM.Top, pbxSpaceShipSM.Height, pbxSpaceShipSM.Right));
                CreateTorpedo();

                obPhotonTorpedo.Add(new csPhotonTorpedo(pbxSpaceShipSM.Top - pbxSpaceShipSM.Height, pbxSpaceShipSM.Height, pbxSpaceShipSM.Right));
                CreateTorpedo();

                obPhotonTorpedo.Add(new csPhotonTorpedo(pbxSpaceShipSM.Top + pbxSpaceShipSM.Height, pbxSpaceShipSM.Height, pbxSpaceShipSM.Right));
                CreateTorpedo();
            }

            if (PowerUp2Active == true)
            {
                obPhotonTorpedo.Add(new csPhotonTorpedo(pbxSpaceShipSM.Top, pbxSpaceShipSM.Height, pbxSpaceShipSM.Right));
                CreateTorpedo();

                obPhotonTorpedo2Power.Add(new csPhotonTorpedo(pbxSpaceShipSM.Top, pbxSpaceShipSM.Height, pbxSpaceShipSM.Left));
                pnlplayingfieldSM.Controls.Add(obPhotonTorpedo2Power[PhotonTorpedoNr2Power].pnlPhotoTorpedo);

                obPhotonTorpedo2Power[PhotonTorpedoNr2Power].GeneratePhotonTorpedo();

                PhotonTorpedoNr2Power++;

                missCount++;
            }

            lblMissCountSM.Text = missCount.ToString();

        }

        private void PhotonTorpedo2()
        {
            if ((PowerUp1Active == false) && (PowerUp2Active == false))
            {
                obPhotonTorpedo.Add(new csPhotonTorpedo(pbxSpaceShip2SM.Top, pbxSpaceShip2SM.Height, pbxSpaceShip2SM.Right));
                CreateTorpedo();
            }

            if (PowerUp1Active == true)
            {
                obPhotonTorpedo.Add(new csPhotonTorpedo(pbxSpaceShip2SM.Top, pbxSpaceShip2SM.Height, pbxSpaceShip2SM.Right));
                CreateTorpedo();

                obPhotonTorpedo.Add(new csPhotonTorpedo(pbxSpaceShip2SM.Top - pbxSpaceShip2SM.Height, pbxSpaceShip2SM.Height, pbxSpaceShip2SM.Right));
                CreateTorpedo();

                obPhotonTorpedo.Add(new csPhotonTorpedo(pbxSpaceShip2SM.Top + pbxSpaceShip2SM.Height, pbxSpaceShip2SM.Height, pbxSpaceShip2SM.Right));
                CreateTorpedo();
            }

            if (PowerUp2Active == true)
            {
                obPhotonTorpedo.Add(new csPhotonTorpedo(pbxSpaceShip2SM.Top, pbxSpaceShip2SM.Height, pbxSpaceShip2SM.Right));
                CreateTorpedo();

                obPhotonTorpedo2Power.Add(new csPhotonTorpedo(pbxSpaceShip2SM.Top, pbxSpaceShip2SM.Height, pbxSpaceShip2SM.Left));
                pnlplayingfieldSM.Controls.Add(obPhotonTorpedo2Power[PhotonTorpedoNr2Power].pnlPhotoTorpedo);

                obPhotonTorpedo2Power[PhotonTorpedoNr2Power].GeneratePhotonTorpedo();

                PhotonTorpedoNr2Power++;

                missCount++;
            }

            lblMissCountSM.Text = missCount.ToString();

        }

        private void CreateTorpedo()
        {
            pnlplayingfieldSM.Controls.Add(obPhotonTorpedo[PhotonTorpedoNr].pnlPhotoTorpedo);

            obPhotonTorpedo[PhotonTorpedoNr].GeneratePhotonTorpedo();

            PhotonTorpedoNr++;

            missCount++;
        }

        /// <summary>
        /// detects colision bassed on c# function intersectswith and bounts
        /// </summary>
        private void HitDetector()
        {
            if (rbnBronzeSM.Checked == true)
            {
                foreach (csPhotonTorpedo m_obPhotonTorpedo in obPhotonTorpedo)
                {
                    foreach (csAstroid m_obAstroidBoss in obAstroidBoss)
                    {
                        if (m_obPhotonTorpedo.pnlPhotoTorpedo.Bounds.IntersectsWith(m_obAstroidBoss.pbxAstroid.Bounds))
                        {
                            if (m_obAstroidBoss.pbxAstroid.Visible == true && m_obPhotonTorpedo.pnlPhotoTorpedo.Visible == true)
                            {
                                killCount++;
                                missCount--;

                                bossHitPointsB--;

                                m_obPhotonTorpedo.pnlPhotoTorpedo.Visible = false;

                                m_obPhotonTorpedo.pnlPhotoTorpedo.Left = 2000;

                                pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedo.pnlPhotoTorpedo);

                                if (bossHitPointsB == 25)
                                {
                                    foreach (csAstroid m_obAstroid in obAstroid)
                                    {
                                        astroidPlus++;
                                        if (astroidPlus <= amountOfAstroids)
                                        {
                                            m_obAstroid.pbxAstroid.Visible = true;

                                            m_obAstroid.GenerateAstroidPosition();
                                        }
                                        else
                                        {
                                            m_obAstroid.pbxAstroid.Visible = false;
                                        }
                                    }
                                    astroidPlus = 0;
                                }

                                if (bossHitPointsB == 0)
                                {
                                    m_obAstroidBoss.pbxAstroid.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
            else if (rbnSilverSM.Checked == true)
            {
                foreach (csPhotonTorpedo m_obPhotonTorpedo in obPhotonTorpedo)
                {
                    foreach (csAstroid m_obAstroidBoss in obAstroidBoss)
                    {
                        if (m_obPhotonTorpedo.pnlPhotoTorpedo.Bounds.IntersectsWith(m_obAstroidBoss.pbxAstroid.Bounds))
                        {
                            if (m_obAstroidBoss.pbxAstroid.Visible == true && m_obPhotonTorpedo.pnlPhotoTorpedo.Visible == true)
                            {
                                killCount++;
                                missCount--;

                                bossHitPointsM--;

                                m_obPhotonTorpedo.pnlPhotoTorpedo.Visible = false;

                                m_obPhotonTorpedo.pnlPhotoTorpedo.Left = 2000;

                                pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedo.pnlPhotoTorpedo);

                                if (bossHitPointsM == 37)
                                {
                                    foreach (csAstroid m_obAstroid in obAstroid)
                                    {
                                            astroidPlus++;
                                            if (astroidPlus <= amountOfAstroids)
                                            {
                                                m_obAstroid.pbxAstroid.Visible = true;

                                                m_obAstroid.GenerateAstroidPosition();
                                            }
                                            else
                                            {
                                                m_obAstroid.pbxAstroid.Visible = false;
                                            }
                                    }
                                    astroidPlus = 0;
                                }

                                if (bossHitPointsM == 0)
                                {
                                    m_obAstroidBoss.pbxAstroid.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
            else if (rbnGoldSM.Checked == true)
            {
                foreach (csPhotonTorpedo m_obPhotonTorpedo in obPhotonTorpedo)
                {
                    foreach (csAstroid m_obAstroidBoss in obAstroidBoss)
                    {
                        if (m_obPhotonTorpedo.pnlPhotoTorpedo.Bounds.IntersectsWith(m_obAstroidBoss.pbxAstroid.Bounds))
                        {
                            if (m_obAstroidBoss.pbxAstroid.Visible == true && m_obPhotonTorpedo.pnlPhotoTorpedo.Visible == true)
                            {
                                killCount++;
                                missCount--;

                                bossHitPointsH--;

                                m_obPhotonTorpedo.pnlPhotoTorpedo.Visible = false;

                                m_obPhotonTorpedo.pnlPhotoTorpedo.Left = 2000;

                                pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedo.pnlPhotoTorpedo);

                                if (bossHitPointsH == 50)
                                {
                                    foreach (csAstroid m_obAstroid in obAstroid)
                                    {

                                            astroidPlus++;
                                            if (astroidPlus <= amountOfAstroids)
                                            {
                                                m_obAstroid.pbxAstroid.Visible = true;

                                                m_obAstroid.GenerateAstroidPosition();
                                            }
                                            else
                                            {
                                                m_obAstroid.pbxAstroid.Visible = false;
                                            }

                                    }
                                    astroidPlus = 0;
                                }

                                if (bossHitPointsH == 0)
                                {
                                    m_obAstroidBoss.pbxAstroid.Visible = false;
                                }
                            }
                        }
                    }
                }
            }

            foreach (csPhotonTorpedo m_obPhotonTorpedo in obPhotonTorpedo)
            {
                foreach (csAstroid m_obAstroid in obAstroid)
                {
                    if(m_obPhotonTorpedo.pnlPhotoTorpedo.Bounds.IntersectsWith(m_obAstroid.pbxAstroid.Bounds))
                    {
                        if ((m_obAstroid.pbxAstroid.Visible == true) && (m_obPhotonTorpedo.pnlPhotoTorpedo.Visible == true) && (m_obAstroid.pbxAstroid.BackColor == Color.Lime))
                        {
                            killCount++;
                            missCount--;

                            explosion(m_obAstroid);

                            m_obPhotonTorpedo.pnlPhotoTorpedo.Visible = false;

                            m_obPhotonTorpedo.pnlPhotoTorpedo.Left = 2000;

                            pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedo.pnlPhotoTorpedo);
                        }
                    }
                    lblKillCountSM.Text = killCount.ToString();
                }
            }

            foreach (csPhotonTorpedo m_obPhotonTorpedo2Power in obPhotonTorpedo2Power)
            {
                foreach (csAstroid m_obAstroid in obAstroid)
                {
                    if(m_obPhotonTorpedo2Power.pnlPhotoTorpedo.Bounds.IntersectsWith(m_obAstroid.pbxAstroid.Bounds))
                    {
                        if(m_obAstroid.pbxAstroid.Visible == true && m_obPhotonTorpedo2Power.pnlPhotoTorpedo.Visible == true)
                        {
                            killCount++;
                            missCount--;

                            explosion(m_obAstroid);

                            m_obAstroid.pbxAstroid.Visible = false;

                            m_obPhotonTorpedo2Power.pnlPhotoTorpedo.Visible = false;

                            m_obPhotonTorpedo2Power.pnlPhotoTorpedo.Left = 2000;

                            pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedo2Power.pnlPhotoTorpedo);
                        }
                    }
                }
            }

            foreach (csAstroid m_obAstroid in obAstroid)
            {
                if((m_obAstroid.pbxAstroid.Bottom > pnlLockOnTargetSM.Bottom) && (m_obAstroid.pbxAstroid.Top < pnlLockOnTargetSM.Bottom) && 
                   (pnlLockOnTargetSM.Left < m_obAstroid.pbxAstroid.Left) && (m_obAstroid.pbxAstroid.Visible == true))
                {
                    pnlLockOnTargetSM.BackColor = Color.Green;
                    beGreen = true;
                }
                else if (beGreen == false)
                {
                    pnlLockOnTargetSM.BackColor = Color.Red;
                }

                if ((m_obAstroid.pbxAstroid.Bottom > pnlLockOnTarget2SM.Bottom) && (m_obAstroid.pbxAstroid.Top < pnlLockOnTarget2SM.Bottom) &&
                  (pnlLockOnTarget2SM.Left < m_obAstroid.pbxAstroid.Left) && (m_obAstroid.pbxAstroid.Visible == true))
                {
                    pnlLockOnTarget2SM.BackColor = Color.Green;
                    beGreen2 = true;
                }
                else if (beGreen2 == false)
                {
                    pnlLockOnTarget2SM.BackColor = Color.Red;
                }
            }

            foreach (csAstroid m_obAstroidBoss in obAstroidBoss)
            {
                if ((m_obAstroidBoss.pbxAstroid.Bottom > pnlLockOnTargetSM.Bottom) && (m_obAstroidBoss.pbxAstroid.Top < pnlLockOnTargetSM.Bottom) &&
                   (pnlLockOnTargetSM.Left < m_obAstroidBoss.pbxAstroid.Left) && (m_obAstroidBoss.pbxAstroid.Visible == true))
                {
                    pnlLockOnTargetSM.BackColor = Color.Green;
                    beGreen = true;
                }
                else if (beGreen == false)
                {
                    pnlLockOnTargetSM.BackColor = Color.Red;
                }

                if ((m_obAstroidBoss.pbxAstroid.Bottom > pnlLockOnTarget2SM.Bottom) && (m_obAstroidBoss.pbxAstroid.Top < pnlLockOnTarget2SM.Bottom) &&
                  (pnlLockOnTarget2SM.Left < m_obAstroidBoss.pbxAstroid.Left) && (m_obAstroidBoss.pbxAstroid.Visible == true))
                {
                    pnlLockOnTarget2SM.BackColor = Color.Green;
                    beGreen2 = true;
                }
                else if (beGreen2 == false)
                {
                    pnlLockOnTarget2SM.BackColor = Color.Red;
                }
            }
            beGreen = false;
            beGreen2 = false;



            if (gothit == false)
            {
                foreach (csAstroid m_obAstroid in obAstroid)
                {
                    if (pbxSpaceShipSM.Bounds.IntersectsWith(m_obAstroid.pbxAstroid.Bounds) || (pbxSpaceShip2SM.Bounds.IntersectsWith(m_obAstroid.pbxAstroid.Bounds) && pbxSpaceShip2SM.Visible == true))
                    {
                        if (m_obAstroid.pbxAstroid.Visible == true)
                        {
                            deathCount++;

                            gothit = true;

                            pbxPowerUp1SM.Visible = false;
                            pbxPowerUp2SM.Visible = false;

                            m_obAstroid.GenerateAstroidPosition();

                            if (deathCount >= 3)
                            {
                                MakeVisible();
                            }
                        }
                    }
                }

                foreach (csPhotonTorpedo m_obPhotonTorpedoEnemy in obPhotonTorpedoEnemy)
                {
                    if (pbxSpaceShipSM.Bounds.IntersectsWith(m_obPhotonTorpedoEnemy.pnlPhotoTorpedo.Bounds) || (pbxSpaceShip2SM.Bounds.IntersectsWith(m_obPhotonTorpedoEnemy.pnlPhotoTorpedo.Bounds) && pbxSpaceShip2SM.Visible == true))
                    {
                        if(m_obPhotonTorpedoEnemy.pnlPhotoTorpedo.Visible == true)
                        {
                            deathCount++;

                            gothit = true;

                            pbxPowerUp1SM.Visible = false;
                            pbxPowerUp2SM.Visible = false;

                            m_obPhotonTorpedoEnemy.pnlPhotoTorpedo.Visible = false;
                            m_obPhotonTorpedoEnemy.pnlPhotoTorpedo.Left = -2000;

                            pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedoEnemy.pnlPhotoTorpedo);

                            if (deathCount >= 3)
                            {
                                MakeVisible();
                            }
                        }
                    }
                }
            }

            else
            {
                safetime++;
                if(safetime >= 90)
                {
                    safetime = 0;

                    gothit = false;
                }
            }

            if(pbxSpaceShipSM.Bounds.IntersectsWith(pbxExtraHartSM.Bounds) || (pbxSpaceShipSM.Bounds.IntersectsWith(pbxExtraHartSM.Bounds) && pbxSpaceShip2SM.Visible == true))
            {
                if (pbxExtraHartSM.Visible == true)
                {
                    pbxExtraHartSM.Visible = false;

                    if ((deathCount < 3) && (deathCount > 0))
                    {
                        deathCount--;
                    }
                }
            }

            if(pbxSpaceShipSM.Bounds.IntersectsWith(pbxPowerUp1SM.Bounds) || (pbxSpaceShip2SM.Bounds.IntersectsWith(pbxPowerUp1SM.Bounds) && pbxSpaceShip2SM.Visible == true))
            {
                if (pbxPowerUp1SM.Visible == true)
                {
                    pbxPowerUp1SM.Left = 174;
                    pbxPowerUp1SM.Top = 6;

                    pbxPowerUp2SM.Visible = false;

                    PowerUp1Active = true;
                    PowerUp2Active = false;
                }
            }

            if (pbxSpaceShipSM.Bounds.IntersectsWith(pbxPowerUp2SM.Bounds) || (pbxSpaceShip2SM.Bounds.IntersectsWith(pbxPowerUp2SM.Bounds) && pbxSpaceShip2SM.Visible == true))
            {
                if (pbxPowerUp2SM.Visible == true)
                {
                    pbxPowerUp2SM.Left = 174;
                    pbxPowerUp2SM.Top = 6;

                    pbxPowerUp1SM.Visible = false;

                    PowerUp2Active = true;
                    PowerUp1Active = false;
                }
            }

            if((PowerUp2Active == true) && (pbxPowerUp2SM.Visible == false))
            {
                pbxPowerUp2SM.Visible = false;
                PowerUp2Active = false;
            }

            if ((PowerUp1Active == true) && (pbxPowerUp1SM.Visible == false))
            {
                pbxPowerUp1SM.Visible = false;
                PowerUp1Active = false;
            }

            if (deathCount == 0)
            {
                pbxredheart3SM.Visible = true;
                pbxredheart2SM.Visible = true;
                pbxredheart1SM.Visible = true;

                pbxgreyheart3SM.Visible = false;
                pbxgreyheart2SM.Visible = false;
                pbxgreyheart1SM.Visible = false;
            }

            if (deathCount == 1)
            {
                pbxgreyheart3SM.Visible = true;

                pbxgreyheart2SM.Visible = false;
                pbxgreyheart1SM.Visible = false;

                pbxredheart3SM.Visible = false;

                pbxredheart2SM.Visible = true;
                pbxredheart1SM.Visible = true;
            }

            if (deathCount == 2)
            {
                pbxgreyheart3SM.Visible = true;
                pbxgreyheart2SM.Visible = true;

                pbxgreyheart1SM.Visible = false;

                pbxredheart2SM.Visible = false;
                pbxredheart3SM.Visible = false;

                pbxredheart1SM.Visible = true;
            }

            if (deathCount == 3)
            {
                pbxgreyheart3SM.Visible = true;
                pbxgreyheart2SM.Visible = true;
                pbxgreyheart1SM.Visible = true;

                pbxredheart1SM.Visible = false;
                pbxredheart2SM.Visible = false;
                pbxredheart3SM.Visible = false;
            }
        }

        private void explosion(csAstroid m_obAstroid)
        {
            string m_location;
            m_location = Application.StartupPath;
            m_location = m_location + "\\..\\..\\..\\img\\explosion.png";

            m_obAstroid.pbxAstroid.Image = Image.FromFile(m_location);
            m_obAstroid.pbxAstroid.Width = m_obAstroid.pbxAstroid.Width + 20;
            m_obAstroid.pbxAstroid.Height = m_obAstroid.pbxAstroid.Height + 20;
            m_obAstroid.pbxAstroid.BackColor = Color.Fuchsia;


            explosionTime = 0;
            tmrExplosionSM.Start();
        }

        private void MakeVisible()
        {
            btnPlayAgainSM.Visible = true;
            lbleasySM.Visible = true;
            lblMediumSM.Visible = true;
            lblHardSM.Visible = true;
            rbnBronzeSM.Visible = true;
            rbnSilverSM.Visible = true;
            rbnGoldSM.Visible = true;

            lblTimerSpeedSM.Visible = true;
            trbIntervalSM.Visible = true;
            lbltrbIntervalAmountSM.Visible = true;

            trbThorpedoSpeedSM.Visible = true;
            lblTimerSpeedSM.Visible = true;
            lblSpeedTorpedoSM.Visible = true;

            SetScore();

            tmrMain.Stop();
        }

        private void SetScore()
        {
            if(killCount > highScore1)
            {
                highScore3 = highScore2;
                highScore2 = highScore1;
                highScore1 = killCount;

                lblHighScore1SM.Text = highScore1.ToString();
                lblHighScore2SM.Text = highScore2.ToString();
                lblHighScore3SM.Text = highScore3.ToString();

                playerName3 = playerName2;
                playerName2 = playerName1;
                playerName1 = playerName;

                lblPlayerName1SM.Text = playerName1.ToString();
                lblPlayerName2SM.Text = playerName2.ToString();
                lblPlayerName3SM.Text = playerName3.ToString();
            }
            else if (killCount > highScore2)
            {
                highScore3 = highScore2;
                highScore2 = killCount;

                lblHighScore2SM.Text = highScore2.ToString();
                lblHighScore3SM.Text = highScore3.ToString();

                playerName3 = playerName2;
                playerName2 = playerName;

                lblPlayerName2SM.Text = playerName2.ToString();
                lblPlayerName3SM.Text = playerName3.ToString();
            }
            else if (killCount > highScore3)
            {
                highScore3 = killCount;

                lblHighScore3SM.Text = highScore3.ToString();

                playerName3 = playerName;

                lblPlayerName3SM.Text = playerName3.ToString();
            }
        }

        private void GameReset()
        {
            tmrMain.Stop();

            btnPlayAgainSM.Visible = false;

            killCount = 0;
            deathCount = 0;
            missCount = 0;
            safetime = 0;
            gothit = false;


            flakVertPosition = 288;
            flakHorPosition = 58;
            pbxSpaceShipSM.Left = flakHorPosition;
            pbxSpaceShipSM.Top = flakVertPosition;

            pbxgreyheart1SM.Visible = false;
            pbxgreyheart2SM.Visible = false;
            pbxgreyheart3SM.Visible = false;

            pbxredheart1SM.Visible = true;
            pbxredheart2SM.Visible = true;
            pbxredheart3SM.Visible = true;

            pbxExtraHartSM.Visible = false;
            extraHeartSpawned = false;

            astroidShotTime = 99;
            astroidTpTime = 0;

            killCount = 0;
            suppostKillCountB = 10;

            bossHitPointsB = 50;

            pbxPowerUp2SM.Visible = false;
            pbxPowerUp1SM.Visible = false;

            foreach (csAstroid m_obAstroidBoss in obAstroidBoss)
            {
                m_obAstroidBoss.pbxAstroid.Visible = false;

                pnlplayingfieldSM.Controls.Remove(m_obAstroidBoss.pbxAstroid);
            }

            foreach (csPhotonTorpedo m_obPhotonTorpedo in obPhotonTorpedo)
            {
                m_obPhotonTorpedo.pnlPhotoTorpedo.Left = 2000;

                m_obPhotonTorpedo.pnlPhotoTorpedo.Visible = false;

                pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedo.pnlPhotoTorpedo);
            }

            foreach (csPhotonTorpedo m_obPhotonTorpedoEnemy in obPhotonTorpedoEnemy)
            {
                m_obPhotonTorpedoEnemy.pnlPhotoTorpedo.Left = -2000;

                m_obPhotonTorpedoEnemy.pnlPhotoTorpedo.Visible = false;

                pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedoEnemy.pnlPhotoTorpedo);
            }

            foreach (csPhotonTorpedo m_obPhotonTorpedo2Power in obPhotonTorpedo2Power)
            {
                m_obPhotonTorpedo2Power.pnlPhotoTorpedo.Left = -2000;

                m_obPhotonTorpedo2Power.pnlPhotoTorpedo.Visible = false;

                pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedo2Power.pnlPhotoTorpedo);
            }

            string m_location;
            m_location = Application.StartupPath;
            m_location = m_location + "\\..\\..\\..\\img\\badbananaNO.png";

            foreach (csAstroid m_obAstroid in obAstroid)
            {
                m_obAstroid.pbxAstroid.Image = Image.FromFile(m_location);
            }

            foreach (csAstroid m_obAstroidBoss in obAstroidBoss)
            {
                pnlplayingfieldSM.Controls.Remove(m_obAstroidBoss.pbxAstroid);
            }
        }
            

        /// <summary>
        /// if astroid is hit a new one is made on a random position
        /// </summary>
        private void RespawnAstroids()
        {
            foreach (csAstroid m_obAstroid in obAstroid)
            {
                if(m_obAstroid.pbxAstroid.Left <= pnlplayingfieldSM.Left)
                {
                    m_obAstroid.GenerateAstroidPosition();
                }
            }
        }

        private void MoveAstroid()
        {
            astroidShotTimeBoss++;
            foreach (csAstroid m_obAstroidBoss in obAstroidBoss)
            {
                if (m_obAstroidBoss.pbxAstroid.Visible == true)
                {
                    
                    if (bossGoingDown == true)
                    {
                        if (m_obAstroidBoss.pbxAstroid.Top > pnlplayingfieldSM.Top - 5)
                        {
                            m_obAstroidBoss.pbxAstroid.Top = m_obAstroidBoss.pbxAstroid.Top - 5;
                        }
                        else
                        {
                            bossGoingDown = false;
                        }
                    }
                    else
                    {
                        if (m_obAstroidBoss.pbxAstroid.Top < pnlplayingfieldSM.Bottom - 5 - m_obAstroidBoss.pbxAstroid.Height)
                        {
                            m_obAstroidBoss.pbxAstroid.Top = m_obAstroidBoss.pbxAstroid.Top + 5;
                        }
                        else
                        {
                            bossGoingDown = true;
                        }
                    }

                    if (astroidShotTimeBoss >= 30)
                    {
                        PhotonTorpedoEnemyBoss(m_obAstroidBoss);

                        astroidShotTimeBoss = 0;
                    }
                }
            }
            if (rbnBronzeSM.Checked == true)
            {
                if (killCount >= 65)
                {
                    LastStageAstroids();
                }
                else if (killCount >= 40)
                {

                }
                else if (killCount >= 30)
                {
                    extraHeartSpawned = false;
                    LastStageAstroids();
                }
                else if (killCount >= 20)
                {
                    astroidShotTime++;
                    foreach (csAstroid m_obAstroid in obAstroid)
                    {
                        if (m_obAstroid.pbxAstroid.Visible == true)
                        {
                            m_obAstroid.pbxAstroid.Left = m_obAstroid.pbxAstroid.Left - 3;

                            if (astroidShotTime >= 125)
                            {
                                PhotonTorpedoEnemy(m_obAstroid);
                            }
                        }
                    }
                    if (astroidShotTime >= 125)
                    {
                        astroidShotTime = 0;
                    }
                }
                else if (killCount >= 10)
                {
                    astroidTpTime++;
                    foreach (csAstroid m_obAstroid in obAstroid)
                    {
                        m_obAstroid.pbxAstroid.Left = m_obAstroid.pbxAstroid.Left - 4;
                        if (astroidTpTime >= 50)
                        {
                            m_obAstroid.pbxAstroid.Top = GenerateRandomTop.Next(pnlplayingfieldSM.Bottom - 20);
                        }
                    }

                    if (astroidTpTime >= 50)
                    {
                        astroidTpTime = 0;
                    }
                }
                else if (killCount >= 0)
                {
                    foreach (csAstroid m_obAstroid in obAstroid)
                    {
                        m_obAstroid.pbxAstroid.Left = m_obAstroid.pbxAstroid.Left - 2;
                    }
                }
            }
            else if (rbnSilverSM.Checked == true)
            {
                if (killCount >= 97)
                {
                    LastStageAstroids();
                }
                else if (killCount >= 60)
                {

                }
                else if (killCount >= 45)
                {
                    extraHeartSpawned = false;
                    LastStageAstroids();
                }
                else if (killCount >= 30)
                {
                    astroidShotTime++;
                    foreach (csAstroid m_obAstroid in obAstroid)
                    {
                        if (m_obAstroid.pbxAstroid.Visible == true)
                        {
                            m_obAstroid.pbxAstroid.Left = m_obAstroid.pbxAstroid.Left - 3;

                            if (astroidShotTime >= 125)
                            {
                                PhotonTorpedoEnemy(m_obAstroid);
                            }
                        }
                    }
                    if (astroidShotTime >= 125)
                    {
                        astroidShotTime = 0;
                    }
                }
                else if (killCount >= 15)
                {
                    astroidTpTime++;
                    foreach (csAstroid m_obAstroid in obAstroid)
                    {
                        m_obAstroid.pbxAstroid.Left = m_obAstroid.pbxAstroid.Left - 4;
                        if (astroidTpTime >= 50)
                        {
                            m_obAstroid.pbxAstroid.Top = GenerateRandomTop.Next(pnlplayingfieldSM.Bottom - 20);
                        }
                    }

                    if (astroidTpTime >= 50)
                    {
                        astroidTpTime = 0;
                    }
                }
                else if (killCount >= 0)
                {
                    foreach (csAstroid m_obAstroid in obAstroid)
                    {
                        m_obAstroid.pbxAstroid.Left = m_obAstroid.pbxAstroid.Left - 2;
                    }
                }
            }
            else if (rbnGoldSM.Checked == true)
            {
                if (killCount >= 130)
                {
                    LastStageAstroids();
                }
                else if (killCount >= 80)
                {

                }
                else if (killCount >= 60)
                {
                    extraHeartSpawned = false;
                    LastStageAstroids();
                }
                else if (killCount >= 40)
                {
                    astroidShotTime++;
                    foreach (csAstroid m_obAstroid in obAstroid)
                    {
                        if (m_obAstroid.pbxAstroid.Visible == true)
                        {
                            m_obAstroid.pbxAstroid.Left = m_obAstroid.pbxAstroid.Left - 3;

                            if (astroidShotTime >= 125)
                            {
                                PhotonTorpedoEnemy(m_obAstroid);
                            }
                        }
                    }
                    if (astroidShotTime >= 125)
                    {
                        astroidShotTime = 0;
                    }
                }
                else if (killCount >= 20)
                {
                    astroidTpTime++;
                    foreach (csAstroid m_obAstroid in obAstroid)
                    {
                        m_obAstroid.pbxAstroid.Left = m_obAstroid.pbxAstroid.Left - 4;
                        if (astroidTpTime >= 50)
                        {
                            m_obAstroid.pbxAstroid.Top = GenerateRandomTop.Next(pnlplayingfieldSM.Bottom - 20);
                        }
                    }

                    if (astroidTpTime >= 50)
                    {
                        astroidTpTime = 0;
                    }
                }
                else if (killCount >= 0)
                {
                    foreach (csAstroid m_obAstroid in obAstroid)
                    {
                        m_obAstroid.pbxAstroid.Left = m_obAstroid.pbxAstroid.Left - 2;
                    }
                }

                pbxExtraHartSM.Left = pbxExtraHartSM.Left - 3;

                if (pbxExtraHartSM.Left <= pnlplayingfieldSM.Left - pbxExtraHartSM.Width)
                {
                    pbxExtraHartSM.Visible = false;
                }

                if (PowerUp1Active == false)
                {
                    pbxPowerUp1SM.Left = pbxPowerUp1SM.Left - 3;

                    if (pbxPowerUp1SM.Left <= pnlplayingfieldSM.Left - pbxPowerUp1SM.Width)
                    {
                        pbxPowerUp1SM.Visible = false;
                    }
                }

                if (PowerUp2Active == false)
                {
                    pbxPowerUp2SM.Left = pbxPowerUp2SM.Left - 3;

                    if (pbxPowerUp2SM.Left <= pnlplayingfieldSM.Left - pbxPowerUp2SM.Width)
                    {
                        pbxPowerUp2SM.Visible = false;
                    }
                }
            }

            pbxExtraHartSM.Left = pbxExtraHartSM.Left - 3;

            if (pbxExtraHartSM.Left <= pnlplayingfieldSM.Left - pbxExtraHartSM.Width)
            {
                pbxExtraHartSM.Visible = false;
            }

            if (PowerUp1Active == false)
            {
                pbxPowerUp1SM.Left = pbxPowerUp1SM.Left - 3;

                if (pbxPowerUp1SM.Left <= pnlplayingfieldSM.Left - pbxPowerUp1SM.Width)
                {
                    pbxPowerUp1SM.Visible = false;
                }
            }

            if (PowerUp2Active == false)
            {
                pbxPowerUp2SM.Left = pbxPowerUp2SM.Left - 3;

                if (pbxPowerUp2SM.Left <= pnlplayingfieldSM.Left - pbxPowerUp2SM.Width)
                {
                    pbxPowerUp2SM.Visible = false;
                }
            }
        }

        private void LastStageAstroids()
        {
            astroidTpTime++;
            astroidShotTime++;
            foreach (csAstroid m_obAstroid in obAstroid)
            {
                if (m_obAstroid.pbxAstroid.Visible == true)
                {
                    m_obAstroid.pbxAstroid.Left = m_obAstroid.pbxAstroid.Left - 3;

                    if (astroidShotTime >= 125)
                    {
                        PhotonTorpedoEnemy(m_obAstroid);
                    }

                    if (astroidTpTime >= 75)
                    {
                        m_obAstroid.pbxAstroid.Top = GenerateRandomTop.Next(pnlplayingfieldSM.Bottom - 20);
                    }
                }
            }
            if (astroidShotTime >= 125)
            {
                astroidShotTime = 0;
            }
            if (astroidTpTime >= 75)
            {
                astroidTpTime = 0;
            }
        }

        private void PhotonTorpedoEnemy(csAstroid m_obAstroid)
        {
            obPhotonTorpedoEnemy.Add(new csPhotonTorpedo(m_obAstroid.pbxAstroid.Top, m_obAstroid.pbxAstroid.Height, m_obAstroid.pbxAstroid.Left));
            CreatePhotonTorpedoEnemy();
        }

        private void PhotonTorpedoEnemyBoss(csAstroid m_obAstroidBoss)
        {
            obPhotonTorpedoEnemy.Add(new csPhotonTorpedo(m_obAstroidBoss.pbxAstroid.Top, m_obAstroidBoss.pbxAstroid.Height, m_obAstroidBoss.pbxAstroid.Left));
            CreatePhotonTorpedoEnemy();

            obPhotonTorpedoEnemy.Add(new csPhotonTorpedo(m_obAstroidBoss.pbxAstroid.Top + 31, m_obAstroidBoss.pbxAstroid.Height, m_obAstroidBoss.pbxAstroid.Left));
            CreatePhotonTorpedoEnemy();

            obPhotonTorpedoEnemy.Add(new csPhotonTorpedo(m_obAstroidBoss.pbxAstroid.Top - 31, m_obAstroidBoss.pbxAstroid.Height, m_obAstroidBoss.pbxAstroid.Left));
            CreatePhotonTorpedoEnemy();

            obPhotonTorpedoEnemy.Add(new csPhotonTorpedo(m_obAstroidBoss.pbxAstroid.Top + 62, m_obAstroidBoss.pbxAstroid.Height, m_obAstroidBoss.pbxAstroid.Left));
            CreatePhotonTorpedoEnemy();

            obPhotonTorpedoEnemy.Add(new csPhotonTorpedo(m_obAstroidBoss.pbxAstroid.Top - 62, m_obAstroidBoss.pbxAstroid.Height, m_obAstroidBoss.pbxAstroid.Left));
            CreatePhotonTorpedoEnemy();
        }

        private void CreatePhotonTorpedoEnemy()
        {
            pnlplayingfieldSM.Controls.Add(obPhotonTorpedoEnemy[PhotonTorpedoNrEnemy].pnlPhotoTorpedo);

            obPhotonTorpedoEnemy[PhotonTorpedoNrEnemy].GeneratePhotonTorpedo();

            obPhotonTorpedoEnemy[PhotonTorpedoNrEnemy].pnlPhotoTorpedo.BackColor = Color.Red;

            PhotonTorpedoNrEnemy++;
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            HandleGameKeys();
            DifDetector();
            HitDetector();
            ControleFlakFireTorpedo();
            RespawnAstroids();
            MoveAstroid();
        }

        private void DifDetector()
        {
            string m_location;
            string m_locationBoss;
            string m_locationNo;
            m_location = Application.StartupPath;
            m_locationBoss = m_location + "\\..\\..\\..\\img\\badbananaBoss.png";
            m_locationNo = m_location + "\\..\\..\\..\\img\\badbananaNo.png";
            m_location = m_location + "\\..\\..\\..\\img\\badbananaYes.png";
            if (tmrExplosionSM.Enabled == false)
            {
                if (rbnBronzeSM.Checked == true)
                {
                    if (killCount == suppostKillCountB)
                    {

                        if (suppostKillCountB < 50)
                        {
                            suppostKillCountB = suppostKillCountB + 10;
                            foreach (csPhotonTorpedo m_obPhotonTorpedo in obPhotonTorpedo)
                            {
                                m_obPhotonTorpedo.pnlPhotoTorpedo.Left = 2000;

                                m_obPhotonTorpedo.pnlPhotoTorpedo.Visible = false;

                                pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedo.pnlPhotoTorpedo);
                            }

                            foreach (csPhotonTorpedo m_obPhotonTorpedoEnemy in obPhotonTorpedoEnemy)
                            {
                                m_obPhotonTorpedoEnemy.pnlPhotoTorpedo.Left = -2000;

                                m_obPhotonTorpedoEnemy.pnlPhotoTorpedo.Visible = false;

                                pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedoEnemy.pnlPhotoTorpedo);
                            }

                            foreach (csPhotonTorpedo m_obPhotonTorpedo2Power in obPhotonTorpedo2Power)
                            {
                                m_obPhotonTorpedo2Power.pnlPhotoTorpedo.Left = -2000;

                                m_obPhotonTorpedo2Power.pnlPhotoTorpedo.Visible = false;

                                pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedo2Power.pnlPhotoTorpedo);
                            }

                            foreach (csAstroid m_obAstroid in obAstroid)
                            {
                                if (killCount < 40)
                                {

                                        astroidPlus++;
                                        if (astroidPlus <= amountOfAstroids)
                                        {
                                            m_obAstroid.pbxAstroid.Visible = true;

                                            m_obAstroid.GenerateAstroidPosition();
                                        }
                                        else
                                        {
                                            m_obAstroid.pbxAstroid.Visible = false;
                                        }
                                    
                                    
                                }

                                if (killCount == 10)
                                {
                                    m_obAstroid.pbxAstroid.Image = Image.FromFile(m_locationNo);
                                }

                                if (killCount == 20 || killCount == 30)
                                {
                                    m_obAstroid.pbxAstroid.Image = Image.FromFile(m_location);
                                }

                                if (killCount == 40)
                                {
                                    for (int i = 0; i < 1; i++)
                                    {
                                        obAstroidBoss.Add(new csAstroid(pbxExtraHartSM.Top, pnlplayingfieldSM.Bottom - 96, pnlplayingfieldSM.Right - 96, pnlplayingfieldSM.Right - 96));

                                        pnlplayingfieldSM.Controls.Add(obAstroidBoss[i].pbxAstroid);
                                        obAstroidBoss[i].pbxAstroid.Visible = true;

                                        obAstroidBoss[i].pbxAstroid.Width = 63;
                                        obAstroidBoss[i].pbxAstroid.Height = 96;

                                        obAstroidBoss[i].pbxAstroid.Image = Image.FromFile(m_locationBoss);
                                        obAstroidBoss[i].pbxAstroid.SizeMode = PictureBoxSizeMode.StretchImage;

                                        //fmLoggingWindow.PrintLn(obAstroid[i].pnlAstroid.Parent.ToString(), "W");

                                        obAstroidBoss[i].GenerateAstroidPosition();

                                        obAstroidBoss[i].pbxAstroid.Top = 0;
                                    }
                                }

                                if (killCount == 65)
                                {
                                    m_obAstroid.pbxAstroid.Image = Image.FromFile(m_location);
                                }
                            }
                            astroidPlus = 0;
                        }
                    }

                    if (killCount == 10)
                    {
                        if (pbxPowerUp2SM.Visible == false)
                        {
                            pbxPowerUp2SM.Left = pnlplayingfieldSM.Right - pbxPowerUp2SM.Width;

                            pbxPowerUp2SM.Top = GenerateRandomTop.Next(pnlplayingfieldSM.Bottom - pbxPowerUp2SM.Height);
                            while (pbxPowerUp2SM.Top <= 51)
                            {
                                pbxPowerUp2SM.Top = GenerateRandomTop.Next(pnlplayingfieldSM.Bottom - pbxPowerUp2SM.Height);
                            }

                            pbxPowerUp2SM.Visible = true;
                        }
                    }

                    if (killCount == 20 && extraHeartSpawned == false)
                    {
                        SpawnHeart();
                    }

                    if (killCount == 40 && extraHeartSpawned == false)
                    {
                        SpawnHeart();

                        if (pbxPowerUp1SM.Visible == false)
                        {
                            pbxPowerUp1SM.Left = pnlplayingfieldSM.Right - pbxPowerUp1SM.Width;

                            pbxPowerUp1SM.Top = GenerateRandomTop.Next(pnlplayingfieldSM.Bottom - pbxPowerUp1SM.Height);
                            while (pbxPowerUp1SM.Top <= 51)
                            {
                                pbxPowerUp1SM.Top = GenerateRandomTop.Next(pnlplayingfieldSM.Bottom - pbxPowerUp1SM.Height);
                            }

                            pbxPowerUp1SM.Visible = true;
                        }
                    }
                    if (killCount == 65 && extraHeartSpawned == false)
                    {
                        SpawnHeart();
                    }

                    if (killCount == 100)
                    {
                        if (endmessageSend == false)
                        {
                            endmessageSend = true;
                            MessageBox.Show("You won !!1!!11! \nnow die");
                            this.Close();
                        }
                    }
                }
                else if (rbnSilverSM.Checked == true)
                {
                    if (killCount == suppostKillCountM)
                    {

                        if (suppostKillCountM < 75)
                        {
                            suppostKillCountM = suppostKillCountM + 15;
                            foreach (csPhotonTorpedo m_obPhotonTorpedo in obPhotonTorpedo)
                            {
                                m_obPhotonTorpedo.pnlPhotoTorpedo.Left = 2000;

                                m_obPhotonTorpedo.pnlPhotoTorpedo.Visible = false;

                                pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedo.pnlPhotoTorpedo);
                            }

                            foreach (csPhotonTorpedo m_obPhotonTorpedoEnemy in obPhotonTorpedoEnemy)
                            {
                                m_obPhotonTorpedoEnemy.pnlPhotoTorpedo.Left = -2000;

                                m_obPhotonTorpedoEnemy.pnlPhotoTorpedo.Visible = false;

                                pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedoEnemy.pnlPhotoTorpedo);
                            }

                            foreach (csPhotonTorpedo m_obPhotonTorpedo2Power in obPhotonTorpedo2Power)
                            {
                                m_obPhotonTorpedo2Power.pnlPhotoTorpedo.Left = -2000;

                                m_obPhotonTorpedo2Power.pnlPhotoTorpedo.Visible = false;

                                pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedo2Power.pnlPhotoTorpedo);
                            }

                            foreach (csAstroid m_obAstroid in obAstroid)
                            {
                                if (killCount < 60)
                                {

                                        astroidPlus++;
                                        if (astroidPlus <= amountOfAstroids)
                                        {
                                            m_obAstroid.pbxAstroid.Visible = true;

                                            m_obAstroid.GenerateAstroidPosition();
                                        }
                                        else
                                        {
                                            m_obAstroid.pbxAstroid.Visible = false;
                                        }
                                    
                                    
                                }

                                if (killCount == 15)
                                {
                                    m_obAstroid.pbxAstroid.Image = Image.FromFile(m_locationNo);
                                }

                                if (killCount == 30 || killCount == 45)
                                {
                                    m_obAstroid.pbxAstroid.Image = Image.FromFile(m_location);
                                }

                                if (killCount == 60)
                                {
                                    for (int i = 0; i < 1; i++)
                                    {
                                        obAstroidBoss.Add(new csAstroid(pbxExtraHartSM.Top, pnlplayingfieldSM.Bottom - 96, pnlplayingfieldSM.Right - 96, pnlplayingfieldSM.Right - 96));

                                        pnlplayingfieldSM.Controls.Add(obAstroidBoss[i].pbxAstroid);
                                        obAstroidBoss[i].pbxAstroid.Visible = true;

                                        obAstroidBoss[i].pbxAstroid.Width = 63;
                                        obAstroidBoss[i].pbxAstroid.Height = 96;

                                        obAstroidBoss[i].pbxAstroid.Image = Image.FromFile(m_locationBoss);
                                        obAstroidBoss[i].pbxAstroid.SizeMode = PictureBoxSizeMode.StretchImage;

                                        //fmLoggingWindow.PrintLn(obAstroid[i].pnlAstroid.Parent.ToString(), "W");

                                        obAstroidBoss[i].GenerateAstroidPosition();

                                        obAstroidBoss[i].pbxAstroid.Top = 0;
                                    }
                                }

                                if (killCount == 98)
                                {
                                    m_obAstroid.pbxAstroid.Image = Image.FromFile(m_location);
                                }
                            }
                            astroidPlus = 0;
                        }
                    }
                    if (killCount == 15)
                    {
                        if (pbxPowerUp2SM.Visible == false)
                        {
                            pbxPowerUp2SM.Left = pnlplayingfieldSM.Right - pbxPowerUp2SM.Width;

                            pbxPowerUp2SM.Top = GenerateRandomTop.Next(pnlplayingfieldSM.Bottom - pbxPowerUp2SM.Height);
                            while (pbxPowerUp2SM.Top <= 51)
                            {
                                pbxPowerUp2SM.Top = GenerateRandomTop.Next(pnlplayingfieldSM.Bottom - pbxPowerUp2SM.Height);
                            }

                            pbxPowerUp2SM.Visible = true;
                        }
                    }

                    if (killCount == 30 && extraHeartSpawned == false)
                    {
                        SpawnHeart();
                    }

                    if (killCount == 60 && extraHeartSpawned == false)
                    {
                        SpawnHeart();

                        if (pbxPowerUp1SM.Visible == false)
                        {
                            pbxPowerUp1SM.Left = pnlplayingfieldSM.Right - pbxPowerUp1SM.Width;

                            pbxPowerUp1SM.Top = GenerateRandomTop.Next(pnlplayingfieldSM.Bottom - pbxPowerUp1SM.Height);
                            while (pbxPowerUp1SM.Top <= 51)
                            {
                                pbxPowerUp1SM.Top = GenerateRandomTop.Next(pnlplayingfieldSM.Bottom - pbxPowerUp1SM.Height);
                            }

                            pbxPowerUp1SM.Visible = true;
                        }
                    }
                    if (killCount == 98 && extraHeartSpawned == false)
                    {
                        SpawnHeart();
                    }

                    if (killCount == 150)
                    {
                        if (endmessageSend == false)
                        {
                            endmessageSend = true;
                            MessageBox.Show("You won !!1!!11! \nnow die");
                            this.Close();
                        }
                    }
                }
                else if (rbnGoldSM.Checked == true)
                {
                    if (killCount == suppostKillCountH)
                    {

                        if (suppostKillCountH < 100)
                        {
                            suppostKillCountH = suppostKillCountH + 20;
                            foreach (csPhotonTorpedo m_obPhotonTorpedo in obPhotonTorpedo)
                            {
                                m_obPhotonTorpedo.pnlPhotoTorpedo.Left = 2000;

                                m_obPhotonTorpedo.pnlPhotoTorpedo.Visible = false;

                                pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedo.pnlPhotoTorpedo);
                            }

                            foreach (csPhotonTorpedo m_obPhotonTorpedoEnemy in obPhotonTorpedoEnemy)
                            {
                                m_obPhotonTorpedoEnemy.pnlPhotoTorpedo.Left = -2000;

                                m_obPhotonTorpedoEnemy.pnlPhotoTorpedo.Visible = false;

                                pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedoEnemy.pnlPhotoTorpedo);
                            }

                            foreach (csPhotonTorpedo m_obPhotonTorpedo2Power in obPhotonTorpedo2Power)
                            {
                                m_obPhotonTorpedo2Power.pnlPhotoTorpedo.Left = -2000;

                                m_obPhotonTorpedo2Power.pnlPhotoTorpedo.Visible = false;

                                pnlplayingfieldSM.Controls.Remove(m_obPhotonTorpedo2Power.pnlPhotoTorpedo);
                            }

                            foreach (csAstroid m_obAstroid in obAstroid)
                            {
                                if (killCount < 80)
                                {
                                        astroidPlus++;
                                        if (astroidPlus <= amountOfAstroids)
                                        {
                                            m_obAstroid.pbxAstroid.Visible = true;

                                            m_obAstroid.GenerateAstroidPosition();
                                        }
                                        else
                                        {
                                            m_obAstroid.pbxAstroid.Visible = false;
                                        }
                                }

                                if (killCount == 20)
                                {
                                    m_obAstroid.pbxAstroid.Image = Image.FromFile(m_locationNo);
                                }

                                if (killCount == 40 || killCount == 60)
                                {
                                    m_obAstroid.pbxAstroid.Image = Image.FromFile(m_location);
                                }


                                if (killCount == 80)
                                {
                                    for (int i = 0; i < 1; i++)
                                    {
                                        obAstroidBoss.Add(new csAstroid(pbxExtraHartSM.Top, pnlplayingfieldSM.Bottom - 96, pnlplayingfieldSM.Right - 96, pnlplayingfieldSM.Right - 96));

                                        pnlplayingfieldSM.Controls.Add(obAstroidBoss[i].pbxAstroid);
                                        obAstroidBoss[i].pbxAstroid.Visible = true;

                                        obAstroidBoss[i].pbxAstroid.Width = 63;
                                        obAstroidBoss[i].pbxAstroid.Height = 96;

                                        obAstroidBoss[i].pbxAstroid.Image = Image.FromFile(m_locationBoss);
                                        obAstroidBoss[i].pbxAstroid.SizeMode = PictureBoxSizeMode.StretchImage;

                                        //fmLoggingWindow.PrintLn(obAstroid[i].pnlAstroid.Parent.ToString(), "W");

                                        obAstroidBoss[i].GenerateAstroidPosition();

                                        obAstroidBoss[i].pbxAstroid.Top = 0;
                                    }
                                }

                                if (killCount == 130)
                                {
                                    m_obAstroid.pbxAstroid.Image = Image.FromFile(m_location);
                                }
                            }
                            astroidPlus = 0;
                        }
                    }

                    if (killCount == 20)
                    {
                        if (pbxPowerUp2SM.Visible == false)
                        {
                            pbxPowerUp2SM.Left = pnlplayingfieldSM.Right - pbxPowerUp2SM.Width;

                            pbxPowerUp2SM.Top = GenerateRandomTop.Next(pnlplayingfieldSM.Bottom - pbxPowerUp2SM.Height);
                            while (pbxPowerUp2SM.Top <= 51)
                            {
                                pbxPowerUp2SM.Top = GenerateRandomTop.Next(pnlplayingfieldSM.Bottom - pbxPowerUp2SM.Height);
                            }

                            pbxPowerUp2SM.Visible = true;
                        }
                    }

                    if (killCount == 40 && extraHeartSpawned == false)
                    {
                        SpawnHeart();
                    }

                    if (killCount == 80 && extraHeartSpawned == false)
                    {
                        SpawnHeart();

                        if (pbxPowerUp1SM.Visible == false)
                        {
                            pbxPowerUp1SM.Left = pnlplayingfieldSM.Right - pbxPowerUp1SM.Width;

                            pbxPowerUp1SM.Top = GenerateRandomTop.Next(pnlplayingfieldSM.Bottom - pbxPowerUp1SM.Height);
                            while (pbxPowerUp1SM.Top <= 51)
                            {
                                pbxPowerUp1SM.Top = GenerateRandomTop.Next(pnlplayingfieldSM.Bottom - pbxPowerUp1SM.Height);
                            }

                            pbxPowerUp1SM.Visible = true;
                        }
                    }
                    if (killCount == 130 && extraHeartSpawned == false)
                    {
                        SpawnHeart();
                    }

                    if (killCount == 200)
                    {
                        if (endmessageSend == false)
                        {
                            endmessageSend = true;
                            MessageBox.Show("You won !!1!!11! \nnow die");
                            this.Close();
                        }
                    }
                }

                if (killCount == suppostKillCount)
                {
                    suppostKillCount = suppostKillCount + 10;
                    if (missCount < shotsFired)
                    {
                        shotsFired = shotsFired + 100;
                    }
                    else
                    {
                        tmrMain.Stop();
                        btnPlayAgainSM.Visible = true;
                        rbnBronzeSM.Visible = true;
                        lbleasySM.Visible = true;
                        rbnGoldSM.Visible = true;
                        lblHardSM.Visible = true;
                        rbnSilverSM.Visible = true;
                        lblMediumSM.Visible = true;
                        MessageBox.Show("you missed to many shots");
                    }
                }
            }
        }

        private void SpawnHeart()
        {
            extraHeartSpawned = true;
            if (pbxExtraHartSM.Visible == false)
            {
                pbxExtraHartSM.Left = pnlplayingfieldSM.Right - pbxExtraHartSM.Width;

                pbxExtraHartSM.Top = GenerateRandomTop.Next(pnlplayingfieldSM.Bottom - pbxExtraHartSM.Height);
                while (pbxExtraHartSM.Top < 52)
                {
                    pbxExtraHartSM.Top = GenerateRandomTop.Next(pnlplayingfieldSM.Bottom - pbxExtraHartSM.Height);
                }

                pbxExtraHartSM.Visible = true;
            }
        }

        private void CreateAstroids()
        {
            for (int i = 0; i < 20; i++ )
            {
                string m_location;
                m_location = Application.StartupPath;
                m_location = m_location + "\\..\\..\\..\\img\\badbananaNO.png";
                //MessageBox.Show(m_location);

                obAstroid.Add(new csAstroid(pbxredheart1SM.Top, pnlplayingfieldSM.Bottom - 60, pnlplayingfieldSM.Right - 120, pnlplayingfieldSM.Right - 20));

                pnlplayingfieldSM.Controls.Add(obAstroid[i].pbxAstroid);
                obAstroid[i].pbxAstroid.Visible = true;

                obAstroid[i].pbxAstroid.Image = Image.FromFile(m_location);
                obAstroid[i].pbxAstroid.SizeMode = PictureBoxSizeMode.StretchImage;

                //fmLoggingWindow.PrintLn(obAstroid[i].pnlAstroid.Parent.ToString(), "W");

                obAstroid[i].GenerateAstroidPosition();
            }
        }

        private void btnStartTimer_Click(object sender, EventArgs e)
        {
            RankDetector();
            tmrMain.Start();
            CreateAstroids();
            btnStartTimer.Visible = false;
            btnStartTimer.Enabled = false;

            foreach (csAstroid m_obAstroid in obAstroid)
            {
                astroidPlus++;
                if (astroidPlus <= amountOfAstroids)
                {
                    m_obAstroid.pbxAstroid.Visible = true;

                    m_obAstroid.GenerateAstroidPosition();
                }
                else
                {
                    m_obAstroid.pbxAstroid.Visible = false;
                }
            }
            astroidPlus = 0;
        }

        private void fmArduinoSerialConnect_KeyDown(object sender, KeyEventArgs e)
        {
            pressedKey = e.KeyCode.ToString();
            lblActiveKeyCwes.Text = pressedKey;
        }

        private void fmArduinoSerialConnect_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKey = "";
            lblActiveKeyCwes.Text = pressedKey;
        }

        private void btnGameBeginSM_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tbpCustomApplication;
            this.Width = 1330;
            this.Height = 788;
            tbcMain.Width = 1294;
            tbcMain.Height = 723;
        }

        private void playAgainSM_Click(object sender, EventArgs e)
        {
            RankDetector();
            GameReset();
            foreach (csAstroid m_obAstroid in obAstroid)
            {
                astroidPlus++;
                if (astroidPlus <= amountOfAstroids)
                {
                    m_obAstroid.pbxAstroid.Visible = true;

                    m_obAstroid.GenerateAstroidPosition();
                }
                else
                {
                    m_obAstroid.pbxAstroid.Visible = false;
                }
            }
            astroidPlus = 0;
            tmrMain.Start();
        }

        private void RankDetector()
        {
            if (rbnBronzeSM.Checked == true)
            {
                amountOfAstroids = 10;
            }
            else if (rbnSilverSM.Checked == true)
            {
                amountOfAstroids = 15;
            }
            else if (rbnGoldSM.Checked == true)
            {
                amountOfAstroids = 20;
            }

            lbleasySM.Visible = false;
            lblMediumSM.Visible = false;
            lblHardSM.Visible = false;
            rbnBronzeSM.Visible = false;
            rbnSilverSM.Visible = false;
            rbnGoldSM.Visible = false;

            trbIntervalSM.Visible = false;
            lbltrbIntervalAmountSM.Visible = false;
            lblTimerSpeedSM.Visible = false;

            trbThorpedoSpeedSM.Visible = false;
            lblTorpedoSpeedSM.Visible = false;
            lblSpeedTorpedoSM.Visible = false;

            tmrMain.Interval = trbIntervalSM.Value;
        }

        private void trbIntervalSM_Scroll(object sender, EventArgs e)
        {
            lbltrbIntervalAmountSM.Text = trbIntervalSM.Value.ToString();
        }

        private void trbThorpedoSpeedSM_Scroll(object sender, EventArgs e)
        {
            thorpedoSpeed = trbThorpedoSpeedSM.Value;
            lblTorpedoSpeedSM.Text = trbThorpedoSpeedSM.Value.ToString();
        }

        private void playerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tbpPlayerInfoSM;
            this.Width = 657;
            this.Height = 401;
            tbcMain.Width = 628;
            tbcMain.Height = 328;
        }

        private void btnSetPlayerNameSM_Click(object sender, EventArgs e)
        {
            try
            {
                playerName = tbxPlayerName.Text;
            }
            catch 
            {
                MessageBox.Show("please use a useable name");
            }
            
        }

        private void tmrExplosion_Tick(object sender, EventArgs e)
        {

            explosionTime++;
            if (explosionTime > 10)
            {
                explosionTime = 0;
                foreach (csAstroid m_obAstroid in obAstroid)
                {
                    if (m_obAstroid.pbxAstroid.BackColor == Color.Fuchsia)
                    {
                        m_obAstroid.pbxAstroid.BackColor = Color.Lime;
                        m_obAstroid.pbxAstroid.Width = m_obAstroid.pbxAstroid.Width - 20;
                        m_obAstroid.pbxAstroid.Height = m_obAstroid.pbxAstroid.Height - 20;

                        m_obAstroid.pbxAstroid.Visible = false;
                    }
                }
                tmrExplosionSM.Stop();
            }
        }

        private void locationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Application.StartupPath);
        }

        private void btnAddPlayerSM_Click(object sender, EventArgs e)
        {
            seccondPlayerActive = true;

            btn1v1SM.Visible = true;

            btnAddPlayerSM.Visible = false;
            
            pbxSpaceShip2SM.Visible = true;
            pnlLockOnTarget2SM.Visible = true;

        }

        #endregion

        #region multiplayer

        private void btn1v1SM_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tbpMultiplayerSM;

            tmrMultiplayerSM.Start();
        }

        private void tmrMultiplayerSM_Tick(object sender, EventArgs e)
        {
            HandleGameKeysM();
            HitDetector();
            ControleFlakFireTorpedo();
        }

        private void HandleGameKeysM()
        {
            switch (pressedKey)
            {
                case "W":
                    if (flakVertPosition > pnlMultiplayerSM.Top)
                    {
                        flakVertPosition = flakVertPosition - 5;
                    }
                    break;
                case "A":
                    if (pnlMultiplayerSM.Left + 6 <= flakHorPosition)
                    {
                        flakHorPosition = flakHorPosition - 7;
                    }
                    break;
                case "S":
                    if (flakVertPosition + pbxSpaceShipSM.Height < pnlMultiplayerSM.Bottom)
                    {
                        flakVertPosition = flakVertPosition + 5;
                    }
                    break;
                case "D":
                    if (pnlMultiplayerSM.Right - pbxSpaceShipSM.Width - 7 >= flakHorPosition + pbxSpaceShipSM.Width)
                    {
                        flakHorPosition = flakHorPosition + 7;
                    }
                    break;
                default:
                    break;
            }

            if (seccondPlayerActive == true)
            {
                switch (receivedString)
                {
                    case "W\r":
                        if (flakVertPosition2M > pnlMultiplayerSM.Top)
                        {
                            flakVertPosition2M = flakVertPosition2M - 5;
                        }
                        break;
                    case "A\r":
                        if (pnlMultiplayerSM.Right - 6 <= flakHorPosition2M)
                        {
                            flakHorPosition2M = flakHorPosition2M - 7;
                        }
                        break;
                    case "S\r":
                        if (flakVertPosition2M + pbxPlayer2mSM.Height < pnlMultiplayerSM.Bottom)
                        {
                            flakVertPosition2M = flakVertPosition2M + 5;
                        }
                        break;
                    case "D\r":
                        if (pnlMultiplayerSM.Left - pbxPlayer2mSM.Width - 7 >= flakHorPosition2 + pbxPlayer2mSM.Width)
                        {
                            flakHorPosition2 = flakHorPosition2 + 7;
                        }
                        break;
                    case "Stop\r":
                        flakHorPosition2M = pbxPlayer2mSM.Left;
                        flakVertPosition2M = pbxPlayer2mSM.Top;
                        break;
                    case "Shot\r":
                        PhotonTorpedo2();
                        break;
                    case "ShotStop\r":
                        break;
                    default:
                        break;
                }
            }

            pbxPlayer1mSM.Left = flakHorPosition;
            pbxPlayer1mSM.Top = flakVertPosition;

            pbxPlayer2mSM.Left = flakHorPosition2M;
            pbxPlayer2mSM.Top = flakVertPosition2M;
            

        }

        #endregion

        #endregion

        //THIS WAY THE REGION BOUNDARIES CAN BE FOUND EASIER

    }
}
