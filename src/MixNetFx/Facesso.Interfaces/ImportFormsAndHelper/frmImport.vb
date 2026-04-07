Imports ActiveDev
Imports Facesso
Imports Facesso.Data
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Reflection
Imports System.Xml.Serialization

Public Class frmImport

    Private Shared myInterfaces As InterfaceClassItems
    Public Const TaskItemsFilename As String = "FacTaskItems.xml"
    Private myTasks As FacessoTaskItems
    Private myTasksTemplates As FacessoTaskItems
    Private myResultMessage As String
    Private myCancelImport As Boolean

    Private myWorkgroups As WorkGroupInfoItems
    Private myFacessoGeneralOptions As FacessoGeneralOptions

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CreateInterfaceDirectoryOnDemand()
        DeserializeTaskItemsFromFile()
        InitializeTaskList()
        rebuildTaskList()
        myWorkgroups = New WorkGroupInfoItems(True)
        ucWorkGroups.WorkGroupInfoItems = myWorkgroups
        ToggleWorkGroupItems(True)

        myFacessoGeneralOptions = DirectCast( _
            FacessoGeneric.FacessoUserSettings.Settings.GetItem("FacessoGeneralOptions", _
            New FacessoGeneralOptions(False, False, True, False, 60)), FacessoGeneralOptions)

    End Sub

    Private Sub InitializeTaskList()
        With lvwTaskList
            With .Columns
                .Add("", 20, HorizontalAlignment.Left)
                .Add("Task-Name", -2, HorizontalAlignment.Left)
                .Add("Import-Typ", -2, HorizontalAlignment.Left)
            End With
        End With
    End Sub

    Private Sub CreateInterfaceDirectoryOnDemand()
        If Not InterfaceDirectory.Exists Then
            InterfaceDirectory.Create()
        End If
    End Sub

    Public Shared ReadOnly Property Interfaces() As InterfaceClassItems
        Get
            If myInterfaces Is Nothing Then
                myInterfaces = InterfaceClassItems.ThroughReflection()
            End If
            Return myInterfaces
        End Get
    End Property

    Public Shared Function InterfaceDirectory() As DirectoryInfo
        Return New DirectoryInfo(FacessoGeneric.SharedFolder & "\Interfaces")
    End Function

    Private Function GetSerialisationTypes() As Type()
        Dim locTypes As New System.Collections.ArrayList
        'Alle vorhandenen Interfaces durchsuchen
        For Each locInterfaceItem As FacessoInterfaceClassItem In Interfaces
            Dim locFound As Boolean
            For Each locType As Type In locTypes
                If locType Is locInterfaceItem.InterfaceType Then
                    locFound = True
                    Exit For
                End If
            Next
            If Not locFound Then
                locTypes.Add(locInterfaceItem.InterfaceType)
            End If
        Next
        Return DirectCast(locTypes.ToArray(GetType(Type)), Type())
    End Function

    Private Sub DeserializeTaskItemsFromFile()
        Dim locTaskFile As New FileInfo(InterfaceDirectory.ToString & "\" & TaskItemsFilename)
        If Not locTaskFile.Exists Then
            myTasks = New FacessoTaskItems
        Else
            Dim locXml As New XmlSerializer(GetType(FacessoTaskItems), GetSerialisationTypes)
            Dim locSr As New StreamReader(InterfaceDirectory.ToString & "\" & TaskItemsFilename)
            myTasks = DirectCast(locXml.Deserialize(locSr), FacessoTaskItems)
            locSr.Close()
        End If
    End Sub

    Public Sub SerializeTaskItemsToFile()
        Dim locXml As New XmlSerializer(GetType(FacessoTaskItems), GetSerialisationTypes)
        'Alle aufgetretenen Typen, die serialisiert werden könnten, in ein Type-Array packen
        Dim locSw As New StreamWriter(InterfaceDirectory.ToString & "\" & TaskItemsFilename, False)
        locXml.Serialize(locSw, myTasks)
        locSw.Flush()
        locSw.Close()
        locSw.Dispose()
    End Sub

    Private Sub frmImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        If Interfaces Is Nothing Then
            MessageBox.Show("Leider sind keine Schnittstellen-Klassen installiert, so dass Sie diese Funktionalität nicht nutzen können.", _
             "Keine Schnittstellen-Klassen registriert.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Hide()
        End If
    End Sub

    Private Sub tsmEditNewImportTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmEditNewImportTask.Click
        Dim locFrm As New frmNewImportTask
        Dim locTask As IFacessoImportTaskItem = locFrm.GetImportTask()
        If locTask Is Nothing Then
            Return
        End If
        If Not locTask.IsGenericInterfaceConfigured Then
            If locTask.ConfigureGenericInterface() = Windows.Forms.DialogResult.Cancel Then
                Return
            End If
        End If
        Dim locDR As DialogResult = locTask.ConfigureImportFilter()
        If locDR = Windows.Forms.DialogResult.Cancel Then
            'Ursprungszustand durch letzten Stand von Platte holen wiederherstellen
            DeserializeTaskItemsFromFile()
            rebuildTaskList()
            Return
        End If
        'Und dafür hier serialisieren
        locTask.Priority = myTasks.NextPriorityLevel
        locTask.TaskID = myTasks.NextTaskID
        myTasks.Add(DirectCast(locTask, FacessoTaskItemBase))
        SerializeTaskItemsToFile()
        rebuildTaskList()
    End Sub

    Private Sub tsmEditImportTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmEditImportTask.Click
        If lvwTaskList.Items Is Nothing OrElse lvwTaskList.Items.Count = 0 Then
            MessageBox.Show("Es sind keine Import-Filter vorhanden, die Sie bearbeiten könnten!", _
                            "Keine Import-Filter verfügbar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If lvwTaskList.SelectedItems.Count = 0 Then
            MessageBox.Show("Es ist kein Import-Filter zum Bearbeiten ausgewählt!", _
                            "Keine Import-Filter verfügbar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim locTask As IFacessoImportTaskItem = DirectCast(lvwTaskList.SelectedItems(0).Tag, IFacessoImportTaskItem)
        Dim locDR As DialogResult = locTask.ConfigureImportFilter()
        If locDR = Windows.Forms.DialogResult.Cancel Then
            'Ursprungszustand durch letzten Stand von Platte holen wiederherstellen
            DeserializeTaskItemsFromFile()
            rebuildTaskList()
            Return
        End If
        SerializeTaskItemsToFile()
        rebuildTaskList()
    End Sub

    Private Sub tsmEditDeleteImportTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmEditDeleteImportTask.Click
        Dim locDr As DialogResult = MessageBox.Show("Sind Sie sicher, dass Sie diesen Import-Task löschen wollen?", _
                                         "Import-Task löschen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If locDr = Windows.Forms.DialogResult.No Then
            Return
        End If
        Dim locTask As IFacessoImportTaskItem = DirectCast(lvwTaskList.SelectedItems(0).Tag, IFacessoImportTaskItem)
        'Remove funktioniert nicht mit anschließender Serialisierung;
        'daher Tabelle neu aufbauen, damit die TaskIDs lückenlos
        'sind!
        Dim locMyTasks As New FacessoTaskItems()
        Dim locCount As Integer
        For Each locItem As FacessoTaskItemBase In myTasks
            If locItem IsNot locTask Then
                locItem.TaskID = locCount
                locMyTasks.Add(locItem)
                locCount += 1
            End If
        Next
        myTasks = locMyTasks
        SerializeTaskItemsToFile()
        rebuildTaskList()
    End Sub

    Private Sub rebuildTaskList()
        With lvwTaskList
            .BeginUpdate()
            .Items.Clear()
            For Each locTask As IFacessoImportTaskItem In myTasks
                Dim locLvwItem As New ListViewItem("", "CheckBox")
                locLvwItem.Tag = locTask
                locLvwItem.SubItems.Add(locTask.Name)
                locLvwItem.SubItems.Add(locTask.ImportType.ToString)
                .Items.Add(locLvwItem)
            Next
            .Columns(0).Width = 20
            .Columns(1).Width = -2
            .Columns(2).Width = -2
            .EndUpdate()
        End With
    End Sub

    Private ReadOnly Property SelectedShift() As ShiftCombination
        Get
            Dim locSc As ShiftCombination = ShiftCombination.None
            If chkShift1.Checked Then locSc = locSc Or ShiftCombination.Shift1
            If chkShift2.Checked Then locSc = locSc Or ShiftCombination.Shift2
            If chkShift3.Checked Then locSc = locSc Or ShiftCombination.Shift3
            If chkShift4.Checked Then locSc = locSc Or ShiftCombination.Shift4
        End Get
    End Property

    Private Sub btnImportNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportNow.Click
        Dim locSelShift As ShiftCombination = SelectedShift
        Dim mainResultTable As IImportResultTable
        Dim locProdData As ProductionDataTable
        Dim locMaxValue As Integer
        Dim locPbCount As Integer

        locMaxValue = (CInt(dtpTo.Value.Date.ToOADate) - CInt(dtpFrom.Value.Date.ToOADate)) + 1
        locMaxValue *= lvwTaskList.Items.Count
        pbImportProgress.Value = 0
        pbImportProgress.Maximum = locMaxValue
        pbImportProgress.Minimum = 0
        btnOK.Text = "Abbrechen"
        btnImportNow.Enabled = False
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        ResultMessage = "Import gestartet am " & Date.Now.ToLongDateString & " von User: " _
            & FacessoGeneric.LoginInfo.Username & vbNewLine & vbNewLine

        For locDateAsInt As Integer = CInt(dtpFrom.Value.Date.ToOADate) To CInt(dtpTo.Value.Date.ToOADate)
            For Each locTask As IFacessoImportTaskItem In myTasks
                Try
                    locPbCount += 1
                    pbImportProgress.Value = locPbCount
                    lblImportStatus.Text = "Übernahme für " & Date.FromOADate(locDateAsInt).ToShortDateString & ":" & locTask.Name
                    Application.DoEvents()

                    If myCancelImport Then
                        lblImportStatus.Text = "Abbruch durch Benutzer!"
                        Application.DoEvents()
                        myCancelImport = False
                        btnOK.Text = "OK"
                        btnImportNow.Enabled = True
                        Return
                    End If

                    'Resulttable kann entweder auf Zeit- oder Produktionsdaten zeigen
                    mainResultTable = locTask.GetData(Date.FromOADate(locDateAsInt), locSelShift)

                    ' Die Konvertierung der IDs (beispielsweise Programmnummern in Arbeitswerte oder
                    ' Fremd-Personalnummern in Facesso-Personalnummern) vornehmen
                    If locTask.ImportType = FacessoImportType.WorkGroupData Then
                        If mainResultTable.Count > 0 Then
                            For c As Integer = 0 To mainResultTable.Count - 1
                                Dim locValue As Integer = mainResultTable.GetPrimarySourceIdentifier(c)
                                Dim locNewValue As Integer
                                'Aus der Foreign-ID den Home-ID (ID des Arbeitswertes) ermitteln
                                locNewValue = locTask.ConversionItems(New IntKey(locValue)).HomeElementID
                                If locNewValue = -1 Then
                                    locNewValue = -locValue
                                End If
                                mainResultTable.SetPrimaryDestinationIdentifier(c, locNewValue)
                            Next
                        Else
                            'Keine Elemente zu konvertieren vorhanden in diesem Taskitem,
                            'dann weiter im Text
                            Continue For
                        End If
                    Else
                        If 0 = 1 Then
                            'TODO: Konvertierung, falls notwendig, aber Personalnummern werden in der Regel in allen Systemen dieselben sein.
                            'Hier ist aufjeden Fall schonmal der Rumpf, um Personal-IDs des einen in die von Facesso zu konvertieren.
                            Dim timeResultTable = DirectCast(mainResultTable, ITimeLogImportResultTable)
                            For c = 0 To timeResultTable.Count - 1
                                Dim locValue As Integer = timeResultTable.GetSecondarySourceIdentifier(c)
                                timeResultTable.SetSecondaryDestinationIdentifier(c, locValue)
                            Next
                        End If
                        'Und danach ziehen wir die Daten glatt.
                        Dim locTimeData = DirectCast(mainResultTable, TimeDataTable)
                        AlignTimeData(locTimeData, Date.FromOADate(locDateAsInt))

                        Dim myhasDiscrepancies = False

                        'Feststellen, ob Issues vorhanden sind.
                        For Each tmpItem As TimeDataRow In locTimeData
                            If tmpItem.HasDiscrepancies Then
                                myhasDiscrepancies = True
                            End If
                        Next

                        'Die Selektierten Arbeitsgruppen aus der Liste ermitteln
                        Dim selectedWorkgroups As New WorkGroupInfoItems
                        For Each item In ucWorkGroups.CheckedWorkGroups
                            selectedWorkgroups.Add(item)
                        Next

                        'Hier schmeißen wir alle raus, deren Arbeitsgruppen nicht selektiert sind.
                        'Die Zeiten für die Arbeitsgruppen rausschmeißen, die nicht in der UI selektiert sind
                        Dim dataRows = From wgItem In selectedWorkgroups _
                                    Join timeItem In locTimeData.TimeDataRows On wgItem.WorkGroupNumber Equals timeItem.WorkgroupNo _
                                    Select timeItem

                        locTimeData = New TimeDataTable()
                        For Each item In dataRows
                            locTimeData.ImportRow(item)
                        Next

                        'Die bearbeiteten Datensätze (selektiert nach Produktiv-Sites, jetzt neue Tabelle!!!) wieder in die mainResult
                        'Tabelle überführen, weil die immer noch die Referenz auf die unbearbeiteten hält.
                        mainResultTable = locTimeData

                        'Und hier bringen wir für die Ergebnisliste im Bedarfsfall die Überprüfungsansicht
                        If myFacessoGeneralOptions.ShowTimeLogPriorToImport Then
                            Dim issueForm As New frmTimeLogResultTable
                            Dim dr = issueForm.ShowDialog(locTimeData, Date.FromOADate(locDateAsInt))
                            If dr = Windows.Forms.DialogResult.Abort Or dr = Windows.Forms.DialogResult.Cancel Then
                                MessageBox.Show("Import von Zeit- und Mengendaten wurde auf Benutzerwunsch abgebrochen", "Abbruch", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                Windows.Forms.Cursor.Current = Cursors.Arrow
                                btnOK.Text = "OK"
                                btnImportNow.Enabled = True
                                Return
                            End If
                        ElseIf myFacessoGeneralOptions.ShowIssueListPriorToImport Then
                            If myhasDiscrepancies Then
                                Dim tmpTimeData As New TimeDataTable
                                For Each tmpItem As TimeDataRow In locTimeData
                                    If tmpItem.HasDiscrepancies Then
                                        Dim newItem = tmpTimeData.NewTimeDataRow
                                        newItem.ItemArray = tmpItem.ItemArray
                                        tmpTimeData.AddTimeDataRow(newItem)
                                    End If
                                Next
                                Dim issueForm As New frmTimeLogResultTable
                                Dim dr = issueForm.ShowDialog(tmpTimeData, Date.FromOADate(locDateAsInt))
                                If dr = Windows.Forms.DialogResult.Abort Or dr = Windows.Forms.DialogResult.Cancel Then
                                    MessageBox.Show("Import von Zeit- und Mengendaten wurde auf Benutzerwunsch abgebrochen", "Abbruch", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                    Windows.Forms.Cursor.Current = Cursors.Arrow
                                    btnOK.Text = "OK"
                                    btnImportNow.Enabled = True
                                    Return
                                End If
                            End If
                        Else
                            If myhasDiscrepancies Then
                                Dim dr = MessageBox.Show("Facesso hat noch Ungereimtheiten bei den zu importierenden Daten gefunden, und empfiehlt, die Import Vorschau erst zu sichten." & vbNewLine & _
                                                "Möchten Sie sich die Import-Vorschau zunächst anschauen (betroffene Datensätze würde nicht importiert werden)?", "Ungereimtheiten bei Importdaten:", _
                                                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
                                If dr = Windows.Forms.DialogResult.Yes Then
                                    Dim issueForm As New frmTimeLogResultTable
                                    Dim dr2 = issueForm.ShowDialog(locTimeData, Date.FromOADate(locDateAsInt))
                                    If dr2 = Windows.Forms.DialogResult.Abort Or dr2 = Windows.Forms.DialogResult.Cancel Then
                                        MessageBox.Show("Import von Zeit- und Mengendaten wurde auf Benutzerwunsch abgebrochen", "Abbruch", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                        Windows.Forms.Cursor.Current = Cursors.Arrow
                                        btnOK.Text = "OK"
                                        btnImportNow.Enabled = True
                                        Return
                                    End If
                                ElseIf dr = Windows.Forms.DialogResult.Abort Or dr = Windows.Forms.DialogResult.Cancel Then
                                    MessageBox.Show("Import von Zeit- und Mengendaten wurde auf Benutzerwunsch abgebrochen", "Abbruch", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                    Windows.Forms.Cursor.Current = Cursors.Arrow
                                    btnOK.Text = "OK"
                                    btnImportNow.Enabled = True
                                    Return
                                End If
                            End If
                        End If
                    End If

                    'Jetzt müssen wir unterscheiden, was wir auswerten wollen
                    'Da aber sowohl Zeit- als auch Produktionsdaten nur
                    'Schichtweise geschrieben werden, müssen wir schauen, wieviele Schichten
                    'berücksichtigt werden sollen.
                    For locShiftCount As Byte = 1 To 4
                        Dim locShift As Integer = 1 << (locShiftCount - 1)
                        'Nur die Schichten übernehmen, die der Anwender für die Übernahme angewählt hatte
                        If (locShift And CInt(locSelShift)) = CInt(locSelShift) Then
                            If locTask.ImportType = FacessoImportType.WorkGroupData Then
                                'Hier gibt es Produktionsdaten, die nun für jede Schicht einzeln ausgewertet werden.
                                locProdData = DirectCast(mainResultTable, ProductionDataTable)
                                ProcessProductionData(locProdData, _
                                    New CombinedParametersInfo(locTask.ForWorkgroup, _
                                        Date.FromOADate(locDateAsInt), _
                                        locShiftCount))
                            Else
                                Dim locTimeData = DirectCast(mainResultTable, TimeDataTable)
                                ProcessTimeData(locTimeData, Date.FromOADate(locDateAsInt), locShiftCount)
                            End If
                        End If
                    Next locShiftCount
                Catch ex As ApplicationException
                    MessageBox.Show("Bei der Konvertierung ist folgender Fehler aufgetreten." & vbNewLine & _
                    "Die Konvertierung für die weiteren ImportTasks wird fortzusetzen versucht." & vbNewLine & _
                    ex.Message & vbNewLine & ex.StackTrace, "Fehler bei der Übernahme", MessageBoxButtons.OK)
                End Try
            Next locTask
        Next locDateAsInt
        Windows.Forms.Cursor.Current = Cursors.Arrow
        btnOK.Text = "OK"
        btnImportNow.Enabled = True
    End Sub

    Private Sub lvwTaskList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwTaskList.SelectedIndexChanged
        If lvwTaskList.SelectedIndices.Count = 0 Then
            ToggleMenus(False)
        Else
            ToggleMenus(True)
            'Rausfinden, ob ein Zeitübernahme-Task-Item selektiert ist, und dann die Workgroups togglen:
            If DirectCast(lvwTaskList.SelectedItems(0).Tag, IFacessoImportTaskItem).ImportType = FacessoImportType.TimeKeepingData Then
                ToggleWorkgroups(True)
            Else
                ToggleWorkgroups(False)
            End If
        End If
    End Sub

    Private Sub ToggleWorkgroups(ByVal OnOff As Boolean)
        ucWorkGroups.Enabled = OnOff
        lblWorkgroups.Enabled = OnOff
        btnSelectAll.Enabled = OnOff
        btnDeselectAll.Enabled = OnOff
    End Sub

    Private Sub ToggleMenus(ByVal OnOff As Boolean)
        tsmEditDeleteImportTask.Enabled = OnOff
        tsmEditImportTask.Enabled = OnOff
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If btnOK.Text <> "OK" Then
            myCancelImport = True
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Public Property ResultMessage() As String
        Get
            Return myResultMessage
        End Get
        Set(ByVal value As String)
            myResultMessage = value
        End Set
    End Property

    Private Sub dtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged
        If dtpTo.Value < dtpFrom.Value Then
            dtpFrom.Value = dtpTo.Value
        End If
    End Sub

    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged
        If dtpFrom.Value > dtpTo.Value Then
            dtpTo.Value = dtpFrom.Value
        End If
    End Sub

    Private Sub tsmQuitDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmQuitDialog.Click
        Me.Close()
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        ToggleWorkGroupItems(True)
    End Sub

    Private Sub btnDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeselectAll.Click
        ToggleWorkGroupItems(False)
    End Sub

    Private Sub ToggleWorkGroupItems(ByVal OnOff As Boolean)
        For Each item As ListViewItem In ucWorkGroups.Items
            item.Checked = OnOff
        Next
    End Sub
End Class

Public Class InterfaceClassItems
    Inherits System.Collections.ObjectModel.KeyedCollection(Of Long, FacessoInterfaceClassItem)

    Sub New()
        MyBase.new()
    End Sub

    Protected Overrides Function GetKeyForItem(ByVal item As FacessoInterfaceClassItem) As Long
        Return item.InterfaceID
    End Function

    ''' <summary>
    ''' Verschafft sich alle Import-Filter aus dieser Assembly
    ''' </summary>
    ''' <returns>InterfaceItems-Collection mit allen Import-Filtern.</returns>
    ''' <remarks></remarks>
    Public Shared Function ThroughReflection() As InterfaceClassItems
        Dim locCount As Long = 0
        Dim locInterfaces As New InterfaceClassItems

        'Oben anfangen auf Assembly-Ebene
        Dim locCurrAssembly As Assembly = Assembly.GetExecutingAssembly
        'Zwar nur ein Modul drin - aber wir machen es gescheit.
        For Each locModule As [Module] In locCurrAssembly.GetModules()
            'Alle Klassen im Modul aufzählen
            For Each locType As Type In locModule.GetTypes()
                'Alle Attribute der Klasse aufzählen
                For Each locAtt As Attribute In locType.GetCustomAttributes(True)
                    'Wenn eine Klasse als Interface gekennzeichnet ist,
                    'dann diese samt dem relevanten Attribut in die Collection aufnehmen.
                    If locAtt.GetType Is GetType(FacessoImportFilterNameAttribute) Then
                        Dim locInterfaceItem As New FacessoInterfaceClassItem(locType, locCount, DirectCast(locAtt, FacessoImportFilterNameAttribute))
                        locInterfaces.Add(locInterfaceItem)
                        locCount += 1
                        Exit For
                    End If
                Next
            Next
        Next
        If locInterfaces.Count = 0 Then
            Return Nothing
        Else
            Return locInterfaces
        End If
    End Function

    Private Sub loadShiftModel()
        Dim locFi As New FileInfo(FacessoGeneric.SharedFolder & "\ShiftModel\GenericShiftModel.xml")
        If Not locFi.Directory.Exists Then
            locFi.Directory.Create()
        End If
    End Sub
End Class

Public Class FacessoInterfaceClassItem

    Private myInterfaceType As Type
    Private myInterfaceAttribute As FacessoImportFilterNameAttribute
    Private myInterfaceID As Long

    Sub New(ByVal InterfaceType As Type, ByVal InterfaceID As Long, ByVal InterfaceAttribute As FacessoImportFilterNameAttribute)
        myInterfaceType = InterfaceType
        myInterfaceID = InterfaceID
        myInterfaceAttribute = InterfaceAttribute
    End Sub

    Public Property InterfaceType() As Type
        Get
            Return myInterfaceType
        End Get
        Set(ByVal value As Type)
            myInterfaceType = value
        End Set
    End Property

    Public Property InterfaceID() As Long
        Get
            Return myInterfaceID
        End Get
        Set(ByVal value As Long)
            myInterfaceID = value
        End Set
    End Property

    Public ReadOnly Property InterfaceAttribute() As FacessoImportFilterNameAttribute
        Get
            Return myInterfaceAttribute
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return myInterfaceAttribute.ImportFiltername
    End Function
End Class