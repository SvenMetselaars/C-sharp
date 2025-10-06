namespace ws4_APPR_cal
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
            this.btnplus = new System.Windows.Forms.Button();
            this.btnmin = new System.Windows.Forms.Button();
            this.btnkeer = new System.Windows.Forms.Button();
            this.btndiv = new System.Windows.Forms.Button();
            this.tbx1 = new System.Windows.Forms.TextBox();
            this.tbx2 = new System.Windows.Forms.TextBox();
            this.lblresult = new System.Windows.Forms.Label();
            this.lblanser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnplus
            // 
            this.btnplus.Location = new System.Drawing.Point(12, 70);
            this.btnplus.Name = "btnplus";
            this.btnplus.Size = new System.Drawing.Size(75, 23);
            this.btnplus.TabIndex = 0;
            this.btnplus.Text = "plus";
            this.btnplus.UseVisualStyleBackColor = true;
            this.btnplus.Click += new System.EventHandler(this.btnplus_Click);
            // 
            // btnmin
            // 
            this.btnmin.Location = new System.Drawing.Point(93, 70);
            this.btnmin.Name = "btnmin";
            this.btnmin.Size = new System.Drawing.Size(75, 23);
            this.btnmin.TabIndex = 1;
            this.btnmin.Text = "min";
            this.btnmin.UseVisualStyleBackColor = true;
            this.btnmin.Click += new System.EventHandler(this.btnmin_Click);
            // 
            // btnkeer
            // 
            this.btnkeer.Location = new System.Drawing.Point(13, 99);
            this.btnkeer.Name = "btnkeer";
            this.btnkeer.Size = new System.Drawing.Size(75, 23);
            this.btnkeer.TabIndex = 2;
            this.btnkeer.Text = "keer";
            this.btnkeer.UseVisualStyleBackColor = true;
            this.btnkeer.Click += new System.EventHandler(this.btnkeer_Click);
            // 
            // btndiv
            // 
            this.btndiv.Location = new System.Drawing.Point(94, 99);
            this.btndiv.Name = "btndiv";
            this.btndiv.Size = new System.Drawing.Size(75, 23);
            this.btndiv.TabIndex = 3;
            this.btndiv.Text = "div";
            this.btndiv.UseVisualStyleBackColor = true;
            this.btndiv.Click += new System.EventHandler(this.btndiv_Click);
            // 
            // tbx1
            // 
            this.tbx1.Location = new System.Drawing.Point(84, 13);
            this.tbx1.Name = "tbx1";
            this.tbx1.Size = new System.Drawing.Size(84, 22);
            this.tbx1.TabIndex = 4;
            // 
            // tbx2
            // 
            this.tbx2.Location = new System.Drawing.Point(84, 42);
            this.tbx2.Name = "tbx2";
            this.tbx2.Size = new System.Drawing.Size(84, 22);
            this.tbx2.TabIndex = 5;
            // 
            // lblresult
            // 
            this.lblresult.AutoSize = true;
            this.lblresult.Location = new System.Drawing.Point(13, 129);
            this.lblresult.Name = "lblresult";
            this.lblresult.Size = new System.Drawing.Size(42, 16);
            this.lblresult.TabIndex = 7;
            this.lblresult.Text = "result:";
            // 
            // lblanser
            // 
            this.lblanser.AutoSize = true;
            this.lblanser.Location = new System.Drawing.Point(61, 129);
            this.lblanser.Name = "lblanser";
            this.lblanser.Size = new System.Drawing.Size(16, 16);
            this.lblanser.TabIndex = 8;
            this.lblanser.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "number 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "number 2:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(171, 159);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblanser);
            this.Controls.Add(this.lblresult);
            this.Controls.Add(this.tbx2);
            this.Controls.Add(this.tbx1);
            this.Controls.Add(this.btndiv);
            this.Controls.Add(this.btnkeer);
            this.Controls.Add(this.btnmin);
            this.Controls.Add(this.btnplus);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnplus;
        private System.Windows.Forms.Button btnmin;
        private System.Windows.Forms.Button btnkeer;
        private System.Windows.Forms.Button btndiv;
        private System.Windows.Forms.TextBox tbx1;
        private System.Windows.Forms.TextBox tbx2;
        private System.Windows.Forms.Label lblresult;
        private System.Windows.Forms.Label lblanser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

