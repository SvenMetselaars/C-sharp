namespace ws7_APPR_RIC
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
            this.btnError = new System.Windows.Forms.Button();
            this.btnWarning = new System.Windows.Forms.Button();
            this.btnAllok = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.rtbLogging = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnError
            // 
            this.btnError.Location = new System.Drawing.Point(14, 12);
            this.btnError.Name = "btnError";
            this.btnError.Size = new System.Drawing.Size(75, 23);
            this.btnError.TabIndex = 0;
            this.btnError.Text = "error";
            this.btnError.UseVisualStyleBackColor = true;
            this.btnError.Click += new System.EventHandler(this.btnError_Click);
            // 
            // btnWarning
            // 
            this.btnWarning.Location = new System.Drawing.Point(95, 13);
            this.btnWarning.Name = "btnWarning";
            this.btnWarning.Size = new System.Drawing.Size(75, 23);
            this.btnWarning.TabIndex = 1;
            this.btnWarning.Text = "warning";
            this.btnWarning.UseVisualStyleBackColor = true;
            this.btnWarning.Click += new System.EventHandler(this.btnWarning_Click);
            // 
            // btnAllok
            // 
            this.btnAllok.Location = new System.Drawing.Point(176, 13);
            this.btnAllok.Name = "btnAllok";
            this.btnAllok.Size = new System.Drawing.Size(75, 23);
            this.btnAllok.TabIndex = 2;
            this.btnAllok.Text = "all ok";
            this.btnAllok.UseVisualStyleBackColor = true;
            this.btnAllok.Click += new System.EventHandler(this.btnAllok_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(258, 12);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(75, 23);
            this.btnInfo.TabIndex = 3;
            this.btnInfo.Text = "info";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // rtbLogging
            // 
            this.rtbLogging.Location = new System.Drawing.Point(14, 42);
            this.rtbLogging.Name = "rtbLogging";
            this.rtbLogging.Size = new System.Drawing.Size(319, 129);
            this.rtbLogging.TabIndex = 4;
            this.rtbLogging.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(14, 178);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 20);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "scroll to carot";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(258, 176);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 528);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.rtbLogging);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnAllok);
            this.Controls.Add(this.btnWarning);
            this.Controls.Add(this.btnError);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnError;
        private System.Windows.Forms.Button btnWarning;
        private System.Windows.Forms.Button btnAllok;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.RichTextBox rtbLogging;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnClear;
    }
}

