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
    public partial class frmDateShiftPicker : Facesso.GenericControls.frmBaseFacesso
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
            this.Button8 = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.Button7 = new System.Windows.Forms.Button();
            this.Button6 = new System.Windows.Forms.Button();
            this.Button5 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.MonthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            //
            //GroupBox1
            //
            this.GroupBox1.Controls.Add(this.Button8);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Button7);
            this.GroupBox1.Controls.Add(this.Button6);
            this.GroupBox1.Controls.Add(this.Button5);
            this.GroupBox1.Controls.Add(this.Button3);
            this.GroupBox1.Controls.Add(this.Button2);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.Button1);
            this.GroupBox1.Controls.Add(this.MonthCalendar1);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.GroupBox1.Location = new System.Drawing.Point(1, 1);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(405, 219);
            this.GroupBox1.TabIndex = 9;
            this.GroupBox1.TabStop = false;
            //
            //Button8
            //
            this.Button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Button8.Location = new System.Drawing.Point(366, 19);
            this.Button8.Name = "Button8";
            this.Button8.Size = new System.Drawing.Size(30, 27);
            this.Button8.TabIndex = 18;
            this.Button8.Text = "S";
            //
            //Label4
            //
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label4.Location = new System.Drawing.Point(209, 24);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(58, 16);
            this.Label4.TabIndex = 17;
            this.Label4.Text = "Schicht:";
            //
            //Button7
            //
            this.Button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Button7.Location = new System.Drawing.Point(270, 19);
            this.Button7.Name = "Button7";
            this.Button7.Size = new System.Drawing.Size(30, 27);
            this.Button7.TabIndex = 16;
            this.Button7.Text = "1";
            //
            //Button6
            //
            this.Button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Button6.Location = new System.Drawing.Point(302, 19);
            this.Button6.Name = "Button6";
            this.Button6.Size = new System.Drawing.Size(30, 27);
            this.Button6.TabIndex = 15;
            this.Button6.Text = "2";
            //
            //Button5
            //
            this.Button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Button5.Location = new System.Drawing.Point(334, 19);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(30, 27);
            this.Button5.TabIndex = 14;
            this.Button5.Text = "3";
            //
            //Button3
            //
            this.Button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Button3.Location = new System.Drawing.Point(209, 177);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(189, 31);
            this.Button3.TabIndex = 8;
            this.Button3.Text = "mein Merkdatum";
            //
            //Button2
            //
            this.Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Button2.Location = new System.Drawing.Point(209, 140);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(189, 31);
            this.Button2.TabIndex = 7;
            this.Button2.Text = "mein letzter Erfassungstag";
            //
            //Label2
            //
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label2.Location = new System.Drawing.Point(209, 75);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(189, 24);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Donnerstag, 31. Dez 2005";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Label1.Location = new System.Drawing.Point(209, 55);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(152, 16);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Ausgew�hltes Datum:";
            //
            //Button1
            //
            this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.Button1.Location = new System.Drawing.Point(209, 103);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(189, 31);
            this.Button1.TabIndex = 4;
            this.Button1.Text = "letztes Datenvorkommen";
            //
            //MonthCalendar1
            //
            this.MonthCalendar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            this.MonthCalendar1.Location = new System.Drawing.Point(7, 24);
            this.MonthCalendar1.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.MonthCalendar1.Name = "MonthCalendar1";
            this.MonthCalendar1.ShowWeekNumbers = true;
            this.MonthCalendar1.Size = new System.Drawing.Size(187, 185);
            this.MonthCalendar1.TabIndex = 3;
            //
            //frmDateShiftPicker
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 226);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDateShiftPicker";
            this.Text = "Datums- und Schichtauswahl";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button Button8;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button Button7;
        internal System.Windows.Forms.Button Button6;
        internal System.Windows.Forms.Button Button5;
        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.MonthCalendar MonthCalendar1;
    }
}