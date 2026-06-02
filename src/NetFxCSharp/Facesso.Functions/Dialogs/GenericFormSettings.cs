using ActiveDev;
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
    public enum InfoItemFormEditMode
    {
        View,
        Edit,
        AddNew,
    }

    public class InfoItemMaintenanceDialogResult
    {
        private DialogResult myDialogResult;
        private IInfoItem myInfoItem;
        public InfoItemMaintenanceDialogResult(IInfoItem InfoItem, DialogResult DialogResult)
        {
            myDialogResult = DialogResult;
            myInfoItem = InfoItem;
        }

        public IInfoItem InfoItem
        {
            get
            {
                return myInfoItem;
            }
        }

        public DialogResult DialogResult
        {
            get
            {
                return myDialogResult;
            }
        }
    }
}