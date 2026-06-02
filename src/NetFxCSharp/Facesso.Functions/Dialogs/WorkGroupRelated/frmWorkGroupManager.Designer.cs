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
    public partial class frmWorkGroupManager : frmBaseFacesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorkGroupManager));
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ProduktivSitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNewWorkgroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNewWorkgroup.Click += btnNewWorkGroup_Click;
            this.tsmEditWorkgroupData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditWorkgroupData.Click += tsmEditWorkgroupData_Click;
            this.tsmDeleteWorkgroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteWorkgroup.Click += tsmDeleteWorkgroup_Click;
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmPrintWorkGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPrintWorkGroup.Click += tsmPrintWorkGroup_Click;
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmAssignLabourValues = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAssignLabourValues.Click += btnAssignToWorkGroup_Click;
            this.tsmUnAssignLabourValues = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUnAssignLabourValues.Click += btnDeleteFromAssignment_Click;
            this.AnsichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowQuickStartButtons = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowQuickStartButtons.Click += tsmShowQuickStartButtons_Click;
            this.tsmGroupLabourValues = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGroupLabourValues.Click += tsmGroupLabourValues_Click;
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmGreyUsedLabourValues = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOK = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOK.Click += OKToolStripMenuItem_Click;
            this.ToolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitLabourValuesQuickButtons = new System.Windows.Forms.SplitContainer();
            this.lvlToAssign = new Facesso.GenericControls.ucLabourValueListView();
            this.lvlToAssign.SelectedIndexChanged += lvlToAssign_SelectedIndexChanged;
            this.Label1 = new System.Windows.Forms.Label();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeleteFromAssignment = new System.Windows.Forms.Button();
            this.btnDeleteFromAssignment.Click += btnDeleteFromAssignment_Click;
            this.btnNewWorkGroup = new System.Windows.Forms.Button();
            this.btnNewWorkGroup.Click += btnNewWorkGroup_Click;
            this.btnAssignToWorkGroup = new System.Windows.Forms.Button();
            this.btnAssignToWorkGroup.Click += btnAssignToWorkGroup_Click;
            this.splitWorkGroupsAssignments = new System.Windows.Forms.SplitContainer();
            this.wglSetup = new Facesso.GenericControls.ucWorkGroupListView();
            this.wglSetup.SelectedIndexChanged += wglSetup_SelectedIndexChanged;
            this.Label2 = new System.Windows.Forms.Label();
            this.lvlAssigned = new Facesso.GenericControls.ucLabourValueListView();
            this.lvlAssigned.SelectedIndexChanged += lvlAssigned_SelectedIndexChanged;
            this.lblSelectedWorkgroup = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNewWorkgroup = new System.Windows.Forms.ToolStripButton();
            this.tsbNewWorkgroup.Click += btnNewWorkGroup_Click;
            this.tsbEditWorkgroup = new System.Windows.Forms.ToolStripButton();
            this.tsbEditWorkgroup.Click += tsmEditWorkgroupData_Click;
            this.tsbDeleteWorkgroup = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteWorkgroup.Click += tsbDeleteWorkgroup_Click;
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrintWorkGroupList = new System.Windows.Forms.ToolStripButton();
            this.tsbPrintWorkGroupList.Click += tsmPrintWorkGroup_Click;
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAssignLabourValues = new System.Windows.Forms.ToolStripButton();
            this.tsbAssignLabourValues.Click += btnAssignToWorkGroup_Click;
            this.tsbUnassignLabourValues = new System.Windows.Forms.ToolStripButton();
            this.tsbUnassignLabourValues.Click += btnDeleteFromAssignment_Click;
            this.MenuStrip1.SuspendLayout();
            this.ToolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.ToolStripContainer1.ContentPanel.SuspendLayout();
            this.ToolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer1.SuspendLayout();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.splitLabourValuesQuickButtons.Panel1.SuspendLayout();
            this.splitLabourValuesQuickButtons.Panel2.SuspendLayout();
            this.splitLabourValuesQuickButtons.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.splitWorkGroupsAssignments.Panel1.SuspendLayout();
            this.splitWorkGroupsAssignments.Panel2.SuspendLayout();
            this.splitWorkGroupsAssignments.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            //MenuStrip1
            //
            this.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ProduktivSitesToolStripMenuItem, this.AnsichtToolStripMenuItem, this.tsmOK });
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(865, 24);
            this.MenuStrip1.TabIndex = 0;
            this.MenuStrip1.Text = "MenuStrip1";
            //
            //ProduktivSitesToolStripMenuItem
            //
            this.ProduktivSitesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmNewWorkgroup, this.tsmEditWorkgroupData, this.tsmDeleteWorkgroup, this.ToolStripMenuItem3, this.tsmPrintWorkGroup, this.ToolStripSeparator1, this.tsmAssignLabourValues, this.tsmUnAssignLabourValues });
            this.ProduktivSitesToolStripMenuItem.Name = "ProduktivSitesToolStripMenuItem";
            this.ProduktivSitesToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.ProduktivSitesToolStripMenuItem.Text = "&Produktiv-Sites";
            //
            //tsmNewWorkgroup
            //
            this.tsmNewWorkgroup.Image = ((System.Drawing.Image)resources.GetObject("tsmNewWorkgroup.Image"));
            this.tsmNewWorkgroup.Name = "tsmNewWorkgroup";
            this.tsmNewWorkgroup.Size = new System.Drawing.Size(327, 22);
            this.tsmNewWorkgroup.Text = "Neue Produktiv-Site anlegen...";
            //
            //tsmEditWorkgroupData
            //
            this.tsmEditWorkgroupData.Image = ((System.Drawing.Image)resources.GetObject("tsmEditWorkgroupData.Image"));
            this.tsmEditWorkgroupData.Name = "tsmEditWorkgroupData";
            this.tsmEditWorkgroupData.Size = new System.Drawing.Size(288, 22);
            this.tsmEditWorkgroupData.Text = "Produktiv-Site-Daten bearbeiten...";
            //
            //tsmDeleteWorkgroup
            //
            this.tsmDeleteWorkgroup.Image = ((System.Drawing.Image)resources.GetObject("tsmDeleteWorkgroup.Image"));
            this.tsmDeleteWorkgroup.Name = "tsmDeleteWorkgroup";
            this.tsmDeleteWorkgroup.Size = new System.Drawing.Size(288, 22);
            this.tsmDeleteWorkgroup.Text = "Produktiv-Site l�schen...";
            //
            //ToolStripMenuItem3
            //
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            this.ToolStripMenuItem3.Size = new System.Drawing.Size(285, 6);
            //
            //tsmPrintWorkGroup
            //
            this.tsmPrintWorkGroup.Image = ((System.Drawing.Image)resources.GetObject("tsmPrintWorkGroup.Image"));
            this.tsmPrintWorkGroup.Name = "tsmPrintWorkGroup";
            this.tsmPrintWorkGroup.Size = new System.Drawing.Size(327, 22);
            this.tsmPrintWorkGroup.Text = "Produktiv-Site-Liste/REFA-Arbeitswerte drucken...";
            //
            //ToolStripSeparator1
            //
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(285, 6);
            //
            //tsmAssignLabourValues
            //
            this.tsmAssignLabourValues.Image = ((System.Drawing.Image)resources.GetObject("tsmAssignLabourValues.Image"));
            this.tsmAssignLabourValues.Name = "tsmAssignLabourValues";
            this.tsmAssignLabourValues.Size = new System.Drawing.Size(288, 22);
            this.tsmAssignLabourValues.Text = "Selektierte Arbeitswerte hinzuf�gen";
            //
            //tsmUnAssignLabourValues
            //
            this.tsmUnAssignLabourValues.Image = ((System.Drawing.Image)resources.GetObject("tsmUnAssignLabourValues.Image"));
            this.tsmUnAssignLabourValues.Name = "tsmUnAssignLabourValues";
            this.tsmUnAssignLabourValues.Size = new System.Drawing.Size(288, 22);
            this.tsmUnAssignLabourValues.Text = "Arbeitswerte aus Produktiv-Site entfernen";
            //
            //AnsichtToolStripMenuItem
            //
            this.AnsichtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsmShowQuickStartButtons, this.tsmGroupLabourValues, this.ToolStripSeparator2, this.tsmGreyUsedLabourValues });
            this.AnsichtToolStripMenuItem.Name = "AnsichtToolStripMenuItem";
            this.AnsichtToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.AnsichtToolStripMenuItem.Text = "&Ansicht";
            //
            //tsmShowQuickStartButtons
            //
            this.tsmShowQuickStartButtons.Checked = true;
            this.tsmShowQuickStartButtons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmShowQuickStartButtons.Name = "tsmShowQuickStartButtons";
            this.tsmShowQuickStartButtons.Size = new System.Drawing.Size(262, 22);
            this.tsmShowQuickStartButtons.Text = "Schnellschaltfl�chen";
            //
            //tsmGroupLabourValues
            //
            this.tsmGroupLabourValues.Checked = true;
            this.tsmGroupLabourValues.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmGroupLabourValues.Name = "tsmGroupLabourValues";
            this.tsmGroupLabourValues.Size = new System.Drawing.Size(262, 22);
            this.tsmGroupLabourValues.Text = "Arbeitswerte gruppieren";
            //
            //ToolStripSeparator2
            //
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(259, 6);
            //
            //tsmGreyUsedLabourValues
            //
            this.tsmGreyUsedLabourValues.Name = "tsmGreyUsedLabourValues";
            this.tsmGreyUsedLabourValues.Size = new System.Drawing.Size(262, 22);
            this.tsmGreyUsedLabourValues.Text = "Verwendete Arbeitswerte ausgrauen";
            //
            //tsmOK
            //
            this.tsmOK.Name = "tsmOK";
            this.tsmOK.Size = new System.Drawing.Size(33, 20);
            this.tsmOK.Text = "&OK";
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
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.SplitContainer1);
            this.ToolStripContainer1.ContentPanel.Size = new System.Drawing.Size(865, 555);
            this.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer1.Name = "ToolStripContainer1";
            this.ToolStripContainer1.Size = new System.Drawing.Size(865, 626);
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
            this.StatusStrip1.Location = new System.Drawing.Point(0, 0);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(865, 22);
            this.StatusStrip1.TabIndex = 0;
            this.StatusStrip1.Text = "StatusStrip1";
            //
            //SplitContainer1
            //
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            //SplitContainer1.Panel1
            //
            this.SplitContainer1.Panel1.Controls.Add(this.splitLabourValuesQuickButtons);
            //
            //SplitContainer1.Panel2
            //
            this.SplitContainer1.Panel2.Controls.Add(this.splitWorkGroupsAssignments);
            this.SplitContainer1.Size = new System.Drawing.Size(865, 555);
            this.SplitContainer1.SplitterDistance = 251;
            this.SplitContainer1.TabIndex = 0;
            this.SplitContainer1.Text = "SplitContainer1";
            //
            //splitLabourValuesQuickButtons
            //
            this.splitLabourValuesQuickButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLabourValuesQuickButtons.Location = new System.Drawing.Point(0, 0);
            this.splitLabourValuesQuickButtons.Name = "splitLabourValuesQuickButtons";
            //
            //splitLabourValuesQuickButtons.Panel1
            //
            this.splitLabourValuesQuickButtons.Panel1.Controls.Add(this.lvlToAssign);
            this.splitLabourValuesQuickButtons.Panel1.Controls.Add(this.Label1);
            //
            //splitLabourValuesQuickButtons.Panel2
            //
            this.splitLabourValuesQuickButtons.Panel2.Controls.Add(this.TableLayoutPanel1);
            this.splitLabourValuesQuickButtons.Size = new System.Drawing.Size(865, 251);
            this.splitLabourValuesQuickButtons.SplitterDistance = 613;
            this.splitLabourValuesQuickButtons.TabIndex = 0;
            this.splitLabourValuesQuickButtons.Text = "SplitContainer3";
            //
            //lvlToAssign
            //
            this.lvlToAssign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.lvlToAssign.AutoGroup = true;
            this.lvlToAssign.FullRowSelect = true;
            this.lvlToAssign.HideSelection = false;
            this.lvlToAssign.LabourValues = null;
            this.lvlToAssign.LabourValueSortOrder = Facesso.GenericControls.LabourValuesSortOrder.LabourValueNumber;
            this.lvlToAssign.Location = new System.Drawing.Point(0, 21);
            this.lvlToAssign.Name = "lvlToAssign";
            this.lvlToAssign.Size = new System.Drawing.Size(611, 228);
            this.lvlToAssign.TabIndex = 10;
            this.lvlToAssign.UseCompatibleStateImageBehavior = false;
            this.lvlToAssign.View = System.Windows.Forms.View.Details;
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label1.Location = new System.Drawing.Point(3, 4);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(330, 13);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "REFA-Arbeitswerte f�r die Zuordnung an Produktiv-Sites:";
            //
            //TableLayoutPanel1
            //
            this.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
            this.TableLayoutPanel1.Controls.Add(this.btnDeleteFromAssignment, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.btnNewWorkGroup, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.btnAssignToWorkGroup, 0, 1);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 3;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(248, 251);
            this.TableLayoutPanel1.TabIndex = 0;
            //
            //btnDeleteFromAssignment
            //
            this.btnDeleteFromAssignment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeleteFromAssignment.Enabled = false;
            this.btnDeleteFromAssignment.Location = new System.Drawing.Point(22, 183);
            this.btnDeleteFromAssignment.Name = "btnDeleteFromAssignment";
            this.btnDeleteFromAssignment.Size = new System.Drawing.Size(204, 49);
            this.btnDeleteFromAssignment.TabIndex = 12;
            this.btnDeleteFromAssignment.Text = "zugeordnete REFA-Arbeitswerte aus Produktiv-Site l�schen";
            //
            //btnNewWorkGroup
            //
            this.btnNewWorkGroup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewWorkGroup.Location = new System.Drawing.Point(22, 18);
            this.btnNewWorkGroup.Name = "btnNewWorkGroup";
            this.btnNewWorkGroup.Size = new System.Drawing.Size(204, 49);
            this.btnNewWorkGroup.TabIndex = 13;
            this.btnNewWorkGroup.Text = "Neue Produktiv-Site erstellen...";
            //
            //btnAssignToWorkGroup
            //
            this.btnAssignToWorkGroup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAssignToWorkGroup.Enabled = false;
            this.btnAssignToWorkGroup.Location = new System.Drawing.Point(22, 100);
            this.btnAssignToWorkGroup.Name = "btnAssignToWorkGroup";
            this.btnAssignToWorkGroup.Size = new System.Drawing.Size(204, 49);
            this.btnAssignToWorkGroup.TabIndex = 11;
            this.btnAssignToWorkGroup.Text = "ausgew�hlte REFA-Arbeitswerte zur selektierten Produktiv-Site hinzuf�gen";
            //
            //splitWorkGroupsAssignments
            //
            this.splitWorkGroupsAssignments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitWorkGroupsAssignments.Location = new System.Drawing.Point(0, 0);
            this.splitWorkGroupsAssignments.Name = "splitWorkGroupsAssignments";
            //
            //splitWorkGroupsAssignments.Panel1
            //
            this.splitWorkGroupsAssignments.Panel1.Controls.Add(this.wglSetup);
            this.splitWorkGroupsAssignments.Panel1.Controls.Add(this.Label2);
            //
            //splitWorkGroupsAssignments.Panel2
            //
            this.splitWorkGroupsAssignments.Panel2.Controls.Add(this.lvlAssigned);
            this.splitWorkGroupsAssignments.Panel2.Controls.Add(this.lblSelectedWorkgroup);
            this.splitWorkGroupsAssignments.Panel2.Controls.Add(this.Label3);
            this.splitWorkGroupsAssignments.Size = new System.Drawing.Size(865, 300);
            this.splitWorkGroupsAssignments.SplitterDistance = 351;
            this.splitWorkGroupsAssignments.TabIndex = 0;
            this.splitWorkGroupsAssignments.Text = "SplitContainer2";
            //
            //wglSetup
            //
            this.wglSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.wglSetup.AutoGroup = false;
            this.wglSetup.FullRowSelect = true;
            this.wglSetup.HideSelection = false;
            this.wglSetup.Location = new System.Drawing.Point(4, 21);
            this.wglSetup.Name = "wglSetup";
            this.wglSetup.OnlyActiveWorkgroups = false;
            this.wglSetup.Size = new System.Drawing.Size(344, 273);
            this.wglSetup.TabIndex = 2;
            this.wglSetup.UseCompatibleStateImageBehavior = false;
            this.wglSetup.View = System.Windows.Forms.View.Details;
            this.wglSetup.WorkGroupInfoItems = null;
            this.wglSetup.WorkGroupSortOrder = Facesso.GenericControls.WorkGroupSortOrder.WorkGroupNumber;
            //
            //Label2
            //
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label2.Location = new System.Drawing.Point(6, 4);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(176, 13);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Eingerichtete Produktiv-Sites:";
            //
            //lvlAssigned
            //
            this.lvlAssigned.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.lvlAssigned.AutoGroup = false;
            this.lvlAssigned.FullRowSelect = true;
            this.lvlAssigned.HideSelection = false;
            this.lvlAssigned.LabourValues = null;
            this.lvlAssigned.LabourValueSortOrder = Facesso.GenericControls.LabourValuesSortOrder.LabourValueNumber;
            this.lvlAssigned.Location = new System.Drawing.Point(3, 48);
            this.lvlAssigned.Name = "lvlAssigned";
            this.lvlAssigned.Size = new System.Drawing.Size(504, 247);
            this.lvlAssigned.TabIndex = 4;
            this.lvlAssigned.UseCompatibleStateImageBehavior = false;
            this.lvlAssigned.View = System.Windows.Forms.View.Details;
            //
            //lblSelectedWorkgroup
            //
            this.lblSelectedWorkgroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.lblSelectedWorkgroup.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSelectedWorkgroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblSelectedWorkgroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSelectedWorkgroup.Location = new System.Drawing.Point(3, 22);
            this.lblSelectedWorkgroup.Name = "lblSelectedWorkgroup";
            this.lblSelectedWorkgroup.Size = new System.Drawing.Size(504, 25);
            this.lblSelectedWorkgroup.TabIndex = 3;
            this.lblSelectedWorkgroup.Text = "- keine Produktiv-Site ausgew�hlt -";
            this.lblSelectedWorkgroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //Label3
            //
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label3.Location = new System.Drawing.Point(3, 4);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(263, 13);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Der Produktiv-Site zugeordnete Arbeitswerte:";
            //
            //ToolStrip1
            //
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsbNewWorkgroup, this.tsbEditWorkgroup, this.tsbDeleteWorkgroup, this.ToolStripSeparator3, this.tsbPrintWorkGroupList, this.ToolStripSeparator4, this.tsbAssignLabourValues, this.tsbUnassignLabourValues });
            this.ToolStrip1.Location = new System.Drawing.Point(3, 24);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(162, 25);
            this.ToolStrip1.TabIndex = 0;
            this.ToolStrip1.Text = "ToolStrip1";
            //
            //tsbNewWorkgroup
            //
            this.tsbNewWorkgroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewWorkgroup.Image = ((System.Drawing.Image)resources.GetObject("tsbNewWorkgroup.Image"));
            this.tsbNewWorkgroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewWorkgroup.Name = "tsbNewWorkgroup";
            this.tsbNewWorkgroup.Size = new System.Drawing.Size(23, 22);
            this.tsbNewWorkgroup.Text = "Neue Produktiv-Site";
            //
            //tsbEditWorkgroup
            //
            this.tsbEditWorkgroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditWorkgroup.Image = ((System.Drawing.Image)resources.GetObject("tsbEditWorkgroup.Image"));
            this.tsbEditWorkgroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditWorkgroup.Name = "tsbEditWorkgroup";
            this.tsbEditWorkgroup.Size = new System.Drawing.Size(23, 22);
            this.tsbEditWorkgroup.Text = "Produktiv-Site-Daten bearbeiten";
            //
            //tsbDeleteWorkgroup
            //
            this.tsbDeleteWorkgroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteWorkgroup.Image = ((System.Drawing.Image)resources.GetObject("tsbDeleteWorkgroup.Image"));
            this.tsbDeleteWorkgroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteWorkgroup.Name = "tsbDeleteWorkgroup";
            this.tsbDeleteWorkgroup.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteWorkgroup.Text = "Produktiv-Site l�schen";
            //
            //ToolStripSeparator3
            //
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            //
            //tsbPrintWorkGroupList
            //
            this.tsbPrintWorkGroupList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrintWorkGroupList.Image = ((System.Drawing.Image)resources.GetObject("tsbPrintWorkGroupList.Image"));
            this.tsbPrintWorkGroupList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrintWorkGroupList.Name = "tsbPrintWorkGroupList";
            this.tsbPrintWorkGroupList.Size = new System.Drawing.Size(23, 22);
            this.tsbPrintWorkGroupList.Text = "Print Workgroup List";
            //
            //ToolStripSeparator4
            //
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            //
            //tsbAssignLabourValues
            //
            this.tsbAssignLabourValues.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAssignLabourValues.Image = ((System.Drawing.Image)resources.GetObject("tsbAssignLabourValues.Image"));
            this.tsbAssignLabourValues.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAssignLabourValues.Name = "tsbAssignLabourValues";
            this.tsbAssignLabourValues.Size = new System.Drawing.Size(23, 22);
            this.tsbAssignLabourValues.Text = "Arbeitswerte zuordnen";
            //
            //tsbUnassignLabourValues
            //
            this.tsbUnassignLabourValues.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUnassignLabourValues.Image = ((System.Drawing.Image)resources.GetObject("tsbUnassignLabourValues.Image"));
            this.tsbUnassignLabourValues.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUnassignLabourValues.Name = "tsbUnassignLabourValues";
            this.tsbUnassignLabourValues.Size = new System.Drawing.Size(23, 22);
            this.tsbUnassignLabourValues.Text = "Arbeitswertzuordnung aufheben";
            //
            //frmWorkGroupManager
            //
            this.ClientSize = new System.Drawing.Size(865, 626);
            this.Controls.Add(this.ToolStripContainer1);
            this.MainMenuStrip = this.MenuStrip1;
            this.MinimumSize = new System.Drawing.Size(630, 440);
            this.Name = "frmWorkGroupManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Produktiv-Sites-Manager";
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.ToolStripContainer1.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer1.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer1.ResumeLayout(false);
            this.ToolStripContainer1.PerformLayout();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.ResumeLayout(false);
            this.splitLabourValuesQuickButtons.Panel1.ResumeLayout(false);
            this.splitLabourValuesQuickButtons.Panel1.PerformLayout();
            this.splitLabourValuesQuickButtons.Panel2.ResumeLayout(false);
            this.splitLabourValuesQuickButtons.ResumeLayout(false);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.splitWorkGroupsAssignments.Panel1.ResumeLayout(false);
            this.splitWorkGroupsAssignments.Panel1.PerformLayout();
            this.splitWorkGroupsAssignments.Panel2.ResumeLayout(false);
            this.splitWorkGroupsAssignments.Panel2.PerformLayout();
            this.splitWorkGroupsAssignments.ResumeLayout(false);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripContainer ToolStripContainer1;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripMenuItem ProduktivSitesToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem tsmNewWorkgroup;

        internal System.Windows.Forms.ToolStripMenuItem tsmDeleteWorkgroup;

        internal System.Windows.Forms.ToolStripMenuItem tsmOK;

        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.SplitContainer splitWorkGroupsAssignments;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label lblSelectedWorkgroup;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.SplitContainer splitLabourValuesQuickButtons;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Button btnDeleteFromAssignment;

        internal System.Windows.Forms.Button btnNewWorkGroup;

        internal System.Windows.Forms.Button btnAssignToWorkGroup;

        internal Facesso.GenericControls.ucLabourValueListView lvlToAssign;

        internal Facesso.GenericControls.ucWorkGroupListView wglSetup;

        internal Facesso.GenericControls.ucLabourValueListView lvlAssigned;

        internal System.Windows.Forms.ToolStripButton tsbNewWorkgroup;

        internal System.Windows.Forms.ToolStripButton tsbEditWorkgroup;

        internal System.Windows.Forms.ToolStripMenuItem AnsichtToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem tsmShowQuickStartButtons;

        internal System.Windows.Forms.ToolStripMenuItem tsmGroupLabourValues;

        internal System.Windows.Forms.ToolStripMenuItem tsmEditWorkgroupData;

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripMenuItem tsmAssignLabourValues;

        internal System.Windows.Forms.ToolStripMenuItem tsmUnAssignLabourValues;

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStripMenuItem tsmGreyUsedLabourValues;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem3;
        internal System.Windows.Forms.ToolStripMenuItem tsmPrintWorkGroup;

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        internal System.Windows.Forms.ToolStripButton tsbPrintWorkGroupList;

        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
        internal System.Windows.Forms.ToolStripButton tsbAssignLabourValues;

        internal System.Windows.Forms.ToolStripButton tsbUnassignLabourValues;

        internal System.Windows.Forms.ToolStripButton tsbDeleteWorkgroup;
    }
}