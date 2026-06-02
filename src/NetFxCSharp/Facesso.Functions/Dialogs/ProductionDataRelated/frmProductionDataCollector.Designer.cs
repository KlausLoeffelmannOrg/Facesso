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
    public partial class frmProductionDataCollector : frmBaseFacesso
    {
        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductionDataCollector));
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmProductionData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSaveChanges = new System.Windows.Forms.ToolStripMenuItem();
            this.AlleEingabenzurücksetzenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.DialogbeendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MitarbeiterdatenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEmployeeTime = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmDeleteTimeEntries = new System.Windows.Forms.ToolStripMenuItem();
            this.NavigationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNextWorkgroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPrevWorkgroup = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmNextWorkDay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMyTodoList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPrevWorkday = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmShift1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShift2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShift3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShift4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowEmployees = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmOnlyShowActiveLabourValues = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslSaveImage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslSaveState = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslCurrentDateInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitProductionData_Employees = new System.Windows.Forms.SplitContainer();
            this.gbProductionData = new System.Windows.Forms.GroupBox();
            this.dgvProductionData = new Facesso.GenericControls.ucProductionDataGridView();
            this.gbEmployees = new System.Windows.Forms.GroupBox();
            this.dgvTimeLogItems = new Facesso.GenericControls.ucTimeLogItemsDataGridView();
            this.layoutAreaLowerLevel = new System.Windows.Forms.TableLayoutPanel();
            this.lblDegreeOfTime = new System.Windows.Forms.Label();
            this.lblMinutesEffective = new System.Windows.Forms.Label();
            this.lblMinutesEffectiveAdj = new System.Windows.Forms.Label();
            this.upperPanel = new System.Windows.Forms.Panel();
            this.layoutPanelUpperArea = new System.Windows.Forms.TableLayoutPanel();
            this.lblMinutesReference = new System.Windows.Forms.Label();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpProductionDate = new System.Windows.Forms.DateTimePicker();
            this.lblShift = new System.Windows.Forms.Label();
            this.lblWorkgroup = new System.Windows.Forms.Label();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNewEmployeeTimes = new System.Windows.Forms.ToolStripButton();
            this.tsmDeleteShiftData = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbDeleteTimeDataOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteProductionDataOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tssbPrint = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmOnlyPrintEmployees = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOnlyPrintProductionData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbSaveChanges = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNullData = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPreviousWorkday = new System.Windows.Forms.ToolStripButton();
            this.tsbMyTodoList = new System.Windows.Forms.ToolStripButton();
            this.tsbNextWorkDay = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPreviousWorkgroup = new System.Windows.Forms.ToolStripButton();
            this.tsbNextWorkgroup = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbShift1 = new System.Windows.Forms.ToolStripButton();
            this.tsbShift2 = new System.Windows.Forms.ToolStripButton();
            this.tsbShift3 = new System.Windows.Forms.ToolStripButton();
            this.tsbShift4 = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tslSites = new System.Windows.Forms.ToolStripLabel();
            this.tscWorkGroup = new System.Windows.Forms.ToolStripComboBox();
            this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBack = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.MenuStrip1.SuspendLayout();
            this.ToolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.ToolStripContainer1.ContentPanel.SuspendLayout();
            this.ToolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer1.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.splitProductionData_Employees).BeginInit();
            this.splitProductionData_Employees.Panel1.SuspendLayout();
            this.splitProductionData_Employees.Panel2.SuspendLayout();
            this.splitProductionData_Employees.SuspendLayout();
            this.gbProductionData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvProductionData).BeginInit();
            this.gbEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvTimeLogItems).BeginInit();
            this.layoutAreaLowerLevel.SuspendLayout();
            this.upperPanel.SuspendLayout();
            this.layoutPanelUpperArea.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            //MenuStrip1
            //
            this.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuStrip1.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmProductionData, this.MitarbeiterdatenToolStripMenuItem, this.NavigationToolStripMenuItem, this.tsmView });
            this.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(772, 22);
            this.MenuStrip1.TabIndex = 0;
            this.MenuStrip1.Text = "MenuStrip1";
            //
            //tsmProductionData
            //
            this.tsmProductionData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmSaveChanges, this.AlleEingabenzurücksetzenToolStripMenuItem, this.ToolStripSeparator1, this.DialogbeendenToolStripMenuItem });
            this.tsmProductionData.Name = "tsmProductionData";
            this.tsmProductionData.Size = new System.Drawing.Size(115, 18);
            this.tsmProductionData.Text = "&Produktionsdaten";
            //
            //tsmSaveChanges
            //
            this.tsmSaveChanges.Image = ((System.Drawing.Image)resources.GetObject("tsmSaveChanges.Image"));
            this.tsmSaveChanges.Name = "tsmSaveChanges";
            this.tsmSaveChanges.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.tsmSaveChanges.Size = new System.Drawing.Size(243, 22);
            this.tsmSaveChanges.Text = "Änderungen speichern";
            //
            //AlleEingabenzurücksetzenToolStripMenuItem
            //
            this.AlleEingabenzurücksetzenToolStripMenuItem.Image = ((System.Drawing.Image)resources.GetObject("AlleEingabenzurücksetzenToolStripMenuItem.Image"));
            this.AlleEingabenzurücksetzenToolStripMenuItem.Name = "AlleEingabenzurücksetzenToolStripMenuItem";
            this.AlleEingabenzurücksetzenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.AlleEingabenzurücksetzenToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.AlleEingabenzurücksetzenToolStripMenuItem.Text = "Alle Eingaben nullen";
            //
            //ToolStripSeparator1
            //
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(240, 6);
            //
            //DialogbeendenToolStripMenuItem
            //
            this.DialogbeendenToolStripMenuItem.Name = "DialogbeendenToolStripMenuItem";
            this.DialogbeendenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.DialogbeendenToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.DialogbeendenToolStripMenuItem.Text = "Dialog be&enden";
            //
            //MitarbeiterdatenToolStripMenuItem
            //
            this.MitarbeiterdatenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmEmployeeTime, this.ToolStripSeparator10, this.tsmDeleteTimeEntries });
            this.MitarbeiterdatenToolStripMenuItem.Name = "MitarbeiterdatenToolStripMenuItem";
            this.MitarbeiterdatenToolStripMenuItem.Size = new System.Drawing.Size(109, 18);
            this.MitarbeiterdatenToolStripMenuItem.Text = "&Mitarbeiterdaten";
            //
            //tsmEmployeeTime
            //
            this.tsmEmployeeTime.Image = ((System.Drawing.Image)resources.GetObject("tsmEmployeeTime.Image"));
            this.tsmEmployeeTime.Name = "tsmEmployeeTime";
            this.tsmEmployeeTime.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.tsmEmployeeTime.Size = new System.Drawing.Size(275, 22);
            this.tsmEmployeeTime.Text = "Mitarbeiterzeiten hinzufügen...";
            //
            //ToolStripSeparator10
            //
            this.ToolStripSeparator10.Name = "ToolStripSeparator10";
            this.ToolStripSeparator10.Size = new System.Drawing.Size(272, 6);
            //
            //tsmDeleteTimeEntries
            //
            this.tsmDeleteTimeEntries.Name = "tsmDeleteTimeEntries";
            this.tsmDeleteTimeEntries.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmDeleteTimeEntries.Size = new System.Drawing.Size(275, 22);
            this.tsmDeleteTimeEntries.Text = "Markierte Mitarbeiter entfernen";
            //
            //NavigationToolStripMenuItem
            //
            this.NavigationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmNextWorkgroup, this.tsmPrevWorkgroup, this.ToolStripSeparator8, this.tsmNextWorkDay, this.tsmMyTodoList, this.tsmPrevWorkday, this.ToolStripSeparator9, this.tsmShift1, this.tsmShift2, this.tsmShift3, this.tsmShift4 });
            this.NavigationToolStripMenuItem.Name = "NavigationToolStripMenuItem";
            this.NavigationToolStripMenuItem.Size = new System.Drawing.Size(75, 18);
            this.NavigationToolStripMenuItem.Text = "&Navigation";
            //
            //tsmNextWorkgroup
            //
            this.tsmNextWorkgroup.Image = ((System.Drawing.Image)resources.GetObject("tsmNextWorkgroup.Image"));
            this.tsmNextWorkgroup.Name = "tsmNextWorkgroup";
            this.tsmNextWorkgroup.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right));
            this.tsmNextWorkgroup.Size = new System.Drawing.Size(267, 22);
            this.tsmNextWorkgroup.Text = "Nächste Produktiv-Site";
            //
            //tsmPrevWorkgroup
            //
            this.tsmPrevWorkgroup.Image = ((System.Drawing.Image)resources.GetObject("tsmPrevWorkgroup.Image"));
            this.tsmPrevWorkgroup.Name = "tsmPrevWorkgroup";
            this.tsmPrevWorkgroup.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left));
            this.tsmPrevWorkgroup.Size = new System.Drawing.Size(267, 22);
            this.tsmPrevWorkgroup.Text = "Vorherige Produktiv-Site";
            //
            //ToolStripSeparator8
            //
            this.ToolStripSeparator8.Name = "ToolStripSeparator8";
            this.ToolStripSeparator8.Size = new System.Drawing.Size(264, 6);
            //
            //tsmNextWorkDay
            //
            this.tsmNextWorkDay.Image = ((System.Drawing.Image)resources.GetObject("tsmNextWorkDay.Image"));
            this.tsmNextWorkDay.Name = "tsmNextWorkDay";
            this.tsmNextWorkDay.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Right));
            this.tsmNextWorkDay.Size = new System.Drawing.Size(267, 22);
            this.tsmNextWorkDay.Text = "Nächster Arbeitstag";
            //
            //tsmMyTodoList
            //
            this.tsmMyTodoList.Image = ((System.Drawing.Image)resources.GetObject("tsmMyTodoList.Image"));
            this.tsmMyTodoList.Name = "tsmMyTodoList";
            this.tsmMyTodoList.Size = new System.Drawing.Size(267, 22);
            this.tsmMyTodoList.Text = "Meine To-Do-Liste...";
            //
            //tsmPrevWorkday
            //
            this.tsmPrevWorkday.Image = ((System.Drawing.Image)resources.GetObject("tsmPrevWorkday.Image"));
            this.tsmPrevWorkday.Name = "tsmPrevWorkday";
            this.tsmPrevWorkday.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Left));
            this.tsmPrevWorkday.Size = new System.Drawing.Size(267, 22);
            this.tsmPrevWorkday.Text = "Vorheriger Arbeitstag";
            //
            //ToolStripSeparator9
            //
            this.ToolStripSeparator9.Name = "ToolStripSeparator9";
            this.ToolStripSeparator9.Size = new System.Drawing.Size(264, 6);
            //
            //tsmShift1
            //
            this.tsmShift1.Image = ((System.Drawing.Image)resources.GetObject("tsmShift1.Image"));
            this.tsmShift1.Name = "tsmShift1";
            this.tsmShift1.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1));
            this.tsmShift1.Size = new System.Drawing.Size(267, 22);
            this.tsmShift1.Text = "Schicht 1";
            //
            //tsmShift2
            //
            this.tsmShift2.Image = ((System.Drawing.Image)resources.GetObject("tsmShift2.Image"));
            this.tsmShift2.Name = "tsmShift2";
            this.tsmShift2.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2));
            this.tsmShift2.Size = new System.Drawing.Size(267, 22);
            this.tsmShift2.Text = "Schicht 2";
            //
            //tsmShift3
            //
            this.tsmShift3.Image = ((System.Drawing.Image)resources.GetObject("tsmShift3.Image"));
            this.tsmShift3.Name = "tsmShift3";
            this.tsmShift3.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3));
            this.tsmShift3.Size = new System.Drawing.Size(267, 22);
            this.tsmShift3.Text = "Schicht 3";
            //
            //tsmShift4
            //
            this.tsmShift4.Image = ((System.Drawing.Image)resources.GetObject("tsmShift4.Image"));
            this.tsmShift4.Name = "tsmShift4";
            this.tsmShift4.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0));
            this.tsmShift4.Size = new System.Drawing.Size(267, 22);
            this.tsmShift4.Text = "Sonderschicht";
            //
            //tsmView
            //
            this.tsmView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmShowEmployees, this.ToolStripMenuItem1, this.tsmOnlyShowActiveLabourValues });
            this.tsmView.Name = "tsmView";
            this.tsmView.Size = new System.Drawing.Size(59, 18);
            this.tsmView.Text = "&Ansicht";
            //
            //tsmShowEmployees
            //
            this.tsmShowEmployees.Name = "tsmShowEmployees";
            this.tsmShowEmployees.Size = new System.Drawing.Size(256, 22);
            this.tsmShowEmployees.Text = "Beteiligte Mitarbeiter";
            //
            //ToolStripMenuItem1
            //
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(253, 6);
            //
            //tsmOnlyShowActiveLabourValues
            //
            this.tsmOnlyShowActiveLabourValues.Checked = true;
            this.tsmOnlyShowActiveLabourValues.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmOnlyShowActiveLabourValues.Name = "tsmOnlyShowActiveLabourValues";
            this.tsmOnlyShowActiveLabourValues.Size = new System.Drawing.Size(256, 22);
            this.tsmOnlyShowActiveLabourValues.Text = "Nur aktive Arbeitswerte anzeigen";
            //
            //ToolStripContainer1
            //
            //
            //ToolStripContainer1.BottomToolStripPanel
            //
            this.ToolStripContainer1.BottomToolStripPanel.Controls.Add(this.StatusStrip1);
            //
            //ToolStripContainer1.ContentPanel
            //
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.splitProductionData_Employees);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.upperPanel);
            this.ToolStripContainer1.ContentPanel.Size = new System.Drawing.Size(772, 454);
            this.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer1.Name = "ToolStripContainer1";
            this.ToolStripContainer1.Size = new System.Drawing.Size(772, 526);
            this.ToolStripContainer1.TabIndex = 1;
            this.ToolStripContainer1.Text = "ToolStripContainer1";
            //
            //ToolStripContainer1.TopToolStripPanel
            //
            this.ToolStripContainer1.TopToolStripPanel.Controls.Add(this.MenuStrip1);
            this.ToolStripContainer1.TopToolStripPanel.Controls.Add(this.ToolStrip1);
            //
            //StatusStrip1
            //
            this.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.StatusStrip1.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tslSaveImage, this.tslSaveState, this.tslCurrentDateInfo });
            this.StatusStrip1.Location = new System.Drawing.Point(0, 0);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(772, 25);
            this.StatusStrip1.TabIndex = 0;
            this.StatusStrip1.Text = "StatusStrip1";
            //
            //tslSaveImage
            //
            this.tslSaveImage.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom));
            this.tslSaveImage.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tslSaveImage.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.tslSaveImage.Image = ((System.Drawing.Image)resources.GetObject("tslSaveImage.Image"));
            this.tslSaveImage.Name = "tslSaveImage";
            this.tslSaveImage.Size = new System.Drawing.Size(48, 20);
            this.tslSaveImage.Text = "         ";
            this.tslSaveImage.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            //
            //tslSaveState
            //
            this.tslSaveState.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom));
            this.tslSaveState.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tslSaveState.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.tslSaveState.Name = "tslSaveState";
            this.tslSaveState.Size = new System.Drawing.Size(263, 20);
            this.tslSaveState.Text = "Es wurden keine Mengenänderungen vorgenommen.";
            //
            //tslCurrentDateInfo
            //
            this.tslCurrentDateInfo.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom));
            this.tslCurrentDateInfo.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tslCurrentDateInfo.Name = "tslCurrentDateInfo";
            this.tslCurrentDateInfo.Size = new System.Drawing.Size(446, 20);
            this.tslCurrentDateInfo.Spring = true;
            this.tslCurrentDateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //splitProductionData_Employees
            //
            this.splitProductionData_Employees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitProductionData_Employees.Location = new System.Drawing.Point(0, 65);
            this.splitProductionData_Employees.Name = "splitProductionData_Employees";
            this.splitProductionData_Employees.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            //splitProductionData_Employees.Panel1
            //
            this.splitProductionData_Employees.Panel1.Controls.Add(this.gbProductionData);
            //
            //splitProductionData_Employees.Panel2
            //
            this.splitProductionData_Employees.Panel2.Controls.Add(this.gbEmployees);
            this.splitProductionData_Employees.Size = new System.Drawing.Size(772, 389);
            this.splitProductionData_Employees.SplitterDistance = 212;
            this.splitProductionData_Employees.TabIndex = 4;
            this.splitProductionData_Employees.Text = "SplitContainer1";
            //
            //gbProductionData
            //
            this.gbProductionData.Controls.Add(this.dgvProductionData);
            this.gbProductionData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbProductionData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.gbProductionData.Location = new System.Drawing.Point(0, 0);
            this.gbProductionData.Name = "gbProductionData";
            this.gbProductionData.Size = new System.Drawing.Size(772, 212);
            this.gbProductionData.TabIndex = 0;
            this.gbProductionData.TabStop = false;
            this.gbProductionData.Text = "Produktionsdaten:";
            //
            //dgvProductionData
            //
            this.dgvProductionData.AllowUserToAddRows = false;
            this.dgvProductionData.AllowUserToDeleteRows = false;
            this.dgvProductionData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvProductionData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductionData.Location = new System.Drawing.Point(3, 18);
            this.dgvProductionData.Name = "dgvProductionData";
            this.dgvProductionData.OnlyShowActivatedLabourValues = false;
            this.dgvProductionData.ProductionData = null;
            this.dgvProductionData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductionData.Size = new System.Drawing.Size(766, 191);
            this.dgvProductionData.TabIndex = 0;
            this.dgvProductionData.Text = "DataGridView1";
            //
            //gbEmployees
            //
            this.gbEmployees.Controls.Add(this.dgvTimeLogItems);
            this.gbEmployees.Controls.Add(this.layoutAreaLowerLevel);
            this.gbEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.gbEmployees.Location = new System.Drawing.Point(0, 0);
            this.gbEmployees.Name = "gbEmployees";
            this.gbEmployees.Size = new System.Drawing.Size(772, 173);
            this.gbEmployees.TabIndex = 0;
            this.gbEmployees.TabStop = false;
            this.gbEmployees.Text = "Beteiligte Mitarbeiter";
            //
            //dgvTimeLogItems
            //
            this.dgvTimeLogItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTimeLogItems.EmployeeTimeLogItems = null;
            this.dgvTimeLogItems.Location = new System.Drawing.Point(3, 18);
            this.dgvTimeLogItems.Name = "dgvTimeLogItems";
            this.dgvTimeLogItems.SingleEmployeeList = false;
            this.dgvTimeLogItems.Size = new System.Drawing.Size(766, 128);
            this.dgvTimeLogItems.TabIndex = 3;
            this.dgvTimeLogItems.Text = "UcTimeLogItemsDataGridView1";
            //
            //layoutAreaLowerLevel
            //
            this.layoutAreaLowerLevel.ColumnCount = 3;
            this.layoutAreaLowerLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
            this.layoutAreaLowerLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
            this.layoutAreaLowerLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
            this.layoutAreaLowerLevel.Controls.Add(this.lblDegreeOfTime, 2, 0);
            this.layoutAreaLowerLevel.Controls.Add(this.lblMinutesEffective, 0, 0);
            this.layoutAreaLowerLevel.Controls.Add(this.lblMinutesEffectiveAdj, 1, 0);
            this.layoutAreaLowerLevel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.layoutAreaLowerLevel.Location = new System.Drawing.Point(3, 146);
            this.layoutAreaLowerLevel.Name = "layoutAreaLowerLevel";
            this.layoutAreaLowerLevel.RowCount = 1;
            this.layoutAreaLowerLevel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
            this.layoutAreaLowerLevel.Size = new System.Drawing.Size(766, 24);
            this.layoutAreaLowerLevel.TabIndex = 2;
            //
            //lblDegreeOfTime
            //
            this.lblDegreeOfTime.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDegreeOfTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDegreeOfTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDegreeOfTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblDegreeOfTime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDegreeOfTime.Location = new System.Drawing.Point(510, 0);
            this.lblDegreeOfTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblDegreeOfTime.Name = "lblDegreeOfTime";
            this.lblDegreeOfTime.Size = new System.Drawing.Size(256, 24);
            this.lblDegreeOfTime.TabIndex = 3;
            this.lblDegreeOfTime.Text = "Zeitgrad:";
            this.lblDegreeOfTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //lblMinutesEffective
            //
            this.lblMinutesEffective.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblMinutesEffective.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMinutesEffective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinutesEffective.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblMinutesEffective.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMinutesEffective.Location = new System.Drawing.Point(0, 0);
            this.lblMinutesEffective.Margin = new System.Windows.Forms.Padding(0);
            this.lblMinutesEffective.Name = "lblMinutesEffective";
            this.lblMinutesEffective.Size = new System.Drawing.Size(255, 24);
            this.lblMinutesEffective.TabIndex = 1;
            this.lblMinutesEffective.Text = "Min. Effektiv:";
            this.lblMinutesEffective.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //lblMinutesEffectiveAdj
            //
            this.lblMinutesEffectiveAdj.AutoSize = true;
            this.lblMinutesEffectiveAdj.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblMinutesEffectiveAdj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMinutesEffectiveAdj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinutesEffectiveAdj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblMinutesEffectiveAdj.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMinutesEffectiveAdj.Location = new System.Drawing.Point(255, 0);
            this.lblMinutesEffectiveAdj.Margin = new System.Windows.Forms.Padding(0);
            this.lblMinutesEffectiveAdj.Name = "lblMinutesEffectiveAdj";
            this.lblMinutesEffectiveAdj.Size = new System.Drawing.Size(255, 24);
            this.lblMinutesEffectiveAdj.TabIndex = 2;
            this.lblMinutesEffectiveAdj.Text = "Min. Effektiv (ang.):";
            this.lblMinutesEffectiveAdj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //upperPanel
            //
            this.upperPanel.Controls.Add(this.layoutPanelUpperArea);
            this.upperPanel.Controls.Add(this.lblWorkgroup);
            this.upperPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.upperPanel.Location = new System.Drawing.Point(0, 0);
            this.upperPanel.Name = "upperPanel";
            this.upperPanel.Size = new System.Drawing.Size(772, 65);
            this.upperPanel.TabIndex = 5;
            //
            //layoutPanelUpperArea
            //
            this.layoutPanelUpperArea.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.layoutPanelUpperArea.ColumnCount = 2;
            this.layoutPanelUpperArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65f));
            this.layoutPanelUpperArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35f));
            this.layoutPanelUpperArea.Controls.Add(this.lblMinutesReference, 1, 0);
            this.layoutPanelUpperArea.Controls.Add(this.TableLayoutPanel1, 0, 0);
            this.layoutPanelUpperArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanelUpperArea.Location = new System.Drawing.Point(0, 34);
            this.layoutPanelUpperArea.Margin = new System.Windows.Forms.Padding(0);
            this.layoutPanelUpperArea.Name = "layoutPanelUpperArea";
            this.layoutPanelUpperArea.RowCount = 1;
            this.layoutPanelUpperArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
            this.layoutPanelUpperArea.Size = new System.Drawing.Size(772, 31);
            this.layoutPanelUpperArea.TabIndex = 3;
            //
            //lblMinutesReference
            //
            this.lblMinutesReference.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblMinutesReference.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinutesReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblMinutesReference.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMinutesReference.Location = new System.Drawing.Point(501, 0);
            this.lblMinutesReference.Margin = new System.Windows.Forms.Padding(0);
            this.lblMinutesReference.Name = "lblMinutesReference";
            this.lblMinutesReference.Size = new System.Drawing.Size(271, 31);
            this.lblMinutesReference.TabIndex = 2;
            this.lblMinutesReference.Text = "Min. Referenz:";
            this.lblMinutesReference.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //TableLayoutPanel1
            //
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45f));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55f));
            this.TableLayoutPanel1.Controls.Add(this.dtpProductionDate, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.lblShift, 1, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(501, 31);
            this.TableLayoutPanel1.TabIndex = 0;
            //
            //dtpProductionDate
            //
            this.dtpProductionDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpProductionDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.dtpProductionDate.CalendarTrailingForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtpProductionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.dtpProductionDate.Location = new System.Drawing.Point(0, 4);
            this.dtpProductionDate.Margin = new System.Windows.Forms.Padding(0);
            this.dtpProductionDate.Name = "dtpProductionDate";
            this.dtpProductionDate.Size = new System.Drawing.Size(220, 22);
            this.dtpProductionDate.TabIndex = 5;
            //
            //lblShift
            //
            this.lblShift.AutoEllipsis = true;
            this.lblShift.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblShift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblShift.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblShift.Location = new System.Drawing.Point(225, 0);
            this.lblShift.Margin = new System.Windows.Forms.Padding(0);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(276, 31);
            this.lblShift.TabIndex = 6;
            this.lblShift.Text = "Schicht 1";
            this.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //lblWorkgroup
            //
            this.lblWorkgroup.AutoEllipsis = true;
            this.lblWorkgroup.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblWorkgroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWorkgroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblWorkgroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWorkgroup.Location = new System.Drawing.Point(0, 0);
            this.lblWorkgroup.Margin = new System.Windows.Forms.Padding(0);
            this.lblWorkgroup.Name = "lblWorkgroup";
            this.lblWorkgroup.Size = new System.Drawing.Size(772, 34);
            this.lblWorkgroup.TabIndex = 2;
            this.lblWorkgroup.Text = "Datenerfassung für:";
            this.lblWorkgroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            //ToolStrip1
            //
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsbNewEmployeeTimes, this.tsmDeleteShiftData, this.ToolStripSeparator3, this.tssbPrint, this.tsbSaveChanges, this.ToolStripSeparator4, this.tsbNullData, this.ToolStripSeparator2, this.tsbPreviousWorkday, this.tsbMyTodoList, this.tsbNextWorkDay, this.ToolStripSeparator7, this.tsbPreviousWorkgroup, this.tsbNextWorkgroup, this.ToolStripSeparator6, this.tsbShift1, this.tsbShift2, this.tsbShift3, this.tsbShift4, this.ToolStripSeparator11, this.tslSites, this.tscWorkGroup, this.ToolStripSeparator5, this.tsbBack });
            this.ToolStrip1.Location = new System.Drawing.Point(0, 22);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(772, 25);
            this.ToolStrip1.Stretch = true;
            this.ToolStrip1.TabIndex = 1;
            this.ToolStrip1.Text = "ToolStrip1";
            //
            //tsbNewEmployeeTimes
            //
            this.tsbNewEmployeeTimes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewEmployeeTimes.Image = ((System.Drawing.Image)resources.GetObject("tsbNewEmployeeTimes.Image"));
            this.tsbNewEmployeeTimes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewEmployeeTimes.Name = "tsbNewEmployeeTimes";
            this.tsbNewEmployeeTimes.Size = new System.Drawing.Size(23, 22);
            this.tsbNewEmployeeTimes.Text = "Neuer Mitarbeiter in Zeiterfassung";
            //
            //tsmDeleteShiftData
            //
            this.tsmDeleteShiftData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmDeleteShiftData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsbDeleteTimeDataOnly, this.tsmDeleteProductionDataOnly });
            this.tsmDeleteShiftData.Image = ((System.Drawing.Image)resources.GetObject("tsmDeleteShiftData.Image"));
            this.tsmDeleteShiftData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmDeleteShiftData.Name = "tsmDeleteShiftData";
            this.tsmDeleteShiftData.Size = new System.Drawing.Size(32, 22);
            this.tsmDeleteShiftData.Text = "ToolStripSplitButton1";
            this.tsmDeleteShiftData.ToolTipText = "Zeit- und Produktionsdaten dieser Schicht löschen";
            //
            //tsbDeleteTimeDataOnly
            //
            this.tsbDeleteTimeDataOnly.Name = "tsbDeleteTimeDataOnly";
            this.tsbDeleteTimeDataOnly.Size = new System.Drawing.Size(311, 22);
            this.tsbDeleteTimeDataOnly.Text = "Nur Zeitdaten dieser Schicht löschen...";
            //
            //tsmDeleteProductionDataOnly
            //
            this.tsmDeleteProductionDataOnly.Name = "tsmDeleteProductionDataOnly";
            this.tsmDeleteProductionDataOnly.Size = new System.Drawing.Size(311, 22);
            this.tsmDeleteProductionDataOnly.Text = "Nur Produktionsdaten dieser Schicht löschen";
            //
            //ToolStripSeparator3
            //
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            //
            //tssbPrint
            //
            this.tssbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssbPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmOnlyPrintEmployees, this.tsmOnlyPrintProductionData });
            this.tssbPrint.Image = ((System.Drawing.Image)resources.GetObject("tssbPrint.Image"));
            this.tssbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbPrint.Name = "tssbPrint";
            this.tssbPrint.Size = new System.Drawing.Size(32, 22);
            this.tssbPrint.Text = "Diese Schichtbetrachtung drucken";
            //
            //tsmOnlyPrintEmployees
            //
            this.tsmOnlyPrintEmployees.Name = "tsmOnlyPrintEmployees";
            this.tsmOnlyPrintEmployees.Size = new System.Drawing.Size(237, 22);
            this.tsmOnlyPrintEmployees.Text = "Nur Mitarbeiter drucken";
            //
            //tsmOnlyPrintProductionData
            //
            this.tsmOnlyPrintProductionData.Name = "tsmOnlyPrintProductionData";
            this.tsmOnlyPrintProductionData.Size = new System.Drawing.Size(237, 22);
            this.tsmOnlyPrintProductionData.Text = "Nur Produktionsdaten drucken";
            //
            //tsbSaveChanges
            //
            this.tsbSaveChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveChanges.Image = ((System.Drawing.Image)resources.GetObject("tsbSaveChanges.Image"));
            this.tsbSaveChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveChanges.Name = "tsbSaveChanges";
            this.tsbSaveChanges.Size = new System.Drawing.Size(23, 22);
            this.tsbSaveChanges.Text = "Änderungen speichern";
            //
            //ToolStripSeparator4
            //
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            //
            //tsbNullData
            //
            this.tsbNullData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNullData.Image = ((System.Drawing.Image)resources.GetObject("tsbNullData.Image"));
            this.tsbNullData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNullData.Name = "tsbNullData";
            this.tsbNullData.Size = new System.Drawing.Size(23, 22);
            this.tsbNullData.Text = "Alle Daten Nullen";
            //
            //ToolStripSeparator2
            //
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            //
            //tsbPreviousWorkday
            //
            this.tsbPreviousWorkday.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPreviousWorkday.Image = ((System.Drawing.Image)resources.GetObject("tsbPreviousWorkday.Image"));
            this.tsbPreviousWorkday.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPreviousWorkday.Name = "tsbPreviousWorkday";
            this.tsbPreviousWorkday.Size = new System.Drawing.Size(23, 22);
            this.tsbPreviousWorkday.Text = "Vorheriger Arbeitstag";
            //
            //tsbMyTodoList
            //
            this.tsbMyTodoList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMyTodoList.Image = ((System.Drawing.Image)resources.GetObject("tsbMyTodoList.Image"));
            this.tsbMyTodoList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMyTodoList.Name = "tsbMyTodoList";
            this.tsbMyTodoList.Size = new System.Drawing.Size(23, 22);
            this.tsbMyTodoList.Text = "Meine To-Do-List";
            //
            //tsbNextWorkDay
            //
            this.tsbNextWorkDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNextWorkDay.Image = ((System.Drawing.Image)resources.GetObject("tsbNextWorkDay.Image"));
            this.tsbNextWorkDay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNextWorkDay.Name = "tsbNextWorkDay";
            this.tsbNextWorkDay.Size = new System.Drawing.Size(23, 22);
            this.tsbNextWorkDay.Text = "Nächster Arbeitstag";
            //
            //ToolStripSeparator7
            //
            this.ToolStripSeparator7.Name = "ToolStripSeparator7";
            this.ToolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            //
            //tsbPreviousWorkgroup
            //
            this.tsbPreviousWorkgroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPreviousWorkgroup.Image = ((System.Drawing.Image)resources.GetObject("tsbPreviousWorkgroup.Image"));
            this.tsbPreviousWorkgroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPreviousWorkgroup.Name = "tsbPreviousWorkgroup";
            this.tsbPreviousWorkgroup.Size = new System.Drawing.Size(23, 22);
            this.tsbPreviousWorkgroup.Text = "Vorherige Produktiv-Site";
            //
            //tsbNextWorkgroup
            //
            this.tsbNextWorkgroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNextWorkgroup.Image = ((System.Drawing.Image)resources.GetObject("tsbNextWorkgroup.Image"));
            this.tsbNextWorkgroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNextWorkgroup.Name = "tsbNextWorkgroup";
            this.tsbNextWorkgroup.Size = new System.Drawing.Size(23, 22);
            this.tsbNextWorkgroup.Text = "Nächste Produktiv-Site";
            //
            //ToolStripSeparator6
            //
            this.ToolStripSeparator6.Name = "ToolStripSeparator6";
            this.ToolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            //
            //tsbShift1
            //
            this.tsbShift1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShift1.Image = ((System.Drawing.Image)resources.GetObject("tsbShift1.Image"));
            this.tsbShift1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShift1.Name = "tsbShift1";
            this.tsbShift1.Size = new System.Drawing.Size(23, 22);
            this.tsbShift1.Text = "1. Schicht";
            //
            //tsbShift2
            //
            this.tsbShift2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShift2.Image = ((System.Drawing.Image)resources.GetObject("tsbShift2.Image"));
            this.tsbShift2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShift2.Name = "tsbShift2";
            this.tsbShift2.Size = new System.Drawing.Size(23, 22);
            this.tsbShift2.Text = "ToolStripButton2";
            this.tsbShift2.ToolTipText = "2. Schicht";
            //
            //tsbShift3
            //
            this.tsbShift3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShift3.Image = ((System.Drawing.Image)resources.GetObject("tsbShift3.Image"));
            this.tsbShift3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShift3.Name = "tsbShift3";
            this.tsbShift3.Size = new System.Drawing.Size(23, 22);
            this.tsbShift3.Text = "ToolStripButton3";
            this.tsbShift3.ToolTipText = "3. Schicht";
            //
            //tsbShift4
            //
            this.tsbShift4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShift4.Image = ((System.Drawing.Image)resources.GetObject("tsbShift4.Image"));
            this.tsbShift4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShift4.Name = "tsbShift4";
            this.tsbShift4.Size = new System.Drawing.Size(23, 22);
            this.tsbShift4.Text = "ToolStripButton1";
            this.tsbShift4.ToolTipText = "Sonderschicht";
            //
            //ToolStripSeparator11
            //
            this.ToolStripSeparator11.Name = "ToolStripSeparator11";
            this.ToolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            //
            //tslSites
            //
            this.tslSites.Name = "tslSites";
            this.tslSites.Size = new System.Drawing.Size(34, 22);
            this.tslSites.Text = "&Sites:";
            //
            //tscWorkGroup
            //
            this.tscWorkGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscWorkGroup.Name = "tscWorkGroup";
            this.tscWorkGroup.Size = new System.Drawing.Size(300, 25);
            this.tscWorkGroup.ToolTipText = "Produktiv-Sites";
            //
            //ToolStripSeparator5
            //
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            this.ToolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            //
            //tsbBack
            //
            this.tsbBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBack.Image = ((System.Drawing.Image)resources.GetObject("tsbBack.Image"));
            this.tsbBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBack.Name = "tsbBack";
            this.tsbBack.Size = new System.Drawing.Size(23, 22);
            this.tsbBack.Text = "Dialog beenden";
            //
            //ToolStrip
            //
            this.ToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Location = new System.Drawing.Point(174, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(555, 25);
            this.ToolStrip.Stretch = true;
            this.ToolStrip.TabIndex = 1;
            this.ToolStrip.Text = "Übernehmen";
            //
            //mainTimer
            //
            this.mainTimer.Enabled = true;
            this.mainTimer.Interval = 250;
            //
            //frmProductionDataCollector
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 526);
            this.Controls.Add(this.ToolStripContainer1);
            this.MainMenuStrip = this.MenuStrip1;
            this.MinimumSize = new System.Drawing.Size(780, 560);
            this.Name = "frmProductionDataCollector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facesso-Datenmanager - Erfassung von Betriebsdaten und Personalzeiten";
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.ToolStripContainer1.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer1.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer1.ResumeLayout(false);
            this.ToolStripContainer1.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.splitProductionData_Employees.Panel1.ResumeLayout(false);
            this.splitProductionData_Employees.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.splitProductionData_Employees).EndInit();
            this.splitProductionData_Employees.ResumeLayout(false);
            this.gbProductionData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvProductionData).EndInit();
            this.gbEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvTimeLogItems).EndInit();
            this.layoutAreaLowerLevel.ResumeLayout(false);
            this.layoutAreaLowerLevel.PerformLayout();
            this.upperPanel.ResumeLayout(false);
            this.layoutPanelUpperArea.ResumeLayout(false);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem tsmProductionData;
        internal System.Windows.Forms.ToolStripContainer ToolStripContainer1;
        internal System.Windows.Forms.SplitContainer splitProductionData_Employees;
        internal System.Windows.Forms.Panel upperPanel;
        internal System.Windows.Forms.GroupBox gbProductionData;
        internal System.Windows.Forms.GroupBox gbEmployees;
        internal System.Windows.Forms.ToolStripMenuItem tsmView;
        internal System.Windows.Forms.ToolStripMenuItem tsmShowEmployees;
        internal System.Windows.Forms.ToolStripMenuItem AlleEingabenzurücksetzenToolStripMenuItem;
        internal System.Windows.Forms.TableLayoutPanel layoutPanelUpperArea;
        internal System.Windows.Forms.Label lblWorkgroup;
        internal System.Windows.Forms.TableLayoutPanel layoutAreaLowerLevel;
        internal System.Windows.Forms.Label lblMinutesEffectiveAdj;
        internal System.Windows.Forms.Label lblMinutesEffective;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripMenuItem _DialogbeendenToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem DialogbeendenToolStripMenuItem
        {
            get
            {
                return _DialogbeendenToolStripMenuItem;
            }

            set
            {
                if (_DialogbeendenToolStripMenuItem != null)
                {
                    _DialogbeendenToolStripMenuItem.Click -= DialogbeendenToolStripMenuItem_Click;
                }

                _DialogbeendenToolStripMenuItem = value;
                if (_DialogbeendenToolStripMenuItem != null)
                {
                    _DialogbeendenToolStripMenuItem.Click += DialogbeendenToolStripMenuItem_Click;
                }
            }
        }

        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton tsbSaveChanges;
        internal System.Windows.Forms.ToolStripButton tsbNullData;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        private System.Windows.Forms.ToolStripButton _tsbNextWorkDay;
        internal System.Windows.Forms.ToolStripButton tsbNextWorkDay
        {
            get
            {
                return _tsbNextWorkDay;
            }

            set
            {
                if (_tsbNextWorkDay != null)
                {
                    _tsbNextWorkDay.Click -= tsbNextWorkDay_Click;
                }

                _tsbNextWorkDay = value;
                if (_tsbNextWorkDay != null)
                {
                    _tsbNextWorkDay.Click += tsbNextWorkDay_Click;
                }
            }
        }

        private System.Windows.Forms.ToolStripButton _tsbMyTodoList;
        internal System.Windows.Forms.ToolStripButton tsbMyTodoList
        {
            get
            {
                return _tsbMyTodoList;
            }

            set
            {
                if (_tsbMyTodoList != null)
                {
                    _tsbMyTodoList.Click -= tsbMyTodoList_Click;
                }

                _tsbMyTodoList = value;
                if (_tsbMyTodoList != null)
                {
                    _tsbMyTodoList.Click += tsbMyTodoList_Click;
                }
            }
        }

        private System.Windows.Forms.ToolStripButton _tsbPreviousWorkday;
        internal System.Windows.Forms.ToolStripButton tsbPreviousWorkday
        {
            get
            {
                return _tsbPreviousWorkday;
            }

            set
            {
                if (_tsbPreviousWorkday != null)
                {
                    _tsbPreviousWorkday.Click -= tsbPreviousWorkday_Click;
                }

                _tsbPreviousWorkday = value;
                if (_tsbPreviousWorkday != null)
                {
                    _tsbPreviousWorkday.Click += tsbPreviousWorkday_Click;
                }
            }
        }

        private System.Windows.Forms.ToolStripButton _tsbPreviousWorkgroup;
        internal System.Windows.Forms.ToolStripButton tsbPreviousWorkgroup
        {
            get
            {
                return _tsbPreviousWorkgroup;
            }

            set
            {
                if (_tsbPreviousWorkgroup != null)
                {
                    _tsbPreviousWorkgroup.Click -= tsbPreviousWorkgroup_Click;
                }

                _tsbPreviousWorkgroup = value;
                if (_tsbPreviousWorkgroup != null)
                {
                    _tsbPreviousWorkgroup.Click += tsbPreviousWorkgroup_Click;
                }
            }
        }

        private System.Windows.Forms.ToolStripButton _tsbNewEmployeeTimes;
        internal System.Windows.Forms.ToolStripButton tsbNewEmployeeTimes
        {
            get
            {
                return _tsbNewEmployeeTimes;
            }

            set
            {
                if (_tsbNewEmployeeTimes != null)
                {
                    _tsbNewEmployeeTimes.Click -= tsmEmployeeTime_Click;
                }

                _tsbNewEmployeeTimes = value;
                if (_tsbNewEmployeeTimes != null)
                {
                    _tsbNewEmployeeTimes.Click += tsmEmployeeTime_Click;
                }
            }
        }

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
        private System.Windows.Forms.ToolStripButton _tsbBack;
        internal System.Windows.Forms.ToolStripButton tsbBack
        {
            get
            {
                return _tsbBack;
            }

            set
            {
                if (_tsbBack != null)
                {
                    _tsbBack.Click -= tsbBack_Click;
                }

                _tsbBack = value;
                if (_tsbBack != null)
                {
                    _tsbBack.Click += tsbBack_Click;
                }
            }
        }

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator5;
        private System.Windows.Forms.ToolStripButton _tsbNextWorkgroup;
        internal System.Windows.Forms.ToolStripButton tsbNextWorkgroup
        {
            get
            {
                return _tsbNextWorkgroup;
            }

            set
            {
                if (_tsbNextWorkgroup != null)
                {
                    _tsbNextWorkgroup.Click -= tsbNextWorkgroup_Click;
                }

                _tsbNextWorkgroup = value;
                if (_tsbNextWorkgroup != null)
                {
                    _tsbNextWorkgroup.Click += tsbNextWorkgroup_Click;
                }
            }
        }

        private System.Windows.Forms.ToolStripSplitButton _tssbPrint;
        internal System.Windows.Forms.ToolStripSplitButton tssbPrint
        {
            get
            {
                return _tssbPrint;
            }

            set
            {
                if (_tssbPrint != null)
                {
                    _tssbPrint.Click -= tssbPrint_Click;
                }

                _tssbPrint = value;
                if (_tssbPrint != null)
                {
                    _tssbPrint.Click += tssbPrint_Click;
                }
            }
        }

        internal System.Windows.Forms.ToolStripMenuItem tsmOnlyPrintEmployees;
        internal System.Windows.Forms.ToolStripMenuItem tsmOnlyPrintProductionData;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator6;
        private System.Windows.Forms.ToolStripButton _tsbShift1;
        internal System.Windows.Forms.ToolStripButton tsbShift1
        {
            get
            {
                return _tsbShift1;
            }

            set
            {
                if (_tsbShift1 != null)
                {
                    _tsbShift1.Click -= tsbShift1_Click;
                }

                _tsbShift1 = value;
                if (_tsbShift1 != null)
                {
                    _tsbShift1.Click += tsbShift1_Click;
                }
            }
        }

        private System.Windows.Forms.ToolStripButton _tsbShift2;
        internal System.Windows.Forms.ToolStripButton tsbShift2
        {
            get
            {
                return _tsbShift2;
            }

            set
            {
                if (_tsbShift2 != null)
                {
                    _tsbShift2.Click -= tsbShift2_Click;
                }

                _tsbShift2 = value;
                if (_tsbShift2 != null)
                {
                    _tsbShift2.Click += tsbShift2_Click;
                }
            }
        }

        private System.Windows.Forms.ToolStripButton _tsbShift3;
        internal System.Windows.Forms.ToolStripButton tsbShift3
        {
            get
            {
                return _tsbShift3;
            }

            set
            {
                if (_tsbShift3 != null)
                {
                    _tsbShift3.Click -= tsbShift3_Click;
                }

                _tsbShift3 = value;
                if (_tsbShift3 != null)
                {
                    _tsbShift3.Click += tsbShift3_Click;
                }
            }
        }

        private System.Windows.Forms.ToolStripButton _tsbShift4;
        internal System.Windows.Forms.ToolStripButton tsbShift4
        {
            get
            {
                return _tsbShift4;
            }

            set
            {
                if (_tsbShift4 != null)
                {
                    _tsbShift4.Click -= tsbShift4_Click;
                }

                _tsbShift4 = value;
                if (_tsbShift4 != null)
                {
                    _tsbShift4.Click += tsbShift4_Click;
                }
            }
        }

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator7;
        private System.Windows.Forms.ToolStripComboBox _tscWorkGroup;
        internal System.Windows.Forms.ToolStripComboBox tscWorkGroup
        {
            get
            {
                return _tscWorkGroup;
            }

            set
            {
                if (_tscWorkGroup != null)
                {
                    _tscWorkGroup.SelectedIndexChanged -= tscWorkGroup_SelectedIndexChanged;
                }

                _tscWorkGroup = value;
                if (_tscWorkGroup != null)
                {
                    _tscWorkGroup.SelectedIndexChanged += tscWorkGroup_SelectedIndexChanged;
                }
            }
        }

        internal System.Windows.Forms.ToolStripLabel tslSites;
        private System.Windows.Forms.ToolStripMenuItem _tsmSaveChanges;
        internal System.Windows.Forms.ToolStripMenuItem tsmSaveChanges
        {
            get
            {
                return _tsmSaveChanges;
            }

            set
            {
                if (_tsmSaveChanges != null)
                {
                    _tsmSaveChanges.Click -= tsmSaveChanges_Click;
                }

                _tsmSaveChanges = value;
                if (_tsmSaveChanges != null)
                {
                    _tsmSaveChanges.Click += tsmSaveChanges_Click;
                }
            }
        }

        internal System.Windows.Forms.ToolStripMenuItem NavigationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _tsmNextWorkgroup;
        internal System.Windows.Forms.ToolStripMenuItem tsmNextWorkgroup
        {
            get
            {
                return _tsmNextWorkgroup;
            }

            set
            {
                if (_tsmNextWorkgroup != null)
                {
                    _tsmNextWorkgroup.Click -= tsbNextWorkgroup_Click;
                }

                _tsmNextWorkgroup = value;
                if (_tsmNextWorkgroup != null)
                {
                    _tsmNextWorkgroup.Click += tsbNextWorkgroup_Click;
                }
            }
        }

        private System.Windows.Forms.ToolStripMenuItem _tsmPrevWorkgroup;
        internal System.Windows.Forms.ToolStripMenuItem tsmPrevWorkgroup
        {
            get
            {
                return _tsmPrevWorkgroup;
            }

            set
            {
                if (_tsmPrevWorkgroup != null)
                {
                    _tsmPrevWorkgroup.Click -= tsbPreviousWorkgroup_Click;
                }

                _tsmPrevWorkgroup = value;
                if (_tsmPrevWorkgroup != null)
                {
                    _tsmPrevWorkgroup.Click += tsbPreviousWorkgroup_Click;
                }
            }
        }

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem _tsmNextWorkDay;
        internal System.Windows.Forms.ToolStripMenuItem tsmNextWorkDay
        {
            get
            {
                return _tsmNextWorkDay;
            }

            set
            {
                if (_tsmNextWorkDay != null)
                {
                    _tsmNextWorkDay.Click -= tsbNextWorkDay_Click;
                }

                _tsmNextWorkDay = value;
                if (_tsmNextWorkDay != null)
                {
                    _tsmNextWorkDay.Click += tsbNextWorkDay_Click;
                }
            }
        }

        private System.Windows.Forms.ToolStripMenuItem _tsmMyTodoList;
        internal System.Windows.Forms.ToolStripMenuItem tsmMyTodoList
        {
            get
            {
                return _tsmMyTodoList;
            }

            set
            {
                if (_tsmMyTodoList != null)
                {
                    _tsmMyTodoList.Click -= tsbMyTodoList_Click;
                }

                _tsmMyTodoList = value;
                if (_tsmMyTodoList != null)
                {
                    _tsmMyTodoList.Click += tsbMyTodoList_Click;
                }
            }
        }

        private System.Windows.Forms.ToolStripMenuItem _tsmPrevWorkday;
        internal System.Windows.Forms.ToolStripMenuItem tsmPrevWorkday
        {
            get
            {
                return _tsmPrevWorkday;
            }

            set
            {
                if (_tsmPrevWorkday != null)
                {
                    _tsmPrevWorkday.Click -= tsbPreviousWorkday_Click;
                }

                _tsmPrevWorkday = value;
                if (_tsmPrevWorkday != null)
                {
                    _tsmPrevWorkday.Click += tsbPreviousWorkday_Click;
                }
            }
        }

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem _tsmShift1;
        internal System.Windows.Forms.ToolStripMenuItem tsmShift1
        {
            get
            {
                return _tsmShift1;
            }

            set
            {
                if (_tsmShift1 != null)
                {
                    _tsmShift1.Click -= tsbShift1_Click;
                }

                _tsmShift1 = value;
                if (_tsmShift1 != null)
                {
                    _tsmShift1.Click += tsbShift1_Click;
                }
            }
        }

        private System.Windows.Forms.ToolStripMenuItem _tsmShift2;
        internal System.Windows.Forms.ToolStripMenuItem tsmShift2
        {
            get
            {
                return _tsmShift2;
            }

            set
            {
                if (_tsmShift2 != null)
                {
                    _tsmShift2.Click -= tsbShift2_Click;
                }

                _tsmShift2 = value;
                if (_tsmShift2 != null)
                {
                    _tsmShift2.Click += tsbShift2_Click;
                }
            }
        }

        private System.Windows.Forms.ToolStripMenuItem _tsmShift3;
        internal System.Windows.Forms.ToolStripMenuItem tsmShift3
        {
            get
            {
                return _tsmShift3;
            }

            set
            {
                if (_tsmShift3 != null)
                {
                    _tsmShift3.Click -= tsbShift3_Click;
                }

                _tsmShift3 = value;
                if (_tsmShift3 != null)
                {
                    _tsmShift3.Click += tsbShift3_Click;
                }
            }
        }

        private System.Windows.Forms.ToolStripMenuItem _tsmShift4;
        internal System.Windows.Forms.ToolStripMenuItem tsmShift4
        {
            get
            {
                return _tsmShift4;
            }

            set
            {
                if (_tsmShift4 != null)
                {
                    _tsmShift4.Click -= tsbShift4_Click;
                }

                _tsmShift4 = value;
                if (_tsmShift4 != null)
                {
                    _tsmShift4.Click += tsbShift4_Click;
                }
            }
        }

        internal System.Windows.Forms.ToolStripMenuItem MitarbeiterdatenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _tsmEmployeeTime;
        internal System.Windows.Forms.ToolStripMenuItem tsmEmployeeTime
        {
            get
            {
                return _tsmEmployeeTime;
            }

            set
            {
                if (_tsmEmployeeTime != null)
                {
                    _tsmEmployeeTime.Click -= tsmEmployeeTime_Click;
                }

                _tsmEmployeeTime = value;
                if (_tsmEmployeeTime != null)
                {
                    _tsmEmployeeTime.Click += tsmEmployeeTime_Click;
                }
            }
        }

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem _tsmDeleteTimeEntries;
        internal System.Windows.Forms.ToolStripMenuItem tsmDeleteTimeEntries
        {
            get
            {
                return _tsmDeleteTimeEntries;
            }

            set
            {
                if (_tsmDeleteTimeEntries != null)
                {
                    _tsmDeleteTimeEntries.Click -= tsmDeleteTimeEntries_Click;
                }

                _tsmDeleteTimeEntries = value;
                if (_tsmDeleteTimeEntries != null)
                {
                    _tsmDeleteTimeEntries.Click += tsmDeleteTimeEntries_Click;
                }
            }
        }

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator11;
        internal Facesso.GenericControls.ucProductionDataGridView dgvProductionData;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker _dtpProductionDate;
        internal System.Windows.Forms.DateTimePicker dtpProductionDate
        {
            get
            {
                return _dtpProductionDate;
            }

            set
            {
                if (_dtpProductionDate != null)
                {
                    _dtpProductionDate.ValueChanged -= dtpProductionDate_ValueChanged;
                }

                _dtpProductionDate = value;
                if (_dtpProductionDate != null)
                {
                    _dtpProductionDate.ValueChanged += dtpProductionDate_ValueChanged;
                }
            }
        }

        internal System.Windows.Forms.Label lblShift;
        internal System.Windows.Forms.Label lblDegreeOfTime;
        private Facesso.GenericControls.ucTimeLogItemsDataGridView _dgvTimeLogItems;
        internal Facesso.GenericControls.ucTimeLogItemsDataGridView dgvTimeLogItems
        {
            get
            {
                return _dgvTimeLogItems;
            }

            set
            {
                if (_dgvTimeLogItems != null)
                {
                    _dgvTimeLogItems.TimeLogItemDoubleClick -= dgvTimeLogItems_TimeLogItemDoubleClick;
                }

                _dgvTimeLogItems = value;
                if (_dgvTimeLogItems != null)
                {
                    _dgvTimeLogItems.TimeLogItemDoubleClick += dgvTimeLogItems_TimeLogItemDoubleClick;
                }
            }
        }

        internal System.Windows.Forms.Label lblMinutesReference;
        internal System.Windows.Forms.ToolStripStatusLabel tslSaveImage;
        internal System.Windows.Forms.ToolStripStatusLabel tslSaveState;
        internal System.Windows.Forms.ToolStripStatusLabel tslCurrentDateInfo;
        private System.Windows.Forms.Timer _mainTimer;
        internal System.Windows.Forms.Timer mainTimer
        {
            get
            {
                return _mainTimer;
            }

            set
            {
                if (_mainTimer != null)
                {
                    _mainTimer.Tick -= mainTimer_Tick;
                }

                _mainTimer = value;
                if (_mainTimer != null)
                {
                    _mainTimer.Tick += mainTimer_Tick;
                }
            }
        }

        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _tsmOnlyShowActiveLabourValues;
        internal System.Windows.Forms.ToolStripMenuItem tsmOnlyShowActiveLabourValues
        {
            get
            {
                return _tsmOnlyShowActiveLabourValues;
            }

            set
            {
                if (_tsmOnlyShowActiveLabourValues != null)
                {
                    _tsmOnlyShowActiveLabourValues.Click -= tsmOnlyShowActiveLabourValues_Click;
                }

                _tsmOnlyShowActiveLabourValues = value;
                if (_tsmOnlyShowActiveLabourValues != null)
                {
                    _tsmOnlyShowActiveLabourValues.Click += tsmOnlyShowActiveLabourValues_Click;
                }
            }
        }

        private System.Windows.Forms.ToolStripSplitButton _tsmDeleteShiftData;
        internal System.Windows.Forms.ToolStripSplitButton tsmDeleteShiftData
        {
            get
            {
                return _tsmDeleteShiftData;
            }

            set
            {
                if (_tsmDeleteShiftData != null)
                {
                    _tsmDeleteShiftData.ButtonClick -= tsmDeleteShiftData_ButtonClick;
                }

                _tsmDeleteShiftData = value;
                if (_tsmDeleteShiftData != null)
                {
                    _tsmDeleteShiftData.ButtonClick += tsmDeleteShiftData_ButtonClick;
                }
            }
        }

        internal System.Windows.Forms.ToolStripMenuItem tsbDeleteTimeDataOnly;
        internal System.Windows.Forms.ToolStripMenuItem tsmDeleteProductionDataOnly;
    }
}