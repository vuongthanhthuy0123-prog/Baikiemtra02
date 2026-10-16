namespace Bai3_MdiSieuThi
{
    partial class frmAsyncReport
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            grpReport = new GroupBox();
            btnLoadReport = new Button();
            lblReportStatus = new Label();
            dgvRevenue = new DataGridView();
            grpSync = new GroupBox();
            btnStartSync = new Button();
            btnStopSync = new Button();
            lblExchangeRate = new Label();
            lblOrderCount = new Label();
            dgvOrders = new DataGridView();
            grpReport.SuspendLayout();
            grpSync.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRevenue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // grpReport
            // 
            grpReport.Controls.Add(dgvRevenue);
            grpReport.Controls.Add(lblReportStatus);
            grpReport.Controls.Add(btnLoadReport);
            grpReport.Location = new Point(12, 12);
            grpReport.Size = new Size(420, 536);
            grpReport.TabStop = false;
            grpReport.Text = "Báo cáo doanh thu (async/await)";
            grpReport.Name = "grpReport";
            grpReport.TabIndex = 0;
            // 
            // btnLoadReport
            // 
            btnLoadReport.Location = new Point(15, 25);
            btnLoadReport.Size = new Size(180, 36);
            btnLoadReport.Text = "Tải Báo Cáo Doanh Thu";
            btnLoadReport.UseVisualStyleBackColor = true;
            btnLoadReport.Name = "btnLoadReport";
            btnLoadReport.TabIndex = 1;
            // 
            // lblReportStatus
            // 
            lblReportStatus.AutoSize = true;
            lblReportStatus.Location = new Point(205, 35);
            lblReportStatus.Text = "Chưa tải dữ liệu";
            lblReportStatus.Name = "lblReportStatus";
            // 
            // dgvRevenue
            // 
            dgvRevenue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRevenue.Location = new Point(15, 70);
            dgvRevenue.Size = new Size(390, 450);
            dgvRevenue.Name = "dgvRevenue";
            dgvRevenue.TabIndex = 2;
            // 
            // grpSync
            // 
            grpSync.Controls.Add(dgvOrders);
            grpSync.Controls.Add(lblOrderCount);
            grpSync.Controls.Add(lblExchangeRate);
            grpSync.Controls.Add(btnStopSync);
            grpSync.Controls.Add(btnStartSync);
            grpSync.Location = new Point(444, 12);
            grpSync.Size = new Size(434, 536);
            grpSync.TabStop = false;
            grpSync.Text = "Đồng bộ thời gian thực (Cross-Thread)";
            grpSync.Name = "grpSync";
            grpSync.TabIndex = 3;
            // 
            // btnStartSync
            // 
            btnStartSync.Location = new Point(15, 25);
            btnStartSync.Size = new Size(150, 36);
            btnStartSync.Text = "Bắt đầu đồng bộ";
            btnStartSync.UseVisualStyleBackColor = true;
            btnStartSync.Name = "btnStartSync";
            btnStartSync.TabIndex = 4;
            // 
            // btnStopSync
            // 
            btnStopSync.Enabled = false;
            btnStopSync.Location = new Point(175, 25);
            btnStopSync.Size = new Size(100, 36);
            btnStopSync.Text = "Dừng";
            btnStopSync.UseVisualStyleBackColor = true;
            btnStopSync.Name = "btnStopSync";
            btnStopSync.TabIndex = 5;
            // 
            // lblExchangeRate
            // 
            lblExchangeRate.AutoSize = true;
            lblExchangeRate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblExchangeRate.Location = new Point(15, 75);
            lblExchangeRate.Text = "Tỷ giá USD/VND: --";
            lblExchangeRate.Name = "lblExchangeRate";
            // 
            // lblOrderCount
            // 
            lblOrderCount.AutoSize = true;
            lblOrderCount.Location = new Point(15, 102);
            lblOrderCount.Text = "Tổng đơn hàng mới: 0";
            lblOrderCount.Name = "lblOrderCount";
            // 
            // dgvOrders
            // 
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(15, 130);
            dgvOrders.Size = new Size(404, 390);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.TabIndex = 6;
            // 
            // frmAsyncReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 560);
            Name = "frmAsyncReport";
            Text = "Báo cáo thống kê & Đồng bộ";
            Controls.Add(grpSync);
            Controls.Add(grpReport);
            ((System.ComponentModel.ISupportInitialize)dgvRevenue).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            grpReport.ResumeLayout(false);
            grpReport.PerformLayout();
            grpSync.ResumeLayout(false);
            grpSync.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpReport;
        private Button btnLoadReport;
        private Label lblReportStatus;
        private DataGridView dgvRevenue;
        private GroupBox grpSync;
        private Button btnStartSync;
        private Button btnStopSync;
        private Label lblExchangeRate;
        private Label lblOrderCount;
        private DataGridView dgvOrders;
    }
}
