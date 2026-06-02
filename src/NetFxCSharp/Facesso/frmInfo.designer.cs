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
    public partial class frmInfo : Facesso.GenericControls.frmBaseFacesso
    {
        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!((components == null)))
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        internal System.Windows.Forms.Label Copyright;
        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfo));
            this.Copyright = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Version = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblSerial = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lblExpiresOn = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            //
            //Copyright
            //
            this.Copyright.BackColor = System.Drawing.Color.Transparent;
            this.Copyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Copyright.Location = new System.Drawing.Point(248, 277);
            this.Copyright.Name = "Copyright";
            this.Copyright.Size = new System.Drawing.Size(364, 40);
            this.Copyright.TabIndex = 2;
            this.Copyright.Text = "Copyright";
            //
            //PictureBox1
            //
            this.PictureBox1.Image = ((System.Drawing.Image)resources.GetObject("PictureBox1.Image"));
            this.PictureBox1.InitialImage = null;
            this.PictureBox1.Location = new System.Drawing.Point(9, 33);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(600, 190);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox1.TabIndex = 2;
            this.PictureBox1.TabStop = false;
            //
            //Version
            //
            this.Version.BackColor = System.Drawing.Color.Transparent;
            this.Version.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Version.Location = new System.Drawing.Point(12, 277);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(241, 20);
            this.Version.TabIndex = 3;
            this.Version.Text = "Version {0}.{1:00}.{2:0}.{3:00}";
            //
            //btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(444, 442);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(167, 36);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //lblSerial
            //
            this.lblSerial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblSerial.Location = new System.Drawing.Point(124, 20);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(454, 20);
            this.lblSerial.TabIndex = 5;
            this.lblSerial.Text = "Label1";
            this.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //Label2
            //
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(6, 24);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(90, 13);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Seriennummer:";
            //
            //GroupBox1
            //
            this.GroupBox1.Controls.Add(this.lblExpiresOn);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.lblVersion);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.lblSerial);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.GroupBox1.Location = new System.Drawing.Point(15, 309);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(596, 114);
            this.GroupBox1.TabIndex = 7;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Lizensierungsinfo:";
            //
            //lblExpiresOn
            //
            this.lblExpiresOn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblExpiresOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblExpiresOn.Location = new System.Drawing.Point(124, 69);
            this.lblExpiresOn.Name = "lblExpiresOn";
            this.lblExpiresOn.Size = new System.Drawing.Size(454, 20);
            this.lblExpiresOn.TabIndex = 9;
            this.lblExpiresOn.Text = "Label4";
            this.lblExpiresOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //Label5
            //
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(6, 73);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(78, 13);
            this.Label5.TabIndex = 10;
            this.Label5.Text = "Läuft ab am:";
            //
            //lblVersion
            //
            this.lblVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblVersion.Location = new System.Drawing.Point(124, 44);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(454, 20);
            this.lblVersion.TabIndex = 7;
            this.lblVersion.Text = "Label1";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //Label3
            //
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 48);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(107, 13);
            this.Label3.TabIndex = 8;
            this.Label3.Text = "Programmversion:";
            //
            //frmInfo
            //
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(623, 490);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.Copyright);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facesso .NET 2011";
            ((System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Label Version;
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

        internal System.Windows.Forms.Label lblSerial;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label lblExpiresOn;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label lblVersion;
        internal System.Windows.Forms.Label Label3;
    }
}