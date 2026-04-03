using System.Diagnostics;
using System.Windows.Forms;

namespace ActiveDev.Data.SqlClient
{
    public abstract class ADSqlInfoComboBase : ComboBox
    {
        private bool _queryInfoOnDropDown;

        public ADSqlInfoComboBase() : base()
        {
        }

        protected virtual void OnDropDownButtonClickedToOpen(System.EventArgs e)
        {
            if (QueryInfoOnDropDown)
            {
                if (this.Items.Count == 0)
                    PopulateItemsInternal();
            }

            // Must open manually since WM_REFLECTED for DropDown is no longer raised.
            this.DroppedDown = true;
        }

        [DebuggerStepThrough]
        protected override void WndProc(ref Message m)
        {
            // WM_LBUTTONDOWN is raised on the ComboBox only over the drop-down button.
            if (m.Msg == 0x201)
            {
                if (!this.DroppedDown)
                {
                    OnDropDownButtonClickedToOpen(System.EventArgs.Empty);
                    return;
                }
            }
            base.WndProc(ref m);
        }

        public bool QueryInfoOnDropDown
        {
            get => _queryInfoOnDropDown;
            set => _queryInfoOnDropDown = value;
        }

        protected virtual void PopulateItemsInternal()
        {
            if (this.Items != null)
                this.Items.Clear();
        }

        public void PopulateInfoItemsManually()
        {
            PopulateItemsInternal();
        }
    }
}
