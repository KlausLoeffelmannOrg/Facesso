Imports System.IO
Imports System.Windows.Forms
Imports ActiveDev.Data.SqlClient
Imports System.Data.SqlClient

Public Class frmKannegiesserSQLProdDataConfigDialog

    Dim mySetByAssignment As Boolean

    Private Sub btnChoosePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoosePath.Click
        PickSqlConnectionString()
    End Sub

    Private Sub PickSqlConnectionString()
        Dim locFB As New ADDatabaseConnectionDialog
        Dim locCB As SqlConnectionStringBuilder = locFB.GetConnectionBuilder("Kannegiesser-SQL-Verbindung:")
        If locCB IsNot Nothing Then
            txtSqlConnectionString.Text = locCB.ToString
        Else
            lblDevice.Enabled = False
            cmbDevice.Enabled = False
            Return
        End If
        
        If TryPopulateKannegiesserDevices() Then
            lblDevice.Enabled = True
            cmbDevice.Enabled = True
            DirectCast(TaskItem, KannegiesserSQLProductionDataImportTaskElement).KannegiesserSQLConnectionString = locCB.ToString
            DirectCast(TaskItem, KannegiesserSQLProductionDataImportTaskElement).KannegiesserDeviceID = Nothing
            TaskItem.ConversionItems = DirectCast(TaskItem, KannegiesserSQLProductionDataImportTaskElement).AssembleConversionItems()
            RebuildLists()
        Else
            lblDevice.Enabled = False
            cmbDevice.Enabled = False
        End If
    End Sub

    Protected Overrides Sub InitializeControls()
        MyBase.InitializeControls()
        If String.IsNullOrEmpty(DirectCast(TaskItem, KannegiesserSQLProductionDataImportTaskElement).KannegiesserSQLConnectionString) Then
            PickSqlConnectionString()
        Else
            txtSqlConnectionString.Text = DirectCast(TaskItem, KannegiesserSQLProductionDataImportTaskElement).KannegiesserSQLConnectionString
        End If
        If TryPopulateKannegiesserDevices() Then
            SetKannegiesserDevice(DirectCast(TaskItem, KannegiesserSQLProductionDataImportTaskElement).KannegiesserDeviceID)
        End If
        myAllowMultipleAssignments = True
    End Sub

    Protected Overrides ReadOnly Property BlockDeviceListBuilding() As Boolean
        Get
            Try
                If DirectCast(TaskItem, KannegiesserSQLProductionDataImportTaskElement).KannegiesserSQLConnectionString IsNot Nothing Then
                    If DirectCast(TaskItem, KannegiesserSQLProductionDataImportTaskElement).KannegiesserDeviceID IsNot Nothing Then
                        Return False
                    End If
                End If
            Catch ex As Exception
            End Try
            Return True
        End Get
    End Property

    Private Sub cmbDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDevice.SelectedIndexChanged
        DirectCast(TaskItem, KannegiesserSQLProductionDataImportTaskElement).KannegiesserDeviceID = GetKannegiesserDevice()
        If mySetByAssignment Then
            mysetbyAssignment = False
        Else
            TaskItem.ConversionItems = DirectCast(TaskItem, KannegiesserSQLProductionDataImportTaskElement).AssembleConversionItems()
        End If
        RebuildLists()
    End Sub

    Private Function TryPopulateKannegiesserDevices() As Boolean
        If txtSqlConnectionString.Text IsNot Nothing Then
            'Versuchen, aufzumachen
            Dim locConnection As New SqlConnection(txtSqlConnectionString.Text)
            Using locConnection
                Try
                    locConnection.Open()
                Catch ex As Exception
                    MessageBox.Show("Verbindung zur Kannegiesser-Datenbankinstanz konnte nicht hergestellt werden!", _
                                    "Verbindungsfehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End Try

                Dim oc As New KannegiesserDataContext(txtSqlConnectionString.Text)
                Dim machineList = (From item In oc.GetMachines).ToList
                cmbDevice.Items.Clear()
                cmbDevice.Items.Add("- nicht definiert -")
                If machineList.Count > 0 Then
                    For Each item In machineList
                        cmbDevice.Items.Add(item)
                    Next
                End If
            End Using
            Return True
        End If
    End Function

    Private Function GetKannegiesserDevice() As String
        If cmbDevice.SelectedIndex <= 0 Then
            Return Nothing
        End If

        If cmbDevice.SelectedItem IsNot Nothing Then
            Return DirectCast(cmbDevice.SelectedItem, GetMachinesResult).MachineID.ToString
        End If
        Return Nothing
    End Function

    Private Sub SetKannegiesserDevice(ByVal Device As String)
        mySetByAssignment = True
        If String.IsNullOrEmpty(Device) Then
            cmbDevice.SelectedIndex = 0
            Return
        End If

        For locIndex As Integer = 0 To cmbDevice.Items.Count - 1
            If locIndex > 0 Then
                If DirectCast(cmbDevice.Items(locIndex), GetMachinesResult).MachineID.ToString = Device Then
                    cmbDevice.SelectedIndex = locIndex
                    Return
                End If
            End If
        Next
        cmbDevice.SelectedIndex = 0
    End Sub
End Class
