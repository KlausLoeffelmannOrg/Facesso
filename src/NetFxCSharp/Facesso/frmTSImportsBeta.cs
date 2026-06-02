using ActiveDev;
using Facesso.Data;
using Facesso.Functions;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso
{
    public partial class frmTSImport
    {
        private string myOleDBConnString;
        private CostcenterInfoItems myCcic = new CostcenterInfoItems();
        private WageGroupInfoCollection myWgic = new WageGroupInfoCollection();
        private System.DateTime myTransformFrom;
        private bool blnGenerateRandom = true;
        private string myProtocol;
        private bool myCancel;
        private bool mySkipNextOp;
        private void btnOpenFile_Click(System.Object sender, System.EventArgs e)
        {
            OpenFileDialog locOFD = new OpenFileDialog();
            locOFD.Filter = "Access-Datenbanken (*.mdb)|*.mdb|Alle Dateien (*.*)|*.*";
            DialogResult locDR = locOFD.ShowDialog();
            if (locDR == System.Windows.Forms.DialogResult.OK)
            {
                txtAccessPathAndFile.Text = locOFD.FileName;
            }
        }

        private void btnImportNow_Click(System.Object sender, System.EventArgs e)
        {
            int locIDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary;
            string locCostCenterString = "";
            int locBaseCostCenterID = SPAccess.GetInstance().GetCurrentBaseCostCenter(FacessoGeneric.LoginInfo.IDSubsidiary).IDCostCenter;
            myProtocol = "";
            if (chkTransformBaseData.Checked)
            {
                //Löschen der Stammdaten
                lblStatus.Text = "Löschen der vorhandenen Daten. Dieser Vorgang kann eine ganze Weile in Anspruch nehmen...";
                lblStatus.Update();
                try
                {
                    SPAccess.GetInstance().DeleteDataForOleDbImport(locIDSubsidiary);
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Die Operation hatte das Timeout erreicht, der Vorgang wurde aber dennoch erfolgreich abgeschlossen!";
                    lblStatus.Update();
                }
            }

            if (ndbTransformFrom.Value.IsNull)
            {
                myTransformFrom = new System.DateTime(1900, 1, 1);
            }
            else
            {
                myTransformFrom = ndbTransformFrom.TypeSafeValue;
            }

            myOleDBConnString = "Jet OLEDB:Database Password=;";
            myOleDBConnString += "Data Source=" + txtAccessPathAndFile.Text + ";Password=;";
            myOleDBConnString += "Provider=\"Microsoft.Jet.OLEDB.4.0\";";
            myOleDBConnString += "Jet OLEDB:SFP=False;";
            myOleDBConnString += "Mode=Share Deny None;";
            myOleDBConnString += "User ID=Admin;";
            OleDbConnection locOleDBConnection = new OleDbConnection(myOleDBConnString);
            using (locOleDBConnection)
            {
                try
                {
                    locOleDBConnection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beim Öffnen der Access-Datenbank ist ein Fehler aufgetreten. Bitte überprüfen Sie den Pfad und den Dateinamen zur Access-Datenbank.", "Fehler beim Öffnen der Datenbank:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                OleDbCommand locCommand = default(OleDbCommand);
                OleDbDataReader locReader = default(OleDbDataReader);
                WorkGroupInfoItems locWorkGroups = new WorkGroupInfoItems();
                WorkGroupInfo locWorkGroup = default(WorkGroupInfo);
                LabourValueInfo locLabourValue = default(LabourValueInfo);
                LabourValueInfoCollection locLabourValues = default(LabourValueInfoCollection);
                if (chkTransformBaseData.Checked)
                {
                    //Lohngruppen übernehmen
                    locCommand = new OleDbCommand("SELECT [Lohngruppe], [Lohn2] FROM [Lohngruppen]" + "ORDER BY [Lohngruppe]", locOleDBConnection);
                    WageGroupInfo locWageGroup = default(WageGroupInfo);
                    locReader = locCommand.ExecuteReader();
                    while (locReader.Read())
                    {
                        locWageGroup = new WageGroupInfo();
                        {
                            var __with0 = locWageGroup;
                            __with0.CurrencyToken = "€";
                            object locObject = locReader.GetValue(locReader.GetOrdinal("Lohn2"));
                            if (locObject != null & locObject != DBNull.Value)
                            {
                                __with0.HourlyRate = (double)System.Convert.ToDecimal(locObject);
                            }
                            else
                            {
                                __with0.HourlyRate = 0;
                            }

                            __with0.IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary;
                            __with0.IsTemplate = false;
                            __with0.WageGroupToken = locReader.GetInt32(locReader.GetOrdinal("Lohngruppe")).ToString();
                            __with0.WasCurrentTo = new System.DateTime(2199, 12, 31);
                            __with0.IDCurrency = 1;
                        }

                        locWageGroup.IDWageGroup = SPAccess.GetInstance().WageGroups_Add(locWageGroup, FacessoGeneric.LoginInfo.IDUser);
                        myWgic.Add(locWageGroup);
                        lblStatus.Text = "Lohngruppen übernehmen: " + locWageGroup.DisplayName;
                        lblStatus.Update();
                        Application.DoEvents();
                    }

                    //Kostenstellen übernehmen
                    locCommand = new OleDbCommand("SELECT DISTINCT [Kostenstelle] FROM [ArbeitswertStammdaten]" + "ORDER BY [Kostenstelle]", locOleDBConnection);
                    CostcenterInfo locCostCenter = default(CostcenterInfo);
                    int locCurrentCostCenterNo = 1000;
                    locReader = locCommand.ExecuteReader();
                    while (locReader.Read())
                    {
                        locCostCenter = new CostcenterInfo();
                        //Testen, ob Kostenstelle eine Nummer ist
                        int locCostCenterInteger = default(int);
                        if (!(locReader.IsDBNull(locReader.GetOrdinal("Kostenstelle"))))
                        {
                            locCostCenterString = locReader.GetValue(locReader.GetOrdinal("Kostenstelle")).ToString();
                            if (int.TryParse(locCostCenterString, out locCostCenterInteger))
                            {
                                locCurrentCostCenterNo = locCostCenterInteger;
                                locCostCenterString = locCostCenterInteger.ToString() + ": * Name zu ergänzen *";
                            }
                            else
                            {
                                locCurrentCostCenterNo += 10;
                            }

                            {
                                var __with1 = locCostCenter;
                                __with1.BaseValuePrecision = 1;
                                __with1.BaseValueSynonym = "te in h/min";
                                __with1.CostCenterDescription = "Aus anderer Anwendung übernommen/noch zu ergänzen";
                                if (blnGenerateRandom)
                                {
                                    __with1.CostCenterName = RandomData.DistortOrgNames(ADDBNullable.FromObject<string>(locCostCenterString));
                                }
                                else
                                {
                                    __with1.CostCenterName = ADDBNullable.FromObject<string>(locCostCenterString);
                                }

                                __with1.CostCenterNo = locCurrentCostCenterNo;
                                __with1.IDCurrency = 1;
                                __with1.IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary;
                                __with1.IncentiveIndicatorDimension = "%";
                                __with1.IncentiveIndicatorFactor = 1;
                                __with1.IncentiveIndicatorPrecision = 4;
                                __with1.IncentiveIndicatorSynonym = "Zeitgrad";
                                __with1.IncentiveWageSynonym = "Prämienlohn";
                                __with1.UseFixValuedBonus = false;
                                __with1.WasCurrentTo = new System.DateTime(2199, 12, 31);
                            }

                            lblStatus.Text = "Kostenstellen übernehmen: " + locCostCenter.DisplayName;
                            lblStatus.Update();
                            Application.DoEvents();
                            locCostCenter.IDCostCenter = SPAccess.GetInstance().CostCenters_Add(locCostCenter, FacessoGeneric.LoginInfo.IDUser);
                            myCcic.Add(locCostCenter);
                        }
                    }

                    //Mitarbeiter übernehmen
                    locCommand = new OleDbCommand("SELECT * FROM [Mitarbeiter]", locOleDBConnection);
                    EmployeeInfo locEmployee = default(EmployeeInfo);
                    AddressDetailsInfo locAdrDetails = default(AddressDetailsInfo);
                    locReader = locCommand.ExecuteReader();
                    while (locReader.Read())
                    {
                        locEmployee = new EmployeeInfo();
                        {
                            var __with2 = locEmployee;
                            __with2.Comment = ADDBNullable.FromObject<string>(locReader.GetValue(locReader.GetOrdinal("Bemerkung")));
                            __with2.DateOfBirth = ADDBNullable.FromObject<System.DateTime>(locReader.GetValue(locReader.GetOrdinal("Geburtsdatum")));
                            __with2.DateOfJoining = ADDBNullable.FromObject<System.DateTime>(locReader.GetValue(locReader.GetOrdinal("Eintrittsdatum")));
                            if (blnGenerateRandom)
                            {
                                __with2.FirstName = RandomData.FirstName;
                                __with2.LastName = RandomData.LastName;
                            }
                            else
                            {
                                __with2.FirstName = locReader.GetString(locReader.GetOrdinal("Vorname"));
                                __with2.LastName = locReader.GetString(locReader.GetOrdinal("Name"));
                            }

                            __with2.UseFixedWage = locReader.GetBoolean(locReader.GetOrdinal("FreierStundensatzVerwenden"));
                            __with2.FixedWage = ADDBNullable.FromObject<double>(locReader.GetValue(locReader.GetOrdinal("FreierStundensatz")));
                            if (__with2.UseFixedWage & __with2.FixedWage.IsNull)
                            {
                                __with2.UseFixedWage = false;
                            }

                            __with2.IDCostCenter = 0;
                            __with2.IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary;
                            __with2.IsActive = locReader.GetBoolean(locReader.GetOrdinal("Aktiviert"));
                            __with2.IDWageGroup = ADDBNullable.FromObject<int>(GetWageGroupByWageGroupNo(locReader.GetInt32(locReader.GetOrdinal("Lohngruppe"))).IDWageGroup);
                            __with2.IsIncentive = true;
                            __with2.Matchcode = locReader.GetInt32(locReader.GetOrdinal("PersonalNr")).ToString();
                            __with2.PersonnelNumber = locReader.GetInt32(locReader.GetOrdinal("PersonalNr"));
                            __with2.TimeCardNo = ADDBNullable.FromObject<string>(locReader.GetValue(locReader.GetOrdinal("KartenNr")));
                            __with2.WasCurrentTo = new System.DateTime(2199, 12, 31);
                        }

                        locAdrDetails = new AddressDetailsInfo();
                        {
                            var __with3 = locAdrDetails;
                            __with3.City = ADDBNullable.FromObject<string>(locReader.GetValue(locReader.GetOrdinal("Ort")));
                            __with3.CompanyPhone = ADDBNullable.FromObject<string>(locReader.GetValue(locReader.GetOrdinal("TelefonExt")));
                            __with3.Country = "Germany";
                            __with3.CountryCode = "D-";
                            __with3.FirstName = locReader.GetString(locReader.GetOrdinal("Vorname"));
                            __with3.LastName = locReader.GetString(locReader.GetOrdinal("Name"));
                            __with3.PersonnelNo = locReader.GetInt32(locReader.GetOrdinal("PersonalNr"));
                            __with3.PrivateMobile = ADDBNullable.FromObject<string>(locReader.GetValue(locReader.GetOrdinal("Handy")));
                            __with3.PrivatePhone = ADDBNullable.FromObject<string>(locReader.GetValue(locReader.GetOrdinal("PrivatTelefon")));
                            __with3.Street = ADDBNullable.FromObject<string>(locReader.GetValue(locReader.GetOrdinal("Straße")));
                            __with3.Zip = ADDBNullable.FromObject<string>(locReader.GetValue(locReader.GetOrdinal("PLZ")));
                        }

                        lblStatus.Text = "Mitarbeiter übernehmen: " + locEmployee.DisplayName;
                        lblStatus.Update();
                        Application.DoEvents();
                        SPAccess.GetInstance().Employees_Add(locEmployee, FacessoGeneric.LoginInfo.IDUser, locAdrDetails);
                    }

                    //Arbeitswerte übernehmen
                    locCommand = new OleDbCommand("SELECT * FROM [ArbeitswertStammdaten]", locOleDBConnection);
                    CostcenterInfo locCci = default(CostcenterInfo);
                    locReader = locCommand.ExecuteReader();
                    while (locReader.Read())
                    {
                        locLabourValue = new LabourValueInfo();
                        {
                            var __with4 = locLabourValue;
                            try
                            {
                                __with4.Dimension = locReader.GetString(locReader.GetOrdinal("Einheit"));
                                __with4.IDCostCenter = locBaseCostCenterID;
                                //Richtige Kostenstelle zuordnen:
                                if (!(locReader.IsDBNull(locReader.GetOrdinal("Kostenstelle"))))
                                {
                                    locCostCenterString = locReader.GetValue(locReader.GetOrdinal("Kostenstelle")).ToString();
                                    locCci = FindCostCenterByString(locCostCenterString);
                                    if (locCci != null)
                                    {
                                        __with4.IDCostCenter = locCci.IDCostCenter;
                                    }
                                }

                                __with4.IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary;
                                __with4.IsActive = true;
                                if (blnGenerateRandom)
                                {
                                    __with4.LabourValueName = RandomData.DistortOrgNames(ADDBNullable.FromObject<string>(locReader.GetValue(locReader.GetOrdinal("AWBeschreibung"))));
                                    __with4.LabourValueDescription = __with4.LabourValueName;
                                }
                                else
                                {
                                    __with4.LabourValueName = ADDBNullable.FromObject<string>(locReader.GetValue(locReader.GetOrdinal("AWBeschreibung")));
                                    __with4.LabourValueDescription = __with4.LabourValueName;
                                }

                                __with4.LabourValueNumber = locReader.GetInt32(locReader.GetOrdinal("ArbeitswertNr"));
                                __with4.TeHMin = locReader.GetDouble(locReader.GetOrdinal("teMin"));
                                __with4.WasCurrentTo = new System.DateTime(2199, 12, 31);
                            }
                            catch (Exception ex)
                            {
                                mySkipNextOp = true;
                            }
                        }

                        lblStatus.Text = "Arbeitswerte übernehmen: " + locLabourValue.DisplayName;
                        lblStatus.Update();
                        Application.DoEvents();
                        if (!(mySkipNextOp))
                        {
                            SPAccess.GetInstance().LabourValues_Add(locLabourValue, FacessoGeneric.LoginInfo.IDUser);
                        }

                        mySkipNextOp = false;
                    }

                    //Arbeitsgruppen übernehmen
                    locCommand = new OleDbCommand("SELECT * FROM [Arbeitsgruppen]", locOleDBConnection);
                    TimeSettingDetails locCurrentTimeSettingDetails = ((TimeSettingDetails)FacessoGeneric.FacessoGlobalSettings.Settings.GetItem("GlobalTimeSettingDetailsTemplate", new TimeSettingDetails(new System.DateTime(2003, 1, 1, 6, 0, 0), new System.DateTime(2003, 1, 1, 14, 0, 0), new System.DateTime(2003, 1, 1, 22, 0, 0), new System.DateTime(2003, 1, 2, 5, 0, 0), default(ActiveDev.ADDBNullable<System.DateTime>), default(ActiveDev.ADDBNullable<System.DateTime>), 30)));
                    locReader = locCommand.ExecuteReader();
                    while (locReader.Read())
                    {
                        locWorkGroup = new WorkGroupInfo();
                        {
                            var __with5 = locWorkGroup;
                            __with5.IDCostCenter = locBaseCostCenterID;
                            __with5.IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary;
                            __with5.IsActive = locReader.GetBoolean(locReader.GetOrdinal("Aktiviert"));
                            __with5.IsCurrent = true;
                            __with5.IsPeaceWork = false;
                            __with5.OrdinalNo = locReader.GetInt32(locReader.GetOrdinal("OrdinalNr"));
                            __with5.TimeSettingDetails = locCurrentTimeSettingDetails;
                            __with5.WasCurrentFrom = System.DateTime.Now;
                            __with5.WasCurrentTo = new System.DateTime(2199, 12, 31);
                            if (!(locReader.IsDBNull(locReader.GetOrdinal("Beschreibung"))))
                            {
                                __with5.WorkGroupDescription = ADDBNullable.FromObject<string>(locReader.GetValue(locReader.GetOrdinal("Beschreibung")));
                            }
                            else
                            {
                                __with5.WorkGroupDescription = default(ActiveDev.ADDBNullable<string>);
                            }

                            if (blnGenerateRandom)
                            {
                                __with5.WorkGroupName = RandomData.DistortOrgNames(locReader.GetString(locReader.GetOrdinal("ArbeitsgruppenName")));
                            }
                            else
                            {
                                __with5.WorkGroupName = locReader.GetString(locReader.GetOrdinal("ArbeitsgruppenName"));
                            }

                            __with5.WorkGroupNumber = locReader.GetInt32(locReader.GetOrdinal("ArbeitsgruppenNr"));
                        }

                        lblStatus.Text = "Arbeitsgruppen übernehmen: " + locWorkGroup.DisplayName;
                        lblStatus.Update();
                        Application.DoEvents();
                        locWorkGroup.IDWorkGroup = SPAccess.GetInstance().WorkGroups_Add(locWorkGroup, FacessoGeneric.LoginInfo.IDUser);
                        locWorkGroups.Add(locWorkGroup);
                    }

                    //Zuordnungen zwischen Arbeitsgruppen und Arbeitswerten herstellen
                    foreach (var _vbForEach_0 in locWorkGroups)
                    {
                        locWorkGroup = _vbForEach_0;
                        {
                            locCommand = new OleDbCommand("SELECT Arbeitswertnr FROM AGrpArbeitswertDef WHERE ArbeitsgruppenNr=" + locWorkGroup.WorkGroupNumber + " ORDER BY OrdinalNr", locOleDBConnection);
                            locReader = locCommand.ExecuteReader();
                            locLabourValues = new LabourValueInfoCollection();
                            while (locReader.Read())
                            {
                                {
                                    var __with6 = locWorkGroup;
                                    int locWorkGroupNumber = locReader.GetInt32(locReader.GetOrdinal("Arbeitswertnr"));
                                    locLabourValue = SPAccess.GetInstance().GetLabourValueByNumber(FacessoGeneric.LoginInfo.IDSubsidiary, locWorkGroupNumber);
                                    try
                                    {
                                        locLabourValues.Add(locLabourValue);
                                    }
                                    catch (Exception ex)
                                    {
                                        myProtocol += "Datenbankinkonsistenz: In Produktiv-Site " + locWorkGroup.ListItemText + " ist der Arbeitswert " + locLabourValue.ListItemText + " doppelt zugewiesen!";
                                    }
                                }
                            }

                            if (locLabourValues.Count > 0)
                            {
                                SPAccess.GetInstance().AssignLabourValuesToWorkGroup(FacessoGeneric.LoginInfo.IDSubsidiary, locWorkGroup.IDWorkGroup, locLabourValues);
                            }

                            lblStatus.Text = "Arbeitsgruppenzuordnung vornehmen für: " + locWorkGroup.DisplayName;
                            lblStatus.Update();
                            Application.DoEvents();
                        }
                    }
                }

                if (chkTransformProductionData.Checked)
                {
                    //Mengendaten übernehmen
                    locCommand = new OleDbCommand("SELECT ArbeitsgruppenNr, Tagesdatum, Schicht, ArbeitswertNr, Menge FROM [AgrpMengenerfassung] " + "WHERE Tagesdatum>=" + myTransformFrom.ToString("\\#MM\\/dd\\/yyyy\\#") + " " + "ORDER BY Tagesdatum, Schicht, ArbeitsgruppenNr", locOleDBConnection);
                    locReader = locCommand.ExecuteReader();
                    bool locFirst = false;
                    ProductionData locPd = null;
                    byte locShift = default(byte);
                    System.DateTime locProductionDate = default(System.DateTime);
                    int locCurrentOrdinalNo = default(int);
                    locLabourValues = SPAccess.GetInstance().GetLabourValueInfoCollection();
                    while (locReader.Read())
                    {
                        locShift = System.Convert.ToByte(locReader.GetInt32(locReader.GetOrdinal("Schicht")));
                        locProductionDate = locReader.GetDateTime(locReader.GetOrdinal("Tagesdatum")).AddMonths(adinMonthToAdd.TypeSafeValue);
                        locWorkGroup = locWorkGroups.GetByWorkGroupNumber(locReader.GetInt32(locReader.GetOrdinal("ArbeitsgruppenNr")));
                        if (!(locFirst))
                        {
                            locPd = new ProductionData();
                            locPd.ProductionDate = locProductionDate;
                            locPd.Shift = locShift;
                            locPd.WorkGroup = locWorkGroup;
                            locPd.Clear();
                            lblStatus.Text = "Mengendaten übernehmen: " + locProductionDate.ToShortDateString() + "; S:" + locShift + " - " + locPd.WorkGroup.ListItemText;
                            lblStatus.Update();
                            locCurrentOrdinalNo = 1;
                            locFirst = true;
                        }
                        else
                        {
                            if (locPd.ProductionDate != locProductionDate | locPd.Shift != locShift | locPd.WorkGroup.IDWorkGroup != locWorkGroup.IDWorkGroup)
                            {
                                locPd.SaveToDatabase(FacessoGeneric.LoginInfo.IDUser, false);
                                lblStatus.Text = "Mengendaten übernehmen: " + locProductionDate.ToShortDateString() + "; S:" + locShift + " - " + locWorkGroup.ListItemText;
                                lblStatus.Update();
                                Application.DoEvents();
                                locPd = new ProductionData();
                                locPd.ProductionDate = locProductionDate;
                                locPd.Shift = locShift;
                                locPd.WorkGroup = locWorkGroup;
                                locPd.Clear();
                                locCurrentOrdinalNo = 1;
                            }
                        }

                        ProductionDataItem locPdi = new ProductionDataItem();
                        int locLabValueNo = default(int);
                        try
                        {
                            locLabValueNo = locReader.GetInt32(locReader.GetOrdinal("ArbeitswertNr"));
                            locPdi.LabourValue = locLabourValues.GetByLabourValueNumber(locLabValueNo);
                        }
                        catch (Exception ex)
                        {
                            myProtocol += "Am " + locProductionDate.ToShortDateString() + " konnte Arbeitswert Nr" + locLabValueNo + " nicht in " + locWorkGroup.ListItemText + " in " + locShift + " zugeordnet werden!";
                            mySkipNextOp = true;
                        }

                        locPdi.Amount = locReader.GetDouble(locReader.GetOrdinal("Menge"));
                        locPdi.ManuallyEdited = true;
                        locPdi.OrdinalNo = locCurrentOrdinalNo;
                        if (!(mySkipNextOp))
                        {
                            locPd.Add(locPdi);
                            locCurrentOrdinalNo += 1;
                        }

                        mySkipNextOp = false;
                    }

                    locPd.SaveToDatabase(FacessoGeneric.LoginInfo.IDUser, false);
                }

                if (chkTransformEmployeeTimes.Checked)
                {
                    //Mitarbeiterzeiten übernehmen
                    locCommand = new OleDbCommand("SELECT * From AgrpZeitenerfassung WHERE PersTagesdatum>=" + myTransformFrom.ToString("\\#MM\\/dd\\/yyyy\\#") + " ORDER BY PersTagesdatum, Schicht, ArbeitsgruppenNr, PersonalNr, Arbeitsbeginn", locOleDBConnection);
                    locReader = locCommand.ExecuteReader();
                    bool locFirst = false;
                    EmployeeTimeLogInfo locTlis = null;
                    byte locShift = default(byte);
                    System.DateTime locProductionDate = default(System.DateTime);
                    EmployeeInfoItems locEmployees = new EmployeeInfoItems("PersonnelNumber");
                    while (locReader.Read())
                    {
                        locShift = System.Convert.ToByte(locReader.GetDouble(locReader.GetOrdinal("Schicht")));
                        locProductionDate = locReader.GetDateTime(locReader.GetOrdinal("PersTagesdatum")).AddMonths(adinMonthToAdd.TypeSafeValue);
                        locWorkGroup = locWorkGroups.GetByWorkGroupNumber(locReader.GetInt32(locReader.GetOrdinal("ArbeitsgruppenNr")));
                        if (!(locFirst))
                        {
                            locTlis = new EmployeeTimeLogInfo();
                            locTlis.ProductionDate = locProductionDate;
                            locTlis.Shift = locShift;
                            locTlis.WorkGroup = locWorkGroup;
                            locTlis.Clear();
                            lblStatus.Text = "Mitarbeiterzeiten übernehmen: " + locProductionDate.ToShortDateString() + "; S:" + locShift + " - " + locTlis.WorkGroup.ListItemText;
                            lblStatus.Update();
                            locFirst = true;
                        }
                        else
                        {
                            if (locTlis.ProductionDate != locProductionDate | locTlis.Shift != locShift | locTlis.WorkGroup.IDWorkGroup != locWorkGroup.IDWorkGroup)
                            {
                                locTlis.SaveToDatabase(FacessoGeneric.LoginInfo.IDUser, false);
                                lblStatus.Text = "Mitarbeiterzeiten übernehmen: " + locProductionDate.ToShortDateString() + "; S:" + locShift + " - " + locWorkGroup.ListItemText;
                                lblStatus.Update();
                                Application.DoEvents();
                                locTlis = new EmployeeTimeLogInfo();
                                locTlis.ProductionDate = locProductionDate;
                                locTlis.Shift = locShift;
                                locTlis.WorkGroup = locWorkGroup;
                                locTlis.Clear();
                            }
                        }

                        EmployeeTimeLogInfoItem locTli = new EmployeeTimeLogInfoItem();
                        locTli.SetShiftTimes(locProductionDate.Add(locReader.GetDateTime(locReader.GetOrdinal("Arbeitsbeginn")).TimeOfDay), locProductionDate.Add(locReader.GetDateTime(locReader.GetOrdinal("ArbeitsEnde")).TimeOfDay), locProductionDate);
                        locTli.Shift = System.Convert.ToByte(locReader.GetDouble(locReader.GetOrdinal("Schicht")));
                        locTli.DownTime = System.Convert.ToInt32(locReader.GetDouble(locReader.GetOrdinal("Ausfallzeit")));
                        locTli.WorkBreak = System.Convert.ToInt32(locReader.GetDouble(locReader.GetOrdinal("Pausenzeiten")));
                        locTli.EditedByIDUser = FacessoGeneric.LoginInfo.IDUser;
                        locTli.EmployeeInfo = locEmployees.GetByPersonnelNumber(locReader.GetInt32(locReader.GetOrdinal("PersonalNr")));
                        locTli.Handicap = System.Convert.ToByte(locReader.GetDouble(locReader.GetOrdinal("Einarbeitungsabschlag")));
                        locTli.IDWorkGroup = locWorkGroups.GetByWorkGroupNumber(locReader.GetInt32(locReader.GetOrdinal("ArbeitsgruppenNr"))).IDWorkGroup;
                        locTli.InsertedByInterface = false;
                        locTli.IsSuspended = false;
                        locTli.LastEdited = System.DateTime.Now;
                        locTli.ManuallyEdited = true;
                        locTlis.Add(locTli);
                    }

                    locTlis.SaveToDatabase(FacessoGeneric.LoginInfo.IDUser, false);
                }
            }

            lblStatus.Text = "Die Übernahme wurde erfolgreich durchgeführt!";
            if (myProtocol != "")
            {
                MessageBox.Show(myProtocol, "Unregelmäßigkeiten bei der Übernahme:");
            }

            lblStatus.Update();
        }

        private CostcenterInfo FindCostCenterByString(string FindString)
        {
            foreach (CostcenterInfo locCci in myCcic)
            {
                if (locCci.CostCenterName.IndexOf(FindString) > -1)
                {
                    return locCci;
                }
            }

            return null;
        }

        private WageGroupInfo GetWageGroupByWageGroupNo(int WageGroupNo)
        {
            foreach (WageGroupInfo locWgi in myWgic)
            {
                if (locWgi.WageGroupToken == WageGroupNo.ToString())
                {
                    return locWgi;
                }
            }

            return null;
        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private class ArbeitsgruppenInfo
        {
            internal int ArbeitsgruppenNummer;
            internal WorkGroupInfo WorkGroupInfo;
            public ArbeitsgruppenInfo(int AGNummer, WorkGroupInfo wgi)
            {
                ArbeitsgruppenNummer = AGNummer;
                WorkGroupInfo = wgi;
            }
        }

        private class ArbeitsgruppenInfos : System.Collections.ObjectModel.KeyedCollection<int, ArbeitsgruppenInfo>
        {
            protected override int GetKeyForItem(ArbeitsgruppenInfo item)
            {
                return item.ArbeitsgruppenNummer;
            }
        }

        private void frmTSImportsBeta_Load(System.Object sender, System.EventArgs e)
        {
            ndbTransformFrom.TypeSafeValue = new System.DateTime(2005, 3, 1);
        }

        private void chkGenerateRandomData_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            adinMonthToAdd.Enabled = chkGenerateRandomData.Checked;
        }

        public frmTSImport()
        {
            this.Load += frmTSImportsBeta_Load;
            InitializeComponent();
        }
    }

    public class RandomData
    {
        private static Random myRandom;
        private static string[] myLastnames;
        private static string[] myFirstnames;
        private static string[] myCities;
        static RandomData()
        {
            myRandom = new Random(System.DateTime.Now.Millisecond);
            myLastnames = new string[]
            {
                "Heckhuis",
                "Löffelmann",
                "Thiemann",
                "Müller",
                "Meier",
                "Tiemann",
                "Sonntag",
                "Ademmer",
                "Westermann",
                "Vüllers",
                "Hollmann",
                "Vielstedde",
                "Weigel",
                "Weichel",
                "Weichelt",
                "Hoffmann",
                "Rode",
                "Trouw",
                "Schindler",
                "Neumann",
                "Jungemann",
                "Hörstmann",
                "Tinoco",
                "Albrecht",
                "Langenbach",
                "Braun",
                "Plenge",
                "Englisch",
                "Clarke"
            };
            myFirstnames = new string[]
            {
                "Jürgen",
                "Gabriele",
                "Uwe",
                "Katrin",
                "Hans",
                "Rainer",
                "Christian",
                "Uta",
                "Michaela",
                "Franz",
                "Anne",
                "Anja",
                "Theo",
                "Momo",
                "Katrin",
                "Guido",
                "Barbara",
                "Bernhard",
                "Margarete",
                "Alfred",
                "Melanie",
                "Britta",
                "José",
                "Thomas",
                "Daja",
                "Klaus",
                "Axel",
                "Lothar",
                "Gareth"
            };
            myCities = new string[]
            {
                "Wuppertal",
                "Dortmund",
                "Lippstadt",
                "Soest",
                "Liebenburg",
                "Hildesheim",
                "München",
                "Berlin",
                "Rheda",
                "Bielefeld",
                "Braunschweig",
                "Unterschleißheim",
                "Wiesbaden",
                "Straubing",
                "Bad Waldliesborn",
                "Lippetal",
                "Stirpe",
                "Erwitte"
            };
        }

        public static string FirstName
        {
            get
            {
                return myFirstnames[myRandom.Next(myFirstnames.Length - 1)];
            }
        }

        public static string LastName
        {
            get
            {
                return myLastnames[myRandom.Next(myLastnames.Length - 1)];
            }
        }

        public static string City
        {
            get
            {
                return myCities[myRandom.Next(myCities.Length - 1)];
            }
        }

        public static string DistortOrgNames(string Text)
        {
            Text = Text.Replace("Jumbo", "3");
            Text = Text.Replace("Tommy", "2");
            Text = Text.Replace("Thommy", "2");
            Text = Text.Replace("Berta", "1");
            Text = Text.Replace("Bärenbach", "Wünnenberg");
            Text = Text.Replace("Hahn", "Lippstadt");
            Text = Text.Replace("Senking", "Kannegiesser");
            return Text;
        }
    }
}