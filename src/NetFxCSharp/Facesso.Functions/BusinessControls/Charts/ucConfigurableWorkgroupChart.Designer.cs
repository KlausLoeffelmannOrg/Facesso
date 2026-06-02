using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public partial class ucConfigurableWorkgroupChart : System.Windows.Forms.UserControl
    {
        //UserControl overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucConfigurableWorkgroupChart));
            System.Windows.Forms.DataVisualization.Charting.ChartArea ChartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend Legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series Series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title Title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title Title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title Title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.NewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.NewToolStripButton.Click += NewToolStripButton_Click;
            this.SaveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveToolStripButton.Click += SaveToolStripButton_Click;
            this.PrintToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.PrintToolStripButton.Click += PrintToolStripButton_Click;
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.CopyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.CopyToolStripButton.Click += CopyToolStripButton_Click;
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.EditToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EditToolStripButton.Click += EditToolStripButton_Click;
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Chart3DToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.Chart3DToolStripButton.Click += Chart3DToolStripButton_Click;
            this.ShowValuesInChartToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ShowValuesInChartToolStripButton.Click += ShowValuesInChartToolStripButton_Click;
            this.WorkgroupsDropDownItems = new System.Windows.Forms.ToolStripDropDownButton();
            this.TestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ToolStrip1.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.mainChart).BeginInit();
            this.SuspendLayout();
            //
            //ToolStrip1
            //
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.NewToolStripButton, this.SaveToolStripButton, this.PrintToolStripButton, this.toolStripSeparator, this.CopyToolStripButton, this.toolStripSeparator1, this.EditToolStripButton, this.ToolStripSeparator2, this.Chart3DToolStripButton, this.ShowValuesInChartToolStripButton, this.WorkgroupsDropDownItems });
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(576, 25);
            this.ToolStrip1.TabIndex = 1;
            this.ToolStrip1.Text = "ToolStrip1";
            //
            //NewToolStripButton
            //
            this.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewToolStripButton.Image = ((System.Drawing.Image)resources.GetObject("NewToolStripButton.Image"));
            this.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewToolStripButton.Name = "NewToolStripButton";
            this.NewToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.NewToolStripButton.Text = "Neues Diagramm";
            //
            //SaveToolStripButton
            //
            this.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveToolStripButton.Image = ((System.Drawing.Image)resources.GetObject("SaveToolStripButton.Image"));
            this.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripButton.Name = "SaveToolStripButton";
            this.SaveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.SaveToolStripButton.Text = "Speichern";
            this.SaveToolStripButton.Visible = false;
            //
            //PrintToolStripButton
            //
            this.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PrintToolStripButton.Image = ((System.Drawing.Image)resources.GetObject("PrintToolStripButton.Image"));
            this.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrintToolStripButton.Name = "PrintToolStripButton";
            this.PrintToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.PrintToolStripButton.Text = "Drucken";
            //
            //toolStripSeparator
            //
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            //
            //CopyToolStripButton
            //
            this.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CopyToolStripButton.Image = ((System.Drawing.Image)resources.GetObject("CopyToolStripButton.Image"));
            this.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyToolStripButton.Name = "CopyToolStripButton";
            this.CopyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.CopyToolStripButton.Text = "Kopieren";
            this.CopyToolStripButton.Visible = false;
            //
            //toolStripSeparator1
            //
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            //
            //EditToolStripButton
            //
            this.EditToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditToolStripButton.Image = ((System.Drawing.Image)resources.GetObject("EditToolStripButton.Image"));
            this.EditToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditToolStripButton.Name = "EditToolStripButton";
            this.EditToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.EditToolStripButton.Text = "Chart-Einstellungen editieren";
            //
            //ToolStripSeparator2
            //
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            //
            //Chart3DToolStripButton
            //
            this.Chart3DToolStripButton.CheckOnClick = true;
            this.Chart3DToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Chart3DToolStripButton.Image = ((System.Drawing.Image)resources.GetObject("Chart3DToolStripButton.Image"));
            this.Chart3DToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Chart3DToolStripButton.Name = "Chart3DToolStripButton";
            this.Chart3DToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.Chart3DToolStripButton.Text = "Chart3DToolStripButton";
            this.Chart3DToolStripButton.ToolTipText = "3D Chart";
            this.Chart3DToolStripButton.Visible = false;
            //
            //ShowValuesInChartToolStripButton
            //
            this.ShowValuesInChartToolStripButton.CheckOnClick = true;
            this.ShowValuesInChartToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ShowValuesInChartToolStripButton.Image = ((System.Drawing.Image)resources.GetObject("ShowValuesInChartToolStripButton.Image"));
            this.ShowValuesInChartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShowValuesInChartToolStripButton.Name = "ShowValuesInChartToolStripButton";
            this.ShowValuesInChartToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ShowValuesInChartToolStripButton.Text = "ToolStripButton1";
            this.ShowValuesInChartToolStripButton.ToolTipText = "Werte im Chart einblenden";
            //
            //WorkgroupsDropDownItems
            //
            this.WorkgroupsDropDownItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.WorkgroupsDropDownItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.TestToolStripMenuItem });
            this.WorkgroupsDropDownItems.Image = ((System.Drawing.Image)resources.GetObject("WorkgroupsDropDownItems.Image"));
            this.WorkgroupsDropDownItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WorkgroupsDropDownItems.Name = "WorkgroupsDropDownItems";
            this.WorkgroupsDropDownItems.Size = new System.Drawing.Size(100, 22);
            this.WorkgroupsDropDownItems.Text = "Produktiv-Sites";
            //
            //TestToolStripMenuItem
            //
            this.TestToolStripMenuItem.Name = "TestToolStripMenuItem";
            this.TestToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.TestToolStripMenuItem.Text = "Test";
            //
            //Panel1
            //
            this.Panel1.Controls.Add(this.mainChart);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 25);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(576, 355);
            this.Panel1.TabIndex = 2;
            //
            //mainChart
            //
            ChartArea2.Area3DStyle.WallWidth = 5;
            ChartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            ChartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            ChartArea2.AxisX.IsLabelAutoFit = false;
            ChartArea2.AxisX.IsStartedFromZero = false;
            ChartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            ChartArea2.AxisX.LabelStyle.Format = "ddd, dd.";
            ChartArea2.AxisX.LabelStyle.Interval = 0.0;
            ChartArea2.AxisX.LabelStyle.IntervalOffset = 0.0;
            ChartArea2.AxisX.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            ChartArea2.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            ChartArea2.AxisX.LabelStyle.IsStaggered = true;
            ChartArea2.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            ChartArea2.AxisY.Title = "Zeitgrad";
            ChartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            ChartArea2.CursorX.IsUserEnabled = true;
            ChartArea2.CursorX.IsUserSelectionEnabled = true;
            ChartArea2.Name = "mainChartArea";
            this.mainChart.ChartAreas.Add(ChartArea2);
            this.mainChart.Dock = System.Windows.Forms.DockStyle.Fill;
            Legend2.Name = "mainLegend";
            Legend2.TextWrapThreshold = 50;
            Legend2.Title = "Übersicht Produktiv-Sites";
            Legend2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.mainChart.Legends.Add(Legend2);
            this.mainChart.Location = new System.Drawing.Point(0, 0);
            this.mainChart.Name = "mainChart";
            Series2.ChartArea = "mainChartArea";
            Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            Series2.Legend = "mainLegend";
            Series2.Name = "Series1";
            this.mainChart.Series.Add(Series2);
            this.mainChart.Size = new System.Drawing.Size(576, 355);
            this.mainChart.TabIndex = 1;
            this.mainChart.Text = "Facesso-Chart";
            this.mainChart.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            Title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            Title4.Name = "MainTitle";
            Title4.Text = "MainTitle";
            Title5.Name = "SubTitle";
            Title5.Text = "von #Datum# - #Datum#";
            Title6.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            Title6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            Title6.Name = "Footer";
            Title6.Text = "FACESSO 2011.NET --- Copyright (c) 2010/2011 by ActiveDevelop/Klaus Löffelmann";
            this.mainChart.Titles.Add(Title4);
            this.mainChart.Titles.Add(Title5);
            this.mainChart.Titles.Add(Title6);
            //
            //ucConfigurableWorkgroupChart
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "ucConfigurableWorkgroupChart";
            this.Size = new System.Drawing.Size(576, 380);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.mainChart).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton NewToolStripButton;

        internal System.Windows.Forms.ToolStripButton SaveToolStripButton;

        internal System.Windows.Forms.ToolStripButton PrintToolStripButton;

        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        internal System.Windows.Forms.ToolStripButton CopyToolStripButton;

        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton EditToolStripButton;

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton Chart3DToolStripButton;

        internal System.Windows.Forms.ToolStripButton ShowValuesInChartToolStripButton;

        internal System.Windows.Forms.ToolStripDropDownButton WorkgroupsDropDownItems;
        internal System.Windows.Forms.ToolStripMenuItem TestToolStripMenuItem;
    }
}