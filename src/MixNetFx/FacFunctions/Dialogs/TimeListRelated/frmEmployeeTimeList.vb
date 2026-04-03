Imports Facesso.Data
Imports System.Windows.Forms

Public Class frmEmployeeTimeList

    Private myEmployee As EmployeeInfo
    Private myReferenceDate As Date
    Private myTimeLogItems As EmployeeTimeLogInfo

    Public Overloads Sub ShowDialog(ByVal Employee As EmployeeInfo, ByVal ReferenceDate As Date)
        myReferenceDate = ReferenceDate
        myEmployee = Employee
        Me.Text = "Zeitenliste für " & Employee.DisplayName
        InitializeDates()
        dgvTimeList.SingleEmployeeList = True
        BuildList()
        Me.ShowDialog()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Public Sub InitializeDates()
        dtpFrom.Value = ActiveDev.Dates.FirstDayOfMonth(myReferenceDate)
        dtpTo.Value = ActiveDev.Dates.LastDayOfMonth(myReferenceDate)
    End Sub

    Public Sub BuildList()
        myTimeLogItems = New EmployeeTimeLogInfo(myEmployee, dtpFrom.Value, dtpTo.Value)
        dgvTimeList.EmployeeTimeLogItems = myTimeLogItems
    End Sub

    Public Sub DeleteItem()
        Dim locString As String = ""
        locString = "Sind Sie sicher, dass Sie die Zeiten der markierten Mitarbeiter" & vbNewLine & vbNewLine
        For Each locItem As EmployeeTimeLogInfoItem In dgvTimeList.SelectedEmployeeTimeLogItems
            locString &= locItem.ToString + vbNewLine
        Next
        locString &= vbNewLine & vbNewLine & "entfernen wollen?"
        Dim locDR As DialogResult = MessageBox.Show(locString, "Markierte Mitarbeiterzeiten entfernen", _
             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If locDR = Windows.Forms.DialogResult.Yes Then
            For Each locItem As EmployeeTimeLogInfoItem In dgvTimeList.SelectedEmployeeTimeLogItems
                dgvTimeList.EmployeeTimeLogItems.DeleteFromDatabase(locItem)
            Next
        End If
    End Sub

    Private Sub dgvTimeList_TimeLogItemDoubleClick(ByVal sender As System.Object, ByVal e As Facesso.FrontEnd.TimeLogItemClickEventArgs) Handles dgvTimeList.TimeLogItemDoubleClick
        Dim locTlis As New EmployeeTimeLogInfo()
        locTlis.Add(e.EmployeeTimeLogItem)
        EditTimeLogItems(locTlis)
        dgvTimeList.SelectEmployeeItems(locTlis)
    End Sub

    Private Sub EditTimeLogItems(ByVal tli As EmployeeTimeLogInfo)
        Dim locFormTimeItems As New frmTimeLogItemCollection
        tli.WorkGroup = WorkGroupInfo.FromID(tli(0).EmployeeInfo.IDSubsidiary, tli(0).IDWorkGroup)
        tli.Shift = tli(0).Shift
        tli.ProductionDate = tli(0).ProductionDate

        Dim locCP As New CombinedParametersInfo(tli.WorkGroup, tli(0).ProductionDate, tli(0).Shift)
        Dim locDR As DialogResult = locFormTimeItems.EditTimeLogItems(locCP, tli)
        If locDR = Windows.Forms.DialogResult.Abort Then Exit Sub
        For Each locItem As EmployeeTimeLogInfoItem In tli
            dgvTimeList.EmployeeTimeLogItems.SetItem(locItem.IDTimeLog, locItem)
        Next
        tli.SaveToDatabase(FacessoGeneric.LoginInfo.IDUser, False)
        BuildList()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        BuildList()
    End Sub

    Private Sub btnCurrentMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCurrentMonth.Click
        dtpFrom.Value = ActiveDev.Dates.FirstDayOfMonth(myReferenceDate)
        dtpTo.Value = ActiveDev.Dates.LastDayOfMonth(myReferenceDate)
    End Sub

    Private Sub btnLastMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLastMonth.Click
        dtpFrom.Value = ActiveDev.Dates.FirstDayOfMonth(myReferenceDate.AddMonths(-1))
        dtpTo.Value = ActiveDev.Dates.LastDayOfMonth(myReferenceDate.AddMonths(-1))
    End Sub

    Private Sub btnSecondLastMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSecondLastMonth.Click
        dtpFrom.Value = ActiveDev.Dates.FirstDayOfMonth(myReferenceDate.AddMonths(-2))
        dtpTo.Value = ActiveDev.Dates.LastDayOfMonth(myReferenceDate.AddMonths(-2))
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim locPrt As New FacPrintEmployeesTimeList(myTimeLogItems, FacessoGeneric.LoginInfo.Username)
        locPrt.ProcessDocument(AnalysisTarget.PreviewBeforePrint)
    End Sub
End Class