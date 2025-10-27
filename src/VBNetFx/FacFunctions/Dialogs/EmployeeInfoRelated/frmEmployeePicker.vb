Imports Facesso.Data
Imports System.Windows.Forms

Public Class frmEmployeePicker

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.AcceptButton = ucEmployeePicker.btnOK
        Me.CancelButton = ucEmployeePicker.btnCancel
        AddHandler ucEmployeePicker.btnOK.Click, AddressOf OKClickHandler
        AddHandler ucEmployeePicker.btnCancel.Click, AddressOf CancelClickHandler

    End Sub

    Public Function GetEmployeeSelection() As EmployeeInfoItems
        Using Me
            ucEmployeePicker.Employees = New EmployeeInfoItems(0)
            Me.ShowDialog()
            If Me.DialogResult = Windows.Forms.DialogResult.OK Then
                Return ucEmployeePicker.SelectedEmployees
            Else
                Return Nothing
            End If
        End Using
    End Function

    Private Sub OKClickHandler(ByVal sender As Object, ByVal e As EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub CancelClickHandler(ByVal sender As Object, ByVal e As EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

End Class