Imports System.Data.SqlClient
Imports ActiveDev

<CLSCompliant(True)> _
Public Class EmployeeInfo
    Inherits InfoItemBase

    Protected Friend myIDEmployee As Integer
    Protected Friend myIDSubsidiary As Integer
    Protected Friend myIDEmployeeInternal As Integer
    Protected Friend myIDCostCenter As Integer
    Protected Friend myIDWageGroup As ADDBNullable(Of Integer)
    Protected Friend myUseFixedWage As Boolean
    Protected Friend myFixedWage As ADDBNullable(Of Double)
    Protected Friend myIDAddressDetails As Integer
    Protected Friend myLastName As String
    Protected Friend myFirstName As String
    Protected Friend myMatchcode As ADDBNullable(Of String)
    Protected Friend myPersonnelNumber As Integer
    Protected Friend myIsCurrent As Boolean
    Protected Friend myIsActive As Boolean
    Protected Friend myIsIncentive As Boolean
    Protected Friend myWasCurrentFrom As Date
    Protected Friend myWasCurrentTo As Date
    Protected Friend myDateOfBirth As ADDBNullable(Of Date)
    Protected Friend myDateOfJoining As ADDBNullable(Of Date)
    Protected Friend myDateOfSeparation As ADDBNullable(Of Date)
    Protected Friend myTimeCardNo As ADDBNullable(Of String)
    Protected Friend myComment As ADDBNullable(Of String)

    Protected Friend myCostCenterNo As Integer
    Protected Friend myCostCenterName As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal dr As SQLDataReader)
        With Me
            .IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"))
            .IDEmployeeInternal = dr.GetInt32(dr.GetOrdinal("IDEmployeeInternal"))
            .IDEmployee = dr.GetInt32(dr.GetOrdinal("IDEmployee"))
            .IDCostCenter = dr.GetInt32(dr.GetOrdinal("IDCostCenter"))
            .IDWageGroup = dr.GetInt32(dr.GetOrdinal("IDWageGroup"))
            .UseFixedWage = dr.GetBoolean(dr.GetOrdinal("UseFixedWage"))
            .FixedWage = ADDBNullable.FromObject(Of Double)(dr.GetValue(dr.GetOrdinal("FixedWage")))
            .IDAddressDetails = dr.GetInt32(dr.GetOrdinal("IDAddressDetails"))
            .LastName = dr.GetString(dr.GetOrdinal("LastName"))
            .FirstName = dr.GetString(dr.GetOrdinal("FirstName"))
            .Matchcode = ADDBNullable.FromObject(Of String)(dr.GetValue(dr.GetOrdinal("Matchcode")))
            .PersonnelNumber = dr.GetInt32(dr.GetOrdinal("PersonnelNumber"))
            .IsCurrent = dr.GetBoolean(dr.GetOrdinal("IsCurrent"))
            .IsActive = dr.GetBoolean(dr.GetOrdinal("IsActive"))
            .IsIncentive = dr.GetBoolean(dr.GetOrdinal("IsIncentive"))
            .WasCurrentFrom = dr.GetDateTime(dr.GetOrdinal("WasCurrentFrom"))
            .WasCurrentTo = dr.GetDateTime(dr.GetOrdinal("WasCurrentTo"))
            .DateOfBirth = ADDBNullable.FromObject(Of Date)(dr.GetValue(dr.GetOrdinal("DateOfBirth")))
            .DateOfJoining = ADDBNullable.FromObject(Of Date)(dr.GetValue(dr.GetOrdinal("DateOfJoining")))
            .DateOfSeparation = ADDBNullable.FromObject(Of Date)(dr.GetValue(dr.GetOrdinal("DateOfSeparation")))
            .TimeCardNo = ADDBNullable.FromObject(Of String)(dr.GetValue(dr.GetOrdinal("TimeCardNo")))
            .Comment = ADDBNullable.FromObject(Of String)(dr.GetValue(dr.GetOrdinal("Comment")))
        End With
    End Sub

    Public Sub New(ByVal dr As SqlDataReader, ByVal JoinedWithCostCenter As Boolean)
        With Me
            .IDSubsidiary = dr.GetInt32(dr.GetOrdinal("IDSubsidiary"))
            .IDEmployeeInternal = dr.GetInt32(dr.GetOrdinal("IDEmployeeInternal"))
            .IDEmployee = dr.GetInt32(dr.GetOrdinal("IDEmployee"))
            .IDCostCenter = dr.GetInt32(dr.GetOrdinal("IDCostCenter"))
            .IDWageGroup = dr.GetInt32(dr.GetOrdinal("IDWageGroup"))
            .UseFixedWage = dr.GetBoolean(dr.GetOrdinal("UseFixedWage"))
            .FixedWage = ADDBNullable.FromObject(Of Double)(dr.GetValue(dr.GetOrdinal("FixedWage")))
            .IDAddressDetails = dr.GetInt32(dr.GetOrdinal("IDAddressDetails"))
            .LastName = dr.GetString(dr.GetOrdinal("LastName"))
            .FirstName = dr.GetString(dr.GetOrdinal("FirstName"))
            .Matchcode = ADDBNullable.FromObject(Of String)(dr.GetValue(dr.GetOrdinal("Matchcode")))
            .PersonnelNumber = dr.GetInt32(dr.GetOrdinal("PersonnelNumber"))
            .IsCurrent = dr.GetBoolean(dr.GetOrdinal("IsCurrent"))
            .IsActive = dr.GetBoolean(dr.GetOrdinal("IsActive"))
            .IsIncentive = dr.GetBoolean(dr.GetOrdinal("IsIncentive"))
            .WasCurrentFrom = dr.GetDateTime(dr.GetOrdinal("WasCurrentFrom"))
            .WasCurrentTo = dr.GetDateTime(dr.GetOrdinal("WasCurrentTo"))
            .DateOfBirth = ADDBNullable.FromObject(Of Date)(dr.GetValue(dr.GetOrdinal("DateOfBirth")))
            .DateOfJoining = ADDBNullable.FromObject(Of Date)(dr.GetValue(dr.GetOrdinal("DateOfJoining")))
            .DateOfSeparation = ADDBNullable.FromObject(Of Date)(dr.GetValue(dr.GetOrdinal("DateOfSeparation")))
            .TimeCardNo = ADDBNullable.FromObject(Of String)(dr.GetValue(dr.GetOrdinal("TimeCardNo")))
            .Comment = ADDBNullable.FromObject(Of String)(dr.GetValue(dr.GetOrdinal("Comment")))

            myCostCenterNo = dr.GetInt32(dr.GetOrdinal("CostcenterNo"))
            myCostCenterName = dr.GetString(dr.GetOrdinal("CostcenterName"))
        End With
    End Sub

    Public Property IDEmployee() As Integer
        Get
            Return Me.myIDEmployee
        End Get
        Set(ByVal value As Integer)
            Me.myIDEmployee = value
        End Set
    End Property

    Public Property IDSubsidiary() As Integer
        Get
            Return Me.myIDSubsidiary
        End Get
        Set(ByVal value As Integer)
            Me.myIDSubsidiary = value
        End Set
    End Property

    Public Property IDEmployeeInternal() As Integer
        Get
            Return Me.myIDEmployeeInternal
        End Get
        Set(ByVal value As Integer)
            Me.myIDEmployeeInternal = value
        End Set
    End Property


    Public Property IDCostCenter() As Integer
        Get
            Return Me.myIDCostCenter
        End Get
        Set(ByVal value As Integer)
            Me.myIDCostCenter = value
        End Set
    End Property

    Public Property IDWageGroup() As ADDBNullable(Of Integer)
        Get
            Return Me.myIDWageGroup
        End Get
        Set(ByVal value As ADDBNullable(Of Integer))
            Me.myIDWageGroup = value
        End Set
    End Property

    Public Property UseFixedWage() As Boolean
        Get
            Return Me.myUseFixedWage
        End Get
        Set(ByVal value As Boolean)
            Me.myUseFixedWage = value
        End Set
    End Property

    Public Property FixedWage() As ADDBNullable(Of Double)
        Get
            Return Me.myFixedWage
        End Get
        Set(ByVal value As ADDBNullable(Of Double))
            Me.myFixedWage = value
        End Set
    End Property

    Public Property IDAddressDetails() As Integer
        Get
            Return Me.myIDAddressDetails
        End Get
        Set(ByVal value As Integer)
            Me.myIDAddressDetails = value
        End Set
    End Property

    <ADAutoReportColumn("Nachname", -1, 2)> _
    Public Property LastName() As String
        Get
            Return Me.myLastName
        End Get
        Set(ByVal value As String)
            Me.myLastName = value
        End Set
    End Property

    <ADAutoReportColumn("Vorname", -1, 3)> _
    Public Property FirstName() As String
        Get
            Return Me.myFirstName
        End Get
        Set(ByVal value As String)
            Me.myFirstName = value
        End Set
    End Property

    Public Property Matchcode() As ADDBNullable(Of String)
        Get
            Return Me.myMatchcode
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            Me.myMatchcode = value
        End Set
    End Property

    <ADAutoReportColumn("Personalnr.", -2, 1)> _
    Public Property PersonnelNumber() As Integer
        Get
            Return Me.myPersonnelNumber
        End Get
        Set(ByVal value As Integer)
            Me.myPersonnelNumber = value
        End Set
    End Property

    Public Property IsCurrent() As Boolean
        Get
            Return Me.myIsCurrent
        End Get
        Set(ByVal value As Boolean)
            Me.myIsCurrent = value
        End Set
    End Property

    Public Property IsActive() As Boolean
        Get
            Return Me.myIsActive
        End Get
        Set(ByVal value As Boolean)
            Me.myIsActive = value
        End Set
    End Property

    Public Property IsIncentive() As Boolean
        Get
            Return Me.myIsIncentive
        End Get
        Set(ByVal value As Boolean)
            Me.myIsIncentive = value
        End Set
    End Property

    Public Property WasCurrentFrom() As Date
        Get
            Return Me.myWasCurrentFrom
        End Get
        Set(ByVal value As Date)
            Me.myWasCurrentFrom = value
        End Set
    End Property

    Public Property WasCurrentTo() As Date
        Get
            Return Me.myWasCurrentTo
        End Get
        Set(ByVal value As Date)
            Me.myWasCurrentTo = value
        End Set
    End Property

    Public Property DateOfBirth() As ADDBNullable(Of Date)
        Get
            Return Me.myDateOfBirth
        End Get
        Set(ByVal value As ADDBNullable(Of Date))
            Me.myDateOfBirth = value
        End Set
    End Property

    Public Property DateOfJoining() As ADDBNullable(Of Date)
        Get
            Return Me.myDateOfJoining
        End Get
        Set(ByVal value As ADDBNullable(Of Date))
            Me.myDateOfJoining = value
        End Set
    End Property

    Public Property DateOfSeparation() As ADDBNullable(Of Date)
        Get
            Return Me.myDateOfSeparation
        End Get
        Set(ByVal value As ADDBNullable(Of Date))
            Me.myDateOfSeparation = value
        End Set
    End Property

    <ADAutoReportColumn("Karten-Nr.:", -2, 4)> _
    Public Property TimeCardNo() As ADDBNullable(Of String)
        Get
            Return Me.myTimeCardNo
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            Me.myTimeCardNo = value
        End Set
    End Property

    Public Property Comment() As ADDBNullable(Of String)
        Get
            Return Me.myComment
        End Get
        Set(ByVal value As ADDBNullable(Of String))
            Me.myComment = value
        End Set
    End Property

    Public Overrides ReadOnly Property DataID() As Integer
        Get
            Return myIDEmployee
        End Get
    End Property

    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Return PersonnelNumber.ToString & ": " & LastName.ToString & ", " & FirstName.ToString
        End Get
    End Property

    Public Overridable ReadOnly Property CostCenterNo() As Integer
        Get
            Return Me.myCostCenterNo
        End Get
    End Property

    Public Overridable ReadOnly Property CostCenterName() As String
        Get
            Return Me.myCostCenterName
        End Get
    End Property

    Public Function Clone() As EmployeeInfo
        Dim locEInfo As New EmployeeInfo
        locEInfo.myComment = Me.Comment
        locEInfo.myCostCenterName = Me.CostCenterName
        locEInfo.myCostCenterNo = Me.CostCenterNo
        locEInfo.myDateOfBirth = Me.DateOfBirth
        locEInfo.myDateOfJoining = Me.DateOfJoining
        locEInfo.myDateOfSeparation = Me.DateOfSeparation
        locEInfo.myFirstName = Me.FirstName
        locEInfo.myFixedWage = Me.FixedWage
        locEInfo.myIDAddressDetails = Me.IDAddressDetails
        locEInfo.myIDCostCenter = Me.IDCostCenter
        locEInfo.myIDEmployee = Me.IDEmployee
        locEInfo.myIDEmployeeInternal = Me.IDEmployeeInternal
        locEInfo.myIDSubsidiary = Me.IDSubsidiary
        locEInfo.myIDWageGroup = Me.IDWageGroup
        locEInfo.myIsActive = Me.IsActive
        locEInfo.myIsCurrent = Me.IsCurrent
        locEInfo.myIsIncentive = Me.IsIncentive
        locEInfo.myLastName = Me.LastName
        locEInfo.myMatchcode = Me.Matchcode
        locEInfo.myPersonnelNumber = Me.PersonnelNumber
        locEInfo.myTimeCardNo = Me.TimeCardNo
        locEInfo.myUseFixedWage = Me.UseFixedWage
        locEInfo.myWasCurrentFrom = Me.WasCurrentFrom
        locEInfo.myWasCurrentTo = Me.WasCurrentTo
        Return locEInfo
    End Function
End Class

<CLSCompliant(True)> _
Public Class EmployeeInfoItems
    Inherits InfoItems(Of EmployeeInfo)

    Sub New()
        MyBase.new()
    End Sub

    'TODO: IDCostcenter wird überhaupt nicht ausgewertet und der Integer dient nur als Überladungs-designator
    'TODO: Aufräumen, und das komplette Laden der Daten in SPAccess übertragen!
    Sub New(ByVal IDCostCenter As Integer)
        Me.New()
        Dim locConnection As SqlConnection = SPAccess.GetInstance.GetOpenedConnectionSafely
        If locConnection Is Nothing Then
            Return
        End If
        Using locConnection
            Dim locCommand As New SqlCommand( _
                SPAccess.GetInstance.EmployeeInfoCollectionCommandString, locConnection)
            Dim locDR As SqlDataReader = locCommand.ExecuteReader()
            If locDR.HasRows Then
                Do While locDR.Read
                    Dim locEmployeeInfo As New EmployeeInfo(locDR, True)
                    Me.Add(locEmployeeInfo)
                Loop
            End If
        End Using
    End Sub

    'TODO: Aufräumen, und das komplette Laden der Daten in SPAccess übertragen!
    Sub New(ByVal OrderByString As String)
        Me.New()
        Dim locConnection As SqlConnection = SPAccess.GetInstance.GetOpenedConnectionSafely
        If locConnection Is Nothing Then
            Return
        End If
        Using locConnection
            Dim locCommand As New SqlCommand( _
                SPAccess.GetInstance.EmployeeInfoCollectionCommandString(OrderByString), locConnection)
            Dim locDR As SqlDataReader = locCommand.ExecuteReader()
            If locDR.HasRows Then
                Do While locDR.Read
                    Dim locEmployeeInfo As New EmployeeInfo(locDR, True)
                    Me.Add(locEmployeeInfo)
                Loop
            End If
        End Using
    End Sub

    Public Function GetByPersonnelNumber(ByVal PersonnelNumber As Integer) As EmployeeInfo
        For Each locItem As EmployeeInfo In Me
            If locItem.PersonnelNumber = PersonnelNumber Then
                Return locItem
            End If
        Next
        Dim up As New FacessoGenericApplicationException("The requested PersonnelNumber could not be found in the EmployeeInfoCollection!", Nothing)
        Throw up
    End Function

    Sub New(ByVal CombinedParameters As CombinedParametersInfo)
        Me.New()
        SPAccess.GetInstance.Employees_GetInWorkGroupOnShiftDate(CombinedParameters, Me)
    End Sub
End Class
