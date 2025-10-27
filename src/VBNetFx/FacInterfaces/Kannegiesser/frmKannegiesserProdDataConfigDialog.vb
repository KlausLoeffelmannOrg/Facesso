Imports System.IO
Imports System.Windows.Forms

Public Class frmKannegiesserProdDataConfigDialog

    Private Sub btnChoosePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoosePath.Click
        Dim locFB As New FolderBrowserDialog
        locFB.Description = "Pfad zur Kannegiesser-Gerätedaten wählen:"
        Dim locDR As DialogResult = locFB.ShowDialog
        If locDR = Windows.Forms.DialogResult.OK Then
            txtPathToDeviceData.Text = locFB.SelectedPath
            DirectCast(TaskItem, KannegiesserProductionDataImportTaskElement).PathToDeviceData = locFB.SelectedPath
            TaskItem.ConversionItems = DirectCast(TaskItem, KannegiesserProductionDataImportTaskElement).AssembleConversionItems()
            RebuildLists()
        End If
    End Sub

    Protected Overrides Sub InitializeControls()
        MyBase.InitializeControls()
        myAllowMultipleAssignments = True
    End Sub
End Class
