#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

#endregion

namespace ActiveDev.Printing
{
	public partial class ADSimplePrintDocument
	{

		public IADPrintableObject PageBreak()
		{
			IADPrintableObject locLine=WriteLine(myCurrentFont);
			locLine.PageBreakAfter = -1;
			return locLine;
		}

		public IADPrintableObject PageBreak(int newPageNo)
		{
			IADPrintableObject locLine = WriteLine(myCurrentFont);
			locLine.PageBreakAfter = newPageNo;
			return locLine;
		}

		public IADPrintableObject WriteLine()
		{
			return WriteLine(myCurrentFont);
		}
		
		public IADPrintableObject WriteLine(Font font)
		{
			if (myWriteInProgress)
				return CloseCurrentWriteProcess();
			else
			{
				IADPrintableObject locObject = new ADPrintableSpaceLine(font);
				PrintObjectInternal(locObject);
				return locObject;
			}
		}

		public IADPrintableObject WriteLine(String text)
		{
			return WriteLine(text, myCurrentFont, myCurrentColor);
		}

		public IADPrintableObject WriteLine(String text, Font font)
		{
			return WriteLine(text, font, myCurrentColor);
		}

		public IADPrintableObject WriteLine(String text, Color color)
		{
			return WriteLine(text, myCurrentFont, color);
		}

		public IADPrintableObject WriteLine(String text, Font font, Color color)
		{
				Write(text, font, color);
				return CloseCurrentWriteProcess();
		}

		public IADPrintableObject Write(String text)
		{
			return Write(text, myCurrentFont, myCurrentColor);
		}

		public IADPrintableObject Write(String text, Color color)
		{
			return Write(text, myCurrentFont, myCurrentColor);
		}

		public IADPrintableObject Write(String text, Font font, Color color)
		{
			if (text == "")
				return WriteLine(font);

			if (myTableBuildInProgress)
				EndTable();
						
			if (!myWriteInProgress)
				myWriteInProgress = true;

			if (myCurrentWriteLine == null)
				myCurrentWriteLine = new ADPrintableTextBlock(myCurrentAlignment);
			else
				myCurrentWriteLine.Alignment = myCurrentAlignment;

			string[] locWords = SplitButIncludeSeparator(text, mySeparator);
			SolidBrush locBrush = new SolidBrush(color);
			foreach (string locWord in locWords)
				myCurrentWriteLine.AddPart(new ADPrintableTextPart(locWord, font, locBrush));

			return myCurrentWriteLine;
		}

		public IADPrintableObject CloseCurrentWriteProcess()
		{
			myWriteInProgress=false;
			IADPrintableObject locPrintableObject = myCurrentWriteLine;
			locPrintableObject.Size = new SizeF(-1f, -1f);
			PrintObjectInternal(locPrintableObject);
			myCurrentWriteLine = null;
			return locPrintableObject;
		}

		private static string[] SplitButIncludeSeparator(String text, char[] separators)
		{
			List<string> locWords=new List<string>();
			StringBuilder locCurrentWord=new StringBuilder();
			bool locFoundFlag=false;

			foreach (char locTextChars in text.ToCharArray())
			{
				foreach(char locSepChar in separators)
					if (locSepChar == locTextChars)
					{
						locFoundFlag = true;
						break;
					}

				locCurrentWord.Append(locTextChars);

				if (locFoundFlag)
				{
					locWords.Add(locCurrentWord.ToString());
					locCurrentWord = new StringBuilder();
					locFoundFlag = false;
				}
			}
			if (locCurrentWord.Length > 0)
				locWords.Add(locCurrentWord.ToString());

			return locWords.ToArray();
		}
	}
}
