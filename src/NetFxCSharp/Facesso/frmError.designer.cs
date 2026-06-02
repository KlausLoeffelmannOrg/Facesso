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

namespace Facesso
{
    public partial class frmError : Form
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
            this.Label1 = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.Button1.Click += Button1_Click;
            this.txtExceptionMessage = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblExceptionText = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            //Label1
            //
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label1.Location = new System.Drawing.Point(12, 13);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(600, 38);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Bei der Programmausführung gab es Unregelmäßigkeiten und Facesso meldet die folge" + "nde Ausnahme:";
            //
            //Button1
            //
            this.Button1.Location = new System.Drawing.Point(451, 448);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(161, 28);
            this.Button1.TabIndex = 4;
            this.Button1.Text = "Programm beenden";
            //
            //txtExceptionMessage
            //
            this.txtExceptionMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.txtExceptionMessage.Location = new System.Drawing.Point(12, 139);
            this.txtExceptionMessage.Multiline = true;
            this.txtExceptionMessage.Name = "txtExceptionMessage";
            this.txtExceptionMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExceptionMessage.Size = new System.Drawing.Size(600, 283);
            this.txtExceptionMessage.TabIndex = 5;
            //
            //Label2
            //
            this.Label2.Location = new System.Drawing.Point(12, 445);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(402, 34);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Bitte kopieren Sie die Texte in die Zwischenablage, drucken Sie ihn aus, und faxe" + "n Sie sie an: +49 2941 910908";
            //
            //lblExceptionText
            //
            this.lblExceptionText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.lblExceptionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblExceptionText.Location = new System.Drawing.Point(12, 51);
            this.lblExceptionText.Name = "lblExceptionText";
            this.lblExceptionText.Size = new System.Drawing.Size(600, 61);
            this.lblExceptionText.TabIndex = 7;
            //
            //Label4
            //
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(12, 123);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(42, 13);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Details:";
            //
            //frmError
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 488);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.lblExceptionText);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtExceptionMessage);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "!!!Während der Programmausführung trat ein Fehler auf:";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button Button1;

        internal System.Windows.Forms.TextBox txtExceptionMessage;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label lblExceptionText;
        internal System.Windows.Forms.Label Label4;
    }
}