using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//for the Arduino Serial project
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ws23_APPR
{
    public partial class fmArduinoSerialConnect : Form
    {
        fmLogging fmLoggingWindow = new fmLogging();

        private delegate void SafeCallDelegate();

        String receivedString = "";
        String receivedStringLast = "";

        public fmArduinoSerialConnect()
        {
            InitializeComponent();
        }

        private void fmArduinoSerialConnect_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;

            this.Left = 100;
            this.Top = 100;

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
        }

        private void msiViewCustom_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tbpCustomApplication;
        }

        private void msiHelp_Click(object sender, EventArgs e)
        {

        }

        private void msiQuickGuide_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tbpQuickGuide;
        }

        private void msiViewSerialCommunication_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tbpSerCom;
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

        private void ShowRecievedDataInProgressBar(string a_receivedString)
        {
            int m_pgbValue = 0;

            if(a_receivedString.IndexOf("RX: ") >= 0)
            {
                m_pgbValue = Convert.ToInt32(a_receivedString.Substring(3));
            }
            else
            {
                PrintLn("API call not recognized", "R");
            }
            pbrarduinoReader.Value = m_pgbValue;
        }


        #endregion

        //THIS WAY THE REGION BOUNDARIES CAN BE FOUND EASIER

        #region Custom

        #endregion

        //THIS WAY THE REGION BOUNDARIES CAN BE FOUND EASIER

    }
}
