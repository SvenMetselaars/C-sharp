using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPR_Astroidenator_91815
{
    internal class csAstroid
    {
        //DISCLAIMER
        ///this is a initial version of the class
        //some functions or variables might be redundant due to development insights
        //
        //a panel is used as 'astroid' but a picturebox might be suitable as well
        //the advantage of a picturebox is that a special image can be added
        public PictureBox pbxAstroid = new PictureBox();
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

            pbxAstroid.BackColor = Color.Lime;

            pbxAstroid.Width = 30;
            pbxAstroid.Height = 40;
        }

        public void GenerateAstroidPosition()
        {
            pbxAstroid.Left = GeneratePos.Next(astroidRangeHorPosMin, astroidRangeHorPosMax);
            pbxAstroid.Top = GeneratePos.Next(astroidRangeVerPosMin, astroidRangeVerPosMax);
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
