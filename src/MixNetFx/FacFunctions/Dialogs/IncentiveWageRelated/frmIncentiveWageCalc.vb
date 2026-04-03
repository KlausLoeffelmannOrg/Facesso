Imports Facesso.FrontEnd
Imports Facesso.Data

Imports System.Windows.Forms

Public Class frmIncentiveWageCalc

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        'Employeeliste füllen
        Dim locEmployees As New EmployeeInfoItems(0)
        If locEmployees Is Nothing OrElse locEmployees.Count = 0 Then
            MessageBox.Show("Es sind keine Stammdaten vorhanden. Bitte legen Sie zunächst die erforderlichen Stammdaten an und führen Sie eine Datenerfassung durch", _
                            "Fehlende Stammdaten:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Dispose()
        End If
        elvEmployees.EmployeeInfoCollection = locEmployees
        SelectAll()

        'Monatsbereich aus den globalen Einstellungen laden
        MonthRangePicker.MonthRangeResult = CType(FacessoGeneric.FacessoGlobalSettings.Settings.GetItem("WageCalcMonthlyRange", _
                                            MonthRangePicker.MonthRangeResult), MonthRangePickerResult)
    End Sub

    Private Sub SelectAll()
        For Each locItem As ListViewItem In elvEmployees.Items
            locItem.Selected = True
        Next
    End Sub

    Private Sub UnselectAll()
        For Each locItem As ListViewItem In elvEmployees.Items
            locItem.Selected = False
        Next
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        SelectAll()
    End Sub

    Private Sub btnUnselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnselectAll.Click
        UnselectAll()
    End Sub

    Private Sub btnPerformCalculation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPerformCalculation.Click

        'Einstellungen speichern
        FacessoGeneric.FacessoGlobalSettings.Settings.SetItem("WageCalcMonthlyRange", MonthRangePicker.MonthRangeResult)

        'Wieviele Mitarbeiter müssen berechnet werden?
        Dim locCount As Integer = elvEmployees.SelectedEmployees.Count
        If locCount = 0 Then
            MessageBox.Show("Bitte wählen Sie die auszuwertenden Mitarbeiter aus.", _
                            "Keine Mitarbeiter ausgewählt:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim locEmployeesAnalysed As New EmployeeAnalysisInfoItems(MonthRangePicker.DateRangeText)
        Dim locEmployeeAnalysed As EmployeeAnalysisInfoItem = Nothing
        Dim blnFirst As Boolean
        Dim locTicket As DateTime

        pbEmployeesToAnalyse.Maximum = locCount
        'Employee-Daten holen
        For Each locEmployee As EmployeeInfo In elvEmployees.SelectedEmployees
            'Progress-Bar setzen:
            pbEmployeesToAnalyse.Value = locCount
            locCount -= 1
            'Mitarbeiternamen anzeigen
            lblCurrentEmployee.Text = locEmployee.DisplayName
            Application.DoEvents()
            'Den Zeitraum bestimmen (immer über alle Schichten)
            Dim locPeriod As New ProductionPeriod(MonthRangePicker.MonthRangeResult.FromDate, _
                                                  MonthRangePicker.MonthRangeResult.ToDate)
            'Zeitdaten einholen und Lohndaten berechnen
            If Not blnFirst Then
                locEmployeeAnalysed = New EmployeeAnalysisInfoItem(FacessoGeneric.LoginInfo.IDSubsidiary, _
                        FacessoGeneric.LoginInfo.IDUser, locEmployee, locPeriod, True)
                locTicket = locEmployeeAnalysed.UsedTicket
                blnFirst = True
            Else
                locEmployeeAnalysed = New EmployeeAnalysisInfoItem(FacessoGeneric.LoginInfo.IDSubsidiary, _
                        FacessoGeneric.LoginInfo.IDUser, locEmployee, locPeriod, locTicket, False)
            End If
            locEmployeesAnalysed.Add(locEmployeeAnalysed)
        Next
        locEmployeeAnalysed.CleanUp()
        pbEmployeesToAnalyse.Value = 0
        Dim locFrm As New frmIncentiveWageGroupResult
        locFrm.ShowDialog(locEmployeesAnalysed)
    End Sub
End Class