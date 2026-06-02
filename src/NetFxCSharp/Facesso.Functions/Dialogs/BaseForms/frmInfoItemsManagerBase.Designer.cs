using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public partial class frmInfoItemsManagerBase : frmBaseFacesso
    {
        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfoItemsManagerBase));
            this.ToolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.arvInfoItems = new ActiveDev.ADAutoReportView();
            this.MenuStripMainMenu = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFromXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ItemAddToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ItemEditToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ItemDeleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ItemPrintToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemXmlExportStripButton = new System.Windows.Forms.ToolStripButton();
            this.ItemXmlImportStripButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.HelpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tslCostcenters = new System.Windows.Forms.ToolStripLabel();
            this.tscCostCenters = new System.Windows.Forms.ToolStripComboBox();
            this.tsbAssignCostcenter = new System.Windows.Forms.ToolStripButton();
            this.ToolStripContainer1.ContentPanel.SuspendLayout();
            this.ToolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer1.SuspendLayout();
            this.MenuStripMainMenu.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            //ToolStripContainer1
            //
            //
            //ToolStripContainer1.ContentPanel
            //
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.arvInfoItems);
            this.ToolStripContainer1.ContentPanel.Size = new System.Drawing.Size(626, 368);
            this.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer1.Name = "ToolStripContainer1";
            this.ToolStripContainer1.Size = new System.Drawing.Size(626, 417);
            this.ToolStripContainer1.TabIndex = 0;
            this.ToolStripContainer1.Text = "ToolStripContainer1";
            //
            //ToolStripContainer1.TopToolStripPanel
            //
            this.ToolStripContainer1.TopToolStripPanel.Controls.Add(this.MenuStripMainMenu);
            this.ToolStripContainer1.TopToolStripPanel.Controls.Add(this.ToolStrip1);
            //
            //arvInfoItems
            //
            this.arvInfoItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arvInfoItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.arvInfoItems.FullRowSelect = true;
            this.arvInfoItems.GridLines = true;
            this.arvInfoItems.HideSelection = false;
            this.arvInfoItems.List = null;
            this.arvInfoItems.ListViewMode = ActiveDev.AutoReportMode.Details;
            this.arvInfoItems.Location = new System.Drawing.Point(0, 0);
            this.arvInfoItems.Name = "arvInfoItems";
            this.arvInfoItems.Size = new System.Drawing.Size(626, 368);
            this.arvInfoItems.TabIndex = 0;
            this.arvInfoItems.UseCompatibleStateImageBehavior = false;
            this.arvInfoItems.View = System.Windows.Forms.View.Details;
            //
            //MenuStripMainMenu
            //
            this.MenuStripMainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuStripMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.FileToolStripMenuItem, this.EditToolStripMenuItem, this.OKToolStripMenuItem });
            this.MenuStripMainMenu.Location = new System.Drawing.Point(0, 0);
            this.MenuStripMainMenu.Name = "MenuStripMainMenu";
            this.MenuStripMainMenu.Size = new System.Drawing.Size(626, 24);
            this.MenuStripMainMenu.TabIndex = 0;
            this.MenuStripMainMenu.Text = "MenuStrip1";
            //
            //FileToolStripMenuItem
            //
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ExportToXmlToolStripMenuItem, this.ImportFromXmlToolStripMenuItem, this.ToolStripSeparator1, this.PrintToolStripMenuItem });
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.FileToolStripMenuItem.Text = "&Datei";
            //
            //ExportToXmlToolStripMenuItem
            //
            this.ExportToXmlToolStripMenuItem.Name = "ExportToXmlToolStripMenuItem";
            this.ExportToXmlToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ExportToXmlToolStripMenuItem.Text = "&Export in XML...";
            //
            //ImportFromXmlToolStripMenuItem
            //
            this.ImportFromXmlToolStripMenuItem.Name = "ImportFromXmlToolStripMenuItem";
            this.ImportFromXmlToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ImportFromXmlToolStripMenuItem.Text = "&Import von XML...";
            //
            //ToolStripSeparator1
            //
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            //
            //PrintToolStripMenuItem
            //
            this.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem";
            this.PrintToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.PrintToolStripMenuItem.Text = "Liste &drucken...";
            //
            //EditToolStripMenuItem
            //
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ItemAddToolStripMenuItem, this.ItemEditToolStripMenuItem, this.ItemDeleteToolStripMenuItem });
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.EditToolStripMenuItem.Text = "&Bearbeiten";
            //
            //ItemAddToolStripMenuItem
            //
            this.ItemAddToolStripMenuItem.Name = "ItemAddToolStripMenuItem";
            this.ItemAddToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.ItemAddToolStripMenuItem.Text = "%1 &hinzuf�gen";
            //
            //ItemEditToolStripMenuItem
            //
            this.ItemEditToolStripMenuItem.Name = "ItemEditToolStripMenuItem";
            this.ItemEditToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.ItemEditToolStripMenuItem.Text = "%1 &bearbeiten";
            //
            //ItemDeleteToolStripMenuItem
            //
            this.ItemDeleteToolStripMenuItem.Name = "ItemDeleteToolStripMenuItem";
            this.ItemDeleteToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.ItemDeleteToolStripMenuItem.Text = "%1 l�schen";
            //
            //OKToolStripMenuItem
            //
            this.OKToolStripMenuItem.Name = "OKToolStripMenuItem";
            this.OKToolStripMenuItem.Size = new System.Drawing.Size(33, 20);
            this.OKToolStripMenuItem.Text = "&OK";
            //
            //ToolStrip1
            //
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ItemAddToolStripButton, this.ItemEditToolStripButton, this.ItemDeleteToolStripButton, this.toolStripSeparator, this.ItemPrintToolStripButton, this.ToolStripSeparator3, this.ItemXmlExportStripButton, this.ItemXmlImportStripButton, this.ToolStripSeparator4, this.HelpToolStripButton, this.ToolStripSeparator5, this.tslCostcenters, this.tscCostCenters, this.tsbAssignCostcenter });
            this.ToolStrip1.Location = new System.Drawing.Point(3, 24);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(578, 25);
            this.ToolStrip1.TabIndex = 1;
            this.ToolStrip1.Text = "ToolStrip1";
            //
            //ItemAddToolStripButton
            //
            this.ItemAddToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ItemAddToolStripButton.Image = ((System.Drawing.Image)resources.GetObject("ItemAddToolStripButton.Image"));
            this.ItemAddToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ItemAddToolStripButton.Name = "ItemAddToolStripButton";
            this.ItemAddToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ItemAddToolStripButton.Text = "Neuer Datensatz";
            //
            //ItemEditToolStripButton
            //
            this.ItemEditToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ItemEditToolStripButton.Image = ((System.Drawing.Image)resources.GetObject("ItemEditToolStripButton.Image"));
            this.ItemEditToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ItemEditToolStripButton.Name = "ItemEditToolStripButton";
            this.ItemEditToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ItemEditToolStripButton.Text = "Datensatz bearbeiten";
            //
            //ItemDeleteToolStripButton
            //
            this.ItemDeleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ItemDeleteToolStripButton.Image = ((System.Drawing.Image)resources.GetObject("ItemDeleteToolStripButton.Image"));
            this.ItemDeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ItemDeleteToolStripButton.Name = "ItemDeleteToolStripButton";
            this.ItemDeleteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ItemDeleteToolStripButton.Text = "Datensatz l�schen";
            //
            //toolStripSeparator
            //
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            //
            //ItemPrintToolStripButton
            //
            this.ItemPrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ItemPrintToolStripButton.Image = ((System.Drawing.Image)resources.GetObject("ItemPrintToolStripButton.Image"));
            this.ItemPrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ItemPrintToolStripButton.Name = "ItemPrintToolStripButton";
            this.ItemPrintToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ItemPrintToolStripButton.Text = "Liste drucken";
            //
            //ToolStripSeparator3
            //
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            //
            //ItemXmlExportStripButton
            //
            this.ItemXmlExportStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ItemXmlExportStripButton.Image = ((System.Drawing.Image)resources.GetObject("ItemXmlExportStripButton.Image"));
            this.ItemXmlExportStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ItemXmlExportStripButton.Name = "ItemXmlExportStripButton";
            this.ItemXmlExportStripButton.Size = new System.Drawing.Size(23, 22);
            this.ItemXmlExportStripButton.Text = "XmlExportStripButton";
            this.ItemXmlExportStripButton.ToolTipText = "XML-Export (nur Enterprise)";
            //
            //ItemXmlImportStripButton
            //
            this.ItemXmlImportStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ItemXmlImportStripButton.Image = ((System.Drawing.Image)resources.GetObject("ItemXmlImportStripButton.Image"));
            this.ItemXmlImportStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ItemXmlImportStripButton.Name = "ItemXmlImportStripButton";
            this.ItemXmlImportStripButton.Size = new System.Drawing.Size(23, 22);
            this.ItemXmlImportStripButton.Text = "ToolStripButton2";
            this.ItemXmlImportStripButton.ToolTipText = "XML-Import (nur Enterprise)";
            //
            //ToolStripSeparator4
            //
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            //
            //HelpToolStripButton
            //
            this.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HelpToolStripButton.Image = ((System.Drawing.Image)resources.GetObject("HelpToolStripButton.Image"));
            this.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HelpToolStripButton.Name = "HelpToolStripButton";
            this.HelpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.HelpToolStripButton.Text = "He&lp";
            this.HelpToolStripButton.ToolTipText = "Hilfe";
            //
            //ToolStripSeparator5
            //
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            this.ToolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            //
            //tslCostcenters
            //
            this.tslCostcenters.Name = "tslCostcenters";
            this.tslCostcenters.Size = new System.Drawing.Size(75, 22);
            this.tslCostcenters.Text = "Kostenstellen:";
            this.tslCostcenters.ToolTipText = "Kostenstellen, die den ausgew�hlten Elementen zugeordnet werden sollen.";
            //
            //tscCostCenters
            //
            this.tscCostCenters.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.tscCostCenters.Name = "tscCostCenters";
            this.tscCostCenters.Size = new System.Drawing.Size(200, 25);
            //
            //tsbAssignCostcenter
            //
            this.tsbAssignCostcenter.Image = ((System.Drawing.Image)resources.GetObject("tsbAssignCostcenter.Image"));
            this.tsbAssignCostcenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAssignCostcenter.Name = "tsbAssignCostcenter";
            this.tsbAssignCostcenter.Size = new System.Drawing.Size(73, 22);
            this.tsbAssignCostcenter.Text = "Zuordnen";
            this.tsbAssignCostcenter.ToolTipText = "Kostenstelle zuordnen";
            //
            //frmInfoItemsManagerBase
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 417);
            this.Controls.Add(this.ToolStripContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.MainMenuStrip = this.MenuStripMainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInfoItemsManagerBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmInfoItemsManagerBase";
            this.ToolStripContainer1.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer1.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer1.ResumeLayout(false);
            this.ToolStripContainer1.PerformLayout();
            this.MenuStripMainMenu.ResumeLayout(false);
            this.MenuStripMainMenu.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.ToolStripContainer ToolStripContainer1;
        internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ExportToXmlToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ImportFromXmlToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripMenuItem PrintToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ItemAddToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ItemEditToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ItemDeleteToolStripMenuItem;
        internal System.Windows.Forms.ToolStripButton ItemAddToolStripButton;
        internal System.Windows.Forms.ToolStripButton ItemEditToolStripButton;
        internal System.Windows.Forms.ToolStripButton ItemDeleteToolStripButton;
        internal System.Windows.Forms.ToolStripButton ItemPrintToolStripButton;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        internal System.Windows.Forms.ToolStripButton HelpToolStripButton;
        internal System.Windows.Forms.ToolStripButton ItemXmlExportStripButton;
        internal System.Windows.Forms.ToolStripButton ItemXmlImportStripButton;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem _OKToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem OKToolStripMenuItem
        {
            get
            {
                return _OKToolStripMenuItem;
            }

            set
            {
                if (_OKToolStripMenuItem != null)
                {
                    _OKToolStripMenuItem.Click -= OKToolStripMenuItem_Click;
                }

                _OKToolStripMenuItem = value;
                if (_OKToolStripMenuItem != null)
                {
                    _OKToolStripMenuItem.Click += OKToolStripMenuItem_Click;
                }
            }
        }

        protected System.Windows.Forms.MenuStrip MenuStripMainMenu;
        protected System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripLabel tslCostcenters;
        internal System.Windows.Forms.ToolStripComboBox tscCostCenters;
        private ActiveDev.ADAutoReportView _arvInfoItems;
        internal ActiveDev.ADAutoReportView arvInfoItems
        {
            get
            {
                return _arvInfoItems;
            }

            set
            {
                if (_arvInfoItems != null)
                {
                    _arvInfoItems.ColumnClick -= arvInfoItems_ColumnClick;
                    _arvInfoItems.DoubleClick -= arvInfoItems_DoubleClick;
                }

                _arvInfoItems = value;
                if (_arvInfoItems != null)
                {
                    _arvInfoItems.ColumnClick += arvInfoItems_ColumnClick;
                    _arvInfoItems.DoubleClick += arvInfoItems_DoubleClick;
                }
            }
        }

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator5;
        internal System.Windows.Forms.ToolStripButton tsbAssignCostcenter;
    }
}