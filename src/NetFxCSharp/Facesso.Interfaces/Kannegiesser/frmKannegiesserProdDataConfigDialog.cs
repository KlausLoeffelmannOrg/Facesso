using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.Interfaces
{
    public partial class frmKannegiesserProdDataConfigDialog
    {
        private void btnChoosePath_Click(System.Object sender, System.EventArgs e)
        {
            FolderBrowserDialog locFB = new FolderBrowserDialog();
            locFB.Description = "Pfad zur Kannegiesser-Gerätedaten wählen:";
            DialogResult locDR = locFB.ShowDialog();
            if (locDR == System.Windows.Forms.DialogResult.OK)
            {
                txtPathToDeviceData.Text = locFB.SelectedPath;
                ((KannegiesserProductionDataImportTaskElement)TaskItem).PathToDeviceData = locFB.SelectedPath;
                TaskItem.ConversionItems = ((KannegiesserProductionDataImportTaskElement)TaskItem).AssembleConversionItems();
                RebuildLists();
            }
        }

        protected override void InitializeControls()
        {
            base.InitializeControls();
            myAllowMultipleAssignments = true;
        }

        public frmKannegiesserProdDataConfigDialog()
        {
            InitializeComponent();
        }
    }
}