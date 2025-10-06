namespace ws6_APPR_up
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
            this.lblstart = new System.Windows.Forms.Label();
            this.lblantwoord = new System.Windows.Forms.Label();
            this.lblspel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnkies = new System.Windows.Forms.Button();
            this.btnmin = new System.Windows.Forms.Button();
            this.btnplus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblstart
            // 
            this.lblstart.AutoSize = true;
            this.lblstart.Location = new System.Drawing.Point(12, 11);
            this.lblstart.Name = "lblstart";
            this.lblstart.Size = new System.Drawing.Size(71, 16);
            this.lblstart.TabIndex = 0;
            this.lblstart.Text = "start value:";
            // 
            // lblantwoord
            // 
            this.lblantwoord.AutoSize = true;
            this.lblantwoord.Location = new System.Drawing.Point(12, 41);
            this.lblantwoord.Name = "lblantwoord";
            this.lblantwoord.Size = new System.Drawing.Size(65, 16);
            this.lblantwoord.TabIndex = 1;
            this.lblantwoord.Text = "antwoord:";
            // 
            // lblspel
            // 
            this.lblspel.AutoSize = true;
            this.lblspel.Location = new System.Drawing.Point(83, 41);
            this.lblspel.Name = "lblspel";
            this.lblspel.Size = new System.Drawing.Size(16, 16);
            this.lblspel.TabIndex = 2;
            this.lblspel.Text = "...";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 3;
            // 
            // btnkies
            // 
            this.btnkies.Location = new System.Drawing.Point(205, 7);
            this.btnkies.Name = "btnkies";
            this.btnkies.Size = new System.Drawing.Size(156, 23);
            this.btnkies.TabIndex = 4;
            this.btnkies.Text = "kies dit numer";
            this.btnkies.UseVisualStyleBackColor = true;
            this.btnkies.Click += new System.EventHandler(this.btnkies_Click);
            // 
            // btnmin
            // 
            this.btnmin.Location = new System.Drawing.Point(205, 41);
            this.btnmin.Name = "btnmin";
            this.btnmin.Size = new System.Drawing.Size(75, 23);
            this.btnmin.TabIndex = 5;
            this.btnmin.Text = "-";
            this.btnmin.UseVisualStyleBackColor = true;
            this.btnmin.Click += new System.EventHandler(this.btnmin_Click);
            // 
            // btnplus
            // 
            this.btnplus.Location = new System.Drawing.Point(286, 41);
            this.btnplus.Name = "btnplus";
            this.btnplus.Size = new System.Drawing.Size(75, 23);
            this.btnplus.TabIndex = 6;
            this.btnplus.Text = "+";
            this.btnplus.UseVisualStyleBackColor = true;
            this.btnplus.Click += new System.EventHandler(this.btnplus_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 528);
            this.Controls.Add(this.btnplus);
            this.Controls.Add(this.btnmin);
            this.Controls.Add(this.btnkies);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblspel);
            this.Controls.Add(this.lblantwoord);
            this.Controls.Add(this.lblstart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblstart;
        private System.Windows.Forms.Label lblantwoord;
        private System.Windows.Forms.Label lblspel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnkies;
        private System.Windows.Forms.Button btnmin;
        private System.Windows.Forms.Button btnplus;
    }
}

