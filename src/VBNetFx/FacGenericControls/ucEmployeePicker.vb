Imports Facesso.Data

Public Class ucEmployeePicker

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        elvMain.AutoGroup = True
        elvMain.MultiSelect = True
        elvMain.OnlyActiveEmployees = True
        elvMain.OnlyIncentiveEmployees = True
    End Sub

    Public Property Employees() As EmployeeInfoItems
        Get
            Return elvMain.EmployeeInfoCollection
        End Get
        Set(ByVal value As EmployeeInfoItems)
            elvMain.EmployeeInfoCollection = value
        End Set
    End Property

    Public ReadOnly Property FirstSelectedEmployee() As EmployeeInfo
        Get
            Return elvMain.FirstSelectedEmployee
        End Get
    End Property

    Public ReadOnly Property SelectedEmployees() As EmployeeInfoItems
        Get
            Return elvMain.SelectedEmployees
        End Get
    End Property

    Private Sub txtSearchText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchText.TextChanged
        Dim locString As String = txtSearchText.Text
        Dim locPersonnelNr As Integer
        Dim locParts As String()
        Dim locFlag As Boolean
        Dim locEmployees As New EmployeeInfoItems()

        locParts = locString.Split(New Char() {","c, "."c, ";"c})
        For Each locS As String In locParts
            If locS.Trim.Length = 0 Then Continue For
            locS = locS.ToLower()
            locFlag = Integer.TryParse(locS, locPersonnelNr)
            For Each locItem As EmployeeInfo In Me.Employees
                If locFlag Then
                    If locItem.PersonnelNumber = locPersonnelNr Then
                        Try
                            locEmployees.Add(locItem)
                        Catch ex As Exception
                        End Try
                        Exit For
                    End If
                End If

                If locItem.LastName.ToLower.StartsWith(locS) Then
                    Try
                        locEmployees.Add(locItem)
                    Catch ex As Exception
                    End Try
                End If
            Next
        Next

        elvMain.SetCustomGroup("Gefundene Treffer aus Eingabe", locEmployees)
    End Sub

    Private Sub chkOnlyIncentiveEmployees_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOnlyIncentiveEmployees.CheckedChanged
        elvMain.OnlyActiveEmployees = chkOnlyIncentiveEmployees.Checked
    End Sub
End Class
