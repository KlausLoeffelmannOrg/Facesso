using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.GenericControls
{
    public partial class ucTimeDetailsSettings : System.Windows.Forms.UserControl
    {
        //UserControl overrides dispose to clean up the component list.
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
            this.Panel2 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblShiftInformer = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.lblImportEndTimeDateDescription = new System.Windows.Forms.Label();
            this.ndbImportTimeStart = new ActiveDev.Controls.ADNullableDateTimeBox();
            this.ndbImportTimeEnd = new ActiveDev.Controls.ADNullableDateTimeBox();
            this.lbTimes = new System.Windows.Forms.ListBox();
            this.btnEndDate = new System.Windows.Forms.Button();
            this.btnStartDate = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.btnWD_07_Sunday = new System.Windows.Forms.Button();
            this.btnWD_06_Saturday = new System.Windows.Forms.Button();
            this.btnWD_05_Friday = new System.Windows.Forms.Button();
            this.btnWD_04_Thursday = new System.Windows.Forms.Button();
            this.btnWD_03_Wednesday = new System.Windows.Forms.Button();
            this.btnWD_02_Tuesday = new System.Windows.Forms.Button();
            this.btnWD_01_Monday = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnGeneric = new System.Windows.Forms.Button();
            this.ncbForceToHavePause = new ActiveDev.Controls.ADNullableCheckBox();
            this.nibThreshold = new ActiveDev.Controls.ADNullableIntBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.ndbRoundDownAfter = new ActiveDev.Controls.ADNullableDateTimeBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.ndbRoundUpBefore = new ActiveDev.Controls.ADNullableDateTimeBox();
            this.nibPausetime = new ActiveDev.Controls.ADNullableIntBox();
            this.lblEndTimeDateDecription = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.ndbCoreTimeStart = new ActiveDev.Controls.ADNullableDateTimeBox();
            this.ndbCoreTimeEnd = new ActiveDev.Controls.ADNullableDateTimeBox();
            this.tcShifts = new System.Windows.Forms.TabControl();
            this.tpShift1 = new System.Windows.Forms.TabPage();
            this.tpShift2 = new System.Windows.Forms.TabPage();
            this.tpShift3 = new System.Windows.Forms.TabPage();
            this.tpShift4 = new System.Windows.Forms.TabPage();
            this.Panel2.SuspendLayout();
            this.tcShifts.SuspendLayout();
            this.SuspendLayout();
            //
            //Panel2
            //
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel2.Controls.Add(this.btnReset);
            this.Panel2.Controls.Add(this.lblShiftInformer);
            this.Panel2.Controls.Add(this.Label7);
            this.Panel2.Controls.Add(this.lblImportEndTimeDateDescription);
            this.Panel2.Controls.Add(this.ndbImportTimeStart);
            this.Panel2.Controls.Add(this.ndbImportTimeEnd);
            this.Panel2.Controls.Add(this.lbTimes);
            this.Panel2.Controls.Add(this.btnEndDate);
            this.Panel2.Controls.Add(this.btnStartDate);
            this.Panel2.Controls.Add(this.Label6);
            this.Panel2.Controls.Add(this.btnWD_07_Sunday);
            this.Panel2.Controls.Add(this.btnWD_06_Saturday);
            this.Panel2.Controls.Add(this.btnWD_05_Friday);
            this.Panel2.Controls.Add(this.btnWD_04_Thursday);
            this.Panel2.Controls.Add(this.btnWD_03_Wednesday);
            this.Panel2.Controls.Add(this.btnWD_02_Tuesday);
            this.Panel2.Controls.Add(this.btnWD_01_Monday);
            this.Panel2.Controls.Add(this.Label5);
            this.Panel2.Controls.Add(this.btnGeneric);
            this.Panel2.Controls.Add(this.ncbForceToHavePause);
            this.Panel2.Controls.Add(this.nibThreshold);
            this.Panel2.Controls.Add(this.Label4);
            this.Panel2.Controls.Add(this.ndbRoundDownAfter);
            this.Panel2.Controls.Add(this.Label3);
            this.Panel2.Controls.Add(this.ndbRoundUpBefore);
            this.Panel2.Controls.Add(this.nibPausetime);
            this.Panel2.Controls.Add(this.lblEndTimeDateDecription);
            this.Panel2.Controls.Add(this.Label2);
            this.Panel2.Controls.Add(this.ndbCoreTimeStart);
            this.Panel2.Controls.Add(this.ndbCoreTimeEnd);
            this.Panel2.Location = new System.Drawing.Point(0, 27);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(567, 445);
            this.Panel2.TabIndex = 1;
            //
            //btnReset
            //
            this.btnReset.Location = new System.Drawing.Point(496, 25);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(61, 24);
            this.btnReset.TabIndex = 35;
            this.btnReset.Text = "Reset...";
            this.btnReset.UseVisualStyleBackColor = true;
            //
            //lblShiftInformer
            //
            this.lblShiftInformer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblShiftInformer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblShiftInformer.Location = new System.Drawing.Point(19, 55);
            this.lblShiftInformer.Name = "lblShiftInformer";
            this.lblShiftInformer.Size = new System.Drawing.Size(169, 22);
            this.lblShiftInformer.TabIndex = 34;
            this.lblShiftInformer.Text = "für Schicht 1";
            this.lblShiftInformer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //Label7
            //
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label7.Location = new System.Drawing.Point(20, 162);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(150, 13);
            this.Label7.TabIndex = 33;
            this.Label7.Text = "(Abweichend für Datenimport:)";
            //
            //lblImportEndTimeDateDescription
            //
            this.lblImportEndTimeDateDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblImportEndTimeDateDescription.Location = new System.Drawing.Point(445, 182);
            this.lblImportEndTimeDateDescription.Name = "lblImportEndTimeDateDescription";
            this.lblImportEndTimeDateDescription.Size = new System.Drawing.Size(94, 17);
            this.lblImportEndTimeDateDescription.TabIndex = 6;
            this.lblImportEndTimeDateDescription.Text = "(Der Folgetag)";
            this.lblImportEndTimeDateDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            //ndbImportTimeStart
            //
            this.ndbImportTimeStart.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime;
            this.ndbImportTimeStart.BackColor = System.Drawing.SystemColors.Window;
            this.ndbImportTimeStart.CaptionToValueRatio = 601.35;
            this.ndbImportTimeStart.ColorOnFocus = true;
            this.ndbImportTimeStart.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime;
            this.ndbImportTimeStart.FailedValidationErrorMessage = "Falsches Datumsformat|Sie haben ein ungültiges Datumsformat eingegeben. Bitte kor" + "rigieren Sie Ihre Eingabe!";
            this.ndbImportTimeStart.HasCaption = true;
            this.ndbImportTimeStart.IndependentDatafieldName = null;
            this.ndbImportTimeStart.Location = new System.Drawing.Point(22, 177);
            this.ndbImportTimeStart.Name = "ndbImportTimeStart";
            this.ndbImportTimeStart.NullString = "* --- *";
            this.ndbImportTimeStart.NullValueMessage = null;
            this.ndbImportTimeStart.Size = new System.Drawing.Size(296, 22);
            this.ndbImportTimeStart.TabIndex = 4;
            this.ndbImportTimeStart.Text = "Schicht Beginn/Ende:";
            this.ndbImportTimeStart.ValueAreaLength = 118;
            //
            //ndbImportTimeEnd
            //
            this.ndbImportTimeEnd.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime;
            this.ndbImportTimeEnd.BackColor = System.Drawing.SystemColors.Window;
            this.ndbImportTimeEnd.CaptionToValueRatio = 0;
            this.ndbImportTimeEnd.ColorOnFocus = true;
            this.ndbImportTimeEnd.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime;
            this.ndbImportTimeEnd.FailedValidationErrorMessage = "Falsches Datumsformat|Sie haben ein ungültiges Datumsformat eingegeben. Bitte kor" + "rigieren Sie Ihre Eingabe!";
            this.ndbImportTimeEnd.HasCaption = false;
            this.ndbImportTimeEnd.IndependentDatafieldName = null;
            this.ndbImportTimeEnd.Location = new System.Drawing.Point(324, 177);
            this.ndbImportTimeEnd.Name = "ndbImportTimeEnd";
            this.ndbImportTimeEnd.NullString = "* --- *";
            this.ndbImportTimeEnd.NullValueMessage = null;
            this.ndbImportTimeEnd.Size = new System.Drawing.Size(118, 22);
            this.ndbImportTimeEnd.TabIndex = 5;
            this.ndbImportTimeEnd.Text = "Schicht-1-Kernzeiten: Beginn/Ende:";
            this.ndbImportTimeEnd.ValueAreaLength = 118;
            //
            //lbTimes
            //
            this.lbTimes.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lbTimes.FormattingEnabled = true;
            this.lbTimes.HorizontalScrollbar = true;
            this.lbTimes.ItemHeight = 14;
            this.lbTimes.Location = new System.Drawing.Point(23, 347);
            this.lbTimes.Name = "lbTimes";
            this.lbTimes.Size = new System.Drawing.Size(534, 88);
            this.lbTimes.TabIndex = 14;
            //
            //btnEndDate
            //
            this.btnEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.btnEndDate.Location = new System.Drawing.Point(320, 108);
            this.btnEndDate.Name = "btnEndDate";
            this.btnEndDate.Size = new System.Drawing.Size(119, 23);
            this.btnEndDate.TabIndex = 12;
            this.btnEndDate.Text = "(Datum)";
            //
            //btnStartDate
            //
            this.btnStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.btnStartDate.Location = new System.Drawing.Point(196, 108);
            this.btnStartDate.Name = "btnStartDate";
            this.btnStartDate.Size = new System.Drawing.Size(119, 23);
            this.btnStartDate.TabIndex = 11;
            this.btnStartDate.Text = "(Datum)";
            //
            //Label6
            //
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label6.Location = new System.Drawing.Point(220, 55);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(300, 33);
            this.Label6.TabIndex = 9;
            this.Label6.Text = "HINWEIS: Tage ohne eigene Definition (nicht fett markiert), erben automatisch die" + " Einstellungen von [für alle Wochentage]!";
            //
            //btnWD_07_Sunday
            //
            this.btnWD_07_Sunday.Location = new System.Drawing.Point(443, 25);
            this.btnWD_07_Sunday.Name = "btnWD_07_Sunday";
            this.btnWD_07_Sunday.Size = new System.Drawing.Size(38, 25);
            this.btnWD_07_Sunday.TabIndex = 23;
            this.btnWD_07_Sunday.Text = "So";
            //
            //btnWD_06_Saturday
            //
            this.btnWD_06_Saturday.Location = new System.Drawing.Point(406, 25);
            this.btnWD_06_Saturday.Name = "btnWD_06_Saturday";
            this.btnWD_06_Saturday.Size = new System.Drawing.Size(38, 25);
            this.btnWD_06_Saturday.TabIndex = 22;
            this.btnWD_06_Saturday.Text = "Sa";
            //
            //btnWD_05_Friday
            //
            this.btnWD_05_Friday.Location = new System.Drawing.Point(369, 25);
            this.btnWD_05_Friday.Name = "btnWD_05_Friday";
            this.btnWD_05_Friday.Size = new System.Drawing.Size(38, 25);
            this.btnWD_05_Friday.TabIndex = 21;
            this.btnWD_05_Friday.Text = "Fr";
            //
            //btnWD_04_Thursday
            //
            this.btnWD_04_Thursday.Location = new System.Drawing.Point(332, 25);
            this.btnWD_04_Thursday.Name = "btnWD_04_Thursday";
            this.btnWD_04_Thursday.Size = new System.Drawing.Size(38, 25);
            this.btnWD_04_Thursday.TabIndex = 20;
            this.btnWD_04_Thursday.Text = "Do";
            //
            //btnWD_03_Wednesday
            //
            this.btnWD_03_Wednesday.Location = new System.Drawing.Point(295, 25);
            this.btnWD_03_Wednesday.Name = "btnWD_03_Wednesday";
            this.btnWD_03_Wednesday.Size = new System.Drawing.Size(38, 25);
            this.btnWD_03_Wednesday.TabIndex = 19;
            this.btnWD_03_Wednesday.Text = "Mi";
            //
            //btnWD_02_Tuesday
            //
            this.btnWD_02_Tuesday.Location = new System.Drawing.Point(258, 25);
            this.btnWD_02_Tuesday.Name = "btnWD_02_Tuesday";
            this.btnWD_02_Tuesday.Size = new System.Drawing.Size(38, 25);
            this.btnWD_02_Tuesday.TabIndex = 18;
            this.btnWD_02_Tuesday.Text = "Di";
            //
            //btnWD_01_Monday
            //
            this.btnWD_01_Monday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.btnWD_01_Monday.Location = new System.Drawing.Point(221, 25);
            this.btnWD_01_Monday.Name = "btnWD_01_Monday";
            this.btnWD_01_Monday.Size = new System.Drawing.Size(38, 25);
            this.btnWD_01_Monday.TabIndex = 17;
            this.btnWD_01_Monday.Text = "Mo";
            //
            //Label5
            //
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(201, 29);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(25, 16);
            this.Label5.TabIndex = 16;
            this.Label5.Text = "für:";
            //
            //btnGeneric
            //
            this.btnGeneric.BackColor = System.Drawing.Color.Yellow;
            this.btnGeneric.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.btnGeneric.Location = new System.Drawing.Point(19, 25);
            this.btnGeneric.Name = "btnGeneric";
            this.btnGeneric.Size = new System.Drawing.Size(174, 25);
            this.btnGeneric.TabIndex = 15;
            this.btnGeneric.Text = "Für alle Wochentage";
            this.btnGeneric.UseVisualStyleBackColor = false;
            //
            //ncbForceToHavePause
            //
            this.ncbForceToHavePause.CaptionToValueRatio = 600;
            this.ncbForceToHavePause.ColorOnFocus = true;
            this.ncbForceToHavePause.FailedValidationErrorMessage = null;
            this.ncbForceToHavePause.HasCaption = true;
            this.ncbForceToHavePause.IndependentDatafieldName = null;
            this.ncbForceToHavePause.Location = new System.Drawing.Point(23, 320);
            this.ncbForceToHavePause.Name = "ncbForceToHavePause";
            this.ncbForceToHavePause.NullString = null;
            this.ncbForceToHavePause.NullValueMessage = null;
            this.ncbForceToHavePause.Size = new System.Drawing.Size(295, 19);
            this.ncbForceToHavePause.TabIndex = 13;
            this.ncbForceToHavePause.Text = "Pause in Schicht erzwingen:";
            this.ncbForceToHavePause.ValueAreaLength = 118;
            //
            //nibThreshold
            //
            this.nibThreshold.BackColor = System.Drawing.SystemColors.Window;
            this.nibThreshold.CaptionToValueRatio = 0;
            this.nibThreshold.ColorOnFocus = true;
            this.nibThreshold.FailedValidationErrorMessage = null;
            this.nibThreshold.FormularText = "";
            this.nibThreshold.HasCaption = false;
            this.nibThreshold.IndependentDatafieldName = null;
            this.nibThreshold.Location = new System.Drawing.Point(324, 289);
            this.nibThreshold.MaxValue = 0;
            this.nibThreshold.MinValue = 0;
            this.nibThreshold.Name = "nibThreshold";
            this.nibThreshold.NullString = "* --- *";
            this.nibThreshold.NullValueMessage = null;
            this.nibThreshold.Size = new System.Drawing.Size(118, 22);
            this.nibThreshold.TabIndex = 12;
            this.nibThreshold.Text = "AdNullableIntBox2";
            this.nibThreshold.ValueAreaLength = 118;
            //
            //Label4
            //
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label4.Location = new System.Drawing.Point(324, 241);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(135, 23);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "enden, abrunden.";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            //ndbRoundDownAfter
            //
            this.ndbRoundDownAfter.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime;
            this.ndbRoundDownAfter.BackColor = System.Drawing.SystemColors.Window;
            this.ndbRoundDownAfter.CaptionToValueRatio = 601.35;
            this.ndbRoundDownAfter.ColorOnFocus = true;
            this.ndbRoundDownAfter.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.CombinedShort;
            this.ndbRoundDownAfter.FailedValidationErrorMessage = "Falsches Datumsformat|Sie haben ein ungültiges Datumsformat eingegeben. Bitte kor" + "rigieren Sie Ihre Eingabe!";
            this.ndbRoundDownAfter.HasCaption = true;
            this.ndbRoundDownAfter.IndependentDatafieldName = null;
            this.ndbRoundDownAfter.Location = new System.Drawing.Point(22, 241);
            this.ndbRoundDownAfter.Name = "ndbRoundDownAfter";
            this.ndbRoundDownAfter.NullString = "* --- *";
            this.ndbRoundDownAfter.NullValueMessage = null;
            this.ndbRoundDownAfter.Size = new System.Drawing.Size(296, 22);
            this.ndbRoundDownAfter.TabIndex = 9;
            this.ndbRoundDownAfter.Text = "Buchungen, die nach";
            this.ndbRoundDownAfter.ValueAreaLength = 118;
            //
            //Label3
            //
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label3.Location = new System.Drawing.Point(324, 212);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(135, 23);
            this.Label3.TabIndex = 8;
            this.Label3.Text = "beginnen, aufrunden.";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            //ndbRoundUpBefore
            //
            this.ndbRoundUpBefore.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime;
            this.ndbRoundUpBefore.BackColor = System.Drawing.SystemColors.Window;
            this.ndbRoundUpBefore.CaptionToValueRatio = 601.35;
            this.ndbRoundUpBefore.ColorOnFocus = true;
            this.ndbRoundUpBefore.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.CombinedShort;
            this.ndbRoundUpBefore.FailedValidationErrorMessage = "Falsches Datumsformat|Sie haben ein ungültiges Datumsformat eingegeben. Bitte kor" + "rigieren Sie Ihre Eingabe!";
            this.ndbRoundUpBefore.HasCaption = true;
            this.ndbRoundUpBefore.IndependentDatafieldName = null;
            this.ndbRoundUpBefore.Location = new System.Drawing.Point(22, 212);
            this.ndbRoundUpBefore.Name = "ndbRoundUpBefore";
            this.ndbRoundUpBefore.NullString = "* --- *";
            this.ndbRoundUpBefore.NullValueMessage = null;
            this.ndbRoundUpBefore.Size = new System.Drawing.Size(296, 22);
            this.ndbRoundUpBefore.TabIndex = 7;
            this.ndbRoundUpBefore.Text = "Buchungen, die vor";
            this.ndbRoundUpBefore.ValueAreaLength = 118;
            //
            //nibPausetime
            //
            this.nibPausetime.BackColor = System.Drawing.SystemColors.Window;
            this.nibPausetime.CaptionToValueRatio = 601.35;
            this.nibPausetime.ColorOnFocus = true;
            this.nibPausetime.FailedValidationErrorMessage = null;
            this.nibPausetime.FormularText = "";
            this.nibPausetime.HasCaption = true;
            this.nibPausetime.IndependentDatafieldName = null;
            this.nibPausetime.Location = new System.Drawing.Point(22, 289);
            this.nibPausetime.MaxValue = 0;
            this.nibPausetime.MinValue = 0;
            this.nibPausetime.Name = "nibPausetime";
            this.nibPausetime.NullString = "* --- *";
            this.nibPausetime.NullValueMessage = null;
            this.nibPausetime.Size = new System.Drawing.Size(296, 22);
            this.nibPausetime.TabIndex = 11;
            this.nibPausetime.Text = "Pause/Schichtschwelle:";
            this.nibPausetime.ValueAreaLength = 118;
            //
            //lblEndTimeDateDecription
            //
            this.lblEndTimeDateDecription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblEndTimeDateDecription.Location = new System.Drawing.Point(445, 135);
            this.lblEndTimeDateDecription.Name = "lblEndTimeDateDecription";
            this.lblEndTimeDateDecription.Size = new System.Drawing.Size(94, 20);
            this.lblEndTimeDateDecription.TabIndex = 2;
            this.lblEndTimeDateDecription.Text = "(Der Folgetag)";
            this.lblEndTimeDateDecription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            //Label2
            //
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label2.Location = new System.Drawing.Point(19, 112);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(149, 13);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "Referenztag: Mo, 01.01.2003:";
            //
            //ndbCoreTimeStart
            //
            this.ndbCoreTimeStart.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime;
            this.ndbCoreTimeStart.BackColor = System.Drawing.SystemColors.Window;
            this.ndbCoreTimeStart.CaptionToValueRatio = 601.35;
            this.ndbCoreTimeStart.ColorOnFocus = true;
            this.ndbCoreTimeStart.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime;
            this.ndbCoreTimeStart.FailedValidationErrorMessage = "Falsches Datumsformat|Sie haben ein ungültiges Datumsformat eingegeben. Bitte kor" + "rigieren Sie Ihre Eingabe!";
            this.ndbCoreTimeStart.HasCaption = true;
            this.ndbCoreTimeStart.IndependentDatafieldName = null;
            this.ndbCoreTimeStart.Location = new System.Drawing.Point(23, 133);
            this.ndbCoreTimeStart.Name = "ndbCoreTimeStart";
            this.ndbCoreTimeStart.NullString = "* --- *";
            this.ndbCoreTimeStart.NullValueMessage = null;
            this.ndbCoreTimeStart.Size = new System.Drawing.Size(296, 22);
            this.ndbCoreTimeStart.TabIndex = 0;
            this.ndbCoreTimeStart.Text = "Schicht: Beginn/Ende:";
            this.ndbCoreTimeStart.ValueAreaLength = 118;
            //
            //ndbCoreTimeEnd
            //
            this.ndbCoreTimeEnd.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime;
            this.ndbCoreTimeEnd.BackColor = System.Drawing.SystemColors.Window;
            this.ndbCoreTimeEnd.CaptionToValueRatio = 0;
            this.ndbCoreTimeEnd.ColorOnFocus = true;
            this.ndbCoreTimeEnd.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime;
            this.ndbCoreTimeEnd.FailedValidationErrorMessage = "Falsches Datumsformat|Sie haben ein ungültiges Datumsformat eingegeben. Bitte kor" + "rigieren Sie Ihre Eingabe!";
            this.ndbCoreTimeEnd.HasCaption = false;
            this.ndbCoreTimeEnd.IndependentDatafieldName = null;
            this.ndbCoreTimeEnd.Location = new System.Drawing.Point(321, 133);
            this.ndbCoreTimeEnd.Name = "ndbCoreTimeEnd";
            this.ndbCoreTimeEnd.NullString = "* --- *";
            this.ndbCoreTimeEnd.NullValueMessage = null;
            this.ndbCoreTimeEnd.Size = new System.Drawing.Size(118, 22);
            this.ndbCoreTimeEnd.TabIndex = 1;
            this.ndbCoreTimeEnd.Text = "Schicht-1-Kernzeiten: Beginn/Ende:";
            this.ndbCoreTimeEnd.ValueAreaLength = 118;
            //
            //tcShifts
            //
            this.tcShifts.Controls.Add(this.tpShift1);
            this.tcShifts.Controls.Add(this.tpShift2);
            this.tcShifts.Controls.Add(this.tpShift3);
            this.tcShifts.Controls.Add(this.tpShift4);
            this.tcShifts.Location = new System.Drawing.Point(0, 2);
            this.tcShifts.Name = "tcShifts";
            this.tcShifts.SelectedIndex = 0;
            this.tcShifts.Size = new System.Drawing.Size(563, 26);
            this.tcShifts.TabIndex = 0;
            //
            //tpShift1
            //
            this.tpShift1.Location = new System.Drawing.Point(4, 25);
            this.tpShift1.Name = "tpShift1";
            this.tpShift1.Padding = new System.Windows.Forms.Padding(3);
            this.tpShift1.Size = new System.Drawing.Size(555, 0);
            this.tpShift1.TabIndex = 0;
            this.tpShift1.Text = "Schicht 1";
            //
            //tpShift2
            //
            this.tpShift2.Location = new System.Drawing.Point(4, 25);
            this.tpShift2.Name = "tpShift2";
            this.tpShift2.Padding = new System.Windows.Forms.Padding(3);
            this.tpShift2.Size = new System.Drawing.Size(555, 0);
            this.tpShift2.TabIndex = 1;
            this.tpShift2.Text = "Schicht 2";
            //
            //tpShift3
            //
            this.tpShift3.Location = new System.Drawing.Point(4, 25);
            this.tpShift3.Name = "tpShift3";
            this.tpShift3.Size = new System.Drawing.Size(555, 0);
            this.tpShift3.TabIndex = 2;
            this.tpShift3.Text = "Schicht 3";
            //
            //tpShift4
            //
            this.tpShift4.Location = new System.Drawing.Point(4, 25);
            this.tpShift4.Name = "tpShift4";
            this.tpShift4.Size = new System.Drawing.Size(555, 0);
            this.tpShift4.TabIndex = 3;
            this.tpShift4.Text = "Sonderschicht";
            //
            //ucTimeDetailsSettings
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.tcShifts);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucTimeDetailsSettings";
            this.Size = new System.Drawing.Size(569, 474);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.tcShifts.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button btnEndDate;
        internal System.Windows.Forms.Button btnStartDate;
        internal System.Windows.Forms.Label Label6;
        private System.Windows.Forms.Button _btnWD_07_Sunday;
        internal System.Windows.Forms.Button btnWD_07_Sunday
        {
            get
            {
                return _btnWD_07_Sunday;
            }

            set
            {
                if (_btnWD_07_Sunday != null)
                {
                    _btnWD_07_Sunday.Click -= btnGeneric_Click;
                }

                _btnWD_07_Sunday = value;
                if (_btnWD_07_Sunday != null)
                {
                    _btnWD_07_Sunday.Click += btnGeneric_Click;
                }
            }
        }

        private System.Windows.Forms.Button _btnWD_06_Saturday;
        internal System.Windows.Forms.Button btnWD_06_Saturday
        {
            get
            {
                return _btnWD_06_Saturday;
            }

            set
            {
                if (_btnWD_06_Saturday != null)
                {
                    _btnWD_06_Saturday.Click -= btnGeneric_Click;
                }

                _btnWD_06_Saturday = value;
                if (_btnWD_06_Saturday != null)
                {
                    _btnWD_06_Saturday.Click += btnGeneric_Click;
                }
            }
        }

        private System.Windows.Forms.Button _btnWD_05_Friday;
        internal System.Windows.Forms.Button btnWD_05_Friday
        {
            get
            {
                return _btnWD_05_Friday;
            }

            set
            {
                if (_btnWD_05_Friday != null)
                {
                    _btnWD_05_Friday.Click -= btnGeneric_Click;
                }

                _btnWD_05_Friday = value;
                if (_btnWD_05_Friday != null)
                {
                    _btnWD_05_Friday.Click += btnGeneric_Click;
                }
            }
        }

        private System.Windows.Forms.Button _btnWD_04_Thursday;
        internal System.Windows.Forms.Button btnWD_04_Thursday
        {
            get
            {
                return _btnWD_04_Thursday;
            }

            set
            {
                if (_btnWD_04_Thursday != null)
                {
                    _btnWD_04_Thursday.Click -= btnGeneric_Click;
                }

                _btnWD_04_Thursday = value;
                if (_btnWD_04_Thursday != null)
                {
                    _btnWD_04_Thursday.Click += btnGeneric_Click;
                }
            }
        }

        private System.Windows.Forms.Button _btnWD_03_Wednesday;
        internal System.Windows.Forms.Button btnWD_03_Wednesday
        {
            get
            {
                return _btnWD_03_Wednesday;
            }

            set
            {
                if (_btnWD_03_Wednesday != null)
                {
                    _btnWD_03_Wednesday.Click -= btnGeneric_Click;
                }

                _btnWD_03_Wednesday = value;
                if (_btnWD_03_Wednesday != null)
                {
                    _btnWD_03_Wednesday.Click += btnGeneric_Click;
                }
            }
        }

        private System.Windows.Forms.Button _btnWD_02_Tuesday;
        internal System.Windows.Forms.Button btnWD_02_Tuesday
        {
            get
            {
                return _btnWD_02_Tuesday;
            }

            set
            {
                if (_btnWD_02_Tuesday != null)
                {
                    _btnWD_02_Tuesday.Click -= btnGeneric_Click;
                }

                _btnWD_02_Tuesday = value;
                if (_btnWD_02_Tuesday != null)
                {
                    _btnWD_02_Tuesday.Click += btnGeneric_Click;
                }
            }
        }

        private System.Windows.Forms.Button _btnWD_01_Monday;
        internal System.Windows.Forms.Button btnWD_01_Monday
        {
            get
            {
                return _btnWD_01_Monday;
            }

            set
            {
                if (_btnWD_01_Monday != null)
                {
                    _btnWD_01_Monday.Click -= btnGeneric_Click;
                }

                _btnWD_01_Monday = value;
                if (_btnWD_01_Monday != null)
                {
                    _btnWD_01_Monday.Click += btnGeneric_Click;
                }
            }
        }

        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Button _btnGeneric;
        internal System.Windows.Forms.Button btnGeneric
        {
            get
            {
                return _btnGeneric;
            }

            set
            {
                if (_btnGeneric != null)
                {
                    _btnGeneric.Click -= btnGeneric_Click;
                }

                _btnGeneric = value;
                if (_btnGeneric != null)
                {
                    _btnGeneric.Click += btnGeneric_Click;
                }
            }
        }

        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label lblEndTimeDateDecription;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TabControl _tcShifts;
        internal System.Windows.Forms.TabControl tcShifts
        {
            get
            {
                return _tcShifts;
            }

            set
            {
                if (_tcShifts != null)
                {
                    _tcShifts.Selected -= tcShifts_Selected;
                }

                _tcShifts = value;
                if (_tcShifts != null)
                {
                    _tcShifts.Selected += tcShifts_Selected;
                }
            }
        }

        internal System.Windows.Forms.TabPage tpShift1;
        internal System.Windows.Forms.TabPage tpShift2;
        internal System.Windows.Forms.TabPage tpShift3;
        internal System.Windows.Forms.TabPage tpShift4;
        internal System.Windows.Forms.ListBox lbTimes;
        internal ActiveDev.Controls.ADNullableCheckBox ncbForceToHavePause;
        internal ActiveDev.Controls.ADNullableIntBox nibThreshold;
        private ActiveDev.Controls.ADNullableDateTimeBox _ndbRoundDownAfter;
        internal ActiveDev.Controls.ADNullableDateTimeBox ndbRoundDownAfter
        {
            get
            {
                return _ndbRoundDownAfter;
            }

            set
            {
                if (_ndbRoundDownAfter != null)
                {
                    _ndbRoundDownAfter.Validated -= ndbRoundUpBefore_Validated;
                }

                _ndbRoundDownAfter = value;
                if (_ndbRoundDownAfter != null)
                {
                    _ndbRoundDownAfter.Validated += ndbRoundUpBefore_Validated;
                }
            }
        }

        private ActiveDev.Controls.ADNullableDateTimeBox _ndbRoundUpBefore;
        internal ActiveDev.Controls.ADNullableDateTimeBox ndbRoundUpBefore
        {
            get
            {
                return _ndbRoundUpBefore;
            }

            set
            {
                if (_ndbRoundUpBefore != null)
                {
                    _ndbRoundUpBefore.Validated -= ndbRoundUpBefore_Validated;
                }

                _ndbRoundUpBefore = value;
                if (_ndbRoundUpBefore != null)
                {
                    _ndbRoundUpBefore.Validated += ndbRoundUpBefore_Validated;
                }
            }
        }

        internal ActiveDev.Controls.ADNullableIntBox nibPausetime;
        private ActiveDev.Controls.ADNullableDateTimeBox _ndbCoreTimeStart;
        internal ActiveDev.Controls.ADNullableDateTimeBox ndbCoreTimeStart
        {
            get
            {
                return _ndbCoreTimeStart;
            }

            set
            {
                if (_ndbCoreTimeStart != null)
                {
                    _ndbCoreTimeStart.Validated -= ndbCoreTimeStart_Validated;
                }

                _ndbCoreTimeStart = value;
                if (_ndbCoreTimeStart != null)
                {
                    _ndbCoreTimeStart.Validated += ndbCoreTimeStart_Validated;
                }
            }
        }

        private ActiveDev.Controls.ADNullableDateTimeBox _ndbCoreTimeEnd;
        internal ActiveDev.Controls.ADNullableDateTimeBox ndbCoreTimeEnd
        {
            get
            {
                return _ndbCoreTimeEnd;
            }

            set
            {
                if (_ndbCoreTimeEnd != null)
                {
                    _ndbCoreTimeEnd.Validated -= ndbCoreTimeEnd_Validated;
                }

                _ndbCoreTimeEnd = value;
                if (_ndbCoreTimeEnd != null)
                {
                    _ndbCoreTimeEnd.Validated += ndbCoreTimeEnd_Validated;
                }
            }
        }

        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label lblImportEndTimeDateDescription;
        private ActiveDev.Controls.ADNullableDateTimeBox _ndbImportTimeStart;
        internal ActiveDev.Controls.ADNullableDateTimeBox ndbImportTimeStart
        {
            get
            {
                return _ndbImportTimeStart;
            }

            set
            {
                if (_ndbImportTimeStart != null)
                {
                    _ndbImportTimeStart.Validated -= ndbImportTimeStart_Validated;
                }

                _ndbImportTimeStart = value;
                if (_ndbImportTimeStart != null)
                {
                    _ndbImportTimeStart.Validated += ndbImportTimeStart_Validated;
                }
            }
        }

        private ActiveDev.Controls.ADNullableDateTimeBox _ndbImportTimeEnd;
        internal ActiveDev.Controls.ADNullableDateTimeBox ndbImportTimeEnd
        {
            get
            {
                return _ndbImportTimeEnd;
            }

            set
            {
                if (_ndbImportTimeEnd != null)
                {
                    _ndbImportTimeEnd.Validated -= ndbImportTimeEnd_Validated;
                }

                _ndbImportTimeEnd = value;
                if (_ndbImportTimeEnd != null)
                {
                    _ndbImportTimeEnd.Validated += ndbImportTimeEnd_Validated;
                }
            }
        }

        internal System.Windows.Forms.Label lblShiftInformer;
        private System.Windows.Forms.Button _btnReset;
        internal System.Windows.Forms.Button btnReset
        {
            get
            {
                return _btnReset;
            }

            set
            {
                if (_btnReset != null)
                {
                    _btnReset.Click -= btnReset_Click;
                }

                _btnReset = value;
                if (_btnReset != null)
                {
                    _btnReset.Click += btnReset_Click;
                }
            }
        }
    }
}