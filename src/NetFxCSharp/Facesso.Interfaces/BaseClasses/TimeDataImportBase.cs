using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Interfaces
{
    public abstract class TimeDataImportBase : FacessoTaskItemBase
    {
        private string myLegatroConnectionString;
        public override System.Windows.Forms.DialogResult ConfigureGenericInterface()
        {
            throw new NotImplementedException("TimeDataImportBase.ConfigureGenericInterface: Nicht implementiert!");
        }

        public override System.Windows.Forms.DialogResult ConfigureImportFilter()
        {
            throw new NotImplementedException("TimeDataImportBase.ConfigureImportFilter: Nicht implementiert!");
        }

        /// <summary>
        /// Erstellt eine generische Konvertierungstabelle,
        /// die in den jeweiligen Ableitungen für die Zuordnungen FremdID-->Produktiv-Site verantwortlich ist.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Diese wird Indirekt über den Delegaten ConversionItemsDelegate aufgerufen.</remarks>
        public virtual FacessoConversionItemsBase AssembleConversionItems()
        {
            FacessoConversionItemsBase locConversionItems = default(FacessoConversionItemsBase);
            //Liste bleibt leer.
            locConversionItems = new FacessoConversionItemsBase();
            return locConversionItems;
        }

        /// <summary>
        /// Ermittelt den Delegaten, der die Funktion zur Verfügung stellt, die die Konvertierungstabelle aufbaut.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public override IFacessoImportTaskItem.GetConversionItemsDelegate ConversionItemsDelegate
        {
            get
            {
                return AssembleConversionItems;
            }
        }

        public override IImportResultTable GetData(System.DateTime ProductionDate, ShiftCombination Shift)
        {
            throw new NotImplementedException("TimeDataImportBase.GetData: Nicht implementiert!");
        }

        public override FacessoImportType ImportType
        {
            get
            {
                return FacessoImportType.TimeKeepingData;
            }
        }
    }
}