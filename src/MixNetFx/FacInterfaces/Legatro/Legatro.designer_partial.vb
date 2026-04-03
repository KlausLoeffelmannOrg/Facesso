Partial Public Class ViewTimeLogNativeVerbatim

    Public ReadOnly Property IsWorksiteChange() As Boolean
        Get
            If Me.BookingType = BookingTypes.Arrive And Me.WorkEntityNumber.HasValue Then
                Return True
            End If
            Return False
        End Get
    End Property
End Class

Public Enum BookingTypes
    Undefined = 0
    Arrive = 1
    Leave = 2
    WorkBreak = 3
    DownTime = 4
    OffSiteWork = 5
End Enum
