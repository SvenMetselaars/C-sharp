namespace ws5_APPR_try
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
            this.lblyears = new System.Windows.Forms.Label();
            this.lbldays = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btndays = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblyears
            // 
            this.lblyears.AutoSize = true;
            this.lblyears.Location = new System.Drawing.Point(12, 9);
            this.lblyears.Name = "lblyears";
            this.lblyears.Size = new System.Drawing.Size(77, 16);
            this.lblyears.TabIndex = 0;
            this.lblyears.Text = "age in year:";
            // 
            // lbldays
            // 
            this.lbldays.AutoSize = true;
            this.lbldays.Location = new System.Drawing.Point(319, 9);
            this.lbldays.Name = "lbldays";
            this.lbldays.Size = new System.Drawing.Size(16, 16);
            this.lbldays.TabIndex = 1;
            this.lbldays.Text = "...";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 2;
            // 
            // btndays
            // 
            this.btndays.Location = new System.Drawing.Point(201, 6);
            this.btndays.Name = "btndays";
            this.btndays.Size = new System.Drawing.Size(112, 23);
            this.btndays.TabIndex = 3;
            this.btndays.Text = "convert to days:";
            this.btndays.UseVisualStyleBackColor = true;
            this.btndays.Click += new System.EventHandler(this.btndays_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btndays);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbldays);
            this.Controls.Add(this.lblyears);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblyears;
        private System.Windows.Forms.Label lbldays;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btndays;
    }
}

