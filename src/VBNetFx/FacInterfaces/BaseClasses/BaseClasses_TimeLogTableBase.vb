Public Interface ITimeLogImportResultTable
    Inherits IImportResultTable
    ''' <summary>
    ''' Liefert den Wert des sekundären Quell-Identifizierers der angegebenen Zeile. Dieser Quell-Identifizierer 
    ''' hält die Daten einer zu konvertierenden ID. Beispielsweise ist er die Kostenstelle einer BDE, die dann 
    ''' in eine Arbeitsgruppe umgewandelt wird.
    ''' </summary>
    ''' <param name="Index">Nummer der Zeile, dessen sekundärer Quell-Identifizierer abgerufen werden soll.</param>
    ''' <returns>Integer-Wert mit dem konvertierten Wert.</returns>
    ''' <remarks></remarks>
    Function GetSecondarySourceIdentifier(ByVal Index As Integer) As Integer
    ''' <summary>
    ''' Bestimmt den Wert des sekundären Quell-Identifizierers der angegebenen Zeile. Dieser Quell-Identifizierer 
    ''' hält die Daten einer zu konvertierenden ID. Beispielsweise ist er die Kostenstelle einer BDE, die dann 
    ''' in eine Arbeitsgruppe umgewandelt wird.
    ''' </summary>
    ''' <param name="Index">Nummer der Zeile, dessen sekundärer Quell-Identifizierer abgerufen werden soll.</param>
    ''' <param name="DestID">Die neue ID, durch die die alte ersetzt werden soll.</param>
    ''' <remarks></remarks>
    Sub SetSecondaryDestinationIdentifier(ByVal Index As Integer, ByVal DestID As Integer)
End Interface

Public Class TimeLogDataTable
    Inherits DataTable
    Implements IEnumerable, ITimeLogImportResultTable

    Sub New()
        With Me.Columns
            .Add("ID", GetType(Integer))
            .Add("IDEmployeeExt", GetType(Integer))
            .Add("IDWorkGroupExt", GetType(Integer))
            .Add("StartTime", GetType(Date))
            .Add("EndTime", GetType(Date))
        End With
        Me.Columns("ID").AutoIncrementSeed = 1
        Me.Columns("ID").AutoIncrementStep = 1
        Me.Columns("ID").AutoIncrement = True
    End Sub

    Public Sub AddTimeLogDataRow(ByVal pdRow As TimeLogDataRow)
        Me.Rows.Add(pdRow)
    End Sub

    Public Function NewTimeLogDataRow() As TimeLogDataRow
        Return DirectCast(Me.NewRow(), TimeLogDataRow)
    End Function

    Protected Overrides Function NewRowFromBuilder(ByVal builder As System.Data.DataRowBuilder) As System.Data.DataRow
        Return New TimeLogDataRow(builder)
    End Function

    Protected Overrides Function GetRowType() As System.Type
        Return GetType(TimeLogDataRow)
    End Function

    Public Overridable Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return Me.Rows.GetEnumerator
    End Function

    Default Public ReadOnly Property Item(ByVal index As Integer) As TimeLogDataRow
        Get
            Return CType(Me.Rows(index), TimeLogDataRow)
        End Get
    End Property

    Public Function Count() As Integer Implements IImportResultTable.Count
        Return Me.Rows.Count
    End Function

    Public Function GetPrimarySourceIdentifier(ByVal Index As Integer) As Integer Implements IImportResultTable.GetPrimarySourceIdentifier
        Return Me(Index).IDEmployeeExt
    End Function

    Public Sub SetPrimaryDestinationIdentifier(ByVal Index As Integer, ByVal DestId As Integer) Implements IImportResultTable.SetPrimaryDestinationIdentifier
        Me(Index).IDEmployeeExt = DestId
    End Sub

    Public Function GetSecondarySourceIdentifier(ByVal Index As Integer) As Integer Implements ITimeLogImportResultTable.GetSecondarySourceIdentifier
        Return Me(Index).IDWorkgroupExt
    End Function

    Public Sub SetSecondaryDestinationIdentifier(ByVal Index As Integer, ByVal DestID As Integer) Implements ITimeLogImportResultTable.SetSecondaryDestinationIdentifier
        Me(Index).IDWorkGroupExt = DestId
    End Sub
End Class

Public Class TimeLogDataRow
    Inherits DataRow

    Sub New(ByVal rb As DataRowBuilder)
        MyBase.new(rb)
    End Sub

    ''' <summary>
    ''' Ermittelt die laufende ID des Datensatzes. Auto-Inkrement-Wert.
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
    ''' Ermittelt die ID der externen Personalnummer der PZE, die in die Facesso-Employee-ID konvertiert werden soll.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IDEmployeeExt() As Integer
        Get
            Return CInt(Me.Item("IDEmployeeExt"))
        End Get
        Set(ByVal value As Integer)
            Me.Item("IDEmployeeExt") = value
        End Set
    End Property

    ''' <summary>
    ''' Ermittelt die ID der externen Produktiv-Site-ID einer PZE, die in die Facesso-WorkGroup-ID konvertiert werden soll.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IDWorkGroupExt() As Integer
        Get
            Return CInt(Me.Item("IDWorkGroupExt"))
        End Get
        Set(ByVal value As Integer)
            Me.Item("IDWorkGroupExt") = value
        End Set
    End Property

    ''' <summary>
    ''' Die zu konvertierende Startzeit aus der externen PZE.
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
    ''' Die zu konvertierende Endzeit aus der externen PZE.
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
End Class


