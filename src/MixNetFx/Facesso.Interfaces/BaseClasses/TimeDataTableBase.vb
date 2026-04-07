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

Public Class TimeDataTable
    Inherits DataTable
    Implements IEnumerable, ITimeLogImportResultTable

    Sub New()
        With Me.Columns
            .Add("ID", GetType(Integer))
            .Add("EmployeeNo", GetType(Integer))
            .Add("EmployeeDescription", GetType(String))
            .Add("AlienEmployeeNo", GetType(Integer))
            .Add("WorkgroupNo", GetType(Integer))
            .Add("WorkgroupDescription", GetType(String))
            ' Zum Beispiel eine Kostenstelle einer Kostenstellenbuchung eines Fremdsystems oder eine WorkEntityNo in Legatro
            .Add("AlienID", GetType(Integer))
            .Add("StartTime", GetType(Date))
            .Add("EndTime", GetType(Date))
            .Add("Shift", GetType(Byte))
            .Add("DownTime", GetType(Integer))
            .Add("WorkBreak", GetType(Integer))
            .Add("Handicap", GetType(Double))
            .Add("HasDiscrepancies", GetType(Boolean))
            .Add("DiscrepanciesText", GetType(String))
        End With
        Me.Columns("ID").AutoIncrementSeed = 1
        Me.Columns("ID").AutoIncrementStep = 1
        Me.Columns("ID").AutoIncrement = True
    End Sub

    Public Sub AddTimeDataRow(ByVal pdRow As TimeDataRow)
        Me.Rows.Add(pdRow)
    End Sub

    Public Function NewTimeDataRow() As TimeDataRow
        Return DirectCast(Me.NewRow(), TimeDataRow)
    End Function

    Protected Overrides Function NewRowFromBuilder(ByVal builder As System.Data.DataRowBuilder) As System.Data.DataRow
        Return New TimeDataRow(builder)
    End Function

    Protected Overrides Function GetRowType() As System.Type
        Return GetType(TimeDataRow)
    End Function

    Public Overridable Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return Me.Rows.GetEnumerator
    End Function

    Default Public ReadOnly Property Item(ByVal index As Integer) As TimeDataRow
        Get
            Return CType(Me.Rows(index), TimeDataRow)
        End Get
    End Property

    ''' <summary>
    ''' Ermittelt den primäre Quell-Identifizierer, der dann mit SetPrimaryDestinationIdentifier in den Facesso-Standard konvertiert werden kann (Kostenstelle-->Produktivsite).
    ''' </summary>
    ''' <param name="Index">Nummer der Zeile in der Quelltabelle.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPrimarySourceIdentifier(ByVal Index As Integer) As Integer Implements IImportResultTable.GetPrimarySourceIdentifier
        Return Me(Index).WorkgroupNo
    End Function

    ''' <summary>
    ''' Setzt den primäre Quell-Identifizierer, der mit GetPrimaryDestinationIdentifier in den Facesso-Standard konvertiert werden kann (Kostenstelle-->Produktivsite).
    ''' </summary>
    ''' <param name="Index"></param>
    ''' <param name="DestId"></param>
    ''' <remarks></remarks>
    Public Sub SetPrimaryDestinationIdentifier(ByVal Index As Integer, ByVal DestId As Integer) Implements IImportResultTable.SetPrimaryDestinationIdentifier
        Me(Index).AlienID = DestId
    End Sub

    ''' <summary>
    ''' Ermittelt die Anzahl der Zeilen in der Konvertierungstabelle.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Count() As Integer Implements IImportResultTable.Count
        Return Me.Rows.Count
    End Function

    ''' <summary>
    ''' Ermittelt den sekundären Quell-Identifizierer, der dann mit SetSecondaryDestinationIdentifier in den Facesso-Standard konvertiert werden kann (Fremd-Personal-ID in Facesso-Personalnummer).
    ''' </summary>
    ''' <param name="Index">Nummer der Zeile in der Quelltabelle.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSecondarySourceIdentifier(ByVal Index As Integer) As Integer Implements ITimeLogImportResultTable.GetSecondarySourceIdentifier
        Return Me(Index).EmployeeNo
    End Function

    ''' <summary>
    ''' Setzt den sekundären Quell-Identifizierer, der mit GetSecondaryDestinationIdentifier in den Facesso-Standard konvertiert werden kann (Fremd-Personal-ID in Facesso-Personalnummer).
    ''' </summary>
    ''' <param name="Index">Nummer der Zeile in der Quelltabelle.</param>
    ''' <remarks></remarks>
    Public Sub SetSecondaryDestinationIdentifier(ByVal Index As Integer, ByVal DestID As Integer) Implements ITimeLogImportResultTable.SetSecondaryDestinationIdentifier
        Me(Index).AlienEmployeeNo = DestID
    End Sub

    Public ReadOnly Property TimeDataRows() As IEnumerable(Of TimeDataRow)
        Get
            Dim tmpList As New List(Of TimeDataRow)
            For Each rowItem In Me.Rows
                tmpList.Add(DirectCast(rowItem, TimeDataRow))
            Next
            Return tmpList
        End Get
    End Property
End Class

Public Class TimeDataRow
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

    Public Property EmployeeNo() As Integer
        Get
            Return CInt(Me.Item("EmployeeNo"))
        End Get
        Set(ByVal value As Integer)
            Me.Item("EmployeeNo") = value
        End Set
    End Property

    Public Property EmployeeDescription() As String
        Get
            Return Me.Item("EmployeeDescription").ToString
        End Get
        Set(ByVal value As String)
            Me.Item("EmployeeDescription") = value
        End Set
    End Property

    Public Property AlienEmployeeNo() As Integer
        Get
            Return CInt(Me.Item("AlienEmployeeNo"))
        End Get
        Set(ByVal value As Integer)
            Me.Item("AlienEmployeeNo") = value
        End Set
    End Property

    Public Property WorkgroupNo() As Integer
        Get
            Return CInt(Me.Item("WorkgroupNo"))
        End Get
        Set(ByVal value As Integer)
            Me.Item("WorkgroupNo") = value
        End Set
    End Property

    Public Property WorkgroupDescription() As String
        Get
            Return Me.Item("WorkgroupDescription").ToString
        End Get
        Set(ByVal value As String)
            Me.Item("WorkgroupDescription") = value
        End Set
    End Property

    Public Property AlienID() As Integer
        Get
            Return CInt(Me.Item("AlienID"))
        End Get
        Set(ByVal value As Integer)
            Me.Item("AlienID") = value
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

    Public Property Shift() As Byte
        Get
            Return CByte(Me.Item("Shift"))
        End Get
        Set(ByVal value As Byte)
            Me.Item("Shift") = value
        End Set
    End Property

    Public Property DownTime() As Integer
        Get
            Return CInt(Me.Item("DownTime"))
        End Get
        Set(ByVal value As Integer)
            Me.Item("DownTime") = value
        End Set
    End Property

    Public Property WorkBreak() As Integer
        Get
            Return CInt(Me.Item("WorkBreak"))
        End Get
        Set(ByVal value As Integer)
            Me.Item("WorkBreak") = value
        End Set
    End Property

    Public Property Handicap() As Double?
        Get
            Return If((Me.Item("Handicap")) Is DBNull.Value, Nothing, CDbl(Me.Item("Handicap")))
        End Get
        Set(ByVal value As Double?)
            Me.Item("Handicap") = value
        End Set
    End Property

    Public Property HasDiscrepancies() As Boolean
        Get
            Return CBool(Me.Item("HasDiscrepancies"))
        End Get
        Set(ByVal value As Boolean)
            Me.Item("HasDiscrepancies") = value
        End Set
    End Property

    Public Property DiscrepanciesText() As String
        Get
            Return Me.Item("DiscrepanciesText").ToString
        End Get
        Set(ByVal value As String)
            Me.Item("DiscrepanciesText") = value
        End Set
    End Property
End Class
