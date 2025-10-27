using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ActiveDev.Printing
{
	public partial class ADSimplePrintDocument
	{
		bool myTableBuildInProgress;
		float[] myCellWidths;
		int myColumns;
		ADTableLine myCurrentTableLine;
		ADTableLine myReferenceToLastTableLine;
		int myCurrentColumn;
		// int myCurrentRow;
		ADTextCellAlignment myCurrentCellAlignment=ADTextCellAlignment.MiddleLeft;
		Color myCurrentCellBackgroundColor=Color.White;
		Pen myCurrentCellPen = new Pen(Color.Black, 1f);
		ADFrameCellBorderStyle myCellBorderStyle=ADFrameCellBorderStyle.FixedSingle;
		bool myCurrentBuildHeader;
		bool myBodyBuilt = false;
		ADCellMargins myCurrentCellMargins = new ADCellMargins(3, 6, 3, 6);
		
		public void BeginTable(ADFrameCellBorderStyle cellBorderStyle, params float[] CellWidths)
		{
			if (myTableBuildInProgress)
				EndTable();

			if (myWriteInProgress)
				CloseCurrentWriteProcess();

			myCellWidths = CellWidths;
			myColumns = myCellWidths.Length;
			myCurrentTableLine = new ADTableLine();
			myCurrentColumn = 0;
			myTableBuildInProgress = true;
			myCurrentBuildHeader = false;
			myCellBorderStyle = cellBorderStyle;
		}

		public void EndTable()
		{
			myReferenceToLastTableLine.DistanceToNext = myCurrentCellPen.Width;
			myBodyBuilt = false;
		}

		public void WriteCell(string text)
		{
			ADSimpleTextCell locSimpleTextCell = new ADSimpleTextCell(text, myCellBorderStyle, myCurrentCellMargins,
													myCurrentCellBackgroundColor, myCurrentCellPen, myCurrentFont, 
													myCurrentCellAlignment, true, true);
			locSimpleTextCell.Size = new SizeF(myCellWidths[myCurrentColumn++], 0);
			myCurrentTableLine.Add(locSimpleTextCell);

			if (myCurrentColumn == myColumns)
			{
				myCurrentTableLine.IsTableHeader = myCurrentBuildHeader;
				myCurrentTableLine.IsTableRow = true;
				myCurrentTableLine.DistanceToNext = -myCurrentCellPen.Width;
				myReferenceToLastTableLine = myCurrentTableLine;
				PrintObjectInternal(myCurrentTableLine);
				myCurrentTableLine = new ADTableLine();
				myCurrentColumn = 0;
			}
		}

		public void WriteCells(params string[] text)
		{
			foreach (string cellText in text)
				WriteCell(cellText);
		}

		public void BuildTableHeader()
		{
			// TODO: Richtige Fehlermeldung
			if (myBodyBuilt)
				throw new Exception("Table body has already been built; building of table header is not possible at this point!");

			myCurrentBuildHeader=true;
		}

		public void BuildTableBody()
		{
			myBodyBuilt = true;
			myCurrentBuildHeader = false;
		}

		public ADTextCellAlignment CurrentCellAlignment
		{
			get { return myCurrentCellAlignment; }
			set { myCurrentCellAlignment = value; }
		}

		public ADCellMargins CurrentCellMargins
		{
			get { return myCurrentCellMargins; }
			set { myCurrentCellMargins = value; }
		}

		public Pen CurrentCellPen
		{
			get { return myCurrentCellPen; }
			set { myCurrentCellPen = value; }
		}

		public Color CurrentCellBackgroundColor
		{
			get { return myCurrentCellBackgroundColor; }
			set { myCurrentCellBackgroundColor = value; }
		}



	}
}
