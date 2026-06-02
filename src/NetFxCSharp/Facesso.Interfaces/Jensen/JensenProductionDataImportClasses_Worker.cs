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
    public partial class JensenProductionDataImportTaskElement
    {
        private void retrieveDataForDate(System.DateTime ProductionDate)
        {
            if (JensenSQLConnectionString == null)
            {
                return;
            }

            //Quelldaten für den Tag abrufen
            SqlConnection locConnection = new SqlConnection(JensenSQLConnectionString);
            DataTable locSourceData = new DataTable();
            using (locConnection)
            {
                SqlDataAdapter locAdapter = new SqlDataAdapter("SELECT * FROM [LogData] WHERE " + "(TargetId='" + this.JensenDeviceID + "') AND" + "([TimeStamp] >= CONVERT(DATETIME,'" + ProductionDate.Date.ToString("MM\\-dd\\-yyyy") + " 00:00:00', 102) AND [TimeStamp] <= CONVERT(DATETIME,'" + ProductionDate.ToString("MM\\-dd\\-yyyy") + " 23:59:59', 102)) AND " + "(([Mode]=1 AND [ValueID]=1) OR [Mode]=6)" + " ORDER BY [TargetID],[LineNo],[Mode]", locConnection);
                locAdapter.SelectCommand.CommandTimeout = 120;
                int locIntBack = locAdapter.Fill(locSourceData);
            }

            //Zieldatentabellenstruktur einrichten
            myCurrFacData = new ProductionDataTable();
            //Aktuelle Programmnr.
            int locCurrPrgNo = default(int);
            //Daten umschaufeln und dabei neu berechnen
            string exCollection = "";
            int exCount = default(int);
            foreach (DataRow locDataRow in locSourceData.Rows)
            {
                ProductionDataRow locFacRow = null;
                try
                {
                    //'Ist es ein "Programm-Umstell-Datensatz"?
                    if (System.Convert.ToInt32(locDataRow["Mode"]) == 1 & System.Convert.ToInt32(locDataRow["ValueID"]) == 1)
                    {
                        //Ja, neue Programmnr. für die nächsten Datensätze
                        locCurrPrgNo = System.Convert.ToInt32(locDataRow["Value"]);
                        //und nächster Datensatz
                        continue;
                    }

                    //Ist es ein Mengen-Datensatz?
                    if (System.Convert.ToInt32(locDataRow["Mode"]) == 6 & System.Convert.ToInt32(locDataRow["ValueID"]) != 9 & locCurrPrgNo > 0)
                    {
                        locFacRow = myCurrFacData.NewProductionDataRow();
                        {
                            var __with0 = locFacRow;
                            __with0.StartTime = System.Convert.ToDateTime(locDataRow["TimeStamp"]);
                            __with0.EndTime = __with0.StartTime.AddSeconds(1);
                            __with0.ProgramNo = locCurrPrgNo;
                            __with0.TotalAmount = System.Convert.ToDouble(locDataRow["Value"]);
                            __with0.Shift = this.ForWorkgroup.TimeSettingDetails.FindShiftForStartTime(ProductionDate, __with0.StartTime).ShiftNo;
                        }

                        myCurrFacData.AddProductionDataRow(locFacRow);
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        exCollection += "Ausnahme Nr.:" + exCount + System.Environment.NewLine;
                        exCollection += "Ausnahmetext:" + ex.Message + System.Environment.NewLine;
                        if (locFacRow == null)
                        {
                            exCollection += "<FacRow> is nothing for TimeStap/Data: " + locDataRow["TimeStamp"].ToString() + "/" + locDataRow["Value"].ToString() + System.Environment.NewLine;
                        }
                        else
                        {
                            {
                                var __with1 = locFacRow;
                                exCollection += "StartTime/EndTime/ProgramNo/TotalAmount/Shift=" + __with1.StartTime + "/" + __with1.EndTime + "/" + __with1.ProgramNo + "/" + __with1.TotalAmount + "/" + __with1.Shift + System.Environment.NewLine;
                            }

                            exCollection += System.Environment.NewLine + System.Environment.NewLine;
                        }
                    }
                    catch (Exception exInner)
                    {
                        exCollection += "!!! WARNUNG - In der Ausnahme ist eine weitere Ausnahme aufgetreten !!!";
                        exCollection += System.Environment.NewLine + System.Environment.NewLine;
                    }
                }
            }

            if (exCollection != "")
            {
                try
                {
                    (new Microsoft.VisualBasic.Devices.Computer()).FileSystem.WriteAllText((new Microsoft.VisualBasic.Devices.Computer()).FileSystem.SpecialDirectories.MyDocuments + "\\" + DateTime.Now.ToString("yymmdd-hhMMss") + "FcExPrt.log", exCollection, false);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Beim Versuch, das Ausnahmebehandlungsprotokoll für den Jensen-Import zu schreiben, ist ein Fehler aufgetreten!" + System.Environment.NewLine + System.Environment.NewLine + ex.Message, "IO-Fehler!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                }
                finally
                {
                    try
                    {
                        (new Microsoft.VisualBasic.Devices.Computer()).Clipboard.SetText(exCollection);
                        System.Windows.Forms.MessageBox.Show("Ausnahmen traten beim Jensen-Import-Filter auf; die Texte wurden ins Protokoll und in die Zwischen ablagegeschrieben.", "Fehler beim Import!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Ausnahmen traten beim Jensen-Import-Filter auf; die Ausnahmetexte konnten nicht in die Zwischenablage kopiert werden!", "Fehler beim Import!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}