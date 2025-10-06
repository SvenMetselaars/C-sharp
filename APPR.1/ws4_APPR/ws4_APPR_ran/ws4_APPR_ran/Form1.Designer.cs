namespace ws4_APPR_ran
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
            this.lblvalue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblanser = new System.Windows.Forms.Label();
            this.btnran = new System.Windows.Forms.Button();
            this.tbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblvalue
            // 
            this.lblvalue.AutoSize = true;
            this.lblvalue.Location = new System.Drawing.Point(12, 9);
            this.lblvalue.Name = "lblvalue";
            this.lblvalue.Size = new System.Drawing.Size(46, 16);
            this.lblvalue.TabIndex = 0;
            this.lblvalue.Text = "value: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "random value:";
            // 
            // lblanser
            // 
            this.lblanser.AutoSize = true;
            this.lblanser.Location = new System.Drawing.Point(110, 42);
            this.lblanser.Name = "lblanser";
            this.lblanser.Size = new System.Drawing.Size(16, 16);
            this.lblanser.TabIndex = 2;
            this.lblanser.Text = "...";
            // 
            // btnran
            // 
            this.btnran.Location = new System.Drawing.Point(15, 74);
            this.btnran.Name = "btnran";
            this.btnran.Size = new System.Drawing.Size(91, 23);
            this.btnran.TabIndex = 3;
            this.btnran.Text = "randomize";
            this.btnran.UseVisualStyleBackColor = true;
            this.btnran.Click += new System.EventHandler(this.btnran_Click);
            // 
            // tbx
            // 
            this.tbx.Location = new System.Drawing.Point(64, 3);
            this.tbx.Name = "tbx";
            this.tbx.Size = new System.Drawing.Size(100, 22);
            this.tbx.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 113);
            this.Controls.Add(this.tbx);
            this.Controls.Add(this.btnran);
            this.Controls.Add(this.lblanser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblvalue);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblvalue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblanser;
        private System.Windows.Forms.Button btnran;
        private System.Windows.Forms.TextBox tbx;
    }
}

