namespace ws5_APPR_com
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblcollor = new System.Windows.Forms.Label();
            this.lblzero = new System.Windows.Forms.Label();
            this.lblindex = new System.Windows.Forms.Label();
            this.lblselect = new System.Windows.Forms.Label();
            this.lbltext = new System.Windows.Forms.Label();
            this.lblcollor2 = new System.Windows.Forms.Label();
            this.lblcollorplay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "light gray",
            "red",
            "green",
            "blue",
            "cyan",
            "yellow",
            "magenta"});
            this.comboBox1.Location = new System.Drawing.Point(100, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblcollor
            // 
            this.lblcollor.AutoSize = true;
            this.lblcollor.Location = new System.Drawing.Point(12, 9);
            this.lblcollor.Name = "lblcollor";
            this.lblcollor.Size = new System.Drawing.Size(82, 16);
            this.lblcollor.TabIndex = 1;
            this.lblcollor.Text = "select collor:";
            // 
            // lblzero
            // 
            this.lblzero.AutoSize = true;
            this.lblzero.Location = new System.Drawing.Point(115, 33);
            this.lblzero.Name = "lblzero";
            this.lblzero.Size = new System.Drawing.Size(14, 16);
            this.lblzero.TabIndex = 2;
            this.lblzero.Text = "0";
            // 
            // lblindex
            // 
            this.lblindex.AutoSize = true;
            this.lblindex.Location = new System.Drawing.Point(12, 33);
            this.lblindex.Name = "lblindex";
            this.lblindex.Size = new System.Drawing.Size(97, 16);
            this.lblindex.TabIndex = 3;
            this.lblindex.Text = "selected index:";
            // 
            // lblselect
            // 
            this.lblselect.AutoSize = true;
            this.lblselect.Location = new System.Drawing.Point(115, 60);
            this.lblselect.Name = "lblselect";
            this.lblselect.Size = new System.Drawing.Size(52, 16);
            this.lblselect.TabIndex = 4;
            this.lblselect.Text = "select...";
            // 
            // lbltext
            // 
            this.lbltext.AutoSize = true;
            this.lbltext.Location = new System.Drawing.Point(12, 60);
            this.lbltext.Name = "lbltext";
            this.lbltext.Size = new System.Drawing.Size(30, 16);
            this.lbltext.TabIndex = 5;
            this.lbltext.Text = "text:";
            // 
            // lblcollor2
            // 
            this.lblcollor2.AutoSize = true;
            this.lblcollor2.Location = new System.Drawing.Point(12, 88);
            this.lblcollor2.Name = "lblcollor2";
            this.lblcollor2.Size = new System.Drawing.Size(43, 16);
            this.lblcollor2.TabIndex = 6;
            this.lblcollor2.Text = "collor:";
            // 
            // lblcollorplay
            // 
            this.lblcollorplay.AutoSize = true;
            this.lblcollorplay.Location = new System.Drawing.Point(115, 88);
            this.lblcollorplay.Name = "lblcollorplay";
            this.lblcollorplay.Size = new System.Drawing.Size(105, 16);
            this.lblcollorplay.TabIndex = 8;
            this.lblcollorplay.Text = "collor [light grey]";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblcollorplay);
            this.Controls.Add(this.lblcollor2);
            this.Controls.Add(this.lbltext);
            this.Controls.Add(this.lblselect);
            this.Controls.Add(this.lblindex);
            this.Controls.Add(this.lblzero);
            this.Controls.Add(this.lblcollor);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblcollor;
        private System.Windows.Forms.Label lblzero;
        private System.Windows.Forms.Label lblindex;
        private System.Windows.Forms.Label lblselect;
        private System.Windows.Forms.Label lbltext;
        private System.Windows.Forms.Label lblcollor2;
        private System.Windows.Forms.Label lblcollorplay;
    }
}

