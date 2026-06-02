using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Facesso.Interfaces
{
    public partial class frmNewImportTask : System.Windows.Forms.Form
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnOK.Click += btnOK_Click;
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCancel.Click += btnCancel_Click;
            this.lvwTaskTemplates = new System.Windows.Forms.ListView();
            this.lvwTaskTemplates.SelectedIndexChanged += lvwTaskTemplates_SelectedIndexChanged;
            this.lvwDeviceClasses = new System.Windows.Forms.ListView();
            this.lvwDeviceClasses.SelectedIndexChanged += lvwDeviceClasses_SelectedIndexChanged;
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.TableLayoutPanel1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            //
            //btnOK
            //
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(532, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(102, 32);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //btnCancel
            //
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnCancel.Location = new System.Drawing.Point(532, 53);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            //lvwTaskTemplates
            //
            this.lvwTaskTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwTaskTemplates.GridLines = true;
            this.lvwTaskTemplates.Location = new System.Drawing.Point(3, 16);
            this.lvwTaskTemplates.MultiSelect = false;
            this.lvwTaskTemplates.Name = "lvwTaskTemplates";
            this.lvwTaskTemplates.Size = new System.Drawing.Size(245, 318);
            this.lvwTaskTemplates.TabIndex = 3;
            this.lvwTaskTemplates.View = System.Windows.Forms.View.Details;
            //
            //lvwDeviceClasses
            //
            this.lvwDeviceClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDeviceClasses.GridLines = true;
            this.lvwDeviceClasses.Location = new System.Drawing.Point(3, 16);
            this.lvwDeviceClasses.MultiSelect = false;
            this.lvwDeviceClasses.Name = "lvwDeviceClasses";
            this.lvwDeviceClasses.Size = new System.Drawing.Size(245, 318);
            this.lvwDeviceClasses.TabIndex = 5;
            this.lvwDeviceClasses.View = System.Windows.Forms.View.Details;
            //
            //TableLayoutPanel1
            //
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
            this.TableLayoutPanel1.Controls.Add(this.GroupBox1, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.GroupBox2, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(514, 343);
            this.TableLayoutPanel1.TabIndex = 7;
            //
            //GroupBox1
            //
            this.GroupBox1.Controls.Add(this.lvwTaskTemplates);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.Location = new System.Drawing.Point(3, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(251, 337);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Task-Vorlagen";
            //
            //GroupBox2
            //
            this.GroupBox2.Controls.Add(this.lvwDeviceClasses);
            this.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox2.Location = new System.Drawing.Point(260, 3);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(251, 337);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Geräteklassen für ausgewählte Taskvorlagen";
            //
            //frmNewImportTask
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 367);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "frmNewImportTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Neuer Import-Task";
            this.TableLayoutPanel1.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.Button btnOK;

        internal System.Windows.Forms.Button btnCancel;

        internal System.Windows.Forms.ListView lvwTaskTemplates;

        internal System.Windows.Forms.ListView lvwDeviceClasses;

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.GroupBox GroupBox2;
    }
}