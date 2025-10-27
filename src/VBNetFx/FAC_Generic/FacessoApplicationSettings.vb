Imports System.Configuration

Public Class FacessoApplicationSettings
    Inherits ApplicationSettingsBase

    Sub New()
        MyBase.New("FacessoGlobal")
    End Sub

    <Global.System.Configuration.UserScopedSettingAttribute()> _
    Public Property LoginHistory() As LoginHistory
        Get
            Return CType(Me("LoginHistory"), LoginHistory)
        End Get
        Set(ByVal value As LoginHistory)
            Me("LoginHistory") = value
        End Set
    End Property

    <Global.System.Configuration.UserScopedSettingAttribute()> _
    Public Property LastLoginName() As String
        Get
            Return CType(Me("LastLoginName"), String)
        End Get
        Set(ByVal value As String)
            Me("LastLoginName") = value
        End Set
    End Property

    <Global.System.Configuration.UserScopedSettingAttribute()> _
    Public Property LastSubsidiaryID() As Integer
        Get
            Return CType(Me("LastSubsidiaryID"), Integer)
        End Get
        Set(ByVal value As Integer)
            Me("LastSubsidiaryID") = value
        End Set
    End Property
End Class

<Serializable()> _
Public Class FacessoDynamicSettingsList
    Inherits System.Collections.Hashtable

    Public Function GetItem(ByVal Key As String, ByVal DefaultValue As Object) As Object
        If Me.ContainsKey(Key) Then
            Return Me(Key)
        End If
        Me.Add(Key, DefaultValue)
        Return DefaultValue
    End Function

    Public Sub SetItem(ByVal key As String, ByVal Value As Object)
        If Me.ContainsKey(key) Then
            Me(key) = Value
            Return
        End If
        Me.Add(key, Value)
    End Sub
End Class
