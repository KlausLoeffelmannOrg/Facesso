#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

#endregion

namespace ActiveDev.Printing
{
	public class ADFooterHeaderLine : ADPrintableObjectBase
	{
		ADFieldString myLeftText;
		ADFieldString myRightText;
		ADFieldString myCenterText;
		float myTextHeight;
		Font myFont;
		Brush myBrush;
		float myLineWidth;
		bool myIsHeader;

		public ADFooterHeaderLine(ADFieldString leftText, ADFieldString rightText, ADFieldString centerText, Font font, Brush brush, float lineWidth)
		{
			myLeftText = leftText;
			myRightText = rightText;
			myCenterText = centerText;
			myFont = font;
			myBrush = brush;
			myLineWidth = lineWidth;
		}

		public ADFieldString LeftText
		{
			get { return myLeftText; }
			set { myLeftText = value; }
		}

		public ADFieldString RightText
		{
			get { return myRightText; }
			set { myRightText = value; }
		}

		public ADFieldString CenterText
		{
			get { return myCenterText; }
			set { myCenterText = value; }
		}

		public override void Render(Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage)
		{
			StringFormat locSF = StringFormat.GenericTypographic;
			locSF.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
			locSF.Alignment = StringAlignment.Near;
			g.DrawString(myLeftText,myFont,myBrush,
				new RectangleF(Location.X,
				                Location.Y,
								currentDefaultPage.CurrentPageWidth/3,
								myTextHeight),locSF);

			locSF.Alignment = StringAlignment.Center;
			g.DrawString(myCenterText, myFont, myBrush,
					new RectangleF(Location.X+currentDefaultPage.CurrentPageWidth/3,
					Location.Y,
					currentDefaultPage.CurrentPageWidth / 3,
					myTextHeight),locSF);

			locSF.Alignment = StringAlignment.Far;
			g.DrawString(myRightText, myFont, myBrush,
					new RectangleF(Location.X+currentDefaultPage.CurrentPageWidth/3*2,
					Location.Y,
					currentDefaultPage.CurrentPageWidth / 3,
					myTextHeight), locSF);

			if (myLineWidth > 0)
				g.DrawLine(new Pen(myBrush, myLineWidth),
					new PointF(Location.X, Location.Y + myTextHeight),
					new PointF(Location.X + currentDefaultPage.CurrentPageWidth, Location.Y + myTextHeight));
		}

		public override System.Drawing.SizeF MeasureSize(System.Drawing.Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage)
		{
			if (IsHeader)
				Location = new PointF(currentDefaultPage.LeftMargin, currentDefaultPage.HeaderDistanceFromPageTopMargin);
			else
				Location = new PointF(currentDefaultPage.LeftMargin,
					currentDefaultPage.CurrentPageHeight + currentDefaultPage.TopMargin +
					currentDefaultPage.BottomMargin - 
					currentDefaultPage.FooterDistanceFromPageBottomMargin);

			return new SizeF(currentDefaultPage.CurrentPageWidth, GetTextHeight(g, currentDefaultPage.CurrentPageWidth) + myLineWidth);
		}

		private float GetTextHeight(Graphics g, float maxWidth)
		{
			SizeF locSize, locSize2;

			locSize = g.MeasureString(myLeftText, myFont, new SizeF(maxWidth/3, 0));
			locSize2 = g.MeasureString(myCenterText, myFont, new SizeF(maxWidth/3, 0));
			if (locSize.Height < locSize2.Height) locSize = locSize2;
			locSize2 = g.MeasureString(myRightText, myFont, new SizeF(maxWidth/3, 0));
			if (locSize.Height < locSize2.Height) locSize = locSize2;
			return myTextHeight=locSize.Height;
		}

		public bool IsHeader
		{
			get { return myIsHeader; }
			set { myIsHeader = value; }
		}

		public bool IsFooter
		{
			get { return !myIsHeader; }
			set { myIsHeader = !value; }
		}
	}
}
