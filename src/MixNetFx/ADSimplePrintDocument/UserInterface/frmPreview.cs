using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Microsoft.Win32;

namespace ActiveDev.Printing
{
	public partial class frmPreview : Form
	{
		private string myDocumentName;
		private PrintDocumentEx myDocument;
		private string myPrintedBy;
		private bool myRenderingFinished;
		private ToolStripMenuItem myLastMenu;
        private bool myAutoSaveSettings;

		public frmPreview()
		{
			InitializeComponent();
			myPrintedBy = "unbekannt";
			this.MouseWheel += new MouseEventHandler(frmPreview_MouseWheel);
			this.ppcMain.StartPageChanged += new EventHandler(ppcMain_StartPageChanged);
			myLastMenu = tsmZoomAuto;
            myAutoSaveSettings = true;
		}

		public PrintDocumentEx Document
		{
			get { return (PrintDocumentEx) this.ppcMain.Document; }
			set 
			{
				myDocument = value;
				if (myDocument != null)
				{
					myDocument.PageRenderingFinished += new PrintDocumentEx.PageRenderingFinishedEventHandler(myDocument_PageRenderingFinished);
					myRenderingFinished = false;
					this.ppcMain.Document = value;
				}
			}
		}

		public bool UseAntiAlias
		{
			get { return this.ppcMain.UseAntiAlias; }
			set { this.ppcMain.UseAntiAlias = value; }
		}

		public string DocumentName
		{
			get { return myDocumentName; }
			set { myDocumentName = value; }
		}

		public string PrintedBy
		{
			get { return myPrintedBy; }
			set { myPrintedBy = value; }
		}

        public bool AutoSaveSettings
        {
            get { return myAutoSaveSettings; }
            set { myAutoSaveSettings = value; }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (myAutoSaveSettings)
            {
                int locTop, locLeft, locWidth, locHeight;
                // Versuchen, Einstellungen aus der Registry zu laden
                string locAppName = AppDomain.CurrentDomain.FriendlyName;
                try
                {
                    locTop = (int)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\ActiveDev\\ADSimplePrintDocument\\" + locAppName, "PreviewWindows_Top", 10);
                    locLeft = (int)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\ActiveDev\\ADSimplePrintDocument\\" + locAppName, "PreviewWindows_Left", 10);
                    locWidth = (int)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\ActiveDev\\ADSimplePrintDocument\\" + locAppName, "PreviewWindows_Width", 400);
                    locHeight = (int)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\ActiveDev\\ADSimplePrintDocument\\" + locAppName, "PreviewWindows_Height", 250);
                    this.Location = new Point(locLeft, locTop);
                    this.Size = new Size(locWidth, locHeight);
                }
                catch (Exception ex)
                {
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (myAutoSaveSettings)
            {
                string locAppName = AppDomain.CurrentDomain.FriendlyName;
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\ActiveDev\\ADSimplePrintDocument\\" + locAppName, "PreviewWindows_Top", this.Location.Y);
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\ActiveDev\\ADSimplePrintDocument\\" + locAppName, "PreviewWindows_Left", this.Location.X);
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\ActiveDev\\ADSimplePrintDocument\\" + locAppName, "PreviewWindows_Width", this.Size.Width);
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\ActiveDev\\ADSimplePrintDocument\\" + locAppName, "PreviewWindows_Height", this.Size.Height);
            }
        }

		private void myDocument_PageRenderingFinished(object sender, PageRenderingFinishedEventArgs e)
		{
			vsbPageAdjuster.Maximum = myDocument.TotalPages;
			vsbPageAdjuster.Minimum = 1;
			vsbPageAdjuster.LargeChange = 1;
			vsbPageAdjuster.SmallChange = 1;
			tslPrintDate.Text = DateTime.Now.ToLongDateString();
			tslPrintedBy.Text = "Gedruckt von: " + PrintedBy;
			System.Diagnostics.Debug.Print(ppcMain.Zoom.ToString());
			myRenderingFinished = true;
			updatePageInfo();
		}

		private void updateZoomInfo()
		{
			string locZoom = ((int)(ppcMain.Zoom * 100)).ToString() + " %";
			if (ppcMain.AutoZoom)
				locZoom += " (Auto)";
			ttbZoom.Text = locZoom;
		}

		private void updatePageInfo()
		{
			tslTotalPages.Text = "Seite " + (ppcMain.StartPage + 1).ToString() + " von " + myDocument.TotalPages.ToString();
			ttbGotoPage.Text = (ppcMain.StartPage + 1).ToString();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			updateZoomInfo();
		}

		private void vsbPageAdjuster_Scroll(object sender, ScrollEventArgs e)
		{
			if (!myRenderingFinished) return;
			this.ppcMain.StartPage = e.NewValue-1;
		}

		private void vsbPageAdjuster_ValueChanged(object sender, EventArgs e)
		{
			if (!myRenderingFinished) return;
			if (this.ppcMain.StartPage != (vsbPageAdjuster.Value-1))
				this.ppcMain.StartPage = vsbPageAdjuster.Value-1;
		}

		void frmPreview_MouseWheel(object sender, MouseEventArgs e)
		{
			int locPage = this.ppcMain.StartPage+1;
			locPage += Math.Sign(e.Delta) * -1;
			if (locPage < 1) locPage = 1;
			if (locPage > myDocument.TotalPages) locPage = myDocument.TotalPages;
			vsbPageAdjuster.Value = locPage;
		}

		void ppcMain_StartPageChanged(object sender, EventArgs e)
		{
			if (!myRenderingFinished) return;
			updatePageInfo();
		}

		private void tsmZoomAuto_Click(object sender, EventArgs e)
		{
			if (!myRenderingFinished) return;
			if (tsmZoomAuto.Checked)
				return;

			myLastMenu.Checked = false;
			tsmZoomAuto.Checked = true;
			myLastMenu = tsmZoomAuto;
			ppcMain.AutoZoom = true;
			vsbPageAdjuster.Visible = true;
			updateZoomInfo();
		}

		private void tsmZoomxxx_Click(object sender, EventArgs e)
		{
			if (!myRenderingFinished) return;
			if (((ToolStripMenuItem)sender).Checked)
				return;

			myLastMenu.Checked = false;
			((ToolStripMenuItem)sender).Checked = true;
			ppcMain.AutoZoom = false;
			ppcMain.Zoom = double.Parse(((ToolStripMenuItem)sender).Tag.ToString())/100;
			vsbPageAdjuster.Visible = false;
			myLastMenu = (ToolStripMenuItem)sender;
			updateZoomInfo();
		}

        private void tsbZoom_Click(object sender, EventArgs e)
        {
            if (!myRenderingFinished) return;
            if (tsmZoomAuto.Checked)
                return;

            myLastMenu.Checked = false;
            tsmZoomAuto.Checked = true;
            myLastMenu = tsmZoomAuto;
            ppcMain.AutoZoom = true;
            vsbPageAdjuster.Visible = true;
            updateZoomInfo();
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            PrintDialog locPD = new PrintDialog();
            DialogResult locDR=locPD.ShowDialog();
            if (locDR == DialogResult.Cancel)
                return;

            myDocument.PrinterSettings = locPD.PrinterSettings;
            myDocument.Print();
        }

        private void tsbPrevPage_Click(object sender, EventArgs e)
        {
            if (vsbPageAdjuster.Value > 1)
                vsbPageAdjuster.Value--;
        }

        private void tsbNextPage_Click(object sender, EventArgs e)
        {
            if (vsbPageAdjuster.Value < myDocument.TotalPages)
                vsbPageAdjuster.Value++;
                
        }

        private void ttbGotoPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                int newPage;
                if (int.TryParse(ttbGotoPage.Text, out newPage))
                {
                    if (newPage < 1) newPage = 1;
                    if (newPage > myDocument.TotalPages) newPage = myDocument.TotalPages;
                    vsbPageAdjuster.Value = newPage;
                }

                e.Handled = true;
            }

        }
	}
}