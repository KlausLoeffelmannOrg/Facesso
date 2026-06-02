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
    public partial class frmEmployeePicker : frmBaseFacesso
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
            this.ucEmployeePicker = new Facesso.GenericControls.ucEmployeePicker();
            this.SuspendLayout();
            //
            //ucEmployeePicker
            //
            this.ucEmployeePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEmployeePicker.Employees = null;
            this.ucEmployeePicker.Location = new System.Drawing.Point(0, 0);
            this.ucEmployeePicker.Name = "ucEmployeePicker";
            this.ucEmployeePicker.Size = new System.Drawing.Size(392, 374);
            this.ucEmployeePicker.TabIndex = 0;
            //
            //frmEmployeePicker
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 374);
            this.Controls.Add(this.ucEmployeePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmEmployeePicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mitarbeiter ausw�hlen:";
            this.ResumeLayout(false);
        }

        internal Facesso.GenericControls.ucEmployeePicker ucEmployeePicker;
    }
}