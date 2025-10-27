Imports Facesso.Data
Imports System.Drawing
Imports System.Windows.Forms

Friend Class frmIncentiveWageGroupResult

    Private myAnalysisItems As EmployeeAnalysisInfoItems

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Overloads Function ShowDialog(ByVal AnalysisItems As EmployeeAnalysisInfoItems) As DialogResult
        myAnalysisItems = AnalysisItems
        InitializeTable()
        UpdateContent()
        Me.Location = DirectCast(FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoIncWageListWindowLocation", Me.Location), Point)
        Me.Size = DirectCast(FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoIncWageListWindowSize", Me.Size), Size)
        Return Me.ShowDialog()
    End Function

    Private Sub UpdateContent()

        Dim locSumIncentiveWage As Double

        dgvEmployeeWages.Rows.Clear()

        For Each locItem As EmployeeAnalysisInfoItem In myAnalysisItems
            If locItem.EmployeeWage.DegreeOfTime = -1 Then
                dgvEmployeeWages.Rows.Add(New Object() _
                    {locItem.EmployeeWage.IDEmployee, _
                    locItem.EmployeeWage.PersonnelNumber, _
                    locItem.EmployeeWage.LastName & ", " & locItem.EmployeeWage.FirstName, _
                    "- - -", "- - -", _
                    "Zeitgrad:" & "- - -" & vbNewLine & "(Faktor: " & "- - -" & ")", _
                    locItem.EmployeeWage.BaseWage.ToString("#,##0.00"), _
                    "- - -", _
                    "- - -", False})
            Else
                dgvEmployeeWages.Rows.Add(New Object() _
                    {locItem.EmployeeWage.IDEmployee, _
                    locItem.EmployeeWage.PersonnelNumber, _
                    locItem.EmployeeWage.LastName & ", " & locItem.EmployeeWage.FirstName, _
                    locItem.TimeLogItems.AttendanceTimeDeltaStrings, _
                    locItem.TimeLogItems.IncentiveTimeDeltaStrings, _
                    "Zeitgrad: " & locItem.EmployeeWage.DegreeOfTime.ToString("##0") & vbNewLine & locItem.EmployeeWage.PercentageDescription, _
                    locItem.EmployeeWage.BaseWage.ToString("#,##0.00 €"), _
                    (locItem.EmployeeWage.IncentiveWageTime / 60).ToString("#,##0.00 \h"), _
                    locItem.EmployeeWage.TotalIncentiveWage.ToString("#,##0.00 €"), True})
                dgvEmployeeWages.Rows(dgvEmployeeWages.Rows.Count - 1).Tag = locItem.EmployeeWage.TotalIncentiveWage
                locSumIncentiveWage += locItem.EmployeeWage.TotalIncentiveWage
            End If
        Next
        lblIncentiveWageForMonth.Text = "Prämienlöhne " & myAnalysisItems.PeriodText
        lblIncentiveWageSum.Text = locSumIncentiveWage.ToString("#,##0.00 €")
    End Sub

    Protected Overrides Sub OnClosed(ByVal e As System.EventArgs)
        MyBase.OnClosed(e)
        With FacessoGeneric.FacessoUserSettings
            If Not Me.WindowState = FormWindowState.Minimized Then
                .Settings.SetItem("FacessoIncWageListWindowLocation", Me.Location)
                .Settings.SetItem("FacessoIncWageListWindowSize", Me.Size)
            End If
        End With
    End Sub

    Private Sub InitializeTable()
        Dim locColumn As DataGridViewColumn
        Dim locTextCell As New DataGridViewTextBoxCell

        Dim locHeaderFont As New Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold)
        Dim locCellFont As New Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular)
        Dim locSpecialFont As New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)

        dgvEmployeeWages.ColumnHeadersDefaultCellStyle.Font = locHeaderFont
        dgvEmployeeWages.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvEmployeeWages.AllowUserToAddRows = False
        dgvEmployeeWages.AllowUserToDeleteRows = False
        dgvEmployeeWages.AllowUserToOrderColumns = False

        With dgvEmployeeWages.Columns
            .Clear()
            'ID (nicht sichtbar)
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.Visible = False
            locColumn.Name = "IDEmployee"
            .Add(locColumn)

            'Personalnummer
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            locColumn.FillWeight = 100
            locColumn.DisplayIndex = 0
            locColumn.HeaderText = "Pers.-Nr.:"
            locColumn.MinimumWidth = 50
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            locColumn.DefaultCellStyle.Font = locHeaderFont
            locColumn.Name = "PersonnelNr"
            locColumn.SortMode = DataGridViewColumnSortMode.Programmatic
            .Add(locColumn)

            'Name, Vorname
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            locColumn.FillWeight = 300
            locColumn.DisplayIndex = 1
            locColumn.HeaderText = "Name, Vorname:"
            locColumn.MinimumWidth = 100
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            locColumn.DefaultCellStyle.Font = locCellFont
            locColumn.Name = "LastnameFirstname"
            locColumn.SortMode = DataGridViewColumnSortMode.Programmatic
            .Add(locColumn)

            'Anwesenheitszeiten
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.Width = 150
            locColumn.DisplayIndex = 2
            locColumn.HeaderText = "Anwesenheitszeiten"
            locColumn.MinimumWidth = 150
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.False
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            locColumn.DefaultCellStyle.Font = locCellFont
            locColumn.Name = "DeltaTimes"
            .Add(locColumn)

            'Bonuszeiten
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.Width = 150
            locColumn.DisplayIndex = 3
            locColumn.HeaderText = "Bonuszeiten"
            locColumn.MinimumWidth = 150
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.False
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            locColumn.DefaultCellStyle.Font = locCellFont
            locColumn.Name = "BonusTimes"
            .Add(locColumn)

            'Zeitgrad/Faktor
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            locColumn.FillWeight = 100
            locColumn.DisplayIndex = 4
            locColumn.HeaderText = "Zeitgrad"
            locColumn.MinimumWidth = 100
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            locColumn.DefaultCellStyle.Font = locCellFont
            locColumn.Name = "DegreeOfTime"
            locColumn.SortMode = DataGridViewColumnSortMode.Programmatic
            .Add(locColumn)

            'Grundlohn
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            locColumn.FillWeight = 60
            locColumn.DisplayIndex = 5
            locColumn.HeaderText = "Grundlohn"
            locColumn.MinimumWidth = 60
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            locColumn.DefaultCellStyle.Font = locCellFont
            locColumn.Name = "BaseWage"
            .Add(locColumn)

            'Prämienlohnstunden
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            locColumn.FillWeight = 60
            locColumn.DisplayIndex = 6
            locColumn.HeaderText = "Effektivstunden:"
            locColumn.MinimumWidth = 60
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            locColumn.DefaultCellStyle.Font = locCellFont
            locColumn.Name = "AttendanceTime"
            .Add(locColumn)

            'Prämie
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            locColumn.FillWeight = 85
            locColumn.DisplayIndex = 7
            locColumn.HeaderText = "Prämie:"
            locColumn.MinimumWidth = 85
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            locColumn.DefaultCellStyle.Font = locSpecialFont
            locColumn.Name = "IncentiveWage"
            .Add(locColumn)

            'Datentag (nicht sichtbar)
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.Visible = False
            locColumn.Name = "HasData"
            .Add(locColumn)

        End With
        dgvEmployeeWages.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvEmployeeWages.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
    End Sub

    Private Sub tsmQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmQuit.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub AssignSelectionFromTable()
        'Zunächst alle deselektieren
        For Each locItem As EmployeeAnalysisInfoItem In myAnalysisItems
            locItem.Selected = False
        Next
        For Each locRow As DataGridViewRow In dgvEmployeeWages.Rows
            If locRow.Selected Then
                'Das selektierte Item finden
                For Each locItem As EmployeeAnalysisInfoItem In myAnalysisItems
                    If CInt(locRow.Cells("IDEmployee").Value) = locItem.EmployeeWage.IDEmployee Then
                        locItem.Selected = True
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub PreselectData(ByVal SelectionMode As IncentiveWagePreSelectionMode)
        For Each locRow As DataGridViewRow In dgvEmployeeWages.Rows
            If SelectionMode = IncentiveWagePreSelectionMode.All Then
                locRow.Selected = True
            ElseIf SelectionMode = IncentiveWagePreSelectionMode.None Then
                locRow.Selected = False
            ElseIf SelectionMode = IncentiveWagePreSelectionMode.DataPresent Then
                If CBool(locRow.Cells("HasData").Value) Then
                    locRow.Selected = True
                Else
                    locRow.Selected = False
                End If
            Else
                Dim locIncentiveWage As Double
                If locRow.Tag IsNot Nothing Then
                    locIncentiveWage = CDbl(locRow.Tag)
                    If Math.Round(locIncentiveWage, 2) > 0 Then
                        locRow.Selected = True
                    Else
                        locRow.Selected = False
                    End If
                Else
                    locRow.Selected = False
                End If
            End If
        Next
    End Sub

    Private Sub tsmPrintWageList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmPrintWageList.Click
        AssignSelectionFromTable()
        Dim locPrintWageList As New FacPrintEmployeesWageList(myAnalysisItems, FacessoGeneric.LoginInfo.Username)
        locPrintWageList.ProcessDocument(AnalysisTarget.PreviewBeforePrint)
    End Sub

    Private Sub tsmPrintEmployeeWagesDetailed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmPrintEmployeeWagesDetailed.Click
        AssignSelectionFromTable()
        Dim locPrintWageStatements As New FacPrintEmployeesWageStatements(myAnalysisItems, FacessoGeneric.LoginInfo.Username)
        locPrintWageStatements.ProcessDocument(AnalysisTarget.PreviewBeforePrint)
    End Sub

    Private Sub tsmSelectWithData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSelectWithData.Click
        PreselectData(IncentiveWagePreSelectionMode.DataPresent)
    End Sub

    Private Sub TsmSelectWithIncentiveWage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsmSelectWithIncentiveWage.Click
        PreselectData(IncentiveWagePreSelectionMode.IncentiveWagePresent)
    End Sub

    Private Sub tsmSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSelectAll.Click
        PreselectData(IncentiveWagePreSelectionMode.All)
    End Sub

    Private Sub tsmDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDeselectAll.Click
        PreselectData(IncentiveWagePreSelectionMode.None)
    End Sub

    Private Sub frmIncentiveWageGroupResult_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PreselectData(IncentiveWagePreSelectionMode.DataPresent)
    End Sub

    Private Sub dgvEmployeeWages_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvEmployeeWages.ColumnHeaderMouseClick
        If e.ColumnIndex = dgvEmployeeWages.Columns("PersonnelNr").Index Then
            myAnalysisItems.SortByPersonnelNumber()
        ElseIf e.ColumnIndex = dgvEmployeeWages.Columns("LastnameFirstname").Index Then
            myAnalysisItems.SortByLastname()
        ElseIf e.ColumnIndex = dgvEmployeeWages.Columns("DegreeOfTime").Index Then
            myAnalysisItems.SortByDegreeOfTime()
        End If
        UpdateContent()
    End Sub

    Private Sub TsmCsvExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TsmCsvExport.Click
        AssignSelectionFromTable()
        Dim locPrintWageList As New FacPrintEmployeesWageList(myAnalysisItems, FacessoGeneric.LoginInfo.Username)
        locPrintWageList.ProcessDocument(AnalysisTarget.CSVExport)
    End Sub
End Class

Public Enum IncentiveWagePreSelectionMode
    All
    IncentiveWagePresent
    DataPresent
    None
End Enum