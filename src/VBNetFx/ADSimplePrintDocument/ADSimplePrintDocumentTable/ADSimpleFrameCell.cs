using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ActiveDev.Printing
{
	public enum ADFrameCellBorderStyle
	{
		None,
		FixedSingle,
		Fixed3DSunken,
		Fixed3DRaised,
		Fixed3DSunkenFrame,
		Fixed3DRaisedFrame
	}

	/// <summary>
	/// Zusammendfassende Beschreibung für ADTableCellSimpleFrame.
	/// </summary>
	public class ADSimpleFrameCell : ADTableCellBase
	{
		protected RectangleF myClientRect;			// Innerer Bereich Float-Rectangle
		protected RectangleF myBounds;				// Äußerer Bereich Float-Rectangle

		protected bool myHasUpper;
		protected bool myHasLeft;
		protected bool myHasRight;
		protected bool myHasLower;

		public static Color color3D_0 = Color.FromArgb(255, 255, 255);
		public static Color color3D_25 = Color.FromArgb(232, 234, 227);
		public static Color color3D_50 = Color.FromArgb(208, 212, 200);
		public static Color color3D_75 = Color.FromArgb(142, 151, 123);
		public static Color color3D_100 = Color.FromArgb(64, 64, 64);

		// TODO: Bild als Hintergrund

		public ADSimpleFrameCell()
		{
			// Nichts ist initialisiert!
		}

		public ADSimpleFrameCell(Color backgroundColor, Pen pen, ADFrameCellBorderStyle borderstyle, bool AutoSize)
		{
			ADTFrameConstructor(backgroundColor, pen, borderstyle, true, true, true, true, AutoSize);
		}

		private void ADTFrameConstructor(Color backgroundColor, Pen pen, ADFrameCellBorderStyle borderstyle, bool HasUpper, bool HasLower, bool HasLeft, bool HasRight, bool AutoSize)
		{
			myAutoSize = AutoSize;
			myBackgroundColor = backgroundColor;
			myForegroundColor = pen.Color;
			myBorderstyle = borderstyle;
			myPen = pen;
			myHasUpper = HasUpper;
			myHasLower = HasLower;
			myHasLeft = HasLeft;
			myHasRight = HasRight;
		}

		/// <summary>
		/// Berechnet auf Grund der Ausmaße den Clientbereich, oder, bei AutoSize=true, auf Grund von MeasureTableCell, die Ausmaße der Bounds
		/// </summary>
		/// <param name="CellAutoSize">Bestimmt, ob die Zelle Ihre Ausmaße ermitteln kann, oder diese vorgegeben bekommt</param>
		public override void CalculateDimensions(Graphics g)
		{
			Pen framePen = myPen;
			myDimensionCalculated = true;

			// Größe des inneren Rechteckes berechnen
			myClientRect.X = myHasLeft ? myBounds.X + DrawLeftBorderLine(myBounds, g, myBorderstyle, framePen, true, myHasUpper, myHasLower) : myBounds.X;
			myClientRect.Y = myHasUpper ? myBounds.Y + DrawUpperBorderLine(myBounds, g, myBorderstyle, framePen, true, myHasLeft, myHasRight) : myBounds.Y;
			myClientRect.Width = myHasRight ? myBounds.Width - DrawRightBorderLine(myBounds, g, myBorderstyle, framePen, true, myHasUpper, myHasLower) : myBounds.Width;
			myClientRect.Width = myClientRect.Width - (myHasLeft ? DrawLeftBorderLine(myBounds, g, myBorderstyle, framePen, true, myHasUpper, myHasLower) : 0);

			// falls nicht AutoSize oder gerade am Ausrichten, dann wird die Höhe
			// ohne Rücksicht auf Verluste brechnet. Hintergrund: Bei AutoSize=true
			// wurde zuvor schon MeasureTable-Cell aufgerufen, so dass die maximale Höhe
			// auf jeden Fall gegeben ist.
			if (!this.myAutoSize || this.myAligning)
			{
				myClientRect.Height = myHasLower ? myBounds.Height - DrawRightBorderLine(myBounds, g, myBorderstyle, framePen, true, myHasUpper, myHasLower) : myBounds.Height;
				myClientRect.Height = myClientRect.Height - (myHasUpper ? DrawUpperBorderLine(myBounds, g, myBorderstyle, framePen, true, myHasLeft, myHasRight) : 0);
			}
			else
			{
				// Falls AutoSize true ist, muss MeasureTableCell aufgerufen werden,
				// damit die Höhe des Clientberechs bekannt ist. Anschließend wird
				// das umgebende Rechteck aufgrund dieser Höhe brechnet.
				myClientRect.Height = MeasureTableCell(g);
				if (myClientRect.Height < myMinimumHeight)
					myClientRect.Height = myMinimumHeight;
				myBounds.Height = myClientRect.Height + (myHasUpper ? DrawUpperBorderLine(myBounds, g, myBorderstyle, framePen, true, myHasLeft, myHasRight) : 0);
				myBounds.Height = myBounds.Height + (myHasLower ? DrawLowerBorderLine(myBounds, g, myBorderstyle, framePen, true, myHasLeft, myHasRight) : 0);
			}
		}

		public override void SetSideLines(bool Left, bool Right, bool Upper, bool Lower)
		{
			myHasLeft = Left;
			myHasRight = Right;
			myHasUpper = Upper;
			myHasLower = Lower;
		}

		/// <summary>
		/// Malt die Zelle
		/// </summary>
		/// <param name="OffsetX">X-Offset</param>
		/// <param name="OffsetY">Y-Offset</param>
		public override void Render(Graphics g, float OffsetX, float OffsetY)
		{
			if (!myDimensionCalculated)
				CalculateDimensions(g);
			RenderOutline(g, OffsetX, OffsetY);
			RenderBackground(g,OffsetX, OffsetY);
		}

		// TODO: Eliminieren von OffsetX und OffsetY in allen Zellen
		protected virtual void RenderOutline(Graphics g, float OffsetX, float OffsetY)
		{
			LineF rt;
			bool firstLine = false;
			GraphicsPath gp = new GraphicsPath();

			// Graphicspfad erstellen, damit verbundene Linien gezeichnet werden können
			// Graphicspfad erstellen
			bool LastItemHadNoLine = false;
			bool fullClosed = false;

			// TODO: korrigieren
			if (myBorderstyle != ADFrameCellBorderStyle.None)
			{

				// CycleList erstellen
				CycleList cl = new CycleList();
				cl.Add(new SideLine(myHasLeft, new LineF(myBounds.X + myPen.Width / 2, myHasLower ? myBounds.Y + myBounds.Height - myPen.Width / 2 : myBounds.Y + myBounds.Height, myBounds.X + myPen.Width / 2, myHasUpper ? myBounds.Y + myPen.Width / 2 : myBounds.Y)));
				cl.Add(new SideLine(myHasUpper, new LineF(myHasLeft ? myBounds.X + myPen.Width / 2 : myBounds.X, myBounds.Y + myPen.Width / 2, myHasRight ? myBounds.X + myBounds.Width - myPen.Width / 2 : myBounds.X + myBounds.Width, myBounds.Y + myPen.Width / 2)));
				cl.Add(new SideLine(myHasRight, new LineF(myBounds.X + myBounds.Width - myPen.Width / 2, myHasUpper ? myBounds.Y + myPen.Width / 2 : myBounds.Y, myBounds.X + myBounds.Width - myPen.Width / 2, myHasLower ? myBounds.Y + myBounds.Height - myPen.Width / 2 : myBounds.Y + myBounds.Height)));
				cl.Add(new SideLine(myHasLower, new LineF(myHasRight ? myBounds.X + myBounds.Width - myPen.Width / 2 : myBounds.X + myBounds.Width, myBounds.Y + myBounds.Height - myPen.Width / 2, myHasLeft ? myBounds.X + myPen.Width / 2 : myBounds.X, myBounds.Y + myBounds.Height - myPen.Width / 2)));

				// erste vorhandene Linie nach nicht vorhandener Linie finden, das ist Startpunkt der Linie
				cl.MoveFirst();
				for (; ; )
				{
					if (!((SideLine)cl.CurrentItem).ToDraw)
						LastItemHadNoLine = true;
					else if (LastItemHadNoLine)
					{
						// Element als Startobjekt markieren
						cl.StartItem = cl.CurrentIndex;
						break;
					}
					cl.MoveNext();

					// einmal 'rum?
					if (cl.Bol)
					{
						// falls keine freie Fläche, dann ist Startobjekt das erste Element
						cl.StartItem = cl.CurrentIndex;
						if (LastItemHadNoLine)
							fullClosed = false;
						else
							fullClosed = true;
						break;
					}
				}

				// alle aufeinanderfolgendene Linien (4) malen bis zum Startobjekt
				cl.MoveToStartItem();

				for (int i = 0; i < 4; i++)
				{
					if (((SideLine)(cl.CurrentItem)).ToDraw)
					{
						if (!firstLine)
						{
							gp.StartFigure();
							firstLine = true;
						}
						rt = ((SideLine)cl.CurrentItem).Coords;
						gp.AddLine(rt.X1 + OffsetX, rt.Y1 + OffsetY, rt.X2 + OffsetX, rt.Y2 + OffsetY);
					}
					else
					{
						firstLine = false;
					}
					cl.MoveNext();
				}
				if (fullClosed)
					gp.CloseFigure();

				if (myBorderstyle == ADFrameCellBorderStyle.FixedSingle)
				{
					g.DrawPath(myPen, gp);
				}

					// alle anderen Linienstile malen
				else
				{
					RectangleF recTemp = new RectangleF(myBounds.X+OffsetX, 
														myBounds.Y+OffsetY,
														myBounds.Width,
														myBounds.Height);

					if (myHasLeft)
						DrawLeftBorderLine(recTemp, g, myBorderstyle, myPen, false, myHasUpper, myHasLower);
					if (myHasUpper)
						DrawUpperBorderLine(recTemp, g, myBorderstyle, myPen, false, myHasLeft, myHasRight);
					if (myHasRight)
						DrawRightBorderLine(recTemp, g, myBorderstyle, myPen, false, myHasUpper, myHasLower);
					if (myHasLower)
						DrawLowerBorderLine(recTemp, g, myBorderstyle, myPen, false, myHasLeft, myHasRight);
				}
			}
		}

		protected virtual void RenderBackground(Graphics g, float OffsetX, float OffsetY)
		{
			g.FillRectangle(new SolidBrush(BackgroundColor),
				myClientRect.X+OffsetX,
				myClientRect.Y+OffsetY,
				myClientRect.Width,
				myClientRect.Height);
		}

		public override float MeasureTableCell(Graphics g)
		{
			if (!myDimensionCalculated)
				CalculateDimensions(g);
			return myBounds.Height;
		}

		public static float DrawUpperBorderLine(RectangleF r, Graphics g, ADFrameCellBorderStyle bs, Pen pen, bool JustCalculate, bool closeLeft, bool closeRight)
		{
			switch (bs)
			{
				case ADFrameCellBorderStyle.None:
					return 0;

				case ADFrameCellBorderStyle.FixedSingle:
					if (!JustCalculate)
						g.DrawLine(pen, r.X, r.Y + pen.Width / 2, r.X + r.Width, r.Y + pen.Width / 2);
					return pen.Width;

				case ADFrameCellBorderStyle.Fixed3DSunken:
					if (!JustCalculate)
					{
						g.DrawLine(new Pen(color3D_75, pen.Width), r.X, r.Y + pen.Width / 2, closeRight ? r.X + r.Width - pen.Width : r.X + r.Width, r.Y + pen.Width / 2);
						g.DrawLine(new Pen(color3D_100, pen.Width), closeLeft ? r.X + pen.Width : r.X, r.Y + pen.Width + pen.Width / 2, closeRight ? r.X + r.Width - (pen.Width * 2) : r.X + r.Width, r.Y + pen.Width + pen.Width / 2);
					}
					return pen.Width + pen.Width;

				case ADFrameCellBorderStyle.Fixed3DRaised:
					if (!JustCalculate)
					{
						g.DrawLine(new Pen(color3D_25, pen.Width), r.X, r.Y + pen.Width / 2, closeRight ? r.X + r.Width - pen.Width : r.X + r.Width, r.Y + pen.Width / 2);
					}
					return pen.Width;

				case ADFrameCellBorderStyle.Fixed3DRaisedFrame:
					if (!JustCalculate)
					{
						g.DrawLine(new Pen(color3D_25, pen.Width), r.X, r.Y + pen.Width / 2, closeRight ? r.X + r.Width - pen.Width : r.X + r.Width, r.Y + pen.Width / 2);
						g.DrawLine(new Pen(color3D_75, pen.Width), closeRight ? r.X + pen.Width : r.X, r.Y + pen.Width + pen.Width / 2, closeRight ? r.X + r.Width - (pen.Width * 2) : r.X + r.Width, r.Y + pen.Width + pen.Width / 2);
					}
					return pen.Width + pen.Width;

				case ADFrameCellBorderStyle.Fixed3DSunkenFrame:
					if (!JustCalculate)
					{
						g.DrawLine(new Pen(color3D_75, pen.Width), r.X, r.Y + pen.Width / 2, closeRight ? r.X + r.Width - pen.Width : r.X + r.Width, r.Y + pen.Width / 2);
						g.DrawLine(new Pen(color3D_25, pen.Width), closeLeft ? r.X + pen.Width : r.X, r.Y + pen.Width + pen.Width / 2, closeRight ? r.X + r.Width - (pen.Width * 2) : r.X + r.Width, r.Y + pen.Width + pen.Width / 2);
					}
					return pen.Width + pen.Width;

				default:
					return 0;
			}
		}

		public static float DrawLowerBorderLine(RectangleF r, Graphics g, ADFrameCellBorderStyle bs, Pen pen, bool JustCalculate, bool closeLeft, bool closeRight)
		{
			switch (bs)
			{
				case ADFrameCellBorderStyle.None:
					return 0;

				case ADFrameCellBorderStyle.FixedSingle:
					if (!JustCalculate)
						g.DrawLine(pen, r.X, r.Y + r.Height - pen.Width / 2, r.X + r.Width, r.Y + r.Height - pen.Width / 2);
					return pen.Width;

				case ADFrameCellBorderStyle.Fixed3DSunken:
					if (!JustCalculate)
					{
						g.DrawLine(new Pen(color3D_50, pen.Width), closeLeft ? r.X + pen.Width : r.X, r.Y + r.Height - pen.Width - pen.Width / 2, closeRight ? r.X + r.Width - (pen.Width * 2) : r.X + r.Width, r.Y + r.Height - pen.Width - pen.Width / 2);
						g.DrawLine(new Pen(color3D_25, pen.Width), r.X, r.Y + r.Height - pen.Width / 2, closeRight ? r.X + r.Width - pen.Width : r.X + r.Width, r.Y + r.Height - pen.Width / 2);
					}
					return pen.Width + pen.Width;

				case ADFrameCellBorderStyle.Fixed3DRaised:
					if (!JustCalculate)
					{
						g.DrawLine(new Pen(color3D_75, pen.Width), closeLeft ? r.X + pen.Width : r.X, r.Y + r.Height - pen.Width - pen.Width / 2, closeRight ? r.X + r.Width - (pen.Width * 2) : r.X + r.Width, r.Y + r.Height - pen.Width - pen.Width / 2);
						g.DrawLine(new Pen(color3D_100, pen.Width), r.X, r.Y + r.Height - pen.Width / 2, closeRight ? r.X + r.Width - pen.Width : r.X + r.Width, r.Y + r.Height - pen.Width / 2);
					}
					return pen.Width + pen.Width;

				case ADFrameCellBorderStyle.Fixed3DRaisedFrame:
					if (!JustCalculate)
					{
						g.DrawLine(new Pen(color3D_25, pen.Width), closeLeft ? r.X + pen.Width * 2 : r.X, r.Y + r.Height - pen.Width - pen.Width / 2, closeRight ? r.X + r.Width - (pen.Width * 2) : r.X + r.Width, r.Y + r.Height - pen.Width - pen.Width / 2);
						g.DrawLine(new Pen(color3D_75, pen.Width), closeLeft ? r.X + pen.Width : r.X, r.Y + r.Height - pen.Width / 2, r.X + r.Width - pen.Width, r.Y + r.Height - pen.Width / 2);
					}
					return pen.Width + pen.Width;

				case ADFrameCellBorderStyle.Fixed3DSunkenFrame:
					if (!JustCalculate)
					{
						g.DrawLine(new Pen(color3D_75, pen.Width), closeLeft ? r.X + pen.Width * 2 : r.X, r.Y + r.Height - pen.Width - pen.Width / 2, closeRight ? r.X + r.Width - (pen.Width * 2) : r.X + r.Width, r.Y + r.Height - pen.Width - pen.Width / 2);
						g.DrawLine(new Pen(color3D_25, pen.Width), closeLeft ? r.X + pen.Width : r.X, r.Y + r.Height - pen.Width / 2, r.X + r.Width - pen.Width, r.Y + r.Height - pen.Width / 2);
					}
					return pen.Width + pen.Width;

				default:
					return 0;
			}
		}
		public static float DrawLeftBorderLine(RectangleF r, Graphics g, ADFrameCellBorderStyle bs, Pen pen, bool JustCalculate, bool closeTop, bool closeBottom)
		{
			switch (bs)
			{
				case ADFrameCellBorderStyle.None:
					return 0;

				case ADFrameCellBorderStyle.FixedSingle:
					if (!JustCalculate)
						g.DrawLine(pen, r.X + pen.Width / 2, r.Y, r.X + pen.Width / 2, r.Y + r.Height);
					return pen.Width;

				case ADFrameCellBorderStyle.Fixed3DSunken:
					if (!JustCalculate)
					{
						g.DrawLine(new Pen(color3D_75, pen.Width), r.X + pen.Width / 2, r.Y, r.X + pen.Width / 2, closeBottom ? r.Y + r.Height - pen.Width : r.Y + r.Height);
						g.DrawLine(new Pen(color3D_100, pen.Width), r.X + pen.Width + pen.Width / 2, closeTop ? r.Y + pen.Width : r.Y, r.X + pen.Width + pen.Width / 2, closeBottom ? r.Y + r.Height - pen.Width * 2 : r.Y + r.Height);
					}
					return (pen.Width * 2);

				case ADFrameCellBorderStyle.Fixed3DRaised:
					if (!JustCalculate)
					{
						g.DrawLine(new Pen(color3D_25, pen.Width), r.X + pen.Width / 2, r.Y, r.X + pen.Width / 2, closeBottom ? r.Y + r.Height - pen.Width : r.Y + r.Height);

					}
					return pen.Width;

				case ADFrameCellBorderStyle.Fixed3DSunkenFrame:
					if (!JustCalculate)
					{
						g.DrawLine(new Pen(color3D_75, pen.Width), r.X + pen.Width / 2, r.Y, r.X + pen.Width / 2, closeBottom ? r.Y + r.Height - pen.Width : r.Y + r.Height);
						g.DrawLine(new Pen(color3D_25, pen.Width), r.X + pen.Width + pen.Width / 2, closeTop ? r.Y + pen.Width : r.Y, r.X + pen.Width + pen.Width / 2, closeBottom ? r.Y + r.Height - pen.Width * 2 : r.Y + r.Height);
					}
					return pen.Width + pen.Width;

				case ADFrameCellBorderStyle.Fixed3DRaisedFrame:
					if (!JustCalculate)
					{
						g.DrawLine(new Pen(color3D_25, pen.Width), r.X + pen.Width / 2, r.Y, r.X + pen.Width / 2, r.Y + r.Height);
						g.DrawLine(new Pen(color3D_75, pen.Width), r.X + pen.Width + pen.Width / 2, closeTop ? r.Y + pen.Width : r.Y, r.X + pen.Width + pen.Width / 2, closeBottom ? r.Y + r.Height - pen.Width : r.Y + r.Height);
					}
					return pen.Width + pen.Width;

				default:
					return 0;
			}
		}

		public static float DrawRightBorderLine(RectangleF r, Graphics g, ADFrameCellBorderStyle bs, Pen pen, bool JustCalculate, bool closeTop, bool closeBottom)
		{
			switch (bs)
			{
				case ADFrameCellBorderStyle.None:
					return 0;

				case ADFrameCellBorderStyle.FixedSingle:
					if (!JustCalculate)
						g.DrawLine(pen, r.X + r.Width - pen.Width / 2, r.Y, r.X + r.Width - pen.Width / 2, r.Y + r.Height);
					return pen.Width;

				case ADFrameCellBorderStyle.Fixed3DSunken:
					if (!JustCalculate)
					{
						g.DrawLine(new Pen(color3D_50, pen.Width), r.X + r.Width - pen.Width - pen.Width / 2, r.Y + pen.Width, r.X + r.Width - pen.Width - pen.Width / 2, closeBottom ? r.Y + r.Height - pen.Width : r.Y + r.Height);
						g.DrawLine(new Pen(color3D_25, pen.Width), r.X + r.Width - pen.Width / 2, r.Y, r.X + r.Width - pen.Width / 2, r.Y + r.Height);
					}
					return pen.Width + pen.Width;

				case ADFrameCellBorderStyle.Fixed3DRaised:
					if (!JustCalculate)
					{
						g.DrawLine(new Pen(color3D_75, pen.Width), r.X + r.Width - pen.Width - pen.Width / 2, closeTop ? r.Y + pen.Width : r.Y, r.X + r.Width - pen.Width - pen.Width / 2, closeBottom ? r.Y + r.Height - pen.Width : r.Y + r.Height);
						g.DrawLine(new Pen(color3D_100, pen.Width), r.X + r.Width - pen.Width / 2, r.Y, r.X + r.Width - pen.Width / 2, r.Y + r.Height);

					}
					return pen.Width + pen.Width;

				case ADFrameCellBorderStyle.Fixed3DSunkenFrame:
					if (!JustCalculate)
					{
						g.DrawLine(new Pen(color3D_75, pen.Width), r.X + r.Width - pen.Width - pen.Width / 2, r.Y, r.X + r.Width - pen.Width - pen.Width / 2, closeBottom ? r.Y + r.Height - pen.Width : r.Y + r.Height);
						g.DrawLine(new Pen(color3D_25, pen.Width), r.X + r.Width - pen.Width / 2, r.Y, r.X + r.Width - pen.Width / 2, r.Y + r.Height);
					}
					return pen.Width + pen.Width;

				case ADFrameCellBorderStyle.Fixed3DRaisedFrame:
					if (!JustCalculate)
					{
						g.DrawLine(new Pen(color3D_25, pen.Width), r.X + r.Width - pen.Width - pen.Width / 2, closeTop ? r.Y + pen.Width : r.Y, r.X + r.Width - pen.Width - pen.Width / 2, closeBottom ? r.Y + r.Height - pen.Width : r.Y + r.Height);
						g.DrawLine(new Pen(color3D_75, pen.Width), r.X + r.Width - pen.Width / 2, r.Y, r.X + r.Width - pen.Width / 2, closeBottom ? r.Y + r.Height - pen.Width : r.Y + r.Height);
					}
					return pen.Width + pen.Width;

				default:
					return 0;
			}


		}
		#region Properties
		public override RectangleF ClientRectangle
		{
			get
			{
				return myClientRect;
			}

			set
			{
				myClientRect = value;
			}
		}

		public override RectangleF Bounds
		{
			get
			{
				return myBounds;
			}

			set
			{
				myBounds = value;
				myDimensionCalculated = false;
			}
		}

		public override bool HasUpper
		{
			get	{ return myHasUpper; }
			set	{ myHasUpper = value; }
		}

		public override bool HasLower
		{
			get	{ return myHasLower; }
			set	{ myHasLower = value; }
		}

		public override bool HasRight
		{
			get	{ return myHasRight; }
			set	{ myHasRight = value; }
		}

		public override bool HasLeft
		{
			get	{ return myHasLeft;	}
			set { myHasLeft = value; }
		}

		public override bool FirstTableRow
		{
			get { return myFirstTableRow; }
			set	{ myFirstTableRow = value; }
		}

		public override bool LastTableRow
		{
			get
			{
				return myLastTableRow;
			}

			set
			{
				myLastTableRow = value;
			}
		}

		public override bool FirstTableCol
		{
			get
			{
				return myFirstTableCol;
			}

			set
			{
				myFirstTableCol = value;
			}
		}

		public override bool LastTableCol
		{
			get
			{
				return myLastTableCol;
			}

			set
			{
				myLastTableCol = value;
			}
		}
		#endregion


		protected struct LineF
		{
			public float X1;
			public float Y1;
			public float X2;
			public float Y2;

			public LineF(float x1, float y1, float x2, float y2)
			{
				X1 = x1;
				X2 = x2;
				Y1 = y1;
				Y2 = y2;
			}
		}

		protected struct SideLine
		{
			public bool ToDraw;
			public LineF Coords;

			public SideLine(bool toDraw, LineF coords)
			{
				ToDraw = toDraw;
				Coords = coords;
			}
		}
	}
}
