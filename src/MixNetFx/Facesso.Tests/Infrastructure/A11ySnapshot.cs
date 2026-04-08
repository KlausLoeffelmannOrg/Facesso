using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;

namespace Facesso.Tests.Infrastructure
{
    /// <summary>
    /// Captures a text-based "accessibility snapshot" of any WinForms window by
    /// walking the UI Automation tree. Works out-of-process and in headless
    /// containers — no visible desktop required.
    /// </summary>
    public class A11ySnapshot
    {
        /// <summary>Root node of the captured control tree.</summary>
        public A11yNode Root { get; }

        /// <summary>Timestamp when the snapshot was taken.</summary>
        public DateTime CapturedAt { get; }

        private A11ySnapshot(A11yNode root, DateTime capturedAt)
        {
            Root = root;
            CapturedAt = capturedAt;
        }

        /// <summary>
        /// Captures the full UI Automation tree for the window identified by <paramref name="hwnd"/>.
        /// </summary>
        public static A11ySnapshot Capture(IntPtr hwnd)
        {
            var element = AutomationElement.FromHandle(hwnd);
            var root = CaptureNode(element, maxDepth: 25);
            return new A11ySnapshot(root, DateTime.Now);
        }

        /// <summary>Renders the snapshot as a Markdown document.</summary>
        public string ToMarkdown()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"# Accessibility Snapshot: {Root.Name}");
            sb.AppendLine();
            sb.AppendLine($"*Captured: {CapturedAt:yyyy-MM-dd HH:mm:ss}*");
            sb.AppendLine();
            sb.AppendLine("---");
            sb.AppendLine();
            RenderNodeMarkdown(sb, Root, headingLevel: 2);
            return sb.ToString();
        }

        /// <summary>Renders the snapshot as plain indented text.</summary>
        public string ToPlainText()
        {
            var sb = new StringBuilder();
            RenderNodePlainText(sb, Root, indent: 0);
            return sb.ToString();
        }

        #region Tree Capture

        private static A11yNode CaptureNode(AutomationElement element, int maxDepth)
        {
            var node = new A11yNode
            {
                Name = SafeGet(() => element.Current.Name) ?? "",
                ControlType = SafeGet(() => element.Current.ControlType.ProgrammaticName)
                                  ?.Replace("ControlType.", "") ?? "Unknown",
                AutomationId = SafeGet(() => element.Current.AutomationId) ?? "",
                ClassName = SafeGet(() => element.Current.ClassName) ?? "",
            };

            // Extract value from controls that support ValuePattern
            if (TryGetPattern<ValuePattern>(element, ValuePattern.Pattern, out var vp))
                node.Value = SafeGet(() => vp.Current.Value);

            // Extract grid data from DataGridView / ListView
            if (TryGetPattern<GridPattern>(element, GridPattern.Pattern, out var gp))
                node.GridData = CaptureGridData(element, gp);

            // Recurse into children (skip if we've gone too deep)
            if (maxDepth > 0)
            {
                var walker = TreeWalker.RawViewWalker;
                var child = SafeGet(() => walker.GetFirstChild(element));
                while (child != null)
                {
                    node.Children.Add(CaptureNode(child, maxDepth - 1));
                    child = SafeGet(() => walker.GetNextSibling(child));
                }
            }

            return node;
        }

        private static string[][] CaptureGridData(AutomationElement element, GridPattern grid)
        {
            try
            {
                int rows = grid.Current.RowCount;
                int cols = grid.Current.ColumnCount;

                if (rows <= 0 || cols <= 0 || rows > 500)
                    return null;

                // Try to get header row
                var headerRow = new List<string>();
                try
                {
                    var headers = element.FindAll(TreeScope.Children,
                        new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Header));
                    if (headers.Count > 0)
                    {
                        var headerItems = headers[0].FindAll(TreeScope.Children, Condition.TrueCondition);
                        foreach (AutomationElement h in headerItems)
                            headerRow.Add(SafeGet(() => h.Current.Name) ?? "");
                    }
                }
                catch { }

                var result = new List<string[]>();
                if (headerRow.Count > 0)
                    result.Add(headerRow.ToArray());

                int maxRows = Math.Min(rows, 50); // cap for sanity
                for (int r = 0; r < maxRows; r++)
                {
                    var row = new string[cols];
                    for (int c = 0; c < cols; c++)
                    {
                        try
                        {
                            var cell = grid.GetItem(r, c);
                            if (TryGetPattern<ValuePattern>(cell, ValuePattern.Pattern, out var cvp))
                                row[c] = SafeGet(() => cvp.Current.Value) ?? "";
                            else
                                row[c] = SafeGet(() => cell.Current.Name) ?? "";
                        }
                        catch
                        {
                            row[c] = "";
                        }
                    }
                    result.Add(row);
                }

                return result.ToArray();
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Markdown Rendering

        private static void RenderNodeMarkdown(StringBuilder sb, A11yNode node, int headingLevel)
        {
            bool hasContent = !string.IsNullOrEmpty(node.Name)
                           || !string.IsNullOrEmpty(node.Value)
                           || node.GridData != null;

            bool isContainer = IsContainerType(node.ControlType);
            bool isLeaf = node.Children.Count == 0;

            // Skip unnamed non-container nodes with no content
            if (!hasContent && !isContainer && isLeaf)
                return;

            // Render heading for significant containers
            if (isContainer || node.GridData != null || IsSignificantControl(node))
            {
                string heading = new string('#', Math.Min(headingLevel, 6));
                string label = FormatNodeLabel(node);
                sb.AppendLine($"{heading} {label}");
                sb.AppendLine();
            }

            // Render value/name as text content
            if (!string.IsNullOrEmpty(node.Value) && node.Value != node.Name)
            {
                sb.AppendLine(node.Value);
                sb.AppendLine();
            }
            else if (!string.IsNullOrEmpty(node.Name) && IsSignificantControl(node) && !isContainer)
            {
                sb.AppendLine(node.Name);
                sb.AppendLine();
            }

            // Render grid data as a Markdown table
            if (node.GridData != null && node.GridData.Length > 0)
            {
                RenderMarkdownTable(sb, node.GridData);
                sb.AppendLine();
            }

            // Render menu items as a bullet list
            if (node.ControlType == "Menu" || node.ControlType == "MenuBar" || node.ControlType == "MenuItem")
            {
                RenderMenuItems(sb, node, indent: 0);
                sb.AppendLine();
                return; // children already rendered
            }

            // Render children
            int childHeading = isContainer ? Math.Min(headingLevel + 1, 6) : headingLevel;
            foreach (var child in node.Children)
                RenderNodeMarkdown(sb, child, childHeading);
        }

        private static void RenderMenuItems(StringBuilder sb, A11yNode node, int indent)
        {
            foreach (var child in node.Children)
            {
                if (string.IsNullOrEmpty(child.Name) || child.Name == "separator")
                    continue;

                string prefix = new string(' ', indent * 2);
                sb.AppendLine($"{prefix}- {child.Name}");

                if (child.Children.Count > 0)
                    RenderMenuItems(sb, child, indent + 1);
            }
        }

        private static void RenderMarkdownTable(StringBuilder sb, string[][] data)
        {
            if (data.Length == 0) return;

            int cols = data.Max(r => r.Length);
            if (cols == 0) return;

            // Header row
            var header = data[0];
            sb.Append("| ");
            for (int c = 0; c < cols; c++)
                sb.Append((c < header.Length ? header[c] : "") + " | ");
            sb.AppendLine();

            // Separator
            sb.Append("| ");
            for (int c = 0; c < cols; c++)
                sb.Append("--- | ");
            sb.AppendLine();

            // Data rows
            for (int r = 1; r < data.Length; r++)
            {
                sb.Append("| ");
                for (int c = 0; c < cols; c++)
                    sb.Append((c < data[r].Length ? data[r][c] : "") + " | ");
                sb.AppendLine();
            }
        }

        #endregion

        #region Plain Text Rendering

        private static void RenderNodePlainText(StringBuilder sb, A11yNode node, int indent)
        {
            string prefix = new string(' ', indent * 2);
            string label = FormatNodeLabel(node);

            if (!string.IsNullOrEmpty(node.Name) || !string.IsNullOrEmpty(node.Value))
            {
                sb.Append(prefix);
                sb.Append($"[{node.ControlType}] {label}");

                if (!string.IsNullOrEmpty(node.Value) && node.Value != node.Name)
                    sb.Append($" = \"{node.Value}\"");

                sb.AppendLine();
            }

            if (node.GridData != null)
            {
                foreach (var row in node.GridData)
                    sb.AppendLine($"{prefix}  | {string.Join(" | ", row)} |");
            }

            foreach (var child in node.Children)
                RenderNodePlainText(sb, child, indent + 1);
        }

        #endregion

        #region Helpers

        private static string FormatNodeLabel(A11yNode node)
        {
            string label = node.ControlType;

            if (!string.IsNullOrEmpty(node.AutomationId))
                label += $" \"{node.AutomationId}\"";

            if (!string.IsNullOrEmpty(node.Name))
            {
                if (string.IsNullOrEmpty(node.AutomationId) || node.AutomationId != node.Name)
                    label += $" — {node.Name}";
            }

            return label;
        }

        private static bool IsContainerType(string controlType) =>
            controlType == "Window" || controlType == "Pane" || controlType == "Group"
            || controlType == "Tab" || controlType == "TabItem" || controlType == "ToolBar"
            || controlType == "MenuBar" || controlType == "StatusBar" || controlType == "Table"
            || controlType == "DataGrid" || controlType == "List" || controlType == "Tree";

        private static bool IsSignificantControl(A11yNode node) =>
            !string.IsNullOrEmpty(node.Name) &&
            (node.ControlType == "Text" || node.ControlType == "Button"
             || node.ControlType == "Edit" || node.ControlType == "MenuItem"
             || node.ControlType == "ListItem" || node.ControlType == "DataItem"
             || node.ControlType == "HeaderItem" || node.ControlType == "Header");

        private static bool TryGetPattern<T>(AutomationElement element,
            AutomationPattern pattern, out T result) where T : BasePattern
        {
            try
            {
                if (element.TryGetCurrentPattern(pattern, out object obj) && obj is T typed)
                {
                    result = typed;
                    return true;
                }
            }
            catch { }

            result = default;
            return false;
        }

        private static T SafeGet<T>(Func<T> func)
        {
            try { return func(); }
            catch { return default; }
        }

        #endregion
    }

    /// <summary>
    /// Represents a single node in the UI Automation tree snapshot.
    /// </summary>
    public class A11yNode
    {
        public string Name { get; set; }
        public string ControlType { get; set; }
        public string AutomationId { get; set; }
        public string ClassName { get; set; }
        public string Value { get; set; }
        public List<A11yNode> Children { get; set; } = new List<A11yNode>();

        /// <summary>
        /// Grid/table data for DataGridView or ListView controls.
        /// First row is headers (if available), remaining rows are data.
        /// </summary>
        public string[][] GridData { get; set; }
    }
}
