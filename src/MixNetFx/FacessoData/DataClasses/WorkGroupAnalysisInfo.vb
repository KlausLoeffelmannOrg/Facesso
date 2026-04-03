Imports Facesso
Imports System.Data.SqlClient
Imports ActiveDev

''' <summary>
''' Kapselt die Daten des kleisten Berechnungselements (bestimmte Arbeitsgruppe, Schicht und Datum) für eine 
''' Produktiv-Site-Analyse, und stellt ein Element der WorkGroupAnalysisInfo-Auflistung dar.
''' </summary>
''' <remarks>Genauere Funktionsweise siehe WorkGroupAnalysisInfoItems-Auflistung.</remarks>
<CLSCompliant(True)> _
Public Class WorkGroupAnalysisInfoItem

    Private _IDProductionData As Long
    Private _WorkGroup As WorkGroupInfo
    Private _ProductionDate As Date
    Private _Shift As Byte
    Private _TotalReferenceIWT As Double
    Private _TotalEffectiveIWT As Double
    Private _TotalEffectiveIWTAdj As Double
    Private _TotalDownTime As Double
    Private _TotalWorkBreakTime As Double
    Private _DegreeOfTime As Double
    Private _DegreeOfTimeAdj As Double
    Private _IsSuspended As Boolean
    Private _HasData As Boolean

    Private _ParentWorkGroupAnalysisInfo As WorkGroupAnalysisInfo
    Private _Deleted As Boolean
    Private _CombinedData As Boolean

    Sub New()
        MyBase.New()
    End Sub

    Public Shared Operator +(ByVal Val1 As WorkGroupAnalysisInfoItem, ByVal Val2 As WorkGroupAnalysisInfoItem) As WorkGroupAnalysisInfoItem
        Dim locRet As WorkGroupAnalysisInfoItem = Val1.Clone
        locRet.Add(Val2)
        Return locRet
    End Operator

    Friend Sub Add(ByVal val2 As WorkGroupAnalysisInfoItem)
        Me._TotalDownTime += val2._TotalDownTime
        Me._TotalEffectiveIWT += val2._TotalEffectiveIWT
        Me._TotalEffectiveIWTAdj += val2._TotalEffectiveIWTAdj
        Me._TotalReferenceIWT += val2._TotalReferenceIWT
        Me._TotalWorkBreakTime += val2._TotalWorkBreakTime
        Me.RecalculateInternal()
        Me._CombinedData = True
        Me._HasData = Me._HasData Or val2.HasData
    End Sub

    Sub New(ByVal IDSubsidiary As Integer, ByVal cp As CombinedParametersInfo)
        _ProductionDate = cp.ProductionDate
        _Shift = cp.Shift
        _WorkGroup = cp.WorkGroup
        SPAccess.GetInstance.ProductionData_GetWorkGroupAnalysisItem(Me, IDSubsidiary, cp)
    End Sub

    Friend WriteOnly Property ParentWorkGroupAnalysisInfo() As WorkGroupAnalysisInfo
        Set(ByVal value As WorkGroupAnalysisInfo)
            _ParentWorkGroupAnalysisInfo = value
        End Set
    End Property

    Public Property WorkGroup() As WorkGroupInfo
        Get
            Return _WorkGroup
        End Get
        Set(ByVal value As WorkGroupInfo)
            _WorkGroup = value
        End Set
    End Property

    Public Property IDProductionData() As Long
        Get
            Return _IDProductionData
        End Get
        Set(ByVal value As Long)
            _IDProductionData = value
        End Set
    End Property

    Public Property ProductionDate() As Date
        Get
            Return _ProductionDate
        End Get
        Set(ByVal value As Date)
            _ProductionDate = value
        End Set
    End Property

    Public Property Shift() As Byte
        Get
            Return _Shift
        End Get
        Set(ByVal value As Byte)
            _Shift = value
        End Set
    End Property

    Public Property TotalReferenceIWT() As Double
        Get
            Return _TotalReferenceIWT
        End Get
        Set(ByVal value As Double)
            _TotalReferenceIWT = value
        End Set
    End Property

    Public Property TotalEffectiveIWT() As Double
        Get
            Return _TotalEffectiveIWT
        End Get
        Set(ByVal value As Double)
            _TotalEffectiveIWT = value
        End Set
    End Property

    Public Property TotalEffectiveIWTAdj() As Double
        Get
            Return _TotalEffectiveIWTAdj
        End Get
        Set(ByVal value As Double)
            _TotalEffectiveIWTAdj = value
        End Set
    End Property

    Public Property TotalDownTime() As Double
        Get
            Return _TotalDownTime
        End Get
        Set(ByVal value As Double)
            _TotalDownTime = value
        End Set
    End Property

    Public Property TotalWorkBreakTime() As Double
        Get
            Return _TotalWorkBreakTime
        End Get
        Set(ByVal value As Double)
            _TotalWorkBreakTime = value
        End Set
    End Property

    Public ReadOnly Property TotalAttendanceTime() As Double
        Get
            Return TotalEffectiveIWT + TotalDownTime + TotalWorkBreakTime
        End Get
    End Property

    Public ReadOnly Property TotalWorkingTime() As Double
        Get
            Return TotalEffectiveIWT + TotalDownTime
        End Get
    End Property

    Public Property DegreeOfTime() As Double
        Get
            Return _DegreeOfTime
        End Get
        Set(ByVal value As Double)
            _DegreeOfTime = value
        End Set
    End Property

    Public Property DegreeOfTimeAdj() As Double
        Get
            Return _DegreeOfTimeAdj
        End Get
        Set(ByVal value As Double)
            _DegreeOfTimeAdj = value
        End Set
    End Property

    Public Property IsSuspended() As Boolean
        Get
            Return _IsSuspended
        End Get
        Set(ByVal value As Boolean)
            _IsSuspended = value
        End Set
    End Property

    Public Property HasData() As Boolean
        Get
            Return _HasData
        End Get
        Set(ByVal value As Boolean)
            _HasData = value
        End Set
    End Property

    Public ReadOnly Property AttendanceTimeDeltaStrings() As String
        Get
            Dim locString As String
            locString = "Gesamt:  " + TotalAttendanceTime.ToString("#,##0") & " Min." + vbNewLine
            locString &= "Arbeit:  " + TotalWorkingTime.ToString("#,##0") & " Min."
            Return locString
        End Get
    End Property

    Public ReadOnly Property GeneralBreakTimeStrings() As String
        Get
            Dim locString As String
            locString = "Pausen:  " + TotalWorkBreakTime.ToString("#,##0") & " Min." + vbNewLine
            locString &= "Ausfall:  " + TotalDownTime.ToString("#,##0") & " Min."
            Return locString
        End Get
    End Property

    Public ReadOnly Property IncentiveTimeDeltaStrings() As String
        Get
            Dim locString As String
            locString = "Referenz:  " + TotalReferenceIWT.ToString("#,##0") & " Min." + vbNewLine
            locString &= "Effektiv:  " + TotalEffectiveIWT.ToString("#,##0") & " Min." + vbNewLine
            locString &= "angepasst:  " + TotalEffectiveIWTAdj.ToString("#,##0") & " Min."
            Return locString
        End Get
    End Property

    ''' <summary>
    ''' Zeigt an, ob die Wertedaten dieses Item durch eine Addition-Operation mit einem anderen zusammengefasst wurden.
    ''' </summary>
    ''' <value>Boolscher Wert, der True ist, wenn eine Addition stattgefunden hat, mehrere Items kombiniert wurden.</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CombinedData() As Boolean
        Get
            Return _CombinedData
        End Get
    End Property

    Public Function Clone() As WorkGroupAnalysisInfoItem
        Dim retItem As New WorkGroupAnalysisInfoItem
        retItem._CombinedData = Me._CombinedData
        retItem._DegreeOfTime = Me._DegreeOfTime
        retItem._DegreeOfTimeAdj = Me._DegreeOfTimeAdj
        retItem._Deleted = Me._Deleted
        retItem._HasData = Me._HasData
        retItem._IDProductionData = Me._IDProductionData
        retItem._IsSuspended = Me._IsSuspended
        retItem._ParentWorkGroupAnalysisInfo = Me._ParentWorkGroupAnalysisInfo
        retItem._ProductionDate = Me._ProductionDate
        retItem._Shift = Me._Shift
        retItem._TotalDownTime = Me._TotalDownTime
        retItem._TotalEffectiveIWT = Me._TotalEffectiveIWT
        retItem._TotalEffectiveIWTAdj = Me._TotalEffectiveIWTAdj
        retItem._TotalReferenceIWT = Me._TotalReferenceIWT
        retItem._TotalWorkBreakTime = Me._TotalWorkBreakTime
        retItem._TotalWorkBreakTime = Me._TotalWorkBreakTime
        retItem._WorkGroup = Me._WorkGroup
        Return retItem
    End Function

    Private Sub RecalculateInternal()
        _DegreeOfTime = _TotalReferenceIWT / _TotalEffectiveIWT * 100
        _DegreeOfTimeAdj = _TotalReferenceIWT / _TotalEffectiveIWTAdj * 100
    End Sub
End Class

''' <summary>
''' Stellt die Funktionalität und Ergebnisklasse für die Auswertung einer Produktiv-Site dar, 
''' und ein Element der WorkGroupAnalysisInfoItems-Auflistung, mit der die Auswertung parametrisiert wird.
''' </summary>
''' <remarks>Genauere Funktionsweise siehe WorkGroupAnalysisInfoItems-Auflistung.</remarks>
Public Class WorkGroupAnalysisInfo
    Inherits System.Collections.ObjectModel.KeyedCollection(Of Long, WorkGroupAnalysisInfoItem)

    Private _WorkGroup As WorkGroupInfo
    Private _Period As ProductionPeriod
    Private _UsedTicket As DateTime
    Private _IDSubsidiary As Integer
    Private _IDUser As Integer
    Private _HasData As Boolean

    Private _NextAutoCountID As Integer

    Private _TotalReferenceIWT As Double
    Private _TotalAttendanceTime As Double
    Private _TotalDownTime As Double
    Private _TotalWorkingTime As Double
    Private _TotalEffectiveIWT As Double
    Private _TotalEffectiveIWTAdj As Double
    Private _TotalWorkBreakTime As Double
    Private _TotalWorkloadIWT As Double
    Private _DegreeOfTime As Double
    Private _DegreeOfTimeAdj As Double

    ''' <summary>
    ''' Dieser Konstruktor wird nur für interne Zwecke für die beiden statischen Verdichtungsfunktionen verwendet.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub New(ByVal wgi As WorkGroupAnalysisInfo)
        MyBase.new()
        _WorkGroup = wgi._WorkGroup
        _Period = wgi._Period
        _UsedTicket = wgi._UsedTicket
        _IDSubsidiary = wgi._IDSubsidiary
        _IDUser = wgi._IDUser
    End Sub

    ''' <summary>
    ''' Führt eine neue Produktiv-Site-Analyse durch und richtet die Params-Tabelle für den Auswertungszeitraum neu ein.
    ''' </summary>
    ''' <param name="IDSubsidiary">ID der Subsidiarität</param>
    ''' <param name="IDUser">ID des Benutzers, der die Auswertung einleitet.</param>
    ''' <param name="WorkGroup">Die Produktiv-Site, die ausgewertet werden soll.</param>
    ''' <param name="Period">Der Zeitraum, über den die Auswertung erfolgen soll.</param>
    ''' <remarks></remarks>
    Sub New(ByVal IDSubsidiary As Integer, ByVal IDUser As Integer, _
            ByVal WorkGroup As WorkGroupInfo, ByVal Period As ProductionPeriod)
        Dim locTicket As Date = Date.Now
        _IDSubsidiary = IDSubsidiary
        _IDUser = IDUser
        _Period = Period
        _WorkGroup = WorkGroup
        Period.PrepareProductionDates(IDSubsidiary, IDUser, locTicket)
        Dim tmpBln = SPAccess.GetInstance.ProductionData_GetWorkGroupAnalysisItems(IDSubsidiary, IDUser, locTicket, WorkGroup, Me)
        Me._HasData = tmpBln
        SPAccess.GetInstance.ProductionData_DeleteProductionDateItems(IDSubsidiary, IDUser, locTicket)
    End Sub

    ''' <summary>
    ''' Führt eine neue Produktiv-Site-Analyse durch, richtet die Params-Tabelle für den Auswertungszeitraum neu ein und behält diese im Bedarfsfall.
    ''' </summary>
    ''' <param name="IDSubsidiary">ID der Subsidiarität</param>
    ''' <param name="IDUser">ID des Benutzers, der die Auswertung einleitet.</param>
    ''' <param name="WorkGroup">Die Produktiv-Site, die ausgewertet werden soll.</param>
    ''' <param name="Period">Der Zeitraum, über den die Auswertung erfolgen soll.</param>
    ''' <param name="KeepParamsTable">Bestimmt, ob die Zeitraum-Parametertabelle für weitere Auswertungen im gleichen Zeitraum erhalten bleiben soll.</param>
    ''' <remarks></remarks>
    Sub New(ByVal IDSubsidiary As Integer, ByVal IDUser As Integer, _
            ByVal WorkGroup As WorkGroupInfo, ByVal Period As ProductionPeriod, _
            ByVal KeepParamsTable As Boolean)
        Dim locTicket As Date = Date.Now
        _IDSubsidiary = IDSubsidiary
        _IDUser = IDUser
        _Period = Period
        _WorkGroup = WorkGroup
        _UsedTicket = locTicket
        Period.PrepareProductionDates(IDSubsidiary, IDUser, locTicket)
        Dim tmpBln = SPAccess.GetInstance.ProductionData_GetWorkGroupAnalysisItems(IDSubsidiary, IDUser, locTicket, WorkGroup, Me)
        Me._HasData = tmpBln
        If Not KeepParamsTable Then
            SPAccess.GetInstance.ProductionData_DeleteProductionDateItems(IDSubsidiary, IDUser, locTicket)
        End If
    End Sub

    ''' <summary>
    ''' Führt eine neue Produktiv-Site-Analyse durch in einem Zeitraum, der durch eine bereits vorhandene Params-Tabelle bestimmt wird.
    ''' </summary>
    ''' <param name="IDSubsidiary">ID der Subsidiarität</param>
    ''' <param name="IDUser">ID des Benutzers, der die Auswertung einleitet.</param>
    ''' <param name="WorkGroup">Die Produktiv-Site, die ausgewertet werden soll.</param>
    ''' <param name="Ticket">Das Ticket, um mit diesem die Zeitraumparameter in der Params-Tabelle zu identifizieren.</param>
    ''' <remarks></remarks>
    Sub New(ByVal IDSubsidiary As Integer, ByVal IDUser As Integer, _
            ByVal WorkGroup As WorkGroupInfo, _
            ByVal Ticket As DateTime)
        Dim locTicket As Date = Date.Now
        _IDSubsidiary = IDSubsidiary
        _IDUser = IDUser
        _WorkGroup = WorkGroup
        _UsedTicket = Ticket
        Dim tmpbln = SPAccess.GetInstance.ProductionData_GetWorkGroupAnalysisItems(IDSubsidiary, IDUser, Ticket, WorkGroup, Me)
        Me._HasData = tmpbln
    End Sub

    ''' <summary>
    ''' Sorgt dafür, dass Params-Daten nach der Auswertung durch manuelles Triggern gelöscht werden.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CleanUp()
        SPAccess.GetInstance.ProductionData_DeleteProductionDateItems(_IDSubsidiary, _IDUser, _UsedTicket)
    End Sub

    Public Property WorkGroupInfo() As WorkGroupInfo
        Get
            Return _WorkGroup
        End Get
        Set(ByVal value As WorkGroupInfo)
            _WorkGroup = value
        End Set
    End Property

    ''' <summary>
    ''' Ermittelt, ob dieses Item über weitere Auflistungs-Daten verfügt, oder nicht.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property HasData As Boolean
        Get
            Return _HasData
        End Get
    End Property

    ''' <summary>
    ''' Ermittelt das verwendete Ticket (Benutzerabhängig, Zeitbasierend) für den Analysevorgang.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UsedTicket() As DateTime
        Get
            Return _UsedTicket
        End Get
    End Property

    Protected Overrides Function GetKeyForItem(ByVal item As WorkGroupAnalysisInfoItem) As Long
        Return item.IDProductionData
    End Function

    Protected Overrides Sub InsertItem(ByVal index As Integer, ByVal item As WorkGroupAnalysisInfoItem)
        item.ParentWorkGroupAnalysisInfo = Me
        If item.IDProductionData <= 0 Then
            item.IDProductionData = _NextAutoCountID
            _NextAutoCountID -= 1
        End If
        MyBase.InsertItem(index, item)
        Recalculate()
    End Sub

    Protected Overrides Sub ClearItems()
        MyBase.ClearItems()
        Recalculate()
    End Sub

    Protected Overrides Sub SetItem(ByVal index As Integer, ByVal item As WorkGroupAnalysisInfoItem)
        item.ParentWorkGroupAnalysisInfo = Me
        MyBase.SetItem(index, item)
        Recalculate()
    End Sub

    Public ReadOnly Property NextAutoCountID() As Integer
        Get
            Return _NextAutoCountID
        End Get
    End Property

    Public Property TotalReferenceIWT() As Double
        Get
            Return _TotalReferenceIWT
        End Get
        Set(ByVal value As Double)
            _TotalReferenceIWT = value
            Recalculate()
        End Set
    End Property

    Public ReadOnly Property TotalEffectiveIWT() As Double
        Get
            Return _TotalEffectiveIWT
        End Get
    End Property

    Public ReadOnly Property TotalEffectiveIWTAdj() As Double
        Get
            Return _TotalEffectiveIWTAdj
        End Get
    End Property

    Public ReadOnly Property DegreeOfTime() As Double
        Get
            Return _DegreeOfTime
        End Get
    End Property

    Public ReadOnly Property DegreeOfTimeAdj() As Double
        Get
            Return _DegreeOfTimeAdj
        End Get
    End Property

    Public ReadOnly Property TotalWorkBreakTime() As Double
        Get
            Return _TotalWorkBreakTime
        End Get
    End Property

    Public ReadOnly Property TotalDownTime() As Double
        Get
            Return _TotalDownTime
        End Get
    End Property

    Public ReadOnly Property TotalWorkloadIWT() As Double
        Get
            Return _TotalWorkloadIWT
        End Get
    End Property

    Public ReadOnly Property PercentageWorkload() As Double
        Get
            Return TotalEffectiveIWT / TotalWorkloadIWT * 100
        End Get
    End Property

    Public ReadOnly Property TotalWorkingTime() As Double
        Get
            Return _TotalWorkingTime
        End Get
    End Property

    Public ReadOnly Property TotalAttendanceTime() As Double
        Get
            Return _TotalAttendanceTime
        End Get
    End Property

    Public ReadOnly Property AttendanceTimeDeltaStrings() As String
        Get
            Dim locString As String
            locString = "Gesamt:  " + TotalAttendanceTime.ToString("#,##0") & " Min." + vbNewLine
            locString &= "Arbeit:  " + TotalWorkingTime.ToString("#,##0") & " Min."
            Return locString
        End Get
    End Property

    Public ReadOnly Property GeneralBreakTimeStrings() As String
        Get
            Dim locString As String
            locString = "Pausen:  " + TotalWorkBreakTime.ToString("#,##0") & " Min." + vbNewLine
            locString &= "Ausfall:  " + TotalDownTime.ToString("#,##0") & " Min."
            Return locString
        End Get
    End Property

    Public ReadOnly Property IncentiveTimeDeltaStrings() As String
        Get
            Dim locString As String
            locString = "Referenz:  " + TotalReferenceIWT.ToString("#,##0") & " Min." + vbNewLine
            locString &= "Effektiv:  " + TotalEffectiveIWT.ToString("#,##0") & " Min." + vbNewLine
            locString &= "angepasst:  " + TotalEffectiveIWTAdj.ToString("#,##0") & " Min."
            Return locString
        End Get
    End Property

    Friend Sub Recalculate()
        _TotalAttendanceTime = 0
        _TotalWorkingTime = 0
        _TotalDownTime = 0
        _TotalEffectiveIWT = 0
        _TotalEffectiveIWTAdj = 0
        _TotalWorkBreakTime = 0
        _TotalReferenceIWT = 0
        _TotalWorkloadIWT = 0
        If Me.Count = 0 Then
            Me._HasData = False
        Else
            Me._HasData = True
        End If

        For Each locItem As WorkGroupAnalysisInfoItem In Me

            _TotalAttendanceTime += locItem.TotalAttendanceTime
            _TotalWorkingTime += locItem.TotalWorkingTime
            _TotalDownTime += locItem.TotalDownTime
            _TotalEffectiveIWT += locItem.TotalEffectiveIWT
            _TotalEffectiveIWTAdj += locItem.TotalEffectiveIWTAdj
            _TotalWorkBreakTime += locItem.TotalWorkBreakTime
            _TotalReferenceIWT += locItem.TotalReferenceIWT
            _TotalWorkloadIWT += locItem.WorkGroup.WorkloadIWT
        Next
        _DegreeOfTime = _TotalReferenceIWT / _TotalEffectiveIWT * 100
        _DegreeOfTimeAdj = _TotalReferenceIWT / _TotalEffectiveIWTAdj * 100
    End Sub

    Protected Overrides Sub RemoveItem(ByVal index As Integer)
        MyBase.RemoveItem(index)
        Recalculate()
    End Sub

    ''' <summary>
    ''' Fasst alle Schichte einer Auswertung zu einer Liste mit der Summe aller Schichten zusammen
    ''' </summary>
    ''' <param name="wai">WorkGroupAnalysisInfo mit den Werten einzelner Schichten</param>
    ''' <returns>WorkGroupAnalysisInfo mit den aller Schichten zusammengefasster Werte</returns>
    ''' <remarks></remarks>
    Public Shared Function CompressShifts(ByVal wai As WorkGroupAnalysisInfo) As WorkGroupAnalysisInfo
        If wai Is Nothing Then
            Return Nothing
        End If

        Dim retWai As New WorkGroupAnalysisInfo(wai)
        Dim locFound As Boolean

        For Each locItem As WorkGroupAnalysisInfoItem In wai
            'Sonderfall - noch kein Element vorhanden, dann 
            'das erste pauschal hinzufügen.
            If retWai.Count = 0 Then
                retWai.Add(locItem)
                retWai._HasData = True
                Continue For
            End If

            locFound = False

            'Alle bislang gefundenen Elemente hinzufügen
            For Each retItem As WorkGroupAnalysisInfoItem In retWai
                If (retItem.ProductionDate = locItem.ProductionDate) And (retItem.WorkGroup = locItem.WorkGroup) Then
                    retItem.Shift = 0
                    retItem.Add(locItem)
                    locFound = True
                    Exit For
                End If
            Next
            If Not locFound Then
                retWai.Add(locItem)
            End If
        Next
        Return retWai
    End Function

    ''' <summary>
    ''' Fasst alle Datumswerte einer Auswertung zu einer Liste mit der Summe aller Datumswerte zusammen
    ''' </summary>
    ''' <param name="wai">WorkGroupAnalysisInfo mit den Werten einzelnen Tagesdaten</param>
    ''' <returns>WorkGroupAnalysisInfo mit den aller Tagesdaten zusammengefasster Werte</returns>
    ''' <remarks></remarks>
    Public Shared Function CompressDates(ByVal wai As WorkGroupAnalysisInfo) As WorkGroupAnalysisInfo
        If wai Is Nothing Then
            Return Nothing
        End If

        Dim retWai As New WorkGroupAnalysisInfo(wai)
        Dim locFound As Boolean

        For Each locItem As WorkGroupAnalysisInfoItem In wai
            'Sonderfall - noch kein Element vorhanden, dann 
            'das erste pauschal hinzufügen.
            If retWai.Count = 0 Then
                retWai.Add(locItem)
                retWai._HasData = True
                Continue For
            End If

            locFound = False
            'Alle bislang gefundenen Elemente hinzufügen
            For Each retItem As WorkGroupAnalysisInfoItem In retWai
                If (retItem.Shift = locItem.Shift) And (retItem.WorkGroup = locItem.WorkGroup) Then
                    retItem.Add(locItem)
                    locFound = True
                    Exit For
                End If
            Next
            If Not locFound Then
                retWai.Add(locItem)
            End If
        Next
        Return retWai
    End Function
End Class

''' <summary>
''' Kapselt Funktion und Ergebnislisten zur Analyse von Produktiv-Sites und stellt die 
''' Ergebnisauflistung dar, die die Einzelauswertungen aller Produktiv-Sites enthält.
''' </summary>
''' <remarks>Diese Klasse stellt eine Auflistung in zwei Ebenen dar. Die erste Auflistung 
''' sind Elemente vom Typ WorkGroupAnalysisInfo, die die Auswertung für die entsprechenden 
''' Produktiv-Sites bilden. Jedes Element ist dabei eine Produktiv-Site-Auswertungsklasse 
''' (WorkGroupAnalasysInfo), die ihrerseits wieder eine Auflistung bildet, und die einzelnen
''' Elemente (WorkGroupAnalysisInfoItem) enthält, die das kleinste Atom der Auswertung bilden. 
''' Durch entsprechende Kompressions-Parameter im Konstruktor dieser Klasse, lassen sich die 
''' Anzahl der WorkGroupAnalysisInfoItem-Elemente beschränken (alle Datumswerte des Auswertungsbereichs 
''' für einzelne Schichten zusammengefasst, oder alle Schichten für jeden Datumswert des Auswertungsbereichs 
''' zusammengefasst, oder beides zusammengefasst, sodass sich nur noch ein WorkGroupAnalysisInfo-Item-Wert ergibt). 
''' </remarks>
Public Class WorkGroupAnalysisInfoItems
    Inherits System.Collections.ObjectModel.KeyedCollection(Of IntKey, WorkGroupAnalysisInfo)

    Private myPeriod As ProductionPeriod
    Private myWorkgroups As WorkGroupInfoItems
    Private myProcessInformerDelegate As WorkGroupAnalysisProcessInformerDelegate
    Private myCompressDates As Boolean
    Private myCompressShifts As Boolean

    ''' <summary>
    ''' Callback-Delegat der für Aktualisierungszwecke für jedes Element bei der Zusammenstellung aufgerufen wird.
    ''' </summary>
    ''' <param name="CurrentWorkgroup">Produktiv-Site, die derzeitig verarbeitet wird.</param>
    ''' <param name="ProcessedWorkgroups">Anzahl Produktiv-Sites, die schon verarbeitet wurden.</param>
    ''' <remarks></remarks>
    Public Delegate Sub WorkGroupAnalysisProcessInformerDelegate(ByVal CurrentWorkgroup As WorkGroupInfo, ByVal ProcessedWorkgroups As Integer)

    Sub New()
        MyBase.new()
    End Sub

    Sub New(ByVal Period As ProductionPeriod, ByVal Workgroups As WorkGroupInfoItems, _
            ByVal ProcessInformerDelegate As WorkGroupAnalysisProcessInformerDelegate, _
            ByVal CompressDates As Boolean, ByVal CompressShifts As Boolean)
        myPeriod = Period
        myWorkgroups = Workgroups
        myProcessInformerDelegate = ProcessInformerDelegate
        myCompressDates = CompressDates
        myCompressShifts = CompressShifts
    End Sub

    Protected Overrides Function GetKeyForItem(ByVal item As WorkGroupAnalysisInfo) As IntKey
        Return New IntKey(item.WorkGroupInfo.IDWorkGroup)
    End Function

    ''' <summary>
    ''' Für die Auswertung mit den definierten Parametern durch.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ExecuteQuery()
        Dim blnFirst As Boolean
        Dim locTicket As DateTime
        Dim locAnalysisInfo As WorkGroupAnalysisInfo = Nothing
        Dim locCount As Integer
        For Each locWorkGroup As WorkGroupInfo In Me.Workgroups

            If ProcessInformerDelegate IsNot Nothing Then
                ProcessInformerDelegate.Invoke(locWorkGroup, locCount)
            End If
            locCount += 1

            If Not blnFirst Then
                locAnalysisInfo = New WorkGroupAnalysisInfo(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                    FacessoGeneric.LoginInfo.IDUser, _
                                    locWorkGroup, Me.Period, True)
                If myCompressDates Then
                    locAnalysisInfo = WorkGroupAnalysisInfo.CompressDates(locAnalysisInfo)
                End If
                If myCompressShifts Then
                    locAnalysisInfo = WorkGroupAnalysisInfo.CompressShifts(locAnalysisInfo)
                End If

                locTicket = locAnalysisInfo.UsedTicket
                Me.Add(locAnalysisInfo)
                blnFirst = True
            Else
                locAnalysisInfo = New WorkGroupAnalysisInfo(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                    FacessoGeneric.LoginInfo.IDUser, locWorkGroup, locTicket)
                If myCompressDates Then
                    locAnalysisInfo = WorkGroupAnalysisInfo.CompressDates(locAnalysisInfo)
                End If
                If myCompressShifts Then
                    locAnalysisInfo = WorkGroupAnalysisInfo.CompressShifts(locAnalysisInfo)
                End If
                Me.Add(locAnalysisInfo)
            End If
        Next
        locAnalysisInfo.CleanUp()
    End Sub

    Public Property Period() As ProductionPeriod
        Get
            Return myPeriod
        End Get
        Set(ByVal value As ProductionPeriod)
            myPeriod = value
        End Set
    End Property

    Public Property Workgroups() As WorkGroupInfoItems
        Get
            Return myWorkgroups
        End Get
        Set(ByVal value As WorkGroupInfoItems)
            myWorkgroups = value
        End Set
    End Property

    Public Property ProcessInformerDelegate() As WorkGroupAnalysisProcessInformerDelegate
        Get
            Return myProcessInformerDelegate
        End Get
        Set(ByVal value As WorkGroupAnalysisProcessInformerDelegate)
            myProcessInformerDelegate = value
        End Set
    End Property
End Class
