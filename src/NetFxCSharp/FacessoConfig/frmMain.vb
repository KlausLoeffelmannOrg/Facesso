Imports System.Collections.ObjectModel
Imports Facesso
Imports System.Data.SqlClient

Public Class frmMain

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim g = e.Graphics

    End Sub

    Private Sub btnSetupDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetupDatabase.Click
        Dim locDbSetupWizard As New frmDbSetupWizard
        locDbSetupWizard.ShowDialog()
    End Sub

    Private Sub btnActivateFacesso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivateFacesso.Click
        Dim locSetupWizard As New frmSetupWizard
        locSetupWizard.ShowDialog()
    End Sub

    Private Sub btnSetDatabaseInstance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDatabaseInstance.Click
        Dim locFrm As New ActiveDev.Data.SqlClient.ADDatabaseConnectionDialog()
        Dim locSqlConnBuilder As SqlConnectionStringBuilder = locFrm.GetConnectionBuilder()
        If locSqlConnBuilder IsNot Nothing Then
            RegistryHelper.SetConnectionString(locSqlConnBuilder.ToString)
        End If
    End Sub

    Private Sub btnUpdateSchema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateSchema.Click

    End Sub
End Class

