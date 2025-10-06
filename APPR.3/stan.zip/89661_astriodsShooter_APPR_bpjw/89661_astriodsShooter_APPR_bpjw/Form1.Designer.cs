namespace _89661_astriodsShooter_APPR_bpjw
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
            this.tmrMovement = new System.Windows.Forms.Timer(this.components);
            this.pnlAstriodSpawnSlin = new System.Windows.Forms.Panel();
            this.pnlPlayerRailSlin = new System.Windows.Forms.Panel();
            this.pnlPlayerSlin = new System.Windows.Forms.Panel();
            this.pnlPlayerGunSlin = new System.Windows.Forms.Panel();
            this.rtbLoggingSlin = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tmrMovement
            // 
            this.tmrMovement.Tick += new System.EventHandler(this.tmrMovement_Tick);
            // 
            // pnlAstriodSpawnSlin
            // 
            this.pnlAstriodSpawnSlin.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pnlAstriodSpawnSlin.Location = new System.Drawing.Point(0, 0);
            this.pnlAstriodSpawnSlin.Name = "pnlAstriodSpawnSlin";
            this.pnlAstriodSpawnSlin.Size = new System.Drawing.Size(37, 303);
            this.pnlAstriodSpawnSlin.TabIndex = 0;
            // 
            // pnlPlayerRailSlin
            // 
            this.pnlPlayerRailSlin.BackColor = System.Drawing.Color.CadetBlue;
            this.pnlPlayerRailSlin.Location = new System.Drawing.Point(803, 0);
            this.pnlPlayerRailSlin.Name = "pnlPlayerRailSlin";
            this.pnlPlayerRailSlin.Size = new System.Drawing.Size(10, 303);
            this.pnlPlayerRailSlin.TabIndex = 1;
            // 
            // pnlPlayerSlin
            // 
            this.pnlPlayerSlin.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlPlayerSlin.Location = new System.Drawing.Point(787, 132);
            this.pnlPlayerSlin.Name = "pnlPlayerSlin";
            this.pnlPlayerSlin.Size = new System.Drawing.Size(32, 39);
            this.pnlPlayerSlin.TabIndex = 2;
            // 
            // pnlPlayerGunSlin
            // 
            this.pnlPlayerGunSlin.BackColor = System.Drawing.Color.DimGray;
            this.pnlPlayerGunSlin.Location = new System.Drawing.Point(769, 142);
            this.pnlPlayerGunSlin.Name = "pnlPlayerGunSlin";
            this.pnlPlayerGunSlin.Size = new System.Drawing.Size(41, 20);
            this.pnlPlayerGunSlin.TabIndex = 3;
            // 
            // rtbLoggingSlin
            // 
            this.rtbLoggingSlin.Enabled = false;
            this.rtbLoggingSlin.Location = new System.Drawing.Point(60, 309);
            this.rtbLoggingSlin.Name = "rtbLoggingSlin";
            this.rtbLoggingSlin.Size = new System.Drawing.Size(304, 108);
            this.rtbLoggingSlin.TabIndex = 4;
            this.rtbLoggingSlin.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 458);
            this.Controls.Add(this.rtbLoggingSlin);
            this.Controls.Add(this.pnlPlayerGunSlin);
            this.Controls.Add(this.pnlPlayerSlin);
            this.Controls.Add(this.pnlPlayerRailSlin);
            this.Controls.Add(this.pnlAstriodSpawnSlin);
            this.Name = "Form1";
            this.Text = "astriods";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrMovement;
        private System.Windows.Forms.Panel pnlAstriodSpawnSlin;
        private System.Windows.Forms.Panel pnlPlayerRailSlin;
        private System.Windows.Forms.Panel pnlPlayerSlin;
        private System.Windows.Forms.Panel pnlPlayerGunSlin;
        private System.Windows.Forms.RichTextBox rtbLoggingSlin;
    }
}

