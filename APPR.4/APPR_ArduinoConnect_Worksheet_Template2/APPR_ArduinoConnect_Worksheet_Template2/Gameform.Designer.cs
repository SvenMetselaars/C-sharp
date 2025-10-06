namespace APPR_ArduinoConnect_Worksheet_Template2
{
    partial class Gameform
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
            this.btnSaveLocation = new System.Windows.Forms.Button();
            this.btnRunApplication = new System.Windows.Forms.Button();
            this.txbHorizontal = new System.Windows.Forms.TextBox();
            this.txbVertical = new System.Windows.Forms.TextBox();
            this.txbRotation = new System.Windows.Forms.TextBox();
            this.lblHorizontalText = new System.Windows.Forms.Label();
            this.lblVerticalText = new System.Windows.Forms.Label();
            this.lblRotationText = new System.Windows.Forms.Label();
            this.gbxLocations = new System.Windows.Forms.GroupBox();
            this.lblCurrentLocationtype = new System.Windows.Forms.Label();
            this.lblLocationtypeText = new System.Windows.Forms.Label();
            this.gbxConnectArduino = new System.Windows.Forms.GroupBox();
            this.lblConnected = new System.Windows.Forms.Label();
            this.lblConnectedText = new System.Windows.Forms.Label();
            this.btnConnectArduino = new System.Windows.Forms.Button();
            this.gbxLocationList = new System.Windows.Forms.GroupBox();
            this.lblArduinoBuisy = new System.Windows.Forms.Label();
            this.lblArduinoBuisyText = new System.Windows.Forms.Label();
            this.lbxLocationList = new System.Windows.Forms.ListBox();
            this.tmrArduino = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.gbxLocations.SuspendLayout();
            this.gbxConnectArduino.SuspendLayout();
            this.gbxLocationList.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveLocation
            // 
            this.btnSaveLocation.Location = new System.Drawing.Point(6, 19);
            this.btnSaveLocation.Name = "btnSaveLocation";
            this.btnSaveLocation.Size = new System.Drawing.Size(116, 23);
            this.btnSaveLocation.TabIndex = 0;
            this.btnSaveLocation.Text = "Save location";
            this.btnSaveLocation.UseVisualStyleBackColor = true;
            this.btnSaveLocation.Click += new System.EventHandler(this.btnSaveLocation_Click);
            // 
            // btnRunApplication
            // 
            this.btnRunApplication.Location = new System.Drawing.Point(6, 48);
            this.btnRunApplication.Name = "btnRunApplication";
            this.btnRunApplication.Size = new System.Drawing.Size(116, 23);
            this.btnRunApplication.TabIndex = 3;
            this.btnRunApplication.Text = "Run application";
            this.btnRunApplication.UseVisualStyleBackColor = true;
            this.btnRunApplication.Click += new System.EventHandler(this.btnRunApplication_Click);
            // 
            // txbHorizontal
            // 
            this.txbHorizontal.Location = new System.Drawing.Point(128, 22);
            this.txbHorizontal.Name = "txbHorizontal";
            this.txbHorizontal.Size = new System.Drawing.Size(46, 20);
            this.txbHorizontal.TabIndex = 4;
            this.txbHorizontal.Text = "0";
            // 
            // txbVertical
            // 
            this.txbVertical.Location = new System.Drawing.Point(198, 21);
            this.txbVertical.Name = "txbVertical";
            this.txbVertical.Size = new System.Drawing.Size(46, 20);
            this.txbVertical.TabIndex = 5;
            this.txbVertical.Text = "0";
            // 
            // txbRotation
            // 
            this.txbRotation.Location = new System.Drawing.Point(270, 22);
            this.txbRotation.Name = "txbRotation";
            this.txbRotation.Size = new System.Drawing.Size(46, 20);
            this.txbRotation.TabIndex = 6;
            this.txbRotation.Text = "0";
            // 
            // lblHorizontalText
            // 
            this.lblHorizontalText.AutoSize = true;
            this.lblHorizontalText.Location = new System.Drawing.Point(125, 6);
            this.lblHorizontalText.Name = "lblHorizontalText";
            this.lblHorizontalText.Size = new System.Drawing.Size(54, 13);
            this.lblHorizontalText.TabIndex = 13;
            this.lblHorizontalText.Text = "Horizontal";
            // 
            // lblVerticalText
            // 
            this.lblVerticalText.AutoSize = true;
            this.lblVerticalText.Location = new System.Drawing.Point(195, 6);
            this.lblVerticalText.Name = "lblVerticalText";
            this.lblVerticalText.Size = new System.Drawing.Size(42, 13);
            this.lblVerticalText.TabIndex = 14;
            this.lblVerticalText.Text = "Vertical";
            // 
            // lblRotationText
            // 
            this.lblRotationText.AutoSize = true;
            this.lblRotationText.Location = new System.Drawing.Point(267, 6);
            this.lblRotationText.Name = "lblRotationText";
            this.lblRotationText.Size = new System.Drawing.Size(47, 13);
            this.lblRotationText.TabIndex = 15;
            this.lblRotationText.Text = "Rotation";
            // 
            // gbxLocations
            // 
            this.gbxLocations.Controls.Add(this.lblCurrentLocationtype);
            this.gbxLocations.Controls.Add(this.lblLocationtypeText);
            this.gbxLocations.Controls.Add(this.btnSaveLocation);
            this.gbxLocations.Controls.Add(this.lblRotationText);
            this.gbxLocations.Controls.Add(this.btnRunApplication);
            this.gbxLocations.Controls.Add(this.lblVerticalText);
            this.gbxLocations.Controls.Add(this.txbHorizontal);
            this.gbxLocations.Controls.Add(this.lblHorizontalText);
            this.gbxLocations.Controls.Add(this.txbVertical);
            this.gbxLocations.Controls.Add(this.txbRotation);
            this.gbxLocations.Location = new System.Drawing.Point(12, 70);
            this.gbxLocations.Name = "gbxLocations";
            this.gbxLocations.Size = new System.Drawing.Size(325, 83);
            this.gbxLocations.TabIndex = 16;
            this.gbxLocations.TabStop = false;
            this.gbxLocations.Text = "Save location";
            // 
            // lblCurrentLocationtype
            // 
            this.lblCurrentLocationtype.AutoSize = true;
            this.lblCurrentLocationtype.Location = new System.Drawing.Point(238, 58);
            this.lblCurrentLocationtype.Name = "lblCurrentLocationtype";
            this.lblCurrentLocationtype.Size = new System.Drawing.Size(16, 13);
            this.lblCurrentLocationtype.TabIndex = 20;
            this.lblCurrentLocationtype.Text = "...";
            // 
            // lblLocationtypeText
            // 
            this.lblLocationtypeText.AutoSize = true;
            this.lblLocationtypeText.Location = new System.Drawing.Point(128, 58);
            this.lblLocationtypeText.Name = "lblLocationtypeText";
            this.lblLocationtypeText.Size = new System.Drawing.Size(104, 13);
            this.lblLocationtypeText.TabIndex = 19;
            this.lblLocationtypeText.Text = "Current locationtype:";
            // 
            // gbxConnectArduino
            // 
            this.gbxConnectArduino.Controls.Add(this.lblConnected);
            this.gbxConnectArduino.Controls.Add(this.lblConnectedText);
            this.gbxConnectArduino.Controls.Add(this.btnConnectArduino);
            this.gbxConnectArduino.Location = new System.Drawing.Point(12, 12);
            this.gbxConnectArduino.Name = "gbxConnectArduino";
            this.gbxConnectArduino.Size = new System.Drawing.Size(325, 52);
            this.gbxConnectArduino.TabIndex = 17;
            this.gbxConnectArduino.TabStop = false;
            this.gbxConnectArduino.Text = "Connect arduino";
            // 
            // lblConnected
            // 
            this.lblConnected.AutoSize = true;
            this.lblConnected.Location = new System.Drawing.Point(245, 24);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(21, 13);
            this.lblConnected.TabIndex = 18;
            this.lblConnected.Text = "No";
            // 
            // lblConnectedText
            // 
            this.lblConnectedText.AutoSize = true;
            this.lblConnectedText.Location = new System.Drawing.Point(139, 24);
            this.lblConnectedText.Name = "lblConnectedText";
            this.lblConnectedText.Size = new System.Drawing.Size(100, 13);
            this.lblConnectedText.TabIndex = 17;
            this.lblConnectedText.Text = "Arduino connected:";
            // 
            // btnConnectArduino
            // 
            this.btnConnectArduino.Location = new System.Drawing.Point(6, 19);
            this.btnConnectArduino.Name = "btnConnectArduino";
            this.btnConnectArduino.Size = new System.Drawing.Size(116, 23);
            this.btnConnectArduino.TabIndex = 16;
            this.btnConnectArduino.Text = "Connect arduino";
            this.btnConnectArduino.UseVisualStyleBackColor = true;
            this.btnConnectArduino.Click += new System.EventHandler(this.btnConnectArduino_Click);
            // 
            // gbxLocationList
            // 
            this.gbxLocationList.Controls.Add(this.button1);
            this.gbxLocationList.Controls.Add(this.lblArduinoBuisy);
            this.gbxLocationList.Controls.Add(this.lblArduinoBuisyText);
            this.gbxLocationList.Controls.Add(this.lbxLocationList);
            this.gbxLocationList.Location = new System.Drawing.Point(343, 12);
            this.gbxLocationList.Name = "gbxLocationList";
            this.gbxLocationList.Size = new System.Drawing.Size(242, 141);
            this.gbxLocationList.TabIndex = 18;
            this.gbxLocationList.TabStop = false;
            this.gbxLocationList.Text = "Location list";
            // 
            // lblArduinoBuisy
            // 
            this.lblArduinoBuisy.AutoSize = true;
            this.lblArduinoBuisy.Location = new System.Drawing.Point(85, 24);
            this.lblArduinoBuisy.Name = "lblArduinoBuisy";
            this.lblArduinoBuisy.Size = new System.Drawing.Size(21, 13);
            this.lblArduinoBuisy.TabIndex = 2;
            this.lblArduinoBuisy.Text = "No";
            // 
            // lblArduinoBuisyText
            // 
            this.lblArduinoBuisyText.AutoSize = true;
            this.lblArduinoBuisyText.Location = new System.Drawing.Point(6, 24);
            this.lblArduinoBuisyText.Name = "lblArduinoBuisyText";
            this.lblArduinoBuisyText.Size = new System.Drawing.Size(73, 13);
            this.lblArduinoBuisyText.TabIndex = 1;
            this.lblArduinoBuisyText.Text = "Arduino buisy:";
            // 
            // lbxLocationList
            // 
            this.lbxLocationList.FormattingEnabled = true;
            this.lbxLocationList.Location = new System.Drawing.Point(6, 45);
            this.lbxLocationList.Name = "lbxLocationList";
            this.lbxLocationList.Size = new System.Drawing.Size(230, 95);
            this.lbxLocationList.TabIndex = 0;
            // 
            // tmrArduino
            // 
            this.tmrArduino.Tick += new System.EventHandler(this.tmrArduino_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Gameform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 157);
            this.Controls.Add(this.gbxLocationList);
            this.Controls.Add(this.gbxConnectArduino);
            this.Controls.Add(this.gbxLocations);
            this.Name = "Gameform";
            this.Text = "Gameform";
            this.Load += new System.EventHandler(this.Gameform_Load);
            this.gbxLocations.ResumeLayout(false);
            this.gbxLocations.PerformLayout();
            this.gbxConnectArduino.ResumeLayout(false);
            this.gbxConnectArduino.PerformLayout();
            this.gbxLocationList.ResumeLayout(false);
            this.gbxLocationList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveLocation;
        private System.Windows.Forms.Button btnRunApplication;
        private System.Windows.Forms.TextBox txbHorizontal;
        private System.Windows.Forms.TextBox txbVertical;
        private System.Windows.Forms.TextBox txbRotation;
        private System.Windows.Forms.Label lblHorizontalText;
        private System.Windows.Forms.Label lblVerticalText;
        private System.Windows.Forms.Label lblRotationText;
        private System.Windows.Forms.GroupBox gbxLocations;
        private System.Windows.Forms.GroupBox gbxConnectArduino;
        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.Label lblConnectedText;
        private System.Windows.Forms.Button btnConnectArduino;
        private System.Windows.Forms.GroupBox gbxLocationList;
        private System.Windows.Forms.ListBox lbxLocationList;
        private System.Windows.Forms.Timer tmrArduino;
        private System.Windows.Forms.Label lblArduinoBuisy;
        private System.Windows.Forms.Label lblArduinoBuisyText;
        private System.Windows.Forms.Label lblLocationtypeText;
        private System.Windows.Forms.Label lblCurrentLocationtype;
        private System.Windows.Forms.Button button1;
    }
}