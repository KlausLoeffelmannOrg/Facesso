using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Interfaces
{
    public partial class KannegiesserSQLProductionDataImportTaskElement
    {
        private void retrieveDataForDate(System.DateTime ProductionDate)
        {
            if (KannegiesserSQLConnectionString == null)
            {
                return;
            }

            //Zieldatentabellenstruktur einrichten
            myCurrFacData = new ProductionDataTable();
            // *** Alte auskommentierte Version (dBase) durch neue SQL ersetzt.
            //'Quelldaten für den Tag abrufen
            //Dim locConnection As New SQLConnection(ConnectionString)
            //Dim locSourceData As New DataTable
            //Using locConnection
            //    Dim locAdapter As New SqlDataAdapter("SELECT * FROM PROTOKOL WHERE DATUM=" & _
            //            ProductionDate.ToString("\#MM\/dd\/yyyy\#") & _
            //            " AND TYP=0 AND ARTNR>0", locConnection)
            //    Dim locIntBack As Integer = locAdapter.Fill(locSourceData)
            //End Using
            //'Daten umschaufeln und dabei neu berechnen
            //For Each locDataRow As DataRow In locSourceData.Rows
            //    Dim locFacRow As ProductionDataRow
            //    locFacRow = myCurrFacData.NewProductionDataRow()
            //    With locFacRow
            //        Dim locStartTime As DateTime = ProductionDate.AddSeconds(CInt(locDataRow("STARTZEIT")))
            //        .StartTime = locStartTime
            //        .EndTime = .StartTime.AddSeconds(CInt(locDataRow("DAUER")))
            //        .ProgramNo = CInt(locDataRow("ARTNR"))
            //        .TotalAmount = CDbl(locDataRow("ZAEHLER"))
            //        Dim locShiftSpan As ShiftTimeSpan = Me.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, locStartTime)
            //        If locShiftSpan IsNot Nothing Then
            //            .Shift = Me.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, locStartTime).ShiftNo
            //        Else
            //            locShiftSpan = Me.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, locStartTime)
            //        End If
            //    End With
            //    myCurrFacData.AddProductionDataRow(locFacRow)
            //Next
            KannegiesserDataContext oc = new KannegiesserDataContext(ConnectionString);
            var sourceDataArticleList = ((
                from artItem in oc.GetArtHist(System.Convert.ToInt32(KannegiesserDeviceID), ProductionDate.Date, ProductionDate.Date.AddDays(1).AddSeconds(-1))
                where artItem.ArticleID > 0
                orderby artItem.StartTime
                select artItem)).ToList();
            foreach (var artItem in sourceDataArticleList)
            {
                ProductionDataRow locFacRow = default(ProductionDataRow);
                locFacRow = myCurrFacData.NewProductionDataRow();
                {
                    var __with0 = locFacRow;
                    __with0.StartTime = artItem.StartTime.Value;
                    __with0.EndTime = artItem.EndTime.Value;
                    __with0.ProgramNo = artItem.ArticleID;
                    __with0.TotalAmount = artItem.Counter.Value;
                    ShiftTimeSpan locShiftSpan = this.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, __with0.StartTime);
                    if (locShiftSpan != null)
                    {
                        __with0.Shift = this.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, __with0.StartTime).ShiftNo;
                    }
                    else
                    {
                        locShiftSpan = this.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, __with0.StartTime);
                    }
                }

                myCurrFacData.AddProductionDataRow(locFacRow);
            }
        }
    }
}