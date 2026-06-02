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
    public partial class frmHandicapRangeManager : frmBaseFacesso
    {
        //Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

        //Wird vom Windows Form-Designer benötigt.
        private System.ComponentModel.IContainer components;
        //Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
        //Das Bearbeiten ist mit dem Windows Form-Designer möglich.
        //Das Bearbeiten mit dem Code-Editor ist nicht möglich.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.btnOk.Click += btnOk_Click;
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCancel.Click += btnCancel_Click;
            this.ListView1 = new System.Windows.Forms.ListView();
            this.ListView1.SelectedIndexChanged += ListView1_SelectedIndexChanged;
            this.ListView1.DoubleClick += ListView1_DoubleClick;
            this.ColumnValidFrom = new System.Windows.Forms.ColumnHeader();
            this.ColumnHandicap = new System.Windows.Forms.ColumnHeader();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnNew.Click += btnNew_Click;
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnEdit.Click += btnEdit_Click;
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDelete.Click += btnDelete_Click;
            this.lblEmployee = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            //btnOk
            //
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnOk.Location = new System.Drawing.Point(216, 276);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(81, 27);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            //
            //btnCancel
            //
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(303, 276);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            //ListView1
            //
            this.ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnValidFrom, this.ColumnHandicap });
            this.ListView1.FullRowSelect = true;
            this.ListView1.Location = new System.Drawing.Point(12, 54);
            this.ListView1.Name = "ListView1";
            this.ListView1.Size = new System.Drawing.Size(273, 200);
            this.ListView1.TabIndex = 2;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.View = System.Windows.Forms.View.Details;
            //
            //ColumnValidFrom
            //
            this.ColumnValidFrom.Text = "Gültig von";
            this.ColumnValidFrom.Width = 100;
            //
            //ColumnHandicap
            //
            this.ColumnHandicap.Text = "Handicap";
            this.ColumnHandicap.Width = 165;
            //
            //btnNew
            //
            this.btnNew.Location = new System.Drawing.Point(291, 53);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(65, 23);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "Neu...";
            this.btnNew.UseVisualStyleBackColor = true;
            //
            //btnEdit
            //
            this.btnEdit.Location = new System.Drawing.Point(291, 82);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(65, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Editieren...";
            this.btnEdit.UseVisualStyleBackColor = true;
            //
            //btnDelete
            //
            this.btnDelete.Location = new System.Drawing.Point(291, 111);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Löschen...";
            this.btnDelete.UseVisualStyleBackColor = true;
            //
            //lblEmployee
            //
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(13, 13);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(22, 13);
            this.lblEmployee.TabIndex = 6;
            this.lblEmployee.Text = ".....";
            //
            //frmHandicapRangeManager
            //
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(396, 315);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.ListView1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "frmHandicapRangeManager";
            this.Text = "Handicap-Vorgaben für Mitarbeiter verwalten";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.Button btnOk;

        internal System.Windows.Forms.Button btnCancel;

        internal System.Windows.Forms.ListView ListView1;

        internal System.Windows.Forms.Button btnNew;

        internal System.Windows.Forms.Button btnEdit;

        internal System.Windows.Forms.Button btnDelete;

        internal System.Windows.Forms.ColumnHeader ColumnValidFrom;
        internal System.Windows.Forms.ColumnHeader ColumnHandicap;
        internal System.Windows.Forms.Label lblEmployee;
    }
}