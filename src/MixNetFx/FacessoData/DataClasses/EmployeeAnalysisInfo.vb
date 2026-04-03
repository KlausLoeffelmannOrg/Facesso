Imports Activedev
Imports System.Data.SqlClient
Imports System.Collections.ObjectModel

''' <summary>
''' Dient zur Durchführung einer Mitarbeiterauswertung oder Mitarbeiter-Prämienlohnberechnung.
''' </summary>
''' <remarks></remarks>
Public Class EmployeeAnalysisInfoItem

    Private _Period As ProductionPeriod
    Private _EmployeeWage As EmployeeWageInfo
    Private _Employee As EmployeeInfo
    Private _TimeLogItems As EmployeeTimeLogInfo
    Private _UsedTicket As DateTime
    Private _IDSubsidiary As Integer
    Private _IDUser As Integer
    Private _Selected As Boolean

    ''' <summary>
    ''' Bereitet die Params-Tabellen im SQL-Server vor, führt die Auswertung durch und ermittelt die Daten und löscht die Daten der Params-Tabellen anschließend wieder.
    ''' </summary>
    ''' <param name="IDSubsidiary">ID der Subsidiarität</param>
    ''' <param name="IDUser">Benutzer-ID (für das Abrufen der korrekten Daten in den Params-Tabellen).</param>
    ''' <param name="Employee">Der auszuwertende Mitarbeiter</param>
    ''' <param name="Period">Der auszuwertende Zeitraum (erfolgt über ALLE Schichten).</param>
    ''' <remarks>Auswertung erfolgt über alle Schichten</remarks>
    Sub New(ByVal IDSubsidiary As Integer, ByVal IDUser As Integer, _
            ByVal Employee As EmployeeInfo, ByVal Period As ProductionPeriod)
        Dim locTicket As Date = Date.Now
        _IDSubsidiary = IDSubsidiary
        _IDUser = IDUser
        _Employee = Employee
        _Period = Period
        _TimeLogItems = New EmployeeTimeLogInfo()
        _TimeLogItems.RecalculateTotalReferenceIWT = True
        Period.PrepareProductionDates(IDSubsidiary, IDUser, locTicket)
        SPAccess.GetInstance.TimeLog_GetEmployeeResult(IDSubsidiary, IDUser, locTicket, Employee, _TimeLogItems)
        SPAccess.GetInstance.ProductionData_DeleteProductionDateItems(IDSubsidiary, IDUser, locTicket)
        _EmployeeWage = New EmployeeWageInfo(_Employee, _
                                       _TimeLogItems.DegreeOfTime, _
                                       _TimeLogItems.TotalEffectiveIWT)
    End Sub

    ''' <summary>
    ''' Bereitet die Params-Tabellen vor, führt die Auswertung durch, und erlaubt es, die Params-Tabellen für eine weitere Auswertung zu behalten.
    ''' </summary>
    ''' <param name="IDSubsidiary">ID der Subsidiarität</param>
    ''' <param name="IDUser">Benutzer-ID (für das Abrufen der korrekten Daten in den Params-Tabellen).</param>
    ''' <param name="Employee">Der auszuwertende Mitarbeiter</param>
    ''' <param name="Period">Der auszuwertende Zeitraum (erfolgt über ALLE Schichten).</param>
    ''' <param name="KeepTicketAndPeriod">Bestimmt, ob die Params-Tabelle im Anschluss für weitere Auswertungen des gleichen Zeitraums beibehalten werden soll.</param>
    ''' <remarks></remarks>
    Sub New(ByVal IDSubsidiary As Integer, ByVal IDUser As Integer, _
            ByVal Employee As EmployeeInfo, ByVal Period As ProductionPeriod, _
            ByVal KeepTicketAndPeriod As Boolean)
        Dim locTicket As Date = Date.Now
        _IDSubsidiary = IDSubsidiary
        _IDUser = IDUser
        _Employee = Employee
        _Period = Period
        _TimeLogItems = New EmployeeTimeLogInfo()
        _TimeLogItems.RecalculateTotalReferenceIWT = True
        Period.PrepareProductionDates(IDSubsidiary, IDUser, locTicket)
        SPAccess.GetInstance.TimeLog_GetEmployeeResult(IDSubsidiary, IDUser, locTicket, Employee, _TimeLogItems)
        _EmployeeWage = New EmployeeWageInfo(_Employee, _
                                       _TimeLogItems.DegreeOfTime, _
                                       _TimeLogItems.TotalEffectiveIWT)
        _UsedTicket = locTicket
    End Sub

    ''' <summary>
    ''' Führt eine Auswertung auf Basis einer bereits angelegten Params-Tabelle durch, die durch eine durchgeführte Auswertung bereits angelegt wurde.
    ''' </summary>
    ''' <param name="IDSubsidiary">ID der Subsidiarität</param>
    ''' <param name="IDUser">Benutzer-ID (für das Abrufen der korrekten Daten in den Params-Tabellen).</param>
    ''' <param name="Employee">Der auszuwertende Mitarbeiter</param>
    ''' <param name="UseTicket">Das Ticket für den Zugriff auf die Params-Tabelle , das bei der ersten Auswertung angelegt wurde und durch UsedTicket ermittelt werden kann.</param>
    ''' <param name="CleanUpAfter">Bestimmt, ob die Params-Daten anschließend gelöscht werden oder für weitere Auswertungen beibehalten werden sollen.</param>
    ''' <remarks></remarks>
    Sub New(ByVal IDSubsidiary As Integer, ByVal IDUser As Integer, _
            ByVal Employee As EmployeeInfo, ByVal Period As ProductionPeriod, _
            ByVal UseTicket As DateTime, ByVal CleanUpAfter As Boolean)
        _IDSubsidiary = IDSubsidiary
        _IDUser = IDUser
        _Employee = Employee
        _Period = Period
        _TimeLogItems = New EmployeeTimeLogInfo()
        _TimeLogItems.RecalculateTotalReferenceIWT = True
        SPAccess.GetInstance.TimeLog_GetEmployeeResult(IDSubsidiary, IDUser, UseTicket, Employee, _TimeLogItems)
        _EmployeeWage = New EmployeeWageInfo(_Employee, _
                                       _TimeLogItems.DegreeOfTime, _
                                       _TimeLogItems.TotalEffectiveIWT)
        _UsedTicket = UseTicket
        If CleanUpAfter Then
            SPAccess.GetInstance.ProductionData_DeleteProductionDateItems(IDSubsidiary, IDUser, UseTicket)
        End If
    End Sub

    ''' <summary>
    ''' Sorgt dafür, dass Params-Daten nach der Auswertung durch manuelles Triggern gelöscht werden.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CleanUp()
        SPAccess.GetInstance.ProductionData_DeleteProductionDateItems(_IDSubsidiary, _IDUser, _UsedTicket)
    End Sub

    ''' <summary>
    ''' Ermittelt den Auswertungszeitraum.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Period() As ProductionPeriod
        Get
            Return _Period
        End Get
    End Property

    ''' <summary>
    ''' Ermittelt den Prämienlohn.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property EmployeeWage() As EmployeeWageInfo
        Get
            Return _EmployeeWage
        End Get
    End Property

    ''' <summary>
    ''' Bestimmt, ob ein Item als selektiert markiert ist, oder nicht, damit es später in Tabellen als durch den Benutzer selektiert identifiziert werden kann.
    ''' </summary>
    ''' <value>Boolscher Wert, der bestimmt, ob das Item selektiert ist oder nicht.</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Selected() As Boolean
        Get
            Return _Selected
        End Get
        Set(ByVal value As Boolean)
            _Selected = value
        End Set
    End Property

    ''' <summary>
    ''' Beinhaltet die Einzelbuchungszeiten.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TimeLogItems() As EmployeeTimeLogInfo
        Get
            Return _TimeLogItems
        End Get
    End Property

    ''' <summary>
    ''' Ermittelt das verwendete Ticket, das für weitere Mitarbeiterauswertungen des gleichen Zeitraums verwendet werden kann.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UsedTicket() As DateTime
        Get
            Return _UsedTicket
        End Get
    End Property
End Class

''' <summary>
''' Stellt Auflistung von Leistungs- bzw. Prämienlohnauswertungen verschiedener Mitarbeiter dar.
''' </summary>
''' <remarks></remarks>
Public Class EmployeeAnalysisInfoItems
    Inherits KeyedCollection(Of IntKey, EmployeeAnalysisInfoItem)

    Private myPeriodText As String

    ''' <summary>
    ''' Erstellt eine neue EmployeeAnalysisInfoItems-Klasse, die Auswertungen verschiedener Mitarbeiter enthält.
    ''' </summary>
    ''' <param name="PeriodText">Einen dokumentierenden Text, der den Zeitraum beschreibt, und beim Drucken verwendet wird.</param>
    ''' <remarks></remarks>
    Sub New(ByVal PeriodText As String)
        MyBase.New()
        myPeriodText = PeriodText
    End Sub

    Protected Overrides Function GetKeyForItem(ByVal item As EmployeeAnalysisInfoItem) As IntKey
        Return New IntKey(item.EmployeeWage.IDEmployee)
    End Function

    ''' <summary>
    ''' Sortiert diese Auflistung nach Personalnummer der einzelnen Mitarbeiter.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SortByPersonnelNumber()
        Dim locList As New List(Of EmployeeAnalysisInfoItem)
        For Each locItem As EmployeeAnalysisInfoItem In Me
            locList.Add(locItem)
        Next
        locList.Sort(New Comparison(Of EmployeeAnalysisInfoItem)(AddressOf EmployeeAnalysisInfoItem_PersonnelNumberComparer))
        Me.Clear()
        For Each locItem As EmployeeAnalysisInfoItem In locList
            Me.Add(locItem)
        Next
    End Sub


    ''' <summary>
    ''' Sortiert diese Auflistung nach Zeitgrad der einzelnen Mitarbeiter.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SortByDegreeOfTime()
        Dim locList As New List(Of EmployeeAnalysisInfoItem)
        For Each locItem As EmployeeAnalysisInfoItem In Me
            locList.Add(locItem)
        Next
        locList.Sort(New Comparison(Of EmployeeAnalysisInfoItem)(AddressOf EmployeeAnalysisInfoItem_TimeOfDegreeComparer))
        Me.Clear()
        For Each locItem As EmployeeAnalysisInfoItem In locList
            Me.Add(locItem)
        Next
    End Sub

    ''' <summary>
    ''' Sortiert diese Auflistung nach Nachnamen der einzelnen Mitarbeiter.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SortByLastname()
        Dim locList As New List(Of EmployeeAnalysisInfoItem)
        For Each locItem As EmployeeAnalysisInfoItem In Me
            locList.Add(locItem)
        Next
        locList.Sort(New Comparison(Of EmployeeAnalysisInfoItem)(AddressOf EmployeeAnalysisInfoItem_LastnameComparer))
        Me.Clear()
        For Each locItem As EmployeeAnalysisInfoItem In locList
            Me.Add(locItem)
        Next
    End Sub

    ''' <summary>
    ''' Der Comparer-Delegat für die Sortierung der Mitarbeiter dieser AUflistung nach Zeitgrad.
    ''' </summary>
    ''' <param name="first">Erster Mitarbeiter-Analysedatensatz, mit dem vergleichen wird.</param>
    ''' <param name="second">Zweiter Mitarbeiter-Analysedatensatz, der vergleichen wird.</param>
    ''' <returns>1 bei Größer, -1 bei Kleiner, 0 bei gleicher Zeitgrad.</returns>
    ''' <remarks></remarks>
    Private Function EmployeeAnalysisInfoItem_TimeOfDegreeComparer(ByVal first As EmployeeAnalysisInfoItem, ByVal second As EmployeeAnalysisInfoItem) As Integer
        If first.EmployeeWage.DegreeOfTime > second.EmployeeWage.DegreeOfTime Then
            Return 1
        ElseIf first.EmployeeWage.DegreeOfTime < second.EmployeeWage.DegreeOfTime Then
            Return -1
        Else
            Return 0
        End If
    End Function

    ''' <summary>
    ''' Der Comparer-Delegat für die Sortierung der Mitarbeiter dieser AUflistung nach Nachnamen.
    ''' </summary>
    ''' <param name="first">Erster Mitarbeiter-Analysedatensatz, mit dem vergleichen wird.</param>
    ''' <param name="second">Zweiter Mitarbeiter-Analysedatensatz, der vergleichen wird.</param>
    ''' <returns>1 bei Größer, -1 bei Kleiner, 0 bei gleicher Nachname.</returns>
    ''' <remarks></remarks>
    Private Function EmployeeAnalysisInfoItem_LastnameComparer(ByVal first As EmployeeAnalysisInfoItem, ByVal second As EmployeeAnalysisInfoItem) As Integer
        If first.EmployeeWage.LastName > second.EmployeeWage.LastName Then
            Return 1
        ElseIf first.EmployeeWage.LastName < second.EmployeeWage.LastName Then
            Return -1
        Else
            Return 0
        End If
    End Function

    ''' <summary>
    ''' Der Comparer-Delegat für die Sortierung der Mitarbeiter dieser AUflistung nach Personalnummer.
    ''' </summary>
    ''' <param name="first">Erster Mitarbeiter-Analysedatensatz, mit dem vergleichen wird.</param>
    ''' <param name="second">Zweiter Mitarbeiter-Analysedatensatz, der vergleichen wird.</param>
    ''' <returns>1 bei Größer, -1 bei Kleiner, 0 bei gleicher Personalnummer.</returns>
    ''' <remarks></remarks>
    Private Function EmployeeAnalysisInfoItem_PersonnelNumberComparer(ByVal first As EmployeeAnalysisInfoItem, ByVal second As EmployeeAnalysisInfoItem) As Integer
        If first.EmployeeWage.PersonnelNumber > second.EmployeeWage.PersonnelNumber Then
            Return 1
        ElseIf first.EmployeeWage.PersonnelNumber < second.EmployeeWage.PersonnelNumber Then
            Return -1
        Else
            Return 0
        End If
    End Function


    ''' <summary>
    ''' Ermittelt den zu druckenden Zeitraum-Text (nur beschreibende Funktion).
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PeriodText() As String
        Get
            Return myPeriodText
        End Get
        Set(ByVal value As String)
            myPeriodText = value
        End Set
    End Property
End Class
