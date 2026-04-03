Public Structure DegreeOfTime

    Private Shared myDefaultFactor As Double = 1
    Private Shared myDefaultDimension As String = "%"
    Private Shared myDefaultDecimalPlaces As Byte = 0

    Private myValue As Double
    Private myDecimalPlaces As Byte
    Private myDimension As String
    Private myFactor As Double

    Sub New(ByVal BaseValue As Double)
        myValue = BaseValue
        myFactor = myDefaultFactor
        myDecimalPlaces = myDefaultDecimalPlaces
        myDimension = myDefaultDimension
    End Sub

    Sub New(ByVal BaseValue As Double, ByVal Factor As Double)
        myValue = BaseValue
        myFactor = Factor
        myDecimalPlaces = myDefaultDecimalPlaces
        myDimension = myDefaultDimension
    End Sub

    Sub New(ByVal BaseValue As Double, ByVal Factor As Double, ByVal DecimalPlaces As Byte)
        myValue = BaseValue
        myFactor = Factor
        myDecimalPlaces = DecimalPlaces
        myDimension = myDefaultDimension
    End Sub

    Sub New(ByVal BaseValue As Double, ByVal Factor As Double, ByVal DecimalPlaces As Byte, ByVal Dimension As String)
        myValue = BaseValue
        myFactor = Factor
        myDecimalPlaces = DecimalPlaces
        myDimension = Dimension
    End Sub

    Public Property Value() As Double
        Get
            Return myValue * myFactor
        End Get
        Set(ByVal value As Double)
            myValue = value / myFactor
        End Set
    End Property

    Public Property Factor() As Double
        Get
            Return myFactor
        End Get
        Set(ByVal value As Double)
            myFactor = value
        End Set
    End Property

    Public Property Dimension() As String
        Get
            Return myDimension
        End Get
        Set(ByVal value As String)
            myDimension = value
        End Set
    End Property

    Public Property DecimalPlaces() As Byte
        Get
            Return myDecimalPlaces
        End Get
        Set(ByVal value As Byte)
            myDecimalPlaces = value
        End Set
    End Property

    Public ReadOnly Property UnderlyingValue() As Double
        Get
            Return myValue
        End Get
    End Property

    Public Overrides Function ToString() As String
        Dim locDec As String = "0"
        If DecimalPlaces > 0 Then
            locDec &= "." & New String("0"c, DecimalPlaces)
        End If
        Return Value.ToString(locDec) & " " & Dimension
    End Function

    Public Shared Widening Operator CType(ByVal value As Double) As DegreeOfTime
        Return New DegreeOfTime(value)
    End Operator
End Structure
