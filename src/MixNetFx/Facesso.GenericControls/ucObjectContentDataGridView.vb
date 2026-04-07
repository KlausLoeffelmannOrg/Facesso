Imports ActiveDev
Imports Facesso.Data
Imports System.Windows.Forms

Public MustInherit Class ucObjectContentDataGridView(Of ObjectType)
    Inherits DataGridView

    Private myObject As ObjectType

    Sub New()
        MyBase.New()
        Me.DoubleBuffered = True
    End Sub

    Public Overridable Property [Object]() As ObjectType
        Get
            Return myObject
        End Get
        Set(ByVal value As ObjectType)
            myObject = value
            If value Is Nothing Then
                Me.Rows.Clear()
            Else
                Me.Rows.Clear()
                InitializeHeaders()
                AssignValues()
            End If
        End Set
    End Property

    Protected MustOverride Sub AssignValues()

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
            'Eigenschaft
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.Width = 120
            locColumn.DisplayIndex = 0
            locColumn.HeaderText = "Eigenschaft:"
            locColumn.MinimumWidth = 50
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.False
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            locColumn.DefaultCellStyle.Font = locHeaderFont
            locColumn.Name = "Property"
            .Add(locColumn)

            'Wert
            locColumn = New DataGridViewColumn(New DataGridViewTextBoxCell())
            locColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            locColumn.FillWeight = 500
            locColumn.DisplayIndex = 1
            locColumn.HeaderText = "Wert:"
            locColumn.MinimumWidth = 100
            locColumn.ReadOnly = True
            locColumn.Resizable = DataGridViewTriState.False
            locColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
            locColumn.DefaultCellStyle.Font = locCellFont
            locColumn.Name = "Value"
            .Add(locColumn)

        End With
        Me.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
        Me.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
    End Sub
End Class

