namespace ws7_APPR_MCI
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnMoof = new System.Windows.Forms.Button();
            this.btnTemple = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.cbxSound = new System.Windows.Forms.CheckBox();
            this.cbxWrapText = new System.Windows.Forms.CheckBox();
            this.rtbLogging = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "audio";
            // 
            // btnMoof
            // 
            this.btnMoof.Location = new System.Drawing.Point(13, 33);
            this.btnMoof.Name = "btnMoof";
            this.btnMoof.Size = new System.Drawing.Size(75, 23);
            this.btnMoof.TabIndex = 1;
            this.btnMoof.Text = "moof";
            this.btnMoof.UseVisualStyleBackColor = true;
            this.btnMoof.Click += new System.EventHandler(this.btnMoof_Click);
            // 
            // btnTemple
            // 
            this.btnTemple.Location = new System.Drawing.Point(95, 33);
            this.btnTemple.Name = "btnTemple";
            this.btnTemple.Size = new System.Drawing.Size(75, 23);
            this.btnTemple.TabIndex = 2;
            this.btnTemple.Text = "temple";
            this.btnTemple.UseVisualStyleBackColor = true;
            this.btnTemple.Click += new System.EventHandler(this.btnTemple_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "logging";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(13, 223);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cbxSound
            // 
            this.cbxSound.AutoSize = true;
            this.cbxSound.Location = new System.Drawing.Point(177, 35);
            this.cbxSound.Name = "cbxSound";
            this.cbxSound.Size = new System.Drawing.Size(58, 20);
            this.cbxSound.TabIndex = 6;
            this.cbxSound.Text = "mute";
            this.cbxSound.UseVisualStyleBackColor = true;
            // 
            // cbxWrapText
            // 
            this.cbxWrapText.AutoSize = true;
            this.cbxWrapText.Location = new System.Drawing.Point(95, 225);
            this.cbxWrapText.Name = "cbxWrapText";
            this.cbxWrapText.Size = new System.Drawing.Size(81, 20);
            this.cbxWrapText.TabIndex = 7;
            this.cbxWrapText.Text = "warp text";
            this.cbxWrapText.UseVisualStyleBackColor = true;
            // 
            // rtbLogging
            // 
            this.rtbLogging.Location = new System.Drawing.Point(12, 82);
            this.rtbLogging.Name = "rtbLogging";
            this.rtbLogging.Size = new System.Drawing.Size(223, 137);
            this.rtbLogging.TabIndex = 8;
            this.rtbLogging.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 521);
            this.Controls.Add(this.rtbLogging);
            this.Controls.Add(this.cbxWrapText);
            this.Controls.Add(this.cbxSound);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTemple);
            this.Controls.Add(this.btnMoof);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMoof;
        private System.Windows.Forms.Button btnTemple;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox cbxSound;
        private System.Windows.Forms.CheckBox cbxWrapText;
        private System.Windows.Forms.RichTextBox rtbLogging;
    }
}

