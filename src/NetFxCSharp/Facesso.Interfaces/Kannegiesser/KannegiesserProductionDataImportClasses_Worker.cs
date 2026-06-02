using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Interfaces
{
    public partial class KannegiesserProductionDataImportTaskElement
    {
        private void retrieveDataForDate(System.DateTime ProductionDate)
        {
            if (PathToDeviceData == null)
            {
                return;
            }

            //Quelldaten für den Tag abrufen
            OleDbConnection locConnection = new OleDbConnection(ConnectionString);
            DataTable locSourceData = new DataTable();
            using (locConnection)
            {
                OleDbDataAdapter locAdapter = new OleDbDataAdapter("SELECT * FROM PROTOKOL WHERE DATUM=" + ProductionDate.ToString("\\#MM\\/dd\\/yyyy\\#") + " AND TYP=0 AND ARTNR>0", locConnection);
                //Falls das eine Exception wirft, dann den BDE (Paradox-Treiber) installieren.
                //Der ist nicht mehr erhältlich, heißt bde.exe ist im Install-Verzeichnis auf
                //dem Server, ca. 5 MByte groß.
                int locIntBack = locAdapter.Fill(locSourceData);
            }

            //Zieldatentabellenstruktur einrichten
            myCurrFacData = new ProductionDataTable();
            //Daten umschaufeln und dabei neu berechnen
            foreach (DataRow locDataRow in locSourceData.Rows)
            {
                ProductionDataRow locFacRow = default(ProductionDataRow);
                locFacRow = myCurrFacData.NewProductionDataRow();
                {
                    var __with0 = locFacRow;
                    DateTime locStartTime = ProductionDate.AddSeconds(System.Convert.ToInt32(locDataRow["STARTZEIT"]));
                    __with0.StartTime = locStartTime;
                    __with0.EndTime = __with0.StartTime.AddSeconds(System.Convert.ToInt32(locDataRow["DAUER"]));
                    __with0.ProgramNo = System.Convert.ToInt32(locDataRow["ARTNR"]);
                    __with0.TotalAmount = System.Convert.ToDouble(locDataRow["ZAEHLER"]);
                    ShiftTimeSpan locShiftSpan = this.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, locStartTime);
                    if (locShiftSpan != null)
                    {
                        __with0.Shift = this.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, locStartTime).ShiftNo;
                    }
                    else
                    {
                        locShiftSpan = this.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, locStartTime);
                    }
                }

                myCurrFacData.AddProductionDataRow(locFacRow);
            }
        }
    }
}