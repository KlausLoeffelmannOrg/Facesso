using Facesso.Data;
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

namespace Facesso.Functions
{
    public partial class frmWorkGroupAnalysisManager
    {
        private WorkGroupAnalysisParametersCollection myAnalyses;
        private int myMaxMenuEntries;
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            //Von der Version abh�ngig machen, wie viele Men�eintr�ge erlaubt sind.
            if (FacessoGeneric.FacessoLicenseInfo.VersionPermissionInfo.FacessoVersion == FacessoVersion.FacessoStandard)
            {
                myMaxMenuEntries = 5;
            }
            else if (FacessoGeneric.FacessoLicenseInfo.VersionPermissionInfo.FacessoVersion == FacessoVersion.FacessoLight)
            {
                myMaxMenuEntries = 2;
            }
            else if (FacessoGeneric.FacessoLicenseInfo.VersionPermissionInfo.FacessoVersion == FacessoVersion.FacessoProfessional)
            {
                myMaxMenuEntries = 10;
            }
            else if (FacessoGeneric.FacessoLicenseInfo.VersionPermissionInfo.FacessoVersion == FacessoVersion.FacessoEnterprise)
            {
                myMaxMenuEntries = 15;
            }

            //Liste laden
            FileInfo locFi = new FileInfo(FacessoGeneric.SharedFolder + "\\AnalysisInfo\\FacessoAnalyses.Xml");
            myAnalyses = WorkGroupAnalysisParametersCollection.FromFile(locFi);
            if (myAnalyses == null)
            {
                myAnalyses = new WorkGroupAnalysisParametersCollection();
            }

            rebuildList();
        }

        private void rebuildList()
        {
            //Menuitems-Templates aufbauen
            cmbMenuIndex.Items.Clear();
            cmbMenuIndex.Items.Add("- Kein Men�eintrag -");
            for (int locCount = 1; locCount <= myMaxMenuEntries; locCount++)
            {
                cmbMenuIndex.Items.Add(locCount.ToString("00") + ": - bislang nicht definiert -");
            }

            //Menu-Item-Liste aktualisieren und gleichzeitig die Analysen-Liste aufbauen
            lstAnalysis.Items.Clear();
            foreach (WorkGroupAnalysisParameters locItem in myAnalyses)
            {
                if (locItem.MenuIndex > 0)
                {
                    cmbMenuIndex.Items[locItem.MenuIndex] = locItem.MenuIndex.ToString("00") + ": " + locItem.MenuName;
                }

                lstAnalysis.Items.Add(locItem);
            }

            //Ersten Punkt vorselektieren
            cmbMenuIndex.SelectedIndex = 0;
        }

        protected override void OnClosed(System.EventArgs e)
        {
            base.OnClosed(e);
            //List abspeichern, wenn es mehr als ein Element gibt!
            SaveChanges();
        }

        private void SaveChanges()
        {
            FileInfo locFi = new FileInfo(FacessoGeneric.SharedFolder + "\\AnalysisInfo\\FacessoAnalyses.Xml");
            if (myAnalyses.Count > 0)
            {
                myAnalyses.ToFile(locFi);
            }
            else
            {
                locFi.Delete();
            }
        }

        private void btnNewAnalysis_Click(System.Object sender, System.EventArgs e)
        {
            if (!(CheckParametersPlausibility(txtAnalysisName.Text, -1, false)))
            {
                return;
            }

            //Todo: Men�zuordnung
            //Assistenten aufrufen
            frmWorkGroupAnalysis locFrmWorkgroupAnalysisWizard = new frmWorkGroupAnalysis();
            WorkGroupAnalysisParameters locAnalysisParameters = locFrmWorkgroupAnalysisWizard.GetAnalysisParameters();
            if (locAnalysisParameters != null)
            {
                locAnalysisParameters.Name = txtAnalysisName.Text;
                myAnalyses.Add(locAnalysisParameters);
                rebuildList();
            }

            SaveChanges();
        }

        private void btnEditAnalysis_Click(System.Object sender, System.EventArgs e)
        {
            if (!(CheckParametersPlausibility(txtAnalysisName.Text, lstAnalysis.SelectedIndex, true)))
            {
                return;
            }

            frmWorkGroupAnalysis locFrmWorkgroupAnalysisWizard = new frmWorkGroupAnalysis();
            WorkGroupAnalysisParameters locAnalysisParameters = ((WorkGroupAnalysisParameters)lstAnalysis.SelectedItem);
            locAnalysisParameters.Name = txtAnalysisName.Text;
            locAnalysisParameters = locFrmWorkgroupAnalysisWizard.GetAnalysisParameters(locAnalysisParameters);
            if (locAnalysisParameters != null)
            {
                lstAnalysis.SelectedItem = locAnalysisParameters;
            }

            SaveChanges();
        }

        private void btnDeleteAnalysis_Click(System.Object sender, System.EventArgs e)
        {
            int locIndex = default(int);
            if (!(CheckParametersPlausibility(null, -1, true)))
            {
                return;
            }

            foreach (WorkGroupAnalysisParameters locAnalysisParameters in myAnalyses)
            {
                if (((WorkGroupAnalysisParameters)lstAnalysis.SelectedItem).Name == locAnalysisParameters.Name)
                {
                    break;
                }

                locIndex += 1;
            }

            myAnalyses.RemoveAt(locIndex);
            rebuildList();
            SaveChanges();
        }

        private bool CheckParametersPlausibility(string name, int DontCheckThisIndex, bool checkSelection)
        {
            int locIndex = 0;
            bool locNameExist = default(bool);
            if (checkSelection)
            {
                if (lstAnalysis.SelectedIndex < 0)
                {
                    MessageBox.Show("Sie haben keine Analyse zur Bearbeitung ausgew�hlt!", "Fehlende Auswahl!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            if (name != null)
            {
                if (txtAnalysisName.Text == "")
                {
                    MessageBox.Show("Bitte geben Sie einen Namen f�r die Analyse ein!", "Fehlender Name!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAnalysisName.Focus();
                    return false;
                }

                foreach (WorkGroupAnalysisParameters locItem in lstAnalysis.Items)
                {
                    if (locItem.Name == txtAnalysisName.Text & !(DontCheckThisIndex == locIndex))
                    {
                        locNameExist = true;
                        break;
                    }

                    locIndex += 1;
                }

                if (locNameExist)
                {
                    MessageBox.Show("Dieser Analysename ist schon vorhanden. Bitte w�hlen Sie einen anderen Namen f�r diese Analyse!", "Name schon vorhanden!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAnalysisName.Focus();
                    return false;
                }
            }

            return true;
        }

        private void lstAnalysis_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (lstAnalysis.SelectedIndex > -1)
            {
                txtAnalysisName.Text = lstAnalysis.SelectedItem.ToString();
            }
            else
            {
                txtAnalysisName.Text = "";
            }
        }

        private void btnUseAnalysis_Click(System.Object sender, System.EventArgs e)
        {
            if (!(CheckParametersPlausibility(null, -1, true)))
            {
                return;
            }

            WorkGroupAnalysisPerformer locAnalysisPerformer = default(WorkGroupAnalysisPerformer);
            try
            {
                locAnalysisPerformer = new WorkGroupAnalysisPerformer(((WorkGroupAnalysisParameters)lstAnalysis.SelectedItem));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seit der letzten Analyse haben sich die Produktiv-Sites ge�ndert," + System.Environment.NewLine + "oder die Analyse-Infos stammen von einem anderen System." + System.Environment.NewLine + "L�schen Sie die Analyse und erstellen Sie sie erneut!", "Fehler bei Produktiv-Site-Vorauswahl!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            locAnalysisPerformer.PerformAnalysis();
        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public frmWorkGroupAnalysisManager()
        {
            InitializeComponent();
        }
    }
}