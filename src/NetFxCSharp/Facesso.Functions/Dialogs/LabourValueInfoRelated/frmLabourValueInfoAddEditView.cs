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
    public class frmLabourValueInfoAddEditView : Facesso.Functions.frmInfoItemAddEditViewBase
    {
        public frmLabourValueInfoAddEditView() : base()
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

        internal ActiveDev.Controls.ADNullableTextBox ntbLabourValueDescription;
        internal ActiveDev.Controls.ADNullableTextBox ntbLabourValueName;
        internal ActiveDev.Controls.ADNullableDoubleBox ndbTe;
        internal ActiveDev.Controls.ADNullableIntBox nibLabourValueNumber;
        internal ActiveDev.Controls.ADNullableTextBox ntbDimension;
        internal ActiveDev.Controls.ADNullableCheckBox ncbIsActive;
        internal ActiveDev.Controls.ADNullableIdOrIndexComboBox ncbCostCenter;
        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.ntbLabourValueDescription = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbLabourValueName = new ActiveDev.Controls.ADNullableTextBox();
            this.ndbTe = new ActiveDev.Controls.ADNullableDoubleBox();
            this.nibLabourValueNumber = new ActiveDev.Controls.ADNullableIntBox();
            this.ntbDimension = new ActiveDev.Controls.ADNullableTextBox();
            this.ncbIsActive = new ActiveDev.Controls.ADNullableCheckBox();
            this.ncbCostCenter = new ActiveDev.Controls.ADNullableIdOrIndexComboBox();
            this.SuspendLayout();
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(468, 13);
            this.btnOK.TabIndex = 7;
            //
            //btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(468, 58);
            this.btnCancel.TabIndex = 8;
            //
            //ntbLabourValueDescription
            //
            this.ntbLabourValueDescription.BackColor = System.Drawing.SystemColors.Window;
            this.ntbLabourValueDescription.CaptionBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ntbLabourValueDescription.CaptionPlacement = ActiveDev.Controls.ADCaptionPlacementEnum.Above;
            this.ntbLabourValueDescription.CaptionToValueRatio = 1000;
            this.ntbLabourValueDescription.ColorOnFocus = true;
            this.ntbLabourValueDescription.FailedValidationErrorMessage = null;
            this.ntbLabourValueDescription.HasCaption = true;
            this.ntbLabourValueDescription.IndependentDatafieldName = "LabourValueDescription";
            this.ntbLabourValueDescription.Location = new System.Drawing.Point(11, 112);
            this.ntbLabourValueDescription.Margin = new System.Windows.Forms.Padding(4);
            this.ntbLabourValueDescription.Multiline = true;
            this.ntbLabourValueDescription.Name = "ntbLabourValueDescription";
            this.ntbLabourValueDescription.NullString = "* --- *";
            this.ntbLabourValueDescription.NullValueMessage = null;
            this.ntbLabourValueDescription.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.ntbLabourValueDescription.Size = new System.Drawing.Size(429, 184);
            this.ntbLabourValueDescription.TabIndex = 3;
            this.ntbLabourValueDescription.Text = "REFA-Arbeitswertbeschreibung:";
            this.ntbLabourValueDescription.ValueAreaLength = 429;
            //
            //ntbLabourValueName
            //
            this.ntbLabourValueName.BackColor = System.Drawing.SystemColors.Window;
            this.ntbLabourValueName.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbLabourValueName.CaptionToValueRatio = 399.53;
            this.ntbLabourValueName.ColorOnFocus = true;
            this.ntbLabourValueName.FailedValidationErrorMessage = null;
            this.ntbLabourValueName.HasCaption = true;
            this.ntbLabourValueName.IndependentDatafieldName = "LabourValueName";
            this.ntbLabourValueName.Location = new System.Drawing.Point(11, 42);
            this.ntbLabourValueName.Margin = new System.Windows.Forms.Padding(4);
            this.ntbLabourValueName.MaxLength = 100;
            this.ntbLabourValueName.Multiline = false;
            this.ntbLabourValueName.Name = "ntbLabourValueName";
            this.ntbLabourValueName.NullString = "* --- *";
            this.ntbLabourValueName.NullValueMessage = "Bitte bestimmen Sie einen Arbeitswertnamen !";
            this.ntbLabourValueName.Size = new System.Drawing.Size(428, 23);
            this.ntbLabourValueName.TabIndex = 1;
            this.ntbLabourValueName.Text = "REFA-Arbeitswertname:";
            this.ntbLabourValueName.ValueAreaLength = 257;
            //
            //ndbTe
            //
            this.ndbTe.AssignFormatString = "#,##0.00";
            this.ndbTe.BackColor = System.Drawing.SystemColors.Window;
            this.ndbTe.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ndbTe.CaptionToValueRatio = 400.93;
            this.ndbTe.ColorOnFocus = true;
            this.ndbTe.CurrencyText = "";
            this.ndbTe.DisplayCustomFormatString = "#,##0.00";
            this.ndbTe.DisplayFormat = ActiveDev.Controls.ADUVNumFormat.UseCustomString;
            this.ndbTe.FailedValidationErrorMessage = null;
            this.ndbTe.FormularText = "";
            this.ndbTe.HasCaption = true;
            this.ndbTe.IndependentDatafieldName = "TeHMin";
            this.ndbTe.Location = new System.Drawing.Point(11, 318);
            this.ndbTe.MaxValue = 0;
            this.ndbTe.MinValue = 0;
            this.ndbTe.Name = "ndbTe";
            this.ndbTe.NullString = "* --- *";
            this.ndbTe.NullValueMessage = "Bitte bestimmen Sie den nach REFA berechneten te-Wert f�r diesen Arbeitswert!";
            this.ndbTe.Size = new System.Drawing.Size(429, 23);
            this.ndbTe.TabIndex = 4;
            this.ndbTe.Text = "te: ";
            this.ndbTe.ValueAreaLength = 257;
            //
            //nibLabourValueNumber
            //
            this.nibLabourValueNumber.BackColor = System.Drawing.SystemColors.Window;
            this.nibLabourValueNumber.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.nibLabourValueNumber.CaptionToValueRatio = 400;
            this.nibLabourValueNumber.ColorOnFocus = true;
            this.nibLabourValueNumber.FailedValidationErrorMessage = null;
            this.nibLabourValueNumber.FormularText = "";
            this.nibLabourValueNumber.HasCaption = true;
            this.nibLabourValueNumber.IndependentDatafieldName = "LabourValueNumber";
            this.nibLabourValueNumber.Location = new System.Drawing.Point(10, 12);
            this.nibLabourValueNumber.MaxValue = 0;
            this.nibLabourValueNumber.MinValue = 0;
            this.nibLabourValueNumber.Name = "nibLabourValueNumber";
            this.nibLabourValueNumber.NullString = "* --- *";
            this.nibLabourValueNumber.NullValueMessage = "Bitte bestimmen Sie die Arbeitswertnummer!";
            this.nibLabourValueNumber.Size = new System.Drawing.Size(430, 23);
            this.nibLabourValueNumber.TabIndex = 0;
            this.nibLabourValueNumber.Text = "REFA-Arbeitswertnr.:";
            this.nibLabourValueNumber.ValueAreaLength = 258;
            //
            //ntbDimension
            //
            this.ntbDimension.BackColor = System.Drawing.SystemColors.Window;
            this.ntbDimension.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbDimension.CaptionToValueRatio = 400.93;
            this.ntbDimension.ColorOnFocus = true;
            this.ntbDimension.FailedValidationErrorMessage = null;
            this.ntbDimension.HasCaption = true;
            this.ntbDimension.IndependentDatafieldName = "Dimension";
            this.ntbDimension.Location = new System.Drawing.Point(10, 348);
            this.ntbDimension.Margin = new System.Windows.Forms.Padding(4);
            this.ntbDimension.MaxLength = 100;
            this.ntbDimension.Multiline = false;
            this.ntbDimension.Name = "ntbDimension";
            this.ntbDimension.NullString = "* --- *";
            this.ntbDimension.NullValueMessage = "Bitte bestimmen Sie die Ma�einheit f�r diesen te-Wert!";
            this.ntbDimension.Size = new System.Drawing.Size(429, 23);
            this.ntbDimension.TabIndex = 5;
            this.ntbDimension.Text = "Ma�einheit: ";
            this.ntbDimension.ValueAreaLength = 257;
            //
            //ncbIsActive
            //
            this.ncbIsActive.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ncbIsActive.CaptionToValueRatio = 741.61;
            this.ncbIsActive.ColorOnFocus = true;
            this.ncbIsActive.FailedValidationErrorMessage = null;
            this.ncbIsActive.HasCaption = true;
            this.ncbIsActive.IndependentDatafieldName = "IsActive";
            this.ncbIsActive.Location = new System.Drawing.Point(10, 390);
            this.ncbIsActive.Name = "ncbIsActive";
            this.ncbIsActive.NullString = null;
            this.ncbIsActive.NullValueMessage = "Bitte bestimmen Sie, ob dieser Mitarbeiter-Datensatz aktiv sein soll!";
            this.ncbIsActive.Size = new System.Drawing.Size(298, 19);
            this.ncbIsActive.TabIndex = 6;
            this.ncbIsActive.Text = "Ist aktiviert:";
            this.ncbIsActive.ValueAreaLength = 77;
            //
            //ncbCostCenter
            //
            this.ncbCostCenter.BackColor = System.Drawing.SystemColors.Window;
            this.ncbCostCenter.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ncbCostCenter.CaptionToValueRatio = 400.93;
            this.ncbCostCenter.ColorOnFocus = true;
            this.ncbCostCenter.ComboBoxValueType = ActiveDev.Controls.ADNullableComboBoxValueType.ID_As_Int32;
            this.ncbCostCenter.DropDownHeight = 106;
            this.ncbCostCenter.DropDownWidth = 315;
            this.ncbCostCenter.FailedValidationErrorMessage = null;
            this.ncbCostCenter.HasCaption = true;
            this.ncbCostCenter.IndependentDatafieldName = "IDCostCenter";
            this.ncbCostCenter.Location = new System.Drawing.Point(11, 72);
            this.ncbCostCenter.MaxDropDownItems = 8;
            this.ncbCostCenter.Name = "ncbCostCenter";
            this.ncbCostCenter.NullString = null;
            this.ncbCostCenter.NullValueMessage = "Bitte bestimmen Sie die Kostenstelle zu diesem Arbeitswert!";
            this.ncbCostCenter.Size = new System.Drawing.Size(429, 24);
            this.ncbCostCenter.TabIndex = 2;
            this.ncbCostCenter.Text = "Kostenstellen-Nummer: ";
            this.ncbCostCenter.ValueAreaLength = 257;
            //
            //frmLabourValueInfoAddEditView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.ClientSize = new System.Drawing.Size(598, 430);
            this.Controls.Add(this.ncbCostCenter);
            this.Controls.Add(this.ncbIsActive);
            this.Controls.Add(this.ntbDimension);
            this.Controls.Add(this.nibLabourValueNumber);
            this.Controls.Add(this.ndbTe);
            this.Controls.Add(this.ntbLabourValueDescription);
            this.Controls.Add(this.ntbLabourValueName);
            this.Name = "frmLabourValueInfoAddEditView";
            this.Controls.SetChildIndex(this.ntbLabourValueName, 0);
            this.Controls.SetChildIndex(this.ntbLabourValueDescription, 0);
            this.Controls.SetChildIndex(this.ndbTe, 0);
            this.Controls.SetChildIndex(this.nibLabourValueNumber, 0);
            this.Controls.SetChildIndex(this.ntbDimension, 0);
            this.Controls.SetChildIndex(this.ncbIsActive, 0);
            this.Controls.SetChildIndex(this.ncbCostCenter, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.ResumeLayout(false);
        }

        protected override void Fac_OnInitializeFormControls()
        {
            base.Fac_OnInitializeFormControls();
            Fac_FunctionsInternal.AddCostCentersToADNullableIdOrIndexComboBox(ncbCostCenter);
        }

        protected override void Fac_OnAssigningToControls(ActiveDev.IInfoItem InfoItem)
        {
            Fac_FunctionsInternal.AddCostCentersToADNullableIdOrIndexComboBox(ncbCostCenter);
            base.Fac_OnAssigningToControls(InfoItem);
        }

        protected override void Fac_OnValidatingNew(System.ComponentModel.CancelEventArgs e)
        {
            base.Fac_OnValidatingNew(e);
            SPAccess locSPA = SPAccess.GetInstance();
            //Feststellen, ob die Arbeitswertnummer schon existiert
            if (locSPA.LabourValues_DoesNumberExist(FacessoGeneric.LoginInfo.IDSubsidiary, nibLabourValueNumber.TypeSafeValue, default(ActiveDev.ADDBNullable<int>)))
            {
                string locErr = Facesso.Functions.My.Resources.LabourValueInfoAdd_NumberAlreadyExists_MB_Body;
                locErr = string.Format(locErr, System.Convert.ToInt32(nibLabourValueNumber.TypeSafeValue), FacessoGeneric.SubsidiarySynonym, FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName);
                MessageBox.Show(locErr, Facesso.Functions.My.Resources.LabourValueInfoAdd_NumberAlreadyExists_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
        }

        protected override void Fac_OnValidatingEdit(InfoItemValidatingEventArgs e)
        {
            base.Fac_OnValidatingEdit(e);
            SPAccess locSPA = SPAccess.GetInstance();
            //Feststellen, ob die Arbeitswertnummer schon existiert
            if (locSPA.LabourValues_DoesNumberExist(FacessoGeneric.LoginInfo.IDSubsidiary, nibLabourValueNumber.TypeSafeValue, ((LabourValueInfo)e.InfoItem).IDLabourValue))
            {
                string locErr = Facesso.Functions.My.Resources.LabourValueInfoAdd_NumberAlreadyExists_MB_Body;
                locErr = string.Format(locErr, nibLabourValueNumber.TypeSafeValue, FacessoGeneric.SubsidiarySynonym, FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName);
                MessageBox.Show(locErr, Facesso.Functions.My.Resources.LabourValueInfoAdd_NumberAlreadyExists_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
        }

        protected override void Fac_OnAssigningToInfoItem(IInfoItem InfoItem)
        {
            base.Fac_OnAssigningToInfoItem(InfoItem);
            SPAccess locSPA = SPAccess.GetInstance();
            ((LabourValueInfo)InfoItem).IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary;
            if (Fac_EditMode == InfoItemFormEditMode.AddNew)
            {
                locSPA.LabourValues_Add(((LabourValueInfo)InfoItem), FacessoGeneric.LoginInfo.IDUser);
            }
            else if (Fac_EditMode == InfoItemFormEditMode.Edit)
            {
                locSPA.LabourValues_Edit(((LabourValueInfo)InfoItem), FacessoGeneric.LoginInfo.IDUser);
            }
        }
    }
}