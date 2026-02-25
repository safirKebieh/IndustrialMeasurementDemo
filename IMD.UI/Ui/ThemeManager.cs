using System.Drawing.Drawing2D;

namespace IMD.UI.Ui
{
    internal static class ThemeManager
    {
        public static void ApplyMainTheme(
            Control root,
            Panel pnlCurrentCard,
            Panel pnlStatsCard,
            Panel pnlSystem,
            DataGridView gridMeasurements,
            ListBox listLog,
            Button btnConnect,
            Button btnStart,
            Button btnStop,
            Label lblCurrentTitleFirst,
            Label lblCurrentValueFirst,
            Label lblCurrentTarget)
        {
            root.BackColor = Color.FromArgb(18, 18, 22);
            root.ForeColor = Color.Gainsboro;

            ApplyThemeRecursive(root);

            // Cards look
            StyleCardPanel(pnlCurrentCard);
            StyleCardPanel(pnlStatsCard);
            StyleCardPanel(pnlSystem);

            // Current card header + main value
            lblCurrentTitleFirst.ForeColor = Color.White;
            lblCurrentTitleFirst.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            lblCurrentValueFirst.ForeColor = Color.White;
            lblCurrentValueFirst.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            lblCurrentTarget.ForeColor = Color.Gray;

            // Grid
            gridMeasurements.BackgroundColor = Color.FromArgb(18, 18, 22);
            gridMeasurements.GridColor = Color.FromArgb(55, 55, 60);

            gridMeasurements.DefaultCellStyle.BackColor = Color.FromArgb(26, 26, 32);
            gridMeasurements.RowTemplate.Height = 34;
            gridMeasurements.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridMeasurements.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            gridMeasurements.DefaultCellStyle.ForeColor = Color.White;
            gridMeasurements.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 90);
            gridMeasurements.DefaultCellStyle.SelectionForeColor = Color.White;

            gridMeasurements.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(22, 22, 28);

            gridMeasurements.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 48);
            gridMeasurements.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridMeasurements.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Log
            listLog.BackColor = Color.FromArgb(26, 26, 32);
            listLog.ForeColor = Color.Gainsboro;

            // Buttons
            StyleButton(btnConnect);
            StyleButton(btnStart);
            StyleButton(btnStop);
        }

        private static void ApplyThemeRecursive(Control c)
        {
            if (c is Panel or TableLayoutPanel or SplitContainer or FlowLayoutPanel)
                c.BackColor = Color.FromArgb(18, 18, 22);

            if (c is Label lbl)
                lbl.ForeColor = Color.Gainsboro;

            foreach (Control child in c.Controls)
                ApplyThemeRecursive(child);
        }

        private static void StyleCardPanel(Panel panel)
        {
            panel.BackColor = Color.FromArgb(26, 26, 32);
            panel.BorderStyle = BorderStyle.FixedSingle;
        }

        private static void StyleButton(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = Color.FromArgb(35, 40, 50);
            b.ForeColor = Color.White;
            b.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            b.Cursor = Cursors.Hand;

            // Prevent stacking event handlers if called twice
            b.MouseEnter -= ButtonMouseEnter;
            b.MouseLeave -= ButtonMouseLeave;
            b.MouseDown -= ButtonMouseDown;
            b.MouseUp -= ButtonMouseUp;
            b.Paint -= ButtonPaint;

            b.MouseEnter += ButtonMouseEnter;
            b.MouseLeave += ButtonMouseLeave;
            b.MouseDown += ButtonMouseDown;
            b.MouseUp += ButtonMouseUp;
            b.Paint += ButtonPaint;
        }

        private static void ButtonMouseEnter(object? s, EventArgs e)
        {
            if (s is Button b) b.BackColor = Color.FromArgb(55, 130, 220);
        }

        private static void ButtonMouseLeave(object? s, EventArgs e)
        {
            if (s is Button b) b.BackColor = Color.FromArgb(35, 40, 50);
        }

        private static void ButtonMouseDown(object? s, MouseEventArgs e)
        {
            if (s is Button b) b.BackColor = Color.FromArgb(25, 100, 180);
        }

        private static void ButtonMouseUp(object? s, MouseEventArgs e)
        {
            if (s is Button b) b.BackColor = Color.FromArgb(55, 130, 220);
        }

        private static void ButtonPaint(object? s, PaintEventArgs e)
        {
            if (s is not Button b) return;

            using var path = new GraphicsPath();
            int radius = 8;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(b.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(b.Width - radius, b.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, b.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            b.Region = new Region(path);
        }
    }
}