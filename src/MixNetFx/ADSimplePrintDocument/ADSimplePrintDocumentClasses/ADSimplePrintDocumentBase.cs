#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Globalization;

#endregion

namespace ActiveDev.Printing
{
	public partial class ADSimplePrintDocument
	{
		private Font myCurrentFont;
		private Color myCurrentColor;
		private ADPrintableTextBlock  myCurrentWriteLine;
		private bool myWriteInProgress=false;
		private ADTextAlignment myCurrentAlignment;
		private ADPrintableObjects myObjectsToPrint;
		private Queue<IADPrintableObject> locQueuedObjects;
		private PrintDocumentEx myPrintDocument;
		private frmPreview myPrintPreviewDialog;
		private String myDocumentName;
		private Graphics myGraphics;
		private ADSimplePrintDocumentDefaultPages myDefaultPages;
		private ADSimplePrintDocumentDefaultPage myCurrentDefaultPage;
		private String myPrinterName;
		private float myPageWidth;
		private float myPageHeight;
		private bool myFirstPageFlag;
		private int myCurrentPageNo;
		private char[] mySeparator ={ ' ', '-' };

		private bool myTableHeaderBuildInProgress;
		private bool myTableBodyPrintInProgress;
		private bool myCurrentTableHeaderToLarge;
		private ADPrintableObjects myTableHeaderLinesToRepeat;

		public ADSimplePrintDocument(String documentName) 
		{
			myPrintDocument = new PrintDocumentEx();
			myDocumentName = documentName;
			myPrinterName = myPrintDocument.PrinterSettings.PrinterName;
			myCurrentFont = new Font(FontFamily.GenericSerif, 12);
			myDefaultPages = new ADSimplePrintDocumentDefaultPages(false, false);
			InitializeComponents();
		}

		public ADSimplePrintDocument(String documentName, ADSimplePrintDocumentDefaultPages defaultPages)
		{
			myPrintDocument = new PrintDocumentEx();
			myDocumentName = documentName;
			myPrinterName = myPrintDocument.PrinterSettings.PrinterName;
			myDefaultPages = defaultPages;
			InitializeComponents();
		}

		public ADSimplePrintDocument(String documentName, ADSimplePrintDocumentDefaultPages defaultPages, String printerName)
		{
			myPrintDocument = new PrintDocumentEx();
			myDocumentName = documentName;
			myPrinterName = printerName;
			myPrintDocument.PrinterSettings.PrinterName = printerName;
			myDefaultPages = defaultPages;
			InitializeComponents();
		}

		private void InitializeComponents()
		{
			myGraphics = myPrintDocument.PrinterSettings.CreateMeasurementGraphics();
			myGraphics.PageUnit = GraphicsUnit.Document;
			myObjectsToPrint = new ADPrintableObjects();
			myCurrentColor = Color.Black;
			myCurrentAlignment = ADTextAlignment.Left;
			myCurrentWriteLine = null;
		}

		public void PrintDocument()
		{
            if (myWriteInProgress)
                CloseCurrentWriteProcess();

            myCurrentPageNo = 1;
            myTableBuildInProgress = false;
            myTableHeaderBuildInProgress = false;

            // Call the PrinterSettings-Dialog
            PrintDialog locPD = new PrintDialog();
            DialogResult locDR = locPD.ShowDialog();
            if (locDR == DialogResult.Cancel)
                return;

            myPrintDocument = new PrintDocumentEx();
            myPrintDocument.DocumentName = myDocumentName;

            // Associate the event-handling method with the 
            // document's PrintPage event.
            myPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(DocumentPrintPageEventHandler);
            myPrintDocument.PrinterSettings = locPD.PrinterSettings;
            myPrintDocument.Print();
		}

		public void PreviewDocument()
		{
			if (myWriteInProgress)
				CloseCurrentWriteProcess();

			myCurrentPageNo = 1;
			myTableBuildInProgress = false;
			myTableHeaderBuildInProgress = false;

			// Create a new PrintPreviewDialog using constructor.
			myPrintPreviewDialog = new frmPreview();
			myPrintDocument = new PrintDocumentEx();
			myPrintDocument.DocumentName = myDocumentName;

			//Set the size, location, and name.
			myPrintPreviewDialog.ClientSize = new System.Drawing.Size(700,550);
			myPrintPreviewDialog.Location = new System.Drawing.Point(29, 29);
			myPrintPreviewDialog.Name = myDocumentName;
			myPrintPreviewDialog.Text = myDocumentName;
			
			// Associate the event-handling method with the 
			// document's PrintPage event.
			myPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(DocumentPrintPageEventHandler);

			// Set the minimum size the dialog can be resized to.
			myPrintPreviewDialog.MinimumSize = new System.Drawing.Size(630, 440);

			// Set the UseAntiAlias property to true, which will allow the 
			// operating system to smooth fonts.
			myPrintPreviewDialog.UseAntiAlias = true;
			myPrintPreviewDialog.Document = myPrintDocument;
			
			myPrintPreviewDialog.ShowDialog();
		}

		private void DocumentPrintPageEventHandler(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			ADFieldString.myPage = myCurrentPageNo.ToString();
			ADFieldString.PrintingStartDate = DateTime.Now;

			// Zwischenspeichern, weil die Abfrage Ewigkeiten dauert!
			RectangleF locVisibleClipbounds = e.Graphics.VisibleClipBounds;
			
			myCurrentDefaultPage = myDefaultPages.GetPage(myCurrentPageNo);
			myCurrentDefaultPage.CurrentPage = myCurrentPageNo;
			myGraphics = e.Graphics;
			CalculatePageSize(locVisibleClipbounds);

			float locCurrentX = myCurrentDefaultPage.LeftMargin;
			float locCurrentY = myCurrentDefaultPage.TopMargin;

			if (!myFirstPageFlag)
			{
				PrepareDocumentForPrinting();
				myFirstPageFlag = true;
			}

			myCurrentDefaultPage.CurrentPageWidth = myPageWidth;
			myCurrentDefaultPage.CurrentPageHeight = locVisibleClipbounds.Height - myCurrentDefaultPage.TopMargin - myCurrentDefaultPage.BottomMargin;

			myCurrentDefaultPage.RenderBackgroundObjects(myGraphics, myCurrentDefaultPage);

			// TableHeader wiederholen, falls es notwendig ist
			if (myTableBodyPrintInProgress)
				if (myTableHeaderLinesToRepeat != null)
				{
					foreach (IADPrintableObject locPObject in myTableHeaderLinesToRepeat)
					{
						SizeF locObjectSize = locPObject.MeasureSize(e.Graphics, myCurrentDefaultPage);
						locPObject.Location = new PointF(locCurrentX, locCurrentY);
						locCurrentY += locObjectSize.Height + locPObject.DistanceToNext;
						locPObject.Render(e.Graphics, myCurrentDefaultPage);
					}
				}
			
			while (locQueuedObjects.Count > 0)
			{
				IADPrintableObject locPrintableObject = locQueuedObjects.Peek();
				// WICHTIG: MeasureSize muss vor Location kommen, damit die einzelnen
				// Objekte eines kombinierten Objektes wissen, wie hoch sie sind,
				// wenn ihre Location zugeordnet wird, und sie die Startposition setzen.
				SizeF locObjectSize = locPrintableObject.MeasureSize(e.Graphics, myCurrentDefaultPage);

				// Falls das Objekt nicht auf die Seite passt, dann dem Objekt die Chance geben
				// sich auf beiden Seiten zu verteilen
				if (locCurrentY + locObjectSize.Height >= locVisibleClipbounds.Height - myCurrentDefaultPage.BottomMargin)
				{
					// TODO: Logik ausführen
				}

				if (locPrintableObject.IsTableHeader && !myTableHeaderBuildInProgress)
				{
					myTableHeaderLinesToRepeat = new ADPrintableObjects();
					myTableHeaderBuildInProgress = true;
				}

				if (!locPrintableObject.IsTableHeader && myTableHeaderBuildInProgress)
					myTableHeaderBuildInProgress = false;

				if (locPrintableObject.IsTableHeader && myTableHeaderBuildInProgress)
					myTableHeaderLinesToRepeat.Add(locPrintableObject);

				if (locPrintableObject.IsTableRow && !myTableBodyPrintInProgress)
					myTableBodyPrintInProgress = true;

				if (!locPrintableObject.IsTableRow && myTableBodyPrintInProgress)
				{
					myTableBodyPrintInProgress = false;
					myTableHeaderLinesToRepeat = null;
				}

				locPrintableObject.Location = new PointF(locCurrentX, locCurrentY);
				locCurrentY += locObjectSize.Height+locPrintableObject.DistanceToNext;
				if (locCurrentY >= locVisibleClipbounds.Height - myCurrentDefaultPage.BottomMargin)
					break;
				else
				{
					locPrintableObject.Render(e.Graphics, myCurrentDefaultPage);
					locQueuedObjects.Dequeue();
					if (locPrintableObject.PageBreakAfter==-1)
						break;

					if (locPrintableObject.PageBreakAfter > 0)
					{
						myCurrentPageNo = locPrintableObject.PageBreakAfter;
						break;
					}

				}
			}

			myCurrentDefaultPage.RenderForegroundObjects(myGraphics, myCurrentDefaultPage);

			if (locQueuedObjects.Count > 0)
			{
				e.HasMorePages = true;
				myCurrentPageNo++;
			}

			else
			{
				myPrintDocument.TotalPages = myCurrentPageNo;
				e.HasMorePages = false;
				myFirstPageFlag = false;
				myCurrentPageNo = 1;
				myTableHeaderLinesToRepeat = null;
				myTableHeaderBuildInProgress = false;
				myTableBodyPrintInProgress = false;
				myPrintDocument.OnPageRenderingFinished(this, new PageRenderingFinishedEventArgs(myPrintDocument.TotalPages));
			}
		}

		private void PrepareDocumentForPrinting()
		{
			ADCombinedLineObjects locCombinedObject=null;
			bool locKeepWithNextFlag=false;

			locQueuedObjects = new Queue<IADPrintableObject>();

			foreach (IADPrintableObject locPObjects in myObjectsToPrint)
			{
				IADPrintableObject locPO = locPObjects.GetFirstPrintableObject();

				do
				{
					if (locPO.KeepWithNext)
					{
						if (!locKeepWithNextFlag)
						{
							locKeepWithNextFlag = true;
							locCombinedObject = new ADCombinedLineObjects();
							locCombinedObject.PrintableObjects.Add(locPO);
						}
						else
						{
							locCombinedObject.PrintableObjects.Add(locPO);
						}
					}
					else
					{
						if (locKeepWithNextFlag)
						{
							locCombinedObject.PrintableObjects.Add(locPO);
							locKeepWithNextFlag = false;
							locQueuedObjects.Enqueue(locCombinedObject);
							locCombinedObject = null;
						}
						else
						{
							locQueuedObjects.Enqueue(locPO);
						}
					}

					locPO = locPObjects.GetNextPrintableObject();
				}
		
				while (!(locPO == null));
			}
		}

		private void CalculatePageSize(RectangleF visibleClipBounds)
		{
			myPageWidth = visibleClipBounds.Width - myCurrentDefaultPage.LeftMargin - myCurrentDefaultPage.RightMargin;
			myPageHeight = visibleClipBounds.Height - myCurrentDefaultPage.TopMargin - myCurrentDefaultPage.BottomMargin;
		}

		private void PrintObjectInternal(IADPrintableObject printableObject)
		{
			myObjectsToPrint.Add(printableObject);
		}

		public Font CurrentFont
		{
			get { return myCurrentFont; }
			set { myCurrentFont = value; }
		}

		public Color CurrentColor
		{
			get { return myCurrentColor; }
			set { myCurrentColor = value; }
		}

		public ADTextAlignment CurrentAlignment
		{
			get { return myCurrentAlignment; }
			set { myCurrentAlignment = value; }
		}

        public ADSimplePrintDocumentDefaultPages DefaultPages
        {
            get { return myDefaultPages; }
        }

		#region Conversion methods

		public static float CmToDocument(float cm)
		{
			return cm / 2.54F * 100F;
		}

		public static float InchToDocument(float inch)
		{
			return inch * 100F;
		}

		public static float DocumentToCM(float document)
		{
			return document / 100F * 2.54F;
		}

		public static float DocumentToInch(float document)
		{
			return document / 100F;
		}

		#endregion
	}
}
