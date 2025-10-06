namespace opdracht2_APPR_TEST
{
    partial class Form1
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
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpRace = new System.Windows.Forms.TabPage();
            this.pbxRacer2 = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblRaceTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFinish = new System.Windows.Forms.FlowLayoutPanel();
            this.pbxRacer1 = new System.Windows.Forms.PictureBox();
            this.tbpSettings = new System.Windows.Forms.TabPage();
            this.lblPerTick2 = new System.Windows.Forms.Label();
            this.lblPerTick = new System.Windows.Forms.Label();
            this.lblEngine2 = new System.Windows.Forms.Label();
            this.lblEngine = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbMaxSpeed = new System.Windows.Forms.TextBox();
            this.txbMinSpeed = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSetupRacers = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.tmrRacer = new System.Windows.Forms.Timer(this.components);
            this.tbcMain.SuspendLayout();
            this.tbpRace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRacer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRacer1)).BeginInit();
            this.tbpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tbpRace);
            this.tbcMain.Controls.Add(this.tbpSettings);
            this.tbcMain.Location = new System.Drawing.Point(2, 1);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(933, 508);
            this.tbcMain.TabIndex = 0;
            // 
            // tbpRace
            // 
            this.tbpRace.Controls.Add(this.pbxRacer2);
            this.tbpRace.Controls.Add(this.btnStart);
            this.tbpRace.Controls.Add(this.lblRaceTime);
            this.tbpRace.Controls.Add(this.label1);
            this.tbpRace.Controls.Add(this.pnlFinish);
            this.tbpRace.Controls.Add(this.pbxRacer1);
            this.tbpRace.Location = new System.Drawing.Point(4, 25);
            this.tbpRace.Name = "tbpRace";
            this.tbpRace.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRace.Size = new System.Drawing.Size(925, 479);
            this.tbpRace.TabIndex = 0;
            this.tbpRace.Text = "the race";
            this.tbpRace.UseVisualStyleBackColor = true;
            // 
            // pbxRacer2
            // 
            this.pbxRacer2.BackColor = System.Drawing.Color.Red;
            this.pbxRacer2.Location = new System.Drawing.Point(6, 62);
            this.pbxRacer2.Name = "pbxRacer2";
            this.pbxRacer2.Size = new System.Drawing.Size(100, 50);
            this.pbxRacer2.TabIndex = 8;
            this.pbxRacer2.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(19, 329);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblRaceTime
            // 
            this.lblRaceTime.AutoSize = true;
            this.lblRaceTime.Location = new System.Drawing.Point(644, 329);
            this.lblRaceTime.Name = "lblRaceTime";
            this.lblRaceTime.Size = new System.Drawing.Size(19, 16);
            this.lblRaceTime.TabIndex = 6;
            this.lblRaceTime.Text = "---";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(581, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "position:";
            // 
            // pnlFinish
            // 
            this.pnlFinish.BackColor = System.Drawing.Color.Purple;
            this.pnlFinish.Location = new System.Drawing.Point(630, 12);
            this.pnlFinish.Name = "pnlFinish";
            this.pnlFinish.Size = new System.Drawing.Size(5, 303);
            this.pnlFinish.TabIndex = 4;
            // 
            // pbxRacer1
            // 
            this.pbxRacer1.BackColor = System.Drawing.Color.Black;
            this.pbxRacer1.Location = new System.Drawing.Point(6, 6);
            this.pbxRacer1.Name = "pbxRacer1";
            this.pbxRacer1.Size = new System.Drawing.Size(100, 50);
            this.pbxRacer1.TabIndex = 0;
            this.pbxRacer1.TabStop = false;
            // 
            // tbpSettings
            // 
            this.tbpSettings.Controls.Add(this.lblPerTick2);
            this.tbpSettings.Controls.Add(this.lblPerTick);
            this.tbpSettings.Controls.Add(this.lblEngine2);
            this.tbpSettings.Controls.Add(this.lblEngine);
            this.tbpSettings.Controls.Add(this.label9);
            this.tbpSettings.Controls.Add(this.label7);
            this.tbpSettings.Controls.Add(this.label8);
            this.tbpSettings.Controls.Add(this.label4);
            this.tbpSettings.Controls.Add(this.label6);
            this.tbpSettings.Controls.Add(this.label5);
            this.tbpSettings.Controls.Add(this.txbMaxSpeed);
            this.tbpSettings.Controls.Add(this.txbMinSpeed);
            this.tbpSettings.Controls.Add(this.label3);
            this.tbpSettings.Controls.Add(this.label2);
            this.tbpSettings.Controls.Add(this.btnSetupRacers);
            this.tbpSettings.Controls.Add(this.btnDefault);
            this.tbpSettings.Location = new System.Drawing.Point(4, 25);
            this.tbpSettings.Name = "tbpSettings";
            this.tbpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSettings.Size = new System.Drawing.Size(925, 479);
            this.tbpSettings.TabIndex = 1;
            this.tbpSettings.Text = "settings";
            this.tbpSettings.UseVisualStyleBackColor = true;
            // 
            // lblPerTick2
            // 
            this.lblPerTick2.AutoSize = true;
            this.lblPerTick2.Location = new System.Drawing.Point(350, 133);
            this.lblPerTick2.Name = "lblPerTick2";
            this.lblPerTick2.Size = new System.Drawing.Size(19, 16);
            this.lblPerTick2.TabIndex = 7;
            this.lblPerTick2.Text = "---";
            // 
            // lblPerTick
            // 
            this.lblPerTick.AutoSize = true;
            this.lblPerTick.Location = new System.Drawing.Point(350, 117);
            this.lblPerTick.Name = "lblPerTick";
            this.lblPerTick.Size = new System.Drawing.Size(19, 16);
            this.lblPerTick.TabIndex = 7;
            this.lblPerTick.Text = "---";
            // 
            // lblEngine2
            // 
            this.lblEngine2.AutoSize = true;
            this.lblEngine2.Location = new System.Drawing.Point(188, 133);
            this.lblEngine2.Name = "lblEngine2";
            this.lblEngine2.Size = new System.Drawing.Size(19, 16);
            this.lblEngine2.TabIndex = 7;
            this.lblEngine2.Text = "---";
            // 
            // lblEngine
            // 
            this.lblEngine.AutoSize = true;
            this.lblEngine.Location = new System.Drawing.Point(188, 117);
            this.lblEngine.Name = "lblEngine";
            this.lblEngine.Size = new System.Drawing.Size(19, 16);
            this.lblEngine.TabIndex = 7;
            this.lblEngine.Text = "---";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(238, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "stapsize per tick:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(238, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "stapsize per tick:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(133, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "engine:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tunening Racer 2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "engine:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tunening Racer 1";
            // 
            // txbMaxSpeed
            // 
            this.txbMaxSpeed.Location = new System.Drawing.Point(94, 40);
            this.txbMaxSpeed.Name = "txbMaxSpeed";
            this.txbMaxSpeed.Size = new System.Drawing.Size(100, 22);
            this.txbMaxSpeed.TabIndex = 3;
            // 
            // txbMinSpeed
            // 
            this.txbMinSpeed.Location = new System.Drawing.Point(94, 15);
            this.txbMinSpeed.Name = "txbMinSpeed";
            this.txbMinSpeed.Size = new System.Drawing.Size(100, 22);
            this.txbMinSpeed.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "maxspeed:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "minspeed:";
            // 
            // btnSetupRacers
            // 
            this.btnSetupRacers.Location = new System.Drawing.Point(241, 202);
            this.btnSetupRacers.Name = "btnSetupRacers";
            this.btnSetupRacers.Size = new System.Drawing.Size(100, 23);
            this.btnSetupRacers.TabIndex = 0;
            this.btnSetupRacers.Text = "setup racers";
            this.btnSetupRacers.UseVisualStyleBackColor = true;
            this.btnSetupRacers.Click += new System.EventHandler(this.btnSetupRacers_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(94, 68);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(100, 23);
            this.btnDefault.TabIndex = 0;
            this.btnDefault.Text = "default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // tmrRacer
            // 
            this.tmrRacer.Tick += new System.EventHandler(this.tmrRacer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 508);
            this.Controls.Add(this.tbcMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tbcMain.ResumeLayout(false);
            this.tbpRace.ResumeLayout(false);
            this.tbpRace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRacer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRacer1)).EndInit();
            this.tbpSettings.ResumeLayout(false);
            this.tbpSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpRace;
        private System.Windows.Forms.FlowLayoutPanel pnlFinish;
        private System.Windows.Forms.PictureBox pbxRacer1;
        private System.Windows.Forms.TabPage tbpSettings;
        private System.Windows.Forms.Label lblRaceTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbMaxSpeed;
        private System.Windows.Forms.TextBox txbMinSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Label lblPerTick;
        private System.Windows.Forms.Label lblEngine;
        private System.Windows.Forms.Button btnSetupRacers;
        private System.Windows.Forms.Timer tmrRacer;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pbxRacer2;
        private System.Windows.Forms.Label lblPerTick2;
        private System.Windows.Forms.Label lblEngine2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
    }
}

