Imports System.Runtime.InteropServices
Imports System.Security.Cryptography

Public Class frmMain

    Private myLicenseInfo As Byte()
    Private mySerialPart As Byte()

    Private Sub btnQuitProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitProgram.Click
        Me.Close()
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbProgramID.Items.Add(New ProgramIDItem("Facesso Standard V1.0", 1))
        cmbProgramID.Items.Add(New ProgramIDItem("Facesso Professional V1.0", 2))
        cmbProgramID.Items.Add(New ProgramIDItem("Facesso Enterprise V1.0", 3))
        cmbProgramID.Items.Add(New ProgramIDItem("Facesso Standard V2.0", 4))
        cmbProgramID.Items.Add(New ProgramIDItem("Facesso Professional V2.0", 5))
        cmbProgramID.Items.Add(New ProgramIDItem("Facesso Enterprise V2.0", 6))
        cmbProgramID.SelectedIndex = 0
        mtbLimit1.Text = "10"
        mtbLimit2.Text = "10"
        mtbLimit3.Text = "50"
        mtbLimit4.Text = "255"
        mtbBestBefore.Text = "0"
        cmbProgramID.SelectedIndex = 5
    End Sub

    Private Sub btnCalcSerial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcSerial.Click
        'TODO: Bereichsvalidierungen
        Dim locLicenseInfo As ADLicenseInfo
        locLicenseInfo = New ADLicenseInfo(DirectCast(cmbProgramID.SelectedItem, ProgramIDItem).ID, _
                        CByte(mtbBestBefore.Text), CByte(mtbLimit1.Text), CByte(mtbLimit2.Text), _
                        CUShort(mtbLimit3.Text), CUShort(mtbLimit4.Text))

        'License-Info als ULong mit Hex:FFEEDDCCBBAA9988 XORn
        Dim locULongLI As ULong = locLicenseInfo.CompleteStructure
        Debug.Print(locULongLI.ToString)
        myLicenseInfo = BitConverter.GetBytes(locULongLI)

        'Vorseriennummer als String mit codierter License-Info und Datum und Füllbytes hashen...
        dim locKeyString as String=(new ADNUmberSystems(locULongLI,20)).ToString(16)+Date.Now.ToString("ddMMyyyy")
        Dim locMACTripleDES As New MACTripleDES(ADCryptography.ToByteArray(locKeyString))
        Dim locPreSerial As String = mtbPreSerial.Text 
        mySerialPart = locMACTripleDES.ComputeHash(ADCryptography.ToByteArray(locPreSerial))

        'Seriennummer/License-Info-Kombo als Seriennummer String ausgeben
        Dim locComSerial As String = (New ADNumberSystems(BitConverter.ToUInt64(mySerialPart, 0), 20)).ToString(15)
        locULongLI = locULongLI Xor &HFFEEDDCCBBAA9988UL
        locComSerial += New ADNumberSystems(locULongLI, 20).ToString(15)
        Dim locFormattedSerial As String = ""
        dim locCount as Integer=0
        For Each locChar As Char In locComSerial
            If locCount = 5 Then
                locCount = 0
                locFormattedSerial += " - "
            End If
            locFormattedSerial += locChar.ToString
            locCount += 1
        Next

        txtSerialNumber.Text = locFormattedSerial

        'Ins Clipboard kopieren
        My.Computer.Clipboard.SetText(locFormattedSerial)
    End Sub

End Class

Friend Class ProgramIDItem

    Private myEntryText As String
    Private myID As Byte

    Sub New(ByVal EntryText As String, ByVal ID As Byte)
        myID = ID
        myEntryText = EntryText
    End Sub

    Public ReadOnly Property ID() As Byte
        Get
            Return myID
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return String.Format("{0}: {1}", myID, myEntryText)
    End Function
End Class
