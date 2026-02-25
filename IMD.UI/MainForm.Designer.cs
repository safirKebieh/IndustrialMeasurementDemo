namespace IMD.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tlpRoot = new TableLayoutPanel();
            pnlTop = new Panel();
            pictureBox1 = new PictureBox();
            tlpCards = new TableLayoutPanel();
            pnlCurrentCard = new Panel();
            lblCurrentTarget = new Label();
            lblCurrentValueFirst = new Label();
            lblCurrentTitleFirst = new Label();
            pnlStatsCard = new Panel();
            tlpStats = new TableLayoutPanel();
            lblTotalTitle = new Label();
            lblTotalValue = new Label();
            lblPerfectTitle = new Label();
            lblPerfectValue = new Label();
            lblAcceptableTitle = new Label();
            lblAcceptableValue = new Label();
            lblRejectedTitle = new Label();
            lblRejectedValue = new Label();
            lblCurrentTitle = new Label();
            lblCurrentValue = new Label();
            pnlSystem = new Panel();
            tlpSystem = new TableLayoutPanel();
            lblSystemTitle = new Label();
            lblConnValue = new Label();
            lblRunValue = new Label();
            lblLastSampleValue = new Label();
            lblLastDbValue = new Label();
            pnlStarting = new Panel();
            btnConnect = new Button();
            btnStart = new Button();
            btnStop = new Button();
            splitMain = new SplitContainer();
            gridMeasurements = new DataGridView();
            listLog = new ListBox();
            tlpRoot.SuspendLayout();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tlpCards.SuspendLayout();
            pnlCurrentCard.SuspendLayout();
            pnlStatsCard.SuspendLayout();
            tlpStats.SuspendLayout();
            pnlSystem.SuspendLayout();
            tlpSystem.SuspendLayout();
            pnlStarting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridMeasurements).BeginInit();
            SuspendLayout();
            // 
            // tlpRoot
            // 
            tlpRoot.ColumnCount = 1;
            tlpRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpRoot.Controls.Add(pnlTop, 0, 0);
            tlpRoot.Controls.Add(tlpCards, 0, 1);
            tlpRoot.Controls.Add(splitMain, 0, 2);
            tlpRoot.Dock = DockStyle.Fill;
            tlpRoot.Location = new Point(0, 0);
            tlpRoot.Name = "tlpRoot";
            tlpRoot.Padding = new Padding(10);
            tlpRoot.RowCount = 3;
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpRoot.Size = new Size(1200, 700);
            tlpRoot.TabIndex = 0;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(pictureBox1);
            pnlTop.Dock = DockStyle.Fill;
            pnlTop.Location = new Point(13, 13);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(8);
            pnlTop.Size = new Size(1174, 94);
            pnlTop.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(8, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1158, 78);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // tlpCards
            // 
            tlpCards.ColumnCount = 4;
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.Controls.Add(pnlCurrentCard, 0, 0);
            tlpCards.Controls.Add(pnlStatsCard, 1, 0);
            tlpCards.Controls.Add(pnlSystem, 2, 0);
            tlpCards.Controls.Add(pnlStarting, 3, 0);
            tlpCards.Dock = DockStyle.Fill;
            tlpCards.Location = new Point(13, 113);
            tlpCards.Name = "tlpCards";
            tlpCards.Padding = new Padding(0, 0, 0, 10);
            tlpCards.RowCount = 1;
            tlpCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpCards.Size = new Size(1174, 134);
            tlpCards.TabIndex = 1;
            // 
            // pnlCurrentCard
            // 
            pnlCurrentCard.Controls.Add(lblCurrentTarget);
            pnlCurrentCard.Controls.Add(lblCurrentValueFirst);
            pnlCurrentCard.Controls.Add(lblCurrentTitleFirst);
            pnlCurrentCard.Dock = DockStyle.Fill;
            pnlCurrentCard.Location = new Point(0, 0);
            pnlCurrentCard.Margin = new Padding(0, 0, 10, 0);
            pnlCurrentCard.Name = "pnlCurrentCard";
            pnlCurrentCard.Padding = new Padding(12);
            pnlCurrentCard.Size = new Size(283, 124);
            pnlCurrentCard.TabIndex = 0;
            // 
            // lblCurrentTarget
            // 
            lblCurrentTarget.Dock = DockStyle.Bottom;
            lblCurrentTarget.Font = new Font("Segoe UI", 10F);
            lblCurrentTarget.ForeColor = Color.Gray;
            lblCurrentTarget.Location = new Point(12, 94);
            lblCurrentTarget.Name = "lblCurrentTarget";
            lblCurrentTarget.Size = new Size(259, 18);
            lblCurrentTarget.TabIndex = 2;
            lblCurrentTarget.Text = "Target: -";
            lblCurrentTarget.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentValueFirst
            // 
            lblCurrentValueFirst.Dock = DockStyle.Fill;
            lblCurrentValueFirst.Font = new Font("Segoe UI", 10F);
            lblCurrentValueFirst.Location = new Point(12, 38);
            lblCurrentValueFirst.Name = "lblCurrentValueFirst";
            lblCurrentValueFirst.Size = new Size(259, 74);
            lblCurrentValueFirst.TabIndex = 1;
            lblCurrentValueFirst.Text = "Width: -   |   Weight: -";
            lblCurrentValueFirst.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentTitleFirst
            // 
            lblCurrentTitleFirst.Dock = DockStyle.Top;
            lblCurrentTitleFirst.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCurrentTitleFirst.Location = new Point(12, 12);
            lblCurrentTitleFirst.Name = "lblCurrentTitleFirst";
            lblCurrentTitleFirst.Size = new Size(259, 26);
            lblCurrentTitleFirst.TabIndex = 0;
            lblCurrentTitleFirst.Text = "Current Sample";
            lblCurrentTitleFirst.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlStatsCard
            // 
            pnlStatsCard.Controls.Add(tlpStats);
            pnlStatsCard.Dock = DockStyle.Fill;
            pnlStatsCard.Location = new Point(293, 0);
            pnlStatsCard.Margin = new Padding(0);
            pnlStatsCard.Name = "pnlStatsCard";
            pnlStatsCard.Padding = new Padding(12);
            pnlStatsCard.Size = new Size(293, 124);
            pnlStatsCard.TabIndex = 2;
            // 
            // tlpStats
            // 
            tlpStats.ColumnCount = 2;
            tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tlpStats.Controls.Add(lblTotalTitle, 0, 0);
            tlpStats.Controls.Add(lblTotalValue, 1, 0);
            tlpStats.Controls.Add(lblPerfectTitle, 0, 1);
            tlpStats.Controls.Add(lblPerfectValue, 1, 1);
            tlpStats.Controls.Add(lblAcceptableTitle, 0, 2);
            tlpStats.Controls.Add(lblAcceptableValue, 1, 2);
            tlpStats.Controls.Add(lblRejectedTitle, 0, 3);
            tlpStats.Controls.Add(lblRejectedValue, 1, 3);
            tlpStats.Controls.Add(lblCurrentTitle, 0, 4);
            tlpStats.Controls.Add(lblCurrentValue, 1, 4);
            tlpStats.Dock = DockStyle.Fill;
            tlpStats.Location = new Point(12, 12);
            tlpStats.Name = "tlpStats";
            tlpStats.Padding = new Padding(6);
            tlpStats.RowCount = 5;
            tlpStats.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpStats.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpStats.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpStats.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpStats.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpStats.Size = new Size(269, 100);
            tlpStats.TabIndex = 0;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.Location = new Point(9, 6);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(100, 17);
            lblTotalTitle.TabIndex = 0;
            lblTotalTitle.Text = "Total:";
            // 
            // lblTotalValue
            // 
            lblTotalValue.Location = new Point(150, 6);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(100, 17);
            lblTotalValue.TabIndex = 1;
            lblTotalValue.Text = "0";
            lblTotalValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPerfectTitle
            // 
            lblPerfectTitle.Location = new Point(9, 23);
            lblPerfectTitle.Name = "lblPerfectTitle";
            lblPerfectTitle.Size = new Size(100, 17);
            lblPerfectTitle.TabIndex = 2;
            lblPerfectTitle.Text = "Perfect:";
            // 
            // lblPerfectValue
            // 
            lblPerfectValue.Location = new Point(150, 23);
            lblPerfectValue.Name = "lblPerfectValue";
            lblPerfectValue.Size = new Size(100, 17);
            lblPerfectValue.TabIndex = 3;
            lblPerfectValue.Text = "0 (0%)";
            lblPerfectValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblAcceptableTitle
            // 
            lblAcceptableTitle.Location = new Point(9, 40);
            lblAcceptableTitle.Name = "lblAcceptableTitle";
            lblAcceptableTitle.Size = new Size(100, 17);
            lblAcceptableTitle.TabIndex = 4;
            lblAcceptableTitle.Text = "Acceptable:";
            // 
            // lblAcceptableValue
            // 
            lblAcceptableValue.Location = new Point(150, 40);
            lblAcceptableValue.Name = "lblAcceptableValue";
            lblAcceptableValue.Size = new Size(100, 17);
            lblAcceptableValue.TabIndex = 5;
            lblAcceptableValue.Text = "0 (0%)";
            lblAcceptableValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblRejectedTitle
            // 
            lblRejectedTitle.Location = new Point(9, 57);
            lblRejectedTitle.Name = "lblRejectedTitle";
            lblRejectedTitle.Size = new Size(100, 17);
            lblRejectedTitle.TabIndex = 6;
            lblRejectedTitle.Text = "Rejected:";
            // 
            // lblRejectedValue
            // 
            lblRejectedValue.Location = new Point(150, 57);
            lblRejectedValue.Name = "lblRejectedValue";
            lblRejectedValue.Size = new Size(100, 17);
            lblRejectedValue.TabIndex = 7;
            lblRejectedValue.Text = "0 (0%)";
            lblRejectedValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCurrentTitle
            // 
            lblCurrentTitle.Location = new Point(9, 74);
            lblCurrentTitle.Name = "lblCurrentTitle";
            lblCurrentTitle.Size = new Size(100, 20);
            lblCurrentTitle.TabIndex = 8;
            lblCurrentTitle.Text = "Current:";
            // 
            // lblCurrentValue
            // 
            lblCurrentValue.Location = new Point(150, 74);
            lblCurrentValue.Name = "lblCurrentValue";
            lblCurrentValue.Size = new Size(100, 20);
            lblCurrentValue.TabIndex = 9;
            lblCurrentValue.Text = "-";
            lblCurrentValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlSystem
            // 
            pnlSystem.Controls.Add(tlpSystem);
            pnlSystem.Dock = DockStyle.Fill;
            pnlSystem.Location = new Point(596, 0);
            pnlSystem.Margin = new Padding(10, 0, 0, 0);
            pnlSystem.Name = "pnlSystem";
            pnlSystem.Padding = new Padding(12);
            pnlSystem.Size = new Size(283, 124);
            pnlSystem.TabIndex = 3;
            // 
            // tlpSystem
            // 
            tlpSystem.ColumnCount = 1;
            tlpSystem.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpSystem.Controls.Add(lblSystemTitle, 0, 0);
            tlpSystem.Controls.Add(lblConnValue, 0, 1);
            tlpSystem.Controls.Add(lblRunValue, 0, 2);
            tlpSystem.Controls.Add(lblLastSampleValue, 0, 3);
            tlpSystem.Controls.Add(lblLastDbValue, 0, 4);
            tlpSystem.Dock = DockStyle.Fill;
            tlpSystem.Location = new Point(12, 12);
            tlpSystem.Name = "tlpSystem";
            tlpSystem.Padding = new Padding(6);
            tlpSystem.RowCount = 5;
            tlpSystem.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpSystem.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpSystem.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpSystem.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpSystem.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpSystem.Size = new Size(259, 100);
            tlpSystem.TabIndex = 0;
            // 
            // lblSystemTitle
            // 
            lblSystemTitle.Location = new Point(9, 6);
            lblSystemTitle.Name = "lblSystemTitle";
            lblSystemTitle.Size = new Size(241, 17);
            lblSystemTitle.TabIndex = 0;
            lblSystemTitle.Text = "System";
            // 
            // lblConnValue
            // 
            lblConnValue.Font = new Font("Segoe UI", 9F);
            lblConnValue.Location = new Point(9, 23);
            lblConnValue.Name = "lblConnValue";
            lblConnValue.Size = new Size(241, 17);
            lblConnValue.TabIndex = 1;
            lblConnValue.Text = "Connection: -";
            // 
            // lblRunValue
            // 
            lblRunValue.Location = new Point(9, 40);
            lblRunValue.Name = "lblRunValue";
            lblRunValue.Size = new Size(241, 17);
            lblRunValue.TabIndex = 2;
            lblRunValue.Text = "Run: -";
            // 
            // lblLastSampleValue
            // 
            lblLastSampleValue.Location = new Point(9, 57);
            lblLastSampleValue.Name = "lblLastSampleValue";
            lblLastSampleValue.Size = new Size(241, 17);
            lblLastSampleValue.TabIndex = 3;
            lblLastSampleValue.Text = "Last sample: -";
            // 
            // lblLastDbValue
            // 
            lblLastDbValue.Location = new Point(9, 74);
            lblLastDbValue.Name = "lblLastDbValue";
            lblLastDbValue.Size = new Size(241, 17);
            lblLastDbValue.TabIndex = 4;
            lblLastDbValue.Text = "DB: -";
            // 
            // pnlStarting
            // 
            pnlStarting.Controls.Add(btnConnect);
            pnlStarting.Controls.Add(btnStart);
            pnlStarting.Controls.Add(btnStop);
            pnlStarting.Dock = DockStyle.Fill;
            pnlStarting.Location = new Point(882, 3);
            pnlStarting.Name = "pnlStarting";
            pnlStarting.Padding = new Padding(10);
            pnlStarting.Size = new Size(289, 118);
            pnlStarting.TabIndex = 4;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(19, 15);
            btnConnect.Margin = new Padding(0, 5, 8, 0);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(242, 25);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(19, 48);
            btnStart.Margin = new Padding(0, 5, 8, 0);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(242, 25);
            btnStart.TabIndex = 5;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(19, 81);
            btnStop.Margin = new Padding(0, 5, 18, 0);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(242, 25);
            btnStop.TabIndex = 6;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(13, 253);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(gridMeasurements);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(listLog);
            splitMain.Size = new Size(1174, 434);
            splitMain.SplitterDistance = 947;
            splitMain.TabIndex = 2;
            // 
            // gridMeasurements
            // 
            gridMeasurements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridMeasurements.Dock = DockStyle.Fill;
            gridMeasurements.Location = new Point(0, 0);
            gridMeasurements.Name = "gridMeasurements";
            gridMeasurements.Size = new Size(947, 434);
            gridMeasurements.TabIndex = 0;
            // 
            // listLog
            // 
            listLog.Dock = DockStyle.Fill;
            listLog.Location = new Point(0, 0);
            listLog.Name = "listLog";
            listLog.Size = new Size(223, 434);
            listLog.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(tlpRoot);
            MinimumSize = new Size(816, 339);
            Name = "MainForm";
            Text = "Industrial Measurement Demo";
            tlpRoot.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tlpCards.ResumeLayout(false);
            pnlCurrentCard.ResumeLayout(false);
            pnlStatsCard.ResumeLayout(false);
            tlpStats.ResumeLayout(false);
            pnlSystem.ResumeLayout(false);
            tlpSystem.ResumeLayout(false);
            pnlStarting.ResumeLayout(false);
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridMeasurements).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpRoot;
        private Panel pnlTop;
        private Button btnConnect;
        private Button btnStart;
        private Button btnStop;

        private TableLayoutPanel tlpCards;

        private Panel pnlCurrentCard;
        private Label lblCurrentTitleFirst;
        private Label lblCurrentValueFirst;
        private Label lblCurrentTarget;

        private Panel pnlStatsCard;
        private TableLayoutPanel tlpStats;
        private Label lblTotalTitle;
        private Label lblTotalValue;
        private Label lblPerfectTitle;
        private Label lblPerfectValue;
        private Label lblAcceptableTitle;
        private Label lblAcceptableValue;
        private Label lblRejectedTitle;
        private Label lblRejectedValue;
        private Label lblCurrentTitle;
        private Label lblCurrentValue;

        private Panel pnlSystem;
        private TableLayoutPanel tlpSystem;
        private Label lblSystemTitle;
        private Label lblConnValue;
        private Label lblRunValue;
        private Label lblLastSampleValue;
        private Label lblLastDbValue;

        private SplitContainer splitMain;
        private DataGridView gridMeasurements;
        private ListBox listLog;
        private Panel pnlStarting;
        private PictureBox pictureBox1;
    }
}
