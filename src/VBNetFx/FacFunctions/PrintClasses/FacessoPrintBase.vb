Imports Facesso.Data
Imports ActiveDev.Printing
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing.Text

Public Class FacessoPrintBase

    Private mySimplePrintDocument As ADSimplePrintDocument
    Private myLayoutAndNumberFormats As LayoutAndNumberformats
    Private myBorderStyle As ADFrameCellBorderStyle
    Private myBorderLineWidth As Single
    Private myAnalysisTitle As String
    Private myAnalysisSubTitle As String
    Private myUsername As String

    Sub New(ByVal AnalysisTitle As String, ByVal AnalysisSubTitel As String, ByVal Username As String)
        Dim defaultPages As New ADSimplePrintDocumentDefaultPages(True, False)
        myLayoutAndNumberFormats = DirectCast(FacessoGeneric.FacessoGlobalSettings.Settings.GetItem("LayoutAndNumberFormats", New LayoutAndNumberformats), LayoutAndNumberformats)
        defaultPages.GetPage(2).LeftHeaderText = "Facesso.NET"
        defaultPages.GetPage(2).RightHeaderText = Date.Now.ToLongDateString
        defaultPages.GetPage(2).CenterHeaderText = AnalysisTitle
        defaultPages.GetPage(1).LeftFooterText = "Gedruckt von: " & Username
        defaultPages.GetPage(1).RightFooterText = "(C) 05-07 by http://ActiveDevelop.de"
        defaultPages.GetPage(1).CenterFooterText = "Seite - {%page%} -"
        defaultPages.GetPage(2).LeftFooterText = "Gedruckt von: " & Username
        defaultPages.GetPage(2).RightFooterText = "(C) 05-07 by http://ActiveDevelop.de"
        defaultPages.GetPage(2).CenterFooterText = "Seite - {%page%} -"
        mySimplePrintDocument = New ADSimplePrintDocument(AnalysisTitle, defaultPages)
        myAnalysisTitle = AnalysisTitle
        myAnalysisSubTitle = AnalysisSubTitel
        myUsername = Username
        Select Case myLayoutAndNumberFormats.Gridstyle
            Case FacessoLayoutGridstyle.NoGrid
                myBorderStyle = ADFrameCellBorderStyle.None
                myBorderLineWidth = 0

            Case FacessoLayoutGridstyle.SimpleGridThin
                myBorderStyle = ADFrameCellBorderStyle.FixedSingle
                myBorderLineWidth = 0.5

            Case FacessoLayoutGridstyle.SimpleGridThick
                myBorderStyle = ADFrameCellBorderStyle.FixedSingle
                myBorderLineWidth = 1

            Case FacessoLayoutGridstyle.ThreeDGrid1
                myBorderStyle = ADFrameCellBorderStyle.Fixed3DRaisedFrame
                myBorderLineWidth = 1

            Case FacessoLayoutGridstyle.ThreeDGrid2
                myBorderStyle = ADFrameCellBorderStyle.Fixed3DSunkenFrame
                myBorderLineWidth = 1
        End Select
    End Sub

    Protected Overridable Sub PrepareDocument()
        PrepareDocument(False)
    End Sub

    Protected Overridable Sub PrepareDocument(ByVal DontPrintBeginingConclusion As Boolean)
        With mySimplePrintDocument
            If DontPrintBeginingConclusion Then
                .CurrentFont = myLayoutAndNumberFormats.U3Font.ToFont
                .CurrentAlignment = ADTextAlignment.Center
                .DefaultPages.FirstPageDifferent = False
                'Hier kann es jetzt losgehen!
            Else
                .CurrentFont = myLayoutAndNumberFormats.U1Font.ToFont
                .CurrentAlignment = ADTextAlignment.Center
                'Alle Zeilen der Überschrift ausgeben
                Dim locIADPO As IADPrintableObject = .WriteLine(myAnalysisTitle)
                locIADPO.DistanceToNext = 15
                .CurrentFont = myLayoutAndNumberFormats.U2Font.ToFont
                Dim locLines As String() = myAnalysisSubTitle.Split(New String() {vbCr.ToString}, StringSplitOptions.RemoveEmptyEntries)
                For Each locLine As String In locLines
                    .WriteLine(locLine)
                Next
                .WriteLine()
                .CurrentFont = myLayoutAndNumberFormats.U3Font.ToFont
                .CurrentAlignment = ADTextAlignment.Left
                'Hier kann es jetzt losgehen!
            End If
        End With
    End Sub

    Public Overridable Sub ProcessDocument(ByVal ProcessTarget As AnalysisTarget)
        If ProcessTarget = AnalysisTarget.PreviewBeforePrint Then
            PrepareDocument()
            PrintDocument.PreviewDocument()
        ElseIf ProcessTarget = AnalysisTarget.DirectlyToPrinter Then
            PrepareDocument()
            PrintDocument.PrintDocument()
        Else
            If Not HasExcelExport Then
                MessageBox.Show("Excel-Export-Funktionalität steht in diesem Auswertungstyp nicht zur Verfügung!", _
                                 "Export nicht möglich!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                ExcelExportHandler()
            End If
        End If
    End Sub

    Public Overridable ReadOnly Property HasExcelExport() As Boolean
        Get
            Return False
        End Get
    End Property

    Private Sub ExcelExportHandler()

        Dim locSFD As New SaveFileDialog
        With locSFD
            .Title = "Export für Excel als CSV-Datei"
            .OverwritePrompt = True
            .CheckPathExists = True
            .DefaultExt = "*.CSV"
            .Filter = "Kommagetrennte Exportdatei (*.csv)|*.csv|Textdatei (*.txt)|*.txt|Alle Dateien (*.*)|*.*"
            Dim dialogErgebnis As DialogResult = .ShowDialog
            If dialogErgebnis = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            ExcelExport(.FileName)
        End With
    End Sub

    Protected Overridable Sub ExcelExport(ByVal Filename As String)
    End Sub

    <CLSCompliant(False)> _
    Public ReadOnly Property PrintDocument() As ADSimplePrintDocument
        Get
            Return mySimplePrintDocument
        End Get
    End Property

    Public ReadOnly Property LayoutAndNumberFormats() As LayoutAndNumberformats
        Get
            Return myLayoutAndNumberFormats
        End Get
    End Property

    <CLSCompliant(False)> _
    Public ReadOnly Property BorderStyle() As ADFrameCellBorderStyle
        Get
            Return myBorderStyle
        End Get
    End Property

    Public ReadOnly Property BorderLineWidth() As Single
        Get
            Return myBorderLineWidth
        End Get
    End Property
End Class
