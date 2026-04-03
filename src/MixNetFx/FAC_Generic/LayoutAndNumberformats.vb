Imports System.Drawing

Public Class LayoutAndNumberformats

    Private _U1Font As SerializableFontSetting
    Private _U2Font As SerializableFontSetting
    Private _U3Font As SerializableFontSetting
    Private _TableHeaderFont As SerializableFontSetting
    Private _TextAndTableBodyFont As SerializableFontSetting
    Private _SmallTableFont As SerializableFontSetting
    Private _HeaderFont As SerializableFontSetting
    Private _FooterFont As SerializableFontSetting
    'Private _LogoBitmap As Image
    Private _Gridstyle As FacessoLayoutGridstyle
    Private _HMinPrecision As Byte

    Sub New()
        _U1Font = New SerializableFontSetting("Arial", 22, FontStyle.Bold)
        _U2Font = New SerializableFontSetting("Arial", 16, FontStyle.Bold)
        _U3Font = New SerializableFontSetting("Arial", 13, FontStyle.Bold)
        _TableHeaderFont = New SerializableFontSetting("Arial", 10, FontStyle.Bold)
        _HeaderFont = New SerializableFontSetting("Arial", 10, FontStyle.Bold)
        _FooterFont = New SerializableFontSetting("Arial", 8, FontStyle.Regular)
        _TextAndTableBodyFont = New SerializableFontSetting("Arial", 9, FontStyle.Regular)
        _SmallTableFont = New SerializableFontSetting("Arial", 8, FontStyle.Regular)
        '_LogoBitmap = My.Resources.CompLogo_V2
        _Gridstyle = FacessoLayoutGridstyle.ThreeDGrid1
        _HMinPrecision = 2
    End Sub

    Public Property U1Font() As SerializableFontSetting
        Get
            Return _U1Font
        End Get
        Set(ByVal value As SerializableFontSetting)
            _U1Font = value
        End Set
    End Property

    Public Property U2Font() As SerializableFontSetting
        Get
            Return _U2Font
        End Get
        Set(ByVal value As SerializableFontSetting)
            _U2Font = value
        End Set
    End Property

    Public Property U3Font() As SerializableFontSetting
        Get
            Return _U3Font
        End Get
        Set(ByVal value As SerializableFontSetting)
            _U3Font = value
        End Set
    End Property

    Public Property TableHeaderFont() As SerializableFontSetting
        Get
            Return _TableHeaderFont
        End Get
        Set(ByVal value As SerializableFontSetting)
            _TableHeaderFont = value
        End Set
    End Property

    Public Property TextAndTableBodyFont() As SerializableFontSetting
        Get
            Return _TextAndTableBodyFont
        End Get
        Set(ByVal value As SerializableFontSetting)
            _TextAndTableBodyFont = value
        End Set
    End Property

    Public Property HeaderFont() As SerializableFontSetting
        Get
            Return _HeaderFont
        End Get
        Set(ByVal value As SerializableFontSetting)
            _HeaderFont = value
        End Set
    End Property

    Public Property FooterFont() As SerializableFontSetting
        Get
            Return _FooterFont
        End Get
        Set(ByVal value As SerializableFontSetting)
            _FooterFont = value
        End Set
    End Property

    Public Property SmallTableFont() As SerializableFontSetting
        Get
            Return _SmallTableFont
        End Get
        Set(ByVal value As SerializableFontSetting)
            _SmallTableFont = value
        End Set
    End Property

    'Public Property LogoBitmap() As Image
    '    Get
    '        Return _LogoBitmap
    '    End Get
    '    Set(ByVal value As Image)
    '        _LogoBitmap = value
    '    End Set
    'End Property

    Public Property Gridstyle() As FacessoLayoutGridstyle
        Get
            Return _Gridstyle
        End Get
        Set(ByVal value As FacessoLayoutGridstyle)
            _Gridstyle = value
        End Set
    End Property

    Public Property HMinPrecision() As Byte
        Get
            Return _HMinPrecision
        End Get
        Set(ByVal value As Byte)
            _HMinPrecision = value
        End Set
    End Property

    Public Function HminFormated(ByVal hmin As Double) As String
        Dim locFormat As String
        locFormat = "#,##0"
        If HMinPrecision > 0 Then
            locFormat &= "," & New String("0"c, HMinPrecision)
        End If
        Return hmin.ToString(locFormat)
    End Function

End Class

Public Enum FacessoLayoutGridstyle
    NoGrid
    SimpleGridThin
    SimpleGridThick
    ThreeDGrid1
    ThreeDGrid2
End Enum

Public Class SerializableFontSetting

    Private _FontName As String
    Private _FontSize As Single
    Private _FontStyle As FontStyle

    Sub New()
        FontName = "Arial"
        FontSize = 10
        FontStyle = FontStyle.Regular
    End Sub

    Sub New(ByVal font As Font)
        _FontName = font.Name
        _FontSize = font.Size
        _FontStyle = font.Style
    End Sub

    Sub New(ByVal fontName As String, ByVal fontSize As Single, ByVal fontStyle As FontStyle)
        _FontName = fontName
        _FontSize = fontSize
        _FontStyle = fontStyle
    End Sub

    Public Property FontName() As String
        Get
            Return _FontName
        End Get
        Set(ByVal value As String)
            _FontName = value
        End Set
    End Property

    Public Property FontSize() As Single
        Get
            Return _FontSize
        End Get
        Set(ByVal value As Single)
            _FontSize = value
        End Set
    End Property

    Public Property FontStyle() As FontStyle
        Get
            Return _FontStyle
        End Get
        Set(ByVal value As FontStyle)
            _FontStyle = value
        End Set
    End Property

    Public ReadOnly Property FontSettingsDescription() As String
        Get
            Return FontName & "; " & FontSize & " pt;" & FontStyle.ToString()
        End Get
    End Property

    Public Function ToFont() As Font
        Return New Font(FontName, FontSize, FontStyle)
    End Function
End Class
