namespace IMD.UI.Ui
{
    internal static class GridConfigurator
    {
        public static void Configure(
            DataGridView grid,
            Action<Exception>? onErrorLog = null)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersHeight = 34;

            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Prevent stacking handlers if called twice
            grid.CellFormatting -= Grid_CellFormatting;
            grid.CellFormatting += Grid_CellFormatting;

            grid.DataBindingComplete -= Grid_DataBindingComplete;
            grid.DataBindingComplete += Grid_DataBindingComplete;

            grid.DataError -= Grid_DataError;
            grid.DataError += Grid_DataError;

            // Local handler uses delegate closure for optional logging
            void Grid_DataError(object? s, DataGridViewDataErrorEventArgs e)
            {
                e.ThrowException = false;
                if (e.Exception is not null)
                    onErrorLog?.Invoke(e.Exception);
            }
        }

        private static void Grid_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (sender is not DataGridView grid)
                return;

            if (grid.Columns[nameof(MeasurementRow.Timestamp)] is DataGridViewColumn ts)
                ts.HeaderText = "Time";

            if (grid.Columns[nameof(MeasurementRow.WidthMm)] is DataGridViewColumn w)
                w.HeaderText = "Width (mm)";

            if (grid.Columns[nameof(MeasurementRow.WeightG)] is DataGridViewColumn wg)
                wg.HeaderText = "Weight (g)";

            if (grid.Columns[nameof(MeasurementRow.Status)] is DataGridViewColumn st)
                st.HeaderText = "Status";

            if (grid.Columns[nameof(MeasurementRow.Accepted)] is DataGridViewColumn acc)
                acc.HeaderText = "Accepted";

            if (grid.Columns[nameof(MeasurementRow.Accepted)] is DataGridViewCheckBoxColumn chk)
                chk.Width = 90;
        }

        private static void Grid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (sender is not DataGridView grid)
                return;

            var col = grid.Columns[e.ColumnIndex].Name;

            if (col == nameof(MeasurementRow.Timestamp) && e.Value is DateTimeOffset dto)
            {
                e.Value = dto.ToLocalTime().ToString("HH:mm:ss.fff");
                e.FormattingApplied = true;
                return;
            }

            if ((col == nameof(MeasurementRow.WidthMm) || col == nameof(MeasurementRow.WeightG)) && e.Value is double d)
            {
                e.Value = d.ToString("F3");
                e.FormattingApplied = true;
            }
        }
    }
}