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
    public partial class frmWorkgroupChartParametersPicker : System.Windows.Forms.Form
    {
        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorkgroupChartParametersPicker));
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.optPickedSites = new System.Windows.Forms.RadioButton();
            this.Label2 = new System.Windows.Forms.Label();
            this.optWorst = new System.Windows.Forms.RadioButton();
            this.optBest = new System.Windows.Forms.RadioButton();
            this.nivBestWorstCount = new ActiveDevelop.EntitiesFormsLib.NullableIntValue();
            this.wglWorkgroups = new Facesso.GenericControls.ucWorkGroupListView();
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.btnResetDeltaValues = new System.Windows.Forms.Button();
            this.chkAutomaticTimeOfDegreeRange = new System.Windows.Forms.CheckBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.tbDegreeOfTimeFrom = new System.Windows.Forms.TrackBar();
            this.txtTimeOfDegreeRangeTo = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.tbDegreeOfTimeTo = new System.Windows.Forms.TrackBar();
            this.txtTimeOfDegreeRangeFrom = new System.Windows.Forms.TextBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.opt3DChart = new System.Windows.Forms.RadioButton();
            this.opt2DChart = new System.Windows.Forms.RadioButton();
            this.txtChartTitel = new System.Windows.Forms.TextBox();
            this.drpMain = new Facesso.GenericControls.ucAnalysisDateRangePicker();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudAltShiftDays).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudAltShift2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudAltShift1).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.tbDegreeOfTimeFrom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.tbDegreeOfTimeTo).BeginInit();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
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
            this.GroupBox1.Location = new System.Drawing.Point(360, 13);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(272, 305);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Schichten:";
            //
            //Label13
            //
            this.Label13.Location = new System.Drawing.Point(11, 242);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(255, 53);
            this.Label13.TabIndex = 16;
            this.Label13.Text = "Wählen Sie diesen Schichttyp, wenn Mitarbeiter beispielsweise in der ersten Woche" + " in Schicht 1, in der zweiten in Schicht 2, in der dritten wieder in Schicht 1 u" + "sw. arbeiten.";
            //
            //nudAltShiftDays
            //
            this.nudAltShiftDays.Location = new System.Drawing.Point(54, 157);
            this.nudAltShiftDays.Maximum = new decimal (new int[] { 31, 0, 0, 0 });
            this.nudAltShiftDays.Minimum = new decimal (new int[] { 1, 0, 0, 0 });
            this.nudAltShiftDays.Name = "nudAltShiftDays";
            this.nudAltShiftDays.Size = new System.Drawing.Size(34, 20);
            this.nudAltShiftDays.TabIndex = 7;
            this.nudAltShiftDays.Value = new decimal (new int[] { 7, 0, 0, 0 });
            //
            //btnAllShifts
            //
            this.btnAllShifts.Location = new System.Drawing.Point(163, 44);
            this.btnAllShifts.Name = "btnAllShifts";
            this.btnAllShifts.Size = new System.Drawing.Size(68, 23);
            this.btnAllShifts.TabIndex = 15;
            this.btnAllShifts.Text = "Alle";
            this.btnAllShifts.UseVisualStyleBackColor = true;
            //
            //Label9
            //
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(107, 214);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(55, 13);
            this.Label9.TabIndex = 14;
            this.Label9.Text = "wechseln.";
            //
            //nudAltShift2
            //
            this.nudAltShift2.Location = new System.Drawing.Point(67, 211);
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
            this.Label10.Location = new System.Drawing.Point(19, 214);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(43, 13);
            this.Label10.TabIndex = 12;
            this.Label10.Text = "Schicht";
            //
            //Label8
            //
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(106, 188);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(25, 13);
            this.Label8.TabIndex = 11;
            this.Label8.Text = "und";
            //
            //nudAltShift1
            //
            this.nudAltShift1.Location = new System.Drawing.Point(66, 185);
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
            this.Label7.Location = new System.Drawing.Point(18, 188);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(43, 13);
            this.Label7.TabIndex = 9;
            this.Label7.Text = "Schicht";
            //
            //Label5
            //
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(94, 159);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(79, 13);
            this.Label5.TabIndex = 8;
            this.Label5.Text = "Tage zwischen";
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(18, 160);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(24, 13);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Alle";
            //
            //optUseAlternatingShifts
            //
            this.optUseAlternatingShifts.AutoSize = true;
            this.optUseAlternatingShifts.Location = new System.Drawing.Point(7, 139);
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
            //btnOK
            //
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(638, 28);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 28);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //btnCancel
            //
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(638, 58);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            //GroupBox2
            //
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.optPickedSites);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.optWorst);
            this.GroupBox2.Controls.Add(this.optBest);
            this.GroupBox2.Controls.Add(this.nivBestWorstCount);
            this.GroupBox2.Controls.Add(this.wglWorkgroups);
            this.GroupBox2.Location = new System.Drawing.Point(12, 327);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(345, 343);
            this.GroupBox2.TabIndex = 7;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Produktiv-Sites:";
            //
            //Label3
            //
            this.Label3.Location = new System.Drawing.Point(6, 288);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(322, 43);
            this.Label3.TabIndex = 17;
            this.Label3.Text = "HINWEIS: Wählen Sie MEHRERE Schichten, aber nur EINE Produktiv-Site aus, erstellt" + " Facesso ein Schichtvergleich-Diagramm über die entsprechende Arbeitsgruppe.";
            //
            //optPickedSites
            //
            this.optPickedSites.AutoSize = true;
            this.optPickedSites.Location = new System.Drawing.Point(9, 62);
            this.optPickedSites.Name = "optPickedSites";
            this.optPickedSites.Size = new System.Drawing.Size(237, 17);
            this.optPickedSites.TabIndex = 13;
            this.optPickedSites.Text = "Die folgenden ausgewählten Produktiv-Sites:";
            this.optPickedSites.UseVisualStyleBackColor = true;
            //
            //Label2
            //
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(19, 36);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(23, 13);
            this.Label2.TabIndex = 12;
            this.Label2.Text = "Die";
            //
            //optWorst
            //
            this.optWorst.AutoSize = true;
            this.optWorst.Location = new System.Drawing.Point(175, 34);
            this.optWorst.Name = "optWorst";
            this.optWorst.Size = new System.Drawing.Size(91, 17);
            this.optWorst.TabIndex = 11;
            this.optWorst.Text = "schlechtesten";
            this.optWorst.UseVisualStyleBackColor = true;
            //
            //optBest
            //
            this.optBest.AutoSize = true;
            this.optBest.Checked = true;
            this.optBest.Location = new System.Drawing.Point(111, 34);
            this.optBest.Name = "optBest";
            this.optBest.Size = new System.Drawing.Size(57, 17);
            this.optBest.TabIndex = 10;
            this.optBest.TabStop = true;
            this.optBest.Text = "besten";
            this.optBest.UseVisualStyleBackColor = true;
            //
            //nivBestWorstCount
            //
            this.nivBestWorstCount.AssignedManagerComponent = null;
            this.nivBestWorstCount.Borderstyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nivBestWorstCount.ContentPresentPermission = ActiveDevelop.EntitiesFormsLib.ContentPresentPermissions.Normal;
            this.nivBestWorstCount.Location = new System.Drawing.Point(56, 33);
            this.nivBestWorstCount.MaxLength = 32767;
            this.nivBestWorstCount.Name = "nivBestWorstCount";
            this.nivBestWorstCount.ObfuscationChar = null;
            this.nivBestWorstCount.PermissionReason = null;
            this.nivBestWorstCount.Size = new System.Drawing.Size(41, 20);
            this.nivBestWorstCount.TabIndex = 9;
            this.nivBestWorstCount.UIGuid = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.nivBestWorstCount.Value = 5;
            //
            //wglWorkgroups
            //
            this.wglWorkgroups.AutoGroup = true;
            this.wglWorkgroups.Enabled = false;
            this.wglWorkgroups.FullRowSelect = true;
            this.wglWorkgroups.HideSelection = false;
            this.wglWorkgroups.Location = new System.Drawing.Point(9, 88);
            this.wglWorkgroups.Name = "wglWorkgroups";
            this.wglWorkgroups.OnlyActiveWorkgroups = true;
            this.wglWorkgroups.Size = new System.Drawing.Size(319, 192);
            this.wglWorkgroups.TabIndex = 8;
            this.wglWorkgroups.UseCompatibleStateImageBehavior = false;
            this.wglWorkgroups.View = System.Windows.Forms.View.Details;
            this.wglWorkgroups.WorkGroupInfoItems = null;
            this.wglWorkgroups.WorkGroupSortOrder = Facesso.GenericControls.WorkGroupSortOrder.WorkGroupNumber;
            //
            //Label4
            //
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 33);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(58, 13);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Chart-Titel:";
            //
            //GroupBox3
            //
            this.GroupBox3.Controls.Add(this.GroupBox5);
            this.GroupBox3.Controls.Add(this.GroupBox4);
            this.GroupBox3.Controls.Add(this.txtChartTitel);
            this.GroupBox3.Controls.Add(this.Label4);
            this.GroupBox3.Location = new System.Drawing.Point(360, 327);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(272, 343);
            this.GroupBox3.TabIndex = 9;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Chart-Parameter:";
            //
            //GroupBox5
            //
            this.GroupBox5.Controls.Add(this.btnResetDeltaValues);
            this.GroupBox5.Controls.Add(this.chkAutomaticTimeOfDegreeRange);
            this.GroupBox5.Controls.Add(this.Label11);
            this.GroupBox5.Controls.Add(this.tbDegreeOfTimeFrom);
            this.GroupBox5.Controls.Add(this.txtTimeOfDegreeRangeTo);
            this.GroupBox5.Controls.Add(this.Label6);
            this.GroupBox5.Controls.Add(this.tbDegreeOfTimeTo);
            this.GroupBox5.Controls.Add(this.txtTimeOfDegreeRangeFrom);
            this.GroupBox5.Location = new System.Drawing.Point(12, 180);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(254, 156);
            this.GroupBox5.TabIndex = 12;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Zeitgrad-Bereich im Chart:";
            this.GroupBox5.Visible = false;
            //
            //btnResetDeltaValues
            //
            this.btnResetDeltaValues.Location = new System.Drawing.Point(167, 130);
            this.btnResetDeltaValues.Name = "btnResetDeltaValues";
            this.btnResetDeltaValues.Size = new System.Drawing.Size(81, 20);
            this.btnResetDeltaValues.TabIndex = 7;
            this.btnResetDeltaValues.Text = "&Zurücksetzen";
            this.btnResetDeltaValues.UseVisualStyleBackColor = true;
            //
            //chkAutomaticTimeOfDegreeRange
            //
            this.chkAutomaticTimeOfDegreeRange.AutoSize = true;
            this.chkAutomaticTimeOfDegreeRange.Location = new System.Drawing.Point(34, 22);
            this.chkAutomaticTimeOfDegreeRange.Name = "chkAutomaticTimeOfDegreeRange";
            this.chkAutomaticTimeOfDegreeRange.Size = new System.Drawing.Size(83, 17);
            this.chkAutomaticTimeOfDegreeRange.TabIndex = 6;
            this.chkAutomaticTimeOfDegreeRange.Text = "automatisch";
            this.chkAutomaticTimeOfDegreeRange.UseVisualStyleBackColor = true;
            //
            //Label11
            //
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(7, 87);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(23, 13);
            this.Label11.TabIndex = 5;
            this.Label11.Text = "bis:";
            //
            //tbDegreeOfTimeFrom
            //
            this.tbDegreeOfTimeFrom.Location = new System.Drawing.Point(48, 49);
            this.tbDegreeOfTimeFrom.Maximum = 100;
            this.tbDegreeOfTimeFrom.Minimum = 20;
            this.tbDegreeOfTimeFrom.Name = "tbDegreeOfTimeFrom";
            this.tbDegreeOfTimeFrom.Size = new System.Drawing.Size(200, 45);
            this.tbDegreeOfTimeFrom.TabIndex = 4;
            this.tbDegreeOfTimeFrom.Value = 80;
            //
            //txtTimeOfDegreeRangeTo
            //
            this.txtTimeOfDegreeRangeTo.Location = new System.Drawing.Point(10, 103);
            this.txtTimeOfDegreeRangeTo.Name = "txtTimeOfDegreeRangeTo";
            this.txtTimeOfDegreeRangeTo.ReadOnly = true;
            this.txtTimeOfDegreeRangeTo.Size = new System.Drawing.Size(32, 20);
            this.txtTimeOfDegreeRangeTo.TabIndex = 3;
            this.txtTimeOfDegreeRangeTo.Text = "140";
            //
            //Label6
            //
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(7, 44);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(28, 13);
            this.Label6.TabIndex = 2;
            this.Label6.Text = "von:";
            //
            //tbDegreeOfTimeTo
            //
            this.tbDegreeOfTimeTo.LargeChange = 10;
            this.tbDegreeOfTimeTo.Location = new System.Drawing.Point(48, 94);
            this.tbDegreeOfTimeTo.Maximum = 200;
            this.tbDegreeOfTimeTo.Minimum = 80;
            this.tbDegreeOfTimeTo.Name = "tbDegreeOfTimeTo";
            this.tbDegreeOfTimeTo.Size = new System.Drawing.Size(200, 45);
            this.tbDegreeOfTimeTo.SmallChange = 5;
            this.tbDegreeOfTimeTo.TabIndex = 1;
            this.tbDegreeOfTimeTo.Value = 140;
            //
            //txtTimeOfDegreeRangeFrom
            //
            this.txtTimeOfDegreeRangeFrom.Location = new System.Drawing.Point(10, 60);
            this.txtTimeOfDegreeRangeFrom.Name = "txtTimeOfDegreeRangeFrom";
            this.txtTimeOfDegreeRangeFrom.ReadOnly = true;
            this.txtTimeOfDegreeRangeFrom.Size = new System.Drawing.Size(32, 20);
            this.txtTimeOfDegreeRangeFrom.TabIndex = 0;
            this.txtTimeOfDegreeRangeFrom.Text = "80";
            //
            //GroupBox4
            //
            this.GroupBox4.Controls.Add(this.opt3DChart);
            this.GroupBox4.Controls.Add(this.opt2DChart);
            this.GroupBox4.Location = new System.Drawing.Point(12, 94);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(254, 70);
            this.GroupBox4.TabIndex = 10;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Chart-Typ:";
            this.GroupBox4.Visible = false;
            //
            //opt3DChart
            //
            this.opt3DChart.AutoSize = true;
            this.opt3DChart.Location = new System.Drawing.Point(9, 42);
            this.opt3DChart.Name = "opt3DChart";
            this.opt3DChart.Size = new System.Drawing.Size(98, 17);
            this.opt3DChart.TabIndex = 13;
            this.opt3DChart.Text = "3D-Linien-Chart";
            this.opt3DChart.UseVisualStyleBackColor = true;
            //
            //opt2DChart
            //
            this.opt2DChart.AutoSize = true;
            this.opt2DChart.Checked = true;
            this.opt2DChart.Location = new System.Drawing.Point(9, 19);
            this.opt2DChart.Name = "opt2DChart";
            this.opt2DChart.Size = new System.Drawing.Size(98, 17);
            this.opt2DChart.TabIndex = 12;
            this.opt2DChart.TabStop = true;
            this.opt2DChart.Text = "2D-Linien-Chart";
            this.opt2DChart.UseVisualStyleBackColor = true;
            //
            //txtChartTitel
            //
            this.txtChartTitel.Location = new System.Drawing.Point(6, 49);
            this.txtChartTitel.Name = "txtChartTitel";
            this.txtChartTitel.Size = new System.Drawing.Size(260, 20);
            this.txtChartTitel.TabIndex = 9;
            this.txtChartTitel.Text = "Arbeitsgruppen-Charting";
            //
            //drpMain
            //
            this.drpMain.LastWorkingday = Facesso.Data.LastWorkingdays.Friday;
            this.drpMain.Location = new System.Drawing.Point(12, 12);
            this.drpMain.Name = "drpMain";
            this.drpMain.Size = new System.Drawing.Size(346, 318);
            this.drpMain.TabIndex = 3;
            this.drpMain.Text = "Zeitbereich der Produktiv-Site-Analyse:";
            //
            //frmWorkgroupChartParametersPicker
            //
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(748, 675);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.drpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
            this.Name = "frmWorkgroupChartParametersPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bearbeiten der Chart-Auswertungsparameter";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudAltShiftDays).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudAltShift2).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudAltShift1).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.tbDegreeOfTimeFrom).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.tbDegreeOfTimeTo).EndInit();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.NumericUpDown nudAltShiftDays;
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
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.RadioButton optUseAlternatingShifts;
        internal System.Windows.Forms.RadioButton optUseShifts;
        internal System.Windows.Forms.CheckBox chkShift4;
        internal System.Windows.Forms.CheckBox chkShift3;
        internal System.Windows.Forms.CheckBox chkShift2;
        internal System.Windows.Forms.CheckBox chkShift1;
        internal Facesso.GenericControls.ucAnalysisDateRangePicker drpMain;
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

        private System.Windows.Forms.Button _btnCancel;
        internal System.Windows.Forms.Button btnCancel
        {
            get
            {
                return _btnCancel;
            }

            set
            {
                if (_btnCancel != null)
                {
                    _btnCancel.Click -= btnCancel_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click;
                }
            }
        }

        internal System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.RadioButton _optWorst;
        internal System.Windows.Forms.RadioButton optWorst
        {
            get
            {
                return _optWorst;
            }

            set
            {
                if (_optWorst != null)
                {
                    _optWorst.CheckedChanged -= rbWorst_CheckedChanged;
                }

                _optWorst = value;
                if (_optWorst != null)
                {
                    _optWorst.CheckedChanged += rbWorst_CheckedChanged;
                }
            }
        }

        private System.Windows.Forms.RadioButton _optBest;
        internal System.Windows.Forms.RadioButton optBest
        {
            get
            {
                return _optBest;
            }

            set
            {
                if (_optBest != null)
                {
                    _optBest.CheckedChanged -= rbBest_CheckedChanged;
                }

                _optBest = value;
                if (_optBest != null)
                {
                    _optBest.CheckedChanged += rbBest_CheckedChanged;
                }
            }
        }

        internal ActiveDevelop.EntitiesFormsLib.NullableIntValue nivBestWorstCount;
        internal Facesso.GenericControls.ucWorkGroupListView wglWorkgroups;
        private System.Windows.Forms.RadioButton _optPickedSites;
        internal System.Windows.Forms.RadioButton optPickedSites
        {
            get
            {
                return _optPickedSites;
            }

            set
            {
                if (_optPickedSites != null)
                {
                    _optPickedSites.CheckedChanged -= rbPickedSites_CheckedChanged;
                }

                _optPickedSites = value;
                if (_optPickedSites != null)
                {
                    _optPickedSites.CheckedChanged += rbPickedSites_CheckedChanged;
                }
            }
        }

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.GroupBox GroupBox5;
        private System.Windows.Forms.CheckBox _chkAutomaticTimeOfDegreeRange;
        internal System.Windows.Forms.CheckBox chkAutomaticTimeOfDegreeRange
        {
            get
            {
                return _chkAutomaticTimeOfDegreeRange;
            }

            set
            {
                if (_chkAutomaticTimeOfDegreeRange != null)
                {
                    _chkAutomaticTimeOfDegreeRange.CheckedChanged -= chkAutomaticTimeOfDegreeRange_CheckedChanged;
                }

                _chkAutomaticTimeOfDegreeRange = value;
                if (_chkAutomaticTimeOfDegreeRange != null)
                {
                    _chkAutomaticTimeOfDegreeRange.CheckedChanged += chkAutomaticTimeOfDegreeRange_CheckedChanged;
                }
            }
        }

        internal System.Windows.Forms.Label Label11;
        private System.Windows.Forms.TrackBar _tbDegreeOfTimeFrom;
        internal System.Windows.Forms.TrackBar tbDegreeOfTimeFrom
        {
            get
            {
                return _tbDegreeOfTimeFrom;
            }

            set
            {
                if (_tbDegreeOfTimeFrom != null)
                {
                    _tbDegreeOfTimeFrom.Scroll -= tbDegreeOfTimeFrom_Scroll;
                }

                _tbDegreeOfTimeFrom = value;
                if (_tbDegreeOfTimeFrom != null)
                {
                    _tbDegreeOfTimeFrom.Scroll += tbDegreeOfTimeFrom_Scroll;
                }
            }
        }

        internal System.Windows.Forms.TextBox txtTimeOfDegreeRangeTo;
        internal System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TrackBar _tbDegreeOfTimeTo;
        internal System.Windows.Forms.TrackBar tbDegreeOfTimeTo
        {
            get
            {
                return _tbDegreeOfTimeTo;
            }

            set
            {
                if (_tbDegreeOfTimeTo != null)
                {
                    _tbDegreeOfTimeTo.Scroll -= tbDegreeOfTimeTo_Scroll;
                }

                _tbDegreeOfTimeTo = value;
                if (_tbDegreeOfTimeTo != null)
                {
                    _tbDegreeOfTimeTo.Scroll += tbDegreeOfTimeTo_Scroll;
                }
            }
        }

        internal System.Windows.Forms.TextBox txtTimeOfDegreeRangeFrom;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.RadioButton opt3DChart;
        internal System.Windows.Forms.RadioButton opt2DChart;
        private System.Windows.Forms.TextBox _txtChartTitel;
        internal System.Windows.Forms.TextBox txtChartTitel
        {
            get
            {
                return _txtChartTitel;
            }

            set
            {
                if (_txtChartTitel != null)
                {
                    _txtChartTitel.TextChanged -= txtChartTitel_TextChanged;
                }

                _txtChartTitel = value;
                if (_txtChartTitel != null)
                {
                    _txtChartTitel.TextChanged += txtChartTitel_TextChanged;
                }
            }
        }

        private System.Windows.Forms.Button _btnResetDeltaValues;
        internal System.Windows.Forms.Button btnResetDeltaValues
        {
            get
            {
                return _btnResetDeltaValues;
            }

            set
            {
                if (_btnResetDeltaValues != null)
                {
                    _btnResetDeltaValues.Click -= btnResetDeltaValues_Click;
                }

                _btnResetDeltaValues = value;
                if (_btnResetDeltaValues != null)
                {
                    _btnResetDeltaValues.Click += btnResetDeltaValues_Click;
                }
            }
        }
    }
}