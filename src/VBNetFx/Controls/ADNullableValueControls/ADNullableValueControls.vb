Imports System.Windows.Forms
Imports System.Collections.ObjectModel

<CLSCompliant(True)> _
Public Class ADNullableValueControls
    Inherits Collection(Of IADNullableValueControl)

    Public Shared Function FromContainerControl(ByVal cControl As Control) As ADNullableValueControls
        Return FromContainerControlInternal(New ADNullableValueControls, cControl)
    End Function

    Private Shared Function FromContainerControlInternal(ByVal nullableControls As ADNullableValueControls, ByVal cControl As Control) As ADNullableValueControls

        For Each c As Control In cControl.Controls
            If c.GetType.GetInterface(GetType(IADNullableValueControl).Name) IsNot Nothing Then
                nullableControls.Add(DirectCast(c, IADNullableValueControl))
            End If
            If c.HasChildren Then
                FromContainerControlInternal(nullableControls, DirectCast(c, Control))
            End If
        Next
        Return nullableControls
    End Function

    Public Function CheckForNotAllowedNullValues() As String

        Dim locString As String = ""

        For Each ic As IADNullableValueControl In Me
            If ic.NullValueMessage IsNot Nothing Then
                If ic.NullValueMessage <> "" Then
                    If ic.Value.IsNull Then
                        locString &= "* " & ic.Text & " " & ic.NullValueMessage & vbNewLine & vbNewLine
                    End If
                End If
            End If
        Next
        If locString = "" Then
            Return Nothing
        Else
            Return locString
        End If
    End Function
End Class


