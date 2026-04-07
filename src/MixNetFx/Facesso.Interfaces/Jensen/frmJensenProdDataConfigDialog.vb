Imports System.IO
Imports System.Windows.Forms
Imports ActiveDev.Data.SqlClient
Imports System.Data.SqlClient

Public Class frmJensenProdDataConfigDialog

    Private Sub btnChoosePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoosePath.Click

        Dim locFB As New ADDatabaseConnectionDialog
        Dim locCB As SqlConnectionStringBuilder = locFB.GetConnectionBuilder("Jensen-SQL-Verbindung:")
        If locCB IsNot Nothing Then
            txtSqlConnectionString.Text = locCB.ToString
            DirectCast(TaskItem, JensenProductionDataImportTaskElement).JensenSQLConnectionString = locCB.ToString
            DirectCast(TaskItem, JensenProductionDataImportTaskElement).JensenDeviceID = Nothing
            TryPopulateJensenDevices()
        End If
    End Sub

    Protected Overrides Sub InitializeControls()
        MyBase.InitializeControls()
        txtSqlConnectionString.Text = DirectCast(TaskItem, JensenProductionDataImportTaskElement).JensenSQLConnectionString
        If TryPopulateJensenDevices() Then
            SetJensenDevice(DirectCast(TaskItem, JensenProductionDataImportTaskElement).JensenDeviceID)
        End If
        myAllowMultipleAssignments = False
    End Sub

    Protected Overrides ReadOnly Property BlockDeviceListBuilding() As Boolean
        Get
            Try
                If DirectCast(TaskItem, JensenProductionDataImportTaskElement).JensenSQLConnectionString IsNot Nothing Then
                    If DirectCast(TaskItem, JensenProductionDataImportTaskElement).JensenDeviceID IsNot Nothing Then
                        Return False
                    End If
                End If
            Catch ex As Exception
            End Try
            Return True
        End Get
    End Property

    Private Sub cmbJensenDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDevice.SelectedIndexChanged
        DirectCast(TaskItem, JensenProductionDataImportTaskElement).JensenDeviceID = GetJensenDevice()
        RebuildLists()
    End Sub

    Public Function TryPopulateJensenDevices() As Boolean
        If txtSqlConnectionString.Text IsNot Nothing Then
            'Versuchen, aufzumachen
            Dim locConnection As New SqlConnection(txtSqlConnectionString.Text)
            Using locConnection
                Try
                    locConnection.Open()
                Catch ex As Exception
                    MessageBox.Show("Verbindung zur Jensendatenbank konnte nicht hergestellt werden!", _
                                    "Verbindungsfehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                    lblDevice.Enabled = False
                    cmbDevice.Enabled = False
                End Try
                Dim locCommand As New SqlCommand("SELECT TargetID FROM LogInfo", locConnection)
                Dim locReader As SqlDataReader = locCommand.ExecuteReader
                cmbDevice.Items.Clear()
                cmbDevice.Items.Add("- nicht definiert -")
                If locReader.HasRows Then
                    Do While locReader.Read
                        cmbDevice.Items.Add(locReader.GetString(locReader.GetOrdinal("TargetID")))
                    Loop
                End If
            End Using
            lblDevice.Enabled = True
            cmbDevice.Enabled = True
            Return True
        End If
    End Function

    Private Function GetJensenDevice() As String
        If cmbDevice.SelectedItem IsNot Nothing Then
            Return cmbDevice.SelectedItem.ToString
        End If
        Return Nothing
    End Function

    Private Sub SetJensenDevice(ByVal Device As String)
        For locIndex As Integer = 0 To cmbDevice.Items.Count - 1
            If cmbDevice.Items(locIndex).ToString = Device Then
                cmbDevice.SelectedIndex = locIndex
                Return
            End If
        Next
        cmbDevice.SelectedIndex = 0
    End Sub
End Class
