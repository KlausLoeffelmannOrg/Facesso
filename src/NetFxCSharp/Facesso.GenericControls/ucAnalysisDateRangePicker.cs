using ActiveDev;
using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
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
    public partial class ucAnalysisDateRangePicker
    {
        private DateRangeParameter myDateRangeValue;
        private bool myDoNothing;
        private LastWorkingdays myLastWorkingday;
        public ucAnalysisDateRangePicker()
        {
            // This call is required by the Windows Form Designer.
            myDoNothing = true;
            InitializeComponent();
            myDoNothing = false;
            myLastWorkingday = LastWorkingdays.Friday;
            // Add any initialization after the InitializeComponent() call.
            cmbMonthsHistory.Items.Add("Laufender Monat (" + MonthText(0) + ")");
            cmbMonthsHistory.Items.Add("Letzter Monat (" + MonthText(1) + ")");
            for (int c = 2; c <= 24; c++)
            {
                cmbMonthsHistory.Items.Add("Vor " + c + " Monaten (" + MonthText(c) + ")");
            }

            DateRangeValue = new DateRangeParameter(DateRangePresets.FromStartToEndOfSpecifiedMonth, 1);
            myDateRangeValue.LastWorkingday = LastWorkingdays.Friday;
        }

        private string MonthText(int MonthsIntoPast)
        {
            System.DateTime locStartDate = default(System.DateTime);
            locStartDate = Dates.LastDayOfMonth(System.DateTime.Now).AddMonths(-MonthsIntoPast);
            return locStartDate.ToString("MMM, yyyy");
        }

        public DateRangeParameter DateRangeValue
        {
            get
            {
                return myDateRangeValue;
            }

            set
            {
                myDateRangeValue = value;
                UpdateUI();
            }
        }

        public LastWorkingdays LastWorkingday
        {
            get
            {
                return myLastWorkingday;
            }

            set
            {
                myLastWorkingday = value;
                myDateRangeValue.LastWorkingday = value;
            }
        }

        private void UpdateUI()
        {
            myDoNothing = true;
            {
                var __select0 = (int)(myDateRangeValue.DateRangePreset);
                if (__select0 == (int)(DateRangePresets.CustomPeriod))
                {
                    optCustomPeriod.Checked = true;
                    myDoNothing = false;
                    return;
                }
                else if (__select0 == (int)(DateRangePresets.YesterdayOrLastWorkingDay))
                {
                    optYesterday.Checked = true;
                }
                else if (__select0 == (int)(DateRangePresets.FromStartOfCurrentMonthToNow))
                {
                    optFromStartOfCurrentMonthToNow.Checked = true;
                }
                else if (__select0 == (int)(DateRangePresets.FromStartOfCurrentWeekToNow))
                {
                    optFromStartOfCurrentWeekToNow.Checked = true;
                }
                else if (__select0 == (int)(DateRangePresets.FromStartToEndOfSpecifiedMonth))
                {
                    cmbMonthsHistory.SelectedIndex = DateRangeValue.MonthIntoPast;
                }
                else if (__select0 == (int)(DateRangePresets.LastWeek))
                {
                    optLastWeek.Checked = true;
                }
                else if (__select0 == (int)(DateRangePresets.Today))
                {
                    optToday.Checked = true;
                }
                else if (__select0 == (int)(DateRangePresets.SinceYearBeganToNow))
                {
                    optSinceYearBegan.Checked = true;
                }
                else
                {
                    optWeekBeforeLastWeek.Checked = true;
                }
            }

            dtpStart.Value = myDateRangeValue.StartDate;
            dtpEnd.Value = myDateRangeValue.EndDate;
            myDoNothing = false;
        }

        private void dtpStart_ValueChanged(System.Object sender, System.EventArgs e)
        {
            if (myDoNothing)
            {
                return;
            }

            if (dtpStart.Value > dtpEnd.Value)
            {
                dtpEnd.Value = dtpStart.Value;
            }

            DateRangeValue = new DateRangeParameter(dtpStart.Value, dtpEnd.Value);
        }

        private void dtpEnd_ValueChanged(System.Object sender, System.EventArgs e)
        {
            if (myDoNothing)
            {
                return;
            }

            if (dtpStart.Value > dtpEnd.Value)
            {
                dtpStart.Value = dtpEnd.Value;
            }

            DateRangeValue = new DateRangeParameter(dtpStart.Value, dtpEnd.Value);
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
            }
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            gbTitle.Text = this.Text;
        }

        private void optDateRanges_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (myDoNothing)
            {
                return;
            }

            if (optYesterday.Checked)
            {
                DateRangeValue = new DateRangeParameter(DateRangePresets.YesterdayOrLastWorkingDay, this.LastWorkingday);
            }
            else if (optFromStartOfCurrentMonthToNow.Checked)
            {
                DateRangeValue = new DateRangeParameter(DateRangePresets.FromStartOfCurrentMonthToNow);
            }
            else if (optFromStartOfCurrentWeekToNow.Checked)
            {
                DateRangeValue = new DateRangeParameter(DateRangePresets.FromStartOfCurrentWeekToNow);
            }
            else if (optStartToEndOfSpecifiedMonth.Checked)
            {
                DateRangeValue = new DateRangeParameter(DateRangePresets.FromStartToEndOfSpecifiedMonth, cmbMonthsHistory.SelectedIndex);
            }
            else if (optLastWeek.Checked)
            {
                DateRangeValue = new DateRangeParameter(DateRangePresets.LastWeek);
            }
            else if (optToday.Checked)
            {
                DateRangeValue = new DateRangeParameter(DateRangePresets.Today);
            }
            else if (optSinceYearBegan.Checked)
            {
                DateRangeValue = new DateRangeParameter(DateRangePresets.SinceYearBeganToNow);
            }
            else if (optWeekBeforeLastWeek.Checked)
            {
                DateRangeValue = new DateRangeParameter(DateRangePresets.WeekBeforeLastWeek);
            }
            else if (optCustomPeriod.Checked)
            {
                DateRangeValue = new DateRangeParameter(dtpStart.Value, dtpEnd.Value);
            }
        }

        private void cmbMonthsHistory_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (!(optStartToEndOfSpecifiedMonth.Checked))
            {
                optStartToEndOfSpecifiedMonth.Checked = true;
            }
            else
            {
                DateRangeValue = new DateRangeParameter(DateRangePresets.FromStartToEndOfSpecifiedMonth, cmbMonthsHistory.SelectedIndex);
            }
        }

        private void gbTitle_Enter(System.Object sender, System.EventArgs e)
        {
        }
    }
}