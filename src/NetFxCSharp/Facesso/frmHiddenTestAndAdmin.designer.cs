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
    public partial class frmHiddenTestAndAdmin : System.Windows.Forms.Form
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ToEndNullableDateValue = new ActiveDevelop.EntitiesFormsLib.NullableDateValue();
            this.ToStartNullableDateValue = new ActiveDevelop.EntitiesFormsLib.NullableDateValue();
            this.FromStartNullableDateValue = new ActiveDevelop.EntitiesFormsLib.NullableDateValue();
            this.CheckBox2 = new System.Windows.Forms.CheckBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.IncludeTineDataCheckBox = new System.Windows.Forms.CheckBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.CopyProgressBar = new System.Windows.Forms.ProgressBar();
            this.CopyNowButton = new System.Windows.Forms.Button();
            this.CopyInfoLabel = new System.Windows.Forms.Label();
            this.PassCaptionLabel = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.btnNamenAnonymisieren = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            //
            //GroupBox1
            //
            this.GroupBox1.Controls.Add(this.btnNamenAnonymisieren);
            this.GroupBox1.Controls.Add(this.ToEndNullableDateValue);
            this.GroupBox1.Controls.Add(this.ToStartNullableDateValue);
            this.GroupBox1.Controls.Add(this.FromStartNullableDateValue);
            this.GroupBox1.Controls.Add(this.CheckBox2);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.IncludeTineDataCheckBox);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.CopyProgressBar);
            this.GroupBox1.Controls.Add(this.CopyNowButton);
            this.GroupBox1.Controls.Add(this.CopyInfoLabel);
            this.GroupBox1.Controls.Add(this.PassCaptionLabel);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(18, 28);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(683, 178);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Mengen und Zeitdaten duplizieren";
            //
            //ToEndNullableDateValue
            //
            this.ToEndNullableDateValue.AssignedManagerComponent = null;
            this.ToEndNullableDateValue.Borderstyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ToEndNullableDateValue.ContentPresentPermission = ActiveDevelop.EntitiesFormsLib.ContentPresentPermissions.Normal;
            this.ToEndNullableDateValue.DaysDistanceBetweenLinkedControl = null;
            this.ToEndNullableDateValue.LinkedToNullableDateControl = null;
            this.ToEndNullableDateValue.Location = new System.Drawing.Point(333, 78);
            this.ToEndNullableDateValue.MaxLength = 32767;
            this.ToEndNullableDateValue.Name = "ToEndNullableDateValue";
            this.ToEndNullableDateValue.NullValueMessage = "Bitte geben Sie ein gültiges Datum in diesem Feld ein!";
            this.ToEndNullableDateValue.ObfuscationChar = null;
            this.ToEndNullableDateValue.PermissionReason = null;
            this.ToEndNullableDateValue.Size = new System.Drawing.Size(185, 20);
            this.ToEndNullableDateValue.TabIndex = 17;
            this.ToEndNullableDateValue.UIGuid = new System.Guid("d0c4f13e-426b-4f1e-83cd-52dc53293618");
            this.ToEndNullableDateValue.Value = new System.DateTime(2010, 1, 2, 0, 0, 0, 0);
            //
            //ToStartNullableDateValue
            //
            this.ToStartNullableDateValue.AssignedManagerComponent = null;
            this.ToStartNullableDateValue.Borderstyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ToStartNullableDateValue.ContentPresentPermission = ActiveDevelop.EntitiesFormsLib.ContentPresentPermissions.Normal;
            this.ToStartNullableDateValue.DaysDistanceBetweenLinkedControl = 1;
            this.ToStartNullableDateValue.LinkedToNullableDateControl = null;
            this.ToStartNullableDateValue.Location = new System.Drawing.Point(64, 79);
            this.ToStartNullableDateValue.MaxLength = 32767;
            this.ToStartNullableDateValue.Name = "ToStartNullableDateValue";
            this.ToStartNullableDateValue.NullValueMessage = "Bitte geben Sie ein gültiges Datum in diesem Feld ein!";
            this.ToStartNullableDateValue.ObfuscationChar = null;
            this.ToStartNullableDateValue.PermissionReason = null;
            this.ToStartNullableDateValue.Size = new System.Drawing.Size(185, 20);
            this.ToStartNullableDateValue.TabIndex = 16;
            this.ToStartNullableDateValue.UIGuid = new System.Guid("d0c4f13e-426b-4f1e-83cd-52dc53293618");
            this.ToStartNullableDateValue.Value = new System.DateTime(2010, 1, 2, 0, 0, 0, 0);
            //
            //FromStartNullableDateValue
            //
            this.FromStartNullableDateValue.AssignedManagerComponent = null;
            this.FromStartNullableDateValue.Borderstyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FromStartNullableDateValue.ContentPresentPermission = ActiveDevelop.EntitiesFormsLib.ContentPresentPermissions.Normal;
            this.FromStartNullableDateValue.DaysDistanceBetweenLinkedControl = 1;
            this.FromStartNullableDateValue.LinkedToNullableDateControl = null;
            this.FromStartNullableDateValue.Location = new System.Drawing.Point(64, 51);
            this.FromStartNullableDateValue.MaxLength = 32767;
            this.FromStartNullableDateValue.Name = "FromStartNullableDateValue";
            this.FromStartNullableDateValue.NullValueMessage = "Bitte geben Sie ein gültiges Datum in diesem Feld ein!";
            this.FromStartNullableDateValue.ObfuscationChar = null;
            this.FromStartNullableDateValue.PermissionReason = null;
            this.FromStartNullableDateValue.Size = new System.Drawing.Size(185, 20);
            this.FromStartNullableDateValue.TabIndex = 15;
            this.FromStartNullableDateValue.UIGuid = new System.Guid("d0c4f13e-426b-4f1e-83cd-52dc53293618");
            this.FromStartNullableDateValue.Value = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            //
            //CheckBox2
            //
            this.CheckBox2.AutoSize = true;
            this.CheckBox2.Location = new System.Drawing.Point(309, 54);
            this.CheckBox2.Name = "CheckBox2";
            this.CheckBox2.Size = new System.Drawing.Size(221, 17);
            this.CheckBox2.TabIndex = 14;
            this.CheckBox2.Text = "Vorhandene Daten dabei vorher löschen.";
            this.CheckBox2.UseVisualStyleBackColor = true;
            //
            //Label6
            //
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(306, 23);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(136, 13);
            this.Label6.TabIndex = 13;
            this.Label6.Text = "ab diesem Datum kopieren.";
            //
            //IncludeTineDataCheckBox
            //
            this.IncludeTineDataCheckBox.AutoSize = true;
            this.IncludeTineDataCheckBox.Location = new System.Drawing.Point(178, 22);
            this.IncludeTineDataCheckBox.Name = "IncludeTineDataCheckBox";
            this.IncludeTineDataCheckBox.Size = new System.Drawing.Size(71, 17);
            this.IncludeTineDataCheckBox.TabIndex = 12;
            this.IncludeTineDataCheckBox.Text = "Zeitdaten";
            this.IncludeTineDataCheckBox.UseVisualStyleBackColor = true;
            //
            //Label5
            //
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(61, 23);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(113, 13);
            this.Label5.TabIndex = 11;
            this.Label5.Text = "Die Mengendaten und";
            //
            //Label4
            //
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(32, 82);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(23, 13);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "bis:";
            //
            //CopyProgressBar
            //
            this.CopyProgressBar.Location = new System.Drawing.Point(255, 139);
            this.CopyProgressBar.Name = "CopyProgressBar";
            this.CopyProgressBar.Size = new System.Drawing.Size(263, 22);
            this.CopyProgressBar.TabIndex = 9;
            this.CopyProgressBar.Value = 10;
            //
            //CopyNowButton
            //
            this.CopyNowButton.Location = new System.Drawing.Point(546, 25);
            this.CopyNowButton.Name = "CopyNowButton";
            this.CopyNowButton.Size = new System.Drawing.Size(120, 46);
            this.CopyNowButton.TabIndex = 8;
            this.CopyNowButton.Text = "Jetzt Kopieren";
            this.CopyNowButton.UseVisualStyleBackColor = true;
            //
            //CopyInfoLabel
            //
            this.CopyInfoLabel.AutoEllipsis = true;
            this.CopyInfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CopyInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.CopyInfoLabel.Location = new System.Drawing.Point(64, 139);
            this.CopyInfoLabel.Name = "CopyInfoLabel";
            this.CopyInfoLabel.Size = new System.Drawing.Size(185, 23);
            this.CopyInfoLabel.TabIndex = 7;
            this.CopyInfoLabel.Text = "- - -";
            //
            //PassCaptionLabel
            //
            this.PassCaptionLabel.AutoSize = true;
            this.PassCaptionLabel.Location = new System.Drawing.Point(61, 117);
            this.PassCaptionLabel.Name = "PassCaptionLabel";
            this.PassCaptionLabel.Size = new System.Drawing.Size(105, 13);
            this.PassCaptionLabel.TabIndex = 5;
            this.PassCaptionLabel.Text = "Kopieren Daten von:";
            //
            //Label2
            //
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(306, 81);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(23, 13);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "bis:";
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(32, 55);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(28, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "von:";
            //
            //OKButton
            //
            this.OKButton.Location = new System.Drawing.Point(591, 212);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(110, 37);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            //
            //btnNamenAnonymisieren
            //
            this.btnNamenAnonymisieren.Location = new System.Drawing.Point(546, 79);
            this.btnNamenAnonymisieren.Name = "btnNamenAnonymisieren";
            this.btnNamenAnonymisieren.Size = new System.Drawing.Size(120, 46);
            this.btnNamenAnonymisieren.TabIndex = 18;
            this.btnNamenAnonymisieren.Text = "Namen anonymisieren";
            this.btnNamenAnonymisieren.UseVisualStyleBackColor = true;
            //
            //frmHiddenTestAndAdmin
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 269);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmHiddenTestAndAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hidden Test and Admin";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ProgressBar CopyProgressBar;
        private System.Windows.Forms.Button _CopyNowButton;
        internal System.Windows.Forms.Button CopyNowButton
        {
            get
            {
                return _CopyNowButton;
            }

            set
            {
                if (_CopyNowButton != null)
                {
                    _CopyNowButton.Click -= CopyNowButton_Clck;
                }

                _CopyNowButton = value;
                if (_CopyNowButton != null)
                {
                    _CopyNowButton.Click += CopyNowButton_Clck;
                }
            }
        }

        internal System.Windows.Forms.Label CopyInfoLabel;
        internal System.Windows.Forms.Label PassCaptionLabel;
        private System.Windows.Forms.Button _OKButton;
        internal System.Windows.Forms.Button OKButton
        {
            get
            {
                return _OKButton;
            }

            set
            {
                if (_OKButton != null)
                {
                    _OKButton.Click -= OKButton_Click;
                }

                _OKButton = value;
                if (_OKButton != null)
                {
                    _OKButton.Click += OKButton_Click;
                }
            }
        }

        internal System.Windows.Forms.CheckBox CheckBox2;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.CheckBox IncludeTineDataCheckBox;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        private ActiveDevelop.EntitiesFormsLib.NullableDateValue _ToEndNullableDateValue;
        internal ActiveDevelop.EntitiesFormsLib.NullableDateValue ToEndNullableDateValue
        {
            get
            {
                return _ToEndNullableDateValue;
            }

            set
            {
                if (_ToEndNullableDateValue != null)
                {
                    _ToEndNullableDateValue.IsDirtyChanged -= ToEndNullableDateValue_IsDirtyChanged;
                }

                _ToEndNullableDateValue = value;
                if (_ToEndNullableDateValue != null)
                {
                    _ToEndNullableDateValue.IsDirtyChanged += ToEndNullableDateValue_IsDirtyChanged;
                }
            }
        }

        internal ActiveDevelop.EntitiesFormsLib.NullableDateValue ToStartNullableDateValue;
        internal ActiveDevelop.EntitiesFormsLib.NullableDateValue FromStartNullableDateValue;
        private System.Windows.Forms.Button _btnNamenAnonymisieren;
        internal System.Windows.Forms.Button btnNamenAnonymisieren
        {
            get
            {
                return _btnNamenAnonymisieren;
            }

            set
            {
                if (_btnNamenAnonymisieren != null)
                {
                    _btnNamenAnonymisieren.Click -= btnNamenAnonymisieren_Click;
                }

                _btnNamenAnonymisieren = value;
                if (_btnNamenAnonymisieren != null)
                {
                    _btnNamenAnonymisieren.Click += btnNamenAnonymisieren_Click;
                }
            }
        }
    }
}