Imports ActiveDev
Imports System.Collections.ObjectModel

Public Class ParamsWorkGroups

    Private _WorkGroups As WorkGroupInfoItems
    Private _ProductionPeriod As ProductionPeriod

    Sub New(ByVal WorkGroups As WorkGroupInfoItems, ByVal Period As ProductionPeriod)
        _WorkGroups = WorkGroups
        _ProductionPeriod = Period
    End Sub

    Public Property WorkGroups() As WorkGroupInfoItems
        Get
            Return _WorkGroups
        End Get
        Set(ByVal value As WorkGroupInfoItems)
            _WorkGroups = value
        End Set
    End Property

    Public Property ProductionPeriod() As ProductionPeriod
        Get
            Return _ProductionPeriod
        End Get
        Set(ByVal value As ProductionPeriod)
            _ProductionPeriod = value
        End Set
    End Property
End Class

Public Class ParamsEmployees
    Private _Employees As EmployeeInfoItems
    Private _ProductionPeriod As ProductionPeriod

    Sub New(ByVal Employees As EmployeeInfoItems, ByVal Period As ProductionPeriod)
        _Employees = Employees
        _ProductionPeriod = Period
    End Sub

    Public Property Employees() As EmployeeInfoItems
        Get
            Return _Employees
        End Get
        Set(ByVal value As EmployeeInfoItems)
            _Employees = value
        End Set
    End Property

    Public Property ProductionPeriod() As ProductionPeriod
        Get
            Return _ProductionPeriod
        End Get
        Set(ByVal value As ProductionPeriod)
            _ProductionPeriod = value
        End Set
    End Property

End Class
