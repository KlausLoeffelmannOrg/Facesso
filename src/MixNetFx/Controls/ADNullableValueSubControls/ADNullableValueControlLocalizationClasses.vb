Imports System.Globalization
Imports System.ComponentModel

Public Class ADDescriptionAttribute
    Inherits DescriptionAttribute

    Private myDescriptionGerman As String
    Private myDescriptionEnglish As String

    Sub New()
        MyBase.New()
    End Sub

    Sub New(ByVal description As String)
        MyBase.new()
        myDescriptionGerman = description
        myDescriptionEnglish = description
    End Sub

    Sub New(ByVal descriptionGerman As String, ByVal descriptionEnglish As String)
        MyBase.new()
        myDescriptionGerman = descriptionGerman
        myDescriptionEnglish = descriptionEnglish
    End Sub

    Public Overrides ReadOnly Property Description() As String
        Get
            If CultureInfo.CurrentCulture.Name.StartsWith("de") Then
                Return myDescriptionGerman
            Else
                Return myDescriptionEnglish
            End If
        End Get
    End Property
End Class

Public Class ADCategoryAttribute
    Inherits CategoryAttribute

    Private myCategoryGerman As String
    Private myCategoryEnglish As String

    Sub New()
        MyBase.New()
    End Sub

    Sub New(ByVal category As String)
        MyBase.new()
        myCategoryGerman = category
        myCategoryEnglish = category
    End Sub

    Sub New(ByVal categoryGerman As String, ByVal categoryEnglish As String)
        MyBase.new()
        myCategoryGerman = categoryGerman
        myCategoryEnglish = categoryEnglish
    End Sub

    Protected Overrides Function GetLocalizedString(ByVal value As String) As String
        If CultureInfo.CurrentCulture.Name.StartsWith("de") Then
            Return myCategoryGerman
        Else
            Return myCategoryEnglish
        End If
    End Function
End Class

'Localizable Exceptions
Public Class ADArgumentException
    Inherits ArgumentException

    Private myMessage As String

    Sub New(ByVal GermanMessage As String, ByVal EnglishMessage As String, ByVal Parameter As String)
        MyBase.New(EnglishMessage, Parameter)
        If CultureInfo.CurrentCulture.Name.StartsWith("de") Then
            myMessage = GermanMessage
        Else
            myMessage = EnglishMessage
        End If

    End Sub

    Public Overrides ReadOnly Property Message() As String
        Get
            Return myMessage
        End Get
    End Property
End Class

Public Class ADTypeMismatchException
    Inherits ArithmeticException

    Private myMessage As String

    Sub New(ByVal GermanMessage As String, ByVal EnglishMessage As String)
        MyBase.New(EnglishMessage)
        If CultureInfo.CurrentCulture.Name.StartsWith("de") Then
            myMessage = GermanMessage
        Else
            myMessage = EnglishMessage
        End If

    End Sub

    Public Overrides ReadOnly Property Message() As String
        Get
            Return myMessage
        End Get
    End Property
End Class
