using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;

namespace ActiveDev.Printing
{
	public class PrintDocumentEx : PrintDocument
	{
		private int myTotalPages;
		public delegate void PageRenderingFinishedEventHandler(object sender, PageRenderingFinishedEventArgs e);
		public event PageRenderingFinishedEventHandler PageRenderingFinished;

		public int TotalPages
		{
			get { return myTotalPages; }
			set { myTotalPages = value; }
		}

		internal void OnPageRenderingFinished(object sender, PageRenderingFinishedEventArgs e)
		{
			if (PageRenderingFinished != null)
			{
				PageRenderingFinished(sender, e);
			}
		}
	}

	public class PageRenderingFinishedEventArgs : EventArgs
	{
		int myTotalPages;

		public PageRenderingFinishedEventArgs(int TotalPages)
		{
			myTotalPages = TotalPages;
		}

		public int TotalPages
		{
			get { return myTotalPages; }
			set { myTotalPages = value; }
		}
	}
}
