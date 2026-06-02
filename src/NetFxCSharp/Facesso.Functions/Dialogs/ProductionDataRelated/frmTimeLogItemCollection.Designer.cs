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
    public partial class frmTimeLogItemCollection : frmBaseFacesso
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
            this.btnShiftStart = new System.Windows.Forms.Button();
            this.lblMinutesAttendance = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblShiftStartDate = new System.Windows.Forms.Label();
            this.btnShiftEnd = new System.Windows.Forms.Button();
            this.lblShiftEndDate = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.lblMinutesEffective = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.lblMinutesEffectiveAdj = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.Label12 = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblMinutesWorkingTime = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.nibDownTime = new ActiveDev.Controls.ADNullableIntBox();
            this.nibWorkBreak = new ActiveDev.Controls.ADNullableIntBox();
            this.ndbShiftEnd = new ActiveDev.Controls.ADNullableDateTimeBox();
            this.ndbShiftStart = new ActiveDev.Controls.ADNullableDateTimeBox();
            this.ndbHandicap = new ActiveDev.Controls.ADNullableDoubleBox();
            this.SuspendLayout();
            //
            //btnShiftStart
            //
            this.btnShiftStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.btnShiftStart.Location = new System.Drawing.Point(11, 18);
            this.btnShiftStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnShiftStart.Name = "btnShiftStart";
            this.btnShiftStart.Size = new System.Drawing.Size(89, 21);
            this.btnShiftStart.TabIndex = 6;
            this.btnShiftStart.Text = "Dieser &Tag";
            //
            //lblMinutesAttendance
            //
            this.lblMinutesAttendance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMinutesAttendance.Location = new System.Drawing.Point(400, 41);
            this.lblMinutesAttendance.Name = "lblMinutesAttendance";
            this.lblMinutesAttendance.Size = new System.Drawing.Size(59, 20);
            this.lblMinutesAttendance.TabIndex = 17;
            this.lblMinutesAttendance.Text = "0";
            this.lblMinutesAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //Label2
            //
            this.Label2.Location = new System.Drawing.Point(465, 42);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(51, 20);
            this.Label2.TabIndex = 18;
            this.Label2.Text = "Minuten";
            //
            //lblShiftStartDate
            //
            this.lblShiftStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblShiftStartDate.Location = new System.Drawing.Point(102, 18);
            this.lblShiftStartDate.Name = "lblShiftStartDate";
            this.lblShiftStartDate.Size = new System.Drawing.Size(81, 18);
            this.lblShiftStartDate.TabIndex = 8;
            this.lblShiftStartDate.Text = "Do, 24.07.2005";
            this.lblShiftStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //btnShiftEnd
            //
            this.btnShiftEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.btnShiftEnd.Location = new System.Drawing.Point(204, 18);
            this.btnShiftEnd.Margin = new System.Windows.Forms.Padding(4);
            this.btnShiftEnd.Name = "btnShiftEnd";
            this.btnShiftEnd.Size = new System.Drawing.Size(89, 21);
            this.btnShiftEnd.TabIndex = 7;
            this.btnShiftEnd.Text = "Dieser Ta&g";
            //
            //lblShiftEndDate
            //
            this.lblShiftEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblShiftEndDate.Location = new System.Drawing.Point(293, 18);
            this.lblShiftEndDate.Name = "lblShiftEndDate";
            this.lblShiftEndDate.Size = new System.Drawing.Size(81, 18);
            this.lblShiftEndDate.TabIndex = 9;
            this.lblShiftEndDate.Text = "Do, 24.07.2005";
            this.lblShiftEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //Label5
            //
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label5.Location = new System.Drawing.Point(398, 21);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(116, 16);
            this.Label5.TabIndex = 16;
            this.Label5.Text = "Gesamtpr�senz:";
            //
            //Label6
            //
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label6.Location = new System.Drawing.Point(202, 127);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(83, 16);
            this.Label6.TabIndex = 13;
            this.Label6.Text = "Effektivzeit:";
            //
            //Label7
            //
            this.Label7.Location = new System.Drawing.Point(302, 149);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(51, 20);
            this.Label7.TabIndex = 15;
            this.Label7.Text = "Minuten";
            //
            //lblMinutesEffective
            //
            this.lblMinutesEffective.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMinutesEffective.Location = new System.Drawing.Point(204, 147);
            this.lblMinutesEffective.Name = "lblMinutesEffective";
            this.lblMinutesEffective.Size = new System.Drawing.Size(89, 20);
            this.lblMinutesEffective.TabIndex = 14;
            this.lblMinutesEffective.Text = "0";
            this.lblMinutesEffective.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //Label9
            //
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label9.Location = new System.Drawing.Point(10, 129);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(187, 17);
            this.Label9.TabIndex = 12;
            this.Label9.Text = "(Zuschlag in % zum Ausgleich)";
            //
            //Label10
            //
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label10.Location = new System.Drawing.Point(398, 127);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(81, 16);
            this.Label10.TabIndex = 22;
            this.Label10.Text = "angepasst:";
            //
            //lblMinutesEffectiveAdj
            //
            this.lblMinutesEffectiveAdj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMinutesEffectiveAdj.Location = new System.Drawing.Point(400, 147);
            this.lblMinutesEffectiveAdj.Name = "lblMinutesEffectiveAdj";
            this.lblMinutesEffectiveAdj.Size = new System.Drawing.Size(59, 20);
            this.lblMinutesEffectiveAdj.TabIndex = 23;
            this.lblMinutesEffectiveAdj.Text = "0";
            this.lblMinutesEffectiveAdj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(307, 195);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 30);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            //
            //Label12
            //
            this.Label12.Location = new System.Drawing.Point(463, 149);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(51, 20);
            this.Label12.TabIndex = 24;
            this.Label12.Text = "Minuten";
            //
            //Button1
            //
            this.Button1.Location = new System.Drawing.Point(11, 195);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(226, 30);
            this.Button1.TabIndex = 10;
            this.Button1.Text = "&Kernzeiten des letzten Arbeitstages";
            //
            //btnCancel
            //
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(413, 195);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Abbrechen";
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label1.Location = new System.Drawing.Point(398, 72);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(81, 16);
            this.Label1.TabIndex = 19;
            this.Label1.Text = "Arbeitszeit:";
            //
            //lblMinutesWorkingTime
            //
            this.lblMinutesWorkingTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMinutesWorkingTime.Location = new System.Drawing.Point(400, 92);
            this.lblMinutesWorkingTime.Name = "lblMinutesWorkingTime";
            this.lblMinutesWorkingTime.Size = new System.Drawing.Size(59, 20);
            this.lblMinutesWorkingTime.TabIndex = 20;
            this.lblMinutesWorkingTime.Text = "0";
            this.lblMinutesWorkingTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //Label4
            //
            this.Label4.Location = new System.Drawing.Point(465, 94);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(51, 20);
            this.Label4.TabIndex = 21;
            this.Label4.Text = "Minuten";
            //
            //nibDownTime
            //
            this.nibDownTime.BackColor = System.Drawing.SystemColors.Window;
            this.nibDownTime.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.nibDownTime.CaptionToValueRatio = 500;
            this.nibDownTime.ColorOnFocus = true;
            this.nibDownTime.FailedValidationErrorMessage = null;
            this.nibDownTime.FormularText = "";
            this.nibDownTime.HasCaption = true;
            this.nibDownTime.IndependentDatafieldName = null;
            this.nibDownTime.Location = new System.Drawing.Point(204, 91);
            this.nibDownTime.MaxValue = 0;
            this.nibDownTime.MinValue = 0;
            this.nibDownTime.Name = "nibDownTime";
            this.nibDownTime.NullString = "* --- *";
            this.nibDownTime.NullValueMessage = null;
            this.nibDownTime.Size = new System.Drawing.Size(178, 23);
            this.nibDownTime.TabIndex = 3;
            this.nibDownTime.Text = "&Ausfall:";
            this.nibDownTime.ValueAreaLength = 89;
            //
            //nibWorkBreak
            //
            this.nibWorkBreak.BackColor = System.Drawing.SystemColors.Window;
            this.nibWorkBreak.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.nibWorkBreak.CaptionToValueRatio = 500;
            this.nibWorkBreak.ColorOnFocus = true;
            this.nibWorkBreak.FailedValidationErrorMessage = null;
            this.nibWorkBreak.FormularText = "";
            this.nibWorkBreak.HasCaption = true;
            this.nibWorkBreak.IndependentDatafieldName = null;
            this.nibWorkBreak.Location = new System.Drawing.Point(12, 91);
            this.nibWorkBreak.MaxValue = 0;
            this.nibWorkBreak.MinValue = 0;
            this.nibWorkBreak.Name = "nibWorkBreak";
            this.nibWorkBreak.NullString = "* --- *";
            this.nibWorkBreak.NullValueMessage = null;
            this.nibWorkBreak.Size = new System.Drawing.Size(178, 23);
            this.nibWorkBreak.TabIndex = 2;
            this.nibWorkBreak.Text = "&Pause:";
            this.nibWorkBreak.ValueAreaLength = 89;
            //
            //ndbShiftEnd
            //
            this.ndbShiftEnd.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime;
            this.ndbShiftEnd.BackColor = System.Drawing.SystemColors.Window;
            this.ndbShiftEnd.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.ndbShiftEnd.CaptionToValueRatio = 500;
            this.ndbShiftEnd.ColorOnFocus = true;
            this.ndbShiftEnd.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime;
            this.ndbShiftEnd.FailedValidationErrorMessage = null;
            this.ndbShiftEnd.HasCaption = true;
            this.ndbShiftEnd.IndependentDatafieldName = null;
            this.ndbShiftEnd.Location = new System.Drawing.Point(205, 39);
            this.ndbShiftEnd.Name = "ndbShiftEnd";
            this.ndbShiftEnd.NullString = "* --- *";
            this.ndbShiftEnd.NullValueMessage = null;
            this.ndbShiftEnd.Size = new System.Drawing.Size(178, 23);
            this.ndbShiftEnd.TabIndex = 1;
            this.ndbShiftEnd.Text = "&Endzeit:";
            this.ndbShiftEnd.ValueAreaLength = 89;
            //
            //ndbShiftStart
            //
            this.ndbShiftStart.AssignFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime;
            this.ndbShiftStart.BackColor = System.Drawing.SystemColors.Window;
            this.ndbShiftStart.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.ndbShiftStart.CaptionToValueRatio = 500;
            this.ndbShiftStart.ColorOnFocus = true;
            this.ndbShiftStart.DisplayFormat = ActiveDev.Controls.ADUVDateTimeFormat.ShortTime;
            this.ndbShiftStart.FailedValidationErrorMessage = null;
            this.ndbShiftStart.HasCaption = true;
            this.ndbShiftStart.IndependentDatafieldName = null;
            this.ndbShiftStart.Location = new System.Drawing.Point(12, 39);
            this.ndbShiftStart.Name = "ndbShiftStart";
            this.ndbShiftStart.NullString = "* --- *";
            this.ndbShiftStart.NullValueMessage = null;
            this.ndbShiftStart.Size = new System.Drawing.Size(178, 23);
            this.ndbShiftStart.TabIndex = 0;
            this.ndbShiftStart.Text = "&Startzeit:";
            this.ndbShiftStart.ValueAreaLength = 89;
            //
            //ndbHandicap
            //
            this.ndbHandicap.BackColor = System.Drawing.SystemColors.Window;
            this.ndbHandicap.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.ndbHandicap.CaptionToValueRatio = 500;
            this.ndbHandicap.ColorOnFocus = true;
            this.ndbHandicap.CurrencyText = "";
            this.ndbHandicap.FailedValidationErrorMessage = null;
            this.ndbHandicap.FormularText = "";
            this.ndbHandicap.HasCaption = true;
            this.ndbHandicap.IndependentDatafieldName = null;
            this.ndbHandicap.Location = new System.Drawing.Point(11, 150);
            this.ndbHandicap.MaxValue = 99;
            this.ndbHandicap.MinValue = 0;
            this.ndbHandicap.Name = "ndbHandicap";
            this.ndbHandicap.NullString = "* --- *";
            this.ndbHandicap.NullValueMessage = null;
            this.ndbHandicap.Size = new System.Drawing.Size(178, 23);
            this.ndbHandicap.TabIndex = 4;
            this.ndbHandicap.Text = "Handicap:";
            this.ndbHandicap.ValueAreaLength = 89;
            //
            //frmTimeLogItemCollection
            //
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(522, 238);
            this.Controls.Add(this.ndbHandicap);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lblMinutesWorkingTime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.lblMinutesEffectiveAdj);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.lblMinutesEffective);
            this.Controls.Add(this.nibDownTime);
            this.Controls.Add(this.nibWorkBreak);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.lblShiftEndDate);
            this.Controls.Add(this.btnShiftEnd);
            this.Controls.Add(this.lblShiftStartDate);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.lblMinutesAttendance);
            this.Controls.Add(this.ndbShiftEnd);
            this.Controls.Add(this.ndbShiftStart);
            this.Controls.Add(this.btnShiftStart);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTimeLogItemCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button _btnShiftStart;
        internal System.Windows.Forms.Button btnShiftStart
        {
            get
            {
                return _btnShiftStart;
            }

            set
            {
                if (_btnShiftStart != null)
                {
                    _btnShiftStart.Click -= btnShiftStart_Click;
                }

                _btnShiftStart = value;
                if (_btnShiftStart != null)
                {
                    _btnShiftStart.Click += btnShiftStart_Click;
                }
            }
        }

        private ActiveDev.Controls.ADNullableDateTimeBox _ndbShiftStart;
        internal ActiveDev.Controls.ADNullableDateTimeBox ndbShiftStart
        {
            get
            {
                return _ndbShiftStart;
            }

            set
            {
                if (_ndbShiftStart != null)
                {
                    _ndbShiftStart.Validated -= GenericValidated;
                }

                _ndbShiftStart = value;
                if (_ndbShiftStart != null)
                {
                    _ndbShiftStart.Validated += GenericValidated;
                }
            }
        }

        private ActiveDev.Controls.ADNullableDateTimeBox _ndbShiftEnd;
        internal ActiveDev.Controls.ADNullableDateTimeBox ndbShiftEnd
        {
            get
            {
                return _ndbShiftEnd;
            }

            set
            {
                if (_ndbShiftEnd != null)
                {
                    _ndbShiftEnd.Validated -= GenericValidated;
                }

                _ndbShiftEnd = value;
                if (_ndbShiftEnd != null)
                {
                    _ndbShiftEnd.Validated += GenericValidated;
                }
            }
        }

        internal System.Windows.Forms.Label lblMinutesAttendance;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label lblShiftStartDate;
        private System.Windows.Forms.Button _btnShiftEnd;
        internal System.Windows.Forms.Button btnShiftEnd
        {
            get
            {
                return _btnShiftEnd;
            }

            set
            {
                if (_btnShiftEnd != null)
                {
                    _btnShiftEnd.Click -= btnShiftEnd_Click;
                }

                _btnShiftEnd = value;
                if (_btnShiftEnd != null)
                {
                    _btnShiftEnd.Click += btnShiftEnd_Click;
                }
            }
        }

        internal System.Windows.Forms.Label lblShiftEndDate;
        internal System.Windows.Forms.Label Label5;
        private ActiveDev.Controls.ADNullableIntBox _nibWorkBreak;
        internal ActiveDev.Controls.ADNullableIntBox nibWorkBreak
        {
            get
            {
                return _nibWorkBreak;
            }

            set
            {
                if (_nibWorkBreak != null)
                {
                    _nibWorkBreak.Validated -= GenericValidated;
                }

                _nibWorkBreak = value;
                if (_nibWorkBreak != null)
                {
                    _nibWorkBreak.Validated += GenericValidated;
                }
            }
        }

        private ActiveDev.Controls.ADNullableIntBox _nibDownTime;
        internal ActiveDev.Controls.ADNullableIntBox nibDownTime
        {
            get
            {
                return _nibDownTime;
            }

            set
            {
                if (_nibDownTime != null)
                {
                    _nibDownTime.Validated -= GenericValidated;
                }

                _nibDownTime = value;
                if (_nibDownTime != null)
                {
                    _nibDownTime.Validated += GenericValidated;
                }
            }
        }

        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label lblMinutesEffective;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label lblMinutesEffectiveAdj;
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

        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Button Button1;
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

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lblMinutesWorkingTime;
        internal System.Windows.Forms.Label Label4;
        private ActiveDev.Controls.ADNullableDoubleBox _ndbHandicap;
        internal ActiveDev.Controls.ADNullableDoubleBox ndbHandicap
        {
            get
            {
                return _ndbHandicap;
            }

            set
            {
                if (_ndbHandicap != null)
                {
                    _ndbHandicap.Validated -= GenericValidated;
                }

                _ndbHandicap = value;
                if (_ndbHandicap != null)
                {
                    _ndbHandicap.Validated += GenericValidated;
                }
            }
        }
    }
}