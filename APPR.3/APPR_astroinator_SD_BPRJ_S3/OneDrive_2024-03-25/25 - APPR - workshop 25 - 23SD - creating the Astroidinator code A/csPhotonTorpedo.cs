using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace APPR_Astroidinator_23SD_WstPrepSerTabs
{
	internal class csPhotonTorpedo
	{
		//DISCLAIMER
		///this is a initial version of the class
		//some functions or variables might be redundant due to development insights
		//
		//a panel is used as 'bullit' but a picturebox might be suitable as well
		//the advantage of a picturebox is that a special image can be added
		public Panel pnlPhotoTorpedo = new Panel();
		public int photonTorpedoNr = 0;
		public int photonTorpedoVerPos = 0;
		public int photonTorpedoHorPos = 0;
		private int heightFlak = 0;
		//private int topFlak = 0;

		public bool photonTorpedoHitAnAstroid = false;

		/// <summary>
		/// constructor: pass the position of the flak as arguments and store them in the private variables
		/// </summary>
		public csPhotonTorpedo(int a_topFlak, int a_heightFlak, int a_leftPos)
		{
			double m_photonTorpedoVerPos = 0;

			heightFlak = a_heightFlak;
			photonTorpedoHorPos = a_leftPos;		
			
			m_photonTorpedoVerPos = heightFlak / 2;
			photonTorpedoVerPos = Convert.ToInt32(m_photonTorpedoVerPos) + a_topFlak;
		}

		public void GeneratePhotonTorpedo()
		{
			pnlPhotoTorpedo.Top = photonTorpedoVerPos;
			pnlPhotoTorpedo.Left = photonTorpedoHorPos;

			pnlPhotoTorpedo.Height = 4;
			pnlPhotoTorpedo.Width = 8;
			pnlPhotoTorpedo.BackColor = System.Drawing.Color.FromName("white");
			pnlPhotoTorpedo.Visible = true;

			//Labelsettings();
		}

		public void ExplodingPhotoTorpedo()
		{
			pnlPhotoTorpedo.Visible = false;
		}

		private void Labelsettings()
		{
			pnlPhotoTorpedo.Text = "<";
			pnlPhotoTorpedo.BackColor = System.Drawing.Color.FromName("White");
			//pnlPhotoTorpedo.ForeColor = System.Drawing.Color.FromName("white");
			pnlPhotoTorpedo.Font = new Font("Arial", 24, FontStyle.Bold);
		}
	}
}
