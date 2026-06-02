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
    public partial class frmAssignTimeSettingsToWorkgroups : frmBaseFacesso
    {
        //Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        //Wird vom Windows Form-Designer benötigt.
        private System.ComponentModel.IContainer components;
        //Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
        //Das Bearbeiten ist mit dem Windows Form-Designer möglich.
        //Das Bearbeiten mit dem Code-Editor ist nicht möglich.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btnOK.Click += btnOK_Click;
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCancel.Click += btnCancel_Click;
            this.wglWorkGroups = new Facesso.GenericControls.ucWorkGroupListView();
            this.SuspendLayout();
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(576, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(125, 39);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(576, 57);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 39);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            //wglWorkGroups
            //
            this.wglWorkGroups.AutoGroup = true;
            this.wglWorkGroups.FullRowSelect = true;
            this.wglWorkGroups.HideSelection = false;
            this.wglWorkGroups.Location = new System.Drawing.Point(7, 12);
            this.wglWorkGroups.Name = "wglWorkGroups";
            this.wglWorkGroups.OnlyActiveWorkgroups = true;
            this.wglWorkGroups.Size = new System.Drawing.Size(554, 304);
            this.wglWorkGroups.TabIndex = 3;
            this.wglWorkGroups.View = System.Windows.Forms.View.Details;
            this.wglWorkGroups.WorkGroupInfoItems = null;
            this.wglWorkGroups.WorkGroupSortOrder = Facesso.GenericControls.WorkGroupSortOrder.WorkGroupNumber;
            //
            //frmAssignTimeSettingsToWorkgroups
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 328);
            this.Controls.Add(this.wglWorkGroups);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAssignTimeSettingsToWorkgroups";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Globale Arbeitszeiteinstellungen Produktiv-Sites zuweisen";
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.Button btnOK;

        internal System.Windows.Forms.Button btnCancel;

        internal Facesso.GenericControls.ucWorkGroupListView wglWorkGroups;
    }
}