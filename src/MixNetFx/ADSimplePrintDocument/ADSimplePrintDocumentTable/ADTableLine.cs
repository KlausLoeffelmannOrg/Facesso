using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Drawing;

namespace ActiveDev.Printing
{
	class ADTableLine : ADPrintableObjectBase
	{
		Collection<IADTableCell> myTableLine;

		bool myOnPageWidthExceededThrowException;

		public ADTableLine()
		{
			myTableLine = new Collection<IADTableCell>();
			myOnPageWidthExceededThrowException = false;
		}

		public void Add(IADTableCell tableCell)
		{
			myTableLine.Add(tableCell);
		}

		public override void Render(System.Drawing.Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage)
		{
			foreach (IADTableCell locPo in myTableLine)
			{
				locPo.Render(g, Location.X, Location.Y);
			}
		}

		public override System.Drawing.SizeF MeasureSize(System.Drawing.Graphics g, ADSimplePrintDocumentDefaultPage currentDefaultPage)
		{

			float locMaxHeight = 0;
			float locCurrentX = 0;
			float locHeight;
			IADTableCell locLastCell=null;
			foreach (IADTableCell locPo in myTableLine)
			{
				locHeight = locPo.MeasureTableCell(g);
				if (locMaxHeight < locHeight)
					locMaxHeight = locHeight;
			}

			foreach (IADTableCell locPo in myTableLine)
			{
				locPo.Bounds = new RectangleF(locCurrentX, 0, locPo.Size.Width, locMaxHeight);
				locCurrentX += locPo.Size.Width - locPo.Pen.Width;
				locLastCell = locPo;
			}
			if (locLastCell!=null)
				locCurrentX += locLastCell.Pen.Width;

			return new SizeF(locCurrentX, locMaxHeight);
		}
	}
}
