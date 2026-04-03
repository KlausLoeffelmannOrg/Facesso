Imports System.Windows.Forms
Imports Facesso.Data
Imports System.Data.SqlClient

Public Class GetFrmEmployeeInfoCenter
    Inherits FacessoFunctionBase

    Private myFrmInfoItemsManagerGeneric As frmInfoItemsManagerGeneric(Of EmployeeInfo)
    Private myCurrentSortOrderString As String = "PersonnelNumber"

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.PerformAccounting)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            Return My.Resources.EmployeeInfoCollectionGet_DeniedDueToRole
        End Get
    End Property

    ''' <summary>
    ''' Liefert - nach Rollenprüfung - eine Instanz eines UserInfoManagers-Formulars zurück,
    ''' das als Ausgangspunkt und Funktionsanbieter für die Pflege von Benutzerkonten dient.
    ''' </summary>
    ''' <remarks>Rückgabewert ist vom Typ (frmInfoItemsManagerGenric'UserInfo)</remarks>
    Public Sub ShowDialog()
        Dim locEmployeeInfoCollection As EmployeeInfoItems = New EmployeeInfoItems(0)

        myFrmInfoItemsManagerGeneric = New frmInfoItemsManagerGeneric(Of EmployeeInfo) _
                                       (My.Resources.EmployeeInfoCenter_LocalizedTypeName)

        myFrmInfoItemsManagerGeneric.InfoItems = locEmployeeInfoCollection

        myFrmInfoItemsManagerGeneric.InfoItemAddDelegate = AddressOf EmployeeInfoAdd
        myFrmInfoItemsManagerGeneric.InfoItemEditDelegate = AddressOf EmployeeInfoEdit
        myFrmInfoItemsManagerGeneric.InfoItemDeleteDelegate = AddressOf EmployeeInfoDelete
        myFrmInfoItemsManagerGeneric.RefreshItemsDelegate = AddressOf RefreshItems
        myFrmInfoItemsManagerGeneric.InfoItemColumnClickDelegate = AddressOf ColumnClick
        myFrmInfoItemsManagerGeneric.PrintListDelegate = AddressOf PrintList
        myFrmInfoItemsManagerGeneric.ShowDialog()
    End Sub

    Friend Sub EmployeeInfoAdd()
        Dim locFH As GetFrmEmployeeInfoAdd = FunctionHandler(Of GetFrmEmployeeInfoAdd).GetFunctionInstance
        If locFH Is Nothing Then Return
        locFH.ShowDialog()
    End Sub

    Friend Sub EmployeeInfoEdit()
        Dim locFH As GetFrmEmployeeInfoEdit = FunctionHandler(Of GetFrmEmployeeInfoEdit).GetFunctionInstance
        If locFH Is Nothing Then Return
        If myFrmInfoItemsManagerGeneric.SelectedInfoItem Is Nothing Then
            MessageBox.Show(My.Resources.EmployeeInfoCenter_NoSelectedEmployee_MB_Body, _
                            My.Resources.EmployeeInfoCenter_NoSelectedEmployee_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        locFH.ShowDialog(myFrmInfoItemsManagerGeneric.SelectedInfoItem)
    End Sub

    Friend Sub EmployeeInfoDelete()
        Dim locFH As GetFuncEmployeeDelete = FunctionHandler(Of GetFuncEmployeeDelete).GetFunctionInstance
        If locFH Is Nothing Then Return
        If myFrmInfoItemsManagerGeneric.SelectedInfoItem Is Nothing Then
            MessageBox.Show(My.Resources.EmployeeInfoCenter_NoSelectedEmployee_MB_Body, _
                            My.Resources.EmployeeInfoCenter_NoSelectedEmployee_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        locFH.DeleteItem(myFrmInfoItemsManagerGeneric.SelectedInfoItem)
    End Sub

    Friend Sub RefreshItems()
        Dim locEmployeeInfoCollection As New EmployeeInfoItems(myCurrentSortOrderString)
        myFrmInfoItemsManagerGeneric.InfoItems = locEmployeeInfoCollection
    End Sub

    Friend Sub PrintList()
        Dim reportForm As New ReportEmployeeMasterData
        reportForm.ShowDialog()
    End Sub

    Friend Sub ColumnClick()
        Select Case myFrmInfoItemsManagerGeneric.LastColumnClickEventArgs.Column

            Case 0
                myCurrentSortOrderString = "PersonnelNumber"
            Case 1
                myCurrentSortOrderString = "LastName"
            Case 2
                myCurrentSortOrderString = "FirstName"
            Case 3
                myCurrentSortOrderString = "TimeCardNo"
            Case Else
                myCurrentSortOrderString = "PersonnelNumber"
        End Select

    End Sub



End Class
