using System;
using System.Drawing;
using System.Windows.Forms;

namespace ActiveDev.Data.SqlClient
{
    public partial class ADTsqlScriptProcessorDialog : Form
    {
        private AdTSqlScriptProcessor _scriptProcessor;

        public void HandleDialog(AdTSqlScriptProcessor scriptProcessor)
        {
            _scriptProcessor = scriptProcessor;
            InitializeTable();
            BuildTable(false);
            this.ShowDialog();
        }

        private void BuildTable(bool useUse)
        {
            dgvScriptChunks.Rows.Clear();
            int count = 1;
            foreach (AdTSqlScriptChunk item in _scriptProcessor)
            {
                string chunk = item.ChunkText.Replace("\t", "   ");
                dgvScriptChunks.Rows.Add(new object[] { count.ToString(), chunk, "Noch nicht verarbeitet" });
                dgvScriptChunks.Rows[count - 1].Tag = item;
                count++;
            }
        }

        private void InitializeTable()
        {
            Font headerFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
            Font cellFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
            Font listingFont = new Font(FontFamily.GenericMonospace, 8, FontStyle.Regular);

            dgvScriptChunks.ColumnHeadersDefaultCellStyle.Font = headerFont;
            dgvScriptChunks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvScriptChunks.AllowUserToAddRows = false;
            dgvScriptChunks.AllowUserToDeleteRows = false;
            dgvScriptChunks.AllowUserToOrderColumns = false;
            dgvScriptChunks.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvScriptChunks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

            dgvScriptChunks.Columns.Clear();

            // Chunk-Nr
            var col = new DataGridViewColumn(new DataGridViewTextBoxCell());
            col.Width = 60;
            col.DisplayIndex = 0;
            col.HeaderText = "Chunk-Nr.:";
            col.MinimumWidth = 50;
            col.ReadOnly = true;
            col.Resizable = DataGridViewTriState.True;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            col.DefaultCellStyle.Font = headerFont;
            col.Name = "ChunkNr";
            dgvScriptChunks.Columns.Add(col);

            // Skript-Chunk
            col = new DataGridViewColumn(new DataGridViewTextBoxCell());
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col.FillWeight = 500;
            col.DisplayIndex = 1;
            col.HeaderText = "Skript-Chunk:";
            col.MinimumWidth = 100;
            col.ReadOnly = true;
            col.Resizable = DataGridViewTriState.True;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            col.DefaultCellStyle.Font = listingFont;
            col.Name = "ScriptChunk";
            dgvScriptChunks.Columns.Add(col);

            // Ausführungsresultat
            col = new DataGridViewColumn(new DataGridViewTextBoxCell());
            col.Width = 120;
            col.DisplayIndex = 2;
            col.HeaderText = "Ausführungsresultat:";
            col.FillWeight = 200;
            col.MinimumWidth = 100;
            col.ReadOnly = false;
            col.Resizable = DataGridViewTriState.True;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            col.DefaultCellStyle.Font = cellFont;
            col.Name = "ExecutionResult";
            dgvScriptChunks.Columns.Add(col);
        }

        private void btnSendScript_Click(object sender, EventArgs e)
        {
            int count = 0;
            pbScriptExecution.Maximum = dgvScriptChunks.Rows.Count - 1;

            foreach (DataGridViewRow row in dgvScriptChunks.Rows)
            {
                var chunk = (AdTSqlScriptChunk)row.Tag;
                string msg = chunk.ExecuteChunk();
                if (msg == "OK")
                {
                    row.Cells["ExecutionResult"].Value = msg;
                    row.Selected = true;
                    dgvScriptChunks.FirstDisplayedScrollingRowIndex = count;
                    Application.DoEvents();
                }
                else
                {
                    DialogResult dr = MessageBox.Show(
                        "Bei der Skript-Ausführung ist ein Fehler aufgetreten:\r\n" +
                        msg + "Soll die Ausführung fortgesetzt werden?", "Skriptfehler:",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No)
                        break;
                }
                pbScriptExecution.Value = count;
                count++;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
