Public Interface IADDBNullableValue
    ReadOnly Property IsNull() As Boolean
    ReadOnly Property HasValue() As Boolean
    ReadOnly Property Value() As Object
End Interface

Public Module ADDBNullable
    Public Function FromObject(Of PrimType As IComparable)(ByVal value As Object) As ADDBNullable(Of PrimType)
        Dim locNullable As New ADDBNullable(Of PrimType)
        If (value Is Nothing) Then
            Return locNullable
        ElseIf (TypeOf value Is DBNull) Then
            Return locNullable
        End If
        If TypeOf value Is PrimType Then
            locNullable.myValue = CType(value, PrimType)
            locNullable.myNotNull = True
            Return locNullable
        End If

        'Ein Versuch ist es Wert!
        Try
            locNullable.myValue = CType(value, PrimType)
            locNullable.myNotNull = True
            Return locNullable
        Catch ex As Exception
            Dim up As New InvalidCastException("Object is not of the correct type!")
            Throw up
        End Try
    End Function

    ''' <summary>
    ''' Wandelt in den gekapselten primitiven Datentypen um, 
    ''' </summary>
    ''' <typeparam name="PrimType">Der zugrundeliegende Basistyp</typeparam>
    ''' <param name="value">In seinen primitiven Typ zu konvertierender ADDBNullable</param>
    ''' <returns>Object mit geboxtem primitivem Typ</returns>
    ''' <remarks></remarks>
    Public Function ToObject(Of PrimType As IComparable)(ByVal value As ADDBNullable(Of PrimType)) As Object
        If Not value.HasValue Then
            Return Nothing
        End If
        Return CType(value.Value, PrimType)
    End Function
End Module

<CLSCompliant(True), Serializable()> _
Public Structure ADDBNullable(Of PrimType As IComparable)
    Implements IComparable, IADDBNullableValue, System.Runtime.Serialization.ISerializable

    Friend myValue As PrimType
    Friend myNotNull As Boolean

    Sub New(ByVal Value As PrimType)
        'Sonderbehandlung String, damit "" impliziet in DBNull umgewandelt werden kann
        If GetType(PrimType) Is GetType(String) Then
            If Convert.ToString(Value) = "" Then
                myNotNull = False
                myValue = Nothing
                Return
            End If
        End If

        If Value Is Nothing Then
            myNotNull = False
        Else
            myNotNull = True
        End If
        myValue = Value
    End Sub

    Public ReadOnly Property IsNull() As Boolean Implements IADDBNullableValue.IsNull
        Get
            Return Not myNotNull
        End Get
    End Property

    Public ReadOnly Property HasValue() As Boolean Implements IADDBNullableValue.HasValue
        Get
            Return myNotNull
        End Get
    End Property

    <Xml.Serialization.XmlIgnore()> _
    Public ReadOnly Property Value() As Object Implements IADDBNullableValue.Value
        Get
            If IsNull Then
                Return DBNull.Value
            Else
                Return myValue
            End If
        End Get
    End Property

    Public ReadOnly Property TypedValue() As PrimType
        Get
            If IsNull Then
                Dim up As New InvalidCastException("Can't cast DBNull to its native type")
                Throw up
            Else
                Return myValue
            End If
        End Get
    End Property

    Public Shared Widening Operator CType(ByVal value As PrimType) As ADDBNullable(Of PrimType)
        Return New ADDBNullable(Of PrimType)(value)
    End Operator

    Public Shared Widening Operator CType(ByVal value As DBNull) As ADDBNullable(Of PrimType)
        Return New ADDBNullable(Of PrimType)()
    End Operator

    Public Shared Widening Operator CType(ByVal value As ADDBNullable(Of PrimType)) As PrimType
        If value.IsNull Then
            Return Nothing
        End If
        Return value.myValue
    End Operator

    Public Shared Operator =(ByVal value1 As ADDBNullable(Of PrimType), ByVal value2 As PrimType) As Boolean
        Return value1.CompareTo(value2) = 0
    End Operator

    Public Shared Operator =(ByVal value1 As ADDBNullable(Of PrimType), ByVal value2 As ADDBNullable(Of PrimType)) As Boolean
        Return value1.CompareTo(value2.Value) = 0
    End Operator

    Public Shared Operator <>(ByVal value1 As ADDBNullable(Of PrimType), ByVal value2 As PrimType) As Boolean
        Return Not value1.CompareTo(value2) = 0
    End Operator

    Public Shared Operator <>(ByVal value1 As ADDBNullable(Of PrimType), ByVal value2 As ADDBNullable(Of PrimType)) As Boolean
        Return Not value1.CompareTo(value2.Value) = 0
    End Operator

    Public Shared Operator >(ByVal value1 As ADDBNullable(Of PrimType), ByVal value2 As PrimType) As Boolean
        Return value1.CompareTo(value2) = 1
    End Operator

    Public Shared Operator >(ByVal value1 As ADDBNullable(Of PrimType), ByVal value2 As ADDBNullable(Of PrimType)) As Boolean
        Return value1.CompareTo(value2.Value) = 1
    End Operator

    Public Shared Operator <(ByVal value1 As ADDBNullable(Of PrimType), ByVal value2 As PrimType) As Boolean
        Return value1.CompareTo(value2) = -1
    End Operator

    Public Shared Operator <(ByVal value1 As ADDBNullable(Of PrimType), ByVal value2 As ADDBNullable(Of PrimType)) As Boolean
        Return value1.CompareTo(value2.Value) = -1
    End Operator

    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        If obj.GetType Is GetType(DBNull) Then
            If IsNull Then
                Return 0
            Else
                Return 1
            End If
        End If
        Return myValue.CompareTo(obj)
    End Function

    Public Overrides Function ToString() As String
        If IsNull Then
            Return ""
        Else
            Return myValue.ToString
        End If
    End Function

    Public Sub GetObjectData(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext) Implements System.Runtime.Serialization.ISerializable.GetObjectData

        If IsNull Then
            info.SetType(GetType(DBNull))
            info.AddValue("ADDBNullable", DBNull.Value)
        Else
            info.SetType(GetType(PrimType))
            info.AddValue("ADDBnullable", Me.TypedValue)
        End If
    End Sub
End Structure

