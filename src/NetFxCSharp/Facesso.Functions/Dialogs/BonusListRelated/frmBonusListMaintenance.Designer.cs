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
            this.lstCostCenter = new System.Windows.Forms.ListBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.NewCostcenterTable = new System.Windows.Forms.Button();
            this.btnDeleteCostCenterTable = new System.Windows.Forms.Button();
            this.dgvWageTable = new System.Windows.Forms.DataGridView();
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

        private System.Windows.Forms.Button _btnOK;
        internal System.Windows.Forms.Button btnOK
        {
            get
            {
                return _btnOK;
            }

            set
            {
                if (_btnOK != null)
                {
                    _btnOK.Click -= btnOK_Click;
                }

                _btnOK = value;
                if (_btnOK != null)
                {
                    _btnOK.Click += btnOK_Click;
                }
            }
        }

        private System.Windows.Forms.ListBox _lstCostCenter;
        internal System.Windows.Forms.ListBox lstCostCenter
        {
            get
            {
                return _lstCostCenter;
            }

            set
            {
                if (_lstCostCenter != null)
                {
                    _lstCostCenter.SelectedIndexChanged -= lstCostCenter_SelectedIndexChanged;
                }

                _lstCostCenter = value;
                if (_lstCostCenter != null)
                {
                    _lstCostCenter.SelectedIndexChanged += lstCostCenter_SelectedIndexChanged;
                }
            }
        }

        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button _NewCostcenterTable;
        internal System.Windows.Forms.Button NewCostcenterTable
        {
            get
            {
                return _NewCostcenterTable;
            }

            set
            {
                if (_NewCostcenterTable != null)
                {
                    _NewCostcenterTable.Click -= NewCostcenterTable_Click;
                }

                _NewCostcenterTable = value;
                if (_NewCostcenterTable != null)
                {
                    _NewCostcenterTable.Click += NewCostcenterTable_Click;
                }
            }
        }

        private System.Windows.Forms.Button _btnDeleteCostCenterTable;
        internal System.Windows.Forms.Button btnDeleteCostCenterTable
        {
            get
            {
                return _btnDeleteCostCenterTable;
            }

            set
            {
                if (_btnDeleteCostCenterTable != null)
                {
                    _btnDeleteCostCenterTable.Click -= btnDeleteCostCenterTable_Click;
                }

                _btnDeleteCostCenterTable = value;
                if (_btnDeleteCostCenterTable != null)
                {
                    _btnDeleteCostCenterTable.Click += btnDeleteCostCenterTable_Click;
                }
            }
        }

        private System.Windows.Forms.DataGridView _dgvWageTable;
        internal System.Windows.Forms.DataGridView dgvWageTable
        {
            get
            {
                return _dgvWageTable;
            }

            set
            {
                if (_dgvWageTable != null)
                {
                    _dgvWageTable.DataError -= dgvWageTable_DataError;
                    _dgvWageTable.CellValueChanged -= dgvWageTable_CellValueChanged;
                }

                _dgvWageTable = value;
                if (_dgvWageTable != null)
                {
                    _dgvWageTable.DataError += dgvWageTable_DataError;
                    _dgvWageTable.CellValueChanged += dgvWageTable_CellValueChanged;
                }
            }
        }

        internal System.Windows.Forms.Label Label2;
    }
}