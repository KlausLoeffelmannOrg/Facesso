using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ActiveDev
{
    public partial class ADFileTextBox : System.Windows.Forms.UserControl
    {

        [DebuggerNonUserCode()]
        public ADFileTextBox() : base()
        {
            Ctor2();

            // This call is required by the Windows Form Designer.
            InitializeComponent();

        }

        // UserControl1 overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components is not null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _txtFilename = new System.Windows.Forms.TextBox();
            _btnFileSelect = new System.Windows.Forms.Button();
            _btnFileSelect.Click += new EventHandler(btnFileSelect_Click);
            SuspendLayout();
            // 
            // txtFilename
            // 
            _txtFilename.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            _txtFilename.Location = new System.Drawing.Point(0, 0);
            _txtFilename.Name = "_txtFilename";
            _txtFilename.Size = new System.Drawing.Size(208, 20);
            _txtFilename.TabIndex = 0;
            // 
            // btnFileSelect
            // 
            _btnFileSelect.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            _btnFileSelect.Location = new System.Drawing.Point(209, 0);
            _btnFileSelect.Name = "_btnFileSelect";
            _btnFileSelect.Size = new System.Drawing.Size(24, 20);
            _btnFileSelect.TabIndex = 1;
            _btnFileSelect.Text = "...";
            // 
            // ADFileTextBox
            // 
            AutoSize = true;
            Controls.Add(_btnFileSelect);
            Controls.Add(_txtFilename);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "ADFileTextBox";
            Size = new System.Drawing.Size(232, 23);
            ResumeLayout(false);
            PerformLayout();

        }
        private System.Windows.Forms.TextBox _txtFilename;

        internal virtual System.Windows.Forms.TextBox txtFilename
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFilename;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _txtFilename = value;
            }
        }
        private System.Windows.Forms.Button _btnFileSelect;

        internal virtual System.Windows.Forms.Button btnFileSelect
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFileSelect;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFileSelect != null)
                {
                    _btnFileSelect.Click -= btnFileSelect_Click;
                }

                _btnFileSelect = value;
                if (_btnFileSelect != null)
                {
                    _btnFileSelect.Click += btnFileSelect_Click;
                }
            }
        }

    }
}