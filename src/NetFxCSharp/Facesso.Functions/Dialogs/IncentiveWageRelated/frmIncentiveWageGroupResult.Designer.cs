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
    internal partial class frmIncentiveWageGroupResult : frmBaseFacesso
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
            this.dgvEmployeeWages = new System.Windows.Forms.DataGridView();
            this.dgvEmployeeWages.ColumnHeaderMouseClick += dgvEmployeeWages_ColumnHeaderMouseClick;
            this.lblIncentiveWageForMonth = new System.Windows.Forms.Label();
            this.lblIncentiveWageSum = new System.Windows.Forms.Label();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.DateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPrintWageList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPrintWageList.Click += tsmPrintWageList_Click;
            this.tsmPrintEmployeeWagesDetailed = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPrintEmployeeWagesDetailed.Click += tsmPrintEmployeeWagesDetailed_Click;
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.TsmCsvExport = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmCsvExport.Click += TsmCsvExport_Click;
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuit.Click += tsmQuit_Click;
            this.BearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmSelectWithIncentiveWage = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmSelectWithIncentiveWage.Click += TsmSelectWithIncentiveWage_Click;
            this.tsmSelectWithData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSelectWithData.Click += tsmSelectWithData_Click;
            this.tsmSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSelectAll.Click += tsmSelectAll_Click;
            this.tsmDeselectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeselectAll.Click += tsmDeselectAll_Click;
            this.SortierungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSortPersonellNo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSortAlphabetically = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSortDegreeOfTime = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)this.dgvEmployeeWages).BeginInit();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            //dgvEmployeeWages
            //
            this.dgvEmployeeWages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.dgvEmployeeWages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeWages.Location = new System.Drawing.Point(5, 32);
            this.dgvEmployeeWages.Name = "dgvEmployeeWages";
            this.dgvEmployeeWages.Size = new System.Drawing.Size(708, 352);
            this.dgvEmployeeWages.TabIndex = 0;
            //
            //lblIncentiveWageForMonth
            //
            this.lblIncentiveWageForMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.lblIncentiveWageForMonth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIncentiveWageForMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblIncentiveWageForMonth.Location = new System.Drawing.Point(5, 388);
            this.lblIncentiveWageForMonth.Name = "lblIncentiveWageForMonth";
            this.lblIncentiveWageForMonth.Size = new System.Drawing.Size(528, 28);
            this.lblIncentiveWageForMonth.TabIndex = 8;
            this.lblIncentiveWageForMonth.Text = "Anfallende Gesamtpr�mien im Monat";
            this.lblIncentiveWageForMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            //lblIncentiveWageSum
            //
            this.lblIncentiveWageSum.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.lblIncentiveWageSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIncentiveWageSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblIncentiveWageSum.Location = new System.Drawing.Point(535, 388);
            this.lblIncentiveWageSum.Name = "lblIncentiveWageSum";
            this.lblIncentiveWageSum.Size = new System.Drawing.Size(179, 28);
            this.lblIncentiveWageSum.TabIndex = 9;
            this.lblIncentiveWageSum.Text = "0,00 �";
            this.lblIncentiveWageSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //MenuStrip1
            //
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.DateiToolStripMenuItem, this.BearbeitenToolStripMenuItem, this.SortierungToolStripMenuItem });
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(719, 24);
            this.MenuStrip1.TabIndex = 12;
            this.MenuStrip1.Text = "MenuStrip1";
            //
            //DateiToolStripMenuItem
            //
            this.DateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmPrintWageList, this.tsmPrintEmployeeWagesDetailed, this.ToolStripMenuItem1, this.TsmCsvExport, this.ToolStripMenuItem2, this.tsmQuit });
            this.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem";
            this.DateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.DateiToolStripMenuItem.Text = "&Datei";
            //
            //tsmPrintWageList
            //
            this.tsmPrintWageList.Name = "tsmPrintWageList";
            this.tsmPrintWageList.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D));
            this.tsmPrintWageList.Size = new System.Drawing.Size(360, 22);
            this.tsmPrintWageList.Text = "&Lohnliste drucken...";
            //
            //tsmPrintEmployeeWagesDetailed
            //
            this.tsmPrintEmployeeWagesDetailed.Name = "tsmPrintEmployeeWagesDetailed";
            this.tsmPrintEmployeeWagesDetailed.Size = new System.Drawing.Size(360, 22);
            this.tsmPrintEmployeeWagesDetailed.Text = "Tageseinzelaufstellung der &Mitarbeiterl�hne drucken...";
            //
            //ToolStripMenuItem1
            //
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(357, 6);
            //
            //TsmCsvExport
            //
            this.TsmCsvExport.Name = "TsmCsvExport";
            this.TsmCsvExport.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            this.TsmCsvExport.Size = new System.Drawing.Size(360, 22);
            this.TsmCsvExport.Text = "CSV-&Export (f�r Excel)...";
            //
            //ToolStripMenuItem2
            //
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(357, 6);
            //
            //tsmQuit
            //
            this.tsmQuit.Name = "tsmQuit";
            this.tsmQuit.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4));
            this.tsmQuit.Size = new System.Drawing.Size(360, 22);
            this.tsmQuit.Text = "Berechnungsdialog &verlassen";
            //
            //BearbeitenToolStripMenuItem
            //
            this.BearbeitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.TsmSelectWithIncentiveWage, this.tsmSelectWithData, this.tsmSelectAll, this.tsmDeselectAll });
            this.BearbeitenToolStripMenuItem.Name = "BearbeitenToolStripMenuItem";
            this.BearbeitenToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.BearbeitenToolStripMenuItem.Text = "&Bearbeiten";
            //
            //TsmSelectWithIncentiveWage
            //
            this.TsmSelectWithIncentiveWage.Name = "TsmSelectWithIncentiveWage";
            this.TsmSelectWithIncentiveWage.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.TsmSelectWithIncentiveWage.Size = new System.Drawing.Size(337, 22);
            this.TsmSelectWithIncentiveWage.Text = "Alle Mitarbeiter mit Pr�mie selektieren";
            //
            //tsmSelectWithData
            //
            this.tsmSelectWithData.Name = "tsmSelectWithData";
            this.tsmSelectWithData.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L));
            this.tsmSelectWithData.Size = new System.Drawing.Size(337, 22);
            this.tsmSelectWithData.Text = "Alle Mitarbeiter mit Lohndaten selektieren";
            //
            //tsmSelectAll
            //
            this.tsmSelectAll.Name = "tsmSelectAll";
            this.tsmSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A));
            this.tsmSelectAll.Size = new System.Drawing.Size(337, 22);
            this.tsmSelectAll.Text = "Alle Mitarbeiter selektieren";
            //
            //tsmDeselectAll
            //
            this.tsmDeselectAll.Name = "tsmDeselectAll";
            this.tsmDeselectAll.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.tsmDeselectAll.Size = new System.Drawing.Size(337, 22);
            this.tsmDeselectAll.Text = "Selektierung aufheben";
            //
            //SortierungToolStripMenuItem
            //
            this.SortierungToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmSortPersonellNo, this.tsmSortAlphabetically, this.tsmSortDegreeOfTime });
            this.SortierungToolStripMenuItem.Name = "SortierungToolStripMenuItem";
            this.SortierungToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.SortierungToolStripMenuItem.Text = "&Sortierung";
            this.SortierungToolStripMenuItem.Visible = false;
            //
            //tsmSortPersonellNo
            //
            this.tsmSortPersonellNo.Name = "tsmSortPersonellNo";
            this.tsmSortPersonellNo.Size = new System.Drawing.Size(196, 22);
            this.tsmSortPersonellNo.Text = "Nach Personalnummer";
            //
            //tsmSortAlphabetically
            //
            this.tsmSortAlphabetically.Name = "tsmSortAlphabetically";
            this.tsmSortAlphabetically.Size = new System.Drawing.Size(196, 22);
            this.tsmSortAlphabetically.Text = "Alphabetisch";
            //
            //tsmSortDegreeOfTime
            //
            this.tsmSortDegreeOfTime.Name = "tsmSortDegreeOfTime";
            this.tsmSortDegreeOfTime.Size = new System.Drawing.Size(196, 22);
            this.tsmSortDegreeOfTime.Text = "Nach Zeitgrad";
            //
            //frmIncentiveWageGroupResult
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 428);
            this.Controls.Add(this.lblIncentiveWageSum);
            this.Controls.Add(this.lblIncentiveWageForMonth);
            this.Controls.Add(this.dgvEmployeeWages);
            this.Controls.Add(this.MenuStrip1);
            this.MainMenuStrip = this.MenuStrip1;
            this.MinimumSize = new System.Drawing.Size(727, 462);
            this.Name = "frmIncentiveWageGroupResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pr�mienlohnberechnung";
            ((System.ComponentModel.ISupportInitialize)this.dgvEmployeeWages).EndInit();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.DataGridView dgvEmployeeWages;

        internal System.Windows.Forms.Label lblIncentiveWageForMonth;
        internal System.Windows.Forms.Label lblIncentiveWageSum;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem DateiToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem tsmPrintWageList;

        internal System.Windows.Forms.ToolStripMenuItem tsmPrintEmployeeWagesDetailed;

        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem TsmCsvExport;

        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem2;
        internal System.Windows.Forms.ToolStripMenuItem tsmQuit;

        internal System.Windows.Forms.ToolStripMenuItem BearbeitenToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem TsmSelectWithIncentiveWage;

        internal System.Windows.Forms.ToolStripMenuItem tsmSelectWithData;

        internal System.Windows.Forms.ToolStripMenuItem tsmSelectAll;

        internal System.Windows.Forms.ToolStripMenuItem tsmDeselectAll;

        internal System.Windows.Forms.ToolStripMenuItem SortierungToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem tsmSortPersonellNo;
        internal System.Windows.Forms.ToolStripMenuItem tsmSortAlphabetically;
        internal System.Windows.Forms.ToolStripMenuItem tsmSortDegreeOfTime;
    }
}