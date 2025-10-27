Public Class EmployeeWageInfo
    Inherits EmployeeInfo

    Protected Friend myDegreeOfTime As Double
    Protected Friend myBonusFactor As Double
    Protected Friend myUseFixValuedBonus As Boolean
    Protected Friend myPercentage As Double
    Protected Friend myAbsoluteValue As Double
    Protected Friend myIncentiveWageTime As Double
    Protected Friend myBaseWage As Double
    Protected Friend myTotalIncentiveWage As Double

    Sub New(ByVal Employee As EmployeeInfo, ByVal DegreeOfTime As Double, ByVal IncentiveWageTime As Double)
        Me.myComment = Employee.Comment
        Me.myCostCenterName = Employee.CostCenterName
        Me.myCostCenterNo = Employee.CostCenterNo
        Me.myDateOfBirth = Employee.DateOfBirth
        Me.myDateOfJoining = Employee.DateOfJoining
        Me.myDateOfSeparation = Employee.DateOfSeparation
        Me.myFirstName = Employee.FirstName
        Me.myFixedWage = Employee.FixedWage
        Me.myIDAddressDetails = Employee.IDAddressDetails
        Me.myIDCostCenter = Employee.IDCostCenter
        Me.myIDEmployee = Employee.IDEmployee
        Me.myIDEmployeeInternal = Employee.IDEmployeeInternal
        Me.myIDSubsidiary = Employee.IDSubsidiary
        Me.myIDWageGroup = Employee.IDWageGroup
        Me.myIsActive = Employee.IsActive
        Me.myIsCurrent = Employee.IsCurrent
        Me.myIsIncentive = Employee.IsIncentive
        Me.myLastName = Employee.LastName
        Me.myMatchcode = Employee.Matchcode
        Me.myPersonnelNumber = Employee.PersonnelNumber
        Me.myTimeCardNo = Employee.TimeCardNo
        Me.myUseFixedWage = Employee.UseFixedWage
        Me.myWasCurrentFrom = Employee.WasCurrentFrom
        Me.myWasCurrentTo = Employee.WasCurrentTo

        myDegreeOfTime = DegreeOfTime
        myIncentiveWageTime = IncentiveWageTime
        If IncentiveWageTime = 0 Then
            myDegreeOfTime = -1
            myTotalIncentiveWage = -1
        Else
            LookUpWageDataInternal()
        End If
    End Sub

    Public Property DegreeOfTime() As Double
        Get
            Return myDegreeOfTime
        End Get
        Set(ByVal value As Double)
            myDegreeOfTime = value
        End Set
    End Property

    Public Property IncentiveWageTime() As Double
        Get
            Return myIncentiveWageTime
        End Get
        Set(ByVal value As Double)
            myIncentiveWageTime = value
        End Set
    End Property

    Public Property UseFixValuedBonus() As Boolean
        Get
            Return myUseFixValuedBonus
        End Get
        Friend Set(ByVal value As Boolean)
            myUseFixValuedBonus = value
        End Set
    End Property

    Public Property Percentage() As Double
        Get
            Return myPercentage
        End Get
        Friend Set(ByVal value As Double)
            myPercentage = value
        End Set
    End Property

    Public ReadOnly Property PercentageDescription() As String
        Get
            If UseFixValuedBonus Then
                Return "(Fixbonus: " & AbsoluteValue.ToString("#,##0.00") & " €)"
            Else
                Return "(Faktor: " & Percentage & " %)"
            End If
        End Get
    End Property

    Public Property AbsoluteValue() As Double
        Get
            Return myAbsoluteValue
        End Get
        Friend Set(ByVal value As Double)
            myAbsoluteValue = value
        End Set
    End Property

    Public Property BaseWage() As Double
        Get
            Return myBaseWage
        End Get
        Friend Set(ByVal value As Double)
            myBaseWage = value
        End Set
    End Property

    Public ReadOnly Property TotalIncentiveWage() As Double
        Get
            Return myTotalIncentiveWage
        End Get
    End Property

    Private Sub LookUpWageDataInternal()
        SPAccess.GetInstance.Employees_LookUpWageData(Me)
        Recalculate()
    End Sub

    Private Sub Recalculate()
        If IncentiveWageTime = 0 Then
            myDegreeOfTime = -1
            myTotalIncentiveWage = -1
        End If
        Dim locHours As Double = IncentiveWageTime / 60
        If UseFixValuedBonus Then
            myTotalIncentiveWage = locHours * AbsoluteValue
        Else
            Dim locTemp As Double = locHours * BaseWage
            myTotalIncentiveWage = (locTemp * Percentage / 100) - locTemp
        End If
    End Sub

End Class
