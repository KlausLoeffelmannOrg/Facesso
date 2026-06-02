using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso
{
    public partial class frmError
    {
        public void HandleDialog(Exception ex)
        {
            string locExMessage = default(string);
            locExMessage = ex.Message;
            string locDetailedMessage = default(string);
            locDetailedMessage = "Exception-Message:" + System.Environment.NewLine + "------------------" + System.Environment.NewLine + locExMessage + System.Environment.NewLine + System.Environment.NewLine;
            locDetailedMessage += "Source:" + System.Environment.NewLine + "-------" + System.Environment.NewLine + ex.Source + System.Environment.NewLine + System.Environment.NewLine;
            if (ex.InnerException != null)
            {
                locDetailedMessage += "Inner Exception Message:" + System.Environment.NewLine + "------------------------" + System.Environment.NewLine + ex.InnerException.Message + System.Environment.NewLine + System.Environment.NewLine;
            }

            locDetailedMessage += "Stack-Trace:" + System.Environment.NewLine + "-------" + System.Environment.NewLine + ex.StackTrace + System.Environment.NewLine + System.Environment.NewLine;
            if (!(Environment.UserInteractive))
            {
                Console.Error.WriteLine(locDetailedMessage);
                Environment.ExitCode = 1;
                return;
            }

            lblExceptionText.Text = locExMessage;
            txtExceptionMessage.Text = locDetailedMessage;
            this.ShowDialog();
        }

        private void Button1_Click(System.Object sender, System.EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public frmError()
        {
            InitializeComponent();
        }
    }
}