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
    public class frmCostcenterInfoAddEditView : Facesso.Functions.frmInfoItemAddEditViewBase
    {
        public frmCostcenterInfoAddEditView() : base()
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

        internal ActiveDev.Controls.ADNullableTextBox nsbCostCenterDescription;
        internal ActiveDev.Controls.ADNullableTextBox nsbCostCenterName;
        internal ActiveDev.Controls.ADNullableIntBox nibCostCenterNo;
        internal ActiveDev.Controls.ADNullableTextBox ntbIncentiveSynonym;
        internal ActiveDev.Controls.ADNullableTextBox ntbIncentiveDimension;
        internal ActiveDev.Controls.ADNullableCheckBox ncbUseFixValuedBonus;
        internal ActiveDev.Controls.ADNullableDoubleBox ndbIncentiveIndicatorFactor;
        internal ActiveDev.Controls.ADNullableTextBox ntbIncentiveWageSynonym;
        internal ActiveDev.Controls.ADNullableIdOrIndexComboBox nibIncentiveIndicatorPrecision;
        internal ActiveDev.Controls.ADNullableIdOrIndexComboBox ncbIDCurrency;
        internal ActiveDev.Controls.ADNullableTextBox ntbBaseValueSynonym;
        internal ActiveDev.Controls.ADNullableIdOrIndexComboBox nibBaseValuePrecision;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.nsbCostCenterDescription = new ActiveDev.Controls.ADNullableTextBox();
            this.nsbCostCenterName = new ActiveDev.Controls.ADNullableTextBox();
            this.nibCostCenterNo = new ActiveDev.Controls.ADNullableIntBox();
            this.ntbIncentiveSynonym = new ActiveDev.Controls.ADNullableTextBox();
            this.ntbIncentiveDimension = new ActiveDev.Controls.ADNullableTextBox();
            this.ncbUseFixValuedBonus = new ActiveDev.Controls.ADNullableCheckBox();
            this.ndbIncentiveIndicatorFactor = new ActiveDev.Controls.ADNullableDoubleBox();
            this.ntbIncentiveWageSynonym = new ActiveDev.Controls.ADNullableTextBox();
            this.nibIncentiveIndicatorPrecision = new ActiveDev.Controls.ADNullableIdOrIndexComboBox();
            this.ncbIDCurrency = new ActiveDev.Controls.ADNullableIdOrIndexComboBox();
            this.ntbBaseValueSynonym = new ActiveDev.Controls.ADNullableTextBox();
            this.nibBaseValuePrecision = new ActiveDev.Controls.ADNullableIdOrIndexComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(454, 13);
            this.btnOK.TabIndex = 15;
            //
            //btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(454, 58);
            this.btnCancel.TabIndex = 16;
            //
            //nsbCostCenterDescription
            //
            this.nsbCostCenterDescription.BackColor = System.Drawing.SystemColors.Window;
            this.nsbCostCenterDescription.CaptionBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nsbCostCenterDescription.CaptionPlacement = ActiveDev.Controls.ADCaptionPlacementEnum.Above;
            this.nsbCostCenterDescription.CaptionToValueRatio = 1000;
            this.nsbCostCenterDescription.ColorOnFocus = true;
            this.nsbCostCenterDescription.FailedValidationErrorMessage = null;
            this.nsbCostCenterDescription.HasCaption = true;
            this.nsbCostCenterDescription.IndependentDatafieldName = "CostCenterDescription";
            this.nsbCostCenterDescription.Location = new System.Drawing.Point(13, 91);
            this.nsbCostCenterDescription.Margin = new System.Windows.Forms.Padding(4);
            this.nsbCostCenterDescription.Multiline = true;
            this.nsbCostCenterDescription.Name = "nsbCostCenterDescription";
            this.nsbCostCenterDescription.NullString = "* --- *";
            this.nsbCostCenterDescription.NullValueMessage = null;
            this.nsbCostCenterDescription.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.nsbCostCenterDescription.Size = new System.Drawing.Size(423, 160);
            this.nsbCostCenterDescription.TabIndex = 2;
            this.nsbCostCenterDescription.Text = "Kostenstellen-Beschreibung:";
            this.nsbCostCenterDescription.ValueAreaLength = 423;
            //
            //nsbCostCenterName
            //
            this.nsbCostCenterName.BackColor = System.Drawing.SystemColors.Window;
            this.nsbCostCenterName.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.nsbCostCenterName.CaptionToValueRatio = 481.13;
            this.nsbCostCenterName.ColorOnFocus = true;
            this.nsbCostCenterName.FailedValidationErrorMessage = null;
            this.nsbCostCenterName.HasCaption = true;
            this.nsbCostCenterName.IndependentDatafieldName = "CostCenterName";
            this.nsbCostCenterName.Location = new System.Drawing.Point(12, 54);
            this.nsbCostCenterName.Margin = new System.Windows.Forms.Padding(4);
            this.nsbCostCenterName.MaxLength = 100;
            this.nsbCostCenterName.Multiline = false;
            this.nsbCostCenterName.Name = "nsbCostCenterName";
            this.nsbCostCenterName.NullString = "* --- *";
            this.nsbCostCenterName.NullValueMessage = "Bitte geben Sie einen g�ltigen Kostenstellennamen ein!";
            this.nsbCostCenterName.Size = new System.Drawing.Size(424, 22);
            this.nsbCostCenterName.TabIndex = 1;
            this.nsbCostCenterName.Text = "Kostenstellen-Name:";
            this.nsbCostCenterName.ValueAreaLength = 220;
            //
            //nibCostCenterNo
            //
            this.nibCostCenterNo.BackColor = System.Drawing.SystemColors.Window;
            this.nibCostCenterNo.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.nibCostCenterNo.CaptionToValueRatio = 481.13;
            this.nibCostCenterNo.ColorOnFocus = true;
            this.nibCostCenterNo.FailedValidationErrorMessage = null;
            this.nibCostCenterNo.FormularText = "";
            this.nibCostCenterNo.HasCaption = true;
            this.nibCostCenterNo.IndependentDatafieldName = "CostCenterNo";
            this.nibCostCenterNo.Location = new System.Drawing.Point(12, 17);
            this.nibCostCenterNo.MaxValue = 0;
            this.nibCostCenterNo.MinValue = 0;
            this.nibCostCenterNo.Name = "nibCostCenterNo";
            this.nibCostCenterNo.NullString = "* --- *";
            this.nibCostCenterNo.NullValueMessage = "Bitte bestimmen Sie die Kostenstellen-Nummer!";
            this.nibCostCenterNo.Size = new System.Drawing.Size(424, 22);
            this.nibCostCenterNo.TabIndex = 0;
            this.nibCostCenterNo.Text = "Kostenstellen-Nr.:";
            this.nibCostCenterNo.ValueAreaLength = 220;
            //
            //ntbIncentiveSynonym
            //
            this.ntbIncentiveSynonym.BackColor = System.Drawing.SystemColors.Window;
            this.ntbIncentiveSynonym.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbIncentiveSynonym.CaptionToValueRatio = 478.87;
            this.ntbIncentiveSynonym.ColorOnFocus = true;
            this.ntbIncentiveSynonym.FailedValidationErrorMessage = null;
            this.ntbIncentiveSynonym.HasCaption = true;
            this.ntbIncentiveSynonym.IndependentDatafieldName = "IncentiveIndicatorSynonym";
            this.ntbIncentiveSynonym.Location = new System.Drawing.Point(9, 487);
            this.ntbIncentiveSynonym.Margin = new System.Windows.Forms.Padding(4);
            this.ntbIncentiveSynonym.MaxLength = 50;
            this.ntbIncentiveSynonym.Multiline = false;
            this.ntbIncentiveSynonym.Name = "ntbIncentiveSynonym";
            this.ntbIncentiveSynonym.NullString = "* --- *";
            this.ntbIncentiveSynonym.NullValueMessage = "Bitte bestimmen Sie die Leistungsbezeichnung!";
            this.ntbIncentiveSynonym.Size = new System.Drawing.Size(426, 22);
            this.ntbIncentiveSynonym.TabIndex = 10;
            this.ntbIncentiveSynonym.Text = "Leistungsbezeichnung: ";
            this.ntbIncentiveSynonym.ValueAreaLength = 222;
            //
            //ntbIncentiveDimension
            //
            this.ntbIncentiveDimension.BackColor = System.Drawing.SystemColors.Window;
            this.ntbIncentiveDimension.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbIncentiveDimension.CaptionToValueRatio = 478.87;
            this.ntbIncentiveDimension.ColorOnFocus = true;
            this.ntbIncentiveDimension.FailedValidationErrorMessage = null;
            this.ntbIncentiveDimension.HasCaption = true;
            this.ntbIncentiveDimension.IndependentDatafieldName = "IncentiveIndicatorDimension";
            this.ntbIncentiveDimension.Location = new System.Drawing.Point(9, 518);
            this.ntbIncentiveDimension.Margin = new System.Windows.Forms.Padding(4);
            this.ntbIncentiveDimension.MaxLength = 10;
            this.ntbIncentiveDimension.Multiline = false;
            this.ntbIncentiveDimension.Name = "ntbIncentiveDimension";
            this.ntbIncentiveDimension.NullString = "* --- *";
            this.ntbIncentiveDimension.NullValueMessage = "Bitte bestimmen Sie die Leistungseinheit!";
            this.ntbIncentiveDimension.ReturnNullOnEmptyString = false;
            this.ntbIncentiveDimension.Size = new System.Drawing.Size(426, 22);
            this.ntbIncentiveDimension.TabIndex = 11;
            this.ntbIncentiveDimension.Text = "Leistungseinheit: ";
            this.ntbIncentiveDimension.ValueAreaLength = 222;
            //
            //ncbUseFixValuedBonus
            //
            this.ncbUseFixValuedBonus.CaptionToValueRatio = 801.89;
            this.ncbUseFixValuedBonus.ColorOnFocus = true;
            this.ncbUseFixValuedBonus.FailedValidationErrorMessage = null;
            this.ncbUseFixValuedBonus.HasCaption = true;
            this.ncbUseFixValuedBonus.IndependentDatafieldName = "UseFixValuedBonus";
            this.ncbUseFixValuedBonus.Location = new System.Drawing.Point(11, 344);
            this.ncbUseFixValuedBonus.Name = "ncbUseFixValuedBonus";
            this.ncbUseFixValuedBonus.NullString = null;
            this.ncbUseFixValuedBonus.NullValueMessage = "Pr�mienberechnungsfeld darf keinen Zwischenstatus haben!";
            this.ncbUseFixValuedBonus.Size = new System.Drawing.Size(424, 19);
            this.ncbUseFixValuedBonus.TabIndex = 5;
            this.ncbUseFixValuedBonus.Text = "Verg�tungsberechnung mit fixen Betr�gen:";
            this.ncbUseFixValuedBonus.ValueAreaLength = 84;
            //
            //ndbIncentiveIndicatorFactor
            //
            this.ndbIncentiveIndicatorFactor.BackColor = System.Drawing.SystemColors.Window;
            this.ndbIncentiveIndicatorFactor.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ndbIncentiveIndicatorFactor.CaptionToValueRatio = 478.87;
            this.ndbIncentiveIndicatorFactor.ColorOnFocus = true;
            this.ndbIncentiveIndicatorFactor.CurrencyText = "";
            this.ndbIncentiveIndicatorFactor.FailedValidationErrorMessage = null;
            this.ndbIncentiveIndicatorFactor.FormularText = "";
            this.ndbIncentiveIndicatorFactor.HasCaption = true;
            this.ndbIncentiveIndicatorFactor.IndependentDatafieldName = "IncentiveIndicatorFactor";
            this.ndbIncentiveIndicatorFactor.Location = new System.Drawing.Point(9, 548);
            this.ndbIncentiveIndicatorFactor.MaxValue = 0;
            this.ndbIncentiveIndicatorFactor.MinValue = 0;
            this.ndbIncentiveIndicatorFactor.Name = "ndbIncentiveIndicatorFactor";
            this.ndbIncentiveIndicatorFactor.NullString = "* --- *";
            this.ndbIncentiveIndicatorFactor.NullValueMessage = "Bitte bestimmen Sie den Leistungsmultiplikator!";
            this.ndbIncentiveIndicatorFactor.Size = new System.Drawing.Size(426, 22);
            this.ndbIncentiveIndicatorFactor.TabIndex = 12;
            this.ndbIncentiveIndicatorFactor.Text = "Leistungsmultiplikator:";
            this.ndbIncentiveIndicatorFactor.ValueAreaLength = 222;
            //
            //ntbIncentiveWageSynonym
            //
            this.ntbIncentiveWageSynonym.BackColor = System.Drawing.SystemColors.Window;
            this.ntbIncentiveWageSynonym.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbIncentiveWageSynonym.CaptionToValueRatio = 481.13;
            this.ntbIncentiveWageSynonym.ColorOnFocus = true;
            this.ntbIncentiveWageSynonym.FailedValidationErrorMessage = null;
            this.ntbIncentiveWageSynonym.HasCaption = true;
            this.ntbIncentiveWageSynonym.IndependentDatafieldName = "IncentiveWageSynonym";
            this.ntbIncentiveWageSynonym.Location = new System.Drawing.Point(11, 311);
            this.ntbIncentiveWageSynonym.Margin = new System.Windows.Forms.Padding(4);
            this.ntbIncentiveWageSynonym.MaxLength = 50;
            this.ntbIncentiveWageSynonym.Multiline = false;
            this.ntbIncentiveWageSynonym.Name = "ntbIncentiveWageSynonym";
            this.ntbIncentiveWageSynonym.NullString = "* --- *";
            this.ntbIncentiveWageSynonym.NullValueMessage = "Bitte bestimmen Sie die Verg�tungsbezeichnung!";
            this.ntbIncentiveWageSynonym.Size = new System.Drawing.Size(424, 22);
            this.ntbIncentiveWageSynonym.TabIndex = 4;
            this.ntbIncentiveWageSynonym.Text = "Verg�tungsbezeichnung: ";
            this.ntbIncentiveWageSynonym.ValueAreaLength = 220;
            //
            //nibIncentiveIndicatorPrecision
            //
            this.nibIncentiveIndicatorPrecision.BackColor = System.Drawing.SystemColors.Window;
            this.nibIncentiveIndicatorPrecision.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.nibIncentiveIndicatorPrecision.CaptionToValueRatio = 689.19;
            this.nibIncentiveIndicatorPrecision.ColorOnFocus = true;
            this.nibIncentiveIndicatorPrecision.ComboBoxValueType = ActiveDev.Controls.ADNullableComboBoxValueType.Index_As_Int32;
            this.nibIncentiveIndicatorPrecision.DropDownHeight = 106;
            this.nibIncentiveIndicatorPrecision.DropDownWidth = 264;
            this.nibIncentiveIndicatorPrecision.FailedValidationErrorMessage = null;
            this.nibIncentiveIndicatorPrecision.HasCaption = true;
            this.nibIncentiveIndicatorPrecision.IndependentDatafieldName = "IncentiveIndicatorPrecision";
            this.nibIncentiveIndicatorPrecision.Location = new System.Drawing.Point(9, 577);
            this.nibIncentiveIndicatorPrecision.MaxDropDownItems = 8;
            this.nibIncentiveIndicatorPrecision.Name = "nibIncentiveIndicatorPrecision";
            this.nibIncentiveIndicatorPrecision.NullString = null;
            this.nibIncentiveIndicatorPrecision.NullValueMessage = null;
            this.nibIncentiveIndicatorPrecision.Size = new System.Drawing.Size(296, 24);
            this.nibIncentiveIndicatorPrecision.TabIndex = 13;
            this.nibIncentiveIndicatorPrecision.Text = "Leistungsindikatorgenauigkeit: ";
            this.nibIncentiveIndicatorPrecision.ValueAreaLength = 92;
            //
            //ncbIDCurrency
            //
            this.ncbIDCurrency.BackColor = System.Drawing.SystemColors.Window;
            this.ncbIDCurrency.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ncbIDCurrency.CaptionToValueRatio = 481.13;
            this.ncbIDCurrency.ColorOnFocus = true;
            this.ncbIDCurrency.ComboBoxValueType = ActiveDev.Controls.ADNullableComboBoxValueType.ID_As_Int32;
            this.ncbIDCurrency.DropDownHeight = 106;
            this.ncbIDCurrency.DropDownWidth = 264;
            this.ncbIDCurrency.FailedValidationErrorMessage = null;
            this.ncbIDCurrency.HasCaption = true;
            this.ncbIDCurrency.IndependentDatafieldName = "IDCurrency";
            this.ncbIDCurrency.Location = new System.Drawing.Point(11, 280);
            this.ncbIDCurrency.MaxDropDownItems = 8;
            this.ncbIDCurrency.Name = "ncbIDCurrency";
            this.ncbIDCurrency.NullString = null;
            this.ncbIDCurrency.NullValueMessage = null;
            this.ncbIDCurrency.Size = new System.Drawing.Size(424, 24);
            this.ncbIDCurrency.TabIndex = 3;
            this.ncbIDCurrency.Text = "Verg�tungsw�hrung: ";
            this.ncbIDCurrency.ValueAreaLength = 220;
            //
            //ntbBaseValueSynonym
            //
            this.ntbBaseValueSynonym.BackColor = System.Drawing.SystemColors.Window;
            this.ntbBaseValueSynonym.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.ntbBaseValueSynonym.CaptionToValueRatio = 478.87;
            this.ntbBaseValueSynonym.ColorOnFocus = true;
            this.ntbBaseValueSynonym.FailedValidationErrorMessage = null;
            this.ntbBaseValueSynonym.HasCaption = true;
            this.ntbBaseValueSynonym.IndependentDatafieldName = "BaseValueSynonym";
            this.ntbBaseValueSynonym.Location = new System.Drawing.Point(10, 378);
            this.ntbBaseValueSynonym.Margin = new System.Windows.Forms.Padding(4);
            this.ntbBaseValueSynonym.MaxLength = 50;
            this.ntbBaseValueSynonym.Multiline = false;
            this.ntbBaseValueSynonym.Name = "ntbBaseValueSynonym";
            this.ntbBaseValueSynonym.NullString = "* --- *";
            this.ntbBaseValueSynonym.NullValueMessage = "Bitte bestimmen Sie die Verg�tungsbezeichnung!";
            this.ntbBaseValueSynonym.Size = new System.Drawing.Size(426, 22);
            this.ntbBaseValueSynonym.TabIndex = 6;
            this.ntbBaseValueSynonym.Text = "Basiswertbezeichnung: ";
            this.ntbBaseValueSynonym.ValueAreaLength = 222;
            //
            //nibBaseValuePrecision
            //
            this.nibBaseValuePrecision.BackColor = System.Drawing.SystemColors.Window;
            this.nibBaseValuePrecision.CaptionAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.nibBaseValuePrecision.CaptionToValueRatio = 689.19;
            this.nibBaseValuePrecision.ColorOnFocus = true;
            this.nibBaseValuePrecision.ComboBoxValueType = ActiveDev.Controls.ADNullableComboBoxValueType.Index_As_Int32;
            this.nibBaseValuePrecision.DropDownHeight = 106;
            this.nibBaseValuePrecision.DropDownWidth = 264;
            this.nibBaseValuePrecision.FailedValidationErrorMessage = null;
            this.nibBaseValuePrecision.HasCaption = true;
            this.nibBaseValuePrecision.IndependentDatafieldName = "BaseValuePrecision";
            this.nibBaseValuePrecision.Location = new System.Drawing.Point(10, 408);
            this.nibBaseValuePrecision.MaxDropDownItems = 8;
            this.nibBaseValuePrecision.Name = "nibBaseValuePrecision";
            this.nibBaseValuePrecision.NullString = null;
            this.nibBaseValuePrecision.NullValueMessage = null;
            this.nibBaseValuePrecision.Size = new System.Drawing.Size(296, 24);
            this.nibBaseValuePrecision.TabIndex = 7;
            this.nibBaseValuePrecision.Text = "Basiswertgenauigkeit: ";
            this.nibBaseValuePrecision.ValueAreaLength = 92;
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(319, 411);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(96, 16);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Dezimalstellen";
            //
            //Label2
            //
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(319, 580);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(96, 16);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "Dezimalstellen";
            //
            //Label3
            //
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label3.Location = new System.Drawing.Point(11, 436);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(424, 28);
            this.Label3.TabIndex = 9;
            this.Label3.Text = "Wichtig: Basiswerte, wie 'te', werden in Facesso immer auf der Grundlage von h/mi" + "n (hundertstel Minuten) angegeben! Diese Berechnungsgrundlage ist nicht �nderbar" + "!";
            //
            //frmCostcenterInfoAddEditView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.ClientSize = new System.Drawing.Size(584, 612);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.nibBaseValuePrecision);
            this.Controls.Add(this.ntbBaseValueSynonym);
            this.Controls.Add(this.ncbIDCurrency);
            this.Controls.Add(this.nibIncentiveIndicatorPrecision);
            this.Controls.Add(this.ntbIncentiveWageSynonym);
            this.Controls.Add(this.ndbIncentiveIndicatorFactor);
            this.Controls.Add(this.ncbUseFixValuedBonus);
            this.Controls.Add(this.ntbIncentiveDimension);
            this.Controls.Add(this.ntbIncentiveSynonym);
            this.Controls.Add(this.nibCostCenterNo);
            this.Controls.Add(this.nsbCostCenterDescription);
            this.Controls.Add(this.nsbCostCenterName);
            this.Name = "frmCostcenterInfoAddEditView";
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.nsbCostCenterName, 0);
            this.Controls.SetChildIndex(this.nsbCostCenterDescription, 0);
            this.Controls.SetChildIndex(this.nibCostCenterNo, 0);
            this.Controls.SetChildIndex(this.ntbIncentiveSynonym, 0);
            this.Controls.SetChildIndex(this.ntbIncentiveDimension, 0);
            this.Controls.SetChildIndex(this.ncbUseFixValuedBonus, 0);
            this.Controls.SetChildIndex(this.ndbIncentiveIndicatorFactor, 0);
            this.Controls.SetChildIndex(this.ntbIncentiveWageSynonym, 0);
            this.Controls.SetChildIndex(this.nibIncentiveIndicatorPrecision, 0);
            this.Controls.SetChildIndex(this.ncbIDCurrency, 0);
            this.Controls.SetChildIndex(this.ntbBaseValueSynonym, 0);
            this.Controls.SetChildIndex(this.nibBaseValuePrecision, 0);
            this.Controls.SetChildIndex(this.Label1, 0);
            this.Controls.SetChildIndex(this.Label2, 0);
            this.Controls.SetChildIndex(this.Label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void FillDecimalPlacesList()
        {
            for (int z = 0; z <= 4; z++)
            {
                ADComboBoxItem locCbi = new ADComboBoxItem(z, z);
                nibIncentiveIndicatorPrecision.Items.Add(locCbi);
                nibBaseValuePrecision.Items.Add(locCbi);
            }

            nibIncentiveIndicatorPrecision.TypeSafeValue = 0;
        }

        protected override void Fac_OnInitializeFormControls()
        {
            base.Fac_OnInitializeFormControls();
            Fac_FunctionsInternal.AddCurrencyToADNullableIdOrIndexComboBox(ncbIDCurrency);
            FillDecimalPlacesList();
            ntbIncentiveDimension.TypeSafeValue = Facesso.Functions.My.Resources.Incentive_Dimension;
            ntbIncentiveSynonym.TypeSafeValue = Facesso.Functions.My.Resources.Incentive_Synonym;
            ntbIncentiveWageSynonym.TypeSafeValue = Facesso.Functions.My.Resources.Incentive_WageSynonym;
            ncbUseFixValuedBonus.TypeSafeValue = false;
            ndbIncentiveIndicatorFactor.TypeSafeValue = 1;
        }

        protected override void Fac_OnAssigningToControls(ActiveDev.IInfoItem InfoItem)
        {
            Fac_FunctionsInternal.AddCurrencyToADNullableIdOrIndexComboBox(ncbIDCurrency);
            FillDecimalPlacesList();
            base.Fac_OnAssigningToControls(InfoItem);
        }

        protected override void Fac_OnValidatingNew(System.ComponentModel.CancelEventArgs e)
        {
            base.Fac_OnValidatingNew(e);
            SPAccess locSPA = SPAccess.GetInstance();
            //Feststellen, ob die Kostenstellennr. schon existiert
            if (locSPA.CostCenters_DoesNumberExist(FacessoGeneric.LoginInfo.IDSubsidiary, System.Convert.ToInt32(nibCostCenterNo.Value.Value), default(ActiveDev.ADDBNullable<int>)))
            {
                string locErr = Facesso.Functions.My.Resources.CostCenterInfoAdd_CostCenterNoAlreadyExist_MB_Body;
                locErr = string.Format(locErr, System.Convert.ToInt32(nibCostCenterNo.Value.Value), FacessoGeneric.SubsidiarySynonym, FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName);
                MessageBox.Show(locErr, Facesso.Functions.My.Resources.CostCenterInfoAdd_CostCenterNoAlreadyExist_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
        }

        protected override void Fac_OnValidatingEdit(InfoItemValidatingEventArgs e)
        {
            base.Fac_OnValidatingEdit(e);
            SPAccess locSPA = SPAccess.GetInstance();
            //Feststellen, ob die Kostenstellennr. schon existiert
            if (locSPA.CostCenters_DoesNumberExist(FacessoGeneric.LoginInfo.IDSubsidiary, System.Convert.ToInt32(nibCostCenterNo.Value.Value), ((CostcenterInfo)e.InfoItem).IDCostCenter))
            {
                string locErr = Facesso.Functions.My.Resources.CostCenterInfoAdd_CostCenterNoAlreadyExist_MB_Body;
                locErr = string.Format(locErr, System.Convert.ToInt32(nibCostCenterNo.Value.Value), FacessoGeneric.SubsidiarySynonym, FacessoGeneric.LoginInfo.SubsidiaryInfo.SubsidiaryName);
                MessageBox.Show(locErr, Facesso.Functions.My.Resources.CostCenterInfoAdd_CostCenterNoAlreadyExist_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
        }

        protected override void Fac_OnAssigningToInfoItem(IInfoItem InfoItem)
        {
            base.Fac_OnAssigningToInfoItem(InfoItem);
            // Abspeichern der Kostenstelle
            SPAccess locSPA = SPAccess.GetInstance();
            ((CostcenterInfo)InfoItem).IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary;
            if (Fac_EditMode == InfoItemFormEditMode.AddNew)
            {
                locSPA.CostCenters_Add(((CostcenterInfo)InfoItem), FacessoGeneric.LoginInfo.IDUser);
            }
            else if (Fac_EditMode == InfoItemFormEditMode.Edit)
            {
                locSPA.CostCenters_Edit(((CostcenterInfo)InfoItem), FacessoGeneric.LoginInfo.IDUser);
            }
        }
    }
}