using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveDev.Printing
{
	class ADPrintTableColumnInfoAttribute : Attribute
	{
		/// <summary>
		/// Bestimmt, dass die Eigenschaft einer Klasse als Basis für eine Tabellenzelle verwendet wird,
		/// wenn diese Klasse in einer IList-Collection als Basis für das füllen einer Tabelle verwendet werden soll.
		/// </summary>
		/// <param name="ColumnHeaderName">Ausgeschriebener Tabellenkopfname der entsprechenden Spalte</param>
		/// <param name="ColumnWidth">Breite der Spalte in Document-Units</param>
		/// <param name="ColumnOrdinal">Reihenfolge der Spalte</param>
		/// <param name="ColumnAlignment">Ausrichtung der Spalte</param>
		public ADPrintTableColumnInfoAttribute(string ColumnHeaderName, float ColumnWidth, 
											   float ColumnOrdinal, ADTextCellAlignment ColumnAlignment)
		{

		}
	}

	class ADPrintTableInfoAttribute : Attribute
	{
		public ADPrintTableInfoAttribute()
		{
		}
	}
}
