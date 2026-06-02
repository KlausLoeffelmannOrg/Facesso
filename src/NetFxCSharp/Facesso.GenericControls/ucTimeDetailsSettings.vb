Imports Facesso.Data
Imports System.ComponentModel
Imports System.Collections.ObjectModel

Public Class ucTimeDetailsSettings

    Protected myTSDetails As TimeSettingDetails
    Protected myCurrentlyDisplayedShift As Integer
    Protected myCurrentlyDisplayedWeekday As TimeSettingDetailsWeekdays
    Protected myWeekdayButtons As New KeyedControlCollection
    Protected myInitialized As Boolean
    Protected myHasntGotData As Boolean = True
    'Protected myShiftTabs As KeyedControlCollection

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        myTSDetails = New TimeSettingDetails()
        With myWeekdayButtons
            .Add(btnWD_01_Monday)
            .Add(btnWD_02_Tuesday)
            .Add(btnWD_03_Wednesday)
            .Add(btnWD_04_Thursday)
            .Add(btnWD_05_Friday)
            .Add(btnWD_06_Saturday)
            .Add(btnWD_07_Sunday)
        End With
        myInitialized = True
        myCurrentlyDisplayedShift = 1
        SetControls()
    End Sub

    Public Property CurrentlyDisplayedShift() As Integer
        Get
            Return myCurrentlyDisplayedShift
        End Get
        Set(ByVal value As Integer)
            If value = 0 Then value = 1
            SaveData()
            myCurrentlyDisplayedShift = value
            SetControls()
        End Set
    End Property

    Public Property CurrentlyDisplayedWeekday() As TimeSettingDetailsWeekdays
        Get
            Return myCurrentlyDisplayedWeekday
        End Get
        Set(ByVal value As TimeSettingDetailsWeekdays)
            SaveData()
            myCurrentlyDisplayedWeekday = value
            SetControls()
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property TSDetails() As TimeSettingDetails
        Get
            Return myTSDetails
        End Get
        Set(ByVal value As TimeSettingDetails)
            If value Is Nothing Then
                myHasntGotData = True
            Else
                myHasntGotData = False
            End If
            myTSDetails = value
            SetControls()
        End Set
    End Property

    Sub SetControls()
        'Controls-Zustände anpassen
        If Not myInitialized Or myHasntGotData Then Return

        'Daten einspielen
        Dim locTSD As TimeSettingDetail
        If CurrentlyDisplayedWeekday = TimeSettingDetailsWeekdays.ForAll Then
            locTSD = TSDetails.GenericTimeSettingDetail(CurrentlyDisplayedShift - 1)
            btnReset.Enabled = True
        Else
            locTSD = TSDetails.TimeSettingDetail((CurrentlyDisplayedShift - 1) * 7 + CurrentlyDisplayedWeekday - 1)
            btnReset.Enabled = False
        End If

        ndbCoreTimeStart.TypeSafeValue = locTSD.ShiftStart
        ndbCoreTimeEnd.TypeSafeValue = locTSD.ShiftEnd
        ndbImportTimeStart.TypeSafeValue = locTSD.ImportShiftStart
        ndbImportTimeEnd.TypeSafeValue = locTSD.ImportShiftEnd
        ndbRoundUpBefore.TypeSafeValue = locTSD.RoundUpBefore
        ndbRoundDownAfter.TypeSafeValue = locTSD.RoundDownAfter
        nibPausetime.TypeSafeValue = locTSD.WorkBreak
        nibThreshold.TypeSafeValue = locTSD.Threshold
        ncbForceToHavePause.TypeSafeValue = locTSD.ForceToHavePause

        'Dokumentation der Daten setzen
        If locTSD.ShiftStart.IsNull Or locTSD.ShiftEnd.IsNull Then
            btnStartDate.Text = "- - -"
            btnEndDate.Text = "- - -"
            lblEndTimeDateDecription.Text = ""
            lblImportEndTimeDateDescription.Text = ""
        Else
            With locTSD
                If .ShiftStart > .ShiftEnd Then
                    .ShiftEnd = .ShiftEnd.TypedValue.AddDays(1)
                End If

                If .ShiftEnd.TypedValue.Date = #1/1/2003# Then
                    lblEndTimeDateDecription.Text = "(Derselbe Tag)"
                Else
                    lblEndTimeDateDecription.Text = "(Der Folgetag)"
                End If

                btnStartDate.Text = .ShiftStart.TypedValue.ToShortDateString
                btnEndDate.Text = .ShiftEnd.TypedValue.ToShortDateString

                If Not .ImportShiftEnd.IsNull Then
                    If .ImportShiftStart > .ImportShiftEnd Then
                        .ImportShiftEnd = .ImportShiftEnd.TypedValue.AddDays(1)
                    End If


                    If .ImportShiftEnd.TypedValue.Date = #1/1/2003# Then
                        lblImportEndTimeDateDescription.Text = "(Derselbe Tag)"
                    Else
                        lblImportEndTimeDateDescription.Text = "(Der Folgetag)"
                    End If
                Else
                    .ImportShiftStart = .ShiftStart
                    .ImportShiftEnd = .ShiftEnd
                End If
            End With
        End If

        'Schichttab wählen
        Select Case CurrentlyDisplayedShift
            Case 1
                tcShifts.SelectedTab = tpShift1
                lblShiftInformer.Text = "für Schicht 1"
            Case 2
                tcShifts.SelectedTab = tpShift2
                lblShiftInformer.Text = "für Schicht 2"
            Case 3
                tcShifts.SelectedTab = tpShift3
                lblShiftInformer.Text = "für Schicht 3"
            Case 4
                tcShifts.SelectedTab = tpShift4
                lblShiftInformer.Text = "für Sonderschicht"
        End Select

        'Buttonfarbe und Selektierung setzen
        If CurrentlyDisplayedWeekday = TimeSettingDetailsWeekdays.ForAll Then
            btnGeneric.BackColor = Color.Yellow
        Else
            btnGeneric.BackColor = SystemColors.Control
        End If

        For locCount As Integer = 0 To 6
            Dim locBtn As Button = DirectCast(myWeekdayButtons(locCount), Button)
            ' Generischer Tag immer fett
            If TSDetails.TimeSettingDetail((CurrentlyDisplayedShift - 1) * 7 + locCount).IsDerived Then
                locBtn.Font = New Font(locBtn.Font, FontStyle.Regular)
            Else
                locBtn.Font = New Font(locBtn.Font, FontStyle.Bold)
            End If

            If locCount = Convert.ToInt32(CurrentlyDisplayedWeekday) - 1 Then
                locBtn.BackColor = Color.Yellow
            Else
                locBtn.BackColor = SystemColors.Control
            End If
        Next

        'Listbox aufbereiten:
        'Erst die Generischen Tage anzeigen
        lbTimes.Items.Clear()
        For z As Integer = 0 To 3
            lbTimes.Items.Add(Me.TSDetails.GenericTimeSettingDetail(z).ToString)
        Next

        'Dann den Rest
        For z As Integer = 0 To 6
            For s As Integer = 0 To 3
                lbTimes.Items.Add(Me.TSDetails.TimeSettingDetail((s) * 7 + z))
            Next
        Next


    End Sub

    Private Sub SaveData()
        Dim locTSD As TimeSettingDetail
        Dim locIsGeneric As Boolean = False
        If CurrentlyDisplayedWeekday = TimeSettingDetailsWeekdays.ForAll Then
            locTSD = TSDetails.GenericTimeSettingDetail(CurrentlyDisplayedShift - 1)
            locIsGeneric = True
        Else
            locTSD = TSDetails.TimeSettingDetail((CurrentlyDisplayedShift - 1) * 7 + CurrentlyDisplayedWeekday - 1)
        End If

        locTSD.ShiftStart = ndbCoreTimeStart.TypeSafeValue
        locTSD.ShiftEnd = ndbCoreTimeEnd.TypeSafeValue
        locTSD.ImportShiftStart = ndbImportTimeStart.TypeSafeValue
        locTSD.ImportShiftEnd = ndbImportTimeEnd.TypeSafeValue
        locTSD.RoundUpBefore = ndbRoundUpBefore.TypeSafeValue
        locTSD.RoundDownAfter = ndbRoundDownAfter.TypeSafeValue
        locTSD.WorkBreak = nibPausetime.TypeSafeValue
        locTSD.Threshold = nibThreshold.TypeSafeValue
        locTSD.ForceToHavePause = ncbForceToHavePause.TypeSafeValue
        locTSD.ForShift = CurrentlyDisplayedShift

        'Plausibilitätskontrolle
        If locTSD.ShiftStart.IsNull Or locTSD.ShiftEnd.IsNull Then
            locTSD.NullAll()
        Else
            With locTSD
                Dim locTimeSpanStart As TimeSpan
                Dim locTimeSpanEnd As TimeSpan

                If Not .ImportShiftStart.IsNull Then
                    locTimeSpanStart = .ImportShiftStart.TypedValue.TimeOfDay
                    .ImportShiftStart = #1/1/2003#.Add(locTimeSpanStart)
                End If

                If Not .ImportShiftEnd.IsNull Then
                    locTimeSpanEnd = .ImportShiftEnd.TypedValue.TimeOfDay
                    .ImportShiftEnd = #1/1/2003#.Add(locTimeSpanEnd)
                End If

                locTimeSpanStart = .ShiftStart.TypedValue.TimeOfDay
                locTimeSpanEnd = .ShiftEnd.TypedValue.TimeOfDay
                .ShiftStart = #1/1/2003#.Add(locTimeSpanStart)
                .ShiftEnd = #1/1/2003#.Add(locTimeSpanEnd)

                If .ShiftStart > .ShiftEnd Then
                    .ShiftEnd = .ShiftEnd.TypedValue.AddDays(1)
                End If

                If .ImportShiftStart.IsNull Then
                    .ImportShiftStart = .ShiftStart.TypedValue
                End If

                If .ImportShiftEnd.IsNull Then
                    .ImportShiftEnd = .ShiftEnd.TypedValue
                End If

                If .ImportShiftStart > .ImportShiftEnd Then
                    .ImportShiftEnd = .ImportShiftEnd.TypedValue.AddDays(1)
                End If
            End With
        End If

        With locTSD
            If Not .RoundUpBefore.IsNull Then
                Dim locTimeSpan As TimeSpan = .RoundUpBefore.TypedValue.TimeOfDay
                .RoundUpBefore = .ImportShiftStart.TypedValue.Date
                .RoundUpBefore = .RoundUpBefore.TypedValue.Add(locTimeSpan)
                If .RoundUpBefore > .ImportShiftStart Then
                    .RoundUpBefore = .ImportShiftStart
                End If
            End If

            If Not .RoundDownAfter.IsNull Then
                Dim locTimeSpan As TimeSpan = .RoundDownAfter.TypedValue.TimeOfDay
                .RoundDownAfter = .ImportShiftEnd.TypedValue.Date
                .RoundDownAfter = .RoundDownAfter.TypedValue.Add(locTimeSpan)
                If .RoundDownAfter < .ImportShiftEnd Then
                    .RoundDownAfter = .ImportShiftEnd
                End If
            End If

        End With

        'Falls es kein generischer Datenblock war, dann rausfinden, ob
        'Daten der generischen Vorlage entsprechen!
        If Not locIsGeneric Then
            If TSDetails.GenericTimeSettingDetail(CurrentlyDisplayedShift - 1).IsEqual(locTSD) Then
                locTSD.IsDerived = True
            Else
                locTSD.IsDerived = False
            End If
        End If

        'Falls Änderungen an der Vorlage, dann alle ändern,
        'die nicht abgeleitet sind!
        If locIsGeneric Then
            For locCount As Integer = 0 To 6
                If TSDetails.TimeSettingDetail((CurrentlyDisplayedShift - 1) * 7 + locCount).IsDerived Then
                    TSDetails.TimeSettingDetail((CurrentlyDisplayedShift - 1) * 7 + locCount) = locTSD.Clone
                    TSDetails.TimeSettingDetail((CurrentlyDisplayedShift - 1) * 7 + locCount).ForWeekday = CType(locCount + 1, TimeSettingDetailsWeekdays)
                End If
                'Und die, die gleich geworden sind, wieder einbinden.
                If TSDetails.TimeSettingDetail((CurrentlyDisplayedShift - 1) * 7 + locCount).IsEqual(locTSD) Then
                    TSDetails.TimeSettingDetail((CurrentlyDisplayedShift - 1) * 7 + locCount).IsDerived = True
                End If
            Next
        End If
    End Sub

    Private Sub btnGeneric_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGeneric.Click, btnWD_01_Monday.Click, btnWD_07_Sunday.Click, btnWD_06_Saturday.Click, btnWD_05_Friday.Click, btnWD_04_Thursday.Click, btnWD_03_Wednesday.Click, btnWD_02_Tuesday.Click
        If DirectCast(sender, Control).Name = btnGeneric.Name Then
            CurrentlyDisplayedWeekday = TimeSettingDetailsWeekdays.ForAll
        Else
            For i As Integer = 0 To 6
                If DirectCast(sender, Control).Name = myWeekdayButtons(i).Name Then
                    CurrentlyDisplayedWeekday = CType(i + 1, TimeSettingDetailsWeekdays)
                    Return
                End If
            Next
        End If
    End Sub

    Private Sub tcShifts_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles tcShifts.Selected
        CurrentlyDisplayedShift = e.TabPageIndex + 1
    End Sub

    Private Sub ndbCoreTimeStart_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ndbCoreTimeStart.Validated
        If ndbCoreTimeEnd.TypeSafeValue.IsNull Then
            ndbCoreTimeEnd.TypeSafeValue = ndbCoreTimeStart.TypeSafeValue
        End If
        SaveData()
        SetControls()
    End Sub

    Private Sub ndbCoreTimeEnd_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ndbCoreTimeEnd.Validated
        If ndbCoreTimeStart.TypeSafeValue.IsNull Then
            ndbCoreTimeStart.TypeSafeValue = ndbCoreTimeEnd.TypeSafeValue
        End If
        SaveData()
        SetControls()
    End Sub

    Private Sub ndbRoundUpBefore_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ndbRoundUpBefore.Validated, ndbRoundDownAfter.Validated
        SaveData()
        SetControls()
    End Sub

    Private Sub ndbImportTimeStart_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ndbImportTimeStart.Validated
        If ndbImportTimeEnd.TypeSafeValue.IsNull Then
            ndbImportTimeEnd.TypeSafeValue = ndbImportTimeStart.TypeSafeValue
        End If
        SaveData()
        SetControls()
    End Sub

    Private Sub ndbImportTimeEnd_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ndbImportTimeEnd.Validated
        If ndbImportTimeStart.TypeSafeValue.IsNull Then
            ndbImportTimeStart.TypeSafeValue = ndbImportTimeEnd.TypeSafeValue
        End If
        SaveData()
        SetControls()
    End Sub

    ''' <summary>
    ''' Setzt, wenn "für alle Wochentage" ausgewählt ist, alle Tagesunterschiede zurück.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        For locCount As Integer = 0 To 6
            TSDetails.TimeSettingDetail((CurrentlyDisplayedShift - 1) * 7 + locCount) = TSDetails.GenericTimeSettingDetail(CurrentlyDisplayedShift - 1).Clone
            SetControls()
        Next
    End Sub
End Class

Public Class KeyedControlCollection
    Inherits KeyedCollection(Of String, Control)

    Protected Overrides Function GetKeyForItem(ByVal item As System.Windows.Forms.Control) As String
        Return item.Name
    End Function
End Class
