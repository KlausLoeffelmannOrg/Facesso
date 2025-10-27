Public Class TimeSplitDataTable
    Inherits DataTable
    Implements IEnumerable

    Sub New()
        With Me.Columns
            .Add("ID", GetType(Integer))
            .Add("ProductionDate", GetType(Date))
            .Add("Shift", GetType(Byte))
            .Add("StartTime", GetType(Date))
            .Add("EndTime", GetType(Date))
            .Add("InShiftProRata", GetType(Double))
            .Add("FromOriginalProRata", GetType(Double))
        End With
        Me.Columns("ID").AutoIncrementSeed = 1
        Me.Columns("ID").AutoIncrementStep = 1
        Me.Columns("ID").AutoIncrement = True
    End Sub

    Public Sub AddProductionDataRow(ByVal pdRow As TimeSplitDataRow)
        Me.Rows.Add(pdRow)
    End Sub

    Public Function NewProductionDataRow() As TimeSplitDataRow
        Return DirectCast(Me.NewRow(), TimeSplitDataRow)
    End Function

    Protected Overrides Function NewRowFromBuilder(ByVal builder As System.Data.DataRowBuilder) As System.Data.DataRow
        Return New TimeSplitDataRow(builder)
    End Function

    Protected Overrides Function GetRowType() As System.Type
        Return GetType(TimeSplitDataRow)
    End Function

    Public Overridable Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return Me.Rows.GetEnumerator
    End Function

    Default Public ReadOnly Property Item(ByVal index As Integer) As TimeSplitDataRow
        Get
            Return CType(Me.Rows(index), TimeSplitDataRow)
        End Get
    End Property

    Public Function Count() As Integer
        Return Me.Rows.Count
    End Function
End Class

''' <summary>
''' Hält einen Datums-Datensatz eines Zeitbereichs, der über mehrere Abschnitte getrennt werden musste.
''' </summary>
''' <remarks></remarks>
Public Class TimeSplitDataRow
    Inherits DataRow

    Sub New(ByVal rb As DataRowBuilder)
        MyBase.new(rb)
    End Sub

    ''' <summary>
    ''' Eindeutige ID des Datensatzes.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ID() As Integer
        Get
            Return CInt(Me.Item("ID"))
        End Get
        Set(ByVal value As Integer)
            Me.Item("ID") = value
        End Set
    End Property

    ''' <summary>
    ''' Produktionsdatum für den Teildatensatz.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ProductionDate() As Date
        Get
            Return CDate(Me.Item("ProductionDate"))
        End Get
        Set(ByVal value As Date)
            Me.Item("ProductionDate") = value
        End Set
    End Property

    ''' <summary>
    ''' Die zugeordnete Schicht für diesen Teildatensatz.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Shift() As Byte
        Get
            Return CByte(Me.Item("Shift"))
        End Get
        Set(ByVal value As Byte)
            Me.Item("Shift") = value
        End Set
    End Property

    ''' <summary>
    ''' Die Startzeit des Teildatensatzes
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StartTime() As Date
        Get
            Return CDate(Me.Item("StartTime"))
        End Get
        Set(ByVal value As Date)
            Me.Item("StartTime") = value
        End Set
    End Property

    ''' <summary>
    ''' Die Endzeit des Teildatensatzes
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EndTime() As Date
        Get
            Return CDate(Me.Item("EndTime"))
        End Get
        Set(ByVal value As Date)
            Me.Item("EndTime") = value
        End Set
    End Property

    ''' <summary>
    ''' Zu welchem Teil der Zeitbereich komplett im Schichtbereich befindet (0-1)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InShiftProRata() As Double
        Get
            Return CDbl(Me.Item("InShiftProRata"))
        End Get
        Set(ByVal value As Double)
            Me.Item("InShiftProRata") = value
        End Set
    End Property

    ''' <summary>
    ''' Welcher Teil (0-1) der neue Zeitbereich anteilig den ursprünglichen Zeitbereich ausmachte.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FromOriginalProRata() As Double
        Get
            Return CDbl(Me.Item("FromOriginalProRata"))
        End Get
        Set(ByVal value As Double)
            Me.Item("FromOriginalProRata") = value
        End Set
    End Property
End Class
