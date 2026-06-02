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

namespace Facesso
{
    public class ToolStripMonthCalender : ToolStripControlHost
    {
        // Call the base constructor passing in a MonthCalendar instance.
        public ToolStripMonthCalender() : base(new MonthCalendar())
        {
        }

        public MonthCalendar MonthCalendarControl
        {
            get
            {
                return ((MonthCalendar)Control);
            }
        }

        // Expose the MonthCalendar.FirstDayOfWeek as a property.
        public Day FirstDayOfWeek
        {
            get
            {
                return MonthCalendarControl.FirstDayOfWeek;
            }

            set
            {
                value = MonthCalendarControl.FirstDayOfWeek;
            }
        }

        public System.DateTime Value
        {
            get
            {
                return MonthCalendarControl.SelectionStart;
            }

            set
            {
                MonthCalendarControl.SelectionStart = value;
                MonthCalendarControl.SelectionEnd = value;
            }
        }

        // Expose the AddBoldedDate method.
        public void AddBoldedDate(DateTime dateToBold)
        {
            MonthCalendarControl.AddBoldedDate(dateToBold);
        }

        public void RemoveBoldedDate(DateTime dateToUnbold)
        {
            MonthCalendarControl.RemoveBoldedDate(dateToUnbold);
        }

        public void RemoveAllBoldedDates()
        {
            MonthCalendarControl.RemoveAllBoldedDates();
        }

        // Subscribe and unsubscribe the control events you wish to expose.
        protected override void OnSubscribeControlEvents(Control c)
        {
            // Call the base so the base events are connected.
            base.OnSubscribeControlEvents(c);
            // Cast the control to a MonthCalendar control.
            MonthCalendar monthCalendarControl = ((MonthCalendar)c);
            // Add the event.
            monthCalendarControl.DateChanged += HandleDateChanged;
        }

        protected override void OnUnsubscribeControlEvents(Control c)
        {
            // Call the base method so the basic events are unsubscribed.
            base.OnUnsubscribeControlEvents(c);
            // Cast the control to a MonthCalendar control.
            MonthCalendar monthCalendarControl = ((MonthCalendar)c);
            // Remove the event.
            monthCalendarControl.DateChanged -= HandleDateChanged;
        }

        // Declare the DateChanged event.
        public event DateRangeEventHandler DateChanged;
        // Raise the DateChanged event.
        private void HandleDateChanged(object sender, DateRangeEventArgs e)
        {
            DateChanged?.Invoke(this, e);
        }
    }
}