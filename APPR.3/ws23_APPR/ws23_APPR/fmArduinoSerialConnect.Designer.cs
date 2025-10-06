namespace ws23_APPR
{
    partial class fmArduinoSerialConnect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbxConnectionDkal = new System.Windows.Forms.GroupBox();
            this.btnAboutDkal = new System.Windows.Forms.Button();
            this.btClearInOutBuffer = new System.Windows.Forms.Button();
            this.cbxNewLine = new System.Windows.Forms.CheckBox();
            this.cbxCarriageReturn = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSelectIfDangerShieldIsUsed = new System.Windows.Forms.CheckBox();
            this.lblArduinoConnectionSettingsHelpDkal = new System.Windows.Forms.Label();
            this.btnScanPortsDkal = new System.Windows.Forms.Button();
            this.cbbSerialPortsDkal = new System.Windows.Forms.ComboBox();
            this.cbbBaudRateDkal = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSerialPortOpenDkal = new System.Windows.Forms.Button();
            this.gbxLoggingDkal = new System.Windows.Forms.GroupBox();
            this.rtbLogging = new System.Windows.Forms.RichTextBox();
            this.serialPortArduinoConnection = new System.IO.Ports.SerialPort(this.components);
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpStartUpScreen = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStartApplication = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbpSerCom = new System.Windows.Forms.TabPage();
            this.tbpTestGround = new System.Windows.Forms.TabPage();
            this.pbrarduinoReader = new System.Windows.Forms.ProgressBar();
            this.btnResetArduino = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnWriteDefault = new System.Windows.Forms.Button();
            this.txbWriteCustom = new System.Windows.Forms.TextBox();
            this.lblSent = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.lblReturned = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnWrite = new System.Windows.Forms.Button();
            this.tbpCustomApplication = new System.Windows.Forms.TabPage();
            this.tbpQuickGuide = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.mstMain = new System.Windows.Forms.MenuStrip();
            this.msiSca = new System.Windows.Forms.ToolStripMenuItem();
            this.msiScaAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.msiScaQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.msiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.msiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.msiView = new System.Windows.Forms.ToolStripMenuItem();
            this.msiViewCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.msiViewSerialCommunication = new System.Windows.Forms.ToolStripMenuItem();
            this.msiViewTestGround = new System.Windows.Forms.ToolStripMenuItem();
            this.msiQuickGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.msiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.msiLogging = new System.Windows.Forms.ToolStripMenuItem();
            this.gbxConnectionDkal.SuspendLayout();
            this.gbxLoggingDkal.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.tbpStartUpScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tbpSerCom.SuspendLayout();
            this.tbpTestGround.SuspendLayout();
            this.tbpQuickGuide.SuspendLayout();
            this.mstMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxConnectionDkal
            // 
            this.gbxConnectionDkal.Controls.Add(this.btnAboutDkal);
            this.gbxConnectionDkal.Controls.Add(this.btClearInOutBuffer);
            this.gbxConnectionDkal.Controls.Add(this.cbxNewLine);
            this.gbxConnectionDkal.Controls.Add(this.cbxCarriageReturn);
            this.gbxConnectionDkal.Controls.Add(this.label1);
            this.gbxConnectionDkal.Controls.Add(this.label7);
            this.gbxConnectionDkal.Controls.Add(this.cbSelectIfDangerShieldIsUsed);
            this.gbxConnectionDkal.Controls.Add(this.lblArduinoConnectionSettingsHelpDkal);
            this.gbxConnectionDkal.Controls.Add(this.btnScanPortsDkal);
            this.gbxConnectionDkal.Controls.Add(this.cbbSerialPortsDkal);
            this.gbxConnectionDkal.Controls.Add(this.cbbBaudRateDkal);
            this.gbxConnectionDkal.Controls.Add(this.label17);
            this.gbxConnectionDkal.Controls.Add(this.btnSerialPortOpenDkal);
            this.gbxConnectionDkal.Location = new System.Drawing.Point(5, 9);
            this.gbxConnectionDkal.Name = "gbxConnectionDkal";
            this.gbxConnectionDkal.Size = new System.Drawing.Size(143, 288);
            this.gbxConnectionDkal.TabIndex = 24;
            this.gbxConnectionDkal.TabStop = false;
            this.gbxConnectionDkal.Text = "Arduino connection";
            // 
            // btnAboutDkal
            // 
            this.btnAboutDkal.Location = new System.Drawing.Point(8, 254);
            this.btnAboutDkal.Margin = new System.Windows.Forms.Padding(2);
            this.btnAboutDkal.Name = "btnAboutDkal";
            this.btnAboutDkal.Size = new System.Drawing.Size(125, 23);
            this.btnAboutDkal.TabIndex = 26;
            this.btnAboutDkal.Text = "About";
            this.btnAboutDkal.UseVisualStyleBackColor = true;
            this.btnAboutDkal.Click += new System.EventHandler(this.btnAboutDkal_Click);
            // 
            // btClearInOutBuffer
            // 
            this.btClearInOutBuffer.Location = new System.Drawing.Point(8, 225);
            this.btClearInOutBuffer.Name = "btClearInOutBuffer";
            this.btClearInOutBuffer.Size = new System.Drawing.Size(125, 23);
            this.btClearInOutBuffer.TabIndex = 30;
            this.btClearInOutBuffer.Text = "Clear InOut Buffer";
            this.btClearInOutBuffer.UseVisualStyleBackColor = true;
            this.btClearInOutBuffer.Click += new System.EventHandler(this.btClearInOutBuffer_Click);
            // 
            // cbxNewLine
            // 
            this.cbxNewLine.AutoSize = true;
            this.cbxNewLine.Location = new System.Drawing.Point(11, 173);
            this.cbxNewLine.Name = "cbxNewLine";
            this.cbxNewLine.Size = new System.Drawing.Size(85, 17);
            this.cbxNewLine.TabIndex = 29;
            this.cbxNewLine.Text = "new line:  \\n";
            this.cbxNewLine.UseVisualStyleBackColor = true;
            // 
            // cbxCarriageReturn
            // 
            this.cbxCarriageReturn.AutoSize = true;
            this.cbxCarriageReturn.Location = new System.Drawing.Point(11, 150);
            this.cbxCarriageReturn.Name = "cbxCarriageReturn";
            this.cbxCarriageReturn.Size = new System.Drawing.Size(108, 17);
            this.cbxCarriageReturn.TabIndex = 28;
            this.cbxCarriageReturn.Text = "carriage return: \\r";
            this.cbxCarriageReturn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "line ending in Tx data:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Port:";
            // 
            // cbSelectIfDangerShieldIsUsed
            // 
            this.cbSelectIfDangerShieldIsUsed.AutoSize = true;
            this.cbSelectIfDangerShieldIsUsed.Location = new System.Drawing.Point(9, 48);
            this.cbSelectIfDangerShieldIsUsed.Name = "cbSelectIfDangerShieldIsUsed";
            this.cbSelectIfDangerShieldIsUsed.Size = new System.Drawing.Size(128, 17);
            this.cbSelectIfDangerShieldIsUsed.TabIndex = 11;
            this.cbSelectIfDangerShieldIsUsed.Text = "remove last character";
            this.cbSelectIfDangerShieldIsUsed.UseVisualStyleBackColor = true;
            // 
            // lblArduinoConnectionSettingsHelpDkal
            // 
            this.lblArduinoConnectionSettingsHelpDkal.AutoSize = true;
            this.lblArduinoConnectionSettingsHelpDkal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblArduinoConnectionSettingsHelpDkal.Location = new System.Drawing.Point(378, 0);
            this.lblArduinoConnectionSettingsHelpDkal.Name = "lblArduinoConnectionSettingsHelpDkal";
            this.lblArduinoConnectionSettingsHelpDkal.Size = new System.Drawing.Size(13, 13);
            this.lblArduinoConnectionSettingsHelpDkal.TabIndex = 10;
            this.lblArduinoConnectionSettingsHelpDkal.Text = "?";
            // 
            // btnScanPortsDkal
            // 
            this.btnScanPortsDkal.Location = new System.Drawing.Point(9, 19);
            this.btnScanPortsDkal.Name = "btnScanPortsDkal";
            this.btnScanPortsDkal.Size = new System.Drawing.Size(128, 23);
            this.btnScanPortsDkal.TabIndex = 3;
            this.btnScanPortsDkal.Text = "Scan USB ports";
            this.btnScanPortsDkal.UseVisualStyleBackColor = true;
            this.btnScanPortsDkal.Click += new System.EventHandler(this.btnScanPortsDkal_Click);
            // 
            // cbbSerialPortsDkal
            // 
            this.cbbSerialPortsDkal.FormattingEnabled = true;
            this.cbbSerialPortsDkal.Location = new System.Drawing.Point(41, 71);
            this.cbbSerialPortsDkal.Name = "cbbSerialPortsDkal";
            this.cbbSerialPortsDkal.Size = new System.Drawing.Size(93, 21);
            this.cbbSerialPortsDkal.TabIndex = 2;
            this.cbbSerialPortsDkal.SelectedIndexChanged += new System.EventHandler(this.cbbSerialPortsDkal_SelectedIndexChanged);
            // 
            // cbbBaudRateDkal
            // 
            this.cbbBaudRateDkal.FormattingEnabled = true;
            this.cbbBaudRateDkal.Items.AddRange(new object[] {
            "select..",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbbBaudRateDkal.Location = new System.Drawing.Point(9, 111);
            this.cbbBaudRateDkal.Name = "cbbBaudRateDkal";
            this.cbbBaudRateDkal.Size = new System.Drawing.Size(125, 21);
            this.cbbBaudRateDkal.TabIndex = 4;
            this.cbbBaudRateDkal.SelectedIndexChanged += new System.EventHandler(this.cbbBaudRateDkal_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Enabled = false;
            this.label17.Location = new System.Drawing.Point(6, 95);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(123, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "select Arduino Baudrate:";
            // 
            // btnSerialPortOpenDkal
            // 
            this.btnSerialPortOpenDkal.Enabled = false;
            this.btnSerialPortOpenDkal.Location = new System.Drawing.Point(8, 196);
            this.btnSerialPortOpenDkal.Name = "btnSerialPortOpenDkal";
            this.btnSerialPortOpenDkal.Size = new System.Drawing.Size(125, 23);
            this.btnSerialPortOpenDkal.TabIndex = 6;
            this.btnSerialPortOpenDkal.Text = "Open port";
            this.btnSerialPortOpenDkal.UseVisualStyleBackColor = true;
            this.btnSerialPortOpenDkal.Click += new System.EventHandler(this.btnSerialPortOpenDkal_Click);
            // 
            // gbxLoggingDkal
            // 
            this.gbxLoggingDkal.Controls.Add(this.rtbLogging);
            this.gbxLoggingDkal.Location = new System.Drawing.Point(154, 9);
            this.gbxLoggingDkal.Name = "gbxLoggingDkal";
            this.gbxLoggingDkal.Size = new System.Drawing.Size(461, 288);
            this.gbxLoggingDkal.TabIndex = 25;
            this.gbxLoggingDkal.TabStop = false;
            this.gbxLoggingDkal.Text = "Logging: double click to clear";
            // 
            // rtbLogging
            // 
            this.rtbLogging.BackColor = System.Drawing.Color.White;
            this.rtbLogging.Location = new System.Drawing.Point(6, 19);
            this.rtbLogging.Name = "rtbLogging";
            this.rtbLogging.Size = new System.Drawing.Size(449, 264);
            this.rtbLogging.TabIndex = 0;
            this.rtbLogging.Text = "";
            this.rtbLogging.WordWrap = false;
            this.rtbLogging.DoubleClick += new System.EventHandler(this.rtbLogging_DoubleClick);
            // 
            // serialPortArduinoConnection
            // 
            this.serialPortArduinoConnection.BaudRate = 115200;
            this.serialPortArduinoConnection.DtrEnable = true;
            this.serialPortArduinoConnection.ReadBufferSize = 19200;
            this.serialPortArduinoConnection.ReadTimeout = 5000;
            this.serialPortArduinoConnection.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortArduinoConnection_DataReceived);
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tbpStartUpScreen);
            this.tbcMain.Controls.Add(this.tbpSerCom);
            this.tbcMain.Controls.Add(this.tbpTestGround);
            this.tbcMain.Controls.Add(this.tbpCustomApplication);
            this.tbcMain.Controls.Add(this.tbpQuickGuide);
            this.tbcMain.Location = new System.Drawing.Point(9, 24);
            this.tbcMain.Margin = new System.Windows.Forms.Padding(2);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(628, 328);
            this.tbcMain.TabIndex = 26;
            // 
            // tbpStartUpScreen
            // 
            this.tbpStartUpScreen.Controls.Add(this.label5);
            this.tbpStartUpScreen.Controls.Add(this.btnStartApplication);
            this.tbpStartUpScreen.Controls.Add(this.pictureBox1);
            this.tbpStartUpScreen.Location = new System.Drawing.Point(4, 22);
            this.tbpStartUpScreen.Margin = new System.Windows.Forms.Padding(2);
            this.tbpStartUpScreen.Name = "tbpStartUpScreen";
            this.tbpStartUpScreen.Size = new System.Drawing.Size(620, 302);
            this.tbpStartUpScreen.TabIndex = 3;
            this.tbpStartUpScreen.Text = "StartUpScreen";
            this.tbpStartUpScreen.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Turquoise;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 43);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(579, 31);
            this.label5.TabIndex = 2;
            this.label5.Text = "Serial Communication Arduino (SCA) Template";
            // 
            // btnStartApplication
            // 
            this.btnStartApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartApplication.Location = new System.Drawing.Point(14, 87);
            this.btnStartApplication.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartApplication.Name = "btnStartApplication";
            this.btnStartApplication.Size = new System.Drawing.Size(105, 38);
            this.btnStartApplication.TabIndex = 1;
            this.btnStartApplication.Text = "Start";
            this.btnStartApplication.UseVisualStyleBackColor = true;
            this.btnStartApplication.Click += new System.EventHandler(this.btnStartApplication_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Turquoise;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(617, 300);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tbpSerCom
            // 
            this.tbpSerCom.Controls.Add(this.gbxConnectionDkal);
            this.tbpSerCom.Controls.Add(this.gbxLoggingDkal);
            this.tbpSerCom.Location = new System.Drawing.Point(4, 22);
            this.tbpSerCom.Margin = new System.Windows.Forms.Padding(2);
            this.tbpSerCom.Name = "tbpSerCom";
            this.tbpSerCom.Padding = new System.Windows.Forms.Padding(2);
            this.tbpSerCom.Size = new System.Drawing.Size(620, 302);
            this.tbpSerCom.TabIndex = 0;
            this.tbpSerCom.Text = "SerCom";
            this.tbpSerCom.UseVisualStyleBackColor = true;
            // 
            // tbpTestGround
            // 
            this.tbpTestGround.Controls.Add(this.pbrarduinoReader);
            this.tbpTestGround.Controls.Add(this.btnResetArduino);
            this.tbpTestGround.Controls.Add(this.label3);
            this.tbpTestGround.Controls.Add(this.btnWriteDefault);
            this.tbpTestGround.Controls.Add(this.txbWriteCustom);
            this.tbpTestGround.Controls.Add(this.lblSent);
            this.tbpTestGround.Controls.Add(this.label2);
            this.tbpTestGround.Controls.Add(this.btnRead);
            this.tbpTestGround.Controls.Add(this.lblReturned);
            this.tbpTestGround.Controls.Add(this.label4);
            this.tbpTestGround.Controls.Add(this.btnWrite);
            this.tbpTestGround.Location = new System.Drawing.Point(4, 22);
            this.tbpTestGround.Margin = new System.Windows.Forms.Padding(2);
            this.tbpTestGround.Name = "tbpTestGround";
            this.tbpTestGround.Padding = new System.Windows.Forms.Padding(2);
            this.tbpTestGround.Size = new System.Drawing.Size(620, 302);
            this.tbpTestGround.TabIndex = 1;
            this.tbpTestGround.Text = "TestGround";
            this.tbpTestGround.UseVisualStyleBackColor = true;
            // 
            // pbrarduinoReader
            // 
            this.pbrarduinoReader.Location = new System.Drawing.Point(89, 8);
            this.pbrarduinoReader.Maximum = 1023;
            this.pbrarduinoReader.Name = "pbrarduinoReader";
            this.pbrarduinoReader.Size = new System.Drawing.Size(170, 23);
            this.pbrarduinoReader.TabIndex = 21;
            // 
            // btnResetArduino
            // 
            this.btnResetArduino.Location = new System.Drawing.Point(5, 6);
            this.btnResetArduino.Name = "btnResetArduino";
            this.btnResetArduino.Size = new System.Drawing.Size(75, 23);
            this.btnResetArduino.TabIndex = 20;
            this.btnResetArduino.Text = "Reset Arduino";
            this.btnResetArduino.UseVisualStyleBackColor = true;
            this.btnResetArduino.Click += new System.EventHandler(this.btnResetArduino_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "custom:";
            // 
            // btnWriteDefault
            // 
            this.btnWriteDefault.Location = new System.Drawing.Point(5, 63);
            this.btnWriteDefault.Name = "btnWriteDefault";
            this.btnWriteDefault.Size = new System.Drawing.Size(75, 23);
            this.btnWriteDefault.TabIndex = 18;
            this.btnWriteDefault.Text = "Write default";
            this.btnWriteDefault.UseVisualStyleBackColor = true;
            this.btnWriteDefault.Click += new System.EventHandler(this.btnWriteDefault_Click);
            // 
            // txbWriteCustom
            // 
            this.txbWriteCustom.Location = new System.Drawing.Point(149, 37);
            this.txbWriteCustom.Name = "txbWriteCustom";
            this.txbWriteCustom.Size = new System.Drawing.Size(110, 20);
            this.txbWriteCustom.TabIndex = 17;
            // 
            // lblSent
            // 
            this.lblSent.AutoSize = true;
            this.lblSent.Location = new System.Drawing.Point(146, 68);
            this.lblSent.Name = "lblSent";
            this.lblSent.Size = new System.Drawing.Size(16, 13);
            this.lblSent.TabIndex = 16;
            this.lblSent.Text = "---";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Sent:";
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(5, 93);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 14;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // lblReturned
            // 
            this.lblReturned.AutoSize = true;
            this.lblReturned.Location = new System.Drawing.Point(146, 98);
            this.lblReturned.Name = "lblReturned";
            this.lblReturned.Size = new System.Drawing.Size(16, 13);
            this.lblReturned.TabIndex = 12;
            this.lblReturned.Text = "---";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Returned:";
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(5, 34);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 11;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // tbpCustomApplication
            // 
            this.tbpCustomApplication.Location = new System.Drawing.Point(4, 22);
            this.tbpCustomApplication.Margin = new System.Windows.Forms.Padding(2);
            this.tbpCustomApplication.Name = "tbpCustomApplication";
            this.tbpCustomApplication.Padding = new System.Windows.Forms.Padding(2);
            this.tbpCustomApplication.Size = new System.Drawing.Size(620, 302);
            this.tbpCustomApplication.TabIndex = 2;
            this.tbpCustomApplication.Text = "Custom";
            this.tbpCustomApplication.UseVisualStyleBackColor = true;
            // 
            // tbpQuickGuide
            // 
            this.tbpQuickGuide.Controls.Add(this.label6);
            this.tbpQuickGuide.Location = new System.Drawing.Point(4, 22);
            this.tbpQuickGuide.Margin = new System.Windows.Forms.Padding(2);
            this.tbpQuickGuide.Name = "tbpQuickGuide";
            this.tbpQuickGuide.Padding = new System.Windows.Forms.Padding(2);
            this.tbpQuickGuide.Size = new System.Drawing.Size(620, 302);
            this.tbpQuickGuide.TabIndex = 4;
            this.tbpQuickGuide.Text = "Quick guide";
            this.tbpQuickGuide.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 10);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(220, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Create a workflow here to quickly get started!";
            // 
            // mstMain
            // 
            this.mstMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mstMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msiSca,
            this.msiFile,
            this.msiEdit,
            this.msiView,
            this.msiHelp,
            this.msiLogging});
            this.mstMain.Location = new System.Drawing.Point(0, 0);
            this.mstMain.Name = "mstMain";
            this.mstMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.mstMain.Size = new System.Drawing.Size(641, 24);
            this.mstMain.TabIndex = 27;
            this.mstMain.Text = "menuStrip1";
            // 
            // msiSca
            // 
            this.msiSca.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msiScaAbout,
            this.msiScaQuit});
            this.msiSca.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.msiSca.Name = "msiSca";
            this.msiSca.Size = new System.Drawing.Size(41, 20);
            this.msiSca.Text = "SCA";
            // 
            // msiScaAbout
            // 
            this.msiScaAbout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.msiScaAbout.Name = "msiScaAbout";
            this.msiScaAbout.Size = new System.Drawing.Size(172, 22);
            this.msiScaAbout.Text = "About..";
            this.msiScaAbout.Click += new System.EventHandler(this.btnAboutDkal_Click);
            // 
            // msiScaQuit
            // 
            this.msiScaQuit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.msiScaQuit.Name = "msiScaQuit";
            this.msiScaQuit.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
            this.msiScaQuit.Size = new System.Drawing.Size(172, 22);
            this.msiScaQuit.Text = "Quit";
            this.msiScaQuit.Click += new System.EventHandler(this.msiScaQuit_Click);
            // 
            // msiFile
            // 
            this.msiFile.Name = "msiFile";
            this.msiFile.Size = new System.Drawing.Size(37, 20);
            this.msiFile.Text = "File";
            // 
            // msiEdit
            // 
            this.msiEdit.Name = "msiEdit";
            this.msiEdit.Size = new System.Drawing.Size(39, 20);
            this.msiEdit.Text = "Edit";
            // 
            // msiView
            // 
            this.msiView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msiViewCustom,
            this.msiViewSerialCommunication,
            this.msiViewTestGround,
            this.msiQuickGuide});
            this.msiView.Name = "msiView";
            this.msiView.Size = new System.Drawing.Size(44, 20);
            this.msiView.Text = "View";
            // 
            // msiViewCustom
            // 
            this.msiViewCustom.Name = "msiViewCustom";
            this.msiViewCustom.Size = new System.Drawing.Size(192, 22);
            this.msiViewCustom.Text = "Custom";
            this.msiViewCustom.Click += new System.EventHandler(this.msiViewCustom_Click);
            // 
            // msiViewSerialCommunication
            // 
            this.msiViewSerialCommunication.Name = "msiViewSerialCommunication";
            this.msiViewSerialCommunication.Size = new System.Drawing.Size(192, 22);
            this.msiViewSerialCommunication.Text = "Serial Communication";
            this.msiViewSerialCommunication.Click += new System.EventHandler(this.msiViewSerialCommunication_Click);
            // 
            // msiViewTestGround
            // 
            this.msiViewTestGround.Name = "msiViewTestGround";
            this.msiViewTestGround.Size = new System.Drawing.Size(192, 22);
            this.msiViewTestGround.Text = "Test Ground";
            this.msiViewTestGround.Click += new System.EventHandler(this.msiViewTestGround_Click);
            // 
            // msiQuickGuide
            // 
            this.msiQuickGuide.Name = "msiQuickGuide";
            this.msiQuickGuide.Size = new System.Drawing.Size(192, 22);
            this.msiQuickGuide.Text = "Quick guide";
            this.msiQuickGuide.Click += new System.EventHandler(this.msiQuickGuide_Click);
            // 
            // msiHelp
            // 
            this.msiHelp.Name = "msiHelp";
            this.msiHelp.Size = new System.Drawing.Size(44, 20);
            this.msiHelp.Text = "Help";
            this.msiHelp.Click += new System.EventHandler(this.msiHelp_Click);
            // 
            // msiLogging
            // 
            this.msiLogging.CheckOnClick = true;
            this.msiLogging.Name = "msiLogging";
            this.msiLogging.Size = new System.Drawing.Size(63, 20);
            this.msiLogging.Text = "Logging";
            this.msiLogging.Click += new System.EventHandler(this.msiLogging_Click);
            // 
            // fmArduinoSerialConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 362);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.mstMain);
            this.MainMenuStrip = this.mstMain;
            this.Name = "fmArduinoSerialConnect";
            this.Text = "Arduino Serial Connect";
            this.Load += new System.EventHandler(this.fmArduinoSerialConnect_Load);
            this.gbxConnectionDkal.ResumeLayout(false);
            this.gbxConnectionDkal.PerformLayout();
            this.gbxLoggingDkal.ResumeLayout(false);
            this.tbcMain.ResumeLayout(false);
            this.tbpStartUpScreen.ResumeLayout(false);
            this.tbpStartUpScreen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tbpSerCom.ResumeLayout(false);
            this.tbpTestGround.ResumeLayout(false);
            this.tbpTestGround.PerformLayout();
            this.tbpQuickGuide.ResumeLayout(false);
            this.tbpQuickGuide.PerformLayout();
            this.mstMain.ResumeLayout(false);
            this.mstMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxConnectionDkal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbSelectIfDangerShieldIsUsed;
        private System.Windows.Forms.Label lblArduinoConnectionSettingsHelpDkal;
        private System.Windows.Forms.Button btnScanPortsDkal;
        private System.Windows.Forms.ComboBox cbbSerialPortsDkal;
        private System.Windows.Forms.ComboBox cbbBaudRateDkal;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnSerialPortOpenDkal;
        private System.Windows.Forms.GroupBox gbxLoggingDkal;
        private System.Windows.Forms.RichTextBox rtbLogging;
        private System.IO.Ports.SerialPort serialPortArduinoConnection;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxNewLine;
        private System.Windows.Forms.CheckBox cbxCarriageReturn;
        private System.Windows.Forms.Button btClearInOutBuffer;
        private System.Windows.Forms.Button btnAboutDkal;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpSerCom;
        private System.Windows.Forms.TabPage tbpTestGround;
        private System.Windows.Forms.TabPage tbpCustomApplication;
        private System.Windows.Forms.MenuStrip mstMain;
        private System.Windows.Forms.ToolStripMenuItem msiSca;
        private System.Windows.Forms.ToolStripMenuItem msiScaAbout;
        private System.Windows.Forms.ToolStripMenuItem msiScaQuit;
        private System.Windows.Forms.ToolStripMenuItem msiFile;
        private System.Windows.Forms.ToolStripMenuItem msiEdit;
        private System.Windows.Forms.ToolStripMenuItem msiView;
        private System.Windows.Forms.ToolStripMenuItem msiHelp;
        private System.Windows.Forms.TabPage tbpStartUpScreen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnResetArduino;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnWriteDefault;
        private System.Windows.Forms.TextBox txbWriteCustom;
        private System.Windows.Forms.Label lblSent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label lblReturned;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.ToolStripMenuItem msiViewCustom;
        private System.Windows.Forms.ToolStripMenuItem msiViewSerialCommunication;
        private System.Windows.Forms.ToolStripMenuItem msiViewTestGround;
        private System.Windows.Forms.ToolStripMenuItem msiLogging;
        private System.Windows.Forms.Button btnStartApplication;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tbpQuickGuide;
        private System.Windows.Forms.ToolStripMenuItem msiQuickGuide;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar pbrarduinoReader;
    }
}