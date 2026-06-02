<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfigurableWorkgroupChart
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucConfigurableWorkgroupChart))
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title4 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim Title5 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim Title6 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Chart3DToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ShowValuesInChartToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.WorkgroupsDropDownItems = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.mainChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.mainChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.toolStripSeparator, Me.CopyToolStripButton, Me.toolStripSeparator1, Me.EditToolStripButton, Me.ToolStripSeparator2, Me.Chart3DToolStripButton, Me.ShowValuesInChartToolStripButton, Me.WorkgroupsDropDownItems})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(576, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NewToolStripButton.Text = "Neues Diagramm"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "Speichern"
        Me.SaveToolStripButton.Visible = False
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "Drucken"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"), System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CopyToolStripButton.Text = "Kopieren"
        Me.CopyToolStripButton.Visible = False
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'EditToolStripButton
        '
        Me.EditToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EditToolStripButton.Image = CType(resources.GetObject("EditToolStripButton.Image"), System.Drawing.Image)
        Me.EditToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditToolStripButton.Name = "EditToolStripButton"
        Me.EditToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.EditToolStripButton.Text = "Chart-Einstellungen editieren"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Chart3DToolStripButton
        '
        Me.Chart3DToolStripButton.CheckOnClick = True
        Me.Chart3DToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Chart3DToolStripButton.Image = CType(resources.GetObject("Chart3DToolStripButton.Image"), System.Drawing.Image)
        Me.Chart3DToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Chart3DToolStripButton.Name = "Chart3DToolStripButton"
        Me.Chart3DToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.Chart3DToolStripButton.Text = "Chart3DToolStripButton"
        Me.Chart3DToolStripButton.ToolTipText = "3D Chart"
        Me.Chart3DToolStripButton.Visible = False
        '
        'ShowValuesInChartToolStripButton
        '
        Me.ShowValuesInChartToolStripButton.CheckOnClick = True
        Me.ShowValuesInChartToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ShowValuesInChartToolStripButton.Image = CType(resources.GetObject("ShowValuesInChartToolStripButton.Image"), System.Drawing.Image)
        Me.ShowValuesInChartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ShowValuesInChartToolStripButton.Name = "ShowValuesInChartToolStripButton"
        Me.ShowValuesInChartToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ShowValuesInChartToolStripButton.Text = "ToolStripButton1"
        Me.ShowValuesInChartToolStripButton.ToolTipText = "Werte im Chart einblenden"
        '
        'WorkgroupsDropDownItems
        '
        Me.WorkgroupsDropDownItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.WorkgroupsDropDownItems.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TestToolStripMenuItem})
        Me.WorkgroupsDropDownItems.Image = CType(resources.GetObject("WorkgroupsDropDownItems.Image"), System.Drawing.Image)
        Me.WorkgroupsDropDownItems.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.WorkgroupsDropDownItems.Name = "WorkgroupsDropDownItems"
        Me.WorkgroupsDropDownItems.Size = New System.Drawing.Size(100, 22)
        Me.WorkgroupsDropDownItems.Text = "Produktiv-Sites"
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.TestToolStripMenuItem.Text = "Test"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.mainChart)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(576, 355)
        Me.Panel1.TabIndex = 2
        '
        'mainChart
        '
        ChartArea2.Area3DStyle.WallWidth = 5
        ChartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[True]
        ChartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea2.AxisX.IsLabelAutoFit = False
        ChartArea2.AxisX.IsStartedFromZero = False
        ChartArea2.AxisX.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisX.LabelStyle.Format = "ddd, dd."
        ChartArea2.AxisX.LabelStyle.Interval = 0.0R
        ChartArea2.AxisX.LabelStyle.IntervalOffset = 0.0R
        ChartArea2.AxisX.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days
        ChartArea2.AxisX.LabelStyle.IsStaggered = True
        ChartArea2.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea2.AxisY.Title = "Zeitgrad"
        ChartArea2.AxisY.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.CursorX.IsUserEnabled = True
        ChartArea2.CursorX.IsUserSelectionEnabled = True
        ChartArea2.Name = "mainChartArea"
        Me.mainChart.ChartAreas.Add(ChartArea2)
        Me.mainChart.Dock = System.Windows.Forms.DockStyle.Fill
        Legend2.Name = "mainLegend"
        Legend2.TextWrapThreshold = 50
        Legend2.Title = "Übersicht Produktiv-Sites"
        Legend2.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainChart.Legends.Add(Legend2)
        Me.mainChart.Location = New System.Drawing.Point(0, 0)
        Me.mainChart.Name = "mainChart"
        Series2.ChartArea = "mainChartArea"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series2.Legend = "mainLegend"
        Series2.Name = "Series1"
        Me.mainChart.Series.Add(Series2)
        Me.mainChart.Size = New System.Drawing.Size(576, 355)
        Me.mainChart.TabIndex = 1
        Me.mainChart.Text = "Facesso-Chart"
        Me.mainChart.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault
        Title4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title4.Name = "MainTitle"
        Title4.Text = "MainTitle"
        Title5.Name = "SubTitle"
        Title5.Text = "von #Datum# - #Datum#"
        Title6.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Title6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title6.Name = "Footer"
        Title6.Text = "FACESSO 2011.NET --- Copyright (c) 2010/2011 by ActiveDevelop/Klaus Löffelmann"
        Me.mainChart.Titles.Add(Title4)
        Me.mainChart.Titles.Add(Title5)
        Me.mainChart.Titles.Add(Title6)
        '
        'ucConfigurableWorkgroupChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "ucConfigurableWorkgroupChart"
        Me.Size = New System.Drawing.Size(576, 380)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.mainChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopyToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents mainChart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Chart3DToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ShowValuesInChartToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents WorkgroupsDropDownItems As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents TestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
