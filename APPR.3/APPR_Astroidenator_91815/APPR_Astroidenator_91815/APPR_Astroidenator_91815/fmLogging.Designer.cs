namespace APPR_Astroidenator_91815
{
    partial class fmLogging
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
            this.cbxLineNumbering = new System.Windows.Forms.CheckBox();
            this.cbxAutoScroll = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.rtbSerialMonitor = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cbxLineNumbering
            // 
            this.cbxLineNumbering.AutoSize = true;
            this.cbxLineNumbering.Checked = true;
            this.cbxLineNumbering.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxLineNumbering.Location = new System.Drawing.Point(84, 230);
            this.cbxLineNumbering.Margin = new System.Windows.Forms.Padding(2);
            this.cbxLineNumbering.Name = "cbxLineNumbering";
            this.cbxLineNumbering.Size = new System.Drawing.Size(94, 17);
            this.cbxLineNumbering.TabIndex = 9;
            this.cbxLineNumbering.Text = "line numbering";
            this.cbxLineNumbering.UseVisualStyleBackColor = true;
            // 
            // cbxAutoScroll
            // 
            this.cbxAutoScroll.AutoSize = true;
            this.cbxAutoScroll.Checked = true;
            this.cbxAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAutoScroll.Location = new System.Drawing.Point(12, 230);
            this.cbxAutoScroll.Margin = new System.Windows.Forms.Padding(2);
            this.cbxAutoScroll.Name = "cbxAutoScroll";
            this.cbxAutoScroll.Size = new System.Drawing.Size(74, 17);
            this.cbxAutoScroll.TabIndex = 8;
            this.cbxAutoScroll.Text = "auto scroll";
            this.cbxAutoScroll.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(458, 226);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // rtbSerialMonitor
            // 
            this.rtbSerialMonitor.BackColor = System.Drawing.Color.Black;
            this.rtbSerialMonitor.ForeColor = System.Drawing.Color.White;
            this.rtbSerialMonitor.Location = new System.Drawing.Point(12, 12);
            this.rtbSerialMonitor.Name = "rtbSerialMonitor";
            this.rtbSerialMonitor.Size = new System.Drawing.Size(521, 208);
            this.rtbSerialMonitor.TabIndex = 6;
            this.rtbSerialMonitor.Text = "";
            // 
            // fmLogging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbxLineNumbering);
            this.Controls.Add(this.cbxAutoScroll);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.rtbSerialMonitor);
            this.Name = "fmLogging";
            this.Text = "fmLogging";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxLineNumbering;
        private System.Windows.Forms.CheckBox cbxAutoScroll;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RichTextBox rtbSerialMonitor;
    }
}