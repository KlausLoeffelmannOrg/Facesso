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
    public partial class frmLegatroTimeDataConfigDialog : System.Windows.Forms.Form
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAdd.Click += btnAdd_Click;
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRemove.Click += btnRemove_Click;
            this.tvwAssignments = new System.Windows.Forms.TreeView();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtSqlConnectionString = new System.Windows.Forms.TextBox();
            this.btnSelectSqlConnection = new System.Windows.Forms.Button();
            this.btnSelectSqlConnection.Click += btnSelectSqlConnection_Click;
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lvwLegatroWorksitesOrProjects = new System.Windows.Forms.ListView();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            //btnAdd
            //
            this.btnAdd.Location = new System.Drawing.Point(296, 229);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 36);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = ">> dazu";
            this.btnAdd.UseVisualStyleBackColor = true;
            //
            //btnRemove
            //
            this.btnRemove.Location = new System.Drawing.Point(296, 271);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(76, 36);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "<< entfernen";
            this.btnRemove.UseVisualStyleBackColor = true;
            //
            //tvwAssignments
            //
            this.tvwAssignments.Location = new System.Drawing.Point(382, 112);
            this.tvwAssignments.Name = "tvwAssignments";
            this.tvwAssignments.Size = new System.Drawing.Size(270, 396);
            this.tvwAssignments.TabIndex = 3;
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(176, 13);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Verbindung zur Legatro-Datenbank:";
            //
            //txtSqlConnectionString
            //
            this.txtSqlConnectionString.Location = new System.Drawing.Point(12, 25);
            this.txtSqlConnectionString.Multiline = true;
            this.txtSqlConnectionString.Name = "txtSqlConnectionString";
            this.txtSqlConnectionString.ReadOnly = true;
            this.txtSqlConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSqlConnectionString.Size = new System.Drawing.Size(592, 52);
            this.txtSqlConnectionString.TabIndex = 5;
            //
            //btnSelectSqlConnection
            //
            this.btnSelectSqlConnection.Location = new System.Drawing.Point(610, 45);
            this.btnSelectSqlConnection.Name = "btnSelectSqlConnection";
            this.btnSelectSqlConnection.Size = new System.Drawing.Size(42, 32);
            this.btnSelectSqlConnection.TabIndex = 6;
            this.btnSelectSqlConnection.Text = "...";
            this.btnSelectSqlConnection.UseVisualStyleBackColor = true;
            //
            //btnOK
            //
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(488, 518);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 32);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //btnCancel
            //
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(573, 518);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 32);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            //lvwLegatroWorksitesOrProjects
            //
            this.lvwLegatroWorksitesOrProjects.FullRowSelect = true;
            this.lvwLegatroWorksitesOrProjects.HideSelection = false;
            this.lvwLegatroWorksitesOrProjects.Location = new System.Drawing.Point(12, 110);
            this.lvwLegatroWorksitesOrProjects.Name = "lvwLegatroWorksitesOrProjects";
            this.lvwLegatroWorksitesOrProjects.Size = new System.Drawing.Size(278, 398);
            this.lvwLegatroWorksitesOrProjects.TabIndex = 9;
            this.lvwLegatroWorksitesOrProjects.UseCompatibleStateImageBehavior = false;
            this.lvwLegatroWorksitesOrProjects.View = System.Windows.Forms.View.Details;
            //
            //Label2
            //
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 94);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(120, 13);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "Arbeitsplätze in Legatro:";
            //
            //Label3
            //
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(295, 94);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(78, 13);
            this.Label3.TabIndex = 11;
            this.Label3.Text = "zugewiesen an";
            //
            //Label4
            //
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(379, 94);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(135, 13);
            this.Label4.TabIndex = 12;
            this.Label4.Text = "Produktiv-Sites in Facesso:";
            //
            //frmLegatroTimeDataConfigDialog
            //
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(664, 562);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.lvwLegatroWorksitesOrProjects);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSelectSqlConnection);
            this.Controls.Add(this.txtSqlConnectionString);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.tvwAssignments);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmLegatroTimeDataConfigDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Legatro Datenübernahmeeinstellungen:";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.Button btnAdd;

        internal System.Windows.Forms.Button btnRemove;

        internal System.Windows.Forms.TreeView tvwAssignments;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtSqlConnectionString;
        internal System.Windows.Forms.Button btnSelectSqlConnection;

        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.ListView lvwLegatroWorksitesOrProjects;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
    }
}