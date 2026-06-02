using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.GenericControls
{
    public partial class ucTimeDetailsSettings
    {
        protected TimeSettingDetails myTSDetails;
        protected int myCurrentlyDisplayedShift;
        protected TimeSettingDetailsWeekdays myCurrentlyDisplayedWeekday;
        protected KeyedControlCollection myWeekdayButtons = new KeyedControlCollection();
        protected bool myInitialized;
        protected bool myHasntGotData = true;
        //Protected myShiftTabs As KeyedControlCollection
        public ucTimeDetailsSettings()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // Add any initialization after the InitializeComponent() call.
            myTSDetails = new TimeSettingDetails();
            {
                var __with0 = myWeekdayButtons;
                __with0.Add(btnWD_01_Monday);
                __with0.Add(btnWD_02_Tuesday);
                __with0.Add(btnWD_03_Wednesday);
                __with0.Add(btnWD_04_Thursday);
                __with0.Add(btnWD_05_Friday);
                __with0.Add(btnWD_06_Saturday);
                __with0.Add(btnWD_07_Sunday);
            }

            myInitialized = true;
            myCurrentlyDisplayedShift = 1;
            SetControls();
        }

        public int CurrentlyDisplayedShift
        {
            get
            {
                return myCurrentlyDisplayedShift;
            }

            set
            {
                if (value == 0)
                {
                    value = 1;
                }

                SaveData();
                myCurrentlyDisplayedShift = value;
                SetControls();
            }
        }

        public TimeSettingDetailsWeekdays CurrentlyDisplayedWeekday
        {
            get
            {
                return myCurrentlyDisplayedWeekday;
            }

            set
            {
                SaveData();
                myCurrentlyDisplayedWeekday = value;
                SetControls();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TimeSettingDetails TSDetails
        {
            get
            {
                return myTSDetails;
            }

            set
            {
                if (value == null)
                {
                    myHasntGotData = true;
                }
                else
                {
                    myHasntGotData = false;
                }

                myTSDetails = value;
                SetControls();
            }
        }

        public void SetControls()
        {
            //Controls-Zustände anpassen
            if (!(myInitialized) | myHasntGotData)
            {
                return;
            }

            //Daten einspielen
            TimeSettingDetail locTSD = default(TimeSettingDetail);
            if (CurrentlyDisplayedWeekday == TimeSettingDetailsWeekdays.ForAll)
            {
                locTSD = TSDetails.GenericTimeSettingDetail[CurrentlyDisplayedShift - 1];
                btnReset.Enabled = true;
            }
            else
            {
                locTSD = TSDetails.TimeSettingDetail[(int)((CurrentlyDisplayedShift - 1) * 7 + CurrentlyDisplayedWeekday - 1)];
                btnReset.Enabled = false;
            }

            ndbCoreTimeStart.TypeSafeValue = locTSD.ShiftStart;
            ndbCoreTimeEnd.TypeSafeValue = locTSD.ShiftEnd;
            ndbImportTimeStart.TypeSafeValue = locTSD.ImportShiftStart;
            ndbImportTimeEnd.TypeSafeValue = locTSD.ImportShiftEnd;
            ndbRoundUpBefore.TypeSafeValue = locTSD.RoundUpBefore;
            ndbRoundDownAfter.TypeSafeValue = locTSD.RoundDownAfter;
            nibPausetime.TypeSafeValue = locTSD.WorkBreak;
            nibThreshold.TypeSafeValue = locTSD.Threshold;
            ncbForceToHavePause.TypeSafeValue = locTSD.ForceToHavePause;
            //Dokumentation der Daten setzen
            if (locTSD.ShiftStart.IsNull | locTSD.ShiftEnd.IsNull)
            {
                btnStartDate.Text = "- - -";
                btnEndDate.Text = "- - -";
                lblEndTimeDateDecription.Text = "";
                lblImportEndTimeDateDescription.Text = "";
            }
            else
            {
                {
                    var __with1 = locTSD;
                    if (__with1.ShiftStart > __with1.ShiftEnd)
                    {
                        __with1.ShiftEnd = __with1.ShiftEnd.TypedValue.AddDays(1);
                    }

                    if (__with1.ShiftEnd.TypedValue.Date == new System.DateTime(2003, 1, 1))
                    {
                        lblEndTimeDateDecription.Text = "(Derselbe Tag)";
                    }
                    else
                    {
                        lblEndTimeDateDecription.Text = "(Der Folgetag)";
                    }

                    btnStartDate.Text = __with1.ShiftStart.TypedValue.ToShortDateString();
                    btnEndDate.Text = __with1.ShiftEnd.TypedValue.ToShortDateString();
                    if (!(__with1.ImportShiftEnd.IsNull))
                    {
                        if (__with1.ImportShiftStart > __with1.ImportShiftEnd)
                        {
                            __with1.ImportShiftEnd = __with1.ImportShiftEnd.TypedValue.AddDays(1);
                        }

                        if (__with1.ImportShiftEnd.TypedValue.Date == new System.DateTime(2003, 1, 1))
                        {
                            lblImportEndTimeDateDescription.Text = "(Derselbe Tag)";
                        }
                        else
                        {
                            lblImportEndTimeDateDescription.Text = "(Der Folgetag)";
                        }
                    }
                    else
                    {
                        __with1.ImportShiftStart = __with1.ShiftStart;
                        __with1.ImportShiftEnd = __with1.ShiftEnd;
                    }
                }
            }

            //Schichttab wählen
            {
                var __select2 = CurrentlyDisplayedShift;
                if (__select2 == 1)
                {
                    tcShifts.SelectedTab = tpShift1;
                    lblShiftInformer.Text = "für Schicht 1";
                }
                else if (__select2 == 2)
                {
                    tcShifts.SelectedTab = tpShift2;
                    lblShiftInformer.Text = "für Schicht 2";
                }
                else if (__select2 == 3)
                {
                    tcShifts.SelectedTab = tpShift3;
                    lblShiftInformer.Text = "für Schicht 3";
                }
                else if (__select2 == 4)
                {
                    tcShifts.SelectedTab = tpShift4;
                    lblShiftInformer.Text = "für Sonderschicht";
                }
            }

            //Buttonfarbe und Selektierung setzen
            if (CurrentlyDisplayedWeekday == TimeSettingDetailsWeekdays.ForAll)
            {
                btnGeneric.BackColor = Color.Yellow;
            }
            else
            {
                btnGeneric.BackColor = SystemColors.Control;
            }

            for (int locCount = 0; locCount <= 6; locCount++)
            {
                Button locBtn = ((Button)myWeekdayButtons[locCount]);
                // Generischer Tag immer fett
                if (TSDetails.TimeSettingDetail[(CurrentlyDisplayedShift - 1) * 7 + locCount].IsDerived)
                {
                    locBtn.Font = new Font(locBtn.Font, FontStyle.Regular);
                }
                else
                {
                    locBtn.Font = new Font(locBtn.Font, FontStyle.Bold);
                }

                if (locCount == Convert.ToInt32(CurrentlyDisplayedWeekday) - 1)
                {
                    locBtn.BackColor = Color.Yellow;
                }
                else
                {
                    locBtn.BackColor = SystemColors.Control;
                }
            }

            //Listbox aufbereiten:
            //Erst die Generischen Tage anzeigen
            lbTimes.Items.Clear();
            for (int z = 0; z <= 3; z++)
            {
                lbTimes.Items.Add(this.TSDetails.GenericTimeSettingDetail[z].ToString());
            }

            //Dann den Rest
            for (int z = 0; z <= 6; z++)
            {
                for (int s = 0; s <= 3; s++)
                {
                    lbTimes.Items.Add(this.TSDetails.TimeSettingDetail[(s) * 7 + z]);
                }
            }
        }

        private void SaveData()
        {
            TimeSettingDetail locTSD = default(TimeSettingDetail);
            bool locIsGeneric = false;
            if (CurrentlyDisplayedWeekday == TimeSettingDetailsWeekdays.ForAll)
            {
                locTSD = TSDetails.GenericTimeSettingDetail[CurrentlyDisplayedShift - 1];
                locIsGeneric = true;
            }
            else
            {
                locTSD = TSDetails.TimeSettingDetail[(int)((CurrentlyDisplayedShift - 1) * 7 + CurrentlyDisplayedWeekday - 1)];
            }

            locTSD.ShiftStart = ndbCoreTimeStart.TypeSafeValue;
            locTSD.ShiftEnd = ndbCoreTimeEnd.TypeSafeValue;
            locTSD.ImportShiftStart = ndbImportTimeStart.TypeSafeValue;
            locTSD.ImportShiftEnd = ndbImportTimeEnd.TypeSafeValue;
            locTSD.RoundUpBefore = ndbRoundUpBefore.TypeSafeValue;
            locTSD.RoundDownAfter = ndbRoundDownAfter.TypeSafeValue;
            locTSD.WorkBreak = nibPausetime.TypeSafeValue;
            locTSD.Threshold = nibThreshold.TypeSafeValue;
            locTSD.ForceToHavePause = ncbForceToHavePause.TypeSafeValue;
            locTSD.ForShift = CurrentlyDisplayedShift;
            //Plausibilitätskontrolle
            if (locTSD.ShiftStart.IsNull | locTSD.ShiftEnd.IsNull)
            {
                locTSD.NullAll();
            }
            else
            {
                {
                    var __with3 = locTSD;
                    TimeSpan locTimeSpanStart = default(TimeSpan);
                    TimeSpan locTimeSpanEnd = default(TimeSpan);
                    if (!(__with3.ImportShiftStart.IsNull))
                    {
                        locTimeSpanStart = __with3.ImportShiftStart.TypedValue.TimeOfDay;
                        __with3.ImportShiftStart = new System.DateTime(2003, 1, 1).Add(locTimeSpanStart);
                    }

                    if (!(__with3.ImportShiftEnd.IsNull))
                    {
                        locTimeSpanEnd = __with3.ImportShiftEnd.TypedValue.TimeOfDay;
                        __with3.ImportShiftEnd = new System.DateTime(2003, 1, 1).Add(locTimeSpanEnd);
                    }

                    locTimeSpanStart = __with3.ShiftStart.TypedValue.TimeOfDay;
                    locTimeSpanEnd = __with3.ShiftEnd.TypedValue.TimeOfDay;
                    __with3.ShiftStart = new System.DateTime(2003, 1, 1).Add(locTimeSpanStart);
                    __with3.ShiftEnd = new System.DateTime(2003, 1, 1).Add(locTimeSpanEnd);
                    if (__with3.ShiftStart > __with3.ShiftEnd)
                    {
                        __with3.ShiftEnd = __with3.ShiftEnd.TypedValue.AddDays(1);
                    }

                    if (__with3.ImportShiftStart.IsNull)
                    {
                        __with3.ImportShiftStart = __with3.ShiftStart.TypedValue;
                    }

                    if (__with3.ImportShiftEnd.IsNull)
                    {
                        __with3.ImportShiftEnd = __with3.ShiftEnd.TypedValue;
                    }

                    if (__with3.ImportShiftStart > __with3.ImportShiftEnd)
                    {
                        __with3.ImportShiftEnd = __with3.ImportShiftEnd.TypedValue.AddDays(1);
                    }
                }
            }

            {
                var __with4 = locTSD;
                if (!(__with4.RoundUpBefore.IsNull))
                {
                    TimeSpan locTimeSpan = __with4.RoundUpBefore.TypedValue.TimeOfDay;
                    __with4.RoundUpBefore = __with4.ImportShiftStart.TypedValue.Date;
                    __with4.RoundUpBefore = __with4.RoundUpBefore.TypedValue.Add(locTimeSpan);
                    if (__with4.RoundUpBefore > __with4.ImportShiftStart)
                    {
                        __with4.RoundUpBefore = __with4.ImportShiftStart;
                    }
                }

                if (!(__with4.RoundDownAfter.IsNull))
                {
                    TimeSpan locTimeSpan = __with4.RoundDownAfter.TypedValue.TimeOfDay;
                    __with4.RoundDownAfter = __with4.ImportShiftEnd.TypedValue.Date;
                    __with4.RoundDownAfter = __with4.RoundDownAfter.TypedValue.Add(locTimeSpan);
                    if (__with4.RoundDownAfter < __with4.ImportShiftEnd)
                    {
                        __with4.RoundDownAfter = __with4.ImportShiftEnd;
                    }
                }
            }

            //Falls es kein generischer Datenblock war, dann rausfinden, ob
            //Daten der generischen Vorlage entsprechen!
            if (!(locIsGeneric))
            {
                if (TSDetails.GenericTimeSettingDetail[CurrentlyDisplayedShift - 1].IsEqual(locTSD))
                {
                    locTSD.IsDerived = true;
                }
                else
                {
                    locTSD.IsDerived = false;
                }
            }

            //Falls Änderungen an der Vorlage, dann alle ändern,
            //die nicht abgeleitet sind!
            if (locIsGeneric)
            {
                for (int locCount = 0; locCount <= 6; locCount++)
                {
                    if (TSDetails.TimeSettingDetail[(CurrentlyDisplayedShift - 1) * 7 + locCount].IsDerived)
                    {
                        TSDetails.TimeSettingDetail[(CurrentlyDisplayedShift - 1) * 7 + locCount] = locTSD.Clone();
                        TSDetails.TimeSettingDetail[(CurrentlyDisplayedShift - 1) * 7 + locCount].ForWeekday = ((TimeSettingDetailsWeekdays)locCount + 1);
                    }

                    //Und die, die gleich geworden sind, wieder einbinden.
                    if (TSDetails.TimeSettingDetail[(CurrentlyDisplayedShift - 1) * 7 + locCount].IsEqual(locTSD))
                    {
                        TSDetails.TimeSettingDetail[(CurrentlyDisplayedShift - 1) * 7 + locCount].IsDerived = true;
                    }
                }
            }
        }

        private void btnGeneric_Click(System.Object sender, System.EventArgs e)
        {
            if (((Control)sender).Name == btnGeneric.Name)
            {
                CurrentlyDisplayedWeekday = TimeSettingDetailsWeekdays.ForAll;
            }
            else
            {
                for (int i = 0; i <= 6; i++)
                {
                    if (((Control)sender).Name == myWeekdayButtons[i].Name)
                    {
                        CurrentlyDisplayedWeekday = ((TimeSettingDetailsWeekdays)i + 1);
                        return;
                    }
                }
            }
        }

        private void tcShifts_Selected(System.Object sender, System.Windows.Forms.TabControlEventArgs e)
        {
            CurrentlyDisplayedShift = e.TabPageIndex + 1;
        }

        private void ndbCoreTimeStart_Validated(System.Object sender, System.EventArgs e)
        {
            if (ndbCoreTimeEnd.TypeSafeValue.IsNull)
            {
                ndbCoreTimeEnd.TypeSafeValue = ndbCoreTimeStart.TypeSafeValue;
            }

            SaveData();
            SetControls();
        }

        private void ndbCoreTimeEnd_Validated(System.Object sender, System.EventArgs e)
        {
            if (ndbCoreTimeStart.TypeSafeValue.IsNull)
            {
                ndbCoreTimeStart.TypeSafeValue = ndbCoreTimeEnd.TypeSafeValue;
            }

            SaveData();
            SetControls();
        }

        private void ndbRoundUpBefore_Validated(System.Object sender, System.EventArgs e)
        {
            SaveData();
            SetControls();
        }

        private void ndbImportTimeStart_Validated(System.Object sender, System.EventArgs e)
        {
            if (ndbImportTimeEnd.TypeSafeValue.IsNull)
            {
                ndbImportTimeEnd.TypeSafeValue = ndbImportTimeStart.TypeSafeValue;
            }

            SaveData();
            SetControls();
        }

        private void ndbImportTimeEnd_Validated(System.Object sender, System.EventArgs e)
        {
            if (ndbImportTimeStart.TypeSafeValue.IsNull)
            {
                ndbImportTimeStart.TypeSafeValue = ndbImportTimeEnd.TypeSafeValue;
            }

            SaveData();
            SetControls();
        }

        /// <summary>
        /// Setzt, wenn "für alle Wochentage" ausgewählt ist, alle Tagesunterschiede zurück.
        /// </summary>
        /// <param name = "sender"></param>
        /// <param name = "e"></param>
        /// <remarks></remarks>
        private void btnReset_Click(System.Object sender, System.EventArgs e)
        {
            for (int locCount = 0; locCount <= 6; locCount++)
            {
                TSDetails.TimeSettingDetail[(CurrentlyDisplayedShift - 1) * 7 + locCount] = TSDetails.GenericTimeSettingDetail[CurrentlyDisplayedShift - 1].Clone();
                SetControls();
            }
        }
    }

    public class KeyedControlCollection : KeyedCollection<string, Control>
    {
        protected override string GetKeyForItem(System.Windows.Forms.Control item)
        {
            return item.Name;
        }
    }
}