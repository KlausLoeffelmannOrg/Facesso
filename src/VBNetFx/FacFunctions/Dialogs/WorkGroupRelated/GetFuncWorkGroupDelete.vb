Imports Activedev
Imports Facesso.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class GetFuncWorkGroupDelete
    Inherits FacessoFunctionBase

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.SystemMaintenance)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            Return My.Resources.WorkGroupInfoDelete_DeniedDueToRole
        End Get
    End Property

    ''' <summary>
    ''' Zeigt - nach Rollenprüfung - eine Instanz eines UserInfoManagers-Formulars,
    ''' das als Ausgangspunkt und Funktionsanbieter für die Pflege von Benutzerkonten dient.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function DeleteItem(ByVal InfoItem As IInfoItem) As Boolean
        Dim locWorkGroupInfo As WorkGroupInfo = DirectCast(InfoItem, WorkGroupInfo)
        If SPAccess.GetInstance.WorkGroups_IsInUse(locWorkGroupInfo) Then
            MessageBox.Show("Da diese Produktiv-Site bereits verwendet wird," & vbNewLine & _
                            "kann sie nicht gelöscht werden.", "Bereits in Verwendung!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If

        Dim locDr As DialogResult = MessageBox.Show("Sind Sie sicher, die Produktiv-Site" & vbNewLine & vbNewLine & _
                                                  locWorkGroupInfo.ListItemText & vbNewLine & vbNewLine & _
                                                  "löschen zu wollen?", "Löschen bestätigen:", _
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If locDr = DialogResult.Yes Then
            Try
                SPAccess.GetInstance.WorkGroups_Delete(locWorkGroupInfo)
            Catch ex As Exception
                MessageBox.Show("Beim Löschen der Produktiv-Site ist ein Fehler aufgetreten!" & _
                vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.StackTrace, "Fehler bei Ausführung!")
            End Try
        End If
    End Function
End Class
