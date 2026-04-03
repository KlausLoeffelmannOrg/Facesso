Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports ActiveDev
Imports Facesso.Data
Imports Facesso.Functions

Public Class frmTSImport

    Private myOleDBConnString As String
    Private myCcic As New CostcenterInfoItems
    Private myWgic As New WageGroupInfoCollection
    Private myTransformFrom As Date
    Private blnGenerateRandom As Boolean = True
    Private myProtocol As String
    Private myCancel As Boolean
    Private mySkipNextOp As Boolean

    Private Sub btnOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenFile.Click
        Dim locOFD As New OpenFileDialog
        locOFD.Filter = "Access-Datenbanken (*.mdb)|*.mdb|Alle Dateien (*.*)|*.*"
        Dim locDR As DialogResult = locOFD.ShowDialog()
        If locDR = Windows.Forms.DialogResult.OK Then
            txtAccessPathAndFile.Text = locOFD.FileName
        End If
    End Sub

    Private Sub btnImportNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportNow.Click

        Dim locIDSubsidiary As Integer = FacessoGeneric.LoginInfo.IDSubsidiary
        Dim locCostCenterString As String = ""
        Dim locBaseCostCenterID As Integer = SPAccess.GetInstance.GetCurrentBaseCostCenter(FacessoGeneric.LoginInfo.IDSubsidiary).IDCostCenter

        myProtocol = ""

        If chkTransformBaseData.Checked Then
            'Löschen der Stammdaten
            lblStatus.Text = "Löschen der vorhandenen Daten. Dieser Vorgang kann eine ganze Weile in Anspruch nehmen..."
            lblStatus.Update()
            Try
                SPAccess.GetInstance.DeleteDataForOleDbImport(locIDSubsidiary)
            Catch ex As Exception
                lblStatus.Text = "Die Operation hatte das Timeout erreicht, der Vorgang wurde aber dennoch erfolgreich abgeschlossen!"
                lblStatus.Update()
            End Try
        End If

        If ndbTransformFrom.Value.IsNull Then
            myTransformFrom = #1/1/1900#
        Else
            myTransformFrom = ndbTransformFrom.TypeSafeValue
        End If

        myOleDBConnString = "Jet OLEDB:Database Password=;"
        myOleDBConnString += "Data Source=" + txtAccessPathAndFile.Text + ";Password=;"
        myOleDBConnString += "Provider=""Microsoft.Jet.OLEDB.4.0"";"
        myOleDBConnString += "Jet OLEDB:SFP=False;"
        myOleDBConnString += "Mode=Share Deny None;"
        myOleDBConnString += "User ID=Admin;"

        Dim locOleDBConnection As New OleDbConnection(myOleDBConnString)
        Using locOleDBConnection
            Try
                locOleDBConnection.Open()
            Catch ex As Exception
                MessageBox.Show("Beim Öffnen der Access-Datenbank ist ein Fehler aufgetreten. Bitte überprüfen Sie den Pfad und den Dateinamen zur Access-Datenbank.", _
                                "Fehler beim Öffnen der Datenbank:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End Try

            Dim locCommand As OleDbCommand
            Dim locReader As OleDbDataReader
            Dim locWorkGroups As New WorkGroupInfoItems
            Dim locWorkGroup As WorkGroupInfo
            Dim locLabourValue As LabourValueInfo
            Dim locLabourValues As LabourValueInfoCollection

            If chkTransformBaseData.Checked Then
                'Lohngruppen übernehmen
                locCommand = New OleDbCommand("SELECT [Lohngruppe], [Lohn2] FROM [Lohngruppen]" & _
                                       "ORDER BY [Lohngruppe]", locOleDBConnection)
                Dim locWageGroup As WageGroupInfo
                locReader = locCommand.ExecuteReader()
                Do While locReader.Read
                    locWageGroup = New WageGroupInfo()
                    With locWageGroup
                        .CurrencyToken = "€"
                        Dim locObject As Object = locReader.GetValue(locReader.GetOrdinal("Lohn2"))
                        If locObject IsNot Nothing And locObject IsNot DBNull.Value Then
                            .HourlyRate = CDec(locObject)
                        Else
                            .HourlyRate = 0
                        End If
                        .IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary
                        .IsTemplate = False
                        .WageGroupToken = locReader.GetInt32(locReader.GetOrdinal("Lohngruppe")).ToString
                        .WasCurrentTo = #12/31/2199#
                        .IDCurrency = 1
                    End With
                    locWageGroup.IDWageGroup = SPAccess.GetInstance.WageGroups_Add(locWageGroup, _
                            FacessoGeneric.LoginInfo.IDUser)
                    myWgic.Add(locWageGroup)
                    lblStatus.Text = "Lohngruppen übernehmen: " + locWageGroup.DisplayName
                    lblStatus.Update()
                    Application.DoEvents()
                Loop

                'Kostenstellen übernehmen
                locCommand = New OleDbCommand("SELECT DISTINCT [Kostenstelle] FROM [ArbeitswertStammdaten]" & _
                                                   "ORDER BY [Kostenstelle]", locOleDBConnection)
                Dim locCostCenter As CostcenterInfo
                Dim locCurrentCostCenterNo As Integer = 1000
                locReader = locCommand.ExecuteReader()
                Do While locReader.Read
                    locCostCenter = New CostcenterInfo
                    'Testen, ob Kostenstelle eine Nummer ist
                    Dim locCostCenterInteger As Integer
                    If Not locReader.IsDBNull(locReader.GetOrdinal("Kostenstelle")) Then
                        locCostCenterString = locReader.GetValue(locReader.GetOrdinal("Kostenstelle")).ToString
                        If Integer.TryParse(locCostCenterString, locCostCenterInteger) Then
                            locCurrentCostCenterNo = locCostCenterInteger
                            locCostCenterString = locCostCenterInteger.ToString & ": * Name zu ergänzen *"
                        Else
                            locCurrentCostCenterNo += 10
                        End If
                        With locCostCenter
                            .BaseValuePrecision = 1
                            .BaseValueSynonym = "te in h/min"
                            .CostCenterDescription = "Aus anderer Anwendung übernommen/noch zu ergänzen"
                            If blnGenerateRandom Then
                                .CostCenterName = RandomData.DistortOrgNames(ADDBNullable.FromObject(Of String)(locCostCenterString))
                            Else
                                .CostCenterName = ADDBNullable.FromObject(Of String)(locCostCenterString)
                            End If
                            .CostCenterNo = locCurrentCostCenterNo
                            .IDCurrency = 1
                            .IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary
                            .IncentiveIndicatorDimension = "%"
                            .IncentiveIndicatorFactor = 1
                            .IncentiveIndicatorPrecision = 4
                            .IncentiveIndicatorSynonym = "Zeitgrad"
                            .IncentiveWageSynonym = "Prämienlohn"
                            .UseFixValuedBonus = False
                            .WasCurrentTo = #12/31/2199#
                        End With
                        lblStatus.Text = "Kostenstellen übernehmen: " + locCostCenter.DisplayName
                        lblStatus.Update()
                        Application.DoEvents()
                        locCostCenter.IDCostCenter = SPAccess.GetInstance.CostCenters_Add(locCostCenter, _
                                                             FacessoGeneric.LoginInfo.IDUser)
                        myCcic.Add(locCostCenter)
                    End If
                Loop

                'Mitarbeiter übernehmen
                locCommand = New OleDbCommand("SELECT * FROM [Mitarbeiter]", locOleDBConnection)
                Dim locEmployee As EmployeeInfo
                Dim locAdrDetails As AddressDetailsInfo
                locReader = locCommand.ExecuteReader()
                Do While locReader.Read
                    locEmployee = New EmployeeInfo
                    With locEmployee
                        .Comment = ADDBNullable.FromObject(Of String)(locReader.GetValue(locReader.GetOrdinal("Bemerkung")))
                        .DateOfBirth = ADDBNullable.FromObject(Of Date)(locReader.GetValue(locReader.GetOrdinal("Geburtsdatum")))
                        .DateOfJoining = ADDBNullable.FromObject(Of Date)(locReader.GetValue(locReader.GetOrdinal("Eintrittsdatum")))
                        If blnGenerateRandom Then
                            .FirstName = RandomData.FirstName
                            .LastName = RandomData.LastName
                        Else
                            .FirstName = locReader.GetString(locReader.GetOrdinal("Vorname"))
                            .LastName = locReader.GetString(locReader.GetOrdinal("Name"))
                        End If
                        .UseFixedWage = locReader.GetBoolean(locReader.GetOrdinal("FreierStundensatzVerwenden"))
                        .FixedWage = ADDBNullable.FromObject(Of Double)(locReader.GetValue(locReader.GetOrdinal("FreierStundensatz")))
                        If .UseFixedWage And .FixedWage.IsNull Then
                            .UseFixedWage = False
                        End If
                        .IDCostCenter = 0
                        .IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary
                        .IsActive = locReader.GetBoolean(locReader.GetOrdinal("Aktiviert"))
                        .IDWageGroup = ADDBNullable.FromObject(Of Integer)(GetWageGroupByWageGroupNo(locReader.GetInt32(locReader.GetOrdinal("Lohngruppe"))).IDWageGroup)
                        .IsIncentive = True
                        .Matchcode = locReader.GetInt32(locReader.GetOrdinal("PersonalNr")).ToString
                        .PersonnelNumber = locReader.GetInt32(locReader.GetOrdinal("PersonalNr"))
                        .TimeCardNo = ADDBNullable.FromObject(Of String)(locReader.GetValue(locReader.GetOrdinal("KartenNr")))
                        .WasCurrentTo = #12/31/2199#
                    End With
                    locAdrDetails = New AddressDetailsInfo()
                    With locAdrDetails
                        .City = ADDBNullable.FromObject(Of String)(locReader.GetValue(locReader.GetOrdinal("Ort")))
                        .CompanyPhone = ADDBNullable.FromObject(Of String)(locReader.GetValue(locReader.GetOrdinal("TelefonExt")))
                        .Country = "Germany"
                        .CountryCode = "D-"
                        .FirstName = locReader.GetString(locReader.GetOrdinal("Vorname"))
                        .LastName = locReader.GetString(locReader.GetOrdinal("Name"))
                        .PersonnelNo = locReader.GetInt32(locReader.GetOrdinal("PersonalNr"))
                        .PrivateMobile = ADDBNullable.FromObject(Of String)(locReader.GetValue(locReader.GetOrdinal("Handy")))
                        .PrivatePhone = ADDBNullable.FromObject(Of String)(locReader.GetValue(locReader.GetOrdinal("PrivatTelefon")))
                        .Street = ADDBNullable.FromObject(Of String)(locReader.GetValue(locReader.GetOrdinal("Straße")))
                        .Zip = ADDBNullable.FromObject(Of String)(locReader.GetValue(locReader.GetOrdinal("PLZ")))
                    End With
                    lblStatus.Text = "Mitarbeiter übernehmen: " + locEmployee.DisplayName
                    lblStatus.Update()
                    Application.DoEvents()
                    SPAccess.GetInstance.Employees_Add(locEmployee, _
                                FacessoGeneric.LoginInfo.IDUser, _
                                locAdrDetails)
                Loop

                'Arbeitswerte übernehmen
                locCommand = New OleDbCommand("SELECT * FROM [ArbeitswertStammdaten]", locOleDBConnection)
                Dim locCci As CostcenterInfo
                locReader = locCommand.ExecuteReader()
                Do While locReader.Read
                    locLabourValue = New LabourValueInfo
                    With locLabourValue
                        Try
                            .Dimension = locReader.GetString(locReader.GetOrdinal("Einheit"))
                            .IDCostCenter = locBaseCostCenterID
                            'Richtige Kostenstelle zuordnen:
                            If Not locReader.IsDBNull(locReader.GetOrdinal("Kostenstelle")) Then
                                locCostCenterString = locReader.GetValue(locReader.GetOrdinal("Kostenstelle")).ToString
                                locCci = FindCostCenterByString(locCostCenterString)
                                If locCci IsNot Nothing Then
                                    .IDCostCenter = locCci.IDCostCenter
                                End If
                            End If
                            .IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary
                            .IsActive = True
                            If blnGenerateRandom Then
                                .LabourValueName = RandomData.DistortOrgNames(ADDBNullable.FromObject(Of String)(locReader.GetValue(locReader.GetOrdinal("AWBeschreibung"))))
                                .LabourValueDescription = .LabourValueName
                            Else
                                .LabourValueName = ADDBNullable.FromObject(Of String)(locReader.GetValue(locReader.GetOrdinal("AWBeschreibung")))
                                .LabourValueDescription = .LabourValueName
                            End If
                            .LabourValueNumber = locReader.GetInt32(locReader.GetOrdinal("ArbeitswertNr"))
                            .TeHMin = locReader.GetDouble(locReader.GetOrdinal("teMin"))
                            .WasCurrentTo = #12/31/2199#
                        Catch ex As Exception
                            mySkipNextOp = True
                        End Try
                    End With
                    lblStatus.Text = "Arbeitswerte übernehmen: " + locLabourValue.DisplayName
                    lblStatus.Update()
                    Application.DoEvents()
                    If Not mySkipNextOp Then
                        SPAccess.GetInstance.LabourValues_Add(locLabourValue, _
                            FacessoGeneric.LoginInfo.IDUser)
                    End If
                    mySkipNextOp = False
                Loop

                'Arbeitsgruppen übernehmen
                locCommand = New OleDbCommand("SELECT * FROM [Arbeitsgruppen]", locOleDBConnection)
                Dim locCurrentTimeSettingDetails As TimeSettingDetails = _
                    DirectCast( _
                    FacessoGeneric.FacessoGlobalSettings.Settings.GetItem("GlobalTimeSettingDetailsTemplate", _
                    New TimeSettingDetails(#1/1/2003 6:00:00 AM#, #1/1/2003 2:00:00 PM#, _
                                        #1/1/2003 10:00:00 PM#, #1/2/2003 5:00:00 AM#, _
                                        Nothing, Nothing, 30)), _
                        TimeSettingDetails)
                locReader = locCommand.ExecuteReader()
                Do While locReader.Read
                    locWorkGroup = New WorkGroupInfo
                    With locWorkGroup
                        .IDCostCenter = locBaseCostCenterID
                        .IDSubsidiary = FacessoGeneric.LoginInfo.IDSubsidiary
                        .IsActive = locReader.GetBoolean(locReader.GetOrdinal("Aktiviert"))
                        .IsCurrent = True
                        .IsPeaceWork = False
                        .OrdinalNo = locReader.GetInt32(locReader.GetOrdinal("OrdinalNr"))
                        .TimeSettingDetails = locCurrentTimeSettingDetails
                        .WasCurrentFrom = Date.Now
                        .WasCurrentTo = #12/31/2199#
                        If Not locReader.IsDBNull(locReader.GetOrdinal("Beschreibung")) Then
                            .WorkGroupDescription = ADDBNullable.FromObject(Of String)(locReader.GetValue(locReader.GetOrdinal("Beschreibung")))
                        Else
                            .WorkGroupDescription = Nothing
                        End If
                        If blnGenerateRandom Then
                            .WorkGroupName = RandomData.DistortOrgNames(locReader.GetString(locReader.GetOrdinal("ArbeitsgruppenName")))
                        Else
                            .WorkGroupName = locReader.GetString(locReader.GetOrdinal("ArbeitsgruppenName"))
                        End If
                        .WorkGroupNumber = locReader.GetInt32(locReader.GetOrdinal("ArbeitsgruppenNr"))
                    End With
                    lblStatus.Text = "Arbeitsgruppen übernehmen: " + locWorkGroup.DisplayName
                    lblStatus.Update()
                    Application.DoEvents()
                    locWorkGroup.IDWorkGroup = SPAccess.GetInstance.WorkGroups_Add(locWorkGroup, FacessoGeneric.LoginInfo.IDUser)
                    locWorkGroups.Add(locWorkGroup)
                Loop

                'Zuordnungen zwischen Arbeitsgruppen und Arbeitswerten herstellen
                For Each locWorkGroup In locWorkGroups
                    locCommand = New OleDbCommand("SELECT Arbeitswertnr FROM AGrpArbeitswertDef WHERE ArbeitsgruppenNr=" & _
                    locWorkGroup.WorkGroupNumber & " ORDER BY OrdinalNr", locOleDBConnection)
                    locReader = locCommand.ExecuteReader()
                    locLabourValues = New LabourValueInfoCollection()
                    Do While locReader.Read
                        With locWorkGroup
                            Dim locWorkGroupNumber As Integer = locReader.GetInt32(locReader.GetOrdinal("Arbeitswertnr"))
                            locLabourValue = SPAccess.GetInstance.GetLabourValueByNumber( _
                                FacessoGeneric.LoginInfo.IDSubsidiary, locWorkGroupNumber)
                            Try
                                locLabourValues.Add(locLabourValue)
                            Catch ex As Exception
                                myProtocol &= "Datenbankinkonsistenz: In Produktiv-Site " & locWorkGroup.ListItemText & " ist der Arbeitswert " & locLabourValue.ListItemText & " doppelt zugewiesen!"
                            End Try
                        End With
                    Loop
                    If locLabourValues.Count > 0 Then
                        SPAccess.GetInstance.AssignLabourValuesToWorkGroup( _
                            FacessoGeneric.LoginInfo.IDSubsidiary, _
                            locWorkGroup.IDWorkGroup, locLabourValues)
                    End If
                    lblStatus.Text = "Arbeitsgruppenzuordnung vornehmen für: " + locWorkGroup.DisplayName
                    lblStatus.Update()
                    Application.DoEvents()
                Next
            End If

            If chkTransformProductionData.Checked Then
                'Mengendaten übernehmen
                locCommand = New OleDbCommand("SELECT ArbeitsgruppenNr, Tagesdatum, Schicht, ArbeitswertNr, Menge FROM [AgrpMengenerfassung] " & _
                        "WHERE Tagesdatum>=" & myTransformFrom.ToString("\#MM\/dd\/yyyy\#") & " " & _
                        "ORDER BY Tagesdatum, Schicht, ArbeitsgruppenNr", locOleDBConnection)
                locReader = locCommand.ExecuteReader()
                Dim locFirst As Boolean = False
                Dim locPd As ProductionData = Nothing
                Dim locShift As Byte
                Dim locProductionDate As Date
                Dim locCurrentOrdinalNo As Integer
                locLabourValues = SPAccess.GetInstance.LabourValueInfoCollection()

                Do While locReader.Read
                    locShift = CByte(locReader.GetInt32(locReader.GetOrdinal("Schicht")))
                    locProductionDate = locReader.GetDateTime(locReader.GetOrdinal("Tagesdatum")).AddMonths(adinMonthToAdd.TypeSafeValue)
                    locWorkGroup = locWorkGroups.GetByWorkGroupNumber(locReader.GetInt32(locReader.GetOrdinal("ArbeitsgruppenNr")))
                    If Not locFirst Then
                        locPd = New ProductionData()
                        locPd.ProductionDate = locProductionDate
                        locPd.Shift = locShift
                        locPd.WorkGroup = locWorkGroup
                        locPd.Clear()
                        lblStatus.Text = "Mengendaten übernehmen: " + locProductionDate.ToShortDateString + "; S:" & locShift & " - " & locPd.WorkGroup.ListItemText
                        lblStatus.Update()
                        locCurrentOrdinalNo = 1
                        locFirst = True
                    Else
                        If locPd.ProductionDate <> locProductionDate Or _
                           locPd.Shift <> locShift Or _
                           locPd.WorkGroup.IDWorkGroup <> locWorkGroup.IDWorkGroup Then
                            locPd.SaveToDatabase(FacessoGeneric.LoginInfo.IDUser, False)
                            lblStatus.Text = "Mengendaten übernehmen: " + locProductionDate.ToShortDateString + "; S:" & locShift & " - " & locWorkGroup.ListItemText
                            lblStatus.Update()
                            Application.DoEvents()
                            locPd = New ProductionData()
                            locPd.ProductionDate = locProductionDate
                            locPd.Shift = locShift
                            locPd.WorkGroup = locWorkGroup
                            locPd.Clear()
                            locCurrentOrdinalNo = 1
                        End If
                    End If

                    Dim locPdi As New ProductionDataItem
                    Dim locLabValueNo As Integer
                    Try
                        locLabValueNo = locReader.GetInt32(locReader.GetOrdinal("ArbeitswertNr"))
                        locPdi.LabourValue = locLabourValues.GetByLabourValueNumber(locLabValueNo)
                    Catch ex As Exception
                        myProtocol &= "Am " & locProductionDate.ToShortDateString & " konnte Arbeitswert Nr" & locLabValueNo & " nicht in " & locWorkGroup.ListItemText & " in " & locShift & " zugeordnet werden!"
                        mySkipNextOp = True
                    End Try
                    locPdi.Amount = locReader.GetDouble(locReader.GetOrdinal("Menge"))
                    locPdi.ManuallyEdited = True
                    locPdi.OrdinalNo = locCurrentOrdinalNo
                    If Not mySkipNextOp Then
                        locPd.Add(locPdi)
                        locCurrentOrdinalNo += 1
                    End If
                    mySkipNextOp = False
                Loop
                locPd.SaveToDatabase(FacessoGeneric.LoginInfo.IDUser, False)
            End If

            If chkTransformEmployeeTimes.Checked Then
                'Mitarbeiterzeiten übernehmen
                locCommand = New OleDbCommand("SELECT * From AgrpZeitenerfassung WHERE PersTagesdatum>=" & _
                        myTransformFrom.ToString("\#MM\/dd\/yyyy\#") & _
                        " ORDER BY PersTagesdatum, Schicht, ArbeitsgruppenNr, PersonalNr, Arbeitsbeginn", locOleDBConnection)
                locReader = locCommand.ExecuteReader()
                Dim locFirst As Boolean = False
                Dim locTlis As EmployeeTimeLogInfo = Nothing
                Dim locShift As Byte
                Dim locProductionDate As Date
                Dim locEmployees As New EmployeeInfoItems("PersonnelNumber")

                Do While locReader.Read
                    locShift = CByte(locReader.GetDouble(locReader.GetOrdinal("Schicht")))
                    locProductionDate = locReader.GetDateTime(locReader.GetOrdinal("PersTagesdatum")).AddMonths(adinMonthToAdd.TypeSafeValue)
                    locWorkGroup = locWorkGroups.GetByWorkGroupNumber(locReader.GetInt32(locReader.GetOrdinal("ArbeitsgruppenNr")))
                    If Not locFirst Then
                        locTlis = New EmployeeTimeLogInfo()
                        locTlis.ProductionDate = locProductionDate
                        locTlis.Shift = locShift
                        locTlis.WorkGroup = locWorkGroup
                        locTlis.Clear()
                        lblStatus.Text = "Mitarbeiterzeiten übernehmen: " + locProductionDate.ToShortDateString + "; S:" & locShift & " - " & locTlis.WorkGroup.ListItemText
                        lblStatus.Update()
                        locFirst = True
                    Else
                        If locTlis.ProductionDate <> locProductionDate Or _
                           locTlis.Shift <> locShift Or _
                           locTlis.WorkGroup.IDWorkGroup <> locWorkGroup.IDWorkGroup Then
                            locTlis.SaveToDatabase(FacessoGeneric.LoginInfo.IDUser, False)
                            lblStatus.Text = "Mitarbeiterzeiten übernehmen: " + locProductionDate.ToShortDateString + "; S:" & locShift & " - " & locWorkGroup.ListItemText
                            lblStatus.Update()
                            Application.DoEvents()
                            locTlis = New EmployeeTimeLogInfo()
                            locTlis.ProductionDate = locProductionDate
                            locTlis.Shift = locShift
                            locTlis.WorkGroup = locWorkGroup
                            locTlis.Clear()
                        End If
                    End If

                    Dim locTli As New EmployeeTimeLogInfoItem
                    locTli.SetShiftTimes(locProductionDate.Add(locReader.GetDateTime(locReader.GetOrdinal("Arbeitsbeginn")).TimeOfDay), _
                                         locProductionDate.Add(locReader.GetDateTime(locReader.GetOrdinal("ArbeitsEnde")).TimeOfDay), _
                                         locProductionDate)
                    locTli.Shift = CByte(locReader.GetDouble(locReader.GetOrdinal("Schicht")))
                    locTli.DownTime = CInt(locReader.GetDouble(locReader.GetOrdinal("Ausfallzeit")))
                    locTli.WorkBreak = CInt(locReader.GetDouble(locReader.GetOrdinal("Pausenzeiten")))
                    locTli.EditedByIDUser = FacessoGeneric.LoginInfo.IDUser
                    locTli.EmployeeInfo = locEmployees.GetByPersonnelNumber(locReader.GetInt32(locReader.GetOrdinal("PersonalNr")))
                    locTli.Handicap = CByte(locReader.GetDouble(locReader.GetOrdinal("Einarbeitungsabschlag")))
                    locTli.IDWorkGroup = locWorkGroups.GetByWorkGroupNumber(locReader.GetInt32(locReader.GetOrdinal("ArbeitsgruppenNr"))).IDWorkGroup
                    locTli.InsertedByInterface = False
                    locTli.IsSuspended = False
                    locTli.LastEdited = Date.Now
                    locTli.ManuallyEdited = True
                    locTlis.Add(locTli)
                Loop
                locTlis.SaveToDatabase(FacessoGeneric.LoginInfo.IDUser, False)
            End If
        End Using

        lblStatus.Text = "Die Übernahme wurde erfolgreich durchgeführt!"
        If myProtocol <> "" Then
            MessageBox.Show(myProtocol, "Unregelmäßigkeiten bei der Übernahme:")
        End If
        lblStatus.Update()

    End Sub

    Private Function FindCostCenterByString(ByVal FindString As String) As CostcenterInfo
        For Each locCci As CostcenterInfo In myCcic
            If locCci.CostCenterName.IndexOf(FindString) > -1 Then
                Return locCci
            End If
        Next
        Return Nothing
    End Function

    Private Function GetWageGroupByWageGroupNo(ByVal WageGroupNo As Integer) As WageGroupInfo
        For Each locWgi As WageGroupInfo In myWgic
            If locWgi.WageGroupToken = WageGroupNo.ToString Then
                Return locWgi
            End If
        Next
        Return Nothing
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Class ArbeitsgruppenInfo

        Friend ArbeitsgruppenNummer As Integer
        Friend WorkGroupInfo As WorkGroupInfo

        Sub New(ByVal AGNummer As Integer, ByVal wgi As WorkGroupInfo)
            ArbeitsgruppenNummer = AGNummer
            WorkGroupInfo = wgi
        End Sub
    End Class

    Private Class ArbeitsgruppenInfos
        Inherits System.Collections.ObjectModel.KeyedCollection(Of Integer, ArbeitsgruppenInfo)

        Protected Overrides Function GetKeyForItem(ByVal item As ArbeitsgruppenInfo) As Integer
            Return item.ArbeitsgruppenNummer
        End Function
    End Class

    Private Sub frmTSImportsBeta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ndbTransformFrom.TypeSafeValue = #3/1/2005#
    End Sub

    Private Sub chkGenerateRandomData_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGenerateRandomData.CheckedChanged
        adinMonthToAdd.Enabled = chkGenerateRandomData.Checked
    End Sub
End Class

Public Class RandomData

    Private Shared myRandom As Random
    Private Shared myLastnames As String()
    Private Shared myFirstnames As String()
    Private Shared myCities As String()

    Shared Sub New()
        myRandom = New Random(Now.Millisecond)
        myLastnames = New String() {"Heckhuis", "Löffelmann", "Thiemann", "Müller", _
            "Meier", "Tiemann", "Sonntag", "Ademmer", "Westermann", "Vüllers", _
            "Hollmann", "Vielstedde", "Weigel", "Weichel", "Weichelt", "Hoffmann", _
            "Rode", "Trouw", "Schindler", "Neumann", "Jungemann", "Hörstmann", _
            "Tinoco", "Albrecht", "Langenbach", "Braun", "Plenge", "Englisch", _
            "Clarke"}

        myFirstnames = New String() {"Jürgen", "Gabriele", "Uwe", "Katrin", "Hans", _
                    "Rainer", "Christian", "Uta", "Michaela", "Franz", "Anne", "Anja", _
                    "Theo", "Momo", "Katrin", "Guido", "Barbara", "Bernhard", "Margarete", _
                    "Alfred", "Melanie", "Britta", "José", "Thomas", "Daja", "Klaus", "Axel", _
                    "Lothar", "Gareth"}

        myCities = New String() {"Wuppertal", "Dortmund", "Lippstadt", "Soest", _
                    "Liebenburg", "Hildesheim", "München", "Berlin", "Rheda", "Bielefeld", _
                    "Braunschweig", "Unterschleißheim", "Wiesbaden", "Straubing", _
                    "Bad Waldliesborn", "Lippetal", "Stirpe", "Erwitte"}
    End Sub

    Public Shared ReadOnly Property FirstName() As String
        Get
            Return myFirstnames(myRandom.Next(myFirstnames.Length - 1))
        End Get
    End Property

    Public Shared ReadOnly Property LastName() As String
        Get
            Return myLastnames(myRandom.Next(myLastnames.Length - 1))
        End Get
    End Property

    Public Shared ReadOnly Property City() As String
        Get
            Return myCities(myRandom.Next(myCities.Length - 1))
        End Get
    End Property

    Public Shared Function DistortOrgNames(ByVal Text As String) As String
        Text = Text.Replace("Jumbo", "3")
        Text = Text.Replace("Tommy", "2")
        Text = Text.Replace("Thommy", "2")
        Text = Text.Replace("Berta", "1")
        Text = Text.Replace("Bärenbach", "Wünnenberg")
        Text = Text.Replace("Hahn", "Lippstadt")
        Text = Text.Replace("Senking", "Kannegiesser")
        Return Text
    End Function
End Class

