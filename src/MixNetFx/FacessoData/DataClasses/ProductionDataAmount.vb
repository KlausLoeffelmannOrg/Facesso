Imports ActiveDev
Imports System.Collections.ObjectModel
Imports Facesso.Data
Imports System.Data.SqlClient

Public Enum ProductionDataAmountsCategory
    None
    LabourValues
    CostCenters
End Enum

Public Class WorkgroupsProductionDataAmounts
    Inherits KeyedCollection(Of IntKey, WorkgroupProductionDataAmounts)

    ''' <summary>
    ''' Callback-Delegat der für Aktualisierungszwecke für jedes Element bei der Zusammenstellung aufgerufen wird.
    ''' </summary>
    ''' <param name="CurrentWorkgroup">Produktiv-Site, die derzeitig verarbeitet wird.</param>
    ''' <param name="ProcessedWorkgroups">Anzahl Produktiv-Sites, die schon verarbeitet wurden.</param>
    ''' <remarks></remarks>
    Public Delegate Sub WorkgroupsProductionDataAmountProgressDelegate(ByVal CurrentWorkgroup As WorkGroupInfo, ByVal ProcessedWorkgroups As Integer)

    Private myIDSubsidiary As Integer
    Private myWorkgroups As WorkGroupInfoItems
    Private myStartDate As Date
    Private myEndDate As Date
    Private myProcessDelegate As WorkgroupsProductionDataAmountProgressDelegate
    Private myCategorisationTable As DataTable
    Private myCategorisedBy As ProductionDataAmountsCategory = ProductionDataAmountsCategory.None
    Private myCostCenterItems As CostcenterInfoItems

    Sub New(ByVal IDSubsidiary As Integer, ByVal Workgroups As WorkGroupInfoItems, _
            ByVal StartDate As Date, ByVal EndDate As Date, _
            ByVal ProcessDelegate As WorkgroupsProductionDataAmountProgressDelegate)
        myIDSubsidiary = IDSubsidiary
        myWorkgroups = Workgroups
        myStartDate = StartDate
        myEndDate = EndDate
        myProcessDelegate = ProcessDelegate
    End Sub

    Protected Overrides Function GetKeyForItem(ByVal item As WorkgroupProductionDataAmounts) As ActiveDev.IntKey
        Return New IntKey(item.Workgroup.IDWorkGroup)
    End Function

    ''' <summary>
    ''' Führt die Mengenanalyse mit den entsprechenden Parametern durch, die sich aus den Eigenschaften Workgroups, StartDate, 
    ''' EndDate und IDSubsidiary dieser Instanz ergeben.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ExecuteQuery()

        Dim locCount As Integer

        For Each locWorkgroupItem As WorkGroupInfo In Workgroups
            If myProcessDelegate IsNot Nothing Then
                myProcessDelegate.Invoke(locWorkgroupItem, locCount)
            End If

            locCount += 1
            Me.Add(New WorkgroupProductionDataAmounts(IDSubsidiary, locWorkgroupItem, Startdate, EndDate))
        Next
    End Sub

    ''' <summary>
    ''' Die Subsidiarität, auf die sich diese Auswertung bezieht.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IDSubsidiary() As Integer
        Get
            Return myIDSubsidiary
        End Get
    End Property

    ''' <summary>
    ''' Auflistung der Produktiv-Sites, die Gegenstand dieser Mengenanalyse ist.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Workgroups() As WorkGroupInfoItems
        Get
            Return myWorkgroups
        End Get
    End Property

    ''' <summary>
    ''' Auflistung der Kostenstellen, über die eine Auswertung bei einer Kostenstellen-Auswertung gemacht werden soll.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CostCenters() As CostcenterInfoItems
        Get
            Return myCostCenterItems
        End Get
        Set(ByVal value As CostcenterInfoItems)
            myCostCenterItems = value
        End Set
    End Property

    ''' <summary>
    ''' Das Anfangsdatum der Analyse dieser Auswertung.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Startdate() As Date
        Get
            Return myStartDate
        End Get
    End Property

    ''' <summary>
    ''' Das Enddatum der Analyse dieser Auswertung.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property EndDate() As Date
        Get
            Return myEndDate
        End Get
    End Property

    ''' <summary>
    ''' Kategorisiert diese Analyse nach Arbeitswerten und stellt das Ergebnis in einer DataTable zur Verfügung, 
    ''' die über die CategorisationTable-Eigenschaft abgerufen werden kann.
    ''' HINWEIS: Die DataTable-Spalten lauten IDLabourValue, LabourValueNr, LabourValue Description, LabourValueDimension, 
    ''' LabourValueTeHMin, IDCostCenter, CostCenterName, CostCenterNo und TotalAMount.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CategoriseByWorkvalues()

        myCategorisationTable = New DataTable

        With myCategorisationTable.Columns
            .Add("IDLabourValue", GetType(Integer))
            .Add("LabourValueNumber", GetType(Integer))
            .Add("LabourValueDescription", GetType(String))
            .Add("LabourValueDimension", GetType(String))
            .Add("LabourValueTeHMin", GetType(Double))
            .Add("IDCostCenter", GetType(Integer))
            .Add("CostCenterName", GetType(String))
            .Add("CostCenterNo", GetType(String))
            .Add("TotalAmount", GetType(Double))
        End With

        For Each locWorkGroupItems As WorkgroupProductionDataAmounts In Me
            For Each locProductionDataAmount As WorkgroupProductionDataAmount In locWorkGroupItems
                Dim locDataRows As DataRow() = myCategorisationTable.Select("IDLabourValue=" & locProductionDataAmount.LabourValue.IDLabourValue)
                If locDataRows.Length = 0 Then
                    Dim locDataRow As DataRow = myCategorisationTable.NewRow
                    locDataRow("IDLabourValue") = locProductionDataAmount.LabourValue.IDLabourValue
                    locDataRow("LabourValueNumber") = locProductionDataAmount.LabourValue.LabourValueNumber
                    locDataRow("LabourValueDescription") = locProductionDataAmount.LabourValue.LabourValueDescription
                    locDataRow("LabourValueDimension") = locProductionDataAmount.LabourValue.Dimension
                    locDataRow("LabourValueTeHMin") = locProductionDataAmount.LabourValue.TeHMin
                    locDataRow("IDCostCenter") = locProductionDataAmount.LabourValue.IDCostCenter
                    locDataRow("CostCenterName") = locProductionDataAmount.LabourValue.CostCenterName
                    locDataRow("CostCenterNo") = locProductionDataAmount.LabourValue.CostCenterNo
                    locDataRow("TotalAmount") = locProductionDataAmount.TotalAmount
                    myCategorisationTable.Rows.Add(locDataRow)
                Else
                    locDataRows(0)("TotalAmount") = CDbl(locDataRows(0)("TotalAmount")) + locProductionDataAmount.TotalAmount
                End If
            Next
        Next
        myCategorisedBy = ProductionDataAmountsCategory.LabourValues
    End Sub

    ''' <summary>
    ''' Kategorisiert diese Analyse nach Kostenstellen und stellt das Ergebnis in einer DataTable zur Verfügung, 
    ''' die über die CategorisationTable-Eigenschaft abgerufen werden kann.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CategoriseByCostCenters()

        myCategorisationTable = New DataTable

        With myCategorisationTable.Columns
            .Add("IDCostCenter", GetType(Integer))
            .Add("CostCenterName", GetType(String))
            .Add("CostCenterNo", GetType(Integer))
            .Add("AmountIncentiveWageProductionTime", GetType(Double))
        End With

        For Each locWorkGroupItems As WorkgroupProductionDataAmounts In Me
            For Each locProductionDataAmount As WorkgroupProductionDataAmount In locWorkGroupItems
                Dim locDataRows As DataRow() = myCategorisationTable.Select("IDCostCenter=" & locProductionDataAmount.LabourValue.IDCostCenter)
                If locDataRows.Length = 0 Then
                    Dim locDataRow As DataRow = myCategorisationTable.NewRow
                    locDataRow("IDCostCenter") = locProductionDataAmount.LabourValue.IDCostCenter
                    locDataRow("CostCenterName") = locProductionDataAmount.LabourValue.CostCenterName
                    locDataRow("CostCenterNo") = locProductionDataAmount.LabourValue.CostCenterNo
                    locDataRow("AmountIncentiveWageProductionTime") = locProductionDataAmount.TotalAmount * locProductionDataAmount.LabourValue.TeHMin
                    myCategorisationTable.Rows.Add(locDataRow)
                Else
                    locDataRows(0)("AmountIncentiveWageProductionTime") = _
                        CDbl(locDataRows(0)("AmountIncentiveWageProductionTime")) + _
                              locProductionDataAmount.TotalAmount * _
                                   locProductionDataAmount.LabourValue.TeHMin
                End If
            Next
        Next
        myCategorisedBy = ProductionDataAmountsCategory.CostCenters
    End Sub

    ''' <summary>
    ''' Liefert eine Datentabelle zurück, in der sich die entweder nach Arbeitswerten oder Kostenstellen 
    ''' kategorisierten Elemente (und kummulierten Summen!) dieser Auflistung befinden.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CategorisationTable() As DataTable
        Get
            Return myCategorisationTable
        End Get
    End Property

    ''' <summary>
    ''' Ermittelt ob und nach welcher Kategorie die Analyse, die diese Klasse zur Verfügung stellt, kategoriesiert wurde.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CategorisedBy() As ProductionDataAmountsCategory
        Get
            Return myCategorisedBy
        End Get
    End Property
End Class

Public Class WorkgroupProductionDataAmounts
    Inherits KeyedCollection(Of IntKey, WorkgroupProductionDataAmount)

    Private myIDSubsidiary As Integer
    Private myWorkgroup As WorkGroupInfo
    Private myStartDate As Date
    Private myEndDate As Date

    Sub New()
        MyBase.New()
    End Sub

    Sub New(ByVal IDSubsidiary As Integer, ByVal Workgroup As WorkGroupInfo, _
            ByVal StartDate As Date, ByVal EndDate As Date)
        myIDSubsidiary = IDSubsidiary
        myWorkgroup = Workgroup
        myStartDate = StartDate
        myEndDate = EndDate
        SPAccess.GetInstance.ProductionData_CollectAmounts(IDSubsidiary, Workgroup.IDWorkGroup, _
                 StartDate, EndDate, Me)
    End Sub

    Protected Overrides Function GetKeyForItem(ByVal item As WorkgroupProductionDataAmount) As IntKey
        Return New IntKey(item.LabourValue.IDLabourValue)
    End Function

    Public ReadOnly Property IDSubsidiary() As Integer
        Get
            Return myIDSubsidiary
        End Get
    End Property

    Public ReadOnly Property Workgroup() As WorkGroupInfo
        Get
            Return myWorkgroup
        End Get
    End Property

    Public ReadOnly Property Startdate() As Date
        Get
            Return myStartDate
        End Get
    End Property

    Public ReadOnly Property EndDate() As Date
        Get
            Return myEndDate
        End Get
    End Property
End Class

Public Class WorkgroupProductionDataAmount

    Private myLabourValue As LabourValueInfo
    Private myTotalAmount As Double

    Sub New(ByVal TotalAmount As Double, ByVal LabourValue As LabourValueInfo)
        myTotalAmount = TotalAmount
        myLabourValue = LabourValue
    End Sub

    Public Property LabourValue() As LabourValueInfo
        Get
            Return myLabourValue
        End Get
        Set(ByVal value As LabourValueInfo)
            myLabourValue = value
        End Set
    End Property

    Public Property TotalAmount() As Double
        Get
            Return myTotalAmount
        End Get
        Set(ByVal value As Double)
            myTotalAmount = value
        End Set
    End Property

End Class
