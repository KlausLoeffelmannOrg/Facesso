Imports Facesso
Imports Facesso.Data
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmProductionDataConfigureDialogBase

    Private myTaskItem As IFacessoImportTaskItem
    Private myLabourValues As LabourValueInfoCollection
    Protected myAllowMultipleAssignments As Boolean

    Public Function HandleDialog(ByVal TaskItem As IFacessoImportTaskItem) As DialogResult
        myTaskItem = TaskItem
        myLabourValues = LabourValueInfoCollection.GetWorkGroupAssignedLabourValues( _
            FacessoGeneric.LoginInfo.IDSubsidiary, myTaskItem.ForWorkgroup)

        InitializeControls()
        RebuildLists()
        Me.ShowDialog()
        Return Me.DialogResult
    End Function

    Protected Property TaskItem() As IFacessoImportTaskItem
        Get
            Return myTaskItem
        End Get
        Set(ByVal value As IFacessoImportTaskItem)
            myTaskItem = value
        End Set
    End Property

    Protected Overridable Sub InitializeControls()
        With lvwDeviceItems
            .Columns.Add("ID", -2, HorizontalAlignment.Left)
            .Columns.Add("Beschreibung", -2, HorizontalAlignment.Left)
            .Columns.Add("Arbeitswert", -2, HorizontalAlignment.Left)
        End With

        If myTaskItem.ConversionItems Is Nothing Then
            myTaskItem.ConversionItems = myTaskItem.ConversionItemsDelegate.Invoke()
        End If
        lblTitel.Text = "Konfiguration für Produktiv-Site:" & vbNewLine & _
                      myTaskItem.ForWorkgroup.ListItemText
    End Sub

    Protected Overridable Sub RebuildLists()

        Dim locSelectedLabourValue As LabourValueInfo = Nothing
        Dim locSelectedDeviceItem As IFacessoConversionItem = Nothing

        Try
            locSelectedLabourValue = ucLabourValues.FirstSelectedLabourValue
            locSelectedDeviceItem = DirectCast(lvwDeviceItems.SelectedItems(0).Tag, IFacessoConversionItem)
        Catch ex As Exception
            'Nur Fehler abfangen. Falls nichts selektiert war,
            'ist das entsprechende Item eh Nothing.
        End Try

        lvwDeviceItems.BeginUpdate()
        lvwDeviceItems.Items.Clear()
        'Nur neu aufbauen, wenn die ableitende Klasse
        'diese Eigenschaft auf True setzt.
        If Not BlockDeviceListBuilding Then
            If myTaskItem.ConversionItems IsNot Nothing Then
                For Each locItem As IFacessoConversionItem In myTaskItem.ConversionItems
                    Dim locLvwItem As New ListViewItem(locItem.AlienElementID.ToString("000000"))
                    locLvwItem.SubItems.Add(locItem.Itemname)
                    If locItem.HomeElementID = -1 Then
                        locLvwItem.SubItems.Add("- - -")
                    Else
                        locLvwItem.SubItems.Add(locItem.HomeElementName)
                        locLvwItem.Font = New Font(locLvwItem.Font, FontStyle.Bold)
                    End If
                    locLvwItem.Tag = locItem
                    lvwDeviceItems.Items.Add(locLvwItem)
                Next
            End If

            lvwDeviceItems.Columns(0).Width = -2
            lvwDeviceItems.Columns(1).Width = -2
            lvwDeviceItems.Columns(2).Width = -2
        End If
        lvwDeviceItems.EndUpdate()

        Dim locToAssignList As New LabourValueInfoCollection
        For Each locItem As LabourValueInfo In myLabourValues
            locToAssignList.Add(locItem)
        Next

        'Elemente, die schon verwendet wurden, nur dann entfernen, wenn 
        'Mehrfachzuweisungen nicht erlaubt sind!
        If Not myAllowMultipleAssignments Then
            For Each locDestItem As ListViewItem In lvwDeviceItems.Items
                Dim locItem As IFacessoConversionItem = DirectCast(locDestItem.Tag, IFacessoConversionItem)
                locToAssignList.Remove(New ActiveDev.IntKey(locItem.HomeElementID))
            Next
        End If
        ucLabourValues.LabourValues = locToAssignList

        'Dafür sorgen, dass zuvor Dargestellte wieder angezeigt werden.
        If locSelectedLabourValue IsNot Nothing Then
            ucLabourValues.SelectLabourValue(locSelectedLabourValue, True)
        End If

        If locSelectedDeviceItem IsNot Nothing Then
            For Each locItem As ListViewItem In lvwDeviceItems.Items
                Dim locDevItem As IFacessoConversionItem = DirectCast(locItem.Tag, IFacessoConversionItem)
                If locDevItem.AlienElementID = locSelectedDeviceItem.AlienElementID Then
                    locItem.Selected = True
                    locItem.EnsureVisible()
                End If
            Next
        End If
    End Sub

    Protected Overridable Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If ucLabourValues.FirstSelectedLabourValue Is Nothing Then
            MessageBox.Show("Bitte wählen Sie zunächst einen REFA-Arbeitswert aus, den Sie an die Geräte-IDs zuweisen möchten!", _
                             "Fehlende Arbeitswertauswahl!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If lvwDeviceItems.SelectedIndices.Count = 0 Then
            MessageBox.Show("Bitte wählen Sie zunächst eine DeviceID aus, der Sie den REFA-Arbeitswert zuweisen möchten!", _
                             "Fehlender Device-ID-Auswahl!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim locLabourValue As LabourValueInfo = ucLabourValues.FirstSelectedLabourValue
        Dim locDeviceItem As IFacessoConversionItem = DirectCast(lvwDeviceItems.SelectedItems(0).Tag, IFacessoConversionItem)
        locDeviceItem.HomeElementID = locLabourValue.IDLabourValue
        locDeviceItem.HomeElementName = locLabourValue.LabourValueNumber & ": " & locLabourValue.LabourValueName
        RebuildLists()
    End Sub

    Protected Overridable Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If lvwDeviceItems.SelectedIndices.Count = 0 Then
            MessageBox.Show("Bitte wählen Sie zunächst eine DeviceID aus, deren REFA-Arbeitswert-Zuweisung Sie aufheben möchten!", _
                             "Fehlender Device-ID-Auswahl!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Dim locDeviceItem As IFacessoConversionItem = DirectCast(lvwDeviceItems.SelectedItems(0).Tag, IFacessoConversionItem)
        locDeviceItem.HomeElementID = -1
        locDeviceItem.HomeElementName = Nothing
        RebuildLists()
    End Sub

    Protected Overridable Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Protected Overridable Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Protected Overridable ReadOnly Property BlockDeviceListBuilding() As Boolean
        Get
            Return False
        End Get
    End Property
End Class