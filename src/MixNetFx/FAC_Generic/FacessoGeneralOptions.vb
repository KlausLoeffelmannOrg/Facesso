<Serializable()> _
Public Class FacessoGeneralOptions

    Private mySaturdayIsWorkday As Boolean
    Private mySundayIsWorkday As Boolean
    Private myDontLookForInterfaceAssemblies As Boolean
    Private myAutomateMainFormUpdate As Boolean
    Private myAutomateMainFormUpdateInterval As Integer
    Private myShowTimeLogPriorToImport As Boolean
    Private myShowIssueListPriorToImport As Boolean

    Sub New()
        MyBase.New()
        myAutomateMainFormUpdateInterval = 60
    End Sub

    Sub New(ByVal SaturdayIsWorkday As Boolean, ByVal SundayIsWorkday As Boolean, _
            ByVal DontLookForInterfaceAssemblies As Boolean, ByVal AutomateMainFormUpdate As Boolean, _
            ByVal AutomateMainFormUpdateInterval As Integer)
        mySaturdayIsWorkday = SaturdayIsWorkday
        mySundayIsWorkday = SundayIsWorkday
        myDontLookForInterfaceAssemblies = DontLookForInterfaceAssemblies
        myAutomateMainFormUpdate = AutomateMainFormUpdate
        myAutomateMainFormUpdateInterval = 60
    End Sub

    Public Property SaturdayIsWorkday() As Boolean
        Get
            Return mySaturdayIsWorkday
        End Get
        Set(ByVal value As Boolean)
            mySaturdayIsWorkday = value
        End Set
    End Property

    Public Property SundayIsWorkday() As Boolean
        Get
            Return mySundayIsWorkday
        End Get
        Set(ByVal value As Boolean)
            mySundayIsWorkday = value
        End Set
    End Property

    Public Property DontLookForInterfaceAssemblies() As Boolean
        Get
            Return myDontLookForInterfaceAssemblies
        End Get
        Set(ByVal value As Boolean)
            myDontLookForInterfaceAssemblies = value
        End Set
    End Property

    Public Property AutomateMainFormUpdate() As Boolean
        Get
            Return myAutomateMainFormUpdate
        End Get
        Set(ByVal value As Boolean)
            myAutomateMainFormUpdate = value
        End Set
    End Property

    Public Property AutomateMainFormUpdateInterval() As Integer
        Get
            Return myAutomateMainFormUpdateInterval
        End Get
        Set(ByVal value As Integer)
            myAutomateMainFormUpdateInterval = value
        End Set
    End Property

    Public Property ShowTimeLogPriorToImport() As Boolean
        Get
            Return myShowTimeLogPriorToImport
        End Get
        Set(ByVal value As Boolean)
            myShowTimeLogPriorToImport = value
        End Set
    End Property

    Public Property ShowIssueListPriorToImport() As Boolean
        Get
            Return myShowIssueListPriorToImport
        End Get
        Set(ByVal value As Boolean)
            myShowIssueListPriorToImport = value
        End Set
    End Property

End Class
