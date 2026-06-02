using ActiveDev;
using Facesso;
using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Facesso.Interfaces
{
    public partial class frmImport
    {
        private static InterfaceClassItems myInterfaces;
        public const string TaskItemsFilename = "FacTaskItems.xml";
        private FacessoTaskItems myTasks;
        private FacessoTaskItems myTasksTemplates;
        private string myResultMessage;
        private bool myCancelImport;
        private WorkGroupInfoItems myWorkgroups;
        private FacessoGeneralOptions myFacessoGeneralOptions;
        public frmImport()
        {
            this.Load += frmImport_Load;
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // Add any initialization after the InitializeComponent() call.
            CreateInterfaceDirectoryOnDemand();
            DeserializeTaskItemsFromFile();
            InitializeTaskList();
            rebuildTaskList();
            myWorkgroups = new WorkGroupInfoItems(true);
            ucWorkGroups.WorkGroupInfoItems = myWorkgroups;
            ToggleWorkGroupItems(true);
            myFacessoGeneralOptions = ((FacessoGeneralOptions)FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoGeneralOptions", new FacessoGeneralOptions(false, false, true, false, 60)));
        }

        private void InitializeTaskList()
        {
            {
                var __with0 = lvwTaskList;
                {
                    var __with1 = __with0.Columns;
                    __with1.Add("", 20, HorizontalAlignment.Left);
                    __with1.Add("Task-Name", -2, HorizontalAlignment.Left);
                    __with1.Add("Import-Typ", -2, HorizontalAlignment.Left);
                }
            }
        }

        private void CreateInterfaceDirectoryOnDemand()
        {
            if (!(InterfaceDirectory().Exists))
            {
                InterfaceDirectory().Create();
            }
        }

        public static InterfaceClassItems Interfaces
        {
            get
            {
                if (myInterfaces == null)
                {
                    myInterfaces = InterfaceClassItems.ThroughReflection();
                }

                return myInterfaces;
            }
        }

        public static DirectoryInfo InterfaceDirectory()
        {
            return new DirectoryInfo(FacessoGeneric.SharedFolder + "\\Interfaces");
        }

        private Type[] GetSerialisationTypes()
        {
            System.Collections.ArrayList locTypes = new System.Collections.ArrayList();
            //Alle vorhandenen Interfaces durchsuchen
            foreach (FacessoInterfaceClassItem locInterfaceItem in Interfaces)
            {
                bool locFound = default(bool);
                foreach (Type locType in locTypes)
                {
                    if (locType == locInterfaceItem.InterfaceType)
                    {
                        locFound = true;
                        break;
                    }
                }

                if (!(locFound))
                {
                    locTypes.Add(locInterfaceItem.InterfaceType);
                }
            }

            return ((Type[])locTypes.ToArray(typeof(Type)));
        }

        private void DeserializeTaskItemsFromFile()
        {
            FileInfo locTaskFile = new FileInfo(InterfaceDirectory().ToString() + "\\" + TaskItemsFilename);
            if (!(locTaskFile.Exists))
            {
                myTasks = new FacessoTaskItems();
            }
            else
            {
                XmlSerializer locXml = new XmlSerializer(typeof(FacessoTaskItems), GetSerialisationTypes());
                StreamReader locSr = new StreamReader(InterfaceDirectory().ToString() + "\\" + TaskItemsFilename);
                myTasks = ((FacessoTaskItems)locXml.Deserialize(locSr));
                locSr.Close();
            }
        }

        public void SerializeTaskItemsToFile()
        {
            XmlSerializer locXml = new XmlSerializer(typeof(FacessoTaskItems), GetSerialisationTypes());
            //Alle aufgetretenen Typen, die serialisiert werden könnten, in ein Type-Array packen
            StreamWriter locSw = new StreamWriter(InterfaceDirectory().ToString() + "\\" + TaskItemsFilename, false);
            locXml.Serialize(locSw, myTasks);
            locSw.Flush();
            locSw.Close();
            locSw.Dispose();
        }

        private void frmImport_Load(System.Object sender, System.EventArgs e)
        {
            this.Show();
            if (Interfaces == null)
            {
                MessageBox.Show("Leider sind keine Schnittstellen-Klassen installiert, so dass Sie diese Funktionalität nicht nutzen können.", "Keine Schnittstellen-Klassen registriert.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Hide();
            }
        }

        private void tsmEditNewImportTask_Click(System.Object sender, System.EventArgs e)
        {
            frmNewImportTask locFrm = new frmNewImportTask();
            IFacessoImportTaskItem locTask = locFrm.GetImportTask();
            if (locTask == null)
            {
                return;
            }

            if (!(locTask.IsGenericInterfaceConfigured))
            {
                if (locTask.ConfigureGenericInterface() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
            }

            DialogResult locDR = locTask.ConfigureImportFilter();
            if (locDR == System.Windows.Forms.DialogResult.Cancel)
            {
                //Ursprungszustand durch letzten Stand von Platte holen wiederherstellen
                DeserializeTaskItemsFromFile();
                rebuildTaskList();
                return;
            }

            //Und dafür hier serialisieren
            locTask.Priority = myTasks.NextPriorityLevel();
            locTask.TaskID = myTasks.NextTaskID();
            myTasks.Add(((FacessoTaskItemBase)locTask));
            SerializeTaskItemsToFile();
            rebuildTaskList();
        }

        private void tsmEditImportTask_Click(System.Object sender, System.EventArgs e)
        {
            if (lvwTaskList.Items == null || lvwTaskList.Items.Count == 0)
            {
                MessageBox.Show("Es sind keine Import-Filter vorhanden, die Sie bearbeiten könnten!", "Keine Import-Filter verfügbar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lvwTaskList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Es ist kein Import-Filter zum Bearbeiten ausgewählt!", "Keine Import-Filter verfügbar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IFacessoImportTaskItem locTask = ((IFacessoImportTaskItem)lvwTaskList.SelectedItems[0].Tag);
            DialogResult locDR = locTask.ConfigureImportFilter();
            if (locDR == System.Windows.Forms.DialogResult.Cancel)
            {
                //Ursprungszustand durch letzten Stand von Platte holen wiederherstellen
                DeserializeTaskItemsFromFile();
                rebuildTaskList();
                return;
            }

            SerializeTaskItemsToFile();
            rebuildTaskList();
        }

        private void tsmEditDeleteImportTask_Click(System.Object sender, System.EventArgs e)
        {
            DialogResult locDr = MessageBox.Show("Sind Sie sicher, dass Sie diesen Import-Task löschen wollen?", "Import-Task löschen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (locDr == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            IFacessoImportTaskItem locTask = ((IFacessoImportTaskItem)lvwTaskList.SelectedItems[0].Tag);
            //Remove funktioniert nicht mit anschließender Serialisierung;
            //daher Tabelle neu aufbauen, damit die TaskIDs lückenlos
            //sind!
            FacessoTaskItems locMyTasks = new FacessoTaskItems();
            int locCount = default(int);
            foreach (FacessoTaskItemBase locItem in myTasks)
            {
                if (locItem != locTask)
                {
                    locItem.TaskID = locCount;
                    locMyTasks.Add(locItem);
                    locCount += 1;
                }
            }

            myTasks = locMyTasks;
            SerializeTaskItemsToFile();
            rebuildTaskList();
        }

        private void rebuildTaskList()
        {
            {
                var __with2 = lvwTaskList;
                __with2.BeginUpdate();
                __with2.Items.Clear();
                foreach (IFacessoImportTaskItem locTask in myTasks)
                {
                    ListViewItem locLvwItem = new ListViewItem("", "CheckBox");
                    locLvwItem.Tag = locTask;
                    locLvwItem.SubItems.Add(locTask.Name);
                    locLvwItem.SubItems.Add(locTask.ImportType.ToString());
                    __with2.Items.Add(locLvwItem);
                }

                __with2.Columns[0].Width = 20;
                __with2.Columns[1].Width = -2;
                __with2.Columns[2].Width = -2;
                __with2.EndUpdate();
            }
        }

        private ShiftCombination SelectedShift
        {
            get
            {
                ShiftCombination locSc = ShiftCombination.None;
                if (chkShift1.Checked)
                {
                    locSc = locSc | ShiftCombination.Shift1;
                }

                if (chkShift2.Checked)
                {
                    locSc = locSc | ShiftCombination.Shift2;
                }

                if (chkShift3.Checked)
                {
                    locSc = locSc | ShiftCombination.Shift3;
                }

                if (chkShift4.Checked)
                {
                    locSc = locSc | ShiftCombination.Shift4;
                }

                return default(ShiftCombination);
            }
        }

        private void btnImportNow_Click(System.Object sender, System.EventArgs e)
        {
            ShiftCombination locSelShift = SelectedShift;
            IImportResultTable mainResultTable = default(IImportResultTable);
            ProductionDataTable locProdData = default(ProductionDataTable);
            int locMaxValue = default(int);
            int locPbCount = default(int);
            locMaxValue = (System.Convert.ToInt32(dtpTo.Value.Date.ToOADate()) - System.Convert.ToInt32(dtpFrom.Value.Date.ToOADate())) + 1;
            locMaxValue *= lvwTaskList.Items.Count;
            pbImportProgress.Value = 0;
            pbImportProgress.Maximum = locMaxValue;
            pbImportProgress.Minimum = 0;
            btnOK.Text = "Abbrechen";
            btnImportNow.Enabled = false;
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            ResultMessage = "Import gestartet am " + System.DateTime.Now.ToLongDateString() + " von User: " + FacessoGeneric.LoginInfo.Username + System.Environment.NewLine + System.Environment.NewLine;
            for (int locDateAsInt = System.Convert.ToInt32(dtpFrom.Value.Date.ToOADate()); locDateAsInt <= System.Convert.ToInt32(dtpTo.Value.Date.ToOADate()); locDateAsInt++)
            {
                foreach (IFacessoImportTaskItem locTask in myTasks)
                {
                    try
                    {
                        locPbCount += 1;
                        pbImportProgress.Value = locPbCount;
                        lblImportStatus.Text = "Übernahme für " + System.DateTime.FromOADate(locDateAsInt).ToShortDateString() + ":" + locTask.Name;
                        Application.DoEvents();
                        if (myCancelImport)
                        {
                            lblImportStatus.Text = "Abbruch durch Benutzer!";
                            Application.DoEvents();
                            myCancelImport = false;
                            btnOK.Text = "OK";
                            btnImportNow.Enabled = true;
                            return;
                        }

                        //Resulttable kann entweder auf Zeit- oder Produktionsdaten zeigen
                        mainResultTable = locTask.GetData(System.DateTime.FromOADate(locDateAsInt), locSelShift);
                        // Die Konvertierung der IDs (beispielsweise Programmnummern in Arbeitswerte oder
                        // Fremd-Personalnummern in Facesso-Personalnummern) vornehmen
                        if (locTask.ImportType == FacessoImportType.WorkGroupData)
                        {
                            if (mainResultTable.Count() > 0)
                            {
                                for (int c = 0; c <= mainResultTable.Count() - 1; c++)
                                {
                                    int locValue = mainResultTable.GetPrimarySourceIdentifier(c);
                                    int locNewValue = default(int);
                                    //Aus der Foreign-ID den Home-ID (ID des Arbeitswertes) ermitteln
                                    locNewValue = locTask.ConversionItems[new IntKey(locValue)].HomeElementID;
                                    if (locNewValue == -1)
                                    {
                                        locNewValue = -locValue;
                                    }

                                    mainResultTable.SetPrimaryDestinationIdentifier(c, locNewValue);
                                }
                            }
                            else
                            {
                                //Keine Elemente zu konvertieren vorhanden in diesem Taskitem,
                                //dann weiter im Text
                                continue;
                            }
                        }
                        else
                        {
                            if (0 == 1)
                            {
                                //TODO: Konvertierung, falls notwendig, aber Personalnummern werden in der Regel in allen Systemen dieselben sein.
                                //Hier ist aufjeden Fall schonmal der Rumpf, um Personal-IDs des einen in die von Facesso zu konvertieren.
                                var timeResultTable = ((ITimeLogImportResultTable)mainResultTable);
                                for (int c = 0; c <= timeResultTable.Count() - 1; c++)
                                {
                                    int locValue = timeResultTable.GetSecondarySourceIdentifier(c);
                                    timeResultTable.SetSecondaryDestinationIdentifier(c, locValue);
                                }
                            }

                            //Und danach ziehen wir die Daten glatt.
                            var locTimeData = ((TimeDataTable)mainResultTable);
                            AlignTimeData(locTimeData, System.DateTime.FromOADate(locDateAsInt));
                            var myhasDiscrepancies = false;
                            //Feststellen, ob Issues vorhanden sind.
                            foreach (TimeDataRow tmpItem in locTimeData)
                            {
                                if (tmpItem.HasDiscrepancies)
                                {
                                    myhasDiscrepancies = true;
                                }
                            }

                            //Die Selektierten Arbeitsgruppen aus der Liste ermitteln
                            WorkGroupInfoItems selectedWorkgroups = new WorkGroupInfoItems();
                            foreach (var item in ucWorkGroups.CheckedWorkGroups)
                            {
                                selectedWorkgroups.Add(item);
                            }

                            //Hier schmeißen wir alle raus, deren Arbeitsgruppen nicht selektiert sind.
                            //Die Zeiten für die Arbeitsgruppen rausschmeißen, die nicht in der UI selektiert sind
                            var dataRows = (
                                from wgItem in selectedWorkgroups
                                join timeItem in locTimeData.TimeDataRows on wgItem.WorkGroupNumber equals timeItem.WorkgroupNo
                                select timeItem);
                            locTimeData = new TimeDataTable();
                            foreach (var item in dataRows)
                            {
                                locTimeData.ImportRow(item);
                            }

                            //Die bearbeiteten Datensätze (selektiert nach Produktiv-Sites, jetzt neue Tabelle!!!) wieder in die mainResult
                            //Tabelle überführen, weil die immer noch die Referenz auf die unbearbeiteten hält.
                            mainResultTable = locTimeData;
                            //Und hier bringen wir für die Ergebnisliste im Bedarfsfall die Überprüfungsansicht
                            if (myFacessoGeneralOptions.ShowTimeLogPriorToImport)
                            {
                                frmTimeLogResultTable issueForm = new frmTimeLogResultTable();
                                var dr = issueForm.ShowDialog(locTimeData, System.DateTime.FromOADate(locDateAsInt));
                                if (dr == System.Windows.Forms.DialogResult.Abort | dr == System.Windows.Forms.DialogResult.Cancel)
                                {
                                    MessageBox.Show("Import von Zeit- und Mengendaten wurde auf Benutzerwunsch abgebrochen", "Abbruch", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    System.Windows.Forms.Cursor.Current = Cursors.Arrow;
                                    btnOK.Text = "OK";
                                    btnImportNow.Enabled = true;
                                    return;
                                }
                            }
                            else if (myFacessoGeneralOptions.ShowIssueListPriorToImport)
                            {
                                if (myhasDiscrepancies)
                                {
                                    TimeDataTable tmpTimeData = new TimeDataTable();
                                    foreach (TimeDataRow tmpItem in locTimeData)
                                    {
                                        if (tmpItem.HasDiscrepancies)
                                        {
                                            var newItem = tmpTimeData.NewTimeDataRow();
                                            newItem.ItemArray = tmpItem.ItemArray;
                                            tmpTimeData.AddTimeDataRow(newItem);
                                        }
                                    }

                                    frmTimeLogResultTable issueForm = new frmTimeLogResultTable();
                                    var dr = issueForm.ShowDialog(tmpTimeData, System.DateTime.FromOADate(locDateAsInt));
                                    if (dr == System.Windows.Forms.DialogResult.Abort | dr == System.Windows.Forms.DialogResult.Cancel)
                                    {
                                        MessageBox.Show("Import von Zeit- und Mengendaten wurde auf Benutzerwunsch abgebrochen", "Abbruch", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        System.Windows.Forms.Cursor.Current = Cursors.Arrow;
                                        btnOK.Text = "OK";
                                        btnImportNow.Enabled = true;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                if (myhasDiscrepancies)
                                {
                                    var dr = MessageBox.Show("Facesso hat noch Ungereimtheiten bei den zu importierenden Daten gefunden, und empfiehlt, die Import Vorschau erst zu sichten." + System.Environment.NewLine + "Möchten Sie sich die Import-Vorschau zunächst anschauen (betroffene Datensätze würde nicht importiert werden)?", "Ungereimtheiten bei Importdaten:", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                                    if (dr == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        frmTimeLogResultTable issueForm = new frmTimeLogResultTable();
                                        var dr2 = issueForm.ShowDialog(locTimeData, System.DateTime.FromOADate(locDateAsInt));
                                        if (dr2 == System.Windows.Forms.DialogResult.Abort | dr2 == System.Windows.Forms.DialogResult.Cancel)
                                        {
                                            MessageBox.Show("Import von Zeit- und Mengendaten wurde auf Benutzerwunsch abgebrochen", "Abbruch", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                            System.Windows.Forms.Cursor.Current = Cursors.Arrow;
                                            btnOK.Text = "OK";
                                            btnImportNow.Enabled = true;
                                            return;
                                        }
                                    }
                                    else if (dr == System.Windows.Forms.DialogResult.Abort | dr == System.Windows.Forms.DialogResult.Cancel)
                                    {
                                        MessageBox.Show("Import von Zeit- und Mengendaten wurde auf Benutzerwunsch abgebrochen", "Abbruch", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        System.Windows.Forms.Cursor.Current = Cursors.Arrow;
                                        btnOK.Text = "OK";
                                        btnImportNow.Enabled = true;
                                        return;
                                    }
                                }
                            }
                        }

                        //Jetzt müssen wir unterscheiden, was wir auswerten wollen
                        //Da aber sowohl Zeit- als auch Produktionsdaten nur
                        //Schichtweise geschrieben werden, müssen wir schauen, wieviele Schichten
                        //berücksichtigt werden sollen.
                        for (byte locShiftCount = 1; locShiftCount <= 4; locShiftCount++)
                        {
                            int locShift = 1 << (locShiftCount - 1);
                            //Nur die Schichten übernehmen, die der Anwender für die Übernahme angewählt hatte
                            if ((locShift & System.Convert.ToInt32(locSelShift)) == System.Convert.ToInt32(locSelShift))
                            {
                                if (locTask.ImportType == FacessoImportType.WorkGroupData)
                                {
                                    //Hier gibt es Produktionsdaten, die nun für jede Schicht einzeln ausgewertet werden.
                                    locProdData = ((ProductionDataTable)mainResultTable);
                                    ProcessProductionData(locProdData, new CombinedParametersInfo(locTask.ForWorkgroup, System.DateTime.FromOADate(locDateAsInt), locShiftCount));
                                }
                                else
                                {
                                    var locTimeData = ((TimeDataTable)mainResultTable);
                                    ProcessTimeData(locTimeData, System.DateTime.FromOADate(locDateAsInt), locShiftCount);
                                }
                            }
                        }
                    }
                    catch (ApplicationException ex)
                    {
                        MessageBox.Show("Bei der Konvertierung ist folgender Fehler aufgetreten." + System.Environment.NewLine + "Die Konvertierung für die weiteren ImportTasks wird fortzusetzen versucht." + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.StackTrace, "Fehler bei der Übernahme", MessageBoxButtons.OK);
                    }
                }
            }

            System.Windows.Forms.Cursor.Current = Cursors.Arrow;
            btnOK.Text = "OK";
            btnImportNow.Enabled = true;
        }

        private void lvwTaskList_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (lvwTaskList.SelectedIndices.Count == 0)
            {
                ToggleMenus(false);
            }
            else
            {
                ToggleMenus(true);
                //Rausfinden, ob ein Zeitübernahme-Task-Item selektiert ist, und dann die Workgroups togglen:
                if (((IFacessoImportTaskItem)lvwTaskList.SelectedItems[0].Tag).ImportType == FacessoImportType.TimeKeepingData)
                {
                    ToggleWorkgroups(true);
                }
                else
                {
                    ToggleWorkgroups(false);
                }
            }
        }

        private void ToggleWorkgroups(bool OnOff)
        {
            ucWorkGroups.Enabled = OnOff;
            lblWorkgroups.Enabled = OnOff;
            btnSelectAll.Enabled = OnOff;
            btnDeselectAll.Enabled = OnOff;
        }

        private void ToggleMenus(bool OnOff)
        {
            tsmEditDeleteImportTask.Enabled = OnOff;
            tsmEditImportTask.Enabled = OnOff;
        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            if (btnOK.Text != "OK")
            {
                myCancelImport = true;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        public string ResultMessage
        {
            get
            {
                return myResultMessage;
            }

            set
            {
                myResultMessage = value;
            }
        }

        private void dtpTo_ValueChanged(System.Object sender, System.EventArgs e)
        {
            if (dtpTo.Value < dtpFrom.Value)
            {
                dtpFrom.Value = dtpTo.Value;
            }
        }

        private void dtpFrom_ValueChanged(System.Object sender, System.EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                dtpTo.Value = dtpFrom.Value;
            }
        }

        private void tsmQuitDialog_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnSelectAll_Click(System.Object sender, System.EventArgs e)
        {
            ToggleWorkGroupItems(true);
        }

        private void btnDeselectAll_Click(System.Object sender, System.EventArgs e)
        {
            ToggleWorkGroupItems(false);
        }

        private void ToggleWorkGroupItems(bool OnOff)
        {
            foreach (ListViewItem item in ucWorkGroups.Items)
            {
                item.Checked = OnOff;
            }
        }
    }

    public class InterfaceClassItems : System.Collections.ObjectModel.KeyedCollection<long, FacessoInterfaceClassItem>
    {
        public InterfaceClassItems() : base()
        {
        }

        protected override long GetKeyForItem(FacessoInterfaceClassItem item)
        {
            return item.InterfaceID;
        }

        /// <summary>
        /// Verschafft sich alle Import-Filter aus dieser Assembly
        /// </summary>
        /// <returns>InterfaceItems-Collection mit allen Import-Filtern.</returns>
        /// <remarks></remarks>
        public static InterfaceClassItems ThroughReflection()
        {
            long locCount = 0;
            InterfaceClassItems locInterfaces = new InterfaceClassItems();
            //Oben anfangen auf Assembly-Ebene
            Assembly locCurrAssembly = Assembly.GetExecutingAssembly();
            //Zwar nur ein Modul drin - aber wir machen es gescheit.
            foreach (Module locModule in locCurrAssembly.GetModules())
            {
                //Alle Klassen im Modul aufzählen
                foreach (Type locType in locModule.GetTypes())
                {
                    //Alle Attribute der Klasse aufzählen
                    foreach (Attribute locAtt in locType.GetCustomAttributes(true))
                    {
                        //Wenn eine Klasse als Interface gekennzeichnet ist,
                        //dann diese samt dem relevanten Attribut in die Collection aufnehmen.
                        if (locAtt.GetType() == typeof(FacessoImportFilterNameAttribute))
                        {
                            FacessoInterfaceClassItem locInterfaceItem = new FacessoInterfaceClassItem(locType, locCount, ((FacessoImportFilterNameAttribute)locAtt));
                            locInterfaces.Add(locInterfaceItem);
                            locCount += 1;
                            break;
                        }
                    }
                }
            }

            if (locInterfaces.Count == 0)
            {
                return null;
            }
            else
            {
                return locInterfaces;
            }

            return default(InterfaceClassItems);
        }

        private void loadShiftModel()
        {
            FileInfo locFi = new FileInfo(FacessoGeneric.SharedFolder + "\\ShiftModel\\GenericShiftModel.xml");
            if (!(locFi.Directory.Exists))
            {
                locFi.Directory.Create();
            }
        }
    }

    public class FacessoInterfaceClassItem
    {
        private Type myInterfaceType;
        private FacessoImportFilterNameAttribute myInterfaceAttribute;
        private long myInterfaceID;
        public FacessoInterfaceClassItem(Type InterfaceType, long InterfaceID, FacessoImportFilterNameAttribute InterfaceAttribute)
        {
            myInterfaceType = InterfaceType;
            myInterfaceID = InterfaceID;
            myInterfaceAttribute = InterfaceAttribute;
        }

        public Type InterfaceType
        {
            get
            {
                return myInterfaceType;
            }

            set
            {
                myInterfaceType = value;
            }
        }

        public long InterfaceID
        {
            get
            {
                return myInterfaceID;
            }

            set
            {
                myInterfaceID = value;
            }
        }

        public FacessoImportFilterNameAttribute InterfaceAttribute
        {
            get
            {
                return myInterfaceAttribute;
            }
        }

        public override string ToString()
        {
            return myInterfaceAttribute.ImportFiltername;
        }
    }
}