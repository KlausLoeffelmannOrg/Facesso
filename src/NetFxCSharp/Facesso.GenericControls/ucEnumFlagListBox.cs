using ActiveDev;
using ActiveDev.Controls;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.GenericControls
{
    [CLSCompliant(false)]
    public class ucClearanceLevelCheckListBox : ADEnumFlagCheckListBox<ClearanceLevel>, IADNullableValueControl
    {
        private ADDBNullable<ClearanceLevel> myValue;
        private string myIndependentDatafieldName;
        private bool myOnceModified;
        public event ActiveDev.Controls.IADNullableValueControl.ValueChangedEventHandler ValueChanged;
        public event ActiveDev.Controls.IADNullableValueControl.OnceModifiedChangedEventHandler OnceModifiedChanged;
        public override string GetLocalizedEnumElementNamesPipeSeparated()
        {
            return FacessoGeneric.RoleList;
        }

        protected override void OnItemCheck(System.Windows.Forms.ItemCheckEventArgs ice)
        {
            base.OnItemCheck(ice);
            ADDBNullable<ClearanceLevel> locValue = ADDBNullable.FromObject<ClearanceLevel>(((ClearanceLevel)base.ValueInternal));
            if (!(base.myEventSourceWasSelf))
            {
                HandleOnceModified(locValue);
            }
        }

        public string IndependentDatafieldName
        {
            get
            {
                return myIndependentDatafieldName;
            }

            set
            {
                myIndependentDatafieldName = value;
            }
        }

        public bool OnceModified
        {
            get
            {
                return myOnceModified;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IADDBNullableValue Value
        {
            get
            {
                return myValue;
            }

            set
            {
                bool locChangedFlag = default(bool);
                if (((ADDBNullable<ClearanceLevel>)value) != ((ADDBNullable<ClearanceLevel>)myValue))
                {
                    locChangedFlag = true;
                }

                if (base.IsHandleCreated)
                {
                    RenderValue(System.Convert.ToInt64(value.Value));
                }
                else
                {
                    base.myValueInternal = System.Convert.ToInt64(value.Value);
                    myValue = ((ADDBNullable<ClearanceLevel>)value);
                }

                if (locChangedFlag)
                {
                    ValueChanged?.Invoke(this, new EventArgs());
                }
            }
        }

        private void HandleOnceModified(IADDBNullableValue newValue)
        {
            ADDBNullable<ClearanceLevel> locTempValue = ((ADDBNullable<ClearanceLevel>)newValue);
            if (locTempValue != myValue)
            {
                myValue = locTempValue;
                ValueChanged?.Invoke(this, new EventArgs());
                if (!(myOnceModified))
                {
                    OnceModifiedChanged?.Invoke(this, new EventArgs());
                    myOnceModified = true;
                }
            }
        }

        public string NullValueMessage
        {
            get
            {
                return null;
            }

            set
            {
            }
        }

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
    }

    public enum CombinedFlagsSelectionBehaviour
    {
        SelectSingelFlag,
        IgnoreSingleFlag,
    }

    public abstract class ADEnumFlagCheckListBox<EType> : CheckedListBox
    {
        private CombinedFlagsSelectionBehaviour myDeselectCombinedFlagsItemBehaviour;
        private CombinedFlagsSelectionBehaviour mySelectCombinedFlagsItemBehaviour;
        protected bool myEventSourceWasSelf;
        protected long myValueInternal;
        public ADEnumFlagCheckListBox() : base()
        {
            myDeselectCombinedFlagsItemBehaviour = CombinedFlagsSelectionBehaviour.IgnoreSingleFlag;
            mySelectCombinedFlagsItemBehaviour = CombinedFlagsSelectionBehaviour.SelectSingelFlag;
            this.CheckOnClick = true;
            myValueInternal = 0;
        }

        protected override void OnHandleCreated(System.EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!(this.DesignMode))
            {
                string locLocalizedText = GetLocalizedEnumElementNamesPipeSeparated();
                EnumCheckListBoxItems<EType> locEnumItems = new EnumCheckListBoxItems<EType>(locLocalizedText);
                foreach (EnumCheckListBoxItem<EType> locItem in locEnumItems)
                {
                    this.Items.Add(locItem, false);
                }

                RenderValue(myValueInternal);
            }
        }

        protected override void OnItemCheck(System.Windows.Forms.ItemCheckEventArgs ice)
        {
            if (this.Items.Count == 0)
            {
                return;
            }

            if (myEventSourceWasSelf)
            {
                return;
            }

            try
            {
                EnumCheckListBoxItem<EType> locEnumItem = default(EnumCheckListBoxItem<EType>);
                EnumCheckListBoxItem<EType> locSelectedItem = ((EnumCheckListBoxItem<EType>)this.Items[ice.Index]);
                int locStartIndex = 0;
                //Wenn das erste Enum-Element Null-Wertigkeit hat,
                //dann ist StartIndex für alle weiteren Operationen 1
                if (((EnumCheckListBoxItem<EType>)this.Items[0]).EnumItemValue == 0)
                {
                    locStartIndex = 1;
                    //Wenn selektiertes Element mit Enum-Wertigkeit 0 ist, dann
                    //alle anderen zurücksetzen, wenn dieses Element gechecked wurde.
                    if (locSelectedItem.EnumItemValue == 0)
                    {
                        if (ice.NewValue == CheckState.Checked)
                        {
                            // Alle löschen
                            myEventSourceWasSelf = true;
                            for (int locCount = 1; locCount <= this.Items.Count - 1; locCount++)
                            {
                                this.SetItemChecked(locCount, false);
                            }

                            myEventSourceWasSelf = false;
                        }
                        else
                        {
                            myEventSourceWasSelf = true;
                            if (this.Items.Count > 1)
                            {
                                this.SetItemChecked(1, true);
                            }

                            myEventSourceWasSelf = false;
                        }

                        return;
                    }
                }

                if (ice.NewValue == CheckState.Checked)
                {
                    if (SelectCombinedFlagsItemBehaviour == CombinedFlagsSelectionBehaviour.SelectSingelFlag)
                    {
                        myEventSourceWasSelf = true;
                        for (int locCount = 1; locCount <= this.Items.Count - 1; locCount++)
                        {
                            locEnumItem = ((EnumCheckListBoxItem<EType>)this.Items[locCount]);
                            if ((locSelectedItem.EnumItemValue & locEnumItem.EnumItemValue) == locEnumItem.EnumItemValue)
                            {
                                this.SetItemChecked(locCount, true);
                            }
                        }

                        myEventSourceWasSelf = false;
                    }
                }
                else
                {
                    if (DeselectCombinedFlagsItemBehaviour == CombinedFlagsSelectionBehaviour.SelectSingelFlag)
                    {
                        myEventSourceWasSelf = true;
                        for (int locCount = 1; locCount <= this.Items.Count - 1; locCount++)
                        {
                            locEnumItem = ((EnumCheckListBoxItem<EType>)this.Items[locCount]);
                            if ((locSelectedItem.EnumItemValue & locEnumItem.EnumItemValue) == locEnumItem.EnumItemValue)
                            {
                                this.SetItemChecked(locCount, false);
                            }
                        }

                        myEventSourceWasSelf = false;
                    }

                    //Die Übergeordneten zurücksetzen
                    myEventSourceWasSelf = true;
                    for (int locCount = 1; locCount <= this.Items.Count - 1; locCount++)
                    {
                        locEnumItem = ((EnumCheckListBoxItem<EType>)this.Items[locCount]);
                        if ((locEnumItem.EnumItemValue & locSelectedItem.EnumItemValue) == locSelectedItem.EnumItemValue)
                        {
                            this.SetItemChecked(locCount, false);
                        }
                    }

                    myEventSourceWasSelf = false;
                }
            }
            finally
            {
                //Keine mehr angeklickt, dann "0"-Wert voreinstellen
                if (this.CheckedItems.Count == 0)
                {
                    myEventSourceWasSelf = true;
                    this.SetItemChecked(0, true);
                    myEventSourceWasSelf = false;
                }

                //Dafür sorgen, dass "0"-Wert nicht voreingestellt ist,
                //wenn andere Elemente ausgewählt werden.
                if (ice.Index > 0 & ice.NewValue == CheckState.Checked)
                {
                    myEventSourceWasSelf = true;
                    this.SetItemChecked(0, false);
                    myEventSourceWasSelf = false;
                }

                base.OnItemCheck(ice);
                long locLong = default(long);
                foreach (EnumCheckListBoxItem<EType> li in this.CheckedItems)
                {
                    locLong = locLong | li.EnumItemValue;
                }

                myValueInternal = locLong;
                Debug.Print(myValueInternal.ToString());
            }
        }

        protected long ValueInternal
        {
            get
            {
                return myValueInternal;
            }

            set
            {
                RenderValue(value);
            }
        }

        protected void RenderValue(long Value)
        {
            try
            {
                myEventSourceWasSelf = true;
                if (Value == 0)
                {
                    SetItemChecked(0, true);
                    return;
                }

                for (int locCount = 1; locCount <= this.Items.Count - 1; locCount++)
                {
                    EnumCheckListBoxItem<EType> locCurrentItem = ((EnumCheckListBoxItem<EType>)this.Items[locCount]);
                    if ((Value & locCurrentItem.EnumItemValue) == locCurrentItem.EnumItemValue)
                    {
                        SetItemChecked(locCount, true);
                    }
                    else
                    {
                        SetItemChecked(locCount, false);
                    }
                }
            }
            finally
            {
                myEventSourceWasSelf = false;
            }
        }

        public CombinedFlagsSelectionBehaviour DeselectCombinedFlagsItemBehaviour
        {
            get
            {
                return myDeselectCombinedFlagsItemBehaviour;
            }

            set
            {
                myDeselectCombinedFlagsItemBehaviour = value;
            }
        }

        public CombinedFlagsSelectionBehaviour SelectCombinedFlagsItemBehaviour
        {
            get
            {
                return mySelectCombinedFlagsItemBehaviour;
            }

            set
            {
                mySelectCombinedFlagsItemBehaviour = value;
            }
        }

        public abstract string GetLocalizedEnumElementNamesPipeSeparated();
        public override string ToString()
        {
            StringBuilder locString = new StringBuilder();
            foreach (EnumCheckListBoxItem<EType> li in this.CheckedItems)
            {
                locString.Append(li.LocalizedText + "; ");
            }

            return locString.ToString();
        }
    }

    internal struct EnumCheckListBoxItem<EType>
    {
        public long EnumItemValue;
        public string EnumText;
        public string LocalizedText;
        public EnumCheckListBoxItem(long value, string et, string lt)
        {
            if (typeof(EType).BaseType != typeof(Enum))
            {
                TypeLoadException up = new TypeLoadException("Only Enum derivatives are allowed in this context!");
                throw up;
            }

            EnumItemValue = value;
            EnumText = et;
            LocalizedText = lt;
        }

        public override string ToString()
        {
            return LocalizedText;
        }
    }

    internal class EnumCheckListBoxItems<EType> : System.Collections.ObjectModel.KeyedCollection<long, EnumCheckListBoxItem<EType>>
    {
        public EnumCheckListBoxItems(string plainTextElements) : base()
        {
            if (typeof(EType).BaseType != typeof(Enum))
            {
                TypeLoadException up = new TypeLoadException("Only Enum derivatives are allowed in this context!");
                throw up;
            }

            string[] locLocalizedElements = plainTextElements.Split(new char[] { '|' });
            string[] locOriginalElements = Enum.GetNames(typeof(EType));
            int locCount = 0;
            foreach (long i in Enum.GetValues(typeof(EType)))
            {
                this.Add(new EnumCheckListBoxItem<EType>(i, locOriginalElements[locCount], locLocalizedElements[locCount]));
                locCount += 1;
            }
        }

        protected override long GetKeyForItem(EnumCheckListBoxItem<EType> item)
        {
            return System.Convert.ToInt64(item.EnumItemValue);
        }
    }
}