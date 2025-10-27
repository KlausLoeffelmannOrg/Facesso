#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

#endregion

namespace ActiveDev.Printing
{
	public interface IADPrintableObjectPart
	{
		SizeF MeasureSize(Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage);
		float LineSpace { get;}
		float AscentHeight { get; }
		float OffsetToBaseline { get; }
		float BaselineHeight { get; set; }
		float LastTrailingCharWidth { get; }
		PointF Location { get; set; }
		SizeF Size { get; set; }
		void Render(Graphics g, float x_offset, float y_offset, ADSimplePrintDocumentDefaultPage currentDefaultPage);
	}

	public abstract class ADPrintableObjectPartBase : IADPrintableObjectPart
	{
		protected PointF myLocation;
		protected SizeF mySize;
		protected float myLineSpace;
		protected float myAscentHeight;
		protected float myBaselineHeight;
		protected float myLastTrailingCharWidth;

		public virtual PointF Location
		{
			get { return myLocation; }
			set { myLocation = value; }
		}

		public virtual SizeF Size
		{
			get { return mySize; }
			set { mySize = value; }
		}

		public virtual float LineSpace
		{
			get { return myLineSpace; }
		}

		public virtual float AscentHeight
		{
			get { return myAscentHeight; }
		}

		public virtual float OffsetToBaseline
		{
			get { return BaselineHeight-AscentHeight; }
		}

		public virtual float BaselineHeight
		{
			get { return myBaselineHeight; }
			set { myBaselineHeight = value; }
		}

		public virtual float LastTrailingCharWidth
		{
			get { return myLastTrailingCharWidth; }
		}

		public abstract void Render(Graphics g, float x_offset, float y_offset, ADSimplePrintDocumentDefaultPage currentDefaultPage);
		public abstract SizeF MeasureSize(Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage);
	}

	public class ADPrintableTextPart : ADPrintableObjectPartBase
	{
		ADFieldString myText;
		Font myFont;
		Brush myBrush;

		public ADPrintableTextPart(ADFieldString text, Font font, Brush brush)
		{
			myText = text;
			myFont = font;
			myBrush = brush;
		}

		public ADFieldString Text
		{
			get { return myText; }
			set { myText = value; }
		}

		public override void Render(Graphics g, float x_offset, float y_offset, ADSimplePrintDocumentDefaultPage currentDefaultPage)
		{
			g.DrawString(myText, myFont, myBrush, new PointF(Location.X + x_offset, Location.Y + y_offset));
		}

		public override SizeF MeasureSize(Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage)
		{
			StringFormat locSF = StringFormat.GenericTypographic;

			if (myText.ToString().EndsWith(" "))
			{
				myLastTrailingCharWidth = g.MeasureString(".", myFont, 0, locSF).Width;
				Size = g.MeasureString(myText.ToStringWithoutLastChar, myFont, 0, locSF);
				Size = new SizeF(Size.Width + myLastTrailingCharWidth, Size.Height);
			}
			else
			{
				myLastTrailingCharWidth = 0;
				Size = g.MeasureString(myText, myFont, 0, locSF);
			}

			myLineSpace = myFont.GetHeight(g);
			int locCellSpace = myFont.FontFamily.GetLineSpacing(myFont.Style);
			int locCellAscent = myFont.FontFamily.GetCellAscent(myFont.Style);
			myAscentHeight = myLineSpace * locCellAscent / locCellSpace;
			return Size;
		}
	}
}

