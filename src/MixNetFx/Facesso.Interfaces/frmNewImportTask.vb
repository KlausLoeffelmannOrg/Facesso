Imports Facesso.Data
Imports System.Windows.Forms

Public Class frmNewImportTask

    Private myImportTaskToReturn As IFacessoImportTaskItem

    Public Function GetImportTask() As IFacessoImportTaskItem
        InitializeHeaders()
        InitializeTaskTemplates()
        Me.ShowDialog()
        Return myImportTaskToReturn
    End Function

    Private Sub InitializeHeaders()
        With lvwTaskTemplates
            With .Columns
                .Add("Task-Name", -2, Windows.Forms.HorizontalAlignment.Left)
                .Add("Import-Typ", -2, Windows.Forms.HorizontalAlignment.Left)
            End With
        End With

        With lvwDeviceClasses
            With .Columns
                .Add("Geräte-Klasse", -2, Windows.Forms.HorizontalAlignment.Left)
            End With
        End With
    End Sub

    Private Sub InitializeTaskTemplates()
        Dim locWorkgroups As New WorkGroupInfoItems(True)
        Dim locTaskTemplate As FacessoTaskItemTemplate
        Dim locLvwItem As ListViewItem
        lvwTaskTemplates.Items.Clear()
        Dim locCount As Long = 0

        'TimeKeeping-Importfilter hinzufügen
        locTaskTemplate = New FacessoTaskItemTemplate(locCount, _
            "Für allgemeine Zeiterfassung", FacessoImportType.TimeKeepingData)
        locLvwItem = New ListViewItem(locTaskTemplate.ToString)
        locLvwItem.Tag = locTaskTemplate
        locLvwItem.SubItems.Add("Zeiterfassung")
        lvwTaskTemplates.Items.Add(locLvwItem)

        'Produktiv-Site-Importfilter hinzufügen
        For Each locWorkgroup As WorkGroupInfo In locWorkgroups
            locTaskTemplate = New FacessoTaskItemTemplate(locCount, _
                    "für Prod.-Site: " & locWorkgroup.WorkGroupNumber & ": " & locWorkgroup.WorkGroupName, _
                    FacessoImportType.WorkGroupData, locWorkgroup.IDWorkGroup)
            locLvwItem = New ListViewItem(locTaskTemplate.ToString)
            locLvwItem.Tag = locTaskTemplate
            locLvwItem.SubItems.Add("Produktionsdaten")
            lvwTaskTemplates.Items.Add(locLvwItem)
        Next
    End Sub

    Private Sub InitializeDeviceClasses(ByVal ImportType As FacessoImportType)
        lvwDeviceClasses.Items.Clear()
        If ImportType = FacessoImportType.NotDefined Then
            Return
        End If
        For Each locItem As FacessoInterfaceClassItem In frmImport.Interfaces
            If locItem.InterfaceAttribute.ImportType = ImportType Then
                Dim locLvwItem As New ListViewItem(locItem.InterfaceAttribute.ImportFiltername)
                locLvwItem.Tag = locItem
                lvwDeviceClasses.Items.Add(locLvwItem)
            End If
        Next
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        myImportTaskToReturn = Nothing
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub lvwTaskTemplates_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwTaskTemplates.SelectedIndexChanged

        If lvwTaskTemplates.SelectedIndices.Count = 0 Then
            InitializeDeviceClasses(FacessoImportType.NotDefined)
            Return
        End If

        Dim locSelectedItem As FacessoTaskItemTemplate = DirectCast(lvwTaskTemplates.SelectedItems(0).Tag, FacessoTaskItemTemplate)
        InitializeDeviceClasses(locSelectedItem.ImportType)
    End Sub

    Private Sub lvwDeviceClasses_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwDeviceClasses.SelectedIndexChanged
        If lvwTaskTemplates.SelectedIndices.Count = 0 Then
            btnOK.Enabled = False
            Return
        End If
        btnOK.Enabled = True
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'Aus den TaskTemplates eine Instanz für die Konfigurierung der Klasse erstellen
        Dim locTemplate As FacessoTaskItemTemplate = DirectCast(lvwTaskTemplates.SelectedItems(0).Tag, FacessoTaskItemTemplate)
        Dim locInterface As FacessoInterfaceClassItem = DirectCast(lvwDeviceClasses.SelectedItems(0).Tag, FacessoInterfaceClassItem)
        Dim locTaskType As Type = locInterface.InterfaceType

        'Instanz des Objektes mit parameterlosem Konstruktor erstellen
        Dim locObject As Object = locTaskType.InvokeMember(Nothing, Reflection.BindingFlags.CreateInstance, Nothing, Nothing, Nothing)

        'In den richtigen Typ casten
        myImportTaskToReturn = DirectCast(locObject, IFacessoImportTaskItem)
        myImportTaskToReturn.IDWorkgroup = locTemplate.IDWorkgroup
        myImportTaskToReturn.Name = locTemplate.Name & " mit " & locInterface.ToString
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class