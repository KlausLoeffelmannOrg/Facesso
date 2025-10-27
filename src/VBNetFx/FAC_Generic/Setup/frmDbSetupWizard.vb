Imports ActiveDev
Imports Facesso
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Security.Cryptography
Imports System.Windows.Forms

Public Class frmDbSetupWizard

    Private myOleDBConnectionString As String
    Private mySQLConnectionString As String
    Private mySubsidiaryID As Integer = 1
    Private myStepAfterSQLConnectionChoice As Boolean
    Private myDatabaseAlreadySetup As Boolean

    'Wizard-Handler
    Private WithEvents myWizardController As ADWizardController

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        myWizardController = New ADWizardController(btnBack, btnNext, btnCancel, tcWizard)
        myWizardController.Initialize()
        mySQLConnectionString = RegistryHelper.ConnectionString
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
                e.Cancel = Not Step4_CompanyData()
            ElseIf e.NewStepNo = 2 Then
                e.Cancel = False
                e.NextStepAllowed = True
            ElseIf e.NewStepNo = 3 Then
                e.Cancel = False
                e.NextStepAllowed = True
            ElseIf e.NewStepNo = 4 Then
                e.Cancel = False
                e.NextStepAllowed = True
            End If
        End If
    End Sub

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

        MessageBox.Show("Die neue Facesso-Datenbank ist nun für den Einsatz bereit." + vbNewLine + _
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
End Class
