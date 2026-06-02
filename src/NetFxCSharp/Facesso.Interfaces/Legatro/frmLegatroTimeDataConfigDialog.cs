using ActiveDev.Data.SqlClient;
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

namespace Facesso.Interfaces
{
    public partial class frmLegatroTimeDataConfigDialog
    {
        private LegatroTimeDataImport myTaskItem;
        private List<WorkGroupInfo> mySortedWorkgroupInfoItems;
        private List<WorksitesOrProjects> myWorksiteOrProjects;
        public DialogResult HandleDialog(IFacessoImportTaskItem TaskItem)
        {
            myTaskItem = ((LegatroTimeDataImport)TaskItem);
            InitializeControls();
            if (!(string.IsNullOrEmpty(myTaskItem.LegatroSQLConnectionString)))
            {
                txtSqlConnectionString.Text = myTaskItem.LegatroSQLConnectionString;
                RebuildLists();
            }

            this.ShowDialog();
            return this.DialogResult;
        }

        private void btnSelectSqlConnection_Click(System.Object sender, System.EventArgs e)
        {
            ADDatabaseConnectionDialog frm = new ADDatabaseConnectionDialog();
            var connBuilder = frm.GetConnectionBuilder("Legatro-Datenbankinstanz auswählen:");
            if (connBuilder != null)
            {
                txtSqlConnectionString.Text = connBuilder.ConnectionString;
                if (myTaskItem != null)
                {
                    myTaskItem.LegatroSQLConnectionString = txtSqlConnectionString.Text;
                }

                InitializeControls();
                RebuildLists();
            }
        }

        private void InitializeControls()
        {
            {
                var __with0 = lvwLegatroWorksitesOrProjects;
                __with0.Columns.Clear();
                {
                    var __with1 = __with0.Columns;
                    __with1.Add("Nummer:");
                    __with1.Add("Arbeitsplatzname:");
                }
            }
        }

        private void RebuildLists()
        {
            lvwLegatroWorksitesOrProjects.Items.Clear();
            tvwAssignments.Nodes.Clear();
            if (!(string.IsNullOrEmpty(myTaskItem.LegatroSQLConnectionString)))
            {
                LegatroDataContext dc = new LegatroDataContext(myTaskItem.LegatroSQLConnectionString);
                try
                {
                    myWorksiteOrProjects = ((
                        from wsItem in dc.WorksitesOrProjects
                        where !(wsItem.IsProject)orderby wsItem.WorkEntityNumber
                        select wsItem)).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beim Abrufen der Daten aus der Legatro-Datenbank ist ein Fehler aufgetreten." + System.Environment.NewLine + "Bitte Überprüfen Sie die Netzwerkverbindung und die Verbindungszeichenfolge zur Datenbank.", "Verbindungsaufbau zu Legatro nicht möglich!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (var wsItem in myWorksiteOrProjects)
                {
                    ListViewItem lvwItem = new ListViewItem(wsItem.WorkEntityNumber.ToString("000000"));
                    lvwItem.SubItems.Add(wsItem.WorkEntityName);
                    lvwItem.Tag = wsItem;
                    //Rausfinden, ob das Item schon zugewiesen wurde
                    if (myTaskItem.ConversionItems != null)
                    {
                        foreach (var taskItem in myTaskItem.ConversionItems)
                        {
                            if (taskItem.AlienElementID == wsItem.WorkEntityNumber)
                            {
                                //...dann in Fettschrift anzeigen
                                if (taskItem.HomeElementID > -1)
                                {
                                    lvwItem.Font = new System.Drawing.Font(lvwItem.Font, System.Drawing.FontStyle.Bold);
                                }
                            }
                        }
                    }

                    lvwLegatroWorksitesOrProjects.Items.Add(lvwItem);
                }
            }

            foreach (ColumnHeader colItem in lvwLegatroWorksitesOrProjects.Columns)
            {
                colItem.Width = -2;
            }

            WorkGroupInfoItems wgItems = new WorkGroupInfoItems(false);
            mySortedWorkgroupInfoItems = ((
                from wgSortedItem in wgItems
                orderby wgSortedItem.WorkGroupNumber
                select wgSortedItem)).ToList();
            foreach (var item in mySortedWorkgroupInfoItems)
            {
                var tn = tvwAssignments.Nodes.Add(item.WorkGroupNumber + ": " + item.WorkGroupName);
                tn.Tag = item;
                if (item.IsActive)
                {
                    tn.ForeColor = System.Drawing.Color.Blue;
                    tn.NodeFont = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);
                }
                else
                {
                    tn.ForeColor = System.Drawing.Color.Red;
                }
            }

            Application.DoEvents();
            if (myTaskItem.ConversionItems == null)
            {
                myTaskItem.ConversionItems = myTaskItem.AssembleConversionItems();
            }
            else
            {
                //Abgleich, ob sich was geändert hat
                var tmpItems = myTaskItem.AssembleConversionItems();
                var itemsToAdd = new List<FacessoConversionItemBase>();
                foreach (var tmpItem in tmpItems)
                {
                    var found = false;
                    foreach (var taskItem in myTaskItem.ConversionItems)
                    {
                        if (taskItem.AlienElementID == tmpItem.AlienElementID)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!(found))
                    {
                        itemsToAdd.Add(tmpItem);
                    }
                }

                foreach (var itemToAdd in itemsToAdd)
                {
                    myTaskItem.ConversionItems.Add(itemToAdd);
                }
            }

            foreach (var item in myTaskItem.ConversionItems)
            {
                //Ein Facesso-Element (Worksite) ist zugeordnet bei >-1
                if (item.HomeElementID > -1)
                {
                    //Home-Element im Tree suchen
                    foreach (TreeNode nodeItem in tvwAssignments.Nodes)
                    {
                        if (((WorkGroupInfo)nodeItem.Tag).WorkGroupNumber == item.HomeElementID)
                        {
                            //Gefunden: Alien-Element und Item-Name als Zwei eintragen
                            var tmpNode = nodeItem.Nodes.Add(item.AlienElementID.ToString("000000") + ": " + item.Itemname);
                            tmpNode.Tag = item.HomeElementID;
                            nodeItem.Expand();
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            if (lvwLegatroWorksitesOrProjects.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie einen Legatro-Arbeitsplatz zum Zuweisen aus!", "Fehlende Auswahl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tvwAssignments.SelectedNode == null)
            {
                MessageBox.Show("Bitte wählen Sie eine Facesso-Produktiv-Site aus, der der Legatro-Arbeitsplatz zugewiesen werden soll!", "Fehlende Auswahl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var legItem = ((WorksitesOrProjects)lvwLegatroWorksitesOrProjects.SelectedItems[0].Tag);
            var facItem = ((WorkGroupInfo)tvwAssignments.SelectedNode.Tag);
            foreach (var cItem in myTaskItem.ConversionItems)
            {
                if (cItem.AlienElementID == legItem.WorkEntityNumber)
                {
                    cItem.HomeElementID = facItem.WorkGroupNumber;
                    cItem.HomeElementName = facItem.WorkGroupName;
                    break;
                }
            }

            RebuildLists();
        }

        private void btnRemove_Click(System.Object sender, System.EventArgs e)
        {
            if (tvwAssignments.SelectedNode == null)
            {
                MessageBox.Show("Bitte wählen Sie eine Facesso-Produktiv-Site aus, deren Zuweisung aufgehoben werden soll!", "Fehlende Auswahl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tvwAssignments.SelectedNode.Parent == null & tvwAssignments.SelectedNode.Nodes.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie eine Zweig aus, der ein Legatro-Arbeitsplatz/Kostenstelle zugeordnet ist!", "Fehlende Auswahl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TreeNode currentNode = default(TreeNode);
            //Dafür sorgen, dass immer der Hauptzweig ausgewählt ist.
            if (tvwAssignments.SelectedNode.Parent != null)
            {
                currentNode = tvwAssignments.SelectedNode.Parent;
            }
            else
            {
                currentNode = tvwAssignments.SelectedNode;
            }

            //Zugeordnetes WorkgroupInfo-Objekt finden
            var workgroupNumber = System.Convert.ToInt32(currentNode.Nodes[0].Tag);
            var facItem = ((
                from fItem in mySortedWorkgroupInfoItems
                where fItem.WorkGroupNumber == workgroupNumber
                select fItem)).SingleOrDefault();
            if (facItem == null)
            {
                MessageBox.Show("Interner Zuordnungsfehler - bitte rufen Sie nach Verlassen diesen Dialog erneut auf.", "Interner Zuordnungsfehler", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //Sicherheitsabfrage:
            var dr = MessageBox.Show("Sind Sie sicher, dass Sie die Zuordnung zur Produktiv-Site " + facItem.DisplayName + " aufheben wollen?", "Zuordnung aufheben?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (var cItem in myTaskItem.ConversionItems)
                {
                    if (cItem.HomeElementID == facItem.WorkGroupNumber)
                    {
                        cItem.HomeElementID = -1;
                        cItem.HomeElementName = "";
                        break;
                    }
                }

                RebuildLists();
            }
        }

        public frmLegatroTimeDataConfigDialog()
        {
            InitializeComponent();
        }
    }
}