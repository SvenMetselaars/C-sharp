using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPR_FileHandling_22SD_WorksheetPrep
{
	internal class csSubscriptionForm
	{
		public int memberNr = 0;
		public string memberName = "";
		public string memberCity = "";
		public string memberOccupation = "";

		public csSubscriptionForm(int a_memberNr, string a_memberName, string a_memberCity, string a_memberOccupation)
		{
			memberNr = a_memberNr;
			memberName = a_memberName;
			memberCity = a_memberCity;
			memberOccupation = a_memberOccupation;
		}
	}
}
