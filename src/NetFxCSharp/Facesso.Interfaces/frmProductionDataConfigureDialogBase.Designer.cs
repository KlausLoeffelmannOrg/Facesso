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
    public partial class frmProductionDataConfigureDialogBase : System.Windows.Forms.Form
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
            this.lblTitel = new System.Windows.Forms.Label();
            this.lvwDeviceItems = new System.Windows.Forms.ListView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ucLabourValues = new Facesso.GenericControls.ucLabourValueListView();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.TableLayoutPanel1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            //
            //lblTitel
            //
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.lblTitel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.lblTitel.Location = new System.Drawing.Point(12, 9);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(710, 46);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Konfiguration f�r Produktiv-Site:";
            this.lblTitel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //lvwDeviceItems
            //
            this.lvwDeviceItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDeviceItems.FullRowSelect = true;
            this.lvwDeviceItems.HideSelection = false;
            this.lvwDeviceItems.Location = new System.Drawing.Point(3, 16);
            this.lvwDeviceItems.MultiSelect = false;
            this.lvwDeviceItems.Name = "lvwDeviceItems";
            this.lvwDeviceItems.Size = new System.Drawing.Size(293, 372);
            this.lvwDeviceItems.TabIndex = 1;
            this.lvwDeviceItems.UseCompatibleStateImageBehavior = false;
            this.lvwDeviceItems.View = System.Windows.Forms.View.Details;
            //
            //btnOK
            //
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnOK.Location = new System.Drawing.Point(522, 472);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 29);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //btnCancel
            //
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnCancel.Location = new System.Drawing.Point(624, 472);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 29);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            //ucLabourValues
            //
            this.ucLabourValues.AutoGroup = true;
            this.ucLabourValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLabourValues.FullRowSelect = true;
            this.ucLabourValues.HideSelection = false;
            this.ucLabourValues.LabourValues = null;
            this.ucLabourValues.LabourValueSortOrder = Facesso.GenericControls.LabourValuesSortOrder.LabourValueNumber;
            this.ucLabourValues.Location = new System.Drawing.Point(3, 16);
            this.ucLabourValues.Name = "ucLabourValues";
            this.ucLabourValues.Size = new System.Drawing.Size(293, 372);
            this.ucLabourValues.TabIndex = 6;
            this.ucLabourValues.UseCompatibleStateImageBehavior = false;
            this.ucLabourValues.View = System.Windows.Forms.View.Details;
            //
            //TableLayoutPanel1
            //
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.TableLayoutPanel1.ColumnCount = 3;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100f));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
            this.TableLayoutPanel1.Controls.Add(this.GroupBox1, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.GroupBox2, 2, 0);
            this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel2, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(12, 58);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(710, 397);
            this.TableLayoutPanel1.TabIndex = 10;
            //
            //GroupBox1
            //
            this.GroupBox1.Controls.Add(this.ucLabourValues);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.Location = new System.Drawing.Point(3, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(299, 391);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Arbeitswerte dieser Produktiv-Site";
            //
            //GroupBox2
            //
            this.GroupBox2.Controls.Add(this.lvwDeviceItems);
            this.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox2.Location = new System.Drawing.Point(408, 3);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(299, 391);
            this.GroupBox2.TabIndex = 2;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Ger�te-Elemente (Artikel, Programmnr, etc.)";
            //
            //TableLayoutPanel2
            //
            this.TableLayoutPanel2.ColumnCount = 1;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
            this.TableLayoutPanel2.Controls.Add(this.btnRemove, 0, 1);
            this.TableLayoutPanel2.Controls.Add(this.btnAdd, 0, 0);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(308, 3);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 3;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25f));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25f));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(94, 391);
            this.TableLayoutPanel2.TabIndex = 3;
            //
            //btnRemove
            //
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemove.Location = new System.Drawing.Point(3, 129);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(87, 32);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "<< entfernen";
            this.btnRemove.UseVisualStyleBackColor = true;
            //
            //btnAdd
            //
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(3, 62);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 32);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "dazu >>";
            this.btnAdd.UseVisualStyleBackColor = true;
            //
            //frmProductionDataConfigureDialogBase
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 531);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblTitel);
            this.Name = "frmProductionDataConfigureDialogBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Konfiguration der Produktiv-Site f�r die Daten�bernahme";
            this.TableLayoutPanel1.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.TableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        protected internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        protected internal System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Button _btnOK;
        protected internal System.Windows.Forms.Button btnOK
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

        private System.Windows.Forms.Button _btnCancel;
        protected internal System.Windows.Forms.Button btnCancel
        {
            get
            {
                return _btnCancel;
            }

            set
            {
                if (_btnCancel != null)
                {
                    _btnCancel.Click -= btnCancel_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click;
                }
            }
        }

        protected internal System.Windows.Forms.ListView lvwDeviceItems;
        protected internal Facesso.GenericControls.ucLabourValueListView ucLabourValues;
        protected internal System.Windows.Forms.GroupBox GroupBox1;
        protected internal System.Windows.Forms.GroupBox GroupBox2;
        protected internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        private System.Windows.Forms.Button _btnRemove;
        protected internal System.Windows.Forms.Button btnRemove
        {
            get
            {
                return _btnRemove;
            }

            set
            {
                if (_btnRemove != null)
                {
                    _btnRemove.Click -= btnRemove_Click;
                }

                _btnRemove = value;
                if (_btnRemove != null)
                {
                    _btnRemove.Click += btnRemove_Click;
                }
            }
        }

        private System.Windows.Forms.Button _btnAdd;
        protected internal System.Windows.Forms.Button btnAdd
        {
            get
            {
                return _btnAdd;
            }

            set
            {
                if (_btnAdd != null)
                {
                    _btnAdd.Click -= btnAdd_Click;
                }

                _btnAdd = value;
                if (_btnAdd != null)
                {
                    _btnAdd.Click += btnAdd_Click;
                }
            }
        }
    }
}