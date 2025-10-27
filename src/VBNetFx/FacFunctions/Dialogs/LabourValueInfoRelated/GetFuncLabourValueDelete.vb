Imports Activedev
Imports Facesso.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class GetFuncLabourValueDelete
    Inherits FacessoFunctionBase

    Public Overrides ReadOnly Property RolePermission() As IRolePermissionInfo
        Get
            Return New FacessoRolePermissionInfo(ClearanceLevel.SystemMaintenance)
        End Get
    End Property

    Public Overrides ReadOnly Property RolePermissionViolationMessage() As String
        Get
            Return My.Resources.LabourValueInfoDelete_DeniedDueToRole
        End Get
    End Property

    ''' <summary>
    ''' Zeigt - nach Rollenprüfung - eine Instanz eines UserInfoManagers-Formulars,
    ''' das als Ausgangspunkt und Funktionsanbieter für die Pflege von Benutzerkonten dient.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function DeleteItem(ByVal InfoItem As IInfoItem) As Boolean
        Dim locLabourInfo As LabourValueInfo = DirectCast(InfoItem, LabourValueInfo)
        If SPAccess.GetInstance.LabourValues_IsInUse(locLabourInfo) Then
            MessageBox.Show("Da dieser REFA-Arbeitswert bereits verwendet wird," & vbNewLine & _
                            "dadurch dass er einer Produktiv-Site zugeordnet wurde," & vbNewLine & _
                            "kann er nicht gelöscht werden.", "Bereits in Verwendung!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Function
        End If

        Dim locDr As DialogResult = MessageBox.Show("Sind Sie sicher, den REFA-Arbeitswert" & vbNewLine & vbNewLine & _
                                                  locLabourInfo.ListItemText & vbNewLine & vbNewLine & _
                                                  "löschen zu wollen?", "Löschen bestätigen:", _
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If locDr = DialogResult.Yes Then
            Try
                SPAccess.GetInstance.LabourValues_Delete(locLabourInfo)
            Catch ex As Exception
                MessageBox.Show("Beim Löschen des REFA-Arbeitswertes ist ein Fehler aufgetreten!" & _
                vbNewLine & vbNewLine & ex.StackTrace, "Fehler bei Ausführung!")
            End Try
        End If
    End Function
End Class
