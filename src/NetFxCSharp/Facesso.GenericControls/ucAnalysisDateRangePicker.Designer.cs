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
    public partial class ucAnalysisDateRangePicker : System.Windows.Forms.UserControl
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
            this.gbTitle = new System.Windows.Forms.GroupBox();
            this.cmbMonthsHistory = new System.Windows.Forms.ComboBox();
            this.optWeekBeforeLastWeek = new System.Windows.Forms.RadioButton();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.Label2 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.optCustomPeriod = new System.Windows.Forms.RadioButton();
            this.Label1 = new System.Windows.Forms.Label();
            this.optToday = new System.Windows.Forms.RadioButton();
            this.optYesterday = new System.Windows.Forms.RadioButton();
            this.optLastWeek = new System.Windows.Forms.RadioButton();
            this.optFromStartOfCurrentWeekToNow = new System.Windows.Forms.RadioButton();
            this.optSinceYearBegan = new System.Windows.Forms.RadioButton();
            this.optStartToEndOfSpecifiedMonth = new System.Windows.Forms.RadioButton();
            this.optFromStartOfCurrentMonthToNow = new System.Windows.Forms.RadioButton();
            this.gbTitle.SuspendLayout();
            this.SuspendLayout();
            //
            //gbTitle
            //
            this.gbTitle.Controls.Add(this.cmbMonthsHistory);
            this.gbTitle.Controls.Add(this.optWeekBeforeLastWeek);
            this.gbTitle.Controls.Add(this.dtpEnd);
            this.gbTitle.Controls.Add(this.Label2);
            this.gbTitle.Controls.Add(this.dtpStart);
            this.gbTitle.Controls.Add(this.optCustomPeriod);
            this.gbTitle.Controls.Add(this.Label1);
            this.gbTitle.Controls.Add(this.optToday);
            this.gbTitle.Controls.Add(this.optYesterday);
            this.gbTitle.Controls.Add(this.optLastWeek);
            this.gbTitle.Controls.Add(this.optFromStartOfCurrentWeekToNow);
            this.gbTitle.Controls.Add(this.optSinceYearBegan);
            this.gbTitle.Controls.Add(this.optStartToEndOfSpecifiedMonth);
            this.gbTitle.Controls.Add(this.optFromStartOfCurrentMonthToNow);
            this.gbTitle.Location = new System.Drawing.Point(0, 0);
            this.gbTitle.Name = "gbTitle";
            this.gbTitle.Size = new System.Drawing.Size(342, 307);
            this.gbTitle.TabIndex = 0;
            this.gbTitle.TabStop = false;
            //
            //cmbMonthsHistory
            //
            this.cmbMonthsHistory.FormattingEnabled = true;
            this.cmbMonthsHistory.Location = new System.Drawing.Point(26, 180);
            this.cmbMonthsHistory.Name = "cmbMonthsHistory";
            this.cmbMonthsHistory.Size = new System.Drawing.Size(228, 21);
            this.cmbMonthsHistory.TabIndex = 14;
            //
            //optWeekBeforeLastWeek
            //
            this.optWeekBeforeLastWeek.AutoSize = true;
            this.optWeekBeforeLastWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.optWeekBeforeLastWeek.Location = new System.Drawing.Point(6, 65);
            this.optWeekBeforeLastWeek.Name = "optWeekBeforeLastWeek";
            this.optWeekBeforeLastWeek.Size = new System.Drawing.Size(119, 17);
            this.optWeekBeforeLastWeek.TabIndex = 13;
            this.optWeekBeforeLastWeek.Text = "Vorletzte Woche";
            this.optWeekBeforeLastWeek.UseVisualStyleBackColor = true;
            //
            //dtpEnd
            //
            this.dtpEnd.Location = new System.Drawing.Point(121, 279);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(209, 20);
            this.dtpEnd.TabIndex = 12;
            //
            //Label2
            //
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(40, 279);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(72, 13);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Endzeitpunkt:";
            //
            //dtpStart
            //
            this.dtpStart.Location = new System.Drawing.Point(121, 253);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(209, 20);
            this.dtpStart.TabIndex = 10;
            //
            //optCustomPeriod
            //
            this.optCustomPeriod.AutoSize = true;
            this.optCustomPeriod.Location = new System.Drawing.Point(6, 230);
            this.optCustomPeriod.Name = "optCustomPeriod";
            this.optCustomPeriod.Size = new System.Drawing.Size(135, 17);
            this.optCustomPeriod.TabIndex = 9;
            this.optCustomPeriod.Text = "Freigewählter Zeitraum:";
            this.optCustomPeriod.UseVisualStyleBackColor = true;
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(40, 259);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(75, 13);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Startzeitpunkt:";
            //
            //optToday
            //
            this.optToday.AutoSize = true;
            this.optToday.Location = new System.Drawing.Point(6, 42);
            this.optToday.Name = "optToday";
            this.optToday.Size = new System.Drawing.Size(54, 17);
            this.optToday.TabIndex = 7;
            this.optToday.Text = "Heute";
            this.optToday.UseVisualStyleBackColor = true;
            //
            //optYesterday
            //
            this.optYesterday.AutoSize = true;
            this.optYesterday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.optYesterday.Location = new System.Drawing.Point(6, 19);
            this.optYesterday.Name = "optYesterday";
            this.optYesterday.Size = new System.Drawing.Size(199, 17);
            this.optYesterday.TabIndex = 6;
            this.optYesterday.Text = "Gestern bzw. letzter Arbeitstag";
            this.optYesterday.UseVisualStyleBackColor = true;
            //
            //optLastWeek
            //
            this.optLastWeek.AutoSize = true;
            this.optLastWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.optLastWeek.Location = new System.Drawing.Point(6, 88);
            this.optLastWeek.Name = "optLastWeek";
            this.optLastWeek.Size = new System.Drawing.Size(104, 17);
            this.optLastWeek.TabIndex = 5;
            this.optLastWeek.Text = "Letzte Woche";
            this.optLastWeek.UseVisualStyleBackColor = true;
            //
            //optFromStartOfCurrentWeekToNow
            //
            this.optFromStartOfCurrentWeekToNow.AutoSize = true;
            this.optFromStartOfCurrentWeekToNow.Location = new System.Drawing.Point(6, 111);
            this.optFromStartOfCurrentWeekToNow.Name = "optFromStartOfCurrentWeekToNow";
            this.optFromStartOfCurrentWeekToNow.Size = new System.Drawing.Size(161, 17);
            this.optFromStartOfCurrentWeekToNow.TabIndex = 4;
            this.optFromStartOfCurrentWeekToNow.Text = "Anfang der Woche bis heute";
            this.optFromStartOfCurrentWeekToNow.UseVisualStyleBackColor = true;
            //
            //optSinceYearBegan
            //
            this.optSinceYearBegan.AutoSize = true;
            this.optSinceYearBegan.Location = new System.Drawing.Point(6, 207);
            this.optSinceYearBegan.Name = "optSinceYearBegan";
            this.optSinceYearBegan.Size = new System.Drawing.Size(151, 17);
            this.optSinceYearBegan.TabIndex = 3;
            this.optSinceYearBegan.Text = "Anfang des Jahres bis jetzt";
            this.optSinceYearBegan.UseVisualStyleBackColor = true;
            //
            //optStartToEndOfSpecifiedMonth
            //
            this.optStartToEndOfSpecifiedMonth.AutoSize = true;
            this.optStartToEndOfSpecifiedMonth.Checked = true;
            this.optStartToEndOfSpecifiedMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.optStartToEndOfSpecifiedMonth.Location = new System.Drawing.Point(6, 157);
            this.optStartToEndOfSpecifiedMonth.Name = "optStartToEndOfSpecifiedMonth";
            this.optStartToEndOfSpecifiedMonth.Size = new System.Drawing.Size(227, 17);
            this.optStartToEndOfSpecifiedMonth.TabIndex = 1;
            this.optStartToEndOfSpecifiedMonth.TabStop = true;
            this.optStartToEndOfSpecifiedMonth.Text = "Anfang bis Ende folgenden Monats:";
            this.optStartToEndOfSpecifiedMonth.UseVisualStyleBackColor = true;
            //
            //optFromStartOfCurrentMonthToNow
            //
            this.optFromStartOfCurrentMonthToNow.AutoSize = true;
            this.optFromStartOfCurrentMonthToNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.optFromStartOfCurrentMonthToNow.Location = new System.Drawing.Point(6, 134);
            this.optFromStartOfCurrentMonthToNow.Name = "optFromStartOfCurrentMonthToNow";
            this.optFromStartOfCurrentMonthToNow.Size = new System.Drawing.Size(213, 17);
            this.optFromStartOfCurrentMonthToNow.TabIndex = 0;
            this.optFromStartOfCurrentMonthToNow.Text = "Anfang aktueller Monat bis heute";
            this.optFromStartOfCurrentMonthToNow.UseVisualStyleBackColor = true;
            //
            //ucAnalysisDateRangePicker
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbTitle);
            this.Name = "ucAnalysisDateRangePicker";
            this.Size = new System.Drawing.Size(345, 310);
            this.gbTitle.ResumeLayout(false);
            this.gbTitle.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox _gbTitle;
        internal System.Windows.Forms.GroupBox gbTitle
        {
            get
            {
                return _gbTitle;
            }

            set
            {
                if (_gbTitle != null)
                {
                    _gbTitle.Enter -= gbTitle_Enter;
                }

                _gbTitle = value;
                if (_gbTitle != null)
                {
                    _gbTitle.Enter += gbTitle_Enter;
                }
            }
        }

        private System.Windows.Forms.RadioButton _optFromStartOfCurrentMonthToNow;
        internal System.Windows.Forms.RadioButton optFromStartOfCurrentMonthToNow
        {
            get
            {
                return _optFromStartOfCurrentMonthToNow;
            }

            set
            {
                if (_optFromStartOfCurrentMonthToNow != null)
                {
                    _optFromStartOfCurrentMonthToNow.CheckedChanged -= optDateRanges_CheckedChanged;
                }

                _optFromStartOfCurrentMonthToNow = value;
                if (_optFromStartOfCurrentMonthToNow != null)
                {
                    _optFromStartOfCurrentMonthToNow.CheckedChanged += optDateRanges_CheckedChanged;
                }
            }
        }

        private System.Windows.Forms.RadioButton _optStartToEndOfSpecifiedMonth;
        internal System.Windows.Forms.RadioButton optStartToEndOfSpecifiedMonth
        {
            get
            {
                return _optStartToEndOfSpecifiedMonth;
            }

            set
            {
                if (_optStartToEndOfSpecifiedMonth != null)
                {
                    _optStartToEndOfSpecifiedMonth.CheckedChanged -= optDateRanges_CheckedChanged;
                }

                _optStartToEndOfSpecifiedMonth = value;
                if (_optStartToEndOfSpecifiedMonth != null)
                {
                    _optStartToEndOfSpecifiedMonth.CheckedChanged += optDateRanges_CheckedChanged;
                }
            }
        }

        private System.Windows.Forms.RadioButton _optSinceYearBegan;
        internal System.Windows.Forms.RadioButton optSinceYearBegan
        {
            get
            {
                return _optSinceYearBegan;
            }

            set
            {
                if (_optSinceYearBegan != null)
                {
                    _optSinceYearBegan.CheckedChanged -= optDateRanges_CheckedChanged;
                }

                _optSinceYearBegan = value;
                if (_optSinceYearBegan != null)
                {
                    _optSinceYearBegan.CheckedChanged += optDateRanges_CheckedChanged;
                }
            }
        }

        private System.Windows.Forms.RadioButton _optFromStartOfCurrentWeekToNow;
        internal System.Windows.Forms.RadioButton optFromStartOfCurrentWeekToNow
        {
            get
            {
                return _optFromStartOfCurrentWeekToNow;
            }

            set
            {
                if (_optFromStartOfCurrentWeekToNow != null)
                {
                    _optFromStartOfCurrentWeekToNow.CheckedChanged -= optDateRanges_CheckedChanged;
                }

                _optFromStartOfCurrentWeekToNow = value;
                if (_optFromStartOfCurrentWeekToNow != null)
                {
                    _optFromStartOfCurrentWeekToNow.CheckedChanged += optDateRanges_CheckedChanged;
                }
            }
        }

        private System.Windows.Forms.RadioButton _optLastWeek;
        internal System.Windows.Forms.RadioButton optLastWeek
        {
            get
            {
                return _optLastWeek;
            }

            set
            {
                if (_optLastWeek != null)
                {
                    _optLastWeek.CheckedChanged -= optDateRanges_CheckedChanged;
                }

                _optLastWeek = value;
                if (_optLastWeek != null)
                {
                    _optLastWeek.CheckedChanged += optDateRanges_CheckedChanged;
                }
            }
        }

        private System.Windows.Forms.RadioButton _optYesterday;
        internal System.Windows.Forms.RadioButton optYesterday
        {
            get
            {
                return _optYesterday;
            }

            set
            {
                if (_optYesterday != null)
                {
                    _optYesterday.CheckedChanged -= optDateRanges_CheckedChanged;
                }

                _optYesterday = value;
                if (_optYesterday != null)
                {
                    _optYesterday.CheckedChanged += optDateRanges_CheckedChanged;
                }
            }
        }

        private System.Windows.Forms.RadioButton _optToday;
        internal System.Windows.Forms.RadioButton optToday
        {
            get
            {
                return _optToday;
            }

            set
            {
                if (_optToday != null)
                {
                    _optToday.CheckedChanged -= optDateRanges_CheckedChanged;
                }

                _optToday = value;
                if (_optToday != null)
                {
                    _optToday.CheckedChanged += optDateRanges_CheckedChanged;
                }
            }
        }

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.RadioButton optCustomPeriod;
        private System.Windows.Forms.DateTimePicker _dtpStart;
        internal System.Windows.Forms.DateTimePicker dtpStart
        {
            get
            {
                return _dtpStart;
            }

            set
            {
                if (_dtpStart != null)
                {
                    _dtpStart.ValueChanged -= dtpStart_ValueChanged;
                }

                _dtpStart = value;
                if (_dtpStart != null)
                {
                    _dtpStart.ValueChanged += dtpStart_ValueChanged;
                }
            }
        }

        private System.Windows.Forms.DateTimePicker _dtpEnd;
        internal System.Windows.Forms.DateTimePicker dtpEnd
        {
            get
            {
                return _dtpEnd;
            }

            set
            {
                if (_dtpEnd != null)
                {
                    _dtpEnd.ValueChanged -= dtpEnd_ValueChanged;
                }

                _dtpEnd = value;
                if (_dtpEnd != null)
                {
                    _dtpEnd.ValueChanged += dtpEnd_ValueChanged;
                }
            }
        }

        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.RadioButton _optWeekBeforeLastWeek;
        internal System.Windows.Forms.RadioButton optWeekBeforeLastWeek
        {
            get
            {
                return _optWeekBeforeLastWeek;
            }

            set
            {
                if (_optWeekBeforeLastWeek != null)
                {
                    _optWeekBeforeLastWeek.CheckedChanged -= optDateRanges_CheckedChanged;
                }

                _optWeekBeforeLastWeek = value;
                if (_optWeekBeforeLastWeek != null)
                {
                    _optWeekBeforeLastWeek.CheckedChanged += optDateRanges_CheckedChanged;
                }
            }
        }

        private System.Windows.Forms.ComboBox _cmbMonthsHistory;
        internal System.Windows.Forms.ComboBox cmbMonthsHistory
        {
            get
            {
                return _cmbMonthsHistory;
            }

            set
            {
                if (_cmbMonthsHistory != null)
                {
                    _cmbMonthsHistory.SelectedIndexChanged -= cmbMonthsHistory_SelectedIndexChanged;
                }

                _cmbMonthsHistory = value;
                if (_cmbMonthsHistory != null)
                {
                    _cmbMonthsHistory.SelectedIndexChanged += cmbMonthsHistory_SelectedIndexChanged;
                }
            }
        }
    }
}