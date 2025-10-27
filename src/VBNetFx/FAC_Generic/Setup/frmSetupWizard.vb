Imports ActiveDev
Imports Facesso
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Security.Cryptography
Imports System.Windows.Forms

Public Class frmSetupWizard

    Private myOleDBConnectionString As String
    Private mySQLConnectionString As String
    Private mySubsidiaryID As Integer = 1
    Private myStepAfterSQLConnectionChoice As Boolean
    Private myDatabaseAlreadySetup As Boolean

    'Wizard-Handler
    Private WithEvents myWizardController As ADWizardController

    Sub New()

        ' Add any initialization after the InitializeComponent() call.

        Try
            If Not RegistryHelper.IsRegistered Then
                RegistryHelper.Register(False)
                RegistryHelper.InstallationDate = DateTime.Now
                RegistryHelper.LastRegisteredDate = RegistryHelper.InstallationDate
                RegistryHelper.ProgramGUID = ADCryptography.GetRandomGUID.ToString
                RegistryHelper.ConnectionString = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Facesso konnte nicht konfiguriert werden - überprüfen Sie, ob Ihr Anmeldekonto ausreichende Rechte besetzt, um Installations- und Konfigurationsaufgaben einer Windows-Software wahrnehmen zu können!",
                            "Konfiguration nicht möglich:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Throw
        End Try

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        RegistryHelper.LastRunDate = DateTime.Now

        If Not RegistryHelper.IsRegistered Then
            RegistryHelper.Register(False)
            RegistryHelper.InstallationDate = DateTime.Now
            RegistryHelper.LastRegisteredDate = RegistryHelper.InstallationDate
            RegistryHelper.ProgramGUID = ADCryptography.GetRandomGUID.ToString
            RegistryHelper.ConnectionString = ""
        Else
            Dim locDR As DialogResult = MessageBox.Show("Sie haben diese Kopie von Facesso bereits freigeschaltet." + vbNewLine + _
                "Wenn Sie die Prozedur abermals durchführen, werden die alten Einstellungen" + vbNewLine + _
                "ungültig, und Sie benötigen obendrein eine neue Seriennummer." + vbNewLine + _
                "Möchten Sie die Freischaltung WIRKLICH neu durchführen?", "Freischaltung neu durchführen?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
            If locDR = Windows.Forms.DialogResult.No Then
                Me.Close()
                'Ausstieg mit Exception, damit ein Neustart sauber erzwungen wird!
                Dim up As New FacessoEndOfSetupException("Abbruch des Setups führte zu Ausnahme (kein kritischer Fehler).", Nothing)
                Throw up
            End If
        End If

        RegistryHelper.LastRegisteredDate = DateTime.Now

        'Vorseriennummer anzeigen
        Dim locGuid As Guid = New Guid(RegistryHelper.ProgramGUID)
        Dim locInstDate As Date = RegistryHelper.InstallationDate
        Dim locPreSerial As String = ADLicenseManager.GetPreSerialNo(locGuid, locInstDate)
        Dim locCount As Integer = 0
        Dim locFormattedPreSerial As String = ""
        For Each locChar As Char In locPreSerial
            If locCount = 5 Then
                locCount = 0
                locFormattedPreSerial += " - "
            End If
            locFormattedPreSerial += locChar.ToString
            locCount += 1
        Next
        lblPreSerialNo.Text = locFormattedPreSerial
        Try
            My.Computer.Clipboard.SetText(locFormattedPreSerial)
        Catch ex As Exception

        End Try

        myWizardController = New ADWizardController(btnBack, btnNext, btnCancel, tcWizard)
        myWizardController.Initialize()
        txtConnectionString.Text = "Server=.\SQLEXPRESS;Database=Facesso;Integrated Security=True; AttachDBFileName=" & My.Application.Info.DirectoryPath & "\Facesso.mdf"

        'Pfade und URLs vorbelegen
        FacessoPathSettings.InstallationFolder = FacessoGeneric.InstallationFolder
        FacessoPathSettings.UpdateFolder = FacessoGeneric.UpdateFolder
        FacessoPathSettings.UpdateUrl = FacessoGeneric.UpdateUrl
        FacessoPathSettings.SharedFolder = FacessoGeneric.SharedFolder
    End Sub

    Private Sub myWizardController_Cancel(ByVal sender As Object, ByVal e As System.EventArgs) Handles myWizardController.Cancel
        Dim locMessage As String = "Sind Sie sicher, dass Sie den Assistenten abbrechen möchten?"
        Dim locdr As DialogResult = MessageBox.Show(locMessage, "Assistenten beenden?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If locdr = Windows.Forms.DialogResult.Yes Then
            'Ausstieg mit Exception, damit ein Neustart sauber erzwungen wird!
            Dim up As New FacessoEndOfSetupException("Abbruch des Setups führte zu Ausnahme (kein kritischer Fehler).", Nothing)
            Throw up
        End If
    End Sub

    Private Sub myWizardController_StepChanged(ByVal sender As Object, ByVal e As ActiveDev.ADWizardStepChangeEventArgs) Handles myWizardController.StepChanged

        If e.WizardStepAction = ADWizardStepAction.NoChange Then
            e.NextStepAllowed = True
            Return
        End If

        If e.WizardStepAction = ADWizardStepAction.NextStep Then
            If e.NewStepNo = 0 Then
                e.NextStepAllowed = True
            ElseIf e.NewStepNo = 1 Then
                e.Cancel = Not Step2_ValidateSerialNo()
                e.NextStepAllowed = True
            ElseIf e.NewStepNo = 2 Then
                e.Cancel = Not Step3_ValidateSQLConnection()
                'Assistent ist beendet, falls die Datenbank bereits eingerichtet war
                If IsDatabaseSetup() Then
                    e.WizardStepAction = ADWizardStepAction.SkipAllRemainingSteps
                    myDatabaseAlreadySetup = True
                    Dim locDR As DialogResult = MessageBox.Show("Die Datenbank ist bereits eingerichtet! Möchten Sie alle Daten dennoch löschen und neu einrichten?", "Datenbank bereits vorhanden!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If locDR = Windows.Forms.DialogResult.Yes Then
                        locDR = MessageBox.Show("Sind Sie sicher? (Alle Daten GEHEN VERLOREN!!!)", "Bestätigung - Datenverlust droht!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                        If locDR = Windows.Forms.DialogResult.Yes Then
                            e.WizardStepAction = ADWizardStepAction.NextStep
                            myDatabaseAlreadySetup = False
                        End If
                    End If
                    e.NextStepAllowed = True
                End If
            ElseIf e.NewStepNo = 3 Then
                e.Cancel = Not Step4_CompanyData()
            ElseIf e.NewStepNo = 4 Then
                e.Cancel = False
                e.NextStepAllowed = True
            ElseIf e.NewStepNo = 5 Then
                e.Cancel = False
                e.NextStepAllowed = True
            ElseIf e.NewStepNo = 6 Then
                e.Cancel = False
                e.NextStepAllowed = True
            End If
        End If
    End Sub

    Private Function Step2_ValidateSerialNo() As Boolean
        'Seriennummer überprüfen
        Dim locSerialString As String = mtbSerialNo.Text
        Dim locLicense As New FacessoLicenseManager(New Guid(RegistryHelper.ProgramGUID),
                                                    RegistryHelper.InstallationDate,
                                                    RegistryHelper.LastRunDate,
                                                    RegistryHelper.LastRegisteredDate,
                                                    locSerialString)

        If locLicense.LicenseInfo.HasFallenBack And (Not locLicense.IsSerialNoValid) Then
            Dim dr As DialogResult = MessageBox.Show("Die angegebene Freischaltnummer passt nicht zu Ihrem System oder Ihrer Facesso-Ausbaustufe." + vbNewLine + _
                            "Sie können ohne Freischaltung zunächst 30 Tage weiterarbeiten, bevor Facesso seinen Dienst einstellt." + vbNewLine + _
                            "Holen Sie die Freischaltung dann zu einem späteren Zeitpunkt nach." + vbNewLine + _
                            "Wenn Sie die Freischaltung JETZT wiederholen möchten, wählen Sie [Wiederholen]," + vbNewLine + _
                            "anderenfalls klicken Sie [Abbrechen], um ohne Freischaltung fortzufahren.", _
                            "Ungültige Seriennummer", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation)
            If dr = Windows.Forms.DialogResult.Retry Then
                Return False
            Else
                Return True
            End If
        End If

        Try
            'Abfrage von IsLicensed Würde in diesem Fall eine Ausnahme auslösen, wenn die Software 
            'nicht ordnungsgemäß lizensiert UND die Probezeit bereits abgelaufen wäre.
            If locLicense.IsLicensed Then
                'Seriennummer in Registry speichern
                RegistryHelper.SerialNumber = locSerialString
                Return True
            End If
        Catch ex As Exception
            Dim dr As DialogResult = MessageBox.Show("Die angegebene Freischaltnummer passt nicht zu Ihrem System oder Ihrer Facesso-Ausbaustufe." + vbNewLine + _
                "Eine Testfrist, mit der Sie 30 Tage zur Probe arbeiten konnten, ist bereits abgelaufen." + vbNewLine + _
                "Wenn Sie die Freischaltung JETZT wiederholen möchten, wählen Sie [Wiederholen], anderenfalls klicken" + vbNewLine + _
                "Sie [Abbrechen], um die Freischaltung abzubrechen, die Sie aber durch Neustart wiederholen können.", _
                "Ungültige Seriennummer", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation)
            If dr = Windows.Forms.DialogResult.Retry Then
                Return False
            Else
                Throw ex
            End If
        End Try
    End Function

    Private Function Step3_ValidateSQLConnection() As Boolean

        Dim locSQLConnection As SqlConnection

        locSQLConnection = New SqlConnection(txtConnectionString.Text)
        
        Using locSQLConnection
            Try
                locSQLConnection.Open()
            Catch ex As Exception
                MessageBox.Show("Beim Öffnen der Datenbankverbindung ist ein Fehler aufgetreten:" & vbNewLine & _
                ex.Message, "Fehler bei der Verbindungsherstellung", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End Try
            RegistryHelper.ConnectionString = txtConnectionString.Text
            mySQLConnectionString = txtConnectionString.Text
        End Using
        Return True
    End Function

    Private Function Step4_CompanyData() As Boolean
        If txtSubsidiaryName.Text = "" Or txtStreet.Text = "" Or txtZip.Text = "" Or _
            txtCity.Text = "" Or txtCountry.Text = "" Or txtCountryCode.Text = "" Or txtPrimaryPhone.Text = "" Then
            MessageBox.Show("Bitte füllen Sie die Felder vollständig aus!", "Fehlende Eingabe(n)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        Return True
    End Function

    Private Sub myWizardController_Finished(ByVal sender As Object, ByVal e As System.EventArgs) Handles myWizardController.Finished

        Dim locString1 As String = "MSI!=Mainboard Creation Computer"
        Dim locString2 As String = "Cuslaka, Alfred"
        Dim locString3 As String = "2cp3b - Fargoroad"

        'Dropping aller Tables, Einrichten von Administrator und Subsidiary
        Dim locCryptedPassword As New ADCryptedPassword(txtPassword.Text)
        locString2 = locString1.Substring(0, 4) + locString2.Substring(0, 4)
        Dim locSystemPassword As New ADCryptedPassword(locString2 + locString3.Substring(0, 5) + "f")
        If Not myDatabaseAlreadySetup Then

            InitializeDatabase(locCryptedPassword.CryptedPassword, locSystemPassword.CryptedPassword, txtSubsidiaryName.Text, txtStreet.Text, _
                             txtZip.Text, txtCity.Text, txtCountryCode.Text, txtCountry.Text, txtPrimaryPhone.Text)

        End If

        'Verzeichnisse und Urls speichern
        FacessoGeneric.InstallationFolder = FacessoPathSettings.InstallationFolder
        FacessoGeneric.UpdateFolder = FacessoPathSettings.UpdateFolder
        FacessoGeneric.UpdateUrl = FacessoPathSettings.UpdateUrl
        FacessoGeneric.SharedFolder = FacessoPathSettings.SharedFolder

        RegistryHelper.Register(True)

        MessageBox.Show("Facesso ist nun für den Einsatz bereit." + vbNewLine + _
                        "Starten Sie das Programm 'Facesso' aus dem Startmenü und der Programmgruppe 'ActiveDevelop'." + vbNewLine + vbNewLine + _
                        "Danke, dass Sie sich für Facesso entschieden haben!", "Konfiguration abgeschlossen", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Ausstieg mit Exception, damit ein Neustart sauber erzwungen wird!
        Dim up As New FacessoEndOfSetupException("Ende des Setups führte zu Ausnahme (kein kritischer Fehler).", Nothing)
        Throw up
    End Sub

    Private Sub txtSS_Name_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubsidiaryName.TextChanged, txtZip.TextChanged, txtStreet.TextChanged, txtCountryCode.TextChanged, txtCountry.TextChanged, txtCity.TextChanged, txtPrimaryPhone.TextChanged
        If txtSubsidiaryName.Text <> "" And txtStreet.Text <> "" And txtZip.Text <> "" And _
            txtCity.Text <> "" And txtCountry.Text <> "" And txtCountryCode.Text <> "" And txtPrimaryPhone.Text <> "" Then
            myWizardController.AllowNextStep()
            Return
        End If
        myWizardController.ForbidNextStep()
    End Sub

    Private Sub txtPasswordRepetition_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPasswordRepetition.TextChanged
        If txtPasswordRepetition.Text = txtPassword.Text And txtPassword.Text.Length > 5 Then
            myWizardController.AllowNextStep()
        Else
            myWizardController.ForbidNextStep()
        End If
    End Sub

    Private Sub dcpSqlServer_DataBasesSelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        myStepAfterSQLConnectionChoice = True
        myWizardController.AllowNextStep()
    End Sub

    Private Sub dcpSqlServer_DataSourcesSelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        myStepAfterSQLConnectionChoice = False
        myWizardController.ForbidNextStep()
    End Sub

    Private Function InitializeDatabase(ByVal CryptedPassword As Byte(), ByVal SystemPassword As Byte(), ByVal SubsidiaryName As String, _
                                        ByVal Street As String, ByVal Zip As String, _
                                        ByVal City As String, ByVal CountryCode As String, _
                                        ByVal Country As String, ByVal PrimaryPhone As String) As Boolean

        Dim locSQLConnection As New SqlConnection(mySQLConnectionString)
        locSQLConnection.Open()

        Using locSQLConnection
            Dim locCmd As New SqlCommand("InitializeDatabase", locSQLConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                .Add("@CryptedAdminPassword", SqlDbType.Binary).Value = CryptedPassword
                .Add("@CryptedSystemPassword", SqlDbType.Binary).Value = SystemPassword
                .Add("@SubsidiaryName", SqlDbType.NVarChar, 100).Value = SubsidiaryName
                .Add("@SubsidiaryStreet", SqlDbType.NVarChar, 100).Value = Street
                .Add("@SubsidiaryZIP", SqlDbType.NVarChar, 10).Value = Zip
                .Add("@SubsidiaryCity", SqlDbType.NVarChar, 100).Value = City
                .Add("@SubsidiaryCountryCode", SqlDbType.NVarChar, 10).Value = CountryCode
                .Add("@SubsidiaryCountry", SqlDbType.NVarChar, 100).Value = Country
                .Add("@SubsidiaryPrimaryPhone", SqlDbType.NVarChar, 100).Value = PrimaryPhone
                .Add("@CostCenterName", SqlDbType.NVarChar, 100).Value = My.Resources.CostCenter_Base_Name
                .Add("@CostCenterDescription", SqlDbType.Text).Value = My.Resources.CostCenter_Base_Description
            End With
            locCmd.CommandTimeout = 10 * 60
            locCmd.ExecuteNonQuery()
            Return True
        End Using

    End Function

    Private Function IsDatabaseSetup() As Boolean

        Dim locConnection As New SqlConnection(mySQLConnectionString)
        locConnection.Open()
        Using locConnection
            Dim locCmd As New SqlCommand("IsDatabaseSetup", locConnection)
            locCmd.CommandType = CommandType.StoredProcedure

            With locCmd.Parameters
                Dim locIsSetup As New SqlParameter("@IsSetup", SqlDbType.Bit)
                locIsSetup.Direction = ParameterDirection.Output
                .Add(locIsSetup)
            End With
            locCmd.ExecuteNonQuery()
            Return CBool(locCmd.Parameters("@IsSetup").Value)
        End Using

    End Function

    Private Sub btnTData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTData.Click
        txtCity.Text = "Musterstadt"
        txtStreet.Text = "Beispielstraße 23"
        txtCountry.Text = "Germany"
        txtCountryCode.Text = "D"
        txtSubsidiaryName.Text = "SampleCompany Ltd."
        txtZip.Text = "59556"
        txtPrimaryPhone.Text = "+49 555 4554"
    End Sub

    Private Sub optNamedInstance_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optNamedInstance.CheckedChanged
        If optNamedInstance.Checked Then
            txtConnectionString.ReadOnly = False
            btnPickConnection.Enabled = True
        Else
            txtConnectionString.ReadOnly = True
            btnPickConnection.Enabled = False
        End If
    End Sub

    Private Sub btnPickConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPickConnection.Click
        Dim locFrm As New ActiveDev.Data.SqlClient.ADDatabaseConnectionDialog()
        Dim locSqlConnBuilder As SqlConnectionStringBuilder = locFrm.GetConnectionBuilder()
        If locSqlConnBuilder IsNot Nothing Then
            txtConnectionString.Text = locSqlConnBuilder.ToString
        End If
    End Sub

    Private Sub btnTestConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestConnection.Click
        If Step3_ValidateSQLConnection() = True Then
            MessageBox.Show("Verbindung konnte erfolgreich aufgebaut und getestet werden!", _
                "Verbindungsinfo:", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub mtbSerialNo_TextChanged(sender As Object, e As System.EventArgs) Handles mtbSerialNo.TextChanged

        Dim tmpGuid = New Guid(RegistryHelper.ProgramGUID)

        Dim locLicense As New FacessoLicenseManager(New Guid(RegistryHelper.ProgramGUID),
                                            RegistryHelper.InstallationDate,
                                            RegistryHelper.LastRunDate,
                                            RegistryHelper.LastRegisteredDate,
                                            mtbSerialNo.Text)

        If locLicense.IsSerialNoValid Then
            lblSerialNoValid.Text = "Die eingegebene Seriennummer ist gültig; eine Vollversion wird freigeschaltet."
            SerialDialogTooltips.SetToolTip(lblSerialNoValid, locLicense.ToString)
            Me.imgCheckSerialNo.Image = Global.Facesso.My.Resources.Resources.Keyboard_Check
        Else
            lblSerialNoValid.Text = "Die eingegebene Seriennummer ist nicht gültig; eine Demo-Version wird - so noch möglich - freigeschaltet."
            SerialDialogTooltips.SetToolTip(lblSerialNoValid, locLicense.ToString)
            Me.imgCheckSerialNo.Image = Global.Facesso.My.Resources.Resources.Keyboard_Error
        End If
    End Sub
End Class
