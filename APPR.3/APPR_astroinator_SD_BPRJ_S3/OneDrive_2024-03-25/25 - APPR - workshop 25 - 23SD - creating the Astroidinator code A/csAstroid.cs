using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPR_Astroidinator_23SD_WstPrepSerTabs
{
	internal class csAstroid
	{
		//DISCLAIMER
		///this is a initial version of the class
		//some functions or variables might be redundant due to development insights
		//
		//a panel is used as 'astroid' but a picturebox might be suitable as well
		//the advantage of a picturebox is that a special image can be added
		public Panel pnlAstroid = new Panel();
		public int astroidNr = 0;

		//public int astroidVerPos = 0;
		//public int astroidHorPos = 0;
		//limits of the astroid in the gamesheet panel, determined at startup of the application
		public int astroidRangeVerPosMin = 0;
		public int astroidRangeVerPosMax = 0;
		public int astroidRangeHorPosMin = 0;
		public int astroidRangeHorPosMax = 0;

		static Random GeneratePos = new Random();

		/// <summary>
		/// constructor: pass the minimum and maximum values as arguments and store them in the private variables
		/// </summary>
		public csAstroid(int a_rangeVerPosMin, int a_rangeVerPosMax, int a_rangeHorPosMin, int a_rangeHorPosMax)
		{
			astroidRangeVerPosMin = a_rangeVerPosMin;
			astroidRangeVerPosMax = a_rangeVerPosMax;
			astroidRangeHorPosMin = a_rangeHorPosMin;
			astroidRangeHorPosMax = a_rangeHorPosMax;

			pnlAstroid.Width = 10;
			pnlAstroid.Height = 10;
		}

		public void GenerateAstroidPosition()
		{
			pnlAstroid.Left = GeneratePos.Next(astroidRangeHorPosMin, astroidRangeHorPosMax);
			pnlAstroid.Top = GeneratePos.Next(astroidRangeVerPosMin, astroidRangeVerPosMax);

			pnlAstroid.BackColor = Color.Fuchsia;
		}

		private void TrickRandomizer()
		{
			int m_setupCounter = 0;

			for (int i = 0; i < 12345678; i++)
			{
				m_setupCounter++;
			}
		}
	}
}
