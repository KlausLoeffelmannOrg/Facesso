using ActiveDev;
using ActiveDev.Controls;
using Facesso;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public partial class frmInfoItemAddEditViewBase
    {
        private IInfoItem myInfoItem;
        private InfoItemFormEditMode myEditMode;
        public virtual InfoItemMaintenanceDialogResult Fac_HandleDialogAsAdd(string FormCaption, Type InfoItemType)
        {
            using (this)
            {
                this.Text = FormCaption;
                btnOK.Text = Facesso.Functions.My.Resources.InfoItemBase_AddCommandButtonText;
                myInfoItem = CreateInstance(InfoItemType);
                Fac_EditMode = InfoItemFormEditMode.AddNew;
                Fac_OnInitializeFormControls();
                this.ShowDialog();
                if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    Fac_OnAssigningToInfoItem(myInfoItem);
                }

                return new InfoItemMaintenanceDialogResult(myInfoItem, this.DialogResult);
            }

            return default(InfoItemMaintenanceDialogResult);
        }

        public virtual InfoItemMaintenanceDialogResult Fac_HandleDialogAsEdit(string FormCaption, IInfoItem InfoItem)
        {
            using (this)
            {
                this.Text = FormCaption;
                btnOK.Text = Facesso.Functions.My.Resources.InfoItemBase_EditCommandButtonText;
                myInfoItem = InfoItem;
                Fac_EditMode = InfoItemFormEditMode.Edit;
                Fac_OnAssigningToControls(myInfoItem);
                this.ShowDialog();
                if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    Fac_OnAssigningToInfoItem(myInfoItem);
                }

                return new InfoItemMaintenanceDialogResult(myInfoItem, this.DialogResult);
            }

            return default(InfoItemMaintenanceDialogResult);
        }

        public virtual InfoItemMaintenanceDialogResult Fac_HandleDialogAsView(string FormCaption, IInfoItem InfoItem)
        {
            using (this)
            {
                this.Text = FormCaption;
                btnOK.Text = Facesso.Functions.My.Resources.InfoItemBase_ViewCommandButtonText;
                myInfoItem = InfoItem;
                Fac_EditMode = InfoItemFormEditMode.View;
                Fac_OnAssigningToControls(myInfoItem);
                this.ShowDialog();
                return new InfoItemMaintenanceDialogResult(myInfoItem, this.DialogResult);
            }

            return default(InfoItemMaintenanceDialogResult);
        }

        /// <summary>
        /// Legt den Editiermodus fest, den das Formular
        /// </summary>
        /// <value></value>
        /// <remarks></remarks>
        public InfoItemFormEditMode Fac_EditMode
        {
            get
            {
                return myEditMode;
            }

            set
            {
                myEditMode = value;
                if (myEditMode == InfoItemFormEditMode.AddNew)
                {
                    this.btnCancel.Visible = true;
                }
                else if (myEditMode == InfoItemFormEditMode.Edit)
                {
                    this.btnCancel.Visible = true;
                }
                else
                {
                    this.btnCancel.Visible = false;
                }
            }
        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            CancelEventArgs locCancelEventArgs = null;
            if (Fac_EditMode == InfoItemFormEditMode.AddNew)
            {
                locCancelEventArgs = new CancelEventArgs();
                Fac_OnValidatingNew(locCancelEventArgs);
            }
            else if (Fac_EditMode == InfoItemFormEditMode.Edit)
            {
                locCancelEventArgs = new InfoItemValidatingEventArgs(myInfoItem, false);
                Fac_OnValidatingEdit(((InfoItemValidatingEventArgs)locCancelEventArgs));
            }

            if (!(locCancelEventArgs.Cancel))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// Liest alle IADNullableControl aus der Control-Collection des Formulars,
        /// und versucht deren Value-Property dynamisch anhand der IndependentDatafield-Eigenschaft
        /// der IInfoItems zuzuweisen.
        /// </summary>
        /// <param name = "InfoItem">IInfoItem einbindende Klasseninstanz, der die Werte des Formulars zugewiesen werden.</param>
        /// <remarks> Um zu erg�nzen, muss in der �berschriebenen Methode
        /// ZUERST MyBase.OnAssigningToInfoItem aufgerufen werden!</remarks>
        protected virtual void Fac_OnAssigningToInfoItem(IInfoItem InfoItem)
        {
            InfoItem.AssignFieldsFromNullableControls(ADNullableValueControls.FromContainerControl(this));
        }

        /// <summary>
        /// Liest alle IADNullableControl aus der Control-Collection des Formulars,
        /// und versucht an deren Value-Property dynamisch anhand der IndependentDatafield-Eigenschaft
        /// die Werte der entsprechenden IInfoItems-Eigenschaften zuzuweisen.
        /// </summary>
        /// <param name = "InfoItem">IInfoItem einbindende Klasseninstanz, die die Werte f�r die Formularbelegung enth�lt.</param>
        /// <remarks></remarks>
        protected virtual void Fac_OnAssigningToControls(IInfoItem InfoItem)
        {
            InfoItem.AssignFieldsToNullableControls(ADNullableValueControls.FromContainerControl(this));
        }

        /// <summary>
        /// Gibt dem ableitenden Formular die M�glichkeit, die Eingaben auf Plausibilit�t f�r
        /// das Hinzuf�gen eines Datensatzes zu pr�fen.
        /// </summary>
        /// <param name = "e">CancelEventArgs, dessen Cancel-Eigenschaft beim Setzen das Validieren fehlschlagen l�sst.</param>
        /// <remarks></remarks>
        protected virtual void Fac_OnValidatingNew(CancelEventArgs e)
        {
            ADNullableValueControls locControls = ADNullableValueControls.FromContainerControl(this);
            string locBackString = locControls.CheckForNotAllowedNullValues();
            if (locBackString != null)
            {
                locBackString = Facesso.Functions.My.Resources.InfoItemBase_NullsInFields_MB_BodyPrefix + System.Environment.NewLine + System.Environment.NewLine + locBackString;
                MessageBox.Show(locBackString, Facesso.Functions.My.Resources.InfoItemBase_NullsInFields_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Gibt dem ableitenden Formular die M�glichkeit, die Eingaben auf Plausibilit�t f�r
        /// das Editieren eines Datensatzes zu pr�fen.
        /// </summary>
        /// <param name = "e">CancelEventArgs, dessen Cancel-Eigenschaft beim Setzen das Validieren fehlschlagen l�sst.</param>
        /// <remarks></remarks>
        protected virtual void Fac_OnValidatingEdit(InfoItemValidatingEventArgs e)
        {
            ADNullableValueControls locControls = ADNullableValueControls.FromContainerControl(this);
            string locBackString = locControls.CheckForNotAllowedNullValues();
            if (locBackString != null)
            {
                locBackString = Facesso.Functions.My.Resources.InfoItemBase_NullsInFields_MB_BodyPrefix + System.Environment.NewLine + System.Environment.NewLine + locBackString;
                MessageBox.Show(locBackString, Facesso.Functions.My.Resources.InfoItemBase_NullsInFields_MB_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Gibt dem ableitenden Form die M�glichkeit, die Steuerelemente mit Default-Werten zu belegen.
        /// </summary>
        /// <remarks></remarks>
        protected virtual void Fac_OnInitializeFormControls()
        {
        }

        /// <summary>
        /// Ermittelt die vom Formular verarbeitete Datenklasse (die auf InfoItem basiert).
        /// </summary>
        /// <value>InfoItem basierte Datenklasse, die durch das IInfoItem-Interface referenziert wird.</value>
        /// <remarks></remarks>
        protected IInfoItem Fac_InfoItem
        {
            get
            {
                return myInfoItem;
            }

            set
            {
                myInfoItem = value;
            }
        }

        private IInfoItem CreateInstance(Type InfoType)
        {
            ConstructorInfo locCI = InfoType.GetConstructor(System.Type.EmptyTypes);
            return ((IInfoItem)locCI.Invoke(null));
        }

        public frmInfoItemAddEditViewBase()
        {
            InitializeComponent();
        }
    }

    public class InfoItemValidatingEventArgs : CancelEventArgs
    {
        private IInfoItem myInfoItem;
        public InfoItemValidatingEventArgs(IInfoItem InfoItem, bool Cancel) : base(Cancel)
        {
            myInfoItem = InfoItem;
        }

        public IInfoItem InfoItem
        {
            get
            {
                return myInfoItem;
            }

            set
            {
                myInfoItem = value;
            }
        }
    }
}