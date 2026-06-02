using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Interfaces
{
    public partial class frmImport : System.Windows.Forms.Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImport));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lvwTaskList = new System.Windows.Forms.ListView();
            this.lvwTaskList.SelectedIndexChanged += lvwTaskList_SelectedIndexChanged;
            this.ListViewImages = new System.Windows.Forms.ImageList(this.components);
            this.Label1 = new System.Windows.Forms.Label();
            this.btnImportNow = new System.Windows.Forms.Button();
            this.btnImportNow.Click += btnImportNow_Click;
            this.Label2 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom.ValueChanged += dtpFrom_ValueChanged;
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpTo.ValueChanged += dtpTo_ValueChanged;
            this.chkShift1 = new System.Windows.Forms.CheckBox();
            this.chkShift2 = new System.Windows.Forms.CheckBox();
            this.chkShift3 = new System.Windows.Forms.CheckBox();
            this.chkShift4 = new System.Windows.Forms.CheckBox();
            this.lblImportStatus = new System.Windows.Forms.Label();
            this.pbImportProgress = new System.Windows.Forms.ProgressBar();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.DateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFileImportImportSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFileExportShiftmodel = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmQuitDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuitDialog.Click += tsmQuitDialog_Click;
            this.BearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditNewImportTask = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditNewImportTask.Click += tsmEditNewImportTask_Click;
            this.tsmEditImportTask = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditImportTask.Click += tsmEditImportTask_Click;
            this.tsmEditDeleteImportTask = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditDeleteImportTask.Click += tsmEditDeleteImportTask_Click;
            this.btnOK = new System.Windows.Forms.Button();
            this.btnOK.Click += btnOK_Click;
            this.ucWorkGroups = new Facesso.GenericControls.ucWorkGroupListView();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSelectAll.Click += btnSelectAll_Click;
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.btnDeselectAll.Click += btnDeselectAll_Click;
            this.lblWorkgroups = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            //GroupBox1
            //
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.GroupBox1.Controls.Add(this.lvwTaskList);
            this.GroupBox1.Location = new System.Drawing.Point(11, 83);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(432, 224);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Import-Tasks: ";
            //
            //lvwTaskList
            //
            this.lvwTaskList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.lvwTaskList.FullRowSelect = true;
            this.lvwTaskList.GridLines = true;
            this.lvwTaskList.Location = new System.Drawing.Point(12, 23);
            this.lvwTaskList.Name = "lvwTaskList";
            this.lvwTaskList.Size = new System.Drawing.Size(414, 194);
            this.lvwTaskList.SmallImageList = this.ListViewImages;
            this.lvwTaskList.TabIndex = 5;
            this.lvwTaskList.UseCompatibleStateImageBehavior = false;
            this.lvwTaskList.View = System.Windows.Forms.View.Details;
            //
            //ListViewImages
            //
            this.ListViewImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)resources.GetObject("ListViewImages.ImageStream"));
            this.ListViewImages.TransparentColor = System.Drawing.Color.Transparent;
            this.ListViewImages.Images.SetKeyName(0, "CheckBox");
            this.ListViewImages.Images.SetKeyName(1, "UnCheckBox");
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(16, 36);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(28, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "von:";
            //
            //btnImportNow
            //
            this.btnImportNow.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnImportNow.Location = new System.Drawing.Point(470, 32);
            this.btnImportNow.Name = "btnImportNow";
            this.btnImportNow.Size = new System.Drawing.Size(114, 47);
            this.btnImportNow.TabIndex = 4;
            this.btnImportNow.Text = "Import starten!";
            this.btnImportNow.UseVisualStyleBackColor = true;
            //
            //Label2
            //
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(16, 62);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(23, 13);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "bis:";
            //
            //dtpFrom
            //
            this.dtpFrom.Location = new System.Drawing.Point(61, 32);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(203, 20);
            this.dtpFrom.TabIndex = 7;
            //
            //dtpTo
            //
            this.dtpTo.Location = new System.Drawing.Point(61, 58);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(203, 20);
            this.dtpTo.TabIndex = 8;
            //
            //chkShift1
            //
            this.chkShift1.AutoSize = true;
            this.chkShift1.Checked = true;
            this.chkShift1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShift1.Location = new System.Drawing.Point(292, 38);
            this.chkShift1.Name = "chkShift1";
            this.chkShift1.Size = new System.Drawing.Size(71, 17);
            this.chkShift1.TabIndex = 9;
            this.chkShift1.Text = "Schicht 1";
            this.chkShift1.UseVisualStyleBackColor = true;
            //
            //chkShift2
            //
            this.chkShift2.AutoSize = true;
            this.chkShift2.Checked = true;
            this.chkShift2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShift2.Location = new System.Drawing.Point(380, 38);
            this.chkShift2.Name = "chkShift2";
            this.chkShift2.Size = new System.Drawing.Size(71, 17);
            this.chkShift2.TabIndex = 10;
            this.chkShift2.Text = "Schicht 2";
            this.chkShift2.UseVisualStyleBackColor = true;
            //
            //chkShift3
            //
            this.chkShift3.AutoSize = true;
            this.chkShift3.Checked = true;
            this.chkShift3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShift3.Location = new System.Drawing.Point(292, 62);
            this.chkShift3.Name = "chkShift3";
            this.chkShift3.Size = new System.Drawing.Size(71, 17);
            this.chkShift3.TabIndex = 11;
            this.chkShift3.Text = "Schicht 3";
            this.chkShift3.UseVisualStyleBackColor = true;
            //
            //chkShift4
            //
            this.chkShift4.AutoSize = true;
            this.chkShift4.Checked = true;
            this.chkShift4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShift4.Location = new System.Drawing.Point(380, 62);
            this.chkShift4.Name = "chkShift4";
            this.chkShift4.Size = new System.Drawing.Size(71, 17);
            this.chkShift4.TabIndex = 12;
            this.chkShift4.Text = "Schicht 4";
            this.chkShift4.UseVisualStyleBackColor = true;
            //
            //lblImportStatus
            //
            this.lblImportStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.lblImportStatus.AutoEllipsis = true;
            this.lblImportStatus.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblImportStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblImportStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblImportStatus.Location = new System.Drawing.Point(20, 310);
            this.lblImportStatus.Name = "lblImportStatus";
            this.lblImportStatus.Size = new System.Drawing.Size(423, 54);
            this.lblImportStatus.TabIndex = 14;
            this.lblImportStatus.Text = "Status: W�hlen Sie den Datumsbereich und anschlie�end 'Import starten!'";
            this.lblImportStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            //pbImportProgress
            //
            this.pbImportProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.pbImportProgress.Location = new System.Drawing.Point(20, 370);
            this.pbImportProgress.Name = "pbImportProgress";
            this.pbImportProgress.Size = new System.Drawing.Size(423, 25);
            this.pbImportProgress.TabIndex = 13;
            //
            //MenuStrip1
            //
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.DateiToolStripMenuItem, this.BearbeitenToolStripMenuItem });
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(697, 24);
            this.MenuStrip1.TabIndex = 15;
            this.MenuStrip1.Text = "MenuStrip1";
            //
            //DateiToolStripMenuItem
            //
            this.DateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmFileImportImportSettings, this.tsmFileExportShiftmodel, this.ToolStripMenuItem1, this.tsmQuitDialog });
            this.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem";
            this.DateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.DateiToolStripMenuItem.Text = "&Datei";
            //
            //tsmFileImportImportSettings
            //
            this.tsmFileImportImportSettings.Name = "tsmFileImportImportSettings";
            this.tsmFileImportImportSettings.Size = new System.Drawing.Size(295, 22);
            this.tsmFileImportImportSettings.Text = "Datemimport-Einstellungen &importieren...";
            //
            //tsmFileExportShiftmodel
            //
            this.tsmFileExportShiftmodel.Name = "tsmFileExportShiftmodel";
            this.tsmFileExportShiftmodel.Size = new System.Drawing.Size(295, 22);
            this.tsmFileExportShiftmodel.Text = "Datenimport-Einstellungen &exportieren...";
            //
            //ToolStripMenuItem1
            //
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(292, 6);
            //
            //tsmQuitDialog
            //
            this.tsmQuitDialog.Name = "tsmQuitDialog";
            this.tsmQuitDialog.Size = new System.Drawing.Size(295, 22);
            this.tsmQuitDialog.Text = "Dialog &beenden";
            //
            //BearbeitenToolStripMenuItem
            //
            this.BearbeitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmEditNewImportTask, this.tsmEditImportTask, this.tsmEditDeleteImportTask });
            this.BearbeitenToolStripMenuItem.Name = "BearbeitenToolStripMenuItem";
            this.BearbeitenToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.BearbeitenToolStripMenuItem.Text = "&Bearbeiten";
            //
            //tsmEditNewImportTask
            //
            this.tsmEditNewImportTask.Name = "tsmEditNewImportTask";
            this.tsmEditNewImportTask.Size = new System.Drawing.Size(207, 22);
            this.tsmEditNewImportTask.Text = "Neuer Import-Task...";
            //
            //tsmEditImportTask
            //
            this.tsmEditImportTask.Name = "tsmEditImportTask";
            this.tsmEditImportTask.Size = new System.Drawing.Size(207, 22);
            this.tsmEditImportTask.Text = "Import-Task bearbeiten...";
            //
            //tsmEditDeleteImportTask
            //
            this.tsmEditDeleteImportTask.Name = "tsmEditDeleteImportTask";
            this.tsmEditDeleteImportTask.Size = new System.Drawing.Size(207, 22);
            this.tsmEditDeleteImportTask.Text = "Import-Task l�schen...";
            //
            //btnOK
            //
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnOK.Location = new System.Drawing.Point(590, 32);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 47);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //ucWorkGroups
            //
            this.ucWorkGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right));
            this.ucWorkGroups.AutoGroup = true;
            this.ucWorkGroups.CheckBoxes = true;
            this.ucWorkGroups.FullRowSelect = true;
            this.ucWorkGroups.HideSelection = false;
            this.ucWorkGroups.Location = new System.Drawing.Point(450, 106);
            this.ucWorkGroups.Name = "ucWorkGroups";
            this.ucWorkGroups.OnlyActiveWorkgroups = true;
            this.ucWorkGroups.Size = new System.Drawing.Size(235, 258);
            this.ucWorkGroups.TabIndex = 17;
            this.ucWorkGroups.UseCompatibleStateImageBehavior = false;
            this.ucWorkGroups.View = System.Windows.Forms.View.Details;
            this.ucWorkGroups.WorkGroupInfoItems = null;
            this.ucWorkGroups.WorkGroupSortOrder = Facesso.GenericControls.WorkGroupSortOrder.WorkGroupNumber;
            //
            //btnSelectAll
            //
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnSelectAll.Location = new System.Drawing.Point(449, 370);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(115, 25);
            this.btnSelectAll.TabIndex = 18;
            this.btnSelectAll.Text = "Alle selektieren";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            //
            //btnDeselectAll
            //
            this.btnDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnDeselectAll.Location = new System.Drawing.Point(570, 370);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(115, 25);
            this.btnDeselectAll.TabIndex = 19;
            this.btnDeselectAll.Text = "Alle de-selektieren";
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            //
            //lblWorkgroups
            //
            this.lblWorkgroups.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.lblWorkgroups.AutoSize = true;
            this.lblWorkgroups.Location = new System.Drawing.Point(449, 90);
            this.lblWorkgroups.Name = "lblWorkgroups";
            this.lblWorkgroups.Size = new System.Drawing.Size(234, 13);
            this.lblWorkgroups.TabIndex = 20;
            this.lblWorkgroups.Text = "Zeitdaten f�r diese Produktiv-Sites �bernehmen:";
            //
            //frmImport
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 407);
            this.Controls.Add(this.lblWorkgroups);
            this.Controls.Add(this.btnDeselectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.ucWorkGroups);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblImportStatus);
            this.Controls.Add(this.pbImportProgress);
            this.Controls.Add(this.chkShift4);
            this.Controls.Add(this.chkShift3);
            this.Controls.Add(this.chkShift2);
            this.Controls.Add(this.chkShift1);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnImportNow);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.MenuStrip1);
            this.MainMenuStrip = this.MenuStrip1;
            this.MinimumSize = new System.Drawing.Size(713, 445);
            this.Name = "frmImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Datenimport";
            this.GroupBox1.ResumeLayout(false);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnImportNow;

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.DateTimePicker dtpFrom;

        internal System.Windows.Forms.DateTimePicker dtpTo;

        internal System.Windows.Forms.CheckBox chkShift1;
        internal System.Windows.Forms.CheckBox chkShift2;
        internal System.Windows.Forms.CheckBox chkShift3;
        internal System.Windows.Forms.CheckBox chkShift4;
        internal System.Windows.Forms.ListView lvwTaskList;

        internal System.Windows.Forms.ImageList ListViewImages;
        internal System.Windows.Forms.Label lblImportStatus;
        internal System.Windows.Forms.ProgressBar pbImportProgress;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem DateiToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem tsmFileImportImportSettings;
        internal System.Windows.Forms.ToolStripMenuItem tsmFileExportShiftmodel;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem tsmQuitDialog;

        internal System.Windows.Forms.ToolStripMenuItem BearbeitenToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem tsmEditNewImportTask;

        internal System.Windows.Forms.ToolStripMenuItem tsmEditImportTask;

        internal System.Windows.Forms.ToolStripMenuItem tsmEditDeleteImportTask;

        internal System.Windows.Forms.Button btnOK;

        internal Facesso.GenericControls.ucWorkGroupListView ucWorkGroups;
        internal System.Windows.Forms.Button btnSelectAll;

        internal System.Windows.Forms.Button btnDeselectAll;

        internal System.Windows.Forms.Label lblWorkgroups;
    }
}