namespace ActiveDev.Data.SqlClient
{
    partial class ADTsqlScriptProcessorDialog
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private System.ComponentModel.IContainer components = null;

        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.dgvScriptChunks = new System.Windows.Forms.DataGridView();
            this.pbScriptExecution = new System.Windows.Forms.ProgressBar();
            this.btnSendScript = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScriptChunks)).BeginInit();
            this.SuspendLayout();
            //
            // dgvScriptChunks
            //
            this.dgvScriptChunks.AllowUserToAddRows = false;
            this.dgvScriptChunks.AllowUserToDeleteRows = false;
            this.dgvScriptChunks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.dgvScriptChunks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScriptChunks.Location = new System.Drawing.Point(12, 12);
            this.dgvScriptChunks.Name = "dgvScriptChunks";
            this.dgvScriptChunks.ReadOnly = true;
            this.dgvScriptChunks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvScriptChunks.Size = new System.Drawing.Size(548, 281);
            this.dgvScriptChunks.TabIndex = 0;
            //
            // pbScriptExecution
            //
            this.pbScriptExecution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            this.pbScriptExecution.Location = new System.Drawing.Point(12, 299);
            this.pbScriptExecution.Name = "pbScriptExecution";
            this.pbScriptExecution.Size = new System.Drawing.Size(548, 22);
            this.pbScriptExecution.TabIndex = 1;
            //
            // btnSendScript
            //
            this.btnSendScript.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.btnSendScript.Location = new System.Drawing.Point(12, 340);
            this.btnSendScript.Name = "btnSendScript";
            this.btnSendScript.Size = new System.Drawing.Size(162, 30);
            this.btnSendScript.TabIndex = 2;
            this.btnSendScript.Text = "Skript senden";
            this.btnSendScript.UseVisualStyleBackColor = true;
            //
            // btnOK
            //
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnOK.Location = new System.Drawing.Point(460, 340);
            this.btnOK.Name = "btnCancel";
            this.btnOK.Size = new System.Drawing.Size(100, 30);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            // ADTsqlScriptProcessorDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 386);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSendScript);
            this.Controls.Add(this.pbScriptExecution);
            this.Controls.Add(this.dgvScriptChunks);
            this.Name = "ADTsqlScriptProcessorDialog";
            this.Text = "T-SQL-Skript ausführen:";
            ((System.ComponentModel.ISupportInitialize)(this.dgvScriptChunks)).EndInit();
            this.ResumeLayout(false);

            // Wire events
            this.btnSendScript.Click += new System.EventHandler(this.btnSendScript_Click);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
        }

        internal System.Windows.Forms.DataGridView dgvScriptChunks;
        internal System.Windows.Forms.ProgressBar pbScriptExecution;
        internal System.Windows.Forms.Button btnSendScript;
        internal System.Windows.Forms.Button btnOK;
    }
}
