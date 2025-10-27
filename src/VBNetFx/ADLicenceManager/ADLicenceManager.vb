Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports ActiveDev

''' <summary>
''' Klasse zum Binden der Software an einer Hardware. Die Klasse ermittelt aus verschiedenen 
''' Hardwarekomponenten eine Kennummer, die mit einer weiteren Kennnummer verschlüsselt wird. 
''' Diese weitere Kennnummer ergibt sich aus verschiedenen Angaben, die durch die ADLicenseInfo-Klasse 
''' verwaltet wird. Bei der Installation wird aus der Ausgangskennnummer zunächst eine Vorseriennummer 
''' gebildet, die der Kunde mitteilen muss. Aus der Vorseriennummer wird die Ausgangskennnummer 
''' zurückgerechnet, und der Kunde erhält die finale Seriennummer, in der sowohl die aktuelle 
''' Installationszeit als auch die durch ADLicence-Info gespeicherten Daten eingehen (sie werden damit 
''' verschlüsselt). Beim Anschließenden Start der Software wird die Rechnerkonfiguraration gelesen 
''' und der gleiche Verschlüsselungsvorgang durchgeführt. Der gespeicherte Schlüssel muss nun dem 
''' daraus errechneten Schlüssel entsprechen. Das ist nicht mehr der Fall, wenn die Konfigurationsdaten der
''' Software oder die Hardware-Kennnummer nicht mit den Ausgangsdaten übereinstimmen - die Software-
''' parameter sind damit genau wie die Software selber an den entsprechenden Computer gebunden.
''' </summary>
''' <remarks></remarks>
<CLSCompliant(False)> _
Public Class ADLicenseManager

    Protected myLicenseInfo As ADLicenseInfo
    Private myGuid As String
    Private myGivenTotalSerialNumber As Byte()
    Private myGivenSerialNumber As Byte()
    Private myGivenLicenseInfo As Byte()
    Private myCalcSerialNumber As Byte()
    Protected myInstallDate As Date
    Protected myLastRunDate As Date

    ''' <summary>
    ''' Erstellt eine neue Instanz dieser Klasse.
    ''' </summary>
    ''' <param name="prgGUID">Eine eindeutige GUID, die zur Identifizierung der Software verwendet wird.</param>
    ''' <param name="InstallationDate">Das Datum der Installation, das in den Bindungsalgorithmus (Programm->Rechner) mit einfließt.</param>
    ''' <param name="LastRunDate">Das Datum, an dem die Software zuletzt gestartet wurde. 
    ''' Dieser Parameter ist wichtig, damit eine auf Zeit limitierte Software erkannt werden kann.</param>
    ''' <param name="LastRegisteredDate">Der Zeitpunkt der letzten Registrierung der Software.</param>
    ''' <param name="SerialNumber">Die Seriennummer der Software.</param>
    ''' <remarks></remarks>
    Sub New(ByVal prgGUID As Guid, ByVal InstallationDate As Date, ByVal LastRunDate As Date, _
            ByVal LastRegisteredDate As Date, ByVal SerialNumber As String)

        'Falls wir noch Leerzeichen darin haben, diese mit Nummern ersetzen.
        SerialNumber = SerialNumber.Replace(" "c, "0"c)
        SerialNumber = SerialNumber.Replace("-", "")

        If SerialNumber Is Nothing Then
            SerialNumber = New String("A"c, 30)
        Else
            If SerialNumber.Length < 30 Then
                SerialNumber = New String("0"c, 30 - SerialNumber.Length) + SerialNumber
            End If
        End If



        Dim locGivenSerialNumber As ULong
        Try
            locGivenSerialNumber = ADNumberSystems.Parse(SerialNumber.Substring(0, 15), 20).Value
        Catch ex As Exception
            locGivenSerialNumber = 0
        End Try

        Dim locGivenLicenseInfo As ULong
        Try
            locGivenLicenseInfo = ADNumberSystems.Parse(SerialNumber.Substring(15), 20).Value
        Catch ex As Exception
            locGivenLicenseInfo = 0
        End Try

        locGivenLicenseInfo = locGivenLicenseInfo Xor &HFFEEDDCCBBAA9988UL
        myLicenseInfo = New ADLicenseInfo(locGivenLicenseInfo)
        myInstallDate = InstallationDate
        myLastRunDate = LastRunDate

        'Vorseriennummer als String mit codierter License-Info, Datum und Füllbytes hashen...
        Dim locKeyString As String = (New ADNumberSystems(locGivenLicenseInfo, 20)).ToString(16) + LastRegisteredDate.ToString("ddMMyyyy")
        Dim locMACTripleDES As New MACTripleDES(ADCryptography.ToByteArray(locKeyString))
        Dim locPreSerial As String = GetPreSerialNo(prgGUID, InstallationDate)

        myCalcSerialNumber = locMACTripleDES.ComputeHash(ADCryptography.ToByteArray(locPreSerial))
        myGivenSerialNumber = BitConverter.GetBytes(locGivenSerialNumber)

    End Sub

    ''' <summary>
    ''' Ermittelt die Vorseriennummer der Software.
    ''' </summary>
    ''' <param name="prgGUID">Eine eindeutige GUID, die zur Identifizierung der Software verwendet wird.</param>
    ''' <param name="InstallationDate">Das Datum der Installation, das in den Bindungsalgorithmus (Programm->Rechner) mit einfließt.</param>
    ''' <returns>Zeichenkette, die die Vorseriennummer des Programms enthält.</returns>
    ''' <remarks></remarks>
    Public Shared Function GetPreSerialNo(ByVal prgGuid As Guid, ByVal InstallationDate As Date) As String

        Dim locComputerInfoString As String = ADComputerInfo.GetBiosInfoString()
        Dim locPreSerial As Byte()
        locComputerInfoString += ADComputerInfo.GetBoardInfoString()
        locComputerInfoString += prgGuid.ToString
        locComputerInfoString += installationDate.ToString

        Dim locMACTripleDES As New MACTripleDES(ADCryptography.ToByteArray("Nicht genügend Speicher!"))
        locPreSerial = locMACTripleDES.ComputeHash(ADCryptography.ToByteArray(locComputerInfoString))
        Dim locULongTemp As ULong = BitConverter.ToUInt64(locPreSerial, 0)
        'Debug.Print(locULongTemp.ToString)
        Return (New ADNumberSystems(locULongTemp, 20)).ToString(15)

    End Function

    ''' <summary>
    ''' Liefert die LicenseInfo-Struktur zurück, die sich aus der Seriennnummer des Programms ergibt.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function LicenseInfo() As ADLicenseInfo
        Return myLicenseInfo
    End Function

    ''' <summary>
    ''' Bestimmt, ob die Software durch Hardware-Kennnummer/Seriennummervergleich als lizensiert gilt.
    ''' </summary>
    ''' <returns>True, wenn die Lizensierung gültig ist.</returns>
    ''' <remarks></remarks>
    Public Overridable Function IsLicensed() As Boolean
        Return HasValidSerialNo()
    End Function

    ''' <summary>
    ''' Überprüft, ob es sich bei der Seriennummer um eine gültige Seriennummer handelt, die 
    ''' zu einer ordnungsgemäßen Lizensierung führen würde.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overridable Function HasValidSerialNo() As Boolean
        For locCount As Integer = 0 To myCalcSerialNumber.Length - 1
            If myCalcSerialNumber(locCount) <> myGivenSerialNumber(locCount) Then
                Return False
            End If
        Next
        Return True
    End Function

    Public ReadOnly Property IsSerialNoValid() As Boolean
        Get
            Return HasValidSerialNo()
        End Get
    End Property

    ''' <summary>
    ''' Ermittelt, wann die Software abläuft (falls die Software auf einen zeitlichen Rahmen limitiert wurde).
    ''' </summary>
    ''' <value></value>
    ''' <returns>Das Ablaufdatum.</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property BestBefore() As Date
        Get
            Dim locDate As Date = myInstallDate
            locDate = locDate.AddMonths(myLicenseInfo.MonthsLimited)
            Return locDate
        End Get
    End Property
End Class

''' <summary>
''' Diese Struktur dient dazu, gewissen Rahmenparameter für verschiedene Ausbaustufen einer Software 
''' festzuhalten. Dazu gehören eine eindeutige Software-ID, die für verschiedene Grundversionen 
''' verwendet werden kann (zum Beispiel Standard, Professional, Enterprise). Zusätzliche Limitierungen 
''' sind ebenfalls verankerbar, und werden durch entsprechende Eigenschaften bestimmt. Diese Struktur 
''' geht fest in die Seriennummer der Software mit ein; auf diese Weise kann eine Software für höhere 
''' Ausbaustufen (Standard zu Professional, Professional zu Enterprise) nur durch die Neueingabe einer  
''' entsprechenden Seriennummer freigeschaltet werden.
''' </summary>
''' <remarks></remarks>
<CLSCompliant(False), _
 StructLayout(LayoutKind.Explicit)> _
Public Structure ADLicenseInfo

    <FieldOffset(0)> Private myCompleteStructure As ULong
    <FieldOffset(0)> Private mySoftwareID As Byte       ' 1=Facesso 1.0 Standard
    <FieldOffset(1)> Private myMonthsLimited As Byte
    <FieldOffset(2)> Private myLimit1 As Byte           ' User
    <FieldOffset(3)> Private myLimit2 As Byte           ' Internet-User
    <FieldOffset(4)> Private myLimit3 As UShort         ' Mitarbeiter
    <FieldOffset(6)> Private myLimit4 As UShort         ' nicht verwendet
    <FieldOffset(8)> Private myHasFallenBack As Boolean      ' War Fallback!

    ''' <summary>
    ''' Erstellt eine Instanz dieser Struktur und bestimmt die Rahmenparameter.
    ''' </summary>
    ''' <param name="SoftwareID">Eindeutige Software-ID (beispielsweise 0 für Standard, 1 für Professional, etc.)</param>
    ''' <param name="MonthsLimited">Anzahl der Monate, auf die die Software limitiert werden soll; danach liefert 
    ''' die Funktion IsLicensed der AdLicenseManager-Klasse false zurück.</param>
    ''' <param name="Limit1">1. limitierender Parameter, den die Software als beliebiges Rahmendatum verwenden kann (beispielsweise Mitarbeiterbeschränkung)</param>
    ''' <param name="Limit2">2. limitierender Parameter, den die Software als beliebiges Rahmendatum verwenden kann (beispielsweise Mitarbeiterbeschränkung)</param>
    ''' <param name="Limit3">3. limitierender Parameter, den die Software als beliebiges Rahmendatum verwenden kann (beispielsweise Mitarbeiterbeschränkung)</param>
    ''' <param name="Limit4">4. limitierender Parameter, den die Software als beliebiges Rahmendatum verwenden kann (beispielsweise Mitarbeiterbeschränkung)</param>
    ''' <remarks></remarks>
    Sub New(ByVal SoftwareID As Byte, ByVal MonthsLimited As Byte, ByVal Limit1 As Byte, ByVal Limit2 As Byte, ByVal Limit3 As UShort, ByVal Limit4 As UShort)
        mySoftwareID = SoftwareID
        myMonthsLimited = MonthsLimited
        myLimit1 = Limit1
        myLimit2 = Limit2
        myLimit3 = Limit3
        myLimit4 = Limit4
    End Sub

    ''' <summary>
    ''' Erstellt eine Instanz dieser Struktur aus einem InfoKey (Zeichenfolge), der sich beispielsweise durch eine Seriennummer ergibt.
    ''' </summary>
    ''' <param name="InfoKey">Zeichenfolge, die den InfoKey repräsentiert.</param>
    ''' <remarks></remarks>
    Sub New(ByVal InfoKey As String)
        Dim locNumberSystems As ADNumberSystems = ADNumberSystems.Parse(InfoKey, 32)
        myCompleteStructure = locNumberSystems.Value
    End Sub

    ''' <summary>
    ''' Erstellt eine Instanz dieser Struktur aus einem InfoKey (Byte-Array), der sich beispielsweise durch eine Seriennummer ergibt.
    ''' </summary>
    ''' <param name="InfoKeyBits">Byte-Array, das den InfoKey repräsentiert.</param>
    ''' <remarks></remarks>
    Sub New(ByVal InfoKeyBits As Byte())
        Dim locADLicenceInfo As New ADLicenseInfo(BitConverter.ToUInt64(InfoKeyBits, 0))
        mySoftwareID = locADLicenceInfo.SoftwareID
        myMonthsLimited = locADLicenceInfo.MonthsLimited
        myLimit1 = locADLicenceInfo.Limit1
        myLimit2 = locADLicenceInfo.Limit2
        myLimit3 = locADLicenceInfo.Limit3
        myLimit4 = locADLicenceInfo.Limit4
    End Sub

    ''' <summary>
    ''' Erstellt eine Instanz dieser Struktur aus einer anderen Struktur (dient zum Klonen einer anderen Struktur)
    ''' </summary>
    ''' <param name="li"></param>
    ''' <remarks></remarks>
    Sub New(ByVal li As ADLicenseInfo)
        mySoftwareID = li.SoftwareID
        myMonthsLimited = li.MonthsLimited
        myLimit1 = li.Limit1
        myLimit2 = li.Limit2
        myLimit3 = li.Limit3
        myLimit4 = li.Limit4
    End Sub

    Public Overrides Function ToString() As String
        Return (New ADNumberSystems(myCompleteStructure, 32)).ToString()
    End Function

    ''' <summary>
    ''' Nur für die Interne Verwendung; baut diese Struktur aus einem 64-Bit-Konstruktor auf.
    ''' </summary>
    ''' <param name="completeStructure">64-Bit-Abbild (unsigned) dieser Struktur.</param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal completeStructure As ULong)
        myCompleteStructure = completeStructure
    End Sub

    ''' <summary>
    ''' Liefert die Bitwerte dieser Struktur als Byte-Array zurück.
    ''' </summary>
    ''' <returns>Byte-Array, das die Werte dieser Struktur enthält.</returns>
    ''' <remarks></remarks>
    Public Function ToByteArray() As Byte()
        Return BitConverter.GetBytes(myCompleteStructure)
    End Function

    ''' <summary>
    ''' Kann von der zuschützenden Software selbst aufgerufen, wenn die Seriennummer ungültig ist, 
    ''' um eine zeitlich limitierte Version aufgrund der falschen Seriennummer daraus zu machen.
    ''' </summary>
    ''' <param name="ToMonths">Die Anzahl der Monate, die die Software trotz falscher Seriennummer 
    ''' freigeschaltet sein soll.</param>
    ''' <param name="ID">Die ID der Software (z.B. 0=Standard, 1=Professional, 2=Enterprise), auf die wegen 
    ''' ungültiger Seriennummer gestuft werden soll.</param>
    ''' <remarks></remarks>
    Public Sub Fallback(ByVal ToMonths As Byte, ByVal ID As Byte)
        If ToMonths > 3 Then
            'Strafe muss sein.
            ToMonths = 1
        End If
        If ToMonths < 2 Then
            ToMonths = 2
        End If
        myHasFallenBack = True
        myMonthsLimited = ToMonths
        mySoftwareID = ID
    End Sub

    ''' <summary>
    ''' Ermittelt die ID der Software (zum Beispiel 0 für Standard, 1 für Professional, 2 für Enterprise, etc.).
    ''' </summary>
    ''' <value></value>
    ''' <returns>Byte-Wert, der die Software-Ausbaustufe repräsentiert (siehe Zusammenfassung).</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SoftwareID() As Byte
        Get
            Return mySoftwareID
        End Get
    End Property

    ''' <summary>
    ''' Ermittelt, auf wieviele Einsatzmonate die Software beschränkt ist.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Byte-Wert, der die möglichen Einsatzmonate angibt.</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property MonthsLimited() As Byte
        Get
            Return myMonthsLimited
        End Get
    End Property

    ''' <summary>
    ''' Erster von der Software selbst zu nutzender, beliebiger Lizenzwert. Beispielsweise eine 
    ''' Beschränkung auf bestimmte Maschinentypen oder Maschinenanzahlen, Mitarbeiter, Artikel, 
    ''' oder sonstiger Geräte. 
    ''' </summary>
    ''' <value></value>
    ''' <returns>Byte-Wert, der diesen Parameter repräsentiert.</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Limit1() As Byte
        Get
            Return myLimit1
        End Get
    End Property

    ''' <summary>
    ''' Zweiter von der Software selbst zu nutzender, beliebiger Lizenzwert. Beispielsweise eine 
    ''' Beschränkung auf bestimmte Maschinentypen oder Maschinenanzahlen, Mitarbeiter, Artikel, 
    ''' oder sonstiger Geräte. 
    ''' </summary>
    ''' <value></value>
    ''' <returns>Byte-Wert, der diesen Parameter repräsentiert.</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Limit2() As Byte
        Get
            Return myLimit2
        End Get
    End Property

    ''' <summary>
    ''' Dritter von der Software selbst zu nutzender, beliebiger Lizenzwert. Beispielsweise eine 
    ''' Beschränkung auf bestimmte Maschinentypen oder Maschinenanzahlen, Mitarbeiter, Artikel, 
    ''' oder sonstiger Geräte. 
    ''' </summary>
    ''' <value></value>
    ''' <returns>Byte-Wert, der diesen Parameter repräsentiert.</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Limit3() As UShort
        Get
            Return myLimit3
        End Get
    End Property

    ''' <summary>
    ''' Vierter von der Software selbst zu nutzender, beliebiger Lizenzwert. Beispielsweise eine 
    ''' Beschränkung auf bestimmte Maschinentypen oder Maschinenanzahlen, Mitarbeiter, Artikel, 
    ''' oder sonstiger Geräte. 
    ''' </summary>
    ''' <value></value>
    ''' <returns>Byte-Wert, der diesen Parameter repräsentiert.</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Limit4() As UShort
        Get
            Return myLimit4
        End Get
    End Property

    ''' <summary>
    ''' Liefert die komplette Struktur als Zusammenfassung in einem unsigned Long zurück.
    ''' </summary>
    ''' <value></value>
    ''' <returns>ULong, der die Strukturinhalte als 64-Bit-Wert wiedergibt</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CompleteStructure() As ULong
        Get
            Return myCompleteStructure
        End Get
    End Property

    ''' <summary>
    ''' Stellt fest, ob ein FallBack auf Grund einer ungültigen Seriennummer stattgefunden hat.
    ''' </summary>
    ''' <value></value>
    ''' <returns>True, wenn ein FallBack stattgefunden hat.</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property HasFallenBack() As Boolean
        Get
            Return myHasFallenBack
        End Get
    End Property
End Structure

''' <summary>
''' Ausnahme, die an die Anwendung aufgrund einer ungültigen Lizenz hochgereicht wird.
''' </summary>
''' <remarks></remarks>
Public Class ADLicenseUnvalidException
    Inherits ApplicationException

    Dim myBestBefore As Date
    Dim myReason As ADLicenseUnvalidReason

    ''' <summary>
    ''' Legt eine neue Instanz dieser Klasse an.
    ''' </summary>
    ''' <param name="BestBefore">Bei einem Fall-Back - das Ablaufdatum, zu dem die Software nicht 
    ''' mehr gültig ist. Die Anwendung muss den Start nach diesem Datum selber verhindern! 
    ''' (Siehe HasFallenBack- und BestBefore-Eigenschaften der AdLicenseInfo-Klasse)</param>
    ''' <param name="Reason">Der Grund des Zurückfallens auf eine beschränkte Version.</param>
    ''' <param name="Message">Eine Zeichenkette, die die beschreibende Nachricht der Ausnahme enthält.</param>
    ''' <remarks></remarks>
    Sub New(ByVal BestBefore As Date, ByVal Reason As ADLicenseUnvalidReason, ByVal Message As String)
        MyBase.New(Message)
        myBestBefore = BestBefore
    End Sub

    ''' <summary>
    ''' Bei einem FallBack - das Ablaufdatum, zu dem die Software nicht 
    ''' mehr gültig ist. Die Anwendung muss den Start nach diesem Datum selber verhindern! 
    ''' (Siehe HasFallenBack- und BestBefore-Eigenschaften der AdLicenseInfo-Klasse)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BestBefore() As Date
        Get
            Return myBestBefore
        End Get
        Set(ByVal value As Date)
            myBestBefore = value
        End Set
    End Property

    ''' <summary>
    ''' Der Grund des Zurückfallens auf eine beschränkte Version.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Reason() As ADLicenseUnvalidReason
        Get
            Return myReason
        End Get
        Set(ByVal value As ADLicenseUnvalidReason)
            myReason = value
        End Set
    End Property
End Class

''' <summary>
''' Enumeration, die den Grund einer ungültigen Lizenz umschreibt.
''' </summary>
''' <remarks></remarks>
Public Enum ADLicenseUnvalidReason
    ''' <summary>
    ''' Die Version hat das BestBefore-Datum erreicht, ist also abgelaufen.
    ''' </summary>
    ''' <remarks></remarks>
    Expired

    ''' <summary>
    ''' Das hinterlegte Registrierungsdatum wurde vermutlich manipuliert.
    ''' </summary>
    ''' <remarks></remarks>
    SystemDateManipulated

    ''' <summary>
    ''' Die Software-ID (zum Beispiel 0 für Standard, 1 für Professional, etc.) stimmt nicht mit der 
    ''' ID überein, die sich aus der Seriennummer ergibt.
    ''' </summary>
    ''' <remarks></remarks>
    WrongSoftware
End Enum
