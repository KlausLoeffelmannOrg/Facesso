Imports Facesso.Data
Imports System.Windows.Forms

Public Class ucProductionDataGridView
    Inherits DataGridView

    Private myProductionDataItems As ProductionData
    Private myRowHeightToRestore As Integer
    Private myOnlyShowActivatedLabourValues As Boolean

    Sub New()
        MyBase.New()
        myOnlyShowActivatedLabourValues = False
        Me.DoubleBuffered = True
    End Sub

    Sub AssignData()
        InitializeHeaders()
        For Each locPDI As ProductionDataItem In myProductionDataItems
            If (OnlyShowActivatedLabourValues And locPDI.LabourValue.IsActive) Or (Not OnlyShowActivatedLabourValues) Then
                Me.Rows.Add(New Object() _
                    {locPDI.LabourValue.LabourValueNumber, _
                     locPDI.LabourValue.LabourValueName, _
                     locPDI.Amount, _
                     locPDI.LabourValue.Dimension, _
                     locPDI.LabourValue.TeHMin, _
                     locPDI.SubTotal, _
                     locPDI.LabourValue.IDLabourValue})
            End If
        Next
    End Sub

    Public Property OnlyShowActivatedLabourValues() As Boolean
        Get
            Return myOnlyShowActivatedLabourValues
        End Get
        Set(ByVal value As Boolean)
            If value <> myOnlyShowActivatedLabourValues Then
                myOnlyShowActivatedLabourValues = value
                If ProductionData IsNot Nothing Then
                    Me.Rows.Clear()
                    AssignData()
                End If
            End If
        End Set
    End Property

    Public Property ProductionData() As ProductionData
        Get
            Return myProductionDataItems
        End Get
        Set(ByVal value As ProductionData)
            If value Is Nothing Then
                Me.Rows.Clear()
                myProductionDataItems = Nothing
                Return
            End If
            If value IsNot myProductionDataItems Then
                Me.Rows.Clear()
                myProductionDataItems = value
                AssignData()
            End If
        End Set
    End Property

    Protected Overrides Function SetCurrentCellAddressCore(ByVal columnIndex As Integer, ByVal rowIndex As Integer, ByVal setAnchorCellAddress As Boolean, ByVal validateCurrentCell As Boolean, ByVal throughMouseClick As Boolean) As Boolean
        If rowIndex > -1 Then
            If columnIndex <> 2 Then
                columnIndex = 2
            End If
        End If
        Return MyBase.SetCurrentCellAddressCore(columnIndex, rowIndex, setAnchorCellAddress, validateCurrentCell, throughMouseClick)
    End Function

    Sub InitializeHeaders()

        Dim locColumn As DataGridViewColumn
        Dim locTextCell As New DataGridViewTextBoxCell

        Dim locHeaderFont As New Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold)
        Dim locCellFont As New Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular)

        Me.ColumnHeadersDefaultCellStyle.Font = locHeaderFont
        Me.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.AllowUserToAddRows = False
        Me.AllowUserToDeleteRows = False
        Me.AllowUserToOrderColumns = False

        With Me.Columns
            .Clear()
            'Arbeitswertnummer
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.Width = 60
            locColumn.DisplayIndex = 0
            locColumn.HeaderText = "AW-Nr.:"
            locColumn.MinimumWidth = 50
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            locColumn.DefaultCellStyle.Font = locHeaderFont
            locColumn.Name = "LabourValueNumber"
            .Add(locColumn)

            'Arbeitswertname
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            locColumn.FillWeight = 500
            locColumn.DisplayIndex = 1
            locColumn.HeaderText = "Arbeitswertname:"
            locColumn.MinimumWidth = 100
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
            locColumn.DefaultCellStyle.Font = locCellFont
            locColumn.Name = "LabourValueName"
            .Add(locColumn)

            'Menge
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.Width = 120
            locColumn.DisplayIndex = 2
            locColumn.HeaderText = "Produktionsmenge:"
            locColumn.MinimumWidth = 100
            locColumn.ReadOnly = False
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            locColumn.DefaultCellStyle.Font = locCellFont
            locColumn.Name = "Amount"
            locColumn.DefaultCellStyle.Format = "#,##0.00"
            .Add(locColumn)

            'Dimension
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.Width = 75
            locColumn.DisplayIndex = 3
            locColumn.HeaderText = "Einheit:"
            locColumn.MinimumWidth = 100
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            locColumn.DefaultCellStyle.Font = locCellFont
            locColumn.Name = "Dimension"
            .Add(locColumn)

            'TeInHMin
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.Width = 75
            locColumn.DisplayIndex = 4
            locColumn.HeaderText = "te in HMin:"
            locColumn.MinimumWidth = 100
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            locColumn.DefaultCellStyle.Font = locCellFont
            locColumn.Name = "Amount"
            .Add(locColumn)

            'Summe
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.Width = 75
            locColumn.DisplayIndex = 5
            locColumn.HeaderText = "Summe:"
            locColumn.MinimumWidth = 100
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.True
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            locColumn.DefaultCellStyle.Font = locHeaderFont
            locColumn.Name = "Subtotal"
            locColumn.DefaultCellStyle.Format = "#,##0.00"
            .Add(locColumn)

            'IDLabourvalue (nicht sichtbar)
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.ReadOnly = True
            locColumn.Visible = False
            locColumn.Name = "IDLabourValue"
            locColumn.DisplayIndex = 6
            .Add(locColumn)
        End With
        Me.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
        Me.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
    End Sub

    Protected Overrides Sub OnCellEndEdit(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        MyBase.OnCellEndEdit(e)
        If Me.SelectedRows.Count = 1 Then
            Me.ProductionData.Item(ProductionDataItemsIndex(e.RowIndex)).Amount = CDbl(Me.CurrentRow.Cells("Amount").Value)
            Me.ProductionData.Item(ProductionDataItemsIndex(e.RowIndex)).ManuallyEdited = True
            Me.CurrentRow.Cells("SubTotal").Value = Me.ProductionData.Item(ProductionDataItemsIndex(e.RowIndex)).SubTotal
        Else
            Dim locAmount As Double = CDbl(Me.CurrentRow.Cells("Amount").Value)
            For Each locRow As DataGridViewRow In Me.SelectedRows
                Me.ProductionData.Item(ProductionDataItemsIndex(locRow.Index)).Amount = locAmount
                Me.ProductionData.Item(ProductionDataItemsIndex(locRow.Index)).ManuallyEdited = True
                locRow.Cells("Amount").Value = locAmount
                locRow.Cells("SubTotal").Value = Me.ProductionData.Item(ProductionDataItemsIndex(locRow.Index)).SubTotal
            Next
        End If
    End Sub

    Protected Overrides Sub OnCellValidating(ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs)
        Dim locFormular As String = e.FormattedValue.ToString
        Dim locFormParser As New ActiveDev.ADFormularParser(locFormular)
        Try
            Dim locTest As Double = locFormParser.Result
        Catch ex As Exception
            MessageBox.Show("Beim Auswerten der Formel ist ein Fehler aufgetreten." & vbNewLine & _
                            "Bitte korrigieren Sie Ihre Eingabe!", "Fehler in Ausdruck:", MessageBoxButtons.OK, _
                             MessageBoxIcon.Error)
            e.Cancel = True
            Return
        End Try
        MyBase.OnCellValidating(e)
    End Sub

    Protected Overrides Sub OnCellParsing(ByVal e As System.Windows.Forms.DataGridViewCellParsingEventArgs)
        MyBase.OnCellParsing(e)
        Dim locFormular As String = e.Value.ToString
        Dim locFormParser As New ActiveDev.ADFormularParser(locFormular)
        e.Value = locFormParser.Result
        e.ParsingApplied = True
    End Sub

    Private Function ProductionDataItemsIndex(ByVal currentRowIndex As Integer) As Integer
        Dim locIDLabourValue As Integer = CInt(Me.Rows(currentRowIndex).Cells("IDLabourValue").Value)
        For locIndex As Integer = 0 To ProductionData.Count - 1
            If ProductionData(locIndex).LabourValue.IDLabourValue = locIDLabourValue Then
                Return locIndex
            End If
        Next
        Return -1
    End Function
End Class

