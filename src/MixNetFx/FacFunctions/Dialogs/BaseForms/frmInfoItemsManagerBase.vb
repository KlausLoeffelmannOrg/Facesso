Imports Facesso
Imports System.WIndows.Forms

Public Class frmInfoItemsManagerBase

    Public Event InfoItemsColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs)

    Private Sub arvInfoItems_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles arvInfoItems.ColumnClick
        OnInfoItemsColumnClick(sender, e)
    End Sub

    Friend Overridable Sub OnInfoItemsColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs)
        RaiseEvent InfoItemsColumnClick(sender, e)
    End Sub

    Private Sub OKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub arvInfoItems_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles arvInfoItems.DoubleClick
        OnInfoItemDoubleClick(sender, e)
    End Sub

    Friend Overridable Sub OnInfoItemDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        MessageBox.Show("Diese Funktion ist in diesem Dialog nicht verfügbar.", "Funktions nicht verfügbar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub
End Class

