Imports System
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Data.EntityClient
Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Runtime.Serialization

Imports Facesso

Partial Public Class FacessoEntities

    Public Shared Function GetFacessoEntityString() As String
        Dim sqlString = FacessoGeneric.SQLConnectionString
        Dim providerString = "System.Data.SqlClient"

        If sqlString.IndexOf("MultipleActiveResultSets") < 0 Then
            sqlString &= ";MultipleActiveResultSets=True"
        End If

        Dim eb As New EntityConnectionStringBuilder(sqlString)
        eb.Provider = providerString
        eb.Metadata = "metadata=res://*/FacessoModel.csdl|res://*/FacessoModel.ssdl|res://*/FacessoModel.msl"
        Return eb.ToString

    End Function

End Class
