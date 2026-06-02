Imports System.IO
Imports System.Xml.Serialization

<Serializable()> _
Public Class KannegiesserSQLConfig

    Private Shared myIsSetup As Boolean
    Private Shared myConfigSettings As KannegiesserSQLConfig

    Private myPathToArticle As String
    Private myPathToData As String
    Private myConnectionString As String

    Shared Sub New()
        myConfigSettings = DeserializeFromFile()
        If myConfigSettings Is Nothing Then
            myIsSetup = False
        Else
            myIsSetup = True
        End If
    End Sub

    Private Shared Function DeserializeFromFile() As KannegiesserSQLConfig
        Dim locFI As FileInfo = ConfigFilename
        If Not locFI.Exists Then
            Return Nothing
        End If
        Dim locXml As New XmlSerializer(GetType(KannegiesserSQLConfig))
        Dim locSr As New StreamReader(ConfigFilename.ToString)
        Return DirectCast(locXml.Deserialize(locSr), KannegiesserSQLConfig)
    End Function

    Public Shared Sub SerializeToFile()
        Dim locXml As New XmlSerializer(GetType(KannegiesserSQLConfig))
        Dim locSw As New StreamWriter(ConfigFilename.ToString, False)
        locXml.Serialize(locSw, myConfigSettings)
        locSw.Flush()
        locSw.Close()
        locSw.Dispose()
    End Sub

    Public Shared Sub Configure()
        Return
    End Sub

    Public Shared Property ConfigSettings() As KannegiesserSQLConfig
        Get
            Return myConfigSettings
        End Get
        Set(ByVal value As KannegiesserSQLConfig)
            myConfigSettings = value
        End Set
    End Property

    Public Shared Function IsSetup() As Boolean
        Return True
    End Function

    Public Shared ReadOnly Property ConfigFilename() As FileInfo
        Get
            Return New FileInfo(frmImport.InterfaceDirectory.ToString & "\" & "KannegiesserSQLConfig" & ".xml")
        End Get
    End Property
End Class

