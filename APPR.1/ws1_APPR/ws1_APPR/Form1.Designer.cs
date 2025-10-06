namespace ws1_APPR
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
            this.btnstartscreen = new System.Windows.Forms.Button();
            this.btnstartmove = new System.Windows.Forms.Button();
            this.pbxstartscreen = new System.Windows.Forms.PictureBox();
            this.pbxineedmorebullets = new System.Windows.Forms.PictureBox();
            this.lblthankyou = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxstartscreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxineedmorebullets)).BeginInit();
            this.SuspendLayout();
            // 
            // btnstartscreen
            // 
            this.btnstartscreen.Location = new System.Drawing.Point(98, 274);
            this.btnstartscreen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnstartscreen.Name = "btnstartscreen";
            this.btnstartscreen.Size = new System.Drawing.Size(56, 19);
            this.btnstartscreen.TabIndex = 0;
            this.btnstartscreen.Text = "about";
            this.btnstartscreen.UseVisualStyleBackColor = true;
            this.btnstartscreen.Click += new System.EventHandler(this.btnstartscreen_Click);
            // 
            // btnstartmove
            // 
            this.btnstartmove.Location = new System.Drawing.Point(274, 274);
            this.btnstartmove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnstartmove.Name = "btnstartmove";
            this.btnstartmove.Size = new System.Drawing.Size(56, 39);
            this.btnstartmove.TabIndex = 1;
            this.btnstartmove.Text = "give";
            this.btnstartmove.UseVisualStyleBackColor = true;
            this.btnstartmove.Click += new System.EventHandler(this.btnstartmove_Click);
            // 
            // pbxstartscreen
            // 
            this.pbxstartscreen.Image = global::ws1_APPR.Properties.Resources.ws1_APPR_picture1;
            this.pbxstartscreen.Location = new System.Drawing.Point(9, 10);
            this.pbxstartscreen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbxstartscreen.Name = "pbxstartscreen";
            this.pbxstartscreen.Size = new System.Drawing.Size(236, 259);
            this.pbxstartscreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxstartscreen.TabIndex = 3;
            this.pbxstartscreen.TabStop = false;
            // 
            // pbxineedmorebullets
            // 
            this.pbxineedmorebullets.Image = global::ws1_APPR.Properties.Resources.ws1_APPR_picture2;
            this.pbxineedmorebullets.Location = new System.Drawing.Point(274, 10);
            this.pbxineedmorebullets.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbxineedmorebullets.Name = "pbxineedmorebullets";
            this.pbxineedmorebullets.Size = new System.Drawing.Size(253, 259);
            this.pbxineedmorebullets.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxineedmorebullets.TabIndex = 2;
            this.pbxineedmorebullets.TabStop = false;
            // 
            // lblthankyou
            // 
            this.lblthankyou.AutoSize = true;
            this.lblthankyou.Location = new System.Drawing.Point(106, 130);
            this.lblthankyou.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblthankyou.Name = "lblthankyou";
            this.lblthankyou.Size = new System.Drawing.Size(54, 13);
            this.lblthankyou.TabIndex = 4;
            this.lblthankyou.Text = "thank you";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 377);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblthankyou);
            this.Controls.Add(this.pbxstartscreen);
            this.Controls.Add(this.pbxineedmorebullets);
            this.Controls.Add(this.btnstartmove);
            this.Controls.Add(this.btnstartscreen);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxstartscreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxineedmorebullets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnstartscreen;
        private System.Windows.Forms.Button btnstartmove;
        private System.Windows.Forms.PictureBox pbxineedmorebullets;
        private System.Windows.Forms.PictureBox pbxstartscreen;
        private System.Windows.Forms.Label lblthankyou;
        private System.Windows.Forms.Button button1;
    }
}

