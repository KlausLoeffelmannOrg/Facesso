Imports ActiveDev
Imports Activedev.Controls
Imports Facesso
Imports system.Windows.Forms
Imports System.ComponentModel
Imports System.Reflection

Public Class frmInfoItemAddEditViewBase

    Private myInfoItem As IInfoItem
    Private myEditMode As InfoItemFormEditMode

    Public Overridable Function Fac_HandleDialogAsAdd(ByVal FormCaption As String, ByVal InfoItemType As Type) As InfoItemMaintenanceDialogResult
        Using Me
            Me.Text = FormCaption
            btnOK.Text = My.Resources.InfoItemBase_AddCommandButtonText
            myInfoItem = CreateInstance(InfoItemType)
            Fac_EditMode = InfoItemFormEditMode.AddNew
            Fac_OnInitializeFormControls()
            Me.ShowDialog()
            If Me.DialogResult = Windows.Forms.DialogResult.OK Then
                Fac_OnAssigningToInfoItem(myInfoItem)
            End If
            Return New InfoItemMaintenanceDialogResult(myInfoItem, Me.DialogResult)
        End Using
    End Function

    Public Overridable Function Fac_HandleDialogAsEdit(ByVal FormCaption As String, ByVal InfoItem As IInfoItem) As InfoItemMaintenanceDialogResult
        Using Me
            Me.Text = FormCaption
            btnOK.Text = My.Resources.InfoItemBase_EditCommandButtonText
            myInfoItem = InfoItem
            Fac_EditMode = InfoItemFormEditMode.Edit
            Fac_OnAssigningToControls(myInfoItem)
            Me.ShowDialog()
            If Me.DialogResult = Windows.Forms.DialogResult.OK Then
                Fac_OnAssigningToInfoItem(myInfoItem)
            End If
            Return New InfoItemMaintenanceDialogResult(myInfoItem, Me.DialogResult)
        End Using
    End Function

    Public Overridable Function Fac_HandleDialogAsView(ByVal FormCaption As String, ByVal InfoItem As IInfoItem) As InfoItemMaintenanceDialogResult
        Using Me
            Me.Text = FormCaption
            btnOK.Text = My.Resources.InfoItemBase_ViewCommandButtonText
            myInfoItem = InfoItem
            Fac_EditMode = InfoItemFormEditMode.View
            Fac_OnAssigningToControls(myInfoItem)
            Me.ShowDialog()
            Return New InfoItemMaintenanceDialogResult(myInfoItem, Me.DialogResult)
        End Using
    End Function

    ''' <summary>
    ''' Legt den Editiermodus fest, den das Formular 
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public Property Fac_EditMode() As InfoItemFormEditMode
        Get
            Return myEditMode
        End Get
        Set(ByVal value As InfoItemFormEditMode)
            myEditMode = value
            If myEditMode = InfoItemFormEditMode.AddNew Then
                Me.btnCancel.Visible = True
            ElseIf myEditMode = InfoItemFormEditMode.Edit Then
                Me.btnCancel.Visible = True
            Else
                Me.btnCancel.Visible = False
            End If
        End Set
    End Property

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim locCancelEventArgs As CancelEventArgs = Nothing
        If Fac_EditMode = InfoItemFormEditMode.AddNew Then
            locCancelEventArgs = New CancelEventArgs()
            Fac_OnValidatingNew(locCancelEventArgs)
        ElseIf Fac_EditMode = InfoItemFormEditMode.Edit Then
            locCancelEventArgs = New InfoItemValidatingEventArgs(myInfoItem, False)
            Fac_OnValidatingEdit(CType(locCancelEventArgs, InfoItemValidatingEventArgs))
        End If
        If Not locCancelEventArgs.Cancel Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    ''' <summary>
    ''' Liest alle IADNullableControl aus der Control-Collection des Formulars,
    ''' und versucht deren Value-Property dynamisch anhand der IndependentDatafield-Eigenschaft
    ''' der IInfoItems zuzuweisen.
    ''' </summary>
    ''' <param name="InfoItem">IInfoItem einbindende Klasseninstanz, der die Werte des Formulars zugewiesen werden.</param>
    ''' <remarks> Um zu ergänzen, muss in der überschriebenen Methode
    ''' ZUERST MyBase.OnAssigningToInfoItem aufgerufen werden!</remarks>
    Protected Overridable Sub Fac_OnAssigningToInfoItem(ByVal InfoItem As IInfoItem)
        InfoItem.AssignFieldsFromNullableControls(ADNullableValueControls.FromContainerControl(Me))
    End Sub

    ''' <summary>
    ''' Liest alle IADNullableControl aus der Control-Collection des Formulars,
    ''' und versucht an deren Value-Property dynamisch anhand der IndependentDatafield-Eigenschaft
    ''' die Werte der entsprechenden IInfoItems-Eigenschaften zuzuweisen.
    ''' </summary>
    ''' <param name="InfoItem">IInfoItem einbindende Klasseninstanz, die die Werte für die Formularbelegung enthält.</param>
    ''' <remarks></remarks>
    Protected Overridable Sub Fac_OnAssigningToControls(ByVal InfoItem As IInfoItem)
        InfoItem.AssignFieldsToNullableControls(ADNullableValueControls.FromContainerControl(Me))
    End Sub

    ''' <summary>
    ''' Gibt dem ableitenden Formular die Möglichkeit, die Eingaben auf Plausibilität für
    ''' das Hinzufügen eines Datensatzes zu prüfen.
    ''' </summary>
    ''' <param name="e">CancelEventArgs, dessen Cancel-Eigenschaft beim Setzen das Validieren fehlschlagen lässt.</param>
    ''' <remarks></remarks>
    Protected Overridable Sub Fac_OnValidatingNew(ByVal e As CancelEventArgs)
        Dim locControls As ADNullableValueControls = ADNullableValueControls.FromContainerControl(Me)
        Dim locBackString As String = locControls.CheckForNotAllowedNullValues()
        If locBackString IsNot Nothing Then
            locBackString = My.Resources.InfoItemBase_NullsInFields_MB_BodyPrefix & _
                            vbNewLine & vbNewLine & locBackString
            MessageBox.Show(locBackString, My.Resources.InfoItemBase_NullsInFields_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
        End If
    End Sub

    ''' <summary>
    ''' Gibt dem ableitenden Formular die Möglichkeit, die Eingaben auf Plausibilität für
    ''' das Editieren eines Datensatzes zu prüfen.
    ''' </summary>
    ''' <param name="e">CancelEventArgs, dessen Cancel-Eigenschaft beim Setzen das Validieren fehlschlagen lässt.</param>
    ''' <remarks></remarks>
    Protected Overridable Sub Fac_OnValidatingEdit(ByVal e As InfoItemValidatingEventArgs)
        Dim locControls As ADNullableValueControls = ADNullableValueControls.FromContainerControl(Me)
        Dim locBackString As String = locControls.CheckForNotAllowedNullValues()
        If locBackString IsNot Nothing Then
            locBackString = My.Resources.InfoItemBase_NullsInFields_MB_BodyPrefix & _
                            vbNewLine & vbNewLine & locBackString
            MessageBox.Show(locBackString, My.Resources.InfoItemBase_NullsInFields_MB_Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
        End If
    End Sub

    ''' <summary>
    ''' Gibt dem ableitenden Form die Möglichkeit, die Steuerelemente mit Default-Werten zu belegen.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub Fac_OnInitializeFormControls()
    End Sub

    ''' <summary>
    ''' Ermittelt die vom Formular verarbeitete Datenklasse (die auf InfoItem basiert).
    ''' </summary>
    ''' <value>InfoItem basierte Datenklasse, die durch das IInfoItem-Interface referenziert wird.</value>
    ''' <remarks></remarks>
    Protected Property Fac_InfoItem() As IInfoItem
        Get
            Return myInfoItem
        End Get
        Set(ByVal value As IInfoItem)
            myInfoItem = value
        End Set
    End Property

    Private Function CreateInstance(ByVal InfoType As Type) As IInfoItem
        Dim locCI As ConstructorInfo = InfoType.GetConstructor(System.Type.EmptyTypes)
        Return CType(locCI.Invoke(Nothing), IInfoItem)
    End Function
End Class

Public Class InfoItemValidatingEventArgs
    Inherits CancelEventArgs

    Private myInfoItem As IInfoItem

    Sub New(ByVal InfoItem As IInfoItem, ByVal Cancel As Boolean)
        MyBase.New(Cancel)
        myInfoItem = InfoItem
    End Sub

    Public Property InfoItem() As IInfoItem
        Get
            Return myInfoItem
        End Get
        Set(ByVal value As IInfoItem)
            myInfoItem = value
        End Set
    End Property
End Class