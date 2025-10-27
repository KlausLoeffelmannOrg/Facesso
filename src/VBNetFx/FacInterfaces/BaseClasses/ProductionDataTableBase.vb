Public Interface IImportResultTable
    ''' <summary>
    ''' Ermittelt die Anzahl der vorhandenen Zeilen mit Import-Daten, die für die Konvertierung anstehen.
    ''' </summary>
    ''' <returns>Interger-Wert, der die Anzahl der Zeilen repräsentiert.</returns>
    ''' <remarks></remarks>
    Function Count() As Integer
    ''' <summary>
    ''' Liefert den Wert des primären Quell-Identifizierers der angegebenen Zeile. Dieser Quell-Identifizierer 
    ''' hält die Daten einer zu konvertierenden ID. Beispielsweise ist er die Programmnummer, die dann 
    ''' in einen Arbeitswert umgewandelt wird, oder die Personalnummer-ID eines externen BDE-Dateinsatzes, 
    ''' die dann in die Employee-ID umgewandelt wird.
    ''' </summary>
    ''' <param name="Index">Nummer der Zeile, dessen primärer Quell-Identifizierer abgerufen werden soll.</param>
    ''' <returns>Integer-Wert mit dem konvertierten Wert.</returns>
    ''' <remarks></remarks>
    Function GetPrimarySourceIdentifier(ByVal Index As Integer) As Integer
    ''' <summary>
    ''' Bestimmt den Wert des primären Quell-Identifizierers der angegebenen Zeile. Dieser Quell-Identifizierer 
    ''' hält die Daten einer zu konvertierenden ID. Beispielsweise ist er die Programmnummer, die dann 
    ''' in einen Arbeitswert umgewandelt wird, oder die Personalnummer-ID eines externen BDE-Dateinsatzes, 
    ''' die dann in die Employee-ID umgewandelt wird.
    ''' </summary>
    ''' <param name="Index">Nummer der Zeile, dessen primärer Quell-Identifizierer abgerufen werden soll.</param>
    ''' <param name="DestID">Die neue ID, durch die die alte ersetzt werden soll.</param>
    ''' <remarks></remarks>
    Sub SetPrimaryDestinationIdentifier(ByVal Index As Integer, ByVal DestID As Integer)
End Interface

Public Class ProductionDataTable
    Inherits DataTable
    Implements IEnumerable, IImportResultTable

    Sub New()
        With Me.Columns
            .Add("ID", GetType(Integer))
            .Add("ProgramNo", GetType(Integer))
            .Add("IDLabourValue", GetType(Integer))
            .Add("Shift", GetType(Byte))
            .Add("StartTime", GetType(Date))
            .Add("EndTime", GetType(Date))
            .Add("TotalAmount", GetType(Double))
        End With
        Me.Columns("ID").AutoIncrementSeed = 1
        Me.Columns("ID").AutoIncrementStep = 1
        Me.Columns("ID").AutoIncrement = True
    End Sub

    Public Sub AddProductionDataRow(ByVal pdRow As ProductionDataRow)
        Me.Rows.Add(pdRow)
    End Sub

    Public Function NewProductionDataRow() As ProductionDataRow
        Return DirectCast(Me.NewRow(), ProductionDataRow)
    End Function

    Protected Overrides Function NewRowFromBuilder(ByVal builder As System.Data.DataRowBuilder) As System.Data.DataRow
        Return New ProductionDataRow(builder)
    End Function

    Protected Overrides Function GetRowType() As System.Type
        Return GetType(ProductionDataRow)
    End Function

    Public Overridable Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return Me.Rows.GetEnumerator
    End Function

    Default Public ReadOnly Property Item(ByVal index As Integer) As ProductionDataRow
        Get
            Return CType(Me.Rows(index), ProductionDataRow)
        End Get
    End Property

    Public Function Count() As Integer Implements IImportResultTable.Count
        Return Me.Rows.Count
    End Function

    Public Function GetPrimarySourceIdentifier(ByVal Index As Integer) As Integer Implements IImportResultTable.GetPrimarySourceIdentifier
        Return Me(Index).ProgramNo
    End Function

    Public Sub SetPrimaryDestinationIdentifier(ByVal Index As Integer, ByVal DestID As Integer) Implements IImportResultTable.SetPrimaryDestinationIdentifier
        Me(Index).IDLabourValue = DestId
    End Sub
End Class

Public Class ProductionDataRow
    Inherits DataRow

    Sub New(ByVal rb As DataRowBuilder)
        MyBase.new(rb)
    End Sub

    Public Property ID() As Integer
        Get
            Return CInt(Me.Item("ID"))
        End Get
        Set(ByVal value As Integer)
            Me.Item("ID") = value
        End Set
    End Property

    Public Property ProgramNo() As Integer
        Get
            Return CInt(Me.Item("ProgramNo"))
        End Get
        Set(ByVal value As Integer)
            Me.Item("ProgramNo") = value
        End Set
    End Property

    Public Property IDLabourValue() As Integer
        Get
            Return CInt(Me.Item("IDLabourValue"))
        End Get
        Set(ByVal value As Integer)
            Me.Item("IDLabourValue") = value
        End Set
    End Property

    Public Property Shift() As Byte
        Get
            Return CByte(Me.Item("Shift"))
        End Get
        Set(ByVal value As Byte)
            Me.Item("Shift") = value
        End Set
    End Property

    Public Property StartTime() As Date
        Get
            Return CDate(Me.Item("StartTime"))
        End Get
        Set(ByVal value As Date)
            Me.Item("StartTime") = value
        End Set
    End Property

    Public Property EndTime() As Date
        Get
            Return CDate(Me.Item("EndTime"))
        End Get
        Set(ByVal value As Date)
            Me.Item("EndTime") = value
        End Set
    End Property

    Public Property TotalAmount() As Double
        Get
            Return CDbl(Me.Item("TotalAmount"))
        End Get
        Set(ByVal value As Double)
            Me.Item("TotalAmount") = value
        End Set
    End Property
End Class
