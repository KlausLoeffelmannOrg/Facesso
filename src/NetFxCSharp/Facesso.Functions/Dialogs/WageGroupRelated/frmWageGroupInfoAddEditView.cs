using ActiveDev;
using ActiveDev.Controls;
using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public class frmWageGroupInfoAddEditView : Facesso.Functions.frmInfoItemAddEditViewBase
    {
        public frmWageGroupInfoAddEditView() : base()
        {
            //This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        //Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!((components == null)))
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        internal ActiveDev.Controls.ADNullableTextBox ntbComment;
        internal ActiveDev.Controls.ADNullableTextBox ntbWageGroupToken;
        internal ActiveDev.Controls.ADNullableDoubleBox ndbHourlyRate;
        internal ActiveDev.Controls.ADNullableIdOrIndexComboBox ncbIDCurrency;
        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.ntbComment = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbWageGroupToken = new ActiveDev.Controls.ADNullableTextBox();
            this.ndbHourlyRate = new ActiveDev.Controls.ADNullableDoubleBox();
            this.ncbIDCurrency = new ActiveDev.Controls.ADNullableIdOrIndexComboBox();
            this.SuspendLayout();
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(468, 13);
            this.btnOK.TabIndex = 4;
            //
            //btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(468, 58);
            this.btnCancel.TabIndex = 5;
            //
            //ntbComment
            //
            this.ntbComment.BackColor = System.Drawing.SystemColors.Window;
            this.ntbComment.CaptionBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ntbComment.CaptionPlacement = ActiveDev.Controls.ADCaptionPlacementEnum.Above;
            this.ntbComment.CaptionToValueRatio = 1000;
            this.ntbComment.ColorOnFocus = true;
            this.ntbComment.FailedValidationErrorMessage = null;
            this.ntbComment.HasCaption = true;
            this.ntbComment.IndependentDatafieldName = "Comment";
            this.ntbComment.Location = new System.Drawing.Point(12, 113);
            this.ntbComment.Margin = new System.Windows.Forms.Padding(4);
            this.ntbComment.Multiline = true;
            this.ntbComment.Name = "ntbComment";
            this.ntbComment.NullString = "* --- *";
            this.ntbComment.NullValueMessage = null;
            this.ntbComment.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.ntbComment.Size = new System.Drawing.Size(426, 150);
            this.ntbComment.TabIndex = 3;
            this.ntbComment.Text = "Anmerkungen:";
            this.ntbComment.ValueAreaLength = 426;
            //
            //ntbWageGroupToken
            //
            this.ntbWageGroupToken.BackColor = System.Drawing.SystemColors.Window;
            this.ntbWageGroupToken.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbWageGroupToken.CaptionToValueRatio = 420.19;
            this.ntbWageGroupToken.ColorOnFocus = true;
            this.ntbWageGroupToken.FailedValidationErrorMessage = null;
            this.ntbWageGroupToken.HasCaption = true;
            this.ntbWageGroupToken.IndependentDatafieldName = "WageGroupToken";
            this.ntbWageGroupToken.Location = new System.Drawing.Point(11, 13);
            this.ntbWageGroupToken.Margin = new System.Windows.Forms.Padding(4);
            this.ntbWageGroupToken.MaxLength = 100;
            this.ntbWageGroupToken.Multiline = false;
            this.ntbWageGroupToken.Name = "ntbWageGroupToken";
            this.ntbWageGroupToken.NullString = "* --- *";
            this.ntbWageGroupToken.NullValueMessage = "Bitte geben Sie einen g�ltigen Kostenstellennamen ein!";
            this.ntbWageGroupToken.Size = new System.Drawing.Size(426, 23);
            this.ntbWageGroupToken.TabIndex = 0;
            this.ntbWageGroupToken.Text = "Lohngruppennr./-k�rzel:";
            this.ntbWageGroupToken.ValueAreaLength = 247;
            //
            //ndbHourlyRate
            //
            this.ndbHourlyRate.AssignFormatString = "#,##0.00";
            this.ndbHourlyRate.BackColor = System.Drawing.SystemColors.Window;
            this.ndbHourlyRate.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ndbHourlyRate.CaptionToValueRatio = 420.19;
            this.ndbHourlyRate.ColorOnFocus = true;
            this.ndbHourlyRate.CurrencyText = "";
            this.ndbHourlyRate.DisplayCustomFormatString = "#,##0.00";
            this.ndbHourlyRate.DisplayFormat = ActiveDev.Controls.ADUVNumFormat.UseCustomString;
            this.ndbHourlyRate.FailedValidationErrorMessage = null;
            this.ndbHourlyRate.FormularText = "";
            this.ndbHourlyRate.HasCaption = true;
            this.ndbHourlyRate.IndependentDatafieldName = "HourlyRate";
            this.ndbHourlyRate.Location = new System.Drawing.Point(11, 43);
            this.ndbHourlyRate.MaxValue = 0;
            this.ndbHourlyRate.MinValue = 0;
            this.ndbHourlyRate.Name = "ndbHourlyRate";
            this.ndbHourlyRate.NullString = "* --- *";
            this.ndbHourlyRate.NullValueMessage = "Bitte bestimmen Sie den Grundlohn pro Stunde!";
            this.ndbHourlyRate.Size = new System.Drawing.Size(426, 23);
            this.ndbHourlyRate.TabIndex = 1;
            this.ndbHourlyRate.Text = "Grundlohn (Stunde): ";
            this.ndbHourlyRate.ValueAreaLength = 247;
            //
            //ncbIDCurrency
            //
            this.ncbIDCurrency.BackColor = System.Drawing.SystemColors.Window;
            this.ncbIDCurrency.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ncbIDCurrency.CaptionToValueRatio = 420.19;
            this.ncbIDCurrency.ColorOnFocus = true;
            this.ncbIDCurrency.ComboBoxValueType = ActiveDev.Controls.ADNullableComboBoxValueType.ID_As_Int32;
            this.ncbIDCurrency.DropDownHeight = 106;
            this.ncbIDCurrency.DropDownWidth = 264;
            this.ncbIDCurrency.FailedValidationErrorMessage = null;
            this.ncbIDCurrency.HasCaption = true;
            this.ncbIDCurrency.IndependentDatafieldName = "IDCurrency";
            this.ncbIDCurrency.Location = new System.Drawing.Point(12, 72);
            this.ncbIDCurrency.MaxDropDownItems = 8;
            this.ncbIDCurrency.Name = "ncbIDCurrency";
            this.ncbIDCurrency.NullString = null;
            this.ncbIDCurrency.NullValueMessage = null;
            this.ncbIDCurrency.Size = new System.Drawing.Size(426, 24);
            this.ncbIDCurrency.TabIndex = 2;
            this.ncbIDCurrency.Text = "W�hrung:";
            this.ncbIDCurrency.ValueAreaLength = 247;
            //
            //frmWageGroupInfoAddEditView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.ClientSize = new System.Drawing.Size(598, 283);
            this.Controls.Add(this.ncbIDCurrency);
            this.Controls.Add(this.ndbHourlyRate);
            this.Controls.Add(this.ntbComment);
            this.Controls.Add(this.ntbWageGroupToken);
            this.Name = "frmWageGroupInfoAddEditView";
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.ntbWageGroupToken, 0);
            this.Controls.SetChildIndex(this.ntbComment, 0);
            this.Controls.SetChildIndex(this.ndbHourlyRate, 0);
            this.Controls.SetChildIndex(this.ncbIDCurrency, 0);
            this.ResumeLayout(false);
        }

        protected override void Fac_OnInitializeFormControls()
        {
            base.Fac_OnInitializeFormControls();
            Fac_FunctionsInternal.AddCurrencyToADNullableIdOrIndexComboBox(ncbIDCurrency);
        }

        protected override void Fac_OnAssigningToControls(ActiveDev.IInfoItem InfoItem)
        {
            Fac_FunctionsInternal.AddCurrencyToADNullableIdOrIndexComboBox(ncbIDCurrency);
            base.Fac_OnAssigningToControls(InfoItem);
        }

        protected override void Fac_OnValidatingNew(System.ComponentModel.CancelEventArgs e)
        {
            base.Fac_OnValidatingNew(e);
            SPAccess locSPA = SPAccess.GetInstance();
            //Feststellen, ob die Kostenstellennr. schon existiert
            if (locSPA.WageGroups_DoesTokenExist(FacessoGeneric.LoginInfo.IDSubsidiary, ntbWageGroupToken.TypeSafeValue, default(ActiveDev.ADDBNullable<int>)))
            {
                string locErr = Facesso.Functions.My.Resources.WageGroupInfoAdd_TokenAlreadyExists_MB_Body;
                locErr = string.Format(locErr, System.Convert.ToInt32(ntbWageGroupToken.TypeSafeValue), FacessoGeneric.SubsidiarySynonym, FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName);
                MessageBox.Show(locErr, Facesso.Functions.My.Resources.WageGroupInfoAdd_TokenAlreadyExists_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
        }

        protected override void Fac_OnValidatingEdit(InfoItemValidatingEventArgs e)
        {
            base.Fac_OnValidatingEdit(e);
            SPAccess locSPA = SPAccess.GetInstance();
            //Feststellen, ob die Kostenstellennr. schon existiert
            if (locSPA.WageGroups_DoesTokenExist(FacessoGeneric.LoginInfo.IDSubsidiary, ntbWageGroupToken.TypeSafeValue, ((WageGroupInfo)e.InfoItem).IDWageGroup))
            {
                string locErr = Facesso.Functions.My.Resources.WageGroupInfoAdd_TokenAlreadyExists_MB_Body;
                locErr = string.Format(locErr, ntbWageGroupToken.TypeSafeValue, FacessoGeneric.SubsidiarySynonym, FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName);
                MessageBox.Show(locErr, Facesso.Functions.My.Resources.WageGroupInfoAdd_TokenAlreadyExists_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
        }

        protected override void Fac_OnAssigningToInfoItem(IInfoItem InfoItem)
        {
            base.Fac_OnAssigningToInfoItem(InfoItem);
            // Abspeichern der Kostenstelle
            SPAccess locSPA = SPAccess.GetInstance();
            ((WageGroupInfo)InfoItem).IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary;
            if (Fac_EditMode == InfoItemFormEditMode.AddNew)
            {
                locSPA.WageGroups_Add(((WageGroupInfo)InfoItem), FacessoGeneric.LoginInfo.IDUser);
            }
            else if (Fac_EditMode == InfoItemFormEditMode.Edit)
            {
                locSPA.WageGroups_Edit(((WageGroupInfo)InfoItem), FacessoGeneric.LoginInfo.IDUser);
            }
        }
    }
}