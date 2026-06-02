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
    public partial class frmBonuslistMaintenance : frmBaseFacesso
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
            this.lstCostCenter = new System.Windows.Forms.ListBox();
            this.lstCostCenter.SelectedIndexChanged += lstCostCenter_SelectedIndexChanged;
            this.Label1 = new System.Windows.Forms.Label();
            this.NewCostcenterTable = new System.Windows.Forms.Button();
            this.NewCostcenterTable.Click += NewCostcenterTable_Click;
            this.btnDeleteCostCenterTable = new System.Windows.Forms.Button();
            this.btnDeleteCostCenterTable.Click += btnDeleteCostCenterTable_Click;
            this.dgvWageTable = new System.Windows.Forms.DataGridView();
            this.dgvWageTable.DataError += dgvWageTable_DataError;
            this.dgvWageTable.CellValueChanged += dgvWageTable_CellValueChanged;
            this.Label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)this.dgvWageTable).BeginInit();
            this.SuspendLayout();
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(405, 34);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(207, 35);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            //
            //lstCostCenter
            //
            this.lstCostCenter.FormattingEnabled = true;
            this.lstCostCenter.ItemHeight = 16;
            this.lstCostCenter.Location = new System.Drawing.Point(14, 34);
            this.lstCostCenter.Margin = new System.Windows.Forms.Padding(4);
            this.lstCostCenter.Name = "lstCostCenter";
            this.lstCostCenter.Size = new System.Drawing.Size(383, 148);
            this.lstCostCenter.TabIndex = 1;
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(13, 14);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(269, 16);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Kostenstellen, f�r die Lohntabellen existieren:";
            //
            //NewCostcenterTable
            //
            this.NewCostcenterTable.Location = new System.Drawing.Point(406, 117);
            this.NewCostcenterTable.Margin = new System.Windows.Forms.Padding(4);
            this.NewCostcenterTable.Name = "NewCostcenterTable";
            this.NewCostcenterTable.Size = new System.Drawing.Size(207, 28);
            this.NewCostcenterTable.TabIndex = 3;
            this.NewCostcenterTable.Text = "Neue Kostenstellentabelle";
            //
            //btnDeleteCostCenterTable
            //
            this.btnDeleteCostCenterTable.Location = new System.Drawing.Point(406, 153);
            this.btnDeleteCostCenterTable.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteCostCenterTable.Name = "btnDeleteCostCenterTable";
            this.btnDeleteCostCenterTable.Size = new System.Drawing.Size(207, 28);
            this.btnDeleteCostCenterTable.TabIndex = 4;
            this.btnDeleteCostCenterTable.Text = "Kostenstellentabelle l�schen";
            //
            //dgvWageTable
            //
            this.dgvWageTable.Location = new System.Drawing.Point(13, 219);
            this.dgvWageTable.Name = "dgvWageTable";
            this.dgvWageTable.Size = new System.Drawing.Size(599, 271);
            this.dgvWageTable.TabIndex = 5;
            this.dgvWageTable.Text = "DataGridView1";
            //
            //Label2
            //
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(13, 200);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(249, 16);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Lohntabelle f�r ausgew�hlte Kostenstelle:";
            //
            //frmBonuslistMaintenance
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 508);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.dgvWageTable);
            this.Controls.Add(this.btnDeleteCostCenterTable);
            this.Controls.Add(this.NewCostcenterTable);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lstCostCenter);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBonuslistMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lohntabellenverwaltung";
            ((System.ComponentModel.ISupportInitialize)this.dgvWageTable).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.Button btnOK;

        internal System.Windows.Forms.ListBox lstCostCenter;

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button NewCostcenterTable;

        internal System.Windows.Forms.Button btnDeleteCostCenterTable;

        internal System.Windows.Forms.DataGridView dgvWageTable;

        internal System.Windows.Forms.Label Label2;
    }
}