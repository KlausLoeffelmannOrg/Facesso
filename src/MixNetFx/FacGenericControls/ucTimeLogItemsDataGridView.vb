Imports ActiveDev
Imports Facesso.Data
Imports System.Windows.Forms

Public Class ucTimeLogItemsDataGridView
    Inherits DataGridView

    Private myEmployeeTimeLogItems As EmployeeTimeLogInfo
    Private mySingleEmployeeList As Boolean
    Private myWorkGroups As WorkGroupInfoItems
    Public Event TimeLogItemDoubleClick(ByVal sender As Object, ByVal e As TimeLogItemClickEventArgs)

    Sub New()
        MyBase.New()
        Me.DoubleBuffered = True
    End Sub

    Sub AssignData()
        InitializeHeaders()
        If myWorkGroups Is Nothing Then
            myWorkGroups = New WorkGroupInfoItems(True)
        End If
        If myEmployeeTimeLogItems Is Nothing Then
            Return
        End If
        For Each locEi As EmployeeTimeLogInfoItem In myEmployeeTimeLogItems
            Me.Rows.Add(New Object() _
                {locEi.IDTimeLog, _
                 locEi.EmployeeInfo.PersonnelNumber, _
                 locEi.EmployeeInfo.LastName & ", " & locEi.EmployeeInfo.FirstName, _
                 myWorkGroups(New IntKey(locEi.IDWorkGroup)).DisplayName, _
                 locEi.Shift, _
                 locEi.ShiftStart, _
                 locEi.ShiftEnd, _
                 locEi.WorkBreak, _
                 locEi.DownTime, _
                 locEi.Handicap, _
                 locEi.TimeDeltaStrings})
        Next
    End Sub

    Public Property EmployeeTimeLogItems() As EmployeeTimeLogInfo
        Get
            Return myEmployeeTimeLogItems
        End Get
        Set(ByVal value As EmployeeTimeLogInfo)
            If value Is Nothing Then
                Me.Rows.Clear()
                myEmployeeTimeLogItems = Nothing
                Return
            End If
            Me.Rows.Clear()
            myEmployeeTimeLogItems = value
            AssignData()
        End Set
    End Property

    Public ReadOnly Property SelectedEmployeeTimeLogItems() As EmployeeTimeLogInfo
        Get
            Dim locEtli As New EmployeeTimeLogInfo
            For Each locRow As DataGridViewRow In Me.Rows
                If locRow.Selected Then
                    locEtli.Add(myEmployeeTimeLogItems(CLng(Me("IDTimeLog", locRow.Index).Value)))
                End If
            Next
            Return locEtli
        End Get
    End Property

    Public Sub SelectEmployeeItems(ByVal Etli As EmployeeTimeLogInfo)
        Me.ClearSelection()
        For Each locSourceRow As EmployeeTimeLogInfoItem In Etli
            For Each locDestRow As DataGridViewRow In Me.Rows
                If CLng(locDestRow.Cells("IDTimeLog").Value) = locSourceRow.IDTimeLog Then
                    locDestRow.Selected = True
                End If
            Next
        Next
    End Sub

    Public Property SingleEmployeeList() As Boolean
        Get
            Return mySingleEmployeeList
        End Get
        Set(ByVal value As Boolean)
            If value <> mySingleEmployeeList Then
                mySingleEmployeeList = value
                AssignData()
            End If
        End Set
    End Property

    Sub InitializeHeaders()

        Dim locColumn As DataGridViewColumn
        Dim locDateCell As New DataGridViewTextBoxCell
        locDateCell.MaxInputLength = 8
        Dim locIntCell As New DataGridViewTextBoxCell
        locIntCell.MaxInputLength = 6

        Dim locHeaderFont As New Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold)
        Dim locCellFont As New Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular)

        Me.ColumnHeadersDefaultCellStyle.Font = locHeaderFont
        Me.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.AllowUserToAddRows = False
        Me.AllowUserToDeleteRows = False
        Me.AllowUserToOrderColumns = False

        With Me.Columns
            .Clear()
            'ID (nicht sichtbar)
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.Visible = False
            locColumn.Name = "IDTimeLog"
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
            locColumn.Visible = Not SingleEmployeeList

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
            locColumn.Visible = Not SingleEmployeeList
            .Add(locColumn)

            'Produktiv-Site
            locColumn = New DataGridViewColumn(locDateCell)
            locColumn.Width = 150
            locColumn.DisplayIndex = 2
            locColumn.HeaderText = "Produktiv-Site"
            locColumn.MinimumWidth = 100
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            locColumn.DefaultCellStyle.Font = locCellFont
            locColumn.Name = "ShiftStart"
            locColumn.Visible = mySingleEmployeeList
            .Add(locColumn)

            'Schicht
            locColumn = New DataGridViewColumn(locIntCell)
            locColumn.Width = 75
            locColumn.DisplayIndex = 3
            locColumn.HeaderText = "Schicht"
            locColumn.MinimumWidth = 50
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            locColumn.DefaultCellStyle.Font = locCellFont
            locColumn.DefaultCellStyle.Format = "0"
            locColumn.Visible = SingleEmployeeList
            locColumn.Name = "Schicht"
            .Add(locColumn)


            'Startzeit
            locColumn = New DataGridViewColumn(locDateCell)
            locColumn.DisplayIndex = 4
            locColumn.HeaderText = "Start"
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            locColumn.DefaultCellStyle.Font = locCellFont
            If SingleEmployeeList Then
                locColumn.DefaultCellStyle.Format = "dd.MM.yy; HH:mm"
                locColumn.Width = 120
                locColumn.MinimumWidth = 80
            Else
                locColumn.DefaultCellStyle.Format = "(ddd), HH:mm"
                locColumn.Width = 75
                locColumn.MinimumWidth = 50
            End If
            locColumn.Name = "ShiftStart"
            .Add(locColumn)

            'Endzeit
            locColumn = New DataGridViewColumn(locDateCell)
            locColumn.DisplayIndex = 5
            locColumn.HeaderText = "Ende"
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            locColumn.DefaultCellStyle.Font = locCellFont
            If SingleEmployeeList Then
                locColumn.DefaultCellStyle.Format = "dd.MM.yy; HH:mm"
                locColumn.Width = 120
                locColumn.MinimumWidth = 80
            Else
                locColumn.DefaultCellStyle.Format = "(ddd), HH:mm"
                locColumn.Width = 75
                locColumn.MinimumWidth = 50
            End If
            locColumn.Name = "ShiftEnd"
            .Add(locColumn)

            'Pause
            locColumn = New DataGridViewColumn(locIntCell)
            locColumn.Width = 75
            locColumn.DisplayIndex = 6
            locColumn.HeaderText = "Pause"
            locColumn.MinimumWidth = 50
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            locColumn.DefaultCellStyle.Font = locCellFont
            locColumn.DefaultCellStyle.Format = "#,##0"
            locColumn.Name = "Pause"
            .Add(locColumn)

            'Ausfallzeit
            locColumn = New DataGridViewColumn(locIntCell)
            locColumn.Width = 75
            locColumn.DisplayIndex = 7
            locColumn.HeaderText = "Ausfall"
            locColumn.MinimumWidth = 50
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            locColumn.DefaultCellStyle.Font = locCellFont
            locColumn.DefaultCellStyle.Format = "#,##0"
            locColumn.Name = "DownTime"
            .Add(locColumn)

            'Handycap
            locColumn = New DataGridViewColumn(locIntCell)
            locColumn.Width = 75
            locColumn.DisplayIndex = 8
            locColumn.HeaderText = "Handicap"
            locColumn.MinimumWidth = 50
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            locColumn.DefaultCellStyle.Font = locCellFont
            locColumn.DefaultCellStyle.Format = "##0 \%"
            locColumn.Visible = Not SingleEmployeeList
            locColumn.Name = "Handycap"
            .Add(locColumn)

            'Zeiten
            locColumn = New DataGridViewColumn(locIntCell)
            locColumn.Width = 150
            locColumn.DisplayIndex = 9
            locColumn.HeaderText = "Zeitendelta"
            locColumn.MinimumWidth = 50
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            locColumn.DefaultCellStyle.Font = locCellFont
            locColumn.Name = "DeltaTimes"
            .Add(locColumn)
        End With
        Me.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
        Me.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
    End Sub

    Protected Overrides Sub OnCellDoubleClick(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        MyBase.OnCellDoubleClick(e)
        If e.RowIndex >= 0 Then
            RaiseEvent TimeLogItemDoubleClick(Me, New TimeLogItemClickEventArgs( _
            myEmployeeTimeLogItems(CLng(Me("IDTimeLog", e.RowIndex).Value))))
        End If
    End Sub

    Protected Overrides Sub OnCellEndEdit(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        MyBase.OnCellEndEdit(e)
        If Me.SelectedRows.Count = 1 Then
            'Nur eine Zelle, dann in diesem Stil:
            'Me.EmployeeItems.Item(e.RowIndex).Amount = CDbl(Me.CurrentRow.Cells("Amount").Value)
            'Me.CurrentRow.Cells("SubTotal").Value = Me.ProductionData.Item(e.RowIndex).SubTotal
        Else
            'Mehrere markierte Zellen, dann in diesem Stil:
            'Dim locAmount As Double = CDbl(Me.CurrentRow.Cells("Amount").Value)
            'For Each locRow As DataGridViewRow In Me.SelectedRows
            '    Me.ProductionData.Item(locRow.Index).Amount = locAmount
            '    locRow.Cells("Amount").Value = locAmount
            '    locRow.Cells("SubTotal").Value = Me.ProductionData.Item(locRow.Index).SubTotal
            'Next
        End If
    End Sub

    Protected Overrides Sub OnCellValidating(ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs)
        'Dim locFormular As String = e.FormattedValue.ToString
        'Dim locFormParser As New ActiveDev.ADFormularParser(locFormular)
        'Try
        '    Dim locTest As Double = locFormParser.Result
        'Catch ex As Exception
        '    MessageBox.Show("Beim Auswerten der Formel ist ein Fehler aufgetreten." & vbNewLine & _
        '                    "Bitte korrigieren Sie Ihre Eingabe!", "Fehler in Ausdruck:", MessageBoxButtons.OK, _
        '                     MessageBoxIcon.Error)
        '    e.Cancel = True
        '    Return
        'End Try
        'MyBase.OnCellValidating(e)
    End Sub

    Protected Overrides Sub OnCellParsing(ByVal e As System.Windows.Forms.DataGridViewCellParsingEventArgs)
        'MyBase.OnCellParsing(e)
        'Dim locFormular As String = e.Value.ToString
        'Dim locFormParser As New ActiveDev.ADFormularParser(locFormular)
        'e.Value = locFormParser.Result
        'e.ParsingApplied = True
    End Sub
End Class

Public Class TimeLogItemClickEventArgs
    Inherits EventArgs

    Private myTimeLogItem As EmployeeTimeLogInfoItem

    Sub New(ByVal tli As EmployeeTimeLogInfoItem)
        myTimeLogItem = tli
    End Sub

    Public Property EmployeeTimeLogItem() As EmployeeTimeLogInfoItem
        Get
            Return myTimeLogItem
        End Get
        Set(ByVal value As EmployeeTimeLogInfoItem)
            myTimeLogItem = value
        End Set
    End Property
End Class

