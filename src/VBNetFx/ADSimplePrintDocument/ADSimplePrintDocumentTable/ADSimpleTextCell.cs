using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ActiveDev.Printing
{
	public enum ADTextCellAlignment
	{
		TopLeft,
		TopRight,
		TopCenter,
		MiddleLeft,
		MiddleRight,
		MiddleCenter,
		BottomLeft,
		BottomRight,
		BottomCenter,
		TopJustified,
		MiddleJustified,
		BottomJustified,
		TopFullyJustified,
		MiddleFullyJustified,
		BottomFullyJustified,
		IllegalAlignment
	}

	public class ADSimpleTextCell : ADSimpleFrameCell
	{
		static string[] alignmentControlChars=new string[] 
				{
					"{%^<%}", "{%^>%}", "{%^|%}",
					"{%=<%}", "{%=>%}", "{%=|%}",
					"{%_<%}", "{%_>%}", "{%_|%}",
					"{%^;%}", "{%=;%}", "{%_;%}",
					"{%^:%}", "{%=:%}", "{%_:%}"
				};

		string myText;
		Brush myBrush;
		ADTextCellAlignment myAlignment;
		StringFormat myStringFormat;
		bool myWrap;
		ADCellMargins myCellMargins;

		public ADSimpleTextCell(string text, ADFrameCellBorderStyle borderstyle, ADCellMargins cellMargins,
			Color backgroundColor, Pen pen, Font font, ADTextCellAlignment alignment, bool autoSize, bool wrap)
			
		{
			myCellMargins = cellMargins;
			myAutoSize = AutoSize;
			myBackgroundColor = backgroundColor;
			myForegroundColor = pen.Color;
			myBorderstyle = borderstyle;
			myPen = pen;
			myHasUpper = true;
			myHasLower = true;
			myHasLeft = true;
			myHasRight = true;
			myText = text;
			myFont = font;
			myAlignment = alignment;
			myWrap = wrap;
			myStringFormat = CreateStringFormat(alignment, myWrap, myAutoSize);
			myBrush = new SolidBrush(myPen.Color);
		}

		public override float MeasureTableCell(Graphics g)
		{
			ADFieldString locString=myText;
			float locReturn;

			if (!myDimensionCalculated)
				CalculateDimensions(g);

			locReturn= g.MeasureString(locString, myFont, 
				new SizeF(Bounds.Width-(myCellMargins.LeftMargin+myCellMargins.RightMargin+PenWidth()), 0), 
				myStringFormat).Height;
			return locReturn+myCellMargins.TopMargin+myCellMargins.BottomMargin+PenWidth()/2;
		}

		private float PenWidth()
		{
			if (this.Borderstyle == ADFrameCellBorderStyle.None)
				return 0;
			if (this.Borderstyle == ADFrameCellBorderStyle.FixedSingle)
				return this.Pen.Width * 2;
			else
				return this.Pen.Width * 4;
		}

		public override void Render(Graphics g, float OffsetX, float OffsetY)
		{
			ADFieldString locString = myText;

			base.Render(g, OffsetX, OffsetY);
			g.DrawString(locString,myFont,myBrush,
						 new RectangleF(ClientRectangle.X + OffsetX+myCellMargins.LeftMargin, 
							ClientRectangle.Y+OffsetY+myCellMargins.TopMargin, 
							ClientRectangle.Width-myCellMargins.RightMargin-myCellMargins.LeftMargin, 
							ClientRectangle.Height-myCellMargins.BottomMargin),
						myStringFormat);
		}

		private StringFormat CreateStringFormat(ADTextCellAlignment textAlign, bool wrap, bool autoSize)
		{
			StringFormat locStringFormat = new StringFormat(StringFormat.GenericTypographic);
			StringFormatFlags locFormatFlags;

			switch (textAlign)
			{
				case ADTextCellAlignment.TopCenter:
					locStringFormat.Alignment = StringAlignment.Center;
					locStringFormat.LineAlignment = StringAlignment.Near;
					break;
				case ADTextCellAlignment.TopLeft:
				case ADTextCellAlignment.IllegalAlignment:
					locStringFormat.Alignment = StringAlignment.Near;
					locStringFormat.LineAlignment = StringAlignment.Near;
					break;
				case ADTextCellAlignment.TopRight:
					locStringFormat.Alignment = StringAlignment.Far;
					locStringFormat.LineAlignment = StringAlignment.Near;
					break;

				case ADTextCellAlignment.MiddleCenter:
					locStringFormat.Alignment = StringAlignment.Center;
					locStringFormat.LineAlignment = StringAlignment.Center;
					break;
				case ADTextCellAlignment.MiddleLeft:
					locStringFormat.Alignment = StringAlignment.Near;
					locStringFormat.LineAlignment = StringAlignment.Center;
					break;
				case ADTextCellAlignment.MiddleRight:
					locStringFormat.Alignment = StringAlignment.Far;
					locStringFormat.LineAlignment = StringAlignment.Center;
					break;

				case ADTextCellAlignment.BottomCenter:
					locStringFormat.Alignment = StringAlignment.Center;
					locStringFormat.LineAlignment = StringAlignment.Far;
					break;
				case ADTextCellAlignment.BottomLeft:
					locStringFormat.Alignment = StringAlignment.Near;
					locStringFormat.LineAlignment = StringAlignment.Far;
					break;
				case ADTextCellAlignment.BottomRight:
					locStringFormat.Alignment = StringAlignment.Far;
					locStringFormat.LineAlignment = StringAlignment.Far;
					break;

				default:
					throw (new ArgumentException("Alignment style not implemented!"));
			}
			locFormatFlags = StringFormatFlags.FitBlackBox;

			if (!wrap)
			{
				locFormatFlags = locFormatFlags | StringFormatFlags.NoWrap;
				locStringFormat.Trimming = StringTrimming.EllipsisCharacter;
			}
			else
			{
				if (autoSize)
					locFormatFlags = locFormatFlags | StringFormatFlags.NoClip;
				else
					locStringFormat.Trimming = StringTrimming.EllipsisWord;
			}
			locStringFormat.FormatFlags = locFormatFlags;
			return locStringFormat;
		}

		/// <summary>
		/// Ermittelt ADTextAlignments anhand der übergebenen AlignmentChars-Kombinationen
		/// </summary>
		/// <param name="AlignmentControlChars"></param>
		/// <returns></returns>
		public static ADTextCellAlignment FindAlignmentFromAlignmentSigns(string AlignmentControlChars)
		{
			int count = 0;
			bool found = false;

			foreach (string controlChar in alignmentControlChars)
			{
				if (AlignmentControlChars == controlChar)
				{
					found = true;
					break;
				}
				count++;
			}

			if (found)
				return (ADTextCellAlignment)count;
			else
				return ADTextCellAlignment.IllegalAlignment;
		}
	}
}
