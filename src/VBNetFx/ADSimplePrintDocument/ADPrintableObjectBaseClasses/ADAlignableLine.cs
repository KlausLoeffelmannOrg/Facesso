#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections.ObjectModel;

#endregion

namespace ActiveDev.Printing
{
	public class ADAlignableLine : ADPrintableObjectBase
	{
		float myRestWidthToLineEnd;
		Collection<IADPrintableObjectPart> myPrintableObjectParts = new Collection<IADPrintableObjectPart>();
		ADTextAlignment myAlignment;
		float myCurrentWidth;

		public ADAlignableLine(ADTextAlignment alignment)
		{
			myAlignment=alignment;
			myCurrentWidth = 0;
		}

		public bool AddPartIfPossible(IADPrintableObjectPart objectPart, Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage)
		{
			float locObjectWidth = objectPart.MeasureSize(g, currentDefaultPage).Width;
			if (myCurrentWidth + (locObjectWidth-objectPart.LastTrailingCharWidth) < currentDefaultPage.CurrentPageWidth)
			{
				myCurrentWidth += objectPart.Size.Width;
				myPrintableObjectParts.Add(objectPart);
				return true;
			}
			else
				return false;
		}

		// Todo: Gelegenheit zum Aufteilen geben, falls es nicht in eine Zeile passt!
		public void AddPart(IADPrintableObjectPart objectPart, Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage)
		{
			myPrintableObjectParts.Add(objectPart);
			myCurrentWidth+=objectPart.MeasureSize(g, currentDefaultPage).Width;
		}

		public override void Render(System.Drawing.Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage)
		{
			foreach(IADPrintableObjectPart locPOP in myPrintableObjectParts)
				locPOP.Render(g, Location.X, Location.Y, currentDefaultPage);
		}

		public override System.Drawing.SizeF MeasureSize(System.Drawing.Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage)
		{
			float locBaselineHeightForCurrentLine = 0;
			float locHighestLineSpace = 0;
			float locCurrentX = 0;
			IADPrintableObjectPart locLastPOP=null;
			int locPOPs = 0;
			float locInsertFaktor;
			int locCount = 0;

			foreach (IADPrintableObjectPart locPOP in myPrintableObjectParts)
			{
				locPOP.MeasureSize(g, currentDefaultPage);
				if (locHighestLineSpace < locPOP.LineSpace) locHighestLineSpace = locPOP.LineSpace;
				if (locBaselineHeightForCurrentLine < locPOP.AscentHeight)
					locBaselineHeightForCurrentLine = locPOP.AscentHeight;
			}

			foreach (IADPrintableObjectPart locPOP in myPrintableObjectParts)
			{
				locPOP.BaselineHeight = locBaselineHeightForCurrentLine;
				locPOP.Location = new PointF(locCurrentX, locPOP.OffsetToBaseline);
				locCurrentX += locPOP.Size.Width;
				locLastPOP = locPOP;
			}

			Size = new SizeF(locCurrentX-locLastPOP.LastTrailingCharWidth, locHighestLineSpace);
			myRestWidthToLineEnd = currentDefaultPage.CurrentPageWidth - Size.Width;
			locPOPs = myPrintableObjectParts.Count-1;
			if (locPOPs < 1)
				locInsertFaktor = myRestWidthToLineEnd;
			else
				locInsertFaktor = myRestWidthToLineEnd / locPOPs;

			switch (myAlignment)
			{
				case ADTextAlignment.Center:
					foreach (IADPrintableObjectPart locPOP in myPrintableObjectParts)
						locPOP.Location = new PointF(locPOP.Location.X+myRestWidthToLineEnd/2, locPOP.OffsetToBaseline);

					break;

				case ADTextAlignment.Right:
					foreach (IADPrintableObjectPart locPOP in myPrintableObjectParts)
						locPOP.Location = new PointF(locPOP.Location.X + myRestWidthToLineEnd, locPOP.OffsetToBaseline);

					break;

				case ADTextAlignment.Justified:
					if (locPOPs>1)
						foreach (IADPrintableObjectPart locPOP in myPrintableObjectParts)
							locPOP.Location = new PointF(locPOP.Location.X + locInsertFaktor*locCount++, locPOP.OffsetToBaseline);

					break;

				default:
					break;
			}

			return Size;
		}

		public int ObjectCount
		{
			get { return myPrintableObjectParts.Count; }
		}

		public ADTextAlignment Alignment
		{
			get { return myAlignment; }
			set { myAlignment=value; }
		}
	}

	public class ADPrintableTextBlock : ADPrintableObjectBase
	{
		Collection<ADAlignableLine> myAlignableLines;
		Collection<IADPrintableObjectPart> myObjectParts = new Collection<IADPrintableObjectPart>();
		ADTextAlignment myAlignment=ADTextAlignment.Left;

		public ADPrintableTextBlock(ADTextAlignment alignment)
		{
			myAlignment = alignment;
		}

		public void AddPart(IADPrintableObjectPart objectPart)
		{
			myObjectParts.Add(objectPart);
		}

		private void AddLine(ADAlignableLine alignableLine)
		{
			myAlignableLines.Add(alignableLine);
		}

		public override void Render(System.Drawing.Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage)
		{
			foreach (ADAlignableLine locAL in myAlignableLines)
				locAL.Render(g, currentDefaultPage);
		}

		public override PointF Location
		{
			get
			{
				return myLocation;
			}

			set
			{
				float locYOffset=0;
				myLocation = value;
				foreach (ADAlignableLine locLine in myAlignableLines)
				{
					locLine.Location = new PointF(Location.X, Location.Y + locYOffset);
					locYOffset += locLine.Size.Height;
				}
			}
		}

		public override System.Drawing.SizeF MeasureSize(System.Drawing.Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage)
		{
			ADAlignableLine locLine=new ADAlignableLine(myAlignment);
			myAlignableLines = new Collection<ADAlignableLine>();
			float myCurrentHeight=0;

			foreach (IADPrintableObjectPart locPOP in myObjectParts)
			{
				if (!locLine.AddPartIfPossible(locPOP, g, currentDefaultPage))
				{
					if (locLine.ObjectCount == 0)
					{
						locLine.AddPart(locPOP, g, currentDefaultPage);
						myAlignableLines.Add(locLine);
						locLine = new ADAlignableLine(myAlignment);
					}

					else
					{
						myAlignableLines.Add(locLine);
						locLine = new ADAlignableLine(myAlignment);
						locLine.AddPart(locPOP, g, currentDefaultPage);
					}
				}
			}

			if (myObjectParts.Count > 0)
				myAlignableLines.Add(locLine);

			for (int locLines = 0; locLines < myAlignableLines.Count; locLines++)
			{
				if (locLines == myAlignableLines.Count - 1 && myAlignment == ADTextAlignment.Justified)
					myAlignableLines[locLines].Alignment = ADTextAlignment.Left;
				else if (myAlignment == ADTextAlignment.Spaced)
					myAlignableLines[locLines].Alignment = ADTextAlignment.Justified;
				else
					myAlignableLines[locLines].Alignment = myAlignment;

				SizeF locSize = myAlignableLines[locLines].MeasureSize(g, currentDefaultPage);
				myCurrentHeight += locSize.Height;
			}

			Size = new SizeF(currentDefaultPage.CurrentPageWidth, myCurrentHeight);
			return Size;
		}

		public ADTextAlignment Alignment
		{
			get { return myAlignment; }
			set { myAlignment = value; }
		}

	}

	public class ADPrintableSpaceLine : ADPrintableObjectBase
	{
		Font myFont;

		public ADPrintableSpaceLine(Font font)
		{
			myFont = font;
		}

		public override void Render(Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage)
		{
			return;
		}

		public override SizeF MeasureSize(Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage)
		{
			return new SizeF(currentDefaultPage.CurrentPageWidth, g.MeasureString("Wg", myFont).Height);
		}
	}
}
