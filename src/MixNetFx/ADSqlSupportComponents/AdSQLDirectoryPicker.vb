Imports System.IO
Imports System.Data.SqlClient
Imports System.Collections.ObjectModel

Public Class ADSQLDirectoryPicker
    Inherits TreeView

    Private myConnectionString As String
    Private myDrives As Collection(Of DBDriveItem)
    Private myImageList As ImageList
    Private myExtensionFilter As String
    Private myUpdateBlocked As Boolean
    Private myUpdateOnUpdateUnblocked As Boolean

    Public Event SelectedFileNodeChanged(ByVal sender As Object, ByVal e As ADFileTreeViewEventArgs)

    Sub New()
        MyBase.New()
        myImageList = New ImageList
        myImageList.Images.Add(My.Resources.drive, Color.Magenta)
        myImageList.Images.Add(My.Resources.VSFolder_closed, Color.Magenta)
        myImageList.Images.Add(My.Resources.document, Color.Magenta)
        Me.ImageList = myImageList
        myExtensionFilter = Nothing
    End Sub

    Public Shadows Sub BeginUpdate()
        MyBase.BeginUpdate()
        myUpdateBlocked = True
    End Sub

    Public Shadows Sub EndUpdate()
        MyBase.EndUpdate()
        myUpdateBlocked = False
        If myUpdateOnUpdateUnblocked Then
            rebuildRootList()
        End If
    End Sub

    Public Property ConnectionString() As String
        Get
            Return myConnectionString
        End Get
        Set(ByVal value As String)
            myConnectionString = value
            If Not myUpdateBlocked Then
                rebuildRootList()
            Else
                myUpdateOnUpdateUnblocked = True
            End If
        End Set
    End Property

    Public Property ExtensionFilter() As String
        Get
            Return myExtensionFilter
        End Get
        Set(ByVal value As String)
            myExtensionFilter = value
            If Not myUpdateBlocked Then
                rebuildRootList()
            Else
                myUpdateOnUpdateUnblocked = True
            End If
        End Set
    End Property

    Private Function testConnection() As Boolean
        Dim locConnection As New SqlConnection(myConnectionString)
        Dim locIcon As MessageBoxIcon = MessageBoxIcon.Exclamation
        Using locConnection
            Try
                locConnection.Open()
            Catch ex As Exception
                Dim locMessage As String = "Verbindungsherstellung war nicht möglich!" & _
                    vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & _
                    ex.StackTrace
                locIcon = MessageBoxIcon.Error
                MessageBox.Show(locMessage, "Verbindungstest:", MessageBoxButtons.OK, locIcon)
                Return False
            End Try
        End Using
        Return True
    End Function

    Private Sub rebuildRootList()
        'Knoten Löschen
        Me.Nodes.Clear()
        If String.IsNullOrEmpty(myConnectionString) Then
            Return
        End If
        If testConnection() Then
            'Wurzel (=Laufwerke ermitteln) und darstellen
            myDrives = ADSqlDriveFoldersAndFilesListing.GetDrivenames(myConnectionString)
            For Each locItem As DBDriveItem In myDrives
                Dim locNode As TreeNode = Me.Nodes.Add(locItem.DriveLetter, locItem.DriveLetter & ":", 0, 0)
                'Erste Ebene einlesen
                Dim locDirItems As New Collection(Of DBDirOrFileItem)
                locDirItems = ADSqlDriveFoldersAndFilesListing.GetSubfoldersAndFiles(myConnectionString, locItem.DriveLetter & ":\")
                buildSubnode(locNode, locDirItems)
            Next
        End If
    End Sub

    Protected Overrides Sub OnBeforeExpand(ByVal e As System.Windows.Forms.TreeViewCancelEventArgs)
        MyBase.OnBeforeExpand(e)
        For Each locNode As TreeNode In e.Node.Nodes
            locNode.Nodes.Clear()
            Dim locDirItems As New Collection(Of DBDirOrFileItem)
            locDirItems = ADSqlDriveFoldersAndFilesListing.GetSubfoldersAndFiles(myConnectionString, locNode.FullPath)
            buildSubnode(locNode, locDirItems)
        Next
    End Sub

    Protected Overrides Sub OnAfterCollapse(ByVal e As System.Windows.Forms.TreeViewEventArgs)
        MyBase.OnAfterCollapse(e)
        Dim locNode As TreeNode = e.Node
        locNode.Nodes.Clear()
        Dim locDirItems As New Collection(Of DBDirOrFileItem)
        locDirItems = ADSqlDriveFoldersAndFilesListing.GetSubfoldersAndFiles(myConnectionString, locNode.FullPath)
        buildSubnode(locNode, locDirItems)
    End Sub

    Private Sub buildSubnode(ByVal node As TreeNode, ByVal dirItems As Collection(Of DBDirOrFileItem))
        If dirItems IsNot Nothing Then
            For Each DirItem As DBDirOrFileItem In dirItems
                If DirItem.IsFile And (Not String.IsNullOrEmpty(ExtensionFilter)) Then
                    Dim locFileInfo As New FileInfo(DirItem.Name)
                    If locFileInfo.Extension = ExtensionFilter Or ExtensionFilter = ".*" Then
                        node.Nodes.Add(DirItem.Name, DirItem.Name, 2, 2)
                    End If
                ElseIf Not DirItem.IsFile Then
                    node.Nodes.Add(DirItem.Name, DirItem.Name, 1, 1)
                End If
            Next
        End If
    End Sub

    Protected Overrides Sub OnAfterSelect(ByVal e As System.Windows.Forms.TreeViewEventArgs)
        MyBase.OnAfterSelect(e)
        Dim locE As ADFileTreeViewEventArgs
        If e.Node IsNot Nothing Then
            locE = New ADFileTreeViewEventArgs(e.Node, e.Action, CType(e.Node.ImageIndex, ADFileItemType))
        Else
            locE = New ADFileTreeViewEventArgs(e.Node, e.Action, ADFileItemType.None)
        End If
        OnSelectedFileNodeChanged(locE)
    End Sub

    Protected Overridable Sub OnSelectedFileNodeChanged(ByVal e As ADFileTreeViewEventArgs)
        RaiseEvent SelectedFileNodeChanged(Me, e)
    End Sub
End Class

Public Class ADFileTreeViewEventArgs
    Inherits TreeViewEventArgs

    Private myFileItemType As ADFileItemType

    Sub New(ByVal node As TreeNode, ByVal action As TreeViewAction, ByVal itemType As ADFileItemType)
        MyBase.New(node, action)
        myFileItemType = itemType
    End Sub

    Public Property FileItemType() As ADFileItemType
        Get
            Return myFileItemType
        End Get
        Set(ByVal value As ADFileItemType)
            myFileItemType = value
        End Set
    End Property
End Class

Public Enum ADFileItemType
    Drive
    Folder
    File
    None
End Enum