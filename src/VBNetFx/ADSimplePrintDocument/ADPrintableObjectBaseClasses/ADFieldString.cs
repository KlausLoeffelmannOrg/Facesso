#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace ActiveDev.Printing
{
	public struct ADFieldString
	{
		string myText;
		internal static string myPage="";
		internal static DateTime myPrintingStartDate;
		private static string myPrintingDate;
		private	static string myPrintingTime;
		private	static string myPrintingLongDate;
		private static string myPrintingLongTime;

		static ADFieldString()
		{
			PrintingStartDate = DateTime.Now;
		}

		public ADFieldString(string text)
		{
			myText = text;
		}

		public override string ToString()
		{
			if (myText == null)
				return "";

			if (myText.IndexOf("{%") >= 0)
			{
				string locReturn;
				locReturn = myText.Replace("{%page%}", myPage);
				locReturn = locReturn.Replace("{%printingdate%}", myPrintingDate);
				locReturn = locReturn.Replace("{%printingtime%}", myPrintingTime);
				locReturn = locReturn.Replace("{%printinglongdate%}", myPrintingLongDate);
				locReturn = locReturn.Replace("{%printinglongtime%}", myPrintingLongTime);
				return locReturn;
			}
			else
				return myText;
		}

		public static implicit operator ADFieldString(string sText)
		{
			return new ADFieldString(sText);
		}

		public static implicit operator string(ADFieldString sText)
		{
			return sText.ToString();
		}

		internal static DateTime PrintingStartDate
		{
			get { return myPrintingStartDate; }
			set 
			{ 
				myPrintingStartDate = value;
				myPrintingDate = myPrintingStartDate.ToString("d");
				myPrintingTime = myPrintingStartDate.ToString("t");
				myPrintingLongDate = myPrintingStartDate.ToString("D");
				myPrintingLongTime = myPrintingStartDate.ToString("T");
			}
		}

		public string ToStringWithoutLastChar
		{
			get { return this.ToString().Substring(0, this.ToString().Length - 1); }
		}
	}
}
