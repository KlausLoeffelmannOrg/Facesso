using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ActiveDev.Printing
{
	public struct ADCellMargins
	{
		float myLeftMargin;
		float myRightMargin;
		float myTopMargin;
		float myBottomMargin;

		public ADCellMargins(float LeftMargin, float RightMargin, float TopMargin, float BottomMargin)
		{
			myLeftMargin = LeftMargin;
			myRightMargin = RightMargin;
			myTopMargin = TopMargin;
			myBottomMargin = BottomMargin;
		}

		public float LeftMargin
		{
			get { return myLeftMargin; }
			set { myLeftMargin = value; }
		}

		public float RightMargin
		{
			get { return myRightMargin; }
			set { myRightMargin = value; }
		}

		public float TopMargin
		{
			get { return myTopMargin; }
			set { myTopMargin = value; }
		}

		public float BottomMargin
		{
			get { return myBottomMargin; }
			set { myBottomMargin = value; }
		}
	}
	
	internal interface IADTableCell
	{
		int Row { get; set;}
		int Col { get; set;}
		bool AutoSize { get; set;}
		bool Aligning { get; set;}
		float MinimumHeight { get; set;}

		Color BackgroundColor { get; set; }
		Color ForegroundColor { get; set; }

		bool HasLeft { get; set;}
		bool HasRight { get; set;}
		bool HasLower { get; set;}
		bool HasUpper { get; set;}

		bool FirstTableRow { get; set;}
		bool FirstTableCol { get; set;}
		bool LastTableRow { get; set;}
		bool LastTableCol { get; set;}

		Pen Pen { get; set; }

		RectangleF Bounds { get; set;}
		RectangleF ClientRectangle { get; set;}
		SizeF Size { get; set; }
		PointF Location { get; set; }

		void Render(Graphics g, float OffsetX, float OffsetY);
		void SetSideLines(bool Left, bool Right, bool Upper, bool Lower);
		float MeasureTableCell(Graphics g);
		void CalculateDimensions(Graphics g);
	}

	public abstract class ADTableCellBase : IADTableCell
	{
		protected bool myFirstTableRow=false;
		protected bool myFirstTableCol=false;
		protected bool myLastTableRow=false;
		protected bool myLastTableCol=false;
		protected int myRow=0;
		protected int myCol=0;
		protected bool myHeader=false;
		protected bool myAutoSize=false;
		protected bool myAligning=false;
		protected float myMinimumHeight=1;
		protected Color myForegroundColor;
		protected Color myBackgroundColor;
		protected bool myDimensionCalculated;

		protected Font myFont;
		protected Pen myPen;
		protected ADFrameCellBorderStyle myBorderstyle;

		public abstract void Render(Graphics g, float X, float Y);
		public abstract void SetSideLines(bool Left, bool Right, bool Upper, bool Lower);

		public abstract RectangleF Bounds{get;set;}
		public abstract RectangleF ClientRectangle{get;set;}
		public abstract float MeasureTableCell(Graphics g);
		public abstract void CalculateDimensions(Graphics g);

		public abstract bool FirstTableCol {get;set;}
		public abstract bool LastTableCol {get;set;}
		public abstract bool FirstTableRow {get;set;}
		public abstract bool LastTableRow {get;set;}

		public abstract bool HasLeft {get; set;}
		public abstract bool HasRight {get; set;}
		public abstract bool HasLower {get; set;}
		public abstract bool HasUpper {get; set;}
		
		/// <summary>
		/// Die aktuelle Reihe der Zelle in der Tabelle
		/// </summary>
		public int Row
		{
			get { return myRow; }
			set	{ myRow=value; }
		}

		/// <summary>
		/// Die aktuelle Spalte der Zelle in der Tabelle
		/// </summary>
		public int Col
		{
			get { return myCol; }
			set { myCol=value; }
		}

		/// <summary>
		/// Bestimmt oder ermittelt, ob die Zelle Ihre notwendige Höhe selber ermittelt.
		/// </summary>
		public virtual bool AutoSize
		{
			get { return myAutoSize; }
			set { myAutoSize=value; }
		}

		/// <summary>
		/// Nur für die interne Verwendung. Bestimmt oder ermittelt, ob die Zelle gerade ausgerichtet wird.
		/// </summary>
		public virtual bool Aligning
		{
			get { return myAligning; }
			set	{ myAligning=value; }
		}

		/// <summary>
		/// Ermittelt oder bestimmt die Mindesthöhe der Zelle. Die Zelle wird durch Reihenausrichten nie kleiner als dieser Wert.
		/// </summary>
		public virtual float MinimumHeight
		{
			get	{ return myMinimumHeight;	}
			set	{ myMinimumHeight=value; }
		}

		/// <summary>
		/// Ermittelt oder bestimmt die Hintergrundfarbe der Zelle
		/// </summary>
		public virtual Color BackgroundColor
		{
			get { return myBackgroundColor; }
			set { myBackgroundColor = value; }
		}

		/// <summary>
		/// Ermittelt oder bestimmt die Hintergrundfarbe der Zelle
		/// </summary>
		public virtual Color ForegroundColor
		{
			get { return myForegroundColor; }
			set { myForegroundColor = value; }
		}

		public virtual Pen Pen
		{
			get { return myPen; }
			set { myPen = value; }
		}

		public virtual Font Font
		{
			get { return myFont; }
			set { myFont = value; }
		}

		public virtual ADFrameCellBorderStyle Borderstyle
		{
			get { return myBorderstyle; }
			set { myBorderstyle = value; }
		}

		public virtual SizeF Size
		{
			get { return new SizeF(Bounds.Width,Bounds.Height); }
			set { Bounds = new RectangleF(Bounds.X, Bounds.Y, value.Width, value.Height); }
		}

		public virtual PointF Location
		{
			get { return new PointF(Bounds.X, Bounds.Y); }
			set { Bounds = new RectangleF(value.X, value.Y, Bounds.Width, Bounds.Height); }
		}
	}
}
