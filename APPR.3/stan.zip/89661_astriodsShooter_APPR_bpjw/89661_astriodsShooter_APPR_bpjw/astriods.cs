using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _89661_astriodsShooter_APPR_bpjw
{
    internal class astriods
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PictureBox pictureBox { get; set; }
        public Image Image { get; set; }

        public int Rank { get; set; }
        public int Health { get; set; }
        
        public astriods(int id, string name, Image image, int rank, int health)
        {
            Id = id;
            Name = name;
            Image = image;
            Rank = rank;
            Health = health;
        }
    }
}
