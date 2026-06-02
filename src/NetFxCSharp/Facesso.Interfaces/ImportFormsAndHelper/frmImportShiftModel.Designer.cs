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
    public partial class frmImportShiftModel : System.Windows.Forms.Form
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
            this.UcTimeDetailsSettings1 = new Facesso.GenericControls.ucTimeDetailsSettings();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            //UcTimeDetailsSettings1
            //
            this.UcTimeDetailsSettings1.CurrentlyDisplayedShift = 1;
            this.UcTimeDetailsSettings1.CurrentlyDisplayedWeekday = Facesso.TimeSettingDetailsWeekdays.ForAll;
            this.UcTimeDetailsSettings1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.UcTimeDetailsSettings1.Location = new System.Drawing.Point(13, 13);
            this.UcTimeDetailsSettings1.Margin = new System.Windows.Forms.Padding(4);
            this.UcTimeDetailsSettings1.Name = "UcTimeDetailsSettings1";
            this.UcTimeDetailsSettings1.Size = new System.Drawing.Size(558, 458);
            this.UcTimeDetailsSettings1.TabIndex = 0;
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(348, 478);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(103, 34);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //btnCancel
            //
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(457, 478);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 34);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            //frmImportShiftModel
            //
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(577, 525);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.UcTimeDetailsSettings1);
            this.Name = "frmImportShiftModel";
            this.Text = "Schichtmodell für den Datenimport bearbeiten";
            this.ResumeLayout(false);
        }

        internal Facesso.GenericControls.ucTimeDetailsSettings UcTimeDetailsSettings1;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnCancel;
    }
}