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
    public class frmSubsidiaryInfoAddEditView : Facesso.Functions.frmInfoItemAddEditViewBase
    {
        public frmSubsidiaryInfoAddEditView() : base()
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

        internal ActiveDev.Controls.ADNullableTextBox ntbSubsidiary;
        internal ActiveDev.Controls.ADNullableTextBox ntbCountry;
        internal ActiveDev.Controls.ADNullableTextBox ntbCountryCode;
        internal ActiveDev.Controls.ADNullableTextBox ntbCity;
        internal ActiveDev.Controls.ADNullableTextBox ntbZip;
        internal ActiveDev.Controls.ADNullableTextBox ntbStreet;

        internal ActiveDev.Controls.ADNullableTextBox ntbPrimaryPhone;
        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.ntbSubsidiary = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbCountry = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbCountryCode = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbCity = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbZip = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbStreet = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbStreet.Click += ntbStreet_Click;
            this.ntbPrimaryPhone = new ActiveDev.Controls.ADNullableTextBox();
            this.SuspendLayout();
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(454, 13);
            this.btnOK.TabIndex = 13;
            //
            //btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(454, 58);
            this.btnCancel.TabIndex = 14;
            //
            //ntbSubsidiary
            //
            this.ntbSubsidiary.BackColor = System.Drawing.SystemColors.Window;
            this.ntbSubsidiary.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbSubsidiary.CaptionToValueRatio = 400.94;
            this.ntbSubsidiary.ColorOnFocus = true;
            this.ntbSubsidiary.FailedValidationErrorMessage = null;
            this.ntbSubsidiary.HasCaption = true;
            this.ntbSubsidiary.IndependentDatafieldName = "SubsidiaryName";
            this.ntbSubsidiary.Location = new System.Drawing.Point(13, 13);
            this.ntbSubsidiary.Margin = new System.Windows.Forms.Padding(4);
            this.ntbSubsidiary.MaxLength = 100;
            this.ntbSubsidiary.Multiline = false;
            this.ntbSubsidiary.Name = "ntbSubsidiary";
            this.ntbSubsidiary.NullString = "* --- *";
            this.ntbSubsidiary.NullValueMessage = "Bitte geben Sie einen g�ltigen Kostenstellennamen ein!";
            this.ntbSubsidiary.Size = new System.Drawing.Size(424, 23);
            this.ntbSubsidiary.TabIndex = 0;
            this.ntbSubsidiary.Text = "Name der Subsidiarit�t:";
            this.ntbSubsidiary.ValueAreaLength = 254;
            //
            //ntbCountry
            //
            this.ntbCountry.BackColor = System.Drawing.SystemColors.Window;
            this.ntbCountry.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbCountry.CaptionToValueRatio = 0;
            this.ntbCountry.ColorOnFocus = true;
            this.ntbCountry.FailedValidationErrorMessage = null;
            this.ntbCountry.HasCaption = false;
            this.ntbCountry.IndependentDatafieldName = "Country";
            this.ntbCountry.Location = new System.Drawing.Point(254, 124);
            this.ntbCountry.Margin = new System.Windows.Forms.Padding(4);
            this.ntbCountry.MaxLength = 100;
            this.ntbCountry.Multiline = false;
            this.ntbCountry.Name = "ntbCountry";
            this.ntbCountry.NullString = "* --- *";
            this.ntbCountry.NullValueMessage = null;
            this.ntbCountry.Size = new System.Drawing.Size(183, 23);
            this.ntbCountry.TabIndex = 5;
            this.ntbCountry.Text = "PLZ/Ort:";
            this.ntbCountry.ValueAreaLength = 183;
            //
            //ntbCountryCode
            //
            this.ntbCountryCode.BackColor = System.Drawing.SystemColors.Window;
            this.ntbCountryCode.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbCountryCode.CaptionToValueRatio = 729.61;
            this.ntbCountryCode.ColorOnFocus = true;
            this.ntbCountryCode.FailedValidationErrorMessage = null;
            this.ntbCountryCode.HasCaption = true;
            this.ntbCountryCode.IndependentDatafieldName = "CountryCode";
            this.ntbCountryCode.Location = new System.Drawing.Point(13, 124);
            this.ntbCountryCode.Margin = new System.Windows.Forms.Padding(4);
            this.ntbCountryCode.MaxLength = 10;
            this.ntbCountryCode.Multiline = false;
            this.ntbCountryCode.Name = "ntbCountryCode";
            this.ntbCountryCode.NullString = "* --- *";
            this.ntbCountryCode.NullValueMessage = null;
            this.ntbCountryCode.Size = new System.Drawing.Size(233, 23);
            this.ntbCountryCode.TabIndex = 4;
            this.ntbCountryCode.Text = "L�nderkennung/Land: ";
            this.ntbCountryCode.ValueAreaLength = 63;
            //
            //ntbCity
            //
            this.ntbCity.BackColor = System.Drawing.SystemColors.Window;
            this.ntbCity.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbCity.CaptionToValueRatio = 0;
            this.ntbCity.ColorOnFocus = true;
            this.ntbCity.FailedValidationErrorMessage = null;
            this.ntbCity.HasCaption = false;
            this.ntbCity.IndependentDatafieldName = "City";
            this.ntbCity.Location = new System.Drawing.Point(254, 93);
            this.ntbCity.Margin = new System.Windows.Forms.Padding(4);
            this.ntbCity.MaxLength = 100;
            this.ntbCity.Multiline = false;
            this.ntbCity.Name = "ntbCity";
            this.ntbCity.NullString = "* --- *";
            this.ntbCity.NullValueMessage = null;
            this.ntbCity.Size = new System.Drawing.Size(183, 23);
            this.ntbCity.TabIndex = 3;
            this.ntbCity.Text = "PLZ/Ort:";
            this.ntbCity.ValueAreaLength = 183;
            //
            //ntbZip
            //
            this.ntbZip.BackColor = System.Drawing.SystemColors.Window;
            this.ntbZip.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbZip.CaptionToValueRatio = 729.61;
            this.ntbZip.ColorOnFocus = true;
            this.ntbZip.FailedValidationErrorMessage = null;
            this.ntbZip.HasCaption = true;
            this.ntbZip.IndependentDatafieldName = "Zip";
            this.ntbZip.Location = new System.Drawing.Point(13, 93);
            this.ntbZip.Margin = new System.Windows.Forms.Padding(4);
            this.ntbZip.MaxLength = 10;
            this.ntbZip.Multiline = false;
            this.ntbZip.Name = "ntbZip";
            this.ntbZip.NullString = "* --- *";
            this.ntbZip.NullValueMessage = null;
            this.ntbZip.Size = new System.Drawing.Size(233, 23);
            this.ntbZip.TabIndex = 2;
            this.ntbZip.Text = "PLZ/Ort:";
            this.ntbZip.ValueAreaLength = 63;
            //
            //ntbStreet
            //
            this.ntbStreet.BackColor = System.Drawing.SystemColors.Window;
            this.ntbStreet.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbStreet.CaptionToValueRatio = 400.94;
            this.ntbStreet.ColorOnFocus = true;
            this.ntbStreet.FailedValidationErrorMessage = null;
            this.ntbStreet.HasCaption = true;
            this.ntbStreet.IndependentDatafieldName = "Street";
            this.ntbStreet.Location = new System.Drawing.Point(13, 62);
            this.ntbStreet.Margin = new System.Windows.Forms.Padding(4);
            this.ntbStreet.MaxLength = 100;
            this.ntbStreet.Multiline = false;
            this.ntbStreet.Name = "ntbStreet";
            this.ntbStreet.NullString = "* --- *";
            this.ntbStreet.NullValueMessage = null;
            this.ntbStreet.Size = new System.Drawing.Size(424, 23);
            this.ntbStreet.TabIndex = 1;
            this.ntbStreet.Text = "Stra�e: ";
            this.ntbStreet.ValueAreaLength = 254;
            //
            //ntbPrimaryPhone
            //
            this.ntbPrimaryPhone.BackColor = System.Drawing.SystemColors.Window;
            this.ntbPrimaryPhone.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbPrimaryPhone.CaptionToValueRatio = 400.94;
            this.ntbPrimaryPhone.ColorOnFocus = true;
            this.ntbPrimaryPhone.FailedValidationErrorMessage = null;
            this.ntbPrimaryPhone.HasCaption = true;
            this.ntbPrimaryPhone.IndependentDatafieldName = "PrimaryPhone";
            this.ntbPrimaryPhone.Location = new System.Drawing.Point(13, 170);
            this.ntbPrimaryPhone.Margin = new System.Windows.Forms.Padding(4);
            this.ntbPrimaryPhone.MaxLength = 100;
            this.ntbPrimaryPhone.Multiline = false;
            this.ntbPrimaryPhone.Name = "ntbPrimaryPhone";
            this.ntbPrimaryPhone.NullString = "* --- *";
            this.ntbPrimaryPhone.NullValueMessage = null;
            this.ntbPrimaryPhone.Size = new System.Drawing.Size(424, 23);
            this.ntbPrimaryPhone.TabIndex = 15;
            this.ntbPrimaryPhone.Text = "Prim�res Telefon:";
            this.ntbPrimaryPhone.ValueAreaLength = 254;
            //
            //frmSubsidiaryInfoAddEditView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.ClientSize = new System.Drawing.Size(584, 213);
            this.Controls.Add(this.ntbPrimaryPhone);
            this.Controls.Add(this.ntbCountry);
            this.Controls.Add(this.ntbCountryCode);
            this.Controls.Add(this.ntbCity);
            this.Controls.Add(this.ntbZip);
            this.Controls.Add(this.ntbStreet);
            this.Controls.Add(this.ntbSubsidiary);
            this.Name = "frmSubsidiaryInfoAddEditView";
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.ntbSubsidiary, 0);
            this.Controls.SetChildIndex(this.ntbStreet, 0);
            this.Controls.SetChildIndex(this.ntbZip, 0);
            this.Controls.SetChildIndex(this.ntbCity, 0);
            this.Controls.SetChildIndex(this.ntbCountryCode, 0);
            this.Controls.SetChildIndex(this.ntbCountry, 0);
            this.Controls.SetChildIndex(this.ntbPrimaryPhone, 0);
            this.ResumeLayout(false);
        }

        protected override void Fac_OnInitializeFormControls()
        {
            base.Fac_OnInitializeFormControls();
        }

        protected override void Fac_OnAssigningToControls(ActiveDev.IInfoItem InfoItem)
        {
            base.Fac_OnAssigningToControls(InfoItem);
        }

        protected override void Fac_OnValidatingNew(System.ComponentModel.CancelEventArgs e)
        {
            base.Fac_OnValidatingNew(e);
            SPAccess locSPA = SPAccess.GetInstance();
            //TODO: Feststellen, ob der Subsidiarit�tsname schon existiert
            if (locSPA.Subsidiaries_DoesNameExist(ntbSubsidiary.TypeSafeValue, default(ActiveDev.ADDBNullable<int>)))
            {
                string locErr = Facesso.Functions.My.Resources.CostCenterInfoAdd_CostCenterNoAlreadyExist_MB_Body;
                locErr = string.Format(locErr, System.Convert.ToInt32(ntbSubsidiary.TypeSafeValue), FacessoGeneric.SubsidiarySynonym, FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName);
                MessageBox.Show(locErr, Facesso.Functions.My.Resources.SubsidiaryInfoAdd_SubsidiaryNameAlreadyExist_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
        }

        protected override void Fac_OnValidatingEdit(InfoItemValidatingEventArgs e)
        {
            base.Fac_OnValidatingEdit(e);
            SPAccess locSPA = SPAccess.GetInstance();
            //TODO: Feststellen, ob der Subsidiarit�tsname schon existiert
            if (locSPA.Subsidiaries_DoesNameExist(ntbSubsidiary.TypeSafeValue, ((SubsidiaryInfo)e.InfoItem).IDSubsidiary))
            {
                string locErr = Facesso.Functions.My.Resources.SubsidiaryInfoAdd_SubsidiaryNameAlreadyExist_MB_Body;
                locErr = string.Format(locErr, ntbSubsidiary.TypeSafeValue, FacessoGeneric.SubsidiarySynonym, FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName);
                MessageBox.Show(locErr, Facesso.Functions.My.Resources.SubsidiaryInfoAdd_SubsidiaryNameAlreadyExist_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
        }

        protected override void Fac_OnAssigningToInfoItem(IInfoItem InfoItem)
        {
            base.Fac_OnAssigningToInfoItem(InfoItem);
            // Abspeichern der Kostenstelle
            SPAccess locSPA = SPAccess.GetInstance();
            ((SubsidiaryInfo)InfoItem).IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary;
            if (Fac_EditMode == InfoItemFormEditMode.AddNew)
            {
                locSPA.Subsidiaries_Add(((SubsidiaryInfo)InfoItem), FacessoGeneric.LoginInfo.IDUser);
            }
            else if (Fac_EditMode == InfoItemFormEditMode.Edit)
            {
                locSPA.Subsidiaries_Edit(((SubsidiaryInfo)InfoItem), FacessoGeneric.LoginInfo.IDUser);
            }
        }

        private void ntbStreet_Click(System.Object sender, System.EventArgs e)
        {
        }
    }
}