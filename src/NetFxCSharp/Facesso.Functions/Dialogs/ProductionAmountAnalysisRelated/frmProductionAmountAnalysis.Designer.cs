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
    public partial class frmProductionAmountAnalysis : frmBaseFacesso
    {
        //Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        //Wird vom Windows Form-Designer benötigt.
        private System.ComponentModel.IContainer components;
        //Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
        //Das Bearbeiten ist mit dem Windows Form-Designer möglich.
        //Das Bearbeiten mit dem Code-Editor ist nicht möglich.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tpWorkgroups = new System.Windows.Forms.TabPage();
            this.lvwWorkgroups = new Facesso.GenericControls.ucWorkGroupListView();
            this.tpCostCenters = new System.Windows.Forms.TabPage();
            this.lvwCostCenter = new Facesso.GenericControls.ucCostCenterListView();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.optGroupWorkvalues = new System.Windows.Forms.RadioButton();
            this.optGroupCostcenters = new System.Windows.Forms.RadioButton();
            this.optStandardAnalysis = new System.Windows.Forms.RadioButton();
            this.Label3 = new System.Windows.Forms.Label();
            this.DateRangePicker = new Facesso.GenericControls.ucAnalysisDateRangePicker();
            this.GroupBox2.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.tpWorkgroups.SuspendLayout();
            this.tpCostCenters.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            //
            //GroupBox2
            //
            this.GroupBox2.Controls.Add(this.TabControl1);
            this.GroupBox2.Controls.Add(this.btnDeselectAll);
            this.GroupBox2.Controls.Add(this.btnSelectAll);
            this.GroupBox2.Location = new System.Drawing.Point(393, 14);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(454, 338);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            //
            //TabControl1
            //
            this.TabControl1.Controls.Add(this.tpWorkgroups);
            this.TabControl1.Controls.Add(this.tpCostCenters);
            this.TabControl1.Location = new System.Drawing.Point(11, 16);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(427, 288);
            this.TabControl1.TabIndex = 3;
            //
            //tpWorkgroups
            //
            this.tpWorkgroups.Controls.Add(this.lvwWorkgroups);
            this.tpWorkgroups.Location = new System.Drawing.Point(4, 22);
            this.tpWorkgroups.Name = "tpWorkgroups";
            this.tpWorkgroups.Padding = new System.Windows.Forms.Padding(3);
            this.tpWorkgroups.Size = new System.Drawing.Size(419, 262);
            this.tpWorkgroups.TabIndex = 0;
            this.tpWorkgroups.Text = "Produktiv-Sites";
            this.tpWorkgroups.UseVisualStyleBackColor = true;
            //
            //lvwWorkgroups
            //
            this.lvwWorkgroups.AutoGroup = true;
            this.lvwWorkgroups.FullRowSelect = true;
            this.lvwWorkgroups.HideSelection = false;
            this.lvwWorkgroups.Location = new System.Drawing.Point(6, 6);
            this.lvwWorkgroups.Name = "lvwWorkgroups";
            this.lvwWorkgroups.OnlyActiveWorkgroups = true;
            this.lvwWorkgroups.Size = new System.Drawing.Size(407, 250);
            this.lvwWorkgroups.TabIndex = 1;
            this.lvwWorkgroups.UseCompatibleStateImageBehavior = false;
            this.lvwWorkgroups.View = System.Windows.Forms.View.Details;
            this.lvwWorkgroups.WorkGroupInfoItems = null;
            this.lvwWorkgroups.WorkGroupSortOrder = Facesso.GenericControls.WorkGroupSortOrder.WorkGroupNumber;
            //
            //tpCostCenters
            //
            this.tpCostCenters.Controls.Add(this.lvwCostCenter);
            this.tpCostCenters.Location = new System.Drawing.Point(4, 22);
            this.tpCostCenters.Name = "tpCostCenters";
            this.tpCostCenters.Padding = new System.Windows.Forms.Padding(3);
            this.tpCostCenters.Size = new System.Drawing.Size(419, 262);
            this.tpCostCenters.TabIndex = 1;
            this.tpCostCenters.Text = "Kostenstellen";
            this.tpCostCenters.UseVisualStyleBackColor = true;
            //
            //lvwCostCenter
            //
            this.lvwCostCenter.AutoGroup = true;
            this.lvwCostCenter.CostCenterInfoCollection = null;
            this.lvwCostCenter.CostCenterSortOrder = Facesso.GenericControls.CostCenterSortOrder.CostCenterNumber;
            this.lvwCostCenter.FullRowSelect = true;
            this.lvwCostCenter.HideSelection = false;
            this.lvwCostCenter.Location = new System.Drawing.Point(6, 6);
            this.lvwCostCenter.Name = "lvwCostCenter";
            this.lvwCostCenter.Size = new System.Drawing.Size(407, 250);
            this.lvwCostCenter.TabIndex = 0;
            this.lvwCostCenter.UseCompatibleStateImageBehavior = false;
            this.lvwCostCenter.View = System.Windows.Forms.View.Details;
            //
            //btnDeselectAll
            //
            this.btnDeselectAll.Location = new System.Drawing.Point(178, 313);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(179, 21);
            this.btnDeselectAll.TabIndex = 2;
            this.btnDeselectAll.Text = "Alle Produktiv-Sites deselektieren";
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            //
            //btnSelectAll
            //
            this.btnSelectAll.Location = new System.Drawing.Point(6, 313);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(166, 21);
            this.btnSelectAll.TabIndex = 1;
            this.btnSelectAll.Text = "Alle Produktiv-Sites markieren";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            //
            //btnPreview
            //
            this.btnPreview.Location = new System.Drawing.Point(393, 454);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(103, 27);
            this.btnPreview.TabIndex = 2;
            this.btnPreview.Text = "Vorschau...";
            this.btnPreview.UseVisualStyleBackColor = true;
            //
            //btnPrint
            //
            this.btnPrint.Location = new System.Drawing.Point(502, 454);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(103, 27);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Drucken...";
            this.btnPrint.UseVisualStyleBackColor = true;
            //
            //btnExport
            //
            this.btnExport.Location = new System.Drawing.Point(611, 454);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(103, 27);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export...";
            this.btnExport.UseVisualStyleBackColor = true;
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(730, 454);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(117, 27);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //GroupBox1
            //
            this.GroupBox1.Controls.Add(this.lblPass);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.ProgressBar1);
            this.GroupBox1.Location = new System.Drawing.Point(396, 360);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(450, 88);
            this.GroupBox1.TabIndex = 9;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Berechnungsstatus:";
            //
            //lblPass
            //
            this.lblPass.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblPass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPass.Location = new System.Drawing.Point(5, 23);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(440, 21);
            this.lblPass.TabIndex = 10;
            this.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //Label4
            //
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(3, 56);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(116, 13);
            this.Label4.TabIndex = 9;
            this.Label4.Text = "Berechnungsfortschritt:";
            //
            //ProgressBar1
            //
            this.ProgressBar1.Location = new System.Drawing.Point(130, 52);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(315, 22);
            this.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar1.TabIndex = 8;
            //
            //GroupBox3
            //
            this.GroupBox3.Controls.Add(this.optGroupWorkvalues);
            this.GroupBox3.Controls.Add(this.optGroupCostcenters);
            this.GroupBox3.Controls.Add(this.optStandardAnalysis);
            this.GroupBox3.Controls.Add(this.Label3);
            this.GroupBox3.Location = new System.Drawing.Point(10, 359);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(373, 125);
            this.GroupBox3.TabIndex = 10;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Auswertungstyp";
            //
            //optGroupWorkvalues
            //
            this.optGroupWorkvalues.AutoSize = true;
            this.optGroupWorkvalues.Location = new System.Drawing.Point(9, 97);
            this.optGroupWorkvalues.Name = "optGroupWorkvalues";
            this.optGroupWorkvalues.Size = new System.Drawing.Size(164, 17);
            this.optGroupWorkvalues.TabIndex = 7;
            this.optGroupWorkvalues.TabStop = true;
            this.optGroupWorkvalues.Text = "Arbeitswertzusammenfassung";
            this.optGroupWorkvalues.UseVisualStyleBackColor = true;
            //
            //optGroupCostcenters
            //
            this.optGroupCostcenters.AutoSize = true;
            this.optGroupCostcenters.Location = new System.Drawing.Point(9, 42);
            this.optGroupCostcenters.Name = "optGroupCostcenters";
            this.optGroupCostcenters.Size = new System.Drawing.Size(175, 17);
            this.optGroupCostcenters.TabIndex = 6;
            this.optGroupCostcenters.TabStop = true;
            this.optGroupCostcenters.Text = "Kostenstellenzusammenfassung";
            this.optGroupCostcenters.UseVisualStyleBackColor = true;
            //
            //optStandardAnalysis
            //
            this.optStandardAnalysis.AutoSize = true;
            this.optStandardAnalysis.Checked = true;
            this.optStandardAnalysis.Location = new System.Drawing.Point(9, 19);
            this.optStandardAnalysis.Name = "optStandardAnalysis";
            this.optStandardAnalysis.Size = new System.Drawing.Size(329, 17);
            this.optStandardAnalysis.TabIndex = 5;
            this.optStandardAnalysis.TabStop = true;
            this.optStandardAnalysis.Text = "Standardauswertung (pro ausgewählte Produktiv-Site eine Seite)";
            this.optStandardAnalysis.UseVisualStyleBackColor = true;
            //
            //Label3
            //
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label3.Location = new System.Drawing.Point(27, 60);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(322, 28);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Wichtig: Die Maßeinheiten der Arbeitswerte gleicher Kostenstellen müssen einheitl" + "ich sein, es findet keine Überprüfung statt.";
            //
            //DateRangePicker
            //
            this.DateRangePicker.LastWorkingday = Facesso.Data.LastWorkingdays.Friday;
            this.DateRangePicker.Location = new System.Drawing.Point(9, 14);
            this.DateRangePicker.Name = "DateRangePicker";
            this.DateRangePicker.Size = new System.Drawing.Size(378, 344);
            this.DateRangePicker.TabIndex = 8;
            //
            //frmProductionAmountAnalysis
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 496);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.DateRangePicker);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.GroupBox2);
            this.Name = "frmProductionAmountAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Produktionsergebnis-Analyse";
            this.GroupBox2.ResumeLayout(false);
            this.TabControl1.ResumeLayout(false);
            this.tpWorkgroups.ResumeLayout(false);
            this.tpCostCenters.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.Button _btnPreview;
        internal System.Windows.Forms.Button btnPreview
        {
            get
            {
                return _btnPreview;
            }

            set
            {
                if (_btnPreview != null)
                {
                    _btnPreview.Click -= btnPreview_Click;
                }

                _btnPreview = value;
                if (_btnPreview != null)
                {
                    _btnPreview.Click += btnPreview_Click;
                }
            }
        }

        private System.Windows.Forms.Button _btnPrint;
        internal System.Windows.Forms.Button btnPrint
        {
            get
            {
                return _btnPrint;
            }

            set
            {
                if (_btnPrint != null)
                {
                    _btnPrint.Click -= btnPrint_Click;
                }

                _btnPrint = value;
                if (_btnPrint != null)
                {
                    _btnPrint.Click += btnPrint_Click;
                }
            }
        }

        private System.Windows.Forms.Button _btnExport;
        internal System.Windows.Forms.Button btnExport
        {
            get
            {
                return _btnExport;
            }

            set
            {
                if (_btnExport != null)
                {
                    _btnExport.Click -= btnExport_Click;
                }

                _btnExport = value;
                if (_btnExport != null)
                {
                    _btnExport.Click += btnExport_Click;
                }
            }
        }

        private System.Windows.Forms.Button _btnOK;
        internal System.Windows.Forms.Button btnOK
        {
            get
            {
                return _btnOK;
            }

            set
            {
                if (_btnOK != null)
                {
                    _btnOK.Click -= btnOK_Click;
                }

                _btnOK = value;
                if (_btnOK != null)
                {
                    _btnOK.Click += btnOK_Click;
                }
            }
        }

        internal Facesso.GenericControls.ucAnalysisDateRangePicker DateRangePicker;
        private System.Windows.Forms.Button _btnSelectAll;
        internal System.Windows.Forms.Button btnSelectAll
        {
            get
            {
                return _btnSelectAll;
            }

            set
            {
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click -= btnSelectAll_Click;
                }

                _btnSelectAll = value;
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click += btnSelectAll_Click;
                }
            }
        }

        private System.Windows.Forms.Button _btnDeselectAll;
        internal System.Windows.Forms.Button btnDeselectAll
        {
            get
            {
                return _btnDeselectAll;
            }

            set
            {
                if (_btnDeselectAll != null)
                {
                    _btnDeselectAll.Click -= btnDeselectAll_Click;
                }

                _btnDeselectAll = value;
                if (_btnDeselectAll != null)
                {
                    _btnDeselectAll.Click += btnDeselectAll_Click;
                }
            }
        }

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ProgressBar ProgressBar1;
        internal System.Windows.Forms.Label lblPass;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.RadioButton optGroupWorkvalues;
        private System.Windows.Forms.RadioButton _optGroupCostcenters;
        internal System.Windows.Forms.RadioButton optGroupCostcenters
        {
            get
            {
                return _optGroupCostcenters;
            }

            set
            {
                if (_optGroupCostcenters != null)
                {
                    _optGroupCostcenters.CheckedChanged -= optGroupCostcenters_CheckedChanged;
                }

                _optGroupCostcenters = value;
                if (_optGroupCostcenters != null)
                {
                    _optGroupCostcenters.CheckedChanged += optGroupCostcenters_CheckedChanged;
                }
            }
        }

        internal System.Windows.Forms.RadioButton optStandardAnalysis;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TabControl _TabControl1;
        internal System.Windows.Forms.TabControl TabControl1
        {
            get
            {
                return _TabControl1;
            }

            set
            {
                if (_TabControl1 != null)
                {
                    _TabControl1.Selected -= TabControl1_Selected;
                }

                _TabControl1 = value;
                if (_TabControl1 != null)
                {
                    _TabControl1.Selected += TabControl1_Selected;
                }
            }
        }

        internal System.Windows.Forms.TabPage tpWorkgroups;
        internal Facesso.GenericControls.ucWorkGroupListView lvwWorkgroups;
        internal System.Windows.Forms.TabPage tpCostCenters;
        internal Facesso.GenericControls.ucCostCenterListView lvwCostCenter;
    }
}