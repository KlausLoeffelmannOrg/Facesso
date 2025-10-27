Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Imports System.Windows.Forms

Public Class ADAutoReportView
    Inherits ListView

    Private myColumnNames As SortedList(Of Integer, ADAutoReportColumn)
    Private myIList As IList
    Private myHelperOrderNo As Integer
    Private myListViewMode As AutoReportMode

    Sub New()
        MyBase.New()
        'Auf Detailansicht umschalten
        Me.View = Windows.Forms.View.Details
        'Bei Fokusverlust Markierung dennoch anzeigen
        Me.HideSelection = False
        'Ganze Reihe soll selektiert werden
        Me.FullRowSelect = True
        myHelperOrderNo = UShort.MaxValue + 1
        myListViewMode = AutoReportMode.Details
    End Sub

#Region "Elemente-Klassen (privat)"

    'Speichert eine einzelne Spalteneinstellung
    Private Class ADAutoReportColumn

        Private myPropertyName As String
        Private myDisplayName As String
        Private myColumnWidth As Integer
        Private myOrderNo As Integer
        Private myPurpose As AutoReportPurpose

        Sub New(ByVal PropertyName As String, ByVal Displayname As String)
            myPropertyName = PropertyName
            myDisplayName = Displayname
        End Sub

        'Speichert den Eigenschaftennamen
        Public Property PropertyName() As String
            Get
                Return myPropertyName
            End Get
            Set(ByVal Value As String)
                myPropertyName = Value
            End Set
        End Property

        'Steuert die Ausgabe
        Public Property Purpose() As AutoReportPurpose
            Get
                Return myPurpose
            End Get
            Set(ByVal value As AutoReportPurpose)
                myPurpose = value
            End Set
        End Property

        'Speichert den Namen dieser Eigenschaft, der als Spaltentitel
        'angezeigt werden soll.
        Public Property DisplayName() As String
            Get
                Return myDisplayName
            End Get
            Set(ByVal Value As String)
                myDisplayName = Value
            End Set
        End Property

        'Speichert die Spaltenbreite
        Public Property ColumnWidth() As Integer
            Get
                Return myColumnWidth
            End Get
            Set(ByVal Value As Integer)
                myColumnWidth = Value
            End Set
        End Property

        'Speichert die Rangfolgennr. für das Sortieren der Spalten
        Public Property OrderNo() As Integer
            Get
                Return myOrderNo
            End Get
            Set(ByVal Value As Integer)
                myOrderNo = Value
            End Set
        End Property
    End Class
#End Region

    Public Property ListViewMode() As AutoReportMode
        Get
            Return myListViewMode
        End Get
        Set(ByVal value As AutoReportMode)
            myListViewMode = value
        End Set
    End Property

    Public Property List() As IList
        Get
            Return myIList
        End Get

        'Setzen der Eigenschaft:
        Set(ByVal Value As IList)
            Me.BeginUpdate()
            'Alle Inhalte löschen
            Me.Items.Clear()
            'Allte Spaltentitel löschen
            Me.Columns.Clear()
            If Value Is Nothing Then
                'Abbrechen, falls Nothing zugewiesen wurde
                Me.EndUpdate()
                Return
            Else
                'Liste zuweisen
                myIList = Value
                'Die Spaltennamen und Objekteigenschaften entweder durch das Objekt
                'selbst oder zugewiesene Attribute ermitteln und in myColumnNamens 
                'speichern.
                myColumnNames = GetColumnNames(Value)
                'Anschließend die Spaltentitel setzen...
                SetupColumns()
                '...und die Liste mit Einträgen füllen, die sich aus myIList ergeben
                SetupEntries()
            End If
            Me.EndUpdate()
        End Set
    End Property

    'Spaltentitel einsetzen
    Private Sub SetupColumns()
        With Me.Columns
            'TODO: Das Alignment könnte auch in Attributen untergebracht werden
            For Each kvp As KeyValuePair(Of Integer, ADAutoReportColumn) In myColumnNames
                .Add(kvp.Value.DisplayName, kvp.Value.ColumnWidth, Windows.Forms.HorizontalAlignment.Left)
            Next
        End With
    End Sub

    'Einträge in die Liste schreiben
    Private Sub SetupEntries()
        For Each obj As Object In myIList
            With Me.Items
                Dim locLvi As New ListViewItem
                locLvi.Tag = obj
                Dim locFirstHandled As Boolean = False
                'Erste darzustellende Eigenschaft erfährt Sonderbehandlung,
                'da sie nicht durch SubItems dargestellt wird
                'Mit GetPropValue wird die Stringumwandlung der Eigenschaft
                'eines Objektes ermittelt.
                For Each locColumn As KeyValuePair(Of Integer, ADAutoReportColumn) In myColumnNames
                    If Not locFirstHandled Then
                        locLvi.Text = GetPropValue(obj, locColumn.Value.PropertyName)
                        locFirstHandled = True
                    Else
                        locLvi.SubItems.Add(GetPropValue(obj, locColumn.Value.PropertyName))
                    End If
                Next
                .Add(locLvi)
            End With
        Next

        'Spaltenbreiten anpassen
        Dim ccount As Integer = 0
        For Each kvp As KeyValuePair(Of Integer, ADAutoReportColumn) In myColumnNames
            Me.Columns(ccount).Width = kvp.Value.ColumnWidth
            ccount += 1
        Next
    End Sub

    'Ermittelt den Inhalt der Eigenschaft eines Objektes als String
    Private Function GetPropValue(ByVal [object] As Object, ByVal PropertyName As String) As String

        Dim locPI As PropertyInfo = [object].GetType.GetProperty(PropertyName)
        Return locPI.GetValue([object], Nothing).ToString
    End Function

    'Ermittelt die durch die Objekteigenschaften vorgegebenen dazustellenden
    'Spalten, wenn keine Attribute verwendet werden. Werden Attribute verwendet,
    'ermittelt die Funktion nur die Eigenschaften eines Objektes, die mit einem
    'entsprechenden Attribut versehen sind.
    Private Function GetColumnNames(ByVal List As IList) As SortedList(Of Integer, ADAutoReportColumn)

        Dim locTypeToExamine As Type
        Dim locARCs As New SortedList(Of Integer, ADAutoReportColumn)
        Dim locExplicitlyDefined As Boolean = False

        If List Is Nothing Then
            'Soweit dürfte es eigentlich gar nicht kommen, aber wir gehen auf No. sicher.
            Dim Up As New NullReferenceException("Die Übergebende Liste ist leer!")
            Throw Up
        End If

        'Das erste Objekt ist maßgeblich für die Typen aller anderen Objekte.
        'Die Liste muss also homogen (Objektableitungen ausgenommen) sein, damit 
        'die automatische Element-Zuweisung reibungslos funktioniert.
        locTypeToExamine = List(0).GetType

        'Alle Eigenschaften des Objektes durchforsten
        For Each pi As PropertyInfo In locTypeToExamine.GetProperties
            'Nach Attributen Ausschau halten
            For Each a As Attribute In pi.GetCustomAttributes(True)
                'Nur reagieren, wenn es sich um unseren speziellen Typ handelt
                If TypeOf a Is ADAutoReportColumnAttribute Then
                    Dim locARC As New ADAutoReportColumn(pi.Name, pi.Name)
                    'Parameter aus dem Attribute-Objekt übernehmen
                    locARC.DisplayName = a.GetType.GetProperty("DisplayName").GetValue(a, Nothing).ToString
                    locARC.ColumnWidth = CInt(a.GetType.GetProperty("ColumnWidth").GetValue(a, Nothing))
                    locARC.OrderNo = CInt(a.GetType.GetProperty("OrderNo").GetValue(a, Nothing))
                    locARC.Purpose = CType(a.GetType.GetProperty("Purpose").GetValue(a, Nothing), AutoReportPurpose)
                    If locARC.OrderNo = 0 Then
                        locARC.OrderNo = myHelperOrderNo
                        myHelperOrderNo += 1
                    End If
                    If ((locARC.Purpose And AutoReportPurpose.ShowInDetailsTable) = AutoReportPurpose.ShowInDetailsTable) And _
                        (Me.ListViewMode = AutoReportMode.Details) Or _
                        ((locARC.Purpose And AutoReportPurpose.ShowInVerboseTable) = AutoReportPurpose.ShowInVerboseTable) And _
                        (Me.ListViewMode = AutoReportMode.Verbose) Then
                        locARCs.Add(locARC.OrderNo, locARC)
                        Exit For
                    End If
                End If
            Next
            'Zur Spaltenkopf-Parameterliste hinzufügen
        Next
        Return locARCs
    End Function
End Class

Public Enum AutoReportMode
    Details
    Verbose
End Enum

Public Enum AutoReportPurpose
    None = 0
    ShowInDetailsTable = 1
    ShowInVerboseTable = 2
    PrintInDetailsList = 4
    PrintInVerboseList = 8
End Enum

'Dieses Attribut kann nur auf Eigenschaften angewendet werden
<AttributeUsage(AttributeTargets.Property)> _
Public Class ADAutoReportColumnAttribute
    Inherits Attribute

    Private myDisplayName As String
    Private myPurpose As AutoReportPurpose
    Private myColumnWidth As Integer
    Private myOrderNo As Integer
    'Vorgabe-Reihenfolgenr. für den Fall, dass diese nicht mit angegeben wurde
    Private Shared myDefaultOrderNo As Integer

    Shared Sub New()
        myDefaultOrderNo = 1
    End Sub

    'Konstruktoren, die den Darstellungsnamen...
    Sub New(ByVal DisplayName As String)
        myPurpose = AutoReportPurpose.PrintInDetailsList Or AutoReportPurpose.ShowInDetailsTable
        myDisplayName = DisplayName
        myColumnWidth = -2
        myOrderNo = myDefaultOrderNo
        myDefaultOrderNo += 1
    End Sub

    '...und optional die Breite der Tabellenspalte bestimmen...
    Sub New(ByVal displayName As String, ByVal colomnWidth As Integer)
        myPurpose = AutoReportPurpose.PrintInDetailsList Or AutoReportPurpose.ShowInDetailsTable
        myDisplayName = displayName
        myColumnWidth = colomnWidth
        myOrderNo = myDefaultOrderNo
        myDefaultOrderNo += 1
    End Sub

    Sub New(ByVal displayName As String, ByVal colomnWidth As Integer, ByVal purpose As AutoReportPurpose)
        myPurpose = purpose
        myDisplayName = displayName
        myColumnWidth = colomnWidth
        myOrderNo = myDefaultOrderNo
        myDefaultOrderNo += 1
    End Sub

    '...sowie die Reihenfolge der Spalte.
    Sub New(ByVal displayName As String, ByVal columnWidth As Integer, ByVal orderNo As Integer)
        myPurpose = AutoReportPurpose.PrintInDetailsList Or AutoReportPurpose.ShowInDetailsTable
        myDisplayName = displayName
        myColumnWidth = columnWidth
        myOrderNo = orderNo
        If orderNo > myDefaultOrderNo Then
            myDefaultOrderNo = orderNo + 1
        End If
    End Sub

    '...sowie die Reihenfolge der Spalte.
    Sub New(ByVal displayName As String, ByVal columnWidth As Integer, ByVal orderNo As Integer, ByVal purpose As AutoReportPurpose)
        myPurpose = purpose
        myPurpose = AutoReportPurpose.PrintInDetailsList Or AutoReportPurpose.ShowInDetailsTable
        myDisplayName = displayName
        myColumnWidth = columnWidth
        myOrderNo = orderNo
        If orderNo > myDefaultOrderNo Then
            myDefaultOrderNo = orderNo + 1
        End If
    End Sub

    'Steuert die Ausgabe
    Public Property Purpose() As AutoReportPurpose
        Get
            Return myPurpose
        End Get
        Set(ByVal value As AutoReportPurpose)
            myPurpose = value
        End Set
    End Property

    'Name des Spaltenkopfs
    Public Property DisplayName() As String
        Get
            Return myDisplayName
        End Get
        Set(ByVal Value As String)
            myDisplayName = Value
        End Set
    End Property

    'Spaltenbreite
    Public Property ColumnWidth() As Integer
        Get
            Return myColumnWidth
        End Get
        Set(ByVal Value As Integer)
            myColumnWidth = Value
        End Set
    End Property

    'Sortierschlüssel
    Public Property OrderNo() As Integer
        Get
            Return myOrderNo
        End Get
        Set(ByVal Value As Integer)
            myOrderNo = Value
        End Set
    End Property
End Class


