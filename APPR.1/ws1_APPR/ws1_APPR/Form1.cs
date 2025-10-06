using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ws1_APPR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pbxstartscreen.Left = pbxineedmorebullets.Left;
            btnstartscreen.Left = btnstartmove.Left;

            pbxineedmorebullets.Visible = false;
            btnstartmove.Visible = false;
            lblthankyou.Visible = false;

            pbxstartscreen.Left = 12;
            pbxstartscreen.Top = 12;

            btnstartscreen.Left = 131 - 30;
            btnstartscreen.Top = 337 - 52;

            this.Width = 280;
            this.Height = 350;

        }

        private void btnstartscreen_Click(object sender, EventArgs e)
        {
            pbxstartscreen.Visible = false;
            btnstartscreen.Visible = false;

            pbxineedmorebullets.Visible = true;
            btnstartmove.Visible = true;
            lblthankyou.Visible = false;

            pbxineedmorebullets.Left = 12;
            pbxineedmorebullets.Top = 12;

            btnstartmove.Left = 110;
            btnstartmove.Top = 280;

            this.Width = 295;
            this.Height = 365;
        }

        private void btnstartmove_Click(object sender, EventArgs e)
        {
            lblthankyou.Visible = true;

            lblthankyou.Left = 140 - 25;
            lblthankyou.Top = 160 - 20;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // damage to cpu
            int De_C = 75;
            int attack_P = 85;
            float defence_C = (100f / 600f) * De_C;
            float damage_To_C = attack_P / 100f * (100f - defence_C);
            int roundedDamage_To_C = (int)Math.Round(damage_To_C);

            // damage to player
            int De_P = 150;
            int attack_C = 150;
            float defence_P = (100f / 600f) * De_P;
            float damage_To_P = attack_C / 100f * (100f - defence_P);
            int roundedDamage_To_P = (int)Math.Round(damage_To_P);

            MessageBox.Show("damage to cpu " + roundedDamage_To_C.ToString());
            MessageBox.Show("damage to player " + roundedDamage_To_P.ToString());
        }
    }
}
