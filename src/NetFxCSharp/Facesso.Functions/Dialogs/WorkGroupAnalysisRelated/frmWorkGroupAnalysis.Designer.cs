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
    public partial class frmWorkGroupAnalysis : frmBaseFacesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorkGroupAnalysis));
            this.tcWizard = new System.Windows.Forms.TabControl();
            this.TabBase = new System.Windows.Forms.TabPage();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Tab2Period = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.nudAltShiftDays = new System.Windows.Forms.NumericUpDown();
            this.btnAllShifts = new System.Windows.Forms.Button();
            this.Label9 = new System.Windows.Forms.Label();
            this.nudAltShift2 = new System.Windows.Forms.NumericUpDown();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.nudAltShift1 = new System.Windows.Forms.NumericUpDown();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.optUseAlternatingShifts = new System.Windows.Forms.RadioButton();
            this.optUseShifts = new System.Windows.Forms.RadioButton();
            this.chkShift4 = new System.Windows.Forms.CheckBox();
            this.chkShift3 = new System.Windows.Forms.CheckBox();
            this.chkShift2 = new System.Windows.Forms.CheckBox();
            this.chkShift1 = new System.Windows.Forms.CheckBox();
            this.drpMain = new Facesso.GenericControls.ucAnalysisDateRangePicker();
            this.Label16 = new System.Windows.Forms.Label();
            this.Tab3SelectWorkgroups = new System.Windows.Forms.TabPage();
            this.btnAllWorkGroupsInCostCenter = new System.Windows.Forms.Button();
            this.btnUnSelectWorkGroups = new System.Windows.Forms.Button();
            this.btnSelectAllWorkGroups = new System.Windows.Forms.Button();
            this.wglWorkGroups = new Facesso.GenericControls.ucWorkGroupListView();
            this.Label25 = new System.Windows.Forms.Label();
            this.Tab4TypeOfAnalysis = new System.Windows.Forms.TabPage();
            this.optWorkGroupListShiftwiseCompressed = new System.Windows.Forms.RadioButton();
            this.lblDescription = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.optWorkGroupListShiftWise = new System.Windows.Forms.RadioButton();
            this.optAnalysisLine = new System.Windows.Forms.RadioButton();
            this.optWorkGroupListShiftCondensed = new System.Windows.Forms.RadioButton();
            this.optBatch = new System.Windows.Forms.RadioButton();
            this.optDetailed = new System.Windows.Forms.RadioButton();
            this.chkIncludeSuspended = new System.Windows.Forms.CheckBox();
            this.Label37 = new System.Windows.Forms.Label();
            this.Tab5AnalysisDestination = new System.Windows.Forms.TabPage();
            this.btnSelectExportFile = new System.Windows.Forms.Button();
            this.lblExportFilename = new System.Windows.Forms.Label();
            this.optCSVExport = new System.Windows.Forms.RadioButton();
            this.optPreviewBeforePrint = new System.Windows.Forms.RadioButton();
            this.optTargetPrinter = new System.Windows.Forms.RadioButton();
            this.Label27 = new System.Windows.Forms.Label();
            this.Tab6ExcelExport = new System.Windows.Forms.TabPage();
            this.lstDestFields = new System.Windows.Forms.ListBox();
            this.btnRemoveAllFields = new System.Windows.Forms.Button();
            this.btnRemoveField = new System.Windows.Forms.Button();
            this.btnAddField = new System.Windows.Forms.Button();
            this.btnAddAllFields = new System.Windows.Forms.Button();
            this.lstSourceFields = new System.Windows.Forms.ListBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.Tab8Finalize = new System.Windows.Forms.TabPage();
            this.txtConclusion = new System.Windows.Forms.TextBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label35 = new System.Windows.Forms.Label();
            this.Label34 = new System.Windows.Forms.Label();
            this.Label33 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.tcWizard.SuspendLayout();
            this.TabBase.SuspendLayout();
            this.Tab2Period.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudAltShiftDays).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudAltShift2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudAltShift1).BeginInit();
            this.Tab3SelectWorkgroups.SuspendLayout();
            this.Tab4TypeOfAnalysis.SuspendLayout();
            this.Tab5AnalysisDestination.SuspendLayout();
            this.Tab6ExcelExport.SuspendLayout();
            this.Tab8Finalize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
            this.SuspendLayout();
            //
            //tcWizard
            //
            this.tcWizard.Controls.Add(this.TabBase);
            this.tcWizard.Controls.Add(this.Tab2Period);
            this.tcWizard.Controls.Add(this.Tab3SelectWorkgroups);
            this.tcWizard.Controls.Add(this.Tab4TypeOfAnalysis);
            this.tcWizard.Controls.Add(this.Tab5AnalysisDestination);
            this.tcWizard.Controls.Add(this.Tab6ExcelExport);
            this.tcWizard.Controls.Add(this.Tab8Finalize);
            this.tcWizard.Location = new System.Drawing.Point(154, -22);
            this.tcWizard.Name = "tcWizard";
            this.tcWizard.SelectedIndex = 0;
            this.tcWizard.Size = new System.Drawing.Size(658, 417);
            this.tcWizard.TabIndex = 1;
            //
            //TabBase
            //
            this.TabBase.Controls.Add(this.Label6);
            this.TabBase.Controls.Add(this.Label12);
            this.TabBase.Controls.Add(this.Label4);
            this.TabBase.Controls.Add(this.Label3);
            this.TabBase.Controls.Add(this.Label2);
            this.TabBase.Location = new System.Drawing.Point(4, 22);
            this.TabBase.Name = "TabBase";
            this.TabBase.Padding = new System.Windows.Forms.Padding(3);
            this.TabBase.Size = new System.Drawing.Size(650, 391);
            this.TabBase.TabIndex = 0;
            this.TabBase.Text = "Basis";
            //
            //Label6
            //
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label6.Location = new System.Drawing.Point(50, 160);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(464, 51);
            this.Label6.TabIndex = 3;
            this.Label6.Text = resources.GetString("Label6.Text");
            //
            //Label12
            //
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label12.Location = new System.Drawing.Point(50, 224);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(438, 32);
            this.Label12.TabIndex = 5;
            this.Label12.Text = "Klicken Sie jeweils auf die Schaltfl�che [Weiter >], wenn Sie einen Schritt des A" + "ssistenten abgeschlossen haben.";
            //
            //Label4
            //
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label4.Location = new System.Drawing.Point(50, 82);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(441, 69);
            this.Label4.TabIndex = 2;
            this.Label4.Text = resources.GetString("Label4.Text");
            //
            //Label3
            //
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label3.Location = new System.Drawing.Point(50, 43);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(438, 39);
            this.Label3.TabIndex = 1;
            this.Label3.Text = "Dieser Assistent hilft Ihnen, die erforderlichen Parameter zusammenzustellen, um " + "auf m�glichst flexible Art und Weise Auswertungen von Produktiv-Sites durchf�hre" + "n zu k�nnen.";
            //
            //Label2
            //
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label2.Location = new System.Drawing.Point(6, 9);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(498, 16);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Willkommen zum Produktiv-Site-Auswertungs-Assistenten von Facesso!";
            //
            //Tab2Period
            //
            this.Tab2Period.Controls.Add(this.GroupBox1);
            this.Tab2Period.Controls.Add(this.drpMain);
            this.Tab2Period.Controls.Add(this.Label16);
            this.Tab2Period.Location = new System.Drawing.Point(4, 22);
            this.Tab2Period.Name = "Tab2Period";
            this.Tab2Period.Padding = new System.Windows.Forms.Padding(3);
            this.Tab2Period.Size = new System.Drawing.Size(650, 391);
            this.Tab2Period.TabIndex = 1;
            this.Tab2Period.Text = "PeriodAndShifts";
            //
            //GroupBox1
            //
            this.GroupBox1.Controls.Add(this.Label13);
            this.GroupBox1.Controls.Add(this.nudAltShiftDays);
            this.GroupBox1.Controls.Add(this.btnAllShifts);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.nudAltShift2);
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Controls.Add(this.nudAltShift1);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.optUseAlternatingShifts);
            this.GroupBox1.Controls.Add(this.optUseShifts);
            this.GroupBox1.Controls.Add(this.chkShift4);
            this.GroupBox1.Controls.Add(this.chkShift3);
            this.GroupBox1.Controls.Add(this.chkShift2);
            this.GroupBox1.Controls.Add(this.chkShift1);
            this.GroupBox1.Location = new System.Drawing.Point(392, 34);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(196, 336);
            this.GroupBox1.TabIndex = 2;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Schichten:";
            //
            //Label13
            //
            this.Label13.Location = new System.Drawing.Point(11, 256);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(181, 69);
            this.Label13.TabIndex = 16;
            this.Label13.Text = "W�hlen Sie diesen Schichttyp, wenn Mitarbeiter beispielsweise in der ersten Woche" + " in Schicht 1, in der zweiten in Schicht 2, in der dritten wieder in Schicht 1 u" + "sw. arbeiten.";
            //
            //nudAltShiftDays
            //
            this.nudAltShiftDays.Location = new System.Drawing.Point(54, 171);
            this.nudAltShiftDays.Maximum = new decimal (new int[] { 31, 0, 0, 0 });
            this.nudAltShiftDays.Minimum = new decimal (new int[] { 1, 0, 0, 0 });
            this.nudAltShiftDays.Name = "nudAltShiftDays";
            this.nudAltShiftDays.Size = new System.Drawing.Size(34, 20);
            this.nudAltShiftDays.TabIndex = 7;
            this.nudAltShiftDays.Value = new decimal (new int[] { 7, 0, 0, 0 });
            //
            //btnAllShifts
            //
            this.btnAllShifts.Location = new System.Drawing.Point(116, 45);
            this.btnAllShifts.Name = "btnAllShifts";
            this.btnAllShifts.Size = new System.Drawing.Size(68, 23);
            this.btnAllShifts.TabIndex = 15;
            this.btnAllShifts.Text = "Alle";
            this.btnAllShifts.UseVisualStyleBackColor = true;
            //
            //Label9
            //
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(107, 228);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(55, 13);
            this.Label9.TabIndex = 14;
            this.Label9.Text = "wechseln.";
            //
            //nudAltShift2
            //
            this.nudAltShift2.Location = new System.Drawing.Point(67, 225);
            this.nudAltShift2.Maximum = new decimal (new int[] { 4, 0, 0, 0 });
            this.nudAltShift2.Minimum = new decimal (new int[] { 1, 0, 0, 0 });
            this.nudAltShift2.Name = "nudAltShift2";
            this.nudAltShift2.Size = new System.Drawing.Size(34, 20);
            this.nudAltShift2.TabIndex = 13;
            this.nudAltShift2.Value = new decimal (new int[] { 2, 0, 0, 0 });
            //
            //Label10
            //
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(19, 228);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(43, 13);
            this.Label10.TabIndex = 12;
            this.Label10.Text = "Schicht";
            //
            //Label8
            //
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(106, 202);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(25, 13);
            this.Label8.TabIndex = 11;
            this.Label8.Text = "und";
            //
            //nudAltShift1
            //
            this.nudAltShift1.Location = new System.Drawing.Point(66, 199);
            this.nudAltShift1.Maximum = new decimal (new int[] { 4, 0, 0, 0 });
            this.nudAltShift1.Minimum = new decimal (new int[] { 1, 0, 0, 0 });
            this.nudAltShift1.Name = "nudAltShift1";
            this.nudAltShift1.Size = new System.Drawing.Size(34, 20);
            this.nudAltShift1.TabIndex = 10;
            this.nudAltShift1.Value = new decimal (new int[] { 1, 0, 0, 0 });
            //
            //Label7
            //
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(18, 202);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(43, 13);
            this.Label7.TabIndex = 9;
            this.Label7.Text = "Schicht";
            //
            //Label5
            //
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(94, 173);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(79, 13);
            this.Label5.TabIndex = 8;
            this.Label5.Text = "Tage zwischen";
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(18, 174);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(24, 13);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Alle";
            //
            //optUseAlternatingShifts
            //
            this.optUseAlternatingShifts.AutoSize = true;
            this.optUseAlternatingShifts.Location = new System.Drawing.Point(7, 149);
            this.optUseAlternatingShifts.Name = "optUseAlternatingShifts";
            this.optUseAlternatingShifts.Size = new System.Drawing.Size(116, 17);
            this.optUseAlternatingShifts.TabIndex = 5;
            this.optUseAlternatingShifts.Text = "Wechselschichten:";
            this.optUseAlternatingShifts.UseVisualStyleBackColor = true;
            //
            //optUseShifts
            //
            this.optUseShifts.AutoSize = true;
            this.optUseShifts.Checked = true;
            this.optUseShifts.Location = new System.Drawing.Point(9, 21);
            this.optUseShifts.Name = "optUseShifts";
            this.optUseShifts.Size = new System.Drawing.Size(183, 17);
            this.optUseShifts.TabIndex = 0;
            this.optUseShifts.TabStop = true;
            this.optUseShifts.Text = "Folgende Schichten einbeziehen:";
            this.optUseShifts.UseVisualStyleBackColor = true;
            //
            //chkShift4
            //
            this.chkShift4.AutoSize = true;
            this.chkShift4.Location = new System.Drawing.Point(21, 115);
            this.chkShift4.Name = "chkShift4";
            this.chkShift4.Size = new System.Drawing.Size(94, 17);
            this.chkShift4.TabIndex = 4;
            this.chkShift4.Text = "Sonderschicht";
            this.chkShift4.UseVisualStyleBackColor = true;
            //
            //chkShift3
            //
            this.chkShift3.AutoSize = true;
            this.chkShift3.Location = new System.Drawing.Point(21, 92);
            this.chkShift3.Name = "chkShift3";
            this.chkShift3.Size = new System.Drawing.Size(71, 17);
            this.chkShift3.TabIndex = 3;
            this.chkShift3.Text = "Schicht 3";
            this.chkShift3.UseVisualStyleBackColor = true;
            //
            //chkShift2
            //
            this.chkShift2.AutoSize = true;
            this.chkShift2.Location = new System.Drawing.Point(21, 69);
            this.chkShift2.Name = "chkShift2";
            this.chkShift2.Size = new System.Drawing.Size(71, 17);
            this.chkShift2.TabIndex = 2;
            this.chkShift2.Text = "Schicht 2";
            this.chkShift2.UseVisualStyleBackColor = true;
            //
            //chkShift1
            //
            this.chkShift1.AutoSize = true;
            this.chkShift1.Checked = true;
            this.chkShift1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShift1.Location = new System.Drawing.Point(21, 46);
            this.chkShift1.Name = "chkShift1";
            this.chkShift1.Size = new System.Drawing.Size(71, 17);
            this.chkShift1.TabIndex = 1;
            this.chkShift1.Text = "Schicht 1";
            this.chkShift1.UseVisualStyleBackColor = true;
            //
            //drpMain
            //
            this.drpMain.LastWorkingday = Facesso.Data.LastWorkingdays.Friday;
            this.drpMain.Location = new System.Drawing.Point(9, 34);
            this.drpMain.Name = "drpMain";
            this.drpMain.Size = new System.Drawing.Size(378, 338);
            this.drpMain.TabIndex = 1;
            //
            //Label16
            //
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label16.Location = new System.Drawing.Point(6, 9);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(362, 16);
            this.Label16.TabIndex = 0;
            this.Label16.Text = "Schritt 1: Eingabe des Zeitraums und der Schichten:";
            //
            //Tab3SelectWorkgroups
            //
            this.Tab3SelectWorkgroups.Controls.Add(this.btnAllWorkGroupsInCostCenter);
            this.Tab3SelectWorkgroups.Controls.Add(this.btnUnSelectWorkGroups);
            this.Tab3SelectWorkgroups.Controls.Add(this.btnSelectAllWorkGroups);
            this.Tab3SelectWorkgroups.Controls.Add(this.wglWorkGroups);
            this.Tab3SelectWorkgroups.Controls.Add(this.Label25);
            this.Tab3SelectWorkgroups.Location = new System.Drawing.Point(4, 22);
            this.Tab3SelectWorkgroups.Name = "Tab3SelectWorkgroups";
            this.Tab3SelectWorkgroups.Padding = new System.Windows.Forms.Padding(3);
            this.Tab3SelectWorkgroups.Size = new System.Drawing.Size(650, 391);
            this.Tab3SelectWorkgroups.TabIndex = 2;
            this.Tab3SelectWorkgroups.Text = "ChooseWorkgroups";
            //
            //btnAllWorkGroupsInCostCenter
            //
            this.btnAllWorkGroupsInCostCenter.Location = new System.Drawing.Point(200, 337);
            this.btnAllWorkGroupsInCostCenter.Name = "btnAllWorkGroupsInCostCenter";
            this.btnAllWorkGroupsInCostCenter.Size = new System.Drawing.Size(197, 25);
            this.btnAllWorkGroupsInCostCenter.TabIndex = 3;
            this.btnAllWorkGroupsInCostCenter.Text = "Alle in dieser Kostenstelle markieren";
            this.btnAllWorkGroupsInCostCenter.UseVisualStyleBackColor = true;
            //
            //btnUnSelectWorkGroups
            //
            this.btnUnSelectWorkGroups.Location = new System.Drawing.Point(495, 337);
            this.btnUnSelectWorkGroups.Name = "btnUnSelectWorkGroups";
            this.btnUnSelectWorkGroups.Size = new System.Drawing.Size(133, 25);
            this.btnUnSelectWorkGroups.TabIndex = 2;
            this.btnUnSelectWorkGroups.Text = "Selektierung aufheben";
            this.btnUnSelectWorkGroups.UseVisualStyleBackColor = true;
            //
            //btnSelectAllWorkGroups
            //
            this.btnSelectAllWorkGroups.Location = new System.Drawing.Point(403, 337);
            this.btnSelectAllWorkGroups.Name = "btnSelectAllWorkGroups";
            this.btnSelectAllWorkGroups.Size = new System.Drawing.Size(86, 25);
            this.btnSelectAllWorkGroups.TabIndex = 4;
            this.btnSelectAllWorkGroups.Text = "Alle markieren";
            this.btnSelectAllWorkGroups.UseVisualStyleBackColor = true;
            //
            //wglWorkGroups
            //
            this.wglWorkGroups.AutoGroup = true;
            this.wglWorkGroups.FullRowSelect = true;
            this.wglWorkGroups.HideSelection = false;
            this.wglWorkGroups.Location = new System.Drawing.Point(9, 50);
            this.wglWorkGroups.Name = "wglWorkGroups";
            this.wglWorkGroups.OnlyActiveWorkgroups = true;
            this.wglWorkGroups.Size = new System.Drawing.Size(619, 281);
            this.wglWorkGroups.TabIndex = 1;
            this.wglWorkGroups.UseCompatibleStateImageBehavior = false;
            this.wglWorkGroups.View = System.Windows.Forms.View.Details;
            this.wglWorkGroups.WorkGroupInfoItems = null;
            this.wglWorkGroups.WorkGroupSortOrder = Facesso.GenericControls.WorkGroupSortOrder.WorkGroupNumber;
            //
            //Label25
            //
            this.Label25.AutoSize = true;
            this.Label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label25.Location = new System.Drawing.Point(6, 14);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(422, 16);
            this.Label25.TabIndex = 0;
            this.Label25.Text = "Schritt 2: Auswahl der mit einzubeziehenden Arbeitsgruppen:";
            //
            //Tab4TypeOfAnalysis
            //
            this.Tab4TypeOfAnalysis.Controls.Add(this.optWorkGroupListShiftwiseCompressed);
            this.Tab4TypeOfAnalysis.Controls.Add(this.lblDescription);
            this.Tab4TypeOfAnalysis.Controls.Add(this.Label14);
            this.Tab4TypeOfAnalysis.Controls.Add(this.optWorkGroupListShiftWise);
            this.Tab4TypeOfAnalysis.Controls.Add(this.optAnalysisLine);
            this.Tab4TypeOfAnalysis.Controls.Add(this.optWorkGroupListShiftCondensed);
            this.Tab4TypeOfAnalysis.Controls.Add(this.optBatch);
            this.Tab4TypeOfAnalysis.Controls.Add(this.optDetailed);
            this.Tab4TypeOfAnalysis.Controls.Add(this.chkIncludeSuspended);
            this.Tab4TypeOfAnalysis.Controls.Add(this.Label37);
            this.Tab4TypeOfAnalysis.Location = new System.Drawing.Point(4, 22);
            this.Tab4TypeOfAnalysis.Name = "Tab4TypeOfAnalysis";
            this.Tab4TypeOfAnalysis.Padding = new System.Windows.Forms.Padding(3);
            this.Tab4TypeOfAnalysis.Size = new System.Drawing.Size(650, 391);
            this.Tab4TypeOfAnalysis.TabIndex = 7;
            this.Tab4TypeOfAnalysis.Text = "TypeOfAnalysis";
            //
            //optWorkGroupListShiftwiseCompressed
            //
            this.optWorkGroupListShiftwiseCompressed.AutoSize = true;
            this.optWorkGroupListShiftwiseCompressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.optWorkGroupListShiftwiseCompressed.Location = new System.Drawing.Point(14, 143);
            this.optWorkGroupListShiftwiseCompressed.Name = "optWorkGroupListShiftwiseCompressed";
            this.optWorkGroupListShiftwiseCompressed.Size = new System.Drawing.Size(610, 19);
            this.optWorkGroupListShiftwiseCompressed.TabIndex = 11;
            this.optWorkGroupListShiftwiseCompressed.Text = "Produktiv-Site-Liste, schichtweise, kompakt: Wie vorheriger, kompakte Version. Al" + "s einfache Tages�bersicht.";
            this.optWorkGroupListShiftwiseCompressed.UseVisualStyleBackColor = true;
            //
            //lblDescription
            //
            this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDescription.Location = new System.Drawing.Point(34, 218);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(599, 129);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Visible = false;
            //
            //Label14
            //
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(31, 202);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(214, 13);
            this.Label14.TabIndex = 9;
            this.Label14.Text = "Beschreibung f�r das ausgew�hlte Element:";
            this.Label14.Visible = false;
            //
            //optWorkGroupListShiftWise
            //
            this.optWorkGroupListShiftWise.AutoSize = true;
            this.optWorkGroupListShiftWise.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.optWorkGroupListShiftWise.Location = new System.Drawing.Point(14, 121);
            this.optWorkGroupListShiftWise.Name = "optWorkGroupListShiftWise";
            this.optWorkGroupListShiftWise.Size = new System.Drawing.Size(588, 19);
            this.optWorkGroupListShiftWise.TabIndex = 8;
            this.optWorkGroupListShiftWise.Text = "Produktiv-Site-Liste, schichtweise: Pro Produktiv-Site und Schicht eine Zeile als" + " Liste, eine Liste pro Tag.";
            this.optWorkGroupListShiftWise.UseVisualStyleBackColor = true;
            //
            //optAnalysisLine
            //
            this.optAnalysisLine.AutoSize = true;
            this.optAnalysisLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.optAnalysisLine.Location = new System.Drawing.Point(14, 168);
            this.optAnalysisLine.Name = "optAnalysisLine";
            this.optAnalysisLine.Size = new System.Drawing.Size(599, 19);
            this.optAnalysisLine.TabIndex = 4;
            this.optAnalysisLine.Text = "Produktiv-Site-Auslastung schichtweise: Wie Produktiv-Site-Liste schichtweise, mi" + "t Auslastungsinformation";
            this.optAnalysisLine.UseVisualStyleBackColor = true;
            //
            //optWorkGroupListShiftCondensed
            //
            this.optWorkGroupListShiftCondensed.AutoSize = true;
            this.optWorkGroupListShiftCondensed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.optWorkGroupListShiftCondensed.Location = new System.Drawing.Point(14, 96);
            this.optWorkGroupListShiftCondensed.Name = "optWorkGroupListShiftCondensed";
            this.optWorkGroupListShiftCondensed.Size = new System.Drawing.Size(616, 19);
            this.optWorkGroupListShiftCondensed.TabIndex = 3;
            this.optWorkGroupListShiftCondensed.Text = "Stapel, Schichten verdichtet: Pro Produktiv-Site eine Zeile mit Tagesergebnissen " + "aller Schichten im Zeitraum.";
            this.optWorkGroupListShiftCondensed.UseVisualStyleBackColor = true;
            //
            //optBatch
            //
            this.optBatch.AutoSize = true;
            this.optBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.optBatch.Location = new System.Drawing.Point(14, 71);
            this.optBatch.Name = "optBatch";
            this.optBatch.Size = new System.Drawing.Size(565, 19);
            this.optBatch.TabIndex = 2;
            this.optBatch.Text = "Stapelausdruck: Pro Produktiv-Site eine Liste, mit einem Element pro Tag; alle Sc" + "hichten verdichtet.";
            this.optBatch.UseVisualStyleBackColor = true;
            //
            //optDetailed
            //
            this.optDetailed.AutoSize = true;
            this.optDetailed.Checked = true;
            this.optDetailed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.optDetailed.Location = new System.Drawing.Point(14, 48);
            this.optDetailed.Name = "optDetailed";
            this.optDetailed.Size = new System.Drawing.Size(603, 19);
            this.optDetailed.TabIndex = 1;
            this.optDetailed.TabStop = true;
            this.optDetailed.Text = "Detailliert: Pro Schicht, Datum und Produktiv-Site eine Seite mit Produktionserge" + "bnis und Mitarbeiterzeiten";
            this.optDetailed.UseVisualStyleBackColor = true;
            //
            //chkIncludeSuspended
            //
            this.chkIncludeSuspended.AutoSize = true;
            this.chkIncludeSuspended.Checked = true;
            this.chkIncludeSuspended.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeSuspended.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.chkIncludeSuspended.Location = new System.Drawing.Point(14, 366);
            this.chkIncludeSuspended.Name = "chkIncludeSuspended";
            this.chkIncludeSuspended.Size = new System.Drawing.Size(294, 19);
            this.chkIncludeSuspended.TabIndex = 6;
            this.chkIncludeSuspended.Text = "Ausgesetzte Tage in die Auswertung einbeziehen";
            this.chkIncludeSuspended.UseVisualStyleBackColor = true;
            this.chkIncludeSuspended.Visible = false;
            //
            //Label37
            //
            this.Label37.AutoSize = true;
            this.Label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label37.Location = new System.Drawing.Point(6, 9);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(503, 16);
            this.Label37.TabIndex = 0;
            this.Label37.Text = "Schritt 3: Bestimmen Sie, wie die Auswertung vorgenommen werden soll:";
            //
            //Tab5AnalysisDestination
            //
            this.Tab5AnalysisDestination.Controls.Add(this.btnSelectExportFile);
            this.Tab5AnalysisDestination.Controls.Add(this.lblExportFilename);
            this.Tab5AnalysisDestination.Controls.Add(this.optCSVExport);
            this.Tab5AnalysisDestination.Controls.Add(this.optPreviewBeforePrint);
            this.Tab5AnalysisDestination.Controls.Add(this.optTargetPrinter);
            this.Tab5AnalysisDestination.Controls.Add(this.Label27);
            this.Tab5AnalysisDestination.Location = new System.Drawing.Point(4, 22);
            this.Tab5AnalysisDestination.Name = "Tab5AnalysisDestination";
            this.Tab5AnalysisDestination.Padding = new System.Windows.Forms.Padding(3);
            this.Tab5AnalysisDestination.Size = new System.Drawing.Size(650, 391);
            this.Tab5AnalysisDestination.TabIndex = 3;
            this.Tab5AnalysisDestination.Text = "SelectFields";
            //
            //btnSelectExportFile
            //
            this.btnSelectExportFile.Enabled = false;
            this.btnSelectExportFile.Location = new System.Drawing.Point(461, 188);
            this.btnSelectExportFile.Name = "btnSelectExportFile";
            this.btnSelectExportFile.Size = new System.Drawing.Size(139, 24);
            this.btnSelectExportFile.TabIndex = 12;
            this.btnSelectExportFile.Text = "Speicherort...";
            this.btnSelectExportFile.UseVisualStyleBackColor = true;
            //
            //lblExportFilename
            //
            this.lblExportFilename.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblExportFilename.Location = new System.Drawing.Point(108, 190);
            this.lblExportFilename.Name = "lblExportFilename";
            this.lblExportFilename.Size = new System.Drawing.Size(336, 23);
            this.lblExportFilename.TabIndex = 13;
            this.lblExportFilename.Text = "unbenannt.csv";
            this.lblExportFilename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //optCSVExport
            //
            this.optCSVExport.AutoSize = true;
            this.optCSVExport.Enabled = false;
            this.optCSVExport.Location = new System.Drawing.Point(89, 170);
            this.optCSVExport.Name = "optCSVExport";
            this.optCSVExport.Size = new System.Drawing.Size(345, 17);
            this.optCSVExport.TabIndex = 11;
            this.optCSVExport.Text = "CSV-Export f�r die Excel-Weiterverarbeitung (nur Enterprise-Edition!)";
            this.optCSVExport.UseVisualStyleBackColor = true;
            //
            //optPreviewBeforePrint
            //
            this.optPreviewBeforePrint.AutoSize = true;
            this.optPreviewBeforePrint.Checked = true;
            this.optPreviewBeforePrint.Location = new System.Drawing.Point(89, 126);
            this.optPreviewBeforePrint.Name = "optPreviewBeforePrint";
            this.optPreviewBeforePrint.Size = new System.Drawing.Size(151, 17);
            this.optPreviewBeforePrint.TabIndex = 10;
            this.optPreviewBeforePrint.TabStop = true;
            this.optPreviewBeforePrint.Text = "Vorschau, dann drucken...";
            this.optPreviewBeforePrint.UseVisualStyleBackColor = true;
            //
            //optTargetPrinter
            //
            this.optTargetPrinter.AutoSize = true;
            this.optTargetPrinter.Location = new System.Drawing.Point(89, 83);
            this.optTargetPrinter.Name = "optTargetPrinter";
            this.optTargetPrinter.Size = new System.Drawing.Size(190, 17);
            this.optTargetPrinter.TabIndex = 9;
            this.optTargetPrinter.Text = "Direkt auf Drucker, ohne Vorschau";
            this.optTargetPrinter.UseVisualStyleBackColor = true;
            //
            //Label27
            //
            this.Label27.AutoSize = true;
            this.Label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label27.Location = new System.Drawing.Point(22, 19);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(348, 16);
            this.Label27.TabIndex = 8;
            this.Label27.Text = "Schritt 4: Bestimmen Sie das Ziel der Auswertung:";
            //
            //Tab6ExcelExport
            //
            this.Tab6ExcelExport.Controls.Add(this.lstDestFields);
            this.Tab6ExcelExport.Controls.Add(this.btnRemoveAllFields);
            this.Tab6ExcelExport.Controls.Add(this.btnRemoveField);
            this.Tab6ExcelExport.Controls.Add(this.btnAddField);
            this.Tab6ExcelExport.Controls.Add(this.btnAddAllFields);
            this.Tab6ExcelExport.Controls.Add(this.lstSourceFields);
            this.Tab6ExcelExport.Controls.Add(this.Label11);
            this.Tab6ExcelExport.Controls.Add(this.Label20);
            this.Tab6ExcelExport.Location = new System.Drawing.Point(4, 22);
            this.Tab6ExcelExport.Name = "Tab6ExcelExport";
            this.Tab6ExcelExport.Padding = new System.Windows.Forms.Padding(3);
            this.Tab6ExcelExport.Size = new System.Drawing.Size(650, 391);
            this.Tab6ExcelExport.TabIndex = 4;
            this.Tab6ExcelExport.Text = "AnalysisTarget";
            //
            //lstDestFields
            //
            this.lstDestFields.FormattingEnabled = true;
            this.lstDestFields.Location = new System.Drawing.Point(357, 75);
            this.lstDestFields.Name = "lstDestFields";
            this.lstDestFields.Size = new System.Drawing.Size(166, 238);
            this.lstDestFields.TabIndex = 15;
            //
            //btnRemoveAllFields
            //
            this.btnRemoveAllFields.Location = new System.Drawing.Point(256, 208);
            this.btnRemoveAllFields.Name = "btnRemoveAllFields";
            this.btnRemoveAllFields.Size = new System.Drawing.Size(86, 26);
            this.btnRemoveAllFields.TabIndex = 14;
            this.btnRemoveAllFields.Text = "<< Alle";
            this.btnRemoveAllFields.UseVisualStyleBackColor = true;
            //
            //btnRemoveField
            //
            this.btnRemoveField.Location = new System.Drawing.Point(256, 176);
            this.btnRemoveField.Name = "btnRemoveField";
            this.btnRemoveField.Size = new System.Drawing.Size(86, 26);
            this.btnRemoveField.TabIndex = 13;
            this.btnRemoveField.Text = "<";
            this.btnRemoveField.UseVisualStyleBackColor = true;
            //
            //btnAddField
            //
            this.btnAddField.Location = new System.Drawing.Point(256, 144);
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.Size = new System.Drawing.Size(86, 26);
            this.btnAddField.TabIndex = 12;
            this.btnAddField.Text = ">";
            this.btnAddField.UseVisualStyleBackColor = true;
            //
            //btnAddAllFields
            //
            this.btnAddAllFields.Location = new System.Drawing.Point(256, 112);
            this.btnAddAllFields.Name = "btnAddAllFields";
            this.btnAddAllFields.Size = new System.Drawing.Size(86, 26);
            this.btnAddAllFields.TabIndex = 11;
            this.btnAddAllFields.Text = "Alle >>";
            this.btnAddAllFields.UseVisualStyleBackColor = true;
            //
            //lstSourceFields
            //
            this.lstSourceFields.FormattingEnabled = true;
            this.lstSourceFields.Location = new System.Drawing.Point(73, 75);
            this.lstSourceFields.Name = "lstSourceFields";
            this.lstSourceFields.Size = new System.Drawing.Size(166, 238);
            this.lstSourceFields.TabIndex = 10;
            //
            //Label11
            //
            this.Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label11.Location = new System.Drawing.Point(70, 29);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(438, 38);
            this.Label11.TabIndex = 9;
            this.Label11.Text = "Hinweis: Diese Einstellung findet nur in der Enterprise-Edition Ber�cksichtigung " + "und gilt ausschlie�lich f�r den Excel-Datenexport!";
            //
            //Label20
            //
            this.Label20.AutoSize = true;
            this.Label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label20.Location = new System.Drawing.Point(6, 9);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(548, 16);
            this.Label20.TabIndex = 8;
            this.Label20.Text = "Schritt 5: Bestimmen Sie die miteinzubeziehenden Datenfelder der Auswertung:";
            //
            //Tab8Finalize
            //
            this.Tab8Finalize.Controls.Add(this.txtConclusion);
            this.Tab8Finalize.Controls.Add(this.Label15);
            this.Tab8Finalize.Controls.Add(this.Label35);
            this.Tab8Finalize.Controls.Add(this.Label34);
            this.Tab8Finalize.Controls.Add(this.Label33);
            this.Tab8Finalize.Location = new System.Drawing.Point(4, 22);
            this.Tab8Finalize.Name = "Tab8Finalize";
            this.Tab8Finalize.Padding = new System.Windows.Forms.Padding(3);
            this.Tab8Finalize.Size = new System.Drawing.Size(650, 391);
            this.Tab8Finalize.TabIndex = 6;
            this.Tab8Finalize.Text = "Fertig";
            //
            //txtConclusion
            //
            this.txtConclusion.Location = new System.Drawing.Point(56, 110);
            this.txtConclusion.Multiline = true;
            this.txtConclusion.Name = "txtConclusion";
            this.txtConclusion.ReadOnly = true;
            this.txtConclusion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConclusion.Size = new System.Drawing.Size(435, 220);
            this.txtConclusion.TabIndex = 4;
            //
            //Label15
            //
            this.Label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label15.Location = new System.Drawing.Point(50, 82);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(441, 19);
            this.Label15.TabIndex = 3;
            this.Label15.Text = "�berpr�fen Sie die Einstellungen in der folgenden Zusammenfassung:";
            //
            //Label35
            //
            this.Label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label35.Location = new System.Drawing.Point(50, 346);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(441, 20);
            this.Label35.TabIndex = 2;
            this.Label35.Text = "Klicken Sie schlie�lich auf [Fertig], um die Auswertung zu erstellen.";
            //
            //Label34
            //
            this.Label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label34.Location = new System.Drawing.Point(50, 41);
            this.Label34.Name = "Label34";
            this.Label34.Size = new System.Drawing.Size(441, 37);
            this.Label34.TabIndex = 1;
            this.Label34.Text = "Der Assistent hat alle erforderlichen Daten gesammelt, um eine Auswertung nach Ih" + "ren W�nschen zu erstellen.";
            //
            //Label33
            //
            this.Label33.AutoSize = true;
            this.Label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label33.Location = new System.Drawing.Point(6, 16);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(156, 16);
            this.Label33.TabIndex = 0;
            this.Label33.Text = "Assistent fertigstellen";
            //
            //btnCancel
            //
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.btnCancel.Location = new System.Drawing.Point(717, 401);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 27);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbrechen";
            //
            //btnNext
            //
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.btnNext.Location = new System.Drawing.Point(603, 401);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(97, 27);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Weiter >";
            //
            //btnBack
            //
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.btnBack.Location = new System.Drawing.Point(500, 401);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(97, 27);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "< Zur�ck";
            //
            //PictureBox1
            //
            this.PictureBox1.BackColor = System.Drawing.Color.Blue;
            this.PictureBox1.Location = new System.Drawing.Point(1, 1);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(154, 394);
            this.PictureBox1.TabIndex = 28;
            this.PictureBox1.TabStop = false;
            //
            //frmWorkGroupAnalysis
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 437);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.tcWizard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmWorkGroupAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assistent zur Durchf�hrung von Produktiv-Sites-Analysen";
            this.tcWizard.ResumeLayout(false);
            this.TabBase.ResumeLayout(false);
            this.TabBase.PerformLayout();
            this.Tab2Period.ResumeLayout(false);
            this.Tab2Period.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudAltShiftDays).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudAltShift2).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudAltShift1).EndInit();
            this.Tab3SelectWorkgroups.ResumeLayout(false);
            this.Tab3SelectWorkgroups.PerformLayout();
            this.Tab4TypeOfAnalysis.ResumeLayout(false);
            this.Tab4TypeOfAnalysis.PerformLayout();
            this.Tab5AnalysisDestination.ResumeLayout(false);
            this.Tab5AnalysisDestination.PerformLayout();
            this.Tab6ExcelExport.ResumeLayout(false);
            this.Tab6ExcelExport.PerformLayout();
            this.Tab8Finalize.ResumeLayout(false);
            this.Tab8Finalize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.TabControl tcWizard;
        internal System.Windows.Forms.TabPage TabBase;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TabPage Tab2Period;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.TabPage Tab3SelectWorkgroups;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.TabPage Tab4TypeOfAnalysis;
        internal System.Windows.Forms.Label Label37;
        internal System.Windows.Forms.TabPage Tab5AnalysisDestination;
        internal System.Windows.Forms.TabPage Tab6ExcelExport;
        internal System.Windows.Forms.TabPage Tab8Finalize;
        internal System.Windows.Forms.Label Label35;
        internal System.Windows.Forms.Label Label34;
        internal System.Windows.Forms.Label Label33;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnNext;
        internal System.Windows.Forms.Button btnBack;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal Facesso.GenericControls.ucAnalysisDateRangePicker drpMain;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.RadioButton optUseAlternatingShifts;
        internal System.Windows.Forms.RadioButton optUseShifts;
        internal System.Windows.Forms.CheckBox chkShift4;
        internal System.Windows.Forms.CheckBox chkShift3;
        internal System.Windows.Forms.CheckBox chkShift2;
        internal System.Windows.Forms.CheckBox chkShift1;
        private System.Windows.Forms.Button _btnAllShifts;
        internal System.Windows.Forms.Button btnAllShifts
        {
            get
            {
                return _btnAllShifts;
            }

            set
            {
                if (_btnAllShifts != null)
                {
                    _btnAllShifts.Click -= btnAllShifts_Click;
                }

                _btnAllShifts = value;
                if (_btnAllShifts != null)
                {
                    _btnAllShifts.Click += btnAllShifts_Click;
                }
            }
        }

        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.NumericUpDown nudAltShift2;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.NumericUpDown nudAltShift1;
        internal System.Windows.Forms.Button btnUnSelectWorkGroups;
        internal System.Windows.Forms.Button btnSelectAllWorkGroups;
        internal Facesso.GenericControls.ucWorkGroupListView wglWorkGroups;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.CheckBox chkIncludeSuspended;
        internal System.Windows.Forms.Button btnAllWorkGroupsInCostCenter;
        internal System.Windows.Forms.NumericUpDown nudAltShiftDays;
        internal System.Windows.Forms.TextBox txtConclusion;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.RadioButton optDetailed;
        internal System.Windows.Forms.RadioButton optAnalysisLine;
        internal System.Windows.Forms.RadioButton optWorkGroupListShiftCondensed;
        internal System.Windows.Forms.RadioButton optBatch;
        internal System.Windows.Forms.Button btnSelectExportFile;
        internal System.Windows.Forms.Label lblExportFilename;
        internal System.Windows.Forms.RadioButton optCSVExport;
        internal System.Windows.Forms.RadioButton optPreviewBeforePrint;
        internal System.Windows.Forms.RadioButton optTargetPrinter;
        internal System.Windows.Forms.Label Label27;
        internal System.Windows.Forms.ListBox lstDestFields;
        internal System.Windows.Forms.Button btnRemoveAllFields;
        internal System.Windows.Forms.Button btnRemoveField;
        internal System.Windows.Forms.Button btnAddField;
        internal System.Windows.Forms.Button btnAddAllFields;
        internal System.Windows.Forms.ListBox lstSourceFields;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.RadioButton optWorkGroupListShiftWise;
        internal System.Windows.Forms.Label lblDescription;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.RadioButton optWorkGroupListShiftwiseCompressed;
    }
}