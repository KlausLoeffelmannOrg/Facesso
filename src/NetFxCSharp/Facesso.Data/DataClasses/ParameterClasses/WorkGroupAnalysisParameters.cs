using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Facesso.Data
{
    [Serializable]
    public class WorkGroupAnalysisParameters
    {
        private DateRangeParameter myDateRange;
        private ShiftParameters myShiftParameters;
        private WorkGroupInfoItems myWorkgroups;
        private WorkgroupAnalysisType myAnalysisType;
        private bool myIncludeSuspended;
        private bool myIncludeWorkload;
        private AnalysisTarget myAnalysisTarget;
        private string myMenuName;
        private string myName;
        private int myMenuIndex;
        private Collection<int> mySelectedWorkgroups;

        public WorkGroupAnalysisParameters() { }

        public DateRangeParameter DateRange
        {
            get { return myDateRange; }
            set { myDateRange = value; }
        }

        public ShiftParameters ShiftParameters
        {
            get { return myShiftParameters; }
            set { myShiftParameters = value; }
        }

        [XmlIgnore]
        public WorkGroupInfoItems WorkGroups
        {
            get { return myWorkgroups; }
            set
            {
                myWorkgroups = value;
                mySelectedWorkgroups = new Collection<int>();
                foreach (WorkGroupInfo locItem in myWorkgroups)
                    mySelectedWorkgroups.Add(locItem.IDWorkGroup);
            }
        }

        public Collection<int> SelectedWorkgroups
        {
            get { return mySelectedWorkgroups; }
            set { mySelectedWorkgroups = value; }
        }

        public WorkgroupAnalysisType AnalysisType
        {
            get { return myAnalysisType; }
            set { myAnalysisType = value; }
        }

        public bool IncludeSuspended
        {
            get { return myIncludeSuspended; }
            set { myIncludeSuspended = value; }
        }

        public bool IncludeWorkLoad
        {
            get { return myIncludeWorkload; }
            set { myIncludeWorkload = value; }
        }

        public AnalysisTarget AnalysisTarget
        {
            get { return myAnalysisTarget; }
            set { myAnalysisTarget = value; }
        }

        public string Name
        {
            get { return myName; }
            set { myName = value; }
        }

        public string MenuName
        {
            get { return myMenuName; }
            set { myMenuName = value; }
        }

        public int MenuIndex
        {
            get { return myMenuIndex; }
            set { myMenuIndex = value; }
        }

        public WorkgroupAnalysisBehaviours WorkgroupAnalysisBehaviour { get; set; }
        public int? WorkgroupAnalysisCount { get; set; }
        public ChartType ChartType { get; set; }
        public bool AutomaticChartDeltaRange { get; set; }
        public int ChartDeltaFromValue { get; set; }
        public int ChartDeltaToValue { get; set; }
        public string ChartTitel { get; set; }

        public override string ToString() => Name;

        public string Description()
        {
            string locString = "Zusammenfassung der Analyseparameter:" + Environment.NewLine + Environment.NewLine;
            switch (AnalysisType)
            {
                case WorkgroupAnalysisType.Batch:
                    locString += "Stapelausdruck."; break;
                case WorkgroupAnalysisType.Detailed:
                    locString += "Detaillierter Ausdruck als Stapel."; break;
                case WorkgroupAnalysisType.WorkGroupListShiftwiseWorkLoad:
                    locString += "Linienanalyse."; break;
                case WorkgroupAnalysisType.WorkGroupListShiftCondensed:
                    locString += "Liste der ausgewählten Arbeitsgruppen mit einem Element pro Tag. Die Daten der angegebenen Daten werden verdichtet."; break;
                case WorkgroupAnalysisType.WorkGroupListShiftwise:
                    locString += "Liste der ausgewählten Arbeitsgruppen, mit einer Einzelaufstellung der Schichten. Die Daten im angegebenen Zeitraum werden Produktiv-Site-weise verdichtet."; break;
                case WorkgroupAnalysisType.WorkGroupListShiftwiseCompressed:
                    locString += "Kompakte Liste der ausgewählten Arbeitsgruppen, mit einer Einzelaufstellung der Schichten. Die Daten im angegebenen Zeitraum werden Produktiv-Site-weise verdichtet."; break;
            }

            locString += Environment.NewLine + Environment.NewLine;
            locString += "Ausgewählter Datumsbereich:" + Environment.NewLine;
            locString += DateRange.ToString() + Environment.NewLine + Environment.NewLine;

            locString += "Einzubeziehende Schichten:" + Environment.NewLine;
            locString += ShiftParameters.ToString();
            return locString;
        }
    }

    [Serializable]
    public class WorkGroupAnalysisParametersCollection : Collection<WorkGroupAnalysisParameters>
    {
        public WorkGroupAnalysisParametersCollection() : base() { }

        public string ToXmlString()
        {
            var locXml = new XmlSerializer(typeof(WorkGroupAnalysisParametersCollection));
            var locSw = new StringWriter();
            locXml.Serialize(locSw, this);
            return locSw.ToString();
        }

        public static WorkGroupAnalysisParametersCollection FromXmlString(string xmlString)
        {
            var locXml = new XmlSerializer(typeof(WorkGroupAnalysisParametersCollection));
            var locSr = new StringReader(xmlString);
            return (WorkGroupAnalysisParametersCollection)locXml.Deserialize(locSr);
        }

        public static WorkGroupAnalysisParametersCollection FromFile(FileInfo filename)
        {
            try
            {
                if (!filename.Directory.Exists)
                    filename.Directory.Create();
                if (!filename.Exists)
                    return null;
                using (var locSr = new StreamReader(filename.FullName))
                {
                    string locString = locSr.ReadToEnd();
                    locSr.Close();
                    return FromXmlString(locString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Die Analysen-Definitionsdatei '" + filename.Name + "' konnte nicht gelesen werden:" + Environment.NewLine + Environment.NewLine +
                    ex.Message, "Fehler beim Lesen der Datei!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public void ToFile(FileInfo filename)
        {
            try
            {
                if (!filename.Directory.Exists)
                    filename.Directory.Create();
                using (var locSw = new StreamWriter(filename.FullName))
                {
                    locSw.Write(ToXmlString());
                    locSw.Flush();
                    locSw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Die Analysen-Definitionsdatei '" + filename.Name + "' konnte nicht geschrieben werden:" + Environment.NewLine + Environment.NewLine +
                    ex.Message, "Fehler beim Schreiben der Analyse-Settings!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }

    public enum WorkgroupAnalysisBehaviours
    {
        Best,
        Worst,
        Selected
    }

    public enum ChartType
    {
        Chart2DLine,
        Chart3DLine
    }

    public enum WorkgroupAnalysisType
    {
        Detailed,
        Batch,
        WorkGroupListShiftCondensed,
        WorkGroupListShiftwise,
        WorkGroupListShiftwiseCompressed,
        WorkGroupListShiftwiseWorkLoad
    }

    public enum AnalysisTarget
    {
        DirectlyToPrinter,
        PreviewBeforePrint,
        CSVExport,
        Chart
    }
}
