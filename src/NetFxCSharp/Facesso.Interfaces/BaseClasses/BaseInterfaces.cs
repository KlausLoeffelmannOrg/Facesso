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
    public interface IFacessoImportTaskItem
    {
        delegate FacessoConversionItemsBase GetConversionItemsDelegate();
        long TaskID { get; set; }

        int Priority { get; set; }

        FacessoInterfaceBrand InterfaceBrand { get; }

        FacessoImportType ImportType { get; }

        WorkGroupInfo ForWorkgroup { get; }

        bool IsGenericInterfaceConfigured { get; }

        int IDWorkgroup { get; set; }

        FacessoConversionItemsBase ConversionItems { get; set; }

        string Name { get; set; }

        DialogResult ConfigureImportFilter();
        DialogResult ConfigureGenericInterface();
        IImportResultTable GetData(System.DateTime ProductionDate, ShiftCombination Shift);
        string ToString();
        GetConversionItemsDelegate ConversionItemsDelegate { get; }
    }

    public interface IFacessoConversionItem
    {
        int AlienElementID { get; set; }

        int HomeElementID { get; set; }

        string HomeElementName { get; set; }

        string Itemname { get; set; }

        string ToString();
    }

    public enum FacessoInterfaceBrand
    {
        BaseClass = 0,
        KannegiesserTimeKeeping = 1,
        KannegiesserProductionData = 2,
        JensenProductionData = 4,
        ZI_Timekeeping = 8,
        InterflexTimeKeeping = 16,
        LegatroTimeKeeping = 32,
        KannegiesserSQLProductionData = 64,
    }

    public enum TimeKeepingEntryType
    {
        TimeKeeping = 0,
        DownTime = -1,
        WorkBreak = -2,
    }

    public enum FacessoImportType
    {
        NotDefined,
        WorkGroupData,
        TimeKeepingData,
    }

    public enum ShiftCombination
    {
        None = 0,
        Shift1 = 1,
        Shift2 = 2,
        Shift3 = 4,
        Shift4 = 8,
        All = 15,
    }

    /// <summary>
    ///     Attribut, mit der man eine TaskItemKlasse kennzeichnet, damit sie als solche erkannt wird.
    /// </summary>
    /// <remarks>
    ///     Zum Beispiel:
    ///     "FacessoImportFilterName("Jensen Produktionsdatenimport", FacessoImportType.WorkGroupData, FacessoInterfaceBrand.KannegiesserProductionData)" _
    /// </remarks>
    public class FacessoImportFilterNameAttribute : Attribute
    {
        private string myImportFiltername;
        private FacessoImportType myImportType;
        private FacessoInterfaceBrand myInterfaceBrand;
        public FacessoImportFilterNameAttribute(string ImportFilterName, FacessoImportType Importtype, FacessoInterfaceBrand Interfacebrand)
        {
            myImportFiltername = ImportFilterName;
            myImportType = Importtype;
            myInterfaceBrand = Interfacebrand;
        }

        public string ImportFiltername
        {
            get
            {
                return myImportFiltername;
            }

            set
            {
                myImportFiltername = value;
            }
        }

        public FacessoImportType ImportType
        {
            get
            {
                return myImportType;
            }

            set
            {
                myImportType = value;
            }
        }

        public FacessoInterfaceBrand InterfaceBrand
        {
            get
            {
                return myInterfaceBrand;
            }

            set
            {
                myInterfaceBrand = value;
            }
        }

        public long DeviceTypeID
        {
            get
            {
                return System.Convert.ToInt64(InterfaceBrand);
            }
        }
    }
}