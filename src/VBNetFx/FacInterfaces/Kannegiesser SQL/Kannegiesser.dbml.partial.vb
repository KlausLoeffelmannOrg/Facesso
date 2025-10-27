Partial Public Class GetMachinesResult

    Public Overrides Function ToString() As String
        Return Me.MachineID & ": " & Me.MachineName
    End Function

End Class
