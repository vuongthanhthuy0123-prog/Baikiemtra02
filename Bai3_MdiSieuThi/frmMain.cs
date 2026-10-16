namespace Bai3_MdiSieuThi;

public partial class frmMain : Form
{
    private string? _currentUser = "admin";
    private int _busyCount;   // số tác vụ nặng đang chạy dùng chung ProgressBar

    public frmMain()
    {
        InitializeComponent();

        Load += (s, e) => UpdateLoginState();
        FormClosing += frmMain_FormClosing;

        mnuLogout.Click += mnuLogout_Click;
        mnuExit.Click += (s, e) => Close();

        mnuProducts.Click += (s, e) => OpenChildForm<frmProductCatalog>();
        mnuStock.Click += (s, e) => OpenChildForm<frmImportExport>();
        mnuRevenue.Click += (s, e) => OpenChildForm<frmAsyncReport>();

        mnuCascade.Click += (s, e) => LayoutMdi(MdiLayout.Cascade);
        mnuTileHorizontal.Click += (s, e) => LayoutMdi(MdiLayout.TileHorizontal);
        mnuTileVertical.Click += (s, e) => LayoutMdi(MdiLayout.TileVertical);
    }

    // ===== Scenario A: mở Form con, nếu đã mở thì Activate() =====
    private void OpenChildForm<T>() where T : Form, new()
    {
        T? existing = MdiChildren.OfType<T>().FirstOrDefault();
        if (existing != null)
        {
            if (existing.WindowState == FormWindowState.Minimized)
                existing.WindowState = FormWindowState.Normal;
            existing.Activate();                 // đã mở -> mang lên trước
            return;
        }

        var child = new T { MdiParent = this };  // chưa mở -> tạo Instance mới
        child.Show();
    }

    // ===== Đăng nhập / Đăng xuất =====
    private void mnuLogout_Click(object? sender, EventArgs e)
    {
        if (_currentUser == null)            // đang đăng xuất -> đăng nhập lại
        {
            _currentUser = "admin";
            UpdateLoginState();
            return;
        }

        if (MessageBox.Show("Đăng xuất sẽ đóng tất cả cửa sổ đang mở. Tiếp tục?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

        foreach (Form f in MdiChildren) f.Close();
        if (MdiChildren.Length > 0) return;  // có form không cho đóng

        _currentUser = null;
        UpdateLoginState();
    }

    private void UpdateLoginState()
    {
        bool loggedIn = _currentUser != null;
        lblUser.Text = loggedIn ? $"Người dùng: {_currentUser}" : "Chưa đăng nhập";
        mnuLogout.Text = loggedIn ? "Đăng xuất" : "Đăng nhập";
        mnuCatalog.Enabled = loggedIn;
        mnuReport.Enabled = loggedIn;
    }

    // ===== API cho Form con dùng chung ProgressBar (gọi trên UI thread) =====
    public void BeginProgress(string message)
    {
        _busyCount++;
        prgLoading.Value = 0;
        prgLoading.Visible = true;
        lblMessage.Text = message;
    }

    public void ReportProgress(int percent) =>
        prgLoading.Value = Math.Clamp(percent, prgLoading.Minimum, prgLoading.Maximum);

    public void EndProgress()
    {
        _busyCount = Math.Max(0, _busyCount - 1);
        if (_busyCount == 0)
        {
            prgLoading.Visible = false;
            lblMessage.Text = "Sẵn sàng";
        }
    }

    // Có thể gọi từ bất kỳ Thread nào: tự chuyển về UI Thread
    public void SetSyncStatus(string text)
    {
        if (IsDisposed) return;
        if (InvokeRequired)
        {
            BeginInvoke(new Action(() => SetSyncStatus(text)));
            return;
        }
        lblSync.Text = text;
    }

    private void frmMain_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (e.CloseReason != CloseReason.UserClosing) return;
        if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            e.Cancel = true;
    }
}
