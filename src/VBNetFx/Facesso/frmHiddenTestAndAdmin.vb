Imports ActiveDevelop.EntitiesFormsLib
Imports Facesso.Data.Entity

Public Class frmHiddenTestAndAdmin

    Private Const DEFAULTFROMSTART As Date = #1/1/2010#
    Private Const DEFAULTFROMEND As Date = #3/31/2010#

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.FromStartNullableDateValue.Value = DEFAULTFROMSTART
        Me.ToStartNullableDateValue.Value = DEFAULTFROMEND

        'Erste des aktuellen Monats
        Me.ToEndNullableDateValue.Value = New Date(Now.Year, Now.Month, 1)

        PassCaptionLabel.Text = ""
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub ToEndNullableDateValue_IsDirtyChanged(sender As Object, e As System.EventArgs) Handles ToEndNullableDateValue.IsDirtyChanged
        MessageBox.Show("DirtyChanged", "test")
    End Sub

    'TODO: Soll diese Funktionalität nicht besser in den DataLayer (Entity?)
    Private Sub CopyNowButton_Clck(sender As System.Object, e As System.EventArgs) Handles CopyNowButton.Click

        'Schauen, ob Daten im Bereich vorhanden sind
        Dim productionDataExist = False
        Dim timeDataExist = False
        Dim facEnt As New FacessoEntities(FacessoGeneric.SqlEntityConnectionString)

        If Not ToEndNullableDateValue.Value.HasValue OrElse
            Not FromStartNullableDateValue.Value.HasValue OrElse
            Not ToStartNullableDateValue.Value.HasValue Then
            MessageBox.Show("Bitte wählen Sie gültige Datumswerte!")
            Exit Sub
        End If

        Dim toEndValue = ToEndNullableDateValue.Value.Value

        productionDataExist = (Aggregate item In facEnt.ProductionDatas
                               Where item.ProductionDate >= toEndValue
                               Into ItemCount = Count()) > 0

        timeDataExist = (Aggregate item In facEnt.TimeLogs
                         Where item.ProductionDate >= toEndValue
                         Into ItemCount = Count()) > 0

        'Meldung für das Löschen aufbauen
        Dim message = "Facesso hat festgestellt, dass ab dem Zielbereich (" &
            ToEndNullableDateValue.Value.Value.ToLongDateString & ") "
        If productionDataExist Then message &= "Produktionsdaten"
        If productionDataExist And timeDataExist Then message &= " und "
        If timeDataExist Then message &= "Zeitbuchungsdaten"

        message &= " existieren. Sollen diese Daten gelöscht werden?"

        If productionDataExist Or timeDataExist Then
            'Sicherheitsabfrage
            Dim retmb = MessageBox.Show(message, "Vorhandene Daten:", MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question,
                                      MessageBoxDefaultButton.Button2)
            If retmb = Windows.Forms.DialogResult.No Then
                Return
            End If

            PassCaptionLabel.Text = "Zeitdaten ab Einfügezeitpunkt löschen..."
            PassCaptionLabel.Refresh()
            'Die löschen wir direkt - geht schneller
            facEnt.ExecuteStoreCommand("Delete from TimeLog Where [ProductionDate]>=Convert(datetime,{0},104)",
                                       toEndValue.ToString("dd.MM.yyyy"))

            PassCaptionLabel.Text = "Mengendaten ab Einfügezeitpunkt löschen..."
            PassCaptionLabel.Refresh()
            'Die löschen wir über das Entity-Modell.
            Dim prodDataToDelete = (From prodItem In facEnt.ProductionDatas
                                 Where prodItem.ProductionDate >= toEndValue).ToList

            For Each prodItem In prodDataToDelete
                CopyInfoLabel.Text = prodItem.ProductionDate.ToLongDateString
                CopyInfoLabel.Refresh()
                facEnt.ExecuteStoreCommand("Delete from ProductionDataItems Where [IDProductionData]={0}",
                           prodItem.IDProductionData)
                facEnt.DeleteObject(prodItem)
            Next
            facEnt.SaveChanges()
        End If

        'Und jetzt beginnen wir die Werte zu kopieren
        Dim currentDate = FromStartNullableDateValue.Value.Value
        Dim endDate = ToStartNullableDateValue.Value.Value
        Dim daysOffset = CInt((ToEndNullableDateValue.Value.Value - currentDate).TotalDays)

        Dim targetFacEntity As New FacessoEntities(FacessoGeneric.SqlEntityConnectionString)
        Dim changed = False

        CopyProgressBar.Maximum = CInt((endDate - currentDate).TotalDays)
        Dim daysCount = 0

        Do While currentDate < endDate
            CopyProgressBar.Value = daysCount
            CopyProgressBar.Refresh()

            CopyInfoLabel.Text = currentDate.ToLongDateString
            CopyInfoLabel.Refresh()

            'Zuerst die Produktionsdaten kopieren
            PassCaptionLabel.Text = "Produktionsdaten verarbeiten:"
            PassCaptionLabel.Refresh()

            Dim prodData = (From prodItem In facEnt.ProductionDatas
                         Where prodItem.ProductionDate = currentDate).ToList

            changed = prodData.Count > 0

            For Each prodDataItem In prodData
                prodDataItem.ProductionDataItems.Load()
                Dim prodDataItems = (prodDataItem.ProductionDataItems).ToList
                For Each pdi In prodDataItems
                    facEnt.Detach(pdi)
                Next
                Dim entCopy = prodDataItem
                facEnt.Detach(entCopy)

                entCopy.ProductionDate = currentDate.AddDays(daysOffset)
                For Each pdi In prodDataItems
                    entCopy.ProductionDataItems.Add(pdi)
                Next
                Application.DoEvents()
                targetFacEntity.ProductionDatas.AddObject(entCopy)
            Next

            If changed Then
                targetFacEntity.SaveChanges()
            End If

            PassCaptionLabel.Text = "Zeitdaten verarbeiten:"
            PassCaptionLabel.Refresh()

            Dim timeLogData = (From timeItem In facEnt.TimeLogs
                 Where timeItem.ProductionDate = currentDate).ToList

            changed = timeLogData.Count > 0

            For Each timeItem In timeLogData
                Dim entCopy = timeItem
                facEnt.Detach(entCopy)
                entCopy.ProductionDate = currentDate.AddDays(daysOffset)
                targetFacEntity.TimeLogs.AddObject(entCopy)
                Application.DoEvents()
            Next

            If changed Then
                targetFacEntity.SaveChanges()
            End If

            currentDate = currentDate.AddDays(1)
            daysCount += 1
        Loop
    End Sub

    Private Sub DisplayLogmessage(Message As String)

    End Sub

    Private Sub btnNamenAnonymisieren_Click(sender As System.Object, e As System.EventArgs) Handles btnNamenAnonymisieren.Click
        Dim facEnt As New FacessoEntities(FacessoGeneric.SqlEntityConnectionString)
        Dim allEmployees = (From empItems In facEnt.Employees).ToList

        Dim demoContacts = DemoContact.RandomContacts(allEmployees.Count)

        Dim count = 0
        For Each item In allEmployees
            item.FirstName = demoContacts(count).FirstName
            item.LastName = demoContacts(count).LastName
            item.PersonnelNumber = count + 10000
            count += 1
            item.AddressDetail.FirstName = item.FirstName
            item.AddressDetail.LastName = item.LastName
        Next

        facEnt.SaveChanges()
    End Sub
End Class
