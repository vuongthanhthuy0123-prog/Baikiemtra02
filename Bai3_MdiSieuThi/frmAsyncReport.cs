using System.Diagnostics;

namespace Bai3_MdiSieuThi;

public record RevenueRow(string Month, decimal Revenue, int Orders, decimal AvgOrder);

public partial class frmAsyncReport : Form
{
    private CancellationTokenSource? _syncCts;
    private int _totalOrders;

    private frmMain? MainForm => MdiParent as frmMain;

    public frmAsyncReport()
    {
        InitializeComponent();
        Load += frmAsyncReport_Load;
        btnLoadReport.Click += btnLoadReport_Click;
        btnStartSync.Click += btnStartSync_Click;
        btnStopSync.Click += (s, e) => _syncCts?.Cancel();
        FormClosing += (s, e) => _syncCts?.Cancel();   // đóng form -> dừng thread nền
    }

    private void frmAsyncReport_Load(object? sender, EventArgs e)
    {
        // Grid doanh thu
        dgvRevenue.AutoGenerateColumns = false;
        dgvRevenue.ReadOnly = true;
        dgvRevenue.AllowUserToAddRows = false;
        dgvRevenue.RowHeadersVisible = false;
        dgvRevenue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvRevenue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvRevenue.Columns.Add(CreateColumn(nameof(RevenueRow.Month), "Tháng", 20, null));
        dgvRevenue.Columns.Add(CreateColumn(nameof(RevenueRow.Revenue), "Doanh thu", 35, "N0"));
        dgvRevenue.Columns.Add(CreateColumn(nameof(RevenueRow.Orders), "Số đơn", 20, "N0"));
        dgvRevenue.Columns.Add(CreateColumn(nameof(RevenueRow.AvgOrder), "TB/đơn", 25, "N0"));

        // Grid đơn hàng đồng bộ (unbound)
        dgvOrders.ReadOnly = true;
        dgvOrders.AllowUserToAddRows = false;
        dgvOrders.RowHeadersVisible = false;
        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvOrders.Columns.Add("colTime", "Thời điểm");
        dgvOrders.Columns.Add("colNewOrders", "Đơn mới");
        dgvOrders.Columns.Add("colRate", "Tỷ giá USD");
    }

    private static DataGridViewTextBoxColumn CreateColumn(string property, string header, float weight, string? format)
    {
        var col = new DataGridViewTextBoxColumn
        {
            DataPropertyName = property,
            HeaderText = header,
            FillWeight = weight
        };
        if (format != null)
        {
            col.DefaultCellStyle.Format = format;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        return col;
    }

    // ===== Scenario B: async/await + Task.Run =====
    private async void btnLoadReport_Click(object? sender, EventArgs e)
    {
        var main = MainForm;
        btnLoadReport.Enabled = false;
        lblReportStatus.Text = "Đang tải dữ liệu...";
        main?.BeginProgress("Đang tải báo cáo doanh thu...");

        // Progress<T> tự động gọi callback trên UI Thread
        var progress = new Progress<int>(p =>
        {
            main?.ReportProgress(p);
            if (!IsDisposed) lblReportStatus.Text = $"Đang xử lý... {p}%";
        });

        var sw = Stopwatch.StartNew();
        try
        {
            // Đẩy việc nặng xuống Thread phụ, UI Thread được giải phóng ngay
            List<RevenueRow> data = await Task.Run(() => BuildRevenueReportAsync(progress));

            if (IsDisposed) return;   // người dùng đã đóng form trong lúc chờ
            dgvRevenue.DataSource = data;
            lblReportStatus.Text = $"Hoàn tất trong {sw.Elapsed.TotalSeconds:N1} giây";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tải báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            main?.EndProgress();
            if (!IsDisposed) btnLoadReport.Enabled = true;
        }
    }

    // Chạy trên Thread phụ: KHÔNG chạm vào bất kỳ Control nào ở đây
    private static async Task<List<RevenueRow>> BuildRevenueReportAsync(IProgress<int> progress)
    {
        var rnd = new Random();
        var result = new List<RevenueRow>();

        for (int month = 1; month <= 12; month++)
        {
            await Task.Delay(250);            // giả lập truy vấn CSDL (12 x 250ms ≈ 3 giây)

            decimal revenue = 0;
            int orders = 0;
            for (int i = 0; i < 300_000; i++) // giả lập tính toán khối lượng lớn
            {
                if (rnd.Next(100) < 3)
                {
                    orders++;
                    revenue += rnd.Next(50_000, 5_000_000);
                }
            }

            result.Add(new RevenueRow($"Tháng {month:D2}", revenue, orders,
                                      orders == 0 ? 0 : Math.Round(revenue / orders)));
            progress.Report(month * 100 / 12);
        }
        return result;
    }

    // ===== Scenario C: tiến trình nền + cập nhật UI an toàn =====
    private async void btnStartSync_Click(object? sender, EventArgs e)
    {
        _syncCts = new CancellationTokenSource();
        var token = _syncCts.Token;
        btnStartSync.Enabled = false;
        btnStopSync.Enabled = true;

        try
        {
            await Task.Run(() => SyncLoop(token));
        }
        finally
        {
            _syncCts?.Dispose();
            _syncCts = null;
            if (!IsDisposed)
            {
                btnStartSync.Enabled = true;
                btnStopSync.Enabled = false;
            }
        }
    }

    // Thread phụ: lặp mỗi 2 giây
    private void SyncLoop(CancellationToken token)
    {
        var rnd = new Random();
        decimal rate = 25_400m;

        // WaitOne(2000): chờ 2 giây, trả về true ngay khi bị Cancel -> thoát vòng lặp
        while (!token.WaitHandle.WaitOne(2000))
        {
            rate += rnd.Next(-30, 31);
            int newOrders = rnd.Next(0, 8);

            // SAI: lblExchangeRate.Text = ...  (truy cập Control từ Thread phụ -> InvalidOperationException)
            // ĐÚNG: chuyển về UI Thread
            UpdateSyncUI(DateTime.Now, newOrders, rate);
        }
    }

    private void UpdateSyncUI(DateTime time, int newOrders, decimal rate)
    {
        if (IsDisposed || !IsHandleCreated) return;

        if (InvokeRequired)   // đang ở Thread phụ
        {
            try { Invoke(new Action(() => UpdateSyncUI(time, newOrders, rate))); }
            catch (ObjectDisposedException) { }
            catch (InvalidOperationException) { }   // form vừa bị đóng
            return;
        }

        // Từ đây trở xuống chắc chắn chạy trên UI Thread
        _totalOrders += newOrders;
        lblExchangeRate.Text = $"Tỷ giá USD/VND: {rate:N0}";
        lblOrderCount.Text = $"Tổng đơn hàng mới: {_totalOrders:N0}";
        dgvOrders.Rows.Insert(0, time.ToString("HH:mm:ss"), newOrders, rate.ToString("N0"));
        if (dgvOrders.Rows.Count > 100) dgvOrders.Rows.RemoveAt(dgvOrders.Rows.Count - 1);

        MainForm?.SetSyncStatus($"Đồng bộ lúc {time:HH:mm:ss}: {newOrders} đơn mới");
    }
}
