using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Facesso
{
    /// <summary>
    /// Walks a WinForms control tree and produces a structured text snapshot
    /// suitable for automated testing. Works in-process — no UI Automation
    /// or accessibility infrastructure required.
    /// 
    /// Triggered via environment variable FACESSO_A11Y_DUMP_PATH.
    /// </summary>
    public static class ControlTreeDumper
    {
        /// <summary>
        /// Dumps the control tree of the given form to the path specified
        /// by FACESSO_A11Y_DUMP_PATH. Does nothing if the variable is not set.
        /// </summary>
        public static void DumpIfRequested(Form form)
        {
            var path = Environment.GetEnvironmentVariable("FACESSO_A11Y_DUMP_PATH");
            if (string.IsNullOrEmpty(path))
                return;

            try
            {
                System.IO.Directory.CreateDirectory(
                    System.IO.Path.GetDirectoryName(path));

                var md = ToMarkdown(form);
                System.IO.File.WriteAllText(path, md, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError(
                    "ControlTreeDumper failed: " + ex.Message);
            }
        }

        /// <summary>
        /// Generates a Markdown representation of the control tree.
        /// Reusable with any Form or Control.
        /// </summary>
        public static string ToMarkdown(Control root)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"# Accessibility Snapshot: {root.Text}");
            sb.AppendLine();
            sb.AppendLine($"*Captured: {DateTime.Now:yyyy-MM-dd HH:mm:ss}*  ");
            sb.AppendLine($"*Control: {root.GetType().Name} ({root.Name})*  ");
            sb.AppendLine($"*Size: {root.Width} × {root.Height}*");
            sb.AppendLine();
            sb.AppendLine("---");
            sb.AppendLine();

            DumpControl(sb, root, headingLevel: 2);
            return sb.ToString();
        }

        private static void DumpControl(StringBuilder sb, Control control, int headingLevel)
        {
            switch (control)
            {
                case MenuStrip menu:
                    WriteHeading(sb, headingLevel, "MenuStrip", menu.Name);
                    DumpMenuItems(sb, menu.Items, indent: 0);
                    sb.AppendLine();
                    return;

                case ToolStrip toolStrip when !(control is MenuStrip) && !(control is StatusStrip):
                    WriteHeading(sb, headingLevel, "ToolStrip", toolStrip.Name);
                    DumpToolStripItems(sb, toolStrip.Items);
                    sb.AppendLine();
                    return;

                case StatusStrip status:
                    WriteHeading(sb, headingLevel, "StatusBar", status.Name);
                    sb.AppendLine("| Label | Text |");
                    sb.AppendLine("| --- | --- |");
                    foreach (ToolStripItem item in status.Items)
                    {
                        if (!string.IsNullOrEmpty(item.Text))
                            sb.AppendLine($"| {item.Name} | {item.Text} |");
                    }
                    sb.AppendLine();
                    return;

                case DataGridView dgv:
                    WriteHeading(sb, headingLevel, "DataGrid", dgv.Name);
                    DumpDataGridView(sb, dgv);
                    return;

                case ListView lv:
                    WriteHeading(sb, headingLevel, "ListView", lv.Name);
                    DumpListView(sb, lv);
                    return;

                case TabControl tab:
                    WriteHeading(sb, headingLevel, "TabControl", tab.Name);
                    sb.AppendLine($"Selected tab: **{tab.SelectedTab?.Text ?? "(none)"}**");
                    sb.AppendLine();
                    // Dump all tab pages
                    foreach (TabPage page in tab.TabPages)
                    {
                        WriteHeading(sb, headingLevel + 1, "TabPage", page.Text);
                        DumpChildren(sb, page, headingLevel + 2);
                    }
                    return;

                case GroupBox gb:
                    WriteHeading(sb, headingLevel, "GroupBox", gb.Text);
                    DumpChildren(sb, gb, headingLevel + 1);
                    return;

                case Label lbl when !string.IsNullOrEmpty(lbl.Text):
                    WriteHeading(sb, headingLevel, "Label", lbl.Name);
                    sb.AppendLine(lbl.Text);
                    sb.AppendLine();
                    return;

                case TextBox txt:
                    WriteHeading(sb, headingLevel, "TextBox", txt.Name);
                    sb.AppendLine(string.IsNullOrEmpty(txt.Text) ? "*(empty)*" : txt.Text);
                    sb.AppendLine();
                    return;

                case SplitContainer split:
                    DumpChildren(sb, split.Panel1, headingLevel);
                    DumpChildren(sb, split.Panel2, headingLevel);
                    return;

                case TableLayoutPanel tlp:
                    DumpChildren(sb, tlp, headingLevel);
                    return;

                case Panel panel:
                    DumpChildren(sb, panel, headingLevel);
                    return;

                case ToolStripContainer tsc:
                    DumpChildren(sb, tsc.TopToolStripPanel, headingLevel);
                    DumpChildren(sb, tsc.LeftToolStripPanel, headingLevel);
                    DumpChildren(sb, tsc.ContentPanel, headingLevel);
                    DumpChildren(sb, tsc.RightToolStripPanel, headingLevel);
                    DumpChildren(sb, tsc.BottomToolStripPanel, headingLevel);
                    return;

                case UserControl uc:
                    // Walk into custom UserControls
                    DumpChildren(sb, uc, headingLevel);
                    return;

                default:
                    // For any other container, walk children
                    if (control.Controls.Count > 0)
                        DumpChildren(sb, control, headingLevel);
                    return;
            }
        }

        private static void DumpChildren(StringBuilder sb, Control parent, int headingLevel)
        {
            foreach (Control child in parent.Controls)
                DumpControl(sb, child, headingLevel);
        }

        private static void DumpMenuItems(StringBuilder sb, ToolStripItemCollection items, int indent)
        {
            string prefix = new string(' ', indent * 2);
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripSeparator)
                    continue;

                if (string.IsNullOrEmpty(item.Text))
                    continue;

                sb.AppendLine($"{prefix}- {item.Text}");

                if (item is ToolStripMenuItem menuItem && menuItem.DropDownItems.Count > 0)
                    DumpMenuItems(sb, menuItem.DropDownItems, indent + 1);
            }
        }

        private static void DumpToolStripItems(StringBuilder sb, ToolStripItemCollection items)
        {
            var namedItems = new List<(string Name, string Text)>();
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripSeparator)
                    continue;

                string text = !string.IsNullOrEmpty(item.Text) ? item.Text
                            : !string.IsNullOrEmpty(item.ToolTipText) ? item.ToolTipText
                            : item.Name;

                if (!string.IsNullOrEmpty(text))
                    namedItems.Add((item.Name, text));
            }

            if (namedItems.Count > 0)
            {
                sb.AppendLine("| Button | Text |");
                sb.AppendLine("| --- | --- |");
                foreach (var (name, text) in namedItems)
                    sb.AppendLine($"| {name} | {text} |");
                sb.AppendLine();
            }
        }

        private static void DumpDataGridView(StringBuilder sb, DataGridView dgv)
        {
            if (dgv.Columns.Count == 0)
            {
                sb.AppendLine("*(no columns)*");
                sb.AppendLine();
                return;
            }

            // Headers
            sb.Append("| ");
            foreach (DataGridViewColumn col in dgv.Columns)
                sb.Append($"{col.HeaderText} | ");
            sb.AppendLine();

            sb.Append("| ");
            foreach (DataGridViewColumn col in dgv.Columns)
                sb.Append("--- | ");
            sb.AppendLine();

            // Rows (cap at 50)
            int maxRows = Math.Min(dgv.Rows.Count, 50);
            for (int r = 0; r < maxRows; r++)
            {
                if (dgv.Rows[r].IsNewRow) continue;
                sb.Append("| ");
                foreach (DataGridViewCell cell in dgv.Rows[r].Cells)
                    sb.Append($"{cell.Value ?? ""} | ");
                sb.AppendLine();
            }

            if (dgv.Rows.Count > 50)
                sb.AppendLine($"*... and {dgv.Rows.Count - 50} more rows*");

            sb.AppendLine();
        }

        private static void DumpListView(StringBuilder sb, ListView lv)
        {
            if (lv.Columns.Count == 0 && lv.Items.Count == 0)
            {
                sb.AppendLine("*(empty)*");
                sb.AppendLine();
                return;
            }

            // Headers
            if (lv.Columns.Count > 0)
            {
                sb.Append("| ");
                foreach (ColumnHeader col in lv.Columns)
                    sb.Append($"{col.Text} | ");
                sb.AppendLine();

                sb.Append("| ");
                foreach (ColumnHeader col in lv.Columns)
                    sb.Append("--- | ");
                sb.AppendLine();
            }

            // Items with groups
            string currentGroup = null;
            int maxItems = Math.Min(lv.Items.Count, 50);
            for (int i = 0; i < maxItems; i++)
            {
                var item = lv.Items[i];
                if (item.Group != null && item.Group.Header != currentGroup)
                {
                    currentGroup = item.Group.Header;
                    sb.AppendLine($"| **{currentGroup}** | | |");
                }

                sb.Append("| ");
                sb.Append($"{item.Text} | ");
                foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
                {
                    if (sub != item.SubItems[0]) // skip the first (already printed)
                        sb.Append($"{sub.Text} | ");
                }
                sb.AppendLine();
            }

            if (lv.Items.Count > 50)
                sb.AppendLine($"*... and {lv.Items.Count - 50} more items*");

            sb.AppendLine();
        }

        private static void WriteHeading(StringBuilder sb, int level, string type, string name)
        {
            string heading = new string('#', Math.Min(level, 6));
            sb.AppendLine($"{heading} {type} \"{name}\"");
            sb.AppendLine();
        }
    }
}
