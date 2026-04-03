Imports Activedev
Imports System.Windows.Forms

Public Enum InfoItemFormEditMode
    View
    Edit
    AddNew
End Enum

Public Class InfoItemMaintenanceDialogResult

    Private myDialogResult As DialogResult
    Private myInfoItem As IInfoItem

    Sub New(ByVal InfoItem As IInfoItem, ByVal DialogResult As DialogResult)
        myDialogResult = DialogResult
        myInfoItem = InfoItem
    End Sub

    Public ReadOnly Property InfoItem() As IInfoItem
        Get
            Return myInfoItem
        End Get
    End Property

    Public ReadOnly Property DialogResult() As DialogResult
        Get
            Return myDialogResult
        End Get
    End Property

End Class

