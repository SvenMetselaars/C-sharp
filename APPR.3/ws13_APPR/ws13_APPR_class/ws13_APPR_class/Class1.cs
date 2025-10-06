using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ws13_APPR_class
{
    internal class Class1
    {
        public string sailorName = "";
        private string sailorRank = "";
        private int sailorAgeYears = 0;

        public string SailorRank
        {
            get{ return sailorRank;}

            set { sailorRank = value; }
        }
        public int SailorAgeInYears
        {
            set {sailorAgeYears = value;}
        }
        public string GetSailorAgeInYears()
        {
            return sailorAgeYears.ToString(); 
        }
        public string Aboout()
        {
            return "created by pattje72";
        }
    }
}
