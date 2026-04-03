Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports ActiveDev
Imports System.Collections.ObjectModel
Imports System.Windows.Forms

''' <summary>
''' Hält alle Parameter, die zu einer Produktiv-Site-Auswertung gehören
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public Class WorkGroupAnalysisParameters
    Private myDateRange As DateRangeParameter
    Private myShiftParameters As ShiftParameters
    Private myWorkgroups As WorkGroupInfoItems
    Private myAnalysisType As WorkgroupAnalysisType
    Private myIncludeSuspended As Boolean
    Private myIncludeWorkload As Boolean
    Private myAnalysisTarget As AnalysisTarget
    Private myMenuName As String
    Private myName As String
    Private myMenuIndex As Integer
    Private mySelectedWorkgroups As Collection(Of Integer)

    Sub New()
        MyBase.New()
    End Sub

    Public Property DateRange() As DateRangeParameter
        Get
            Return myDateRange
        End Get
        Set(ByVal value As DateRangeParameter)
            myDateRange = value
        End Set
    End Property

    Public Property ShiftParameters() As ShiftParameters
        Get
            Return myShiftParameters
        End Get
        Set(ByVal value As ShiftParameters)
            myShiftParameters = value
        End Set
    End Property

    <XmlIgnore()> _
    Public Property WorkGroups() As WorkGroupInfoItems
        Get
            Return myWorkgroups
        End Get
        Set(ByVal value As WorkGroupInfoItems)
            myWorkgroups = value
            mySelectedWorkgroups = New Collection(Of Integer)
            For Each locItem As WorkGroupInfo In myWorkgroups
                mySelectedWorkgroups.Add(locItem.IDWorkGroup)
            Next
        End Set
    End Property

    Public Property SelectedWorkgroups() As Collection(Of Integer)
        Get
            Return mySelectedWorkgroups
        End Get
        Set(ByVal value As Collection(Of Integer))
            mySelectedWorkgroups = value
        End Set
    End Property

    Public Property AnalysisType() As WorkgroupAnalysisType
        Get
            Return myAnalysisType
        End Get
        Set(ByVal value As WorkgroupAnalysisType)
            myAnalysisType = value
        End Set
    End Property

    Public Property IncludeSuspended() As Boolean
        Get
            Return myIncludeSuspended
        End Get
        Set(ByVal value As Boolean)
            myIncludeSuspended = value
        End Set
    End Property

    Public Property IncludeWorkLoad() As Boolean
        Get
            Return myIncludeWorkload
        End Get
        Set(ByVal value As Boolean)
            myIncludeWorkload = value
        End Set
    End Property

    Public Property AnalysisTarget() As AnalysisTarget
        Get
            Return myAnalysisTarget
        End Get
        Set(ByVal value As AnalysisTarget)
            myAnalysisTarget = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return myName
        End Get
        Set(ByVal value As String)
            myName = value
        End Set
    End Property

    ''' <summary>
    ''' Der Menü- oder Registerkartenname der Analyse.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MenuName() As String
        Get
            Return myMenuName
        End Get
        Set(ByVal value As String)
            myMenuName = value
        End Set
    End Property

    Public Property MenuIndex() As Integer
        Get
            Return myMenuIndex
        End Get
        Set(ByVal value As Integer)
            myMenuIndex = value
        End Set
    End Property

    Public Property WorkgroupAnalysisBehaviour As WorkgroupAnalysisBehaviours
    Public Property WorkgroupAnalysisCount As Integer?
    Public Property ChartType As ChartType
    Public Property AutomaticChartDeltaRange As Boolean
    Public Property ChartDeltaFromValue As Integer
    Public Property ChartDeltaToValue As Integer
    Public Property ChartTitel As String

    Public Overrides Function ToString() As String
        Return Me.Name
    End Function

    Public Function Description() As String
        Dim locString As String
        locString = "Zusammenfassung der Analyseparameter:" & vbNewLine & vbNewLine
        Select Case AnalysisType
            Case WorkgroupAnalysisType.Batch
                locString &= "Stapelausdruck."
            Case WorkgroupAnalysisType.Detailed
                locString &= "Detaillierter Ausdruck als Stapel."
            Case WorkgroupAnalysisType.WorkGroupListShiftwiseWorkLoad
                locString &= "Linienanalyse."
            Case WorkgroupAnalysisType.WorkGroupListShiftCondensed
                locString &= "Liste der ausgewählten Arbeitsgruppen mit einem Element pro Tag. Die Daten der angegebenen Daten werden verdichtet."
            Case WorkgroupAnalysisType.WorkGroupListShiftwise
                locString &= "Liste der ausgewählten Arbeitsgruppen, mit einer Einzelaufstellung der Schichten. Die Daten im angegebenen Zeitraum werden Produktiv-Site-weise verdichtet."
            Case WorkgroupAnalysisType.WorkGroupListShiftwiseCompressed
                locString &= "Kompakte Liste der ausgewählten Arbeitsgruppen, mit einer Einzelaufstellung der Schichten. Die Daten im angegebenen Zeitraum werden Produktiv-Site-weise verdichtet."
        End Select

        locString &= vbNewLine & vbNewLine
        locString &= "Ausgewählter Datumsbereich:" & vbNewLine
        locString &= DateRange.ToString & vbNewLine & vbNewLine

        locString &= "Einzubeziehende Schichten:" & vbNewLine
        locString &= ShiftParameters.ToString
        Return locString
    End Function
End Class

<Serializable()> _
Public Class WorkGroupAnalysisParametersCollection
    Inherits Collection(Of WorkGroupAnalysisParameters)

    Sub New()
        MyBase.new()
    End Sub

    Public Function ToXmlString() As String
        Dim locXml As New XmlSerializer(GetType(WorkGroupAnalysisParametersCollection))
        Dim locSw As New StringWriter()
        locXml.Serialize(locSw, Me)
        Return locSw.ToString
    End Function

    Public Shared Function FromXmlString(ByVal XmlString As String) As WorkGroupAnalysisParametersCollection
        Dim locXml As New XmlSerializer(GetType(WorkGroupAnalysisParametersCollection))
        Dim locSr As New StringReader(XmlString)
        Return DirectCast(locXml.Deserialize(locSr), WorkGroupAnalysisParametersCollection)
    End Function

    Public Shared Function FromFile(ByVal filename As FileInfo) As WorkGroupAnalysisParametersCollection
        Try
            If Not filename.Directory.Exists Then
                filename.Directory.Create()
            End If
            If Not filename.Exists Then
                Return Nothing
            End If
            Using locSr As StreamReader = New StreamReader(filename.FullName)
                Dim locString As String
                locString = locSr.ReadToEnd
                locSr.Close()
                Return FromXmlString(locString)
            End Using
        Catch ex As Exception
            MessageBox.Show("Die Analysen-Definitionsdatei '" & filename.Name & "' konnte nicht gelesen werden:" & vbNewLine & vbNewLine & _
            ex.Message, "Fehler beim Lesen der Datei!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return Nothing
        End Try
    End Function

    Public Sub ToFile(ByVal filename As FileInfo)
        Try
            If Not filename.Directory.Exists Then
                filename.Directory.Create()
            End If
            Using locSw As StreamWriter = New StreamWriter(filename.FullName)
                locSw.Write(Me.ToXmlString())
                locSw.Flush()
                locSw.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Die Analysen-Definitionsdatei '" & filename.Name & "' konnte nicht geschrieben werden:" & vbNewLine & vbNewLine & _
            ex.Message, "Fehler beim Schreiben der Analyse-Settings!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
End Class

Public Enum WorkgroupAnalysisBehaviours
    Best
    Worst
    Selected
End Enum

Public Enum ChartType
    Chart2DLine
    Chart3DLine
End Enum

Public Enum WorkgroupAnalysisType
    Detailed
    Batch
    WorkGroupListShiftCondensed
    WorkGroupListShiftwise
    WorkGroupListShiftwiseCompressed
    WorkGroupListShiftwiseWorkLoad
End Enum

Public Enum AnalysisTarget
    DirectlyToPrinter
    PreviewBeforePrint
    CSVExport
    Chart
End Enum
