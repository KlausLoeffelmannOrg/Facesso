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
    public partial class ucMonthRangePicker
    {
        private MonthRangePickerResult myMonthRangeResult;
        private bool myFromInner;
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            myMonthRangeResult = new MonthRangePickerResult(MonthRangeBase.FirstToLastPrevious, RelatedMonth.PreviousMonth);
            this.MonthRangeResult = myMonthRangeResult;
            myFromInner = true;
            this.dtpFrom.Value = myMonthRangeResult.FromDate;
            this.dtpTo.Value = myMonthRangeResult.ToDate;
            myFromInner = false;
            optCurrentMonth.Text = optCurrentMonth.Text.Replace("###", System.DateTime.Now.ToString("MMMM"));
            optPreviousMonth.Text = optPreviousMonth.Text.Replace("###", System.DateTime.Now.AddMonths(-1).ToString("MMMM"));
            optSecondLastMonth.Text = optSecondLastMonth.Text.Replace("###", System.DateTime.Now.AddMonths(-2).ToString("MMMM"));
        }

        public MonthRangePickerResult MonthRangeResult
        {
            get
            {
                myMonthRangeResult.FromDate = dtpFrom.Value;
                myMonthRangeResult.ToDate = dtpTo.Value;
                return myMonthRangeResult;
            }

            set
            {
                myMonthRangeResult = value;
                SetControlsInternal();
            }
        }

        private void SetControlsInternal()
        {
            optRelatedMonth.Checked = true;
            cmbMonthRange.SelectedIndex = (int)(myMonthRangeResult.MonthRangeBase);
            {
                var __select0 = (int)(myMonthRangeResult.RelatedMonth);
                if (__select0 == (int)(RelatedMonth.CurrentMonth))
                {
                    optCurrentMonth.Checked = true;
                }
                else if (__select0 == (int)(RelatedMonth.PreviousMonth))
                {
                    optPreviousMonth.Checked = true;
                }
                else if (__select0 == (int)(RelatedMonth.SecondLastMonth))
                {
                    optSecondLastMonth.Checked = true;
                }
            }

            myFromInner = true;
            dtpFrom.Value = myMonthRangeResult.FromDate;
            dtpTo.Value = myMonthRangeResult.ToDate;
            myFromInner = false;
        }

        public string DateRangeText
        {
            get
            {
                {
                    var __with1 = myMonthRangeResult;
                    return __with1.FromDate.ToString("dd. MMMM yy") + " - " + __with1.ToDate.ToString("dd. MMMM yy");
                }

                return default(string);
            }
        }

        private void dtps_ValuesChanged(System.Object sender, System.EventArgs e)
        {
            if (myFromInner)
            {
                return;
            }

            optFreeRange.Checked = true;
        }

        private void cmbMonthRange_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            myMonthRangeResult.MonthRangeBase = ((MonthRangeBase)cmbMonthRange.SelectedIndex);
            SetControlsInternal();
        }

        private void optRelatedMonth_Changed(System.Object sender, System.EventArgs e)
        {
            if (optCurrentMonth.Checked)
            {
                myMonthRangeResult.RelatedMonth = RelatedMonth.CurrentMonth;
            }
            else if (optPreviousMonth.Checked)
            {
                myMonthRangeResult.RelatedMonth = RelatedMonth.PreviousMonth;
            }
            else if (optSecondLastMonth.Checked)
            {
                myMonthRangeResult.RelatedMonth = RelatedMonth.SecondLastMonth;
            }

            SetControlsInternal();
        }
    }
}