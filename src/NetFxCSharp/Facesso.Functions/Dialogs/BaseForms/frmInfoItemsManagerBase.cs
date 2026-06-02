using Facesso;
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
    public partial class frmInfoItemsManagerBase
    {
        public delegate void InfoItemsColumnClickEventHandler(object sender, ColumnClickEventArgs e);
        public event InfoItemsColumnClickEventHandler InfoItemsColumnClick;
        private void arvInfoItems_ColumnClick(System.Object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            OnInfoItemsColumnClick(sender, e);
        }

        internal virtual void OnInfoItemsColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            InfoItemsColumnClick?.Invoke(sender, e);
        }

        private void OKToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void arvInfoItems_DoubleClick(System.Object sender, System.EventArgs e)
        {
            OnInfoItemDoubleClick(sender, e);
        }

        internal virtual void OnInfoItemDoubleClick(object sender, System.EventArgs e)
        {
            MessageBox.Show("Diese Funktion ist in diesem Dialog nicht verf�gbar.", "Funktions nicht verf�gbar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public frmInfoItemsManagerBase()
        {
            InitializeComponent();
        }
    }
}