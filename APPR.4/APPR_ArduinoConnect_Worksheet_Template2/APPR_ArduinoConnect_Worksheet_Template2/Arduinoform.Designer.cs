namespace APPR_ArduinoConnect_Worksheet_Template2
{
    partial class Arduinoform
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
            this.txbSendMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnZeroAll = new System.Windows.Forms.Button();
            this.btnPossibleMessages = new System.Windows.Forms.Button();
            this.gbxSend = new System.Windows.Forms.GroupBox();
            this.serialPortArduinoConnection = new System.IO.Ports.SerialPort(this.components);
            this.rtbLogging = new System.Windows.Forms.RichTextBox();
            this.gbxLoggingDkal = new System.Windows.Forms.GroupBox();
            this.btnSerialPortOpenDkal = new System.Windows.Forms.Button();
            this.cbbSerialPortsDkal = new System.Windows.Forms.ComboBox();
            this.btnScanPortsDkal = new System.Windows.Forms.Button();
            this.lblArduinoConnectionSettingsHelpDkal = new System.Windows.Forms.Label();
            this.lblPortText = new System.Windows.Forms.Label();
            this.gbxConnectionDkal = new System.Windows.Forms.GroupBox();
            this.gbxSend.SuspendLayout();
            this.gbxLoggingDkal.SuspendLayout();
            this.gbxConnectionDkal.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbSendMessage
            // 
            this.txbSendMessage.Enabled = false;
            this.txbSendMessage.Location = new System.Drawing.Point(156, 19);
            this.txbSendMessage.Name = "txbSendMessage";
            this.txbSendMessage.Size = new System.Drawing.Size(100, 20);
            this.txbSendMessage.TabIndex = 0;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Enabled = false;
            this.btnSendMessage.Location = new System.Drawing.Point(12, 16);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(138, 24);
            this.btnSendMessage.TabIndex = 1;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnZeroAll
            // 
            this.btnZeroAll.Enabled = false;
            this.btnZeroAll.Location = new System.Drawing.Point(420, 15);
            this.btnZeroAll.Name = "btnZeroAll";
            this.btnZeroAll.Size = new System.Drawing.Size(138, 24);
            this.btnZeroAll.TabIndex = 2;
            this.btnZeroAll.Text = "Zero all";
            this.btnZeroAll.UseVisualStyleBackColor = true;
            this.btnZeroAll.Click += new System.EventHandler(this.btnZeroAll_Click);
            // 
            // btnPossibleMessages
            // 
            this.btnPossibleMessages.Location = new System.Drawing.Point(276, 15);
            this.btnPossibleMessages.Name = "btnPossibleMessages";
            this.btnPossibleMessages.Size = new System.Drawing.Size(138, 24);
            this.btnPossibleMessages.TabIndex = 3;
            this.btnPossibleMessages.Text = "Options";
            this.btnPossibleMessages.UseVisualStyleBackColor = true;
            this.btnPossibleMessages.Click += new System.EventHandler(this.btnPossibleMessages_Click);
            // 
            // gbxSend
            // 
            this.gbxSend.Controls.Add(this.btnPossibleMessages);
            this.gbxSend.Controls.Add(this.btnZeroAll);
            this.gbxSend.Controls.Add(this.btnSendMessage);
            this.gbxSend.Controls.Add(this.txbSendMessage);
            this.gbxSend.Location = new System.Drawing.Point(12, 126);
            this.gbxSend.Name = "gbxSend";
            this.gbxSend.Size = new System.Drawing.Size(567, 46);
            this.gbxSend.TabIndex = 30;
            this.gbxSend.TabStop = false;
            this.gbxSend.Text = "Send message";
            // 
            // serialPortArduinoConnection
            // 
            this.serialPortArduinoConnection.BaudRate = 115200;
            this.serialPortArduinoConnection.DtrEnable = true;
            this.serialPortArduinoConnection.ReadBufferSize = 19200;
            this.serialPortArduinoConnection.ReadTimeout = 5000;
            this.serialPortArduinoConnection.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortArduinoConnection_DataReceived);
            // 
            // rtbLogging
            // 
            this.rtbLogging.BackColor = System.Drawing.Color.White;
            this.rtbLogging.Location = new System.Drawing.Point(6, 19);
            this.rtbLogging.Name = "rtbLogging";
            this.rtbLogging.Size = new System.Drawing.Size(406, 82);
            this.rtbLogging.TabIndex = 0;
            this.rtbLogging.Text = "";
            this.rtbLogging.WordWrap = false;
            this.rtbLogging.TextChanged += new System.EventHandler(this.rtbLogging_TextChanged);
            // 
            // gbxLoggingDkal
            // 
            this.gbxLoggingDkal.Controls.Add(this.rtbLogging);
            this.gbxLoggingDkal.Location = new System.Drawing.Point(161, 12);
            this.gbxLoggingDkal.Name = "gbxLoggingDkal";
            this.gbxLoggingDkal.Size = new System.Drawing.Size(418, 108);
            this.gbxLoggingDkal.TabIndex = 29;
            this.gbxLoggingDkal.TabStop = false;
            this.gbxLoggingDkal.Text = "Logging: double click to clear";
            // 
            // btnSerialPortOpenDkal
            // 
            this.btnSerialPortOpenDkal.Enabled = false;
            this.btnSerialPortOpenDkal.Location = new System.Drawing.Point(12, 78);
            this.btnSerialPortOpenDkal.Name = "btnSerialPortOpenDkal";
            this.btnSerialPortOpenDkal.Size = new System.Drawing.Size(125, 23);
            this.btnSerialPortOpenDkal.TabIndex = 6;
            this.btnSerialPortOpenDkal.Text = "Open port";
            this.btnSerialPortOpenDkal.UseVisualStyleBackColor = true;
            this.btnSerialPortOpenDkal.Click += new System.EventHandler(this.btnSerialPortOpenDkal_Click);
            // 
            // cbbSerialPortsDkal
            // 
            this.cbbSerialPortsDkal.FormattingEnabled = true;
            this.cbbSerialPortsDkal.Location = new System.Drawing.Point(41, 51);
            this.cbbSerialPortsDkal.Name = "cbbSerialPortsDkal";
            this.cbbSerialPortsDkal.Size = new System.Drawing.Size(93, 21);
            this.cbbSerialPortsDkal.TabIndex = 2;
            this.cbbSerialPortsDkal.SelectedIndexChanged += new System.EventHandler(this.cbbSerialPortsDkal_SelectedIndexChanged);
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
            // lblPortText
            // 
            this.lblPortText.AutoSize = true;
            this.lblPortText.Location = new System.Drawing.Point(6, 54);
            this.lblPortText.Name = "lblPortText";
            this.lblPortText.Size = new System.Drawing.Size(29, 13);
            this.lblPortText.TabIndex = 26;
            this.lblPortText.Text = "Port:";
            // 
            // gbxConnectionDkal
            // 
            this.gbxConnectionDkal.Controls.Add(this.lblPortText);
            this.gbxConnectionDkal.Controls.Add(this.lblArduinoConnectionSettingsHelpDkal);
            this.gbxConnectionDkal.Controls.Add(this.btnScanPortsDkal);
            this.gbxConnectionDkal.Controls.Add(this.cbbSerialPortsDkal);
            this.gbxConnectionDkal.Controls.Add(this.btnSerialPortOpenDkal);
            this.gbxConnectionDkal.Location = new System.Drawing.Point(12, 12);
            this.gbxConnectionDkal.Name = "gbxConnectionDkal";
            this.gbxConnectionDkal.Size = new System.Drawing.Size(143, 108);
            this.gbxConnectionDkal.TabIndex = 28;
            this.gbxConnectionDkal.TabStop = false;
            this.gbxConnectionDkal.Text = "Arduino connection";
            // 
            // Arduinoform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 184);
            this.Controls.Add(this.gbxSend);
            this.Controls.Add(this.gbxConnectionDkal);
            this.Controls.Add(this.gbxLoggingDkal);
            this.Name = "Arduinoform";
            this.Text = "Form1";
            this.gbxSend.ResumeLayout(false);
            this.gbxSend.PerformLayout();
            this.gbxLoggingDkal.ResumeLayout(false);
            this.gbxConnectionDkal.ResumeLayout(false);
            this.gbxConnectionDkal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txbSendMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnZeroAll;
        private System.Windows.Forms.Button btnPossibleMessages;
        private System.Windows.Forms.GroupBox gbxSend;
        private System.IO.Ports.SerialPort serialPortArduinoConnection;
        private System.Windows.Forms.RichTextBox rtbLogging;
        private System.Windows.Forms.GroupBox gbxLoggingDkal;
        private System.Windows.Forms.Button btnSerialPortOpenDkal;
        private System.Windows.Forms.ComboBox cbbSerialPortsDkal;
        private System.Windows.Forms.Button btnScanPortsDkal;
        private System.Windows.Forms.Label lblArduinoConnectionSettingsHelpDkal;
        private System.Windows.Forms.Label lblPortText;
        private System.Windows.Forms.GroupBox gbxConnectionDkal;
    }
}

