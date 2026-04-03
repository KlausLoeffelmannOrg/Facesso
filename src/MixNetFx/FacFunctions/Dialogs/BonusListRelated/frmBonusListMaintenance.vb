Imports System.Windows.Forms
Imports System.Drawing
Imports Facesso.Data

Public Class frmBonuslistMaintenance

    Private myBaseCostcenter As CostcenterInfo
    Private myIsBeingBuild As Boolean

    Friend Sub HandleDialog()
        Using Me
            myBaseCostcenter = SPAccess.GetInstance.GetCurrentBaseCostCenter(FacessoGeneric.LoginInfo.IDSubsidiary)
            Me.ShowDialog()
        End Using
    End Sub

    Private Sub frmBonuslistMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RebuildCostcenterList()
    End Sub

    Private Sub lstCostCenter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCostCenter.SelectedIndexChanged
        RebuildTable(DirectCast(lstCostCenter.SelectedItem, CostcenterInfo))
    End Sub

    Private Sub RebuildTable(ByVal cci As CostcenterInfo)
        Dim locBlis As BonusListItems = SPAccess.GetInstance.BonusList_GetBonusListItems(cci.IDSubsidiary, _
                                                                                       cci.IDCostCenter)
        myIsBeingBuild = True
        dgvWageTable.AutoGenerateColumns = True
        dgvWageTable.SuspendLayout()
        dgvWageTable.DataSource = locBlis
        With dgvWageTable.Columns
            .Remove(.Item("IDBonusLists"))
            .Remove(.Item("IDBonusList"))
            .Remove(.Item("IDSubsidiary"))
            .Remove(.Item("DegreeOfTime"))
            .Remove(.Item("DegreeOfTimeAligned"))
            .Remove(.Item("CostCenterInfo"))
            With .Item("DegreeOfTimeAlignedText")
                .DisplayIndex = 0
                .DefaultCellStyle.Format = cci.IncentiveFormatString
                .HeaderText = cci.IncentiveIndicatorSynonym
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
            End With

            With .Item("Percentage")
                .DisplayIndex = 1
                .DefaultCellStyle.Format = "#,##0.##"
                .HeaderText = cci.IncentiveWageSynonym & " (% Aufschlag)"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = False
            End With
            With .Item("AbsoluteValue")
                .DisplayIndex = 2
                .DefaultCellStyle.Format = "#,##0.00"
                .HeaderText = cci.IncentiveWageSynonym & " (" & cci.CurrencyToken & " Fixbetrag)"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = False
            End With
        End With
        dgvWageTable.ResumeLayout()
        myIsBeingBuild = False
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub NewCostcenterTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewCostcenterTable.Click
        Dim locCsel As New frmCostCenterSelector
        'TODO: Position correctly!
        'locCsel.Location = New Point(NewCostcenterTable.Location.X, NewCostcenterTable.Location.Y + _
        '                             NewCostcenterTable.Size.Height)
        'locCsel.Size = New Size(NewCostcenterTable.Size.Width, locCsel.Size.Height)
        Dim locCcic As CostcenterInfoItems = _
           SPAccess.GetInstance.BonusList_GetCostCenterInfoCollection( _
                FacessoGeneric.LoginInfo.IDSubsidiary, True)
        Dim locCci As CostcenterInfo = locCsel.HandleDialog(locCcic)
        If locCci Is Nothing Then Exit Sub

        SPAccess.GetInstance.BonusList_FromBaseCostCenter(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                                          SPAccess.GetInstance.GetCurrentBaseCostCenter(FacessoGeneric.LoginInfo.IDSubsidiary).IDCostCenter, _
                                                          locCci.IDCostCenter, _
                                                          FacessoGeneric.LoginInfo.IDUser)
        RebuildCostcenterList()
    End Sub

    Private Sub RebuildCostcenterList()
        'Kostenstellenliste füllen
        Dim locCCs As CostcenterInfoItems = _
            SPAccess.GetInstance.BonusList_GetCostCenterInfoCollection(FacessoGeneric.LoginInfo.IDSubsidiary, False)
        If locCCs Is Nothing OrElse locCCs.Count = 0 Then
            Me.Visible = True
            Application.DoEvents()
            Dim dr As DialogResult = MessageBox.Show("Die Lohnliste der Systemkostenstelle wurde gelöscht." & vbNewLine & _
                            "Soll eine Standardtabelle wiederhergestellt werden, die Sie anschließend nachbearbeiten können?", _
                             "Lohnliste nicht vorhanden!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If dr = Windows.Forms.DialogResult.Yes Then
                SPAccess.GetInstance.BonusList_CreateBaseList(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                                          SPAccess.GetInstance.GetCurrentBaseCostCenter(FacessoGeneric.LoginInfo.IDSubsidiary).IDCostCenter, _
                                                         FacessoGeneric.LoginInfo.IDUser)
            End If
            locCCs = SPAccess.GetInstance.BonusList_GetCostCenterInfoCollection(FacessoGeneric.LoginInfo.IDSubsidiary, False)
        End If

        lstCostCenter.DataSource = locCCs
        lstCostCenter.DisplayMember = "ListItemText"
    End Sub

    Private Sub btnDeleteCostCenterTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteCostCenterTable.Click
        If lstCostCenter.SelectedIndex = -1 Then
            MessageBox.Show(My.Resources.CostCenterInfoCenter_NoSelectedCostCenter_MB_Body, _
                My.Resources.CostCenterInfoCenter_NoSelectedCostCenter_MB_Title, _
                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Dim locCci As CostcenterInfo = DirectCast(lstCostCenter.SelectedItem, CostcenterInfo)
        SPAccess.GetInstance.BonusList_DeleteList(FacessoGeneric.LoginInfo.IDSubsidiary, _
                                                  locCci.IDCostCenter, _
                                                  FacessoGeneric.LoginInfo.IDUser)
        RebuildCostcenterList()
    End Sub

    Private Sub dgvWageTable_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvWageTable.DataError
        e.ThrowException = False
        MessageBox.Show(My.Resources.BonusListMaintenance_InputValueFormatError_MB_Body, _
                        My.Resources.BonusListMaintenance_InputValueFormatError_MB_Title, _
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub dgvWageTable_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWageTable.CellValueChanged
        If myIsBeingBuild Then Exit Sub
        'Neue Zeile direkt abspeichern
        Dim locCurrentRow As Integer = e.RowIndex
        SPAccess.GetInstance.BonusList_ReplaceEntry( _
            DirectCast(dgvWageTable.Rows.Item(locCurrentRow).DataBoundItem, BonusListItem), _
            FacessoGeneric.LoginInfo.IDUser)
    End Sub
End Class