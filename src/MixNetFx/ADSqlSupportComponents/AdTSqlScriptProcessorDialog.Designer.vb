<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADTsqlScriptProcessorDialog
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvScriptChunks = New System.Windows.Forms.DataGridView
        Me.pbScriptExecution = New System.Windows.Forms.ProgressBar
        Me.btnSendScript = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        CType(Me.dgvScriptChunks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvScriptChunks
        '
        Me.dgvScriptChunks.AllowUserToAddRows = False
        Me.dgvScriptChunks.AllowUserToDeleteRows = False
        Me.dgvScriptChunks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvScriptChunks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvScriptChunks.Location = New System.Drawing.Point(12, 12)
        Me.dgvScriptChunks.Name = "dgvScriptChunks"
        Me.dgvScriptChunks.ReadOnly = True
        Me.dgvScriptChunks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvScriptChunks.Size = New System.Drawing.Size(548, 281)
        Me.dgvScriptChunks.TabIndex = 0
        '
        'pbScriptExecution
        '
        Me.pbScriptExecution.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbScriptExecution.Location = New System.Drawing.Point(12, 299)
        Me.pbScriptExecution.Name = "pbScriptExecution"
        Me.pbScriptExecution.Size = New System.Drawing.Size(548, 22)
        Me.pbScriptExecution.TabIndex = 1
        '
        'btnSendScript
        '
        Me.btnSendScript.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSendScript.Location = New System.Drawing.Point(12, 340)
        Me.btnSendScript.Name = "btnSendScript"
        Me.btnSendScript.Size = New System.Drawing.Size(162, 30)
        Me.btnSendScript.TabIndex = 2
        Me.btnSendScript.Text = "Skript senden"
        Me.btnSendScript.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(460, 340)
        Me.btnOK.Name = "btnCancel"
        Me.btnOK.Size = New System.Drawing.Size(100, 30)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'ADTsqlScriptProcessorDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 386)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnSendScript)
        Me.Controls.Add(Me.pbScriptExecution)
        Me.Controls.Add(Me.dgvScriptChunks)
        Me.Name = "ADTsqlScriptProcessorDialog"
        Me.Text = "T-SQL-Skript ausführen:"
        CType(Me.dgvScriptChunks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvScriptChunks As System.Windows.Forms.DataGridView
    Friend WithEvents pbScriptExecution As System.Windows.Forms.ProgressBar
    Friend WithEvents btnSendScript As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
