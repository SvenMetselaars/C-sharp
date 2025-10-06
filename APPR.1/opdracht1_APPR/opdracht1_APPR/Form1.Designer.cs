namespace opdracht1_APPR
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnstartSM = new Button();
            pbxstartSM = new PictureBox();
            btngoSM = new Button();
            btnlocateSM = new Button();
            btncheatSM = new Button();
            btnclearSM = new Button();
            btnaboutSM = new Button();
            errorProvider1 = new ErrorProvider(components);
            cbxattemptsSM = new ComboBox();
            tbxstopSM = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            tbrtemperatureSM = new TrackBar();
            pgrattemptsSM = new ProgressBar();
            lblhotSM = new Label();
            btnguessSM = new Button();
            lblcoldSM = new Label();
            tbxguessSM = new TextBox();
            gbxplaySM = new GroupBox();
            pgrplayedSM = new ProgressBar();
            lblplayedSM = new Label();
            label1 = new Label();
            lbltriedSM = new Label();
            pgrwrongSM = new ProgressBar();
            lblrightplaySM = new Label();
            lblrightSM = new Label();
            lblwrongplaySM = new Label();
            lblwrongSM = new Label();
            lblleftplaySM = new Label();
            lblleftSM = new Label();
            lblattemptsleftSM = new Label();
            lblguessSM = new Label();
            tbxnicknameSM = new TextBox();
            gbxsetupSM = new GroupBox();
            lbldifficultySM = new Label();
            rbthardSM = new RadioButton();
            btnrandomSM = new Button();
            rbtmediumSM = new RadioButton();
            rbteasySM = new RadioButton();
            tbxstartSM = new TextBox();
            lblstartSM = new Label();
            lblattemptsSM = new Label();
            lblstopSM = new Label();
            gbxinformationSM = new GroupBox();
            rtbinformationSM = new RichTextBox();
            lblgameSM = new Label();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            lblgame3SM = new Label();
            lblgame2SM = new Label();
            lblnicknameSM = new Label();
            lblname = new Label();
            pbxwrongSM = new PictureBox();
            pbxrightSM = new PictureBox();
            btnagainSM = new Button();
            btnstopSM = new Button();
            ((System.ComponentModel.ISupportInitialize)pbxstartSM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbrtemperatureSM).BeginInit();
            gbxplaySM.SuspendLayout();
            gbxsetupSM.SuspendLayout();
            gbxinformationSM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxwrongSM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxrightSM).BeginInit();
            SuspendLayout();
            // 
            // btnstartSM
            // 
            btnstartSM.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            btnstartSM.Location = new Point(1028, 238);
            btnstartSM.Name = "btnstartSM";
            btnstartSM.Size = new Size(65, 32);
            btnstartSM.TabIndex = 0;
            btnstartSM.Text = "Lets begin!";
            btnstartSM.TextImageRelation = TextImageRelation.TextAboveImage;
            btnstartSM.UseVisualStyleBackColor = true;
            btnstartSM.Click += btnstart_Click;
            // 
            // pbxstartSM
            // 
            pbxstartSM.Image = (Image)resources.GetObject("pbxstartSM.Image");
            pbxstartSM.Location = new Point(1047, 12);
            pbxstartSM.Name = "pbxstartSM";
            pbxstartSM.Size = new Size(56, 116);
            pbxstartSM.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxstartSM.TabIndex = 1;
            pbxstartSM.TabStop = false;
            // 
            // btngoSM
            // 
            btngoSM.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point);
            btngoSM.Location = new Point(198, 38);
            btngoSM.Name = "btngoSM";
            btngoSM.Size = new Size(50, 45);
            btngoSM.TabIndex = 3;
            btngoSM.Text = "go!";
            btngoSM.UseVisualStyleBackColor = true;
            btngoSM.Click += btngo_Click;
            // 
            // btnlocateSM
            // 
            btnlocateSM.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnlocateSM.Location = new Point(69, 115);
            btnlocateSM.Name = "btnlocateSM";
            btnlocateSM.Size = new Size(57, 29);
            btnlocateSM.TabIndex = 4;
            btnlocateSM.Text = "locate";
            btnlocateSM.UseVisualStyleBackColor = true;
            btnlocateSM.Click += btnlocate_Click;
            // 
            // btncheatSM
            // 
            btncheatSM.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            btncheatSM.Location = new Point(137, 115);
            btncheatSM.Name = "btncheatSM";
            btncheatSM.Size = new Size(57, 29);
            btncheatSM.TabIndex = 5;
            btncheatSM.Text = "cheat";
            btncheatSM.UseVisualStyleBackColor = true;
            btncheatSM.Click += btncheat_Click;
            // 
            // btnclearSM
            // 
            btnclearSM.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnclearSM.Location = new Point(200, 115);
            btnclearSM.Name = "btnclearSM";
            btnclearSM.Size = new Size(57, 29);
            btnclearSM.TabIndex = 6;
            btnclearSM.Text = "clear";
            btnclearSM.UseVisualStyleBackColor = true;
            btnclearSM.Click += btnclear_Click;
            // 
            // btnaboutSM
            // 
            btnaboutSM.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnaboutSM.Location = new Point(6, 115);
            btnaboutSM.Name = "btnaboutSM";
            btnaboutSM.Size = new Size(57, 29);
            btnaboutSM.TabIndex = 7;
            btnaboutSM.Text = "about";
            btnaboutSM.UseVisualStyleBackColor = true;
            btnaboutSM.Click += btnabout_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // cbxattemptsSM
            // 
            cbxattemptsSM.FormattingEnabled = true;
            cbxattemptsSM.Items.AddRange(new object[] { "5", "15", "25", "50", "75" });
            cbxattemptsSM.Location = new Point(108, 83);
            cbxattemptsSM.Name = "cbxattemptsSM";
            cbxattemptsSM.Size = new Size(79, 25);
            cbxattemptsSM.TabIndex = 9;
            // 
            // tbxstopSM
            // 
            tbxstopSM.Location = new Point(108, 52);
            tbxstopSM.Name = "tbxstopSM";
            tbxstopSM.Size = new Size(78, 25);
            tbxstopSM.TabIndex = 18;
            // 
            // tbrtemperatureSM
            // 
            tbrtemperatureSM.Location = new Point(200, 41);
            tbrtemperatureSM.Name = "tbrtemperatureSM";
            tbrtemperatureSM.Orientation = Orientation.Vertical;
            tbrtemperatureSM.Size = new Size(56, 78);
            tbrtemperatureSM.TabIndex = 10;
            // 
            // pgrattemptsSM
            // 
            pgrattemptsSM.Location = new Point(96, 84);
            pgrattemptsSM.Name = "pgrattemptsSM";
            pgrattemptsSM.Size = new Size(95, 16);
            pgrattemptsSM.TabIndex = 12;
            // 
            // lblhotSM
            // 
            lblhotSM.AutoSize = true;
            lblhotSM.Location = new Point(200, 119);
            lblhotSM.Name = "lblhotSM";
            lblhotSM.Size = new Size(33, 17);
            lblhotSM.TabIndex = 16;
            lblhotSM.Text = "HOT";
            // 
            // btnguessSM
            // 
            btnguessSM.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnguessSM.Location = new Point(98, 41);
            btnguessSM.Name = "btnguessSM";
            btnguessSM.Size = new Size(93, 37);
            btnguessSM.TabIndex = 14;
            btnguessSM.Text = "Guess!";
            btnguessSM.UseVisualStyleBackColor = true;
            btnguessSM.Click += btnguess_Click;
            // 
            // lblcoldSM
            // 
            lblcoldSM.AutoSize = true;
            lblcoldSM.Location = new Point(200, 18);
            lblcoldSM.Name = "lblcoldSM";
            lblcoldSM.Size = new Size(41, 17);
            lblcoldSM.TabIndex = 17;
            lblcoldSM.Text = "COLD";
            // 
            // tbxguessSM
            // 
            tbxguessSM.Location = new Point(108, 15);
            tbxguessSM.Name = "tbxguessSM";
            tbxguessSM.Size = new Size(78, 25);
            tbxguessSM.TabIndex = 19;
            // 
            // gbxplaySM
            // 
            gbxplaySM.Controls.Add(pgrplayedSM);
            gbxplaySM.Controls.Add(lblplayedSM);
            gbxplaySM.Controls.Add(label1);
            gbxplaySM.Controls.Add(lbltriedSM);
            gbxplaySM.Controls.Add(pgrwrongSM);
            gbxplaySM.Controls.Add(lblrightplaySM);
            gbxplaySM.Controls.Add(lblrightSM);
            gbxplaySM.Controls.Add(lblwrongplaySM);
            gbxplaySM.Controls.Add(pgrattemptsSM);
            gbxplaySM.Controls.Add(btnguessSM);
            gbxplaySM.Controls.Add(lblwrongSM);
            gbxplaySM.Controls.Add(lblleftplaySM);
            gbxplaySM.Controls.Add(lblleftSM);
            gbxplaySM.Controls.Add(tbrtemperatureSM);
            gbxplaySM.Controls.Add(lblattemptsleftSM);
            gbxplaySM.Controls.Add(tbxguessSM);
            gbxplaySM.Controls.Add(lblcoldSM);
            gbxplaySM.Controls.Add(lblguessSM);
            gbxplaySM.Controls.Add(lblhotSM);
            gbxplaySM.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            gbxplaySM.Location = new Point(21, 141);
            gbxplaySM.Name = "gbxplaySM";
            gbxplaySM.Size = new Size(262, 150);
            gbxplaySM.TabIndex = 20;
            gbxplaySM.TabStop = false;
            gbxplaySM.Text = "play";
            // 
            // pgrplayedSM
            // 
            pgrplayedSM.Location = new Point(25, 59);
            pgrplayedSM.Name = "pgrplayedSM";
            pgrplayedSM.Size = new Size(71, 19);
            pgrplayedSM.TabIndex = 26;
            // 
            // lblplayedSM
            // 
            lblplayedSM.AutoSize = true;
            lblplayedSM.Location = new Point(6, 59);
            lblplayedSM.Name = "lblplayedSM";
            lblplayedSM.Size = new Size(15, 17);
            lblplayedSM.TabIndex = 26;
            lblplayedSM.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 35);
            label1.Name = "label1";
            label1.Size = new Size(90, 17);
            label1.TabIndex = 26;
            label1.Text = "games played";
            // 
            // lbltriedSM
            // 
            lbltriedSM.AutoSize = true;
            lbltriedSM.Location = new Point(6, 103);
            lbltriedSM.Name = "lbltriedSM";
            lbltriedSM.Size = new Size(77, 17);
            lbltriedSM.TabIndex = 26;
            lbltriedSM.Text = "tries wrong:";
            // 
            // pgrwrongSM
            // 
            pgrwrongSM.Location = new Point(96, 103);
            pgrwrongSM.Name = "pgrwrongSM";
            pgrwrongSM.Size = new Size(95, 16);
            pgrwrongSM.TabIndex = 26;
            // 
            // lblrightplaySM
            // 
            lblrightplaySM.AutoSize = true;
            lblrightplaySM.Location = new Point(169, 119);
            lblrightplaySM.Name = "lblrightplaySM";
            lblrightplaySM.Size = new Size(15, 17);
            lblrightplaySM.TabIndex = 24;
            lblrightplaySM.Text = "0";
            // 
            // lblrightSM
            // 
            lblrightSM.AutoSize = true;
            lblrightSM.Location = new Point(132, 119);
            lblrightSM.Name = "lblrightSM";
            lblrightSM.Size = new Size(38, 17);
            lblrightSM.TabIndex = 31;
            lblrightSM.Text = "right:";
            // 
            // lblwrongplaySM
            // 
            lblwrongplaySM.AutoSize = true;
            lblwrongplaySM.Location = new Point(109, 119);
            lblwrongplaySM.Name = "lblwrongplaySM";
            lblwrongplaySM.Size = new Size(17, 17);
            lblwrongplaySM.TabIndex = 24;
            lblwrongplaySM.Text = "...";
            // 
            // lblwrongSM
            // 
            lblwrongSM.AutoSize = true;
            lblwrongSM.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblwrongSM.Location = new Point(64, 119);
            lblwrongSM.Name = "lblwrongSM";
            lblwrongSM.Size = new Size(48, 17);
            lblwrongSM.TabIndex = 30;
            lblwrongSM.Text = "wrong:";
            // 
            // lblleftplaySM
            // 
            lblleftplaySM.AutoSize = true;
            lblleftplaySM.Location = new Point(32, 119);
            lblleftplaySM.Name = "lblleftplaySM";
            lblleftplaySM.Size = new Size(17, 17);
            lblleftplaySM.TabIndex = 23;
            lblleftplaySM.Text = "...";
            // 
            // lblleftSM
            // 
            lblleftSM.AutoSize = true;
            lblleftSM.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblleftSM.Location = new Point(6, 119);
            lblleftSM.Name = "lblleftSM";
            lblleftSM.Size = new Size(29, 17);
            lblleftSM.TabIndex = 29;
            lblleftSM.Text = "left:";
            // 
            // lblattemptsleftSM
            // 
            lblattemptsleftSM.AutoSize = true;
            lblattemptsleftSM.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblattemptsleftSM.Location = new Point(6, 84);
            lblattemptsleftSM.Name = "lblattemptsleftSM";
            lblattemptsleftSM.Size = new Size(58, 17);
            lblattemptsleftSM.TabIndex = 28;
            lblattemptsleftSM.Text = "tries left:";
            // 
            // lblguessSM
            // 
            lblguessSM.AutoSize = true;
            lblguessSM.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblguessSM.Location = new Point(6, 18);
            lblguessSM.Name = "lblguessSM";
            lblguessSM.Size = new Size(66, 17);
            lblguessSM.TabIndex = 26;
            lblguessSM.Text = "my guess:";
            // 
            // tbxnicknameSM
            // 
            tbxnicknameSM.Location = new Point(985, 205);
            tbxnicknameSM.Name = "tbxnicknameSM";
            tbxnicknameSM.Size = new Size(108, 27);
            tbxnicknameSM.TabIndex = 26;
            // 
            // gbxsetupSM
            // 
            gbxsetupSM.Controls.Add(lbldifficultySM);
            gbxsetupSM.Controls.Add(rbthardSM);
            gbxsetupSM.Controls.Add(btnrandomSM);
            gbxsetupSM.Controls.Add(rbtmediumSM);
            gbxsetupSM.Controls.Add(rbteasySM);
            gbxsetupSM.Controls.Add(tbxstartSM);
            gbxsetupSM.Controls.Add(btngoSM);
            gbxsetupSM.Controls.Add(tbxstopSM);
            gbxsetupSM.Controls.Add(cbxattemptsSM);
            gbxsetupSM.Controls.Add(lblstartSM);
            gbxsetupSM.Controls.Add(lblattemptsSM);
            gbxsetupSM.Controls.Add(lblstopSM);
            gbxsetupSM.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            gbxsetupSM.Location = new Point(21, 19);
            gbxsetupSM.Name = "gbxsetupSM";
            gbxsetupSM.Size = new Size(262, 116);
            gbxsetupSM.TabIndex = 21;
            gbxsetupSM.TabStop = false;
            gbxsetupSM.Text = "set up";
            // 
            // lbldifficultySM
            // 
            lbldifficultySM.AutoSize = true;
            lbldifficultySM.Location = new Point(197, 1);
            lbldifficultySM.Name = "lbldifficultySM";
            lbldifficultySM.Size = new Size(56, 17);
            lbldifficultySM.TabIndex = 26;
            lbldifficultySM.Text = "difficulty";
            // 
            // rbthardSM
            // 
            rbthardSM.AutoSize = true;
            rbthardSM.Location = new Point(239, 21);
            rbthardSM.Name = "rbthardSM";
            rbthardSM.Size = new Size(17, 16);
            rbthardSM.TabIndex = 34;
            rbthardSM.UseVisualStyleBackColor = true;
            // 
            // btnrandomSM
            // 
            btnrandomSM.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            btnrandomSM.Location = new Point(198, 83);
            btnrandomSM.Name = "btnrandomSM";
            btnrandomSM.Size = new Size(50, 28);
            btnrandomSM.TabIndex = 23;
            btnrandomSM.Text = "random";
            btnrandomSM.UseVisualStyleBackColor = true;
            btnrandomSM.Click += btnrandom_Click;
            // 
            // rbtmediumSM
            // 
            rbtmediumSM.AutoSize = true;
            rbtmediumSM.Location = new Point(216, 21);
            rbtmediumSM.Name = "rbtmediumSM";
            rbtmediumSM.Size = new Size(17, 16);
            rbtmediumSM.TabIndex = 33;
            rbtmediumSM.UseVisualStyleBackColor = true;
            // 
            // rbteasySM
            // 
            rbteasySM.AutoSize = true;
            rbteasySM.Checked = true;
            rbteasySM.Location = new Point(193, 21);
            rbteasySM.Name = "rbteasySM";
            rbteasySM.Size = new Size(17, 16);
            rbteasySM.TabIndex = 32;
            rbteasySM.TabStop = true;
            rbteasySM.UseVisualStyleBackColor = true;
            // 
            // tbxstartSM
            // 
            tbxstartSM.Location = new Point(108, 21);
            tbxstartSM.Name = "tbxstartSM";
            tbxstartSM.Size = new Size(78, 25);
            tbxstartSM.TabIndex = 19;
            tbxstartSM.Text = "0";
            // 
            // lblstartSM
            // 
            lblstartSM.AutoSize = true;
            lblstartSM.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblstartSM.Location = new Point(6, 24);
            lblstartSM.Name = "lblstartSM";
            lblstartSM.Size = new Size(52, 17);
            lblstartSM.TabIndex = 23;
            lblstartSM.Text = "start at:";
            // 
            // lblattemptsSM
            // 
            lblattemptsSM.AutoSize = true;
            lblattemptsSM.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point);
            lblattemptsSM.Location = new Point(6, 88);
            lblattemptsSM.Name = "lblattemptsSM";
            lblattemptsSM.Size = new Size(62, 17);
            lblattemptsSM.TabIndex = 25;
            lblattemptsSM.Text = "attempts:";
            // 
            // lblstopSM
            // 
            lblstopSM.AutoSize = true;
            lblstopSM.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblstopSM.Location = new Point(6, 55);
            lblstopSM.Name = "lblstopSM";
            lblstopSM.Size = new Size(52, 17);
            lblstopSM.TabIndex = 24;
            lblstopSM.Text = "stop at:";
            // 
            // gbxinformationSM
            // 
            gbxinformationSM.Controls.Add(btnaboutSM);
            gbxinformationSM.Controls.Add(btnclearSM);
            gbxinformationSM.Controls.Add(btnlocateSM);
            gbxinformationSM.Controls.Add(btncheatSM);
            gbxinformationSM.Controls.Add(rtbinformationSM);
            gbxinformationSM.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            gbxinformationSM.Location = new Point(21, 297);
            gbxinformationSM.Name = "gbxinformationSM";
            gbxinformationSM.Size = new Size(262, 148);
            gbxinformationSM.TabIndex = 22;
            gbxinformationSM.TabStop = false;
            gbxinformationSM.Text = "infromation";
            // 
            // rtbinformationSM
            // 
            rtbinformationSM.Location = new Point(6, 19);
            rtbinformationSM.Name = "rtbinformationSM";
            rtbinformationSM.ReadOnly = true;
            rtbinformationSM.Size = new Size(242, 90);
            rtbinformationSM.TabIndex = 24;
            rtbinformationSM.Text = "";
            // 
            // lblgameSM
            // 
            lblgameSM.AutoSize = true;
            lblgameSM.Location = new Point(957, 489);
            lblgameSM.Name = "lblgameSM";
            lblgameSM.Size = new Size(146, 20);
            lblgameSM.TabIndex = 23;
            lblgameSM.Text = "create a number first";
            // 
            // lblgame3SM
            // 
            lblgame3SM.AutoSize = true;
            lblgame3SM.Location = new Point(957, 449);
            lblgame3SM.Name = "lblgame3SM";
            lblgame3SM.Size = new Size(146, 20);
            lblgame3SM.TabIndex = 24;
            lblgame3SM.Text = "create a number first";
            // 
            // lblgame2SM
            // 
            lblgame2SM.AutoSize = true;
            lblgame2SM.Location = new Point(957, 469);
            lblgame2SM.Name = "lblgame2SM";
            lblgame2SM.Size = new Size(146, 20);
            lblgame2SM.TabIndex = 25;
            lblgame2SM.Text = "create a number first";
            // 
            // lblnicknameSM
            // 
            lblnicknameSM.AutoSize = true;
            lblnicknameSM.Location = new Point(1021, 182);
            lblnicknameSM.Name = "lblnicknameSM";
            lblnicknameSM.Size = new Size(72, 20);
            lblnicknameSM.TabIndex = 27;
            lblnicknameSM.Text = "nickname";
            // 
            // lblname
            // 
            lblname.AutoSize = true;
            lblname.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lblname.Location = new Point(801, 387);
            lblname.Name = "lblname";
            lblname.Size = new Size(302, 54);
            lblname.TabIndex = 28;
            lblname.Text = "sven metselaars";
            // 
            // pbxwrongSM
            // 
            pbxwrongSM.Image = (Image)resources.GetObject("pbxwrongSM.Image");
            pbxwrongSM.Location = new Point(577, 12);
            pbxwrongSM.Name = "pbxwrongSM";
            pbxwrongSM.Size = new Size(282, 446);
            pbxwrongSM.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxwrongSM.TabIndex = 30;
            pbxwrongSM.TabStop = false;
            // 
            // pbxrightSM
            // 
            pbxrightSM.Image = (Image)resources.GetObject("pbxrightSM.Image");
            pbxrightSM.Location = new Point(289, 12);
            pbxrightSM.Name = "pbxrightSM";
            pbxrightSM.Size = new Size(282, 446);
            pbxrightSM.SizeMode = PictureBoxSizeMode.Zoom;
            pbxrightSM.TabIndex = 31;
            pbxrightSM.TabStop = false;
            // 
            // btnagainSM
            // 
            btnagainSM.Location = new Point(307, 27);
            btnagainSM.Name = "btnagainSM";
            btnagainSM.Size = new Size(102, 29);
            btnagainSM.TabIndex = 32;
            btnagainSM.Text = "play again";
            btnagainSM.UseVisualStyleBackColor = true;
            btnagainSM.Click += btnagainSM_Click;
            // 
            // btnstopSM
            // 
            btnstopSM.Location = new Point(456, 27);
            btnstopSM.Name = "btnstopSM";
            btnstopSM.Size = new Size(102, 29);
            btnstopSM.TabIndex = 33;
            btnstopSM.Text = "stop playing";
            btnstopSM.UseVisualStyleBackColor = true;
            btnstopSM.Click += btnstopSM_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1115, 518);
            Controls.Add(btnstopSM);
            Controls.Add(btnagainSM);
            Controls.Add(pbxwrongSM);
            Controls.Add(pbxrightSM);
            Controls.Add(lblname);
            Controls.Add(lblnicknameSM);
            Controls.Add(btnstartSM);
            Controls.Add(tbxnicknameSM);
            Controls.Add(lblgame2SM);
            Controls.Add(lblgame3SM);
            Controls.Add(pbxstartSM);
            Controls.Add(lblgameSM);
            Controls.Add(gbxplaySM);
            Controls.Add(gbxinformationSM);
            Controls.Add(gbxsetupSM);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pbxstartSM).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbrtemperatureSM).EndInit();
            gbxplaySM.ResumeLayout(false);
            gbxplaySM.PerformLayout();
            gbxsetupSM.ResumeLayout(false);
            gbxsetupSM.PerformLayout();
            gbxinformationSM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxwrongSM).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxrightSM).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnstartSM;
        private PictureBox pbxstartSM;
        private Button btngoSM;
        private Button btnlocateSM;
        private Button btncheatSM;
        private Button btnclearSM;
        private Button btnaboutSM;
        private ErrorProvider errorProvider1;
        private ComboBox cbxattemptsSM;
        private TextBox tbxstopSM;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox gbxplaySM;
        private TextBox tbxguessSM;
        private Label lblcoldSM;
        private Button btnguessSM;
        private Label lblhotSM;
        private ProgressBar pgrattemptsSM;
        private TrackBar tbrtemperatureSM;
        private GroupBox gbxinformationSM;
        private GroupBox gbxsetupSM;
        private TextBox tbxstartSM;
        private Label lblwrongSM;
        private Label lblleftSM;
        private Label lblattemptsleftSM;
        private Label lblguessSM;
        private Label lblattemptsSM;
        private Label lblstopSM;
        private Label lblstartSM;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private Button btnrandomSM;
        private Label lblgameSM;
        private Label lblwrongplaySM;
        private Label lblleftplaySM;
        private RichTextBox rtbinformationSM;
        private Label lblrightSM;
        private RadioButton rbthardSM;
        private RadioButton rbtmediumSM;
        private RadioButton rbteasySM;
        private Label lblrightplaySM;
        private Label lblgame2SM;
        private Label lblgame3SM;
        private Label lbldifficultySM;
        private ProgressBar pgrwrongSM;
        private Label lbltriedSM;
        private Label lblplayedSM;
        private Label label1;
        private ProgressBar pgrplayedSM;
        private TextBox tbxnicknameSM;
        private Label lblnicknameSM;
        private Label lblname;
        private PictureBox pbxrightSM;
        private PictureBox pbxwrongSM;
        private Button btnstopSM;
        private Button btnagainSM;
    }
}