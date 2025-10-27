Public Class WorkgroupBaseDataPrintParameters

    Private myPrintWorkgroups As Boolean
    Private myPrintAssignedLabourValues As Boolean
    Private myPrintShiftTimes As Boolean
    Private myPrintProductivityHistory As Integer
    Private myOnlyPrintListOfLabourValues As Boolean

    Public Property PrintWorkgroups() As Boolean
        Get
            Return myPrintWorkgroups
        End Get
        Set(ByVal value As Boolean)
            myPrintWorkgroups = value
        End Set
    End Property

    Public Property PrintAssignedLabourValues() As Boolean
        Get
            Return myPrintAssignedLabourValues
        End Get
        Set(ByVal value As Boolean)
            myPrintAssignedLabourValues = value
        End Set
    End Property

    Public Property PrintShiftTimes() As Boolean
        Get
            Return myPrintShiftTimes
        End Get
        Set(ByVal value As Boolean)
            myPrintShiftTimes = value
        End Set
    End Property

    Public Property VisualizeProductivityHistory() As Integer
        Get
            Return myPrintProductivityHistory
        End Get
        Set(ByVal value As Integer)
            myPrintProductivityHistory = value
        End Set
    End Property

    Public Property OnlyPrintListOfLabourValues() As Boolean
        Get
            Return myOnlyPrintListOfLabourValues
        End Get
        Set(ByVal value As Boolean)
            myOnlyPrintListOfLabourValues = value
        End Set
    End Property
End Class
