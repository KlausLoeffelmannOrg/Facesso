namespace ActiveDev.Printing
{

	partial class frmPreview
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreview));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslTotalPages = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslPrintedBy = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslPrintDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbPrintSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbZoom = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmZoom500 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom250 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom200 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom075 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom050 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom033 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom025 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoomAuto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ttbZoom = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrevPage = new System.Windows.Forms.ToolStripButton();
            this.tsbNextPage = new System.Windows.Forms.ToolStripButton();
            this.tslGoto = new System.Windows.Forms.ToolStripLabel();
            this.ttbGotoPage = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.ppcMain = new System.Windows.Forms.PrintPreviewControl();
            this.vsbPageAdjuster = new System.Windows.Forms.VScrollBar();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslTotalPages,
            this.tslPrintedBy,
            this.tslPrintDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 547);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(569, 24);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslTotalPages
            // 
            this.tslTotalPages.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslTotalPages.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tslTotalPages.Name = "tslTotalPages";
            this.tslTotalPages.Size = new System.Drawing.Size(184, 19);
            this.tslTotalPages.Spring = true;
            this.tslTotalPages.Text = "Seite xxx von xxx";
            // 
            // tslPrintedBy
            // 
            this.tslPrintedBy.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslPrintedBy.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tslPrintedBy.Name = "tslPrintedBy";
            this.tslPrintedBy.Size = new System.Drawing.Size(184, 19);
            this.tslPrintedBy.Spring = true;
            this.tslPrintedBy.Text = "Gedruckt von: Administrator";
            // 
            // tslPrintDate
            // 
            this.tslPrintDate.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslPrintDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tslPrintDate.Name = "tslPrintDate";
            this.tslPrintDate.Size = new System.Drawing.Size(184, 19);
            this.tslPrintDate.Spring = true;
            this.tslPrintDate.Text = "Druckdatum: Montag, 01.01.2005";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPrint,
            this.tsbPrintSettings,
            this.toolStripSeparator1,
            this.tsbZoom,
            this.toolStripLabel1,
            this.ttbZoom,
            this.toolStripSeparator2,
            this.tsbPrevPage,
            this.tsbNextPage,
            this.tslGoto,
            this.ttbGotoPage,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(569, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(23, 22);
            this.tsbPrint.Text = "Drucken";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // tsbPrintSettings
            // 
            this.tsbPrintSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrintSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrintSettings.Image")));
            this.tsbPrintSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrintSettings.Name = "tsbPrintSettings";
            this.tsbPrintSettings.Size = new System.Drawing.Size(23, 22);
            this.tsbPrintSettings.Text = "Druckereinstellungen";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbZoom
            // 
            this.tsbZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmZoom500,
            this.tsmZoom250,
            this.tsmZoom200,
            this.tsmZoom100,
            this.tsmZoom075,
            this.tsmZoom050,
            this.tsmZoom033,
            this.tsmZoom025,
            this.tsmZoomAuto});
            this.tsbZoom.Image = ((System.Drawing.Image)(resources.GetObject("tsbZoom.Image")));
            this.tsbZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoom.Name = "tsbZoom";
            this.tsbZoom.Size = new System.Drawing.Size(29, 22);
            this.tsbZoom.Text = "Zoom-Einstellungen";
            this.tsbZoom.Click += new System.EventHandler(this.tsbZoom_Click);
            // 
            // tsmZoom500
            // 
            this.tsmZoom500.Name = "tsmZoom500";
            this.tsmZoom500.Size = new System.Drawing.Size(105, 22);
            this.tsmZoom500.Tag = "500";
            this.tsmZoom500.Text = "500 %";
            this.tsmZoom500.Click += new System.EventHandler(this.tsmZoomxxx_Click);
            // 
            // tsmZoom250
            // 
            this.tsmZoom250.Name = "tsmZoom250";
            this.tsmZoom250.Size = new System.Drawing.Size(105, 22);
            this.tsmZoom250.Tag = "250";
            this.tsmZoom250.Text = "250 %";
            this.tsmZoom250.Click += new System.EventHandler(this.tsmZoomxxx_Click);
            // 
            // tsmZoom200
            // 
            this.tsmZoom200.Name = "tsmZoom200";
            this.tsmZoom200.Size = new System.Drawing.Size(105, 22);
            this.tsmZoom200.Tag = "200";
            this.tsmZoom200.Text = "200 %";
            this.tsmZoom200.Click += new System.EventHandler(this.tsmZoomxxx_Click);
            // 
            // tsmZoom100
            // 
            this.tsmZoom100.Name = "tsmZoom100";
            this.tsmZoom100.Size = new System.Drawing.Size(105, 22);
            this.tsmZoom100.Tag = "100";
            this.tsmZoom100.Text = "100 %";
            this.tsmZoom100.Click += new System.EventHandler(this.tsmZoomxxx_Click);
            // 
            // tsmZoom075
            // 
            this.tsmZoom075.Name = "tsmZoom075";
            this.tsmZoom075.Size = new System.Drawing.Size(105, 22);
            this.tsmZoom075.Tag = "75";
            this.tsmZoom075.Text = "75 %";
            this.tsmZoom075.Click += new System.EventHandler(this.tsmZoomxxx_Click);
            // 
            // tsmZoom050
            // 
            this.tsmZoom050.Name = "tsmZoom050";
            this.tsmZoom050.Size = new System.Drawing.Size(105, 22);
            this.tsmZoom050.Tag = "50";
            this.tsmZoom050.Text = "50 %";
            this.tsmZoom050.Click += new System.EventHandler(this.tsmZoomxxx_Click);
            // 
            // tsmZoom033
            // 
            this.tsmZoom033.Name = "tsmZoom033";
            this.tsmZoom033.Size = new System.Drawing.Size(105, 22);
            this.tsmZoom033.Tag = "33";
            this.tsmZoom033.Text = "33 %";
            this.tsmZoom033.Click += new System.EventHandler(this.tsmZoomxxx_Click);
            // 
            // tsmZoom025
            // 
            this.tsmZoom025.Name = "tsmZoom025";
            this.tsmZoom025.Size = new System.Drawing.Size(105, 22);
            this.tsmZoom025.Tag = "25";
            this.tsmZoom025.Text = "25 %";
            this.tsmZoom025.Click += new System.EventHandler(this.tsmZoomxxx_Click);
            // 
            // tsmZoomAuto
            // 
            this.tsmZoomAuto.Checked = true;
            this.tsmZoomAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmZoomAuto.Name = "tsmZoomAuto";
            this.tsmZoomAuto.Size = new System.Drawing.Size(105, 22);
            this.tsmZoomAuto.Text = "Auto";
            this.tsmZoomAuto.Click += new System.EventHandler(this.tsmZoomAuto_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel1.Text = "Zoom:";
            // 
            // ttbZoom
            // 
            this.ttbZoom.AcceptsReturn = true;
            this.ttbZoom.MaxLength = 3;
            this.ttbZoom.Name = "ttbZoom";
            this.ttbZoom.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbPrevPage
            // 
            this.tsbPrevPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrevPage.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrevPage.Image")));
            this.tsbPrevPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrevPage.Name = "tsbPrevPage";
            this.tsbPrevPage.Size = new System.Drawing.Size(23, 22);
            this.tsbPrevPage.Text = "Vorherige Seite";
            this.tsbPrevPage.Click += new System.EventHandler(this.tsbPrevPage_Click);
            // 
            // tsbNextPage
            // 
            this.tsbNextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNextPage.Image = ((System.Drawing.Image)(resources.GetObject("tsbNextPage.Image")));
            this.tsbNextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNextPage.Name = "tsbNextPage";
            this.tsbNextPage.Size = new System.Drawing.Size(23, 22);
            this.tsbNextPage.Text = "Nächste Seite";
            this.tsbNextPage.Click += new System.EventHandler(this.tsbNextPage_Click);
            // 
            // tslGoto
            // 
            this.tslGoto.Name = "tslGoto";
            this.tslGoto.Size = new System.Drawing.Size(81, 22);
            this.tslGoto.Text = "Aktuelle Seite:";
            // 
            // ttbGotoPage
            // 
            this.ttbGotoPage.MaxLength = 5;
            this.ttbGotoPage.Name = "ttbGotoPage";
            this.ttbGotoPage.Size = new System.Drawing.Size(100, 25);
            this.ttbGotoPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ttbGotoPage_KeyPress);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // ppcMain
            // 
            this.ppcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppcMain.Location = new System.Drawing.Point(0, 25);
            this.ppcMain.Name = "ppcMain";
            this.ppcMain.Size = new System.Drawing.Size(552, 522);
            this.ppcMain.TabIndex = 2;
            // 
            // vsbPageAdjuster
            // 
            this.vsbPageAdjuster.Dock = System.Windows.Forms.DockStyle.Right;
            this.vsbPageAdjuster.Location = new System.Drawing.Point(552, 25);
            this.vsbPageAdjuster.Name = "vsbPageAdjuster";
            this.vsbPageAdjuster.Size = new System.Drawing.Size(17, 522);
            this.vsbPageAdjuster.TabIndex = 3;
            this.vsbPageAdjuster.ValueChanged += new System.EventHandler(this.vsbPageAdjuster_ValueChanged);
            this.vsbPageAdjuster.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsbPageAdjuster_Scroll);
            // 
            // frmPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 571);
            this.Controls.Add(this.ppcMain);
            this.Controls.Add(this.vsbPageAdjuster);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmPreview";
            this.Text = "Druckvorschau";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.PrintPreviewControl ppcMain;
		private System.Windows.Forms.ToolStripDropDownButton tsbZoom;
		private System.Windows.Forms.ToolStripMenuItem tsmZoom500;
		private System.Windows.Forms.ToolStripMenuItem tsmZoom250;
		private System.Windows.Forms.ToolStripMenuItem tsmZoom200;
		private System.Windows.Forms.ToolStripMenuItem tsmZoom100;
		private System.Windows.Forms.ToolStripMenuItem tsmZoom075;
		private System.Windows.Forms.ToolStripMenuItem tsmZoom050;
		private System.Windows.Forms.ToolStripMenuItem tsmZoom033;
		private System.Windows.Forms.ToolStripMenuItem tsmZoom025;
		private System.Windows.Forms.ToolStripMenuItem tsmZoomAuto;
		private System.Windows.Forms.ToolStripButton tsbPrint;
		private System.Windows.Forms.ToolStripButton tsbPrintSettings;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox ttbZoom;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbPrevPage;
		private System.Windows.Forms.ToolStripButton tsbNextPage;
		private System.Windows.Forms.ToolStripLabel tslGoto;
		private System.Windows.Forms.ToolStripTextBox ttbGotoPage;
		private System.Windows.Forms.ToolStripStatusLabel tslTotalPages;
		private System.Windows.Forms.ToolStripStatusLabel tslPrintedBy;
		private System.Windows.Forms.ToolStripStatusLabel tslPrintDate;
		private System.Windows.Forms.VScrollBar vsbPageAdjuster;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
	}
}