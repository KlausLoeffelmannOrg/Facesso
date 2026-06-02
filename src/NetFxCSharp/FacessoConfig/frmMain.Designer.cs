using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FacessoConfig
{
    public partial class frmMain : System.Windows.Forms.Form
    {
        //Form overrides dispose to clean up the component list.
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

        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.btnActivateFacesso = new System.Windows.Forms.Button();
            this.btnActivateFacesso.Click += btnActivateFacesso_Click;
            this.btnSetupDatabase = new System.Windows.Forms.Button();
            this.btnSetupDatabase.Click += btnSetupDatabase_Click;
            this.btnSetDatabaseInstance = new System.Windows.Forms.Button();
            this.btnSetDatabaseInstance.Click += btnSetDatabaseInstance_Click;
            this.btnUpdateSchema = new System.Windows.Forms.Button();
            this.btnUpdateSchema.Click += btnUpdateSchema_Click;
            this.SuspendLayout();
            //
            //btnActivateFacesso
            //
            this.btnActivateFacesso.Location = new System.Drawing.Point(75, 12);
            this.btnActivateFacesso.Name = "btnActivateFacesso";
            this.btnActivateFacesso.Size = new System.Drawing.Size(335, 67);
            this.btnActivateFacesso.TabIndex = 0;
            this.btnActivateFacesso.Text = "Facesso neu aktivieren.";
            this.btnActivateFacesso.UseVisualStyleBackColor = true;
            //
            //btnSetupDatabase
            //
            this.btnSetupDatabase.Location = new System.Drawing.Point(75, 85);
            this.btnSetupDatabase.Name = "btnSetupDatabase";
            this.btnSetupDatabase.Size = new System.Drawing.Size(335, 67);
            this.btnSetupDatabase.TabIndex = 1;
            this.btnSetupDatabase.Text = "Datenbank neu einrichten.";
            this.btnSetupDatabase.UseVisualStyleBackColor = true;
            //
            //btnSetDatabaseInstance
            //
            this.btnSetDatabaseInstance.Location = new System.Drawing.Point(75, 158);
            this.btnSetDatabaseInstance.Name = "btnSetDatabaseInstance";
            this.btnSetDatabaseInstance.Size = new System.Drawing.Size(335, 67);
            this.btnSetDatabaseInstance.TabIndex = 2;
            this.btnSetDatabaseInstance.Text = "Datenbank-Instanz neu festlegen.";
            this.btnSetDatabaseInstance.UseVisualStyleBackColor = true;
            //
            //btnUpdateSchema
            //
            this.btnUpdateSchema.Location = new System.Drawing.Point(75, 231);
            this.btnUpdateSchema.Name = "btnUpdateSchema";
            this.btnUpdateSchema.Size = new System.Drawing.Size(335, 67);
            this.btnUpdateSchema.TabIndex = 3;
            this.btnUpdateSchema.Text = "Schema-Update durchführen.";
            this.btnUpdateSchema.UseVisualStyleBackColor = true;
            //
            //frmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 312);
            this.Controls.Add(this.btnUpdateSchema);
            this.Controls.Add(this.btnSetDatabaseInstance);
            this.Controls.Add(this.btnSetupDatabase);
            this.Controls.Add(this.btnActivateFacesso);
            this.Name = "frmMain";
            this.Text = "Facesso Konfigurationswerkzeug";
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.Button btnActivateFacesso;

        internal System.Windows.Forms.Button btnSetupDatabase;

        internal System.Windows.Forms.Button btnSetDatabaseInstance;

        internal System.Windows.Forms.Button btnUpdateSchema;
    }
}