using System.ComponentModel;
using System.Globalization;

namespace Bai1_QuanLyThietBi;

public partial class frmDeviceManager : Form
{
    private readonly BindingList<Device> _devices = new();
    private readonly BindingSource _bsDevices = new();
    private static readonly CultureInfo VnCulture = new("vi-VN");

    public frmDeviceManager()
    {
        InitializeComponent();

        // Gắn sự kiện bằng code (không cần double-click trên Designer)
        Load += frmDeviceManager_Load;
        btnAdd.Click += btnAdd_Click;
        btnUpdate.Click += btnUpdate_Click;
        btnDelete.Click += btnDelete_Click;
        btnClear.Click += btnClear_Click;
        dgvDevices.CellClick += dgvDevices_CellClick;

        // Hiện icon cảnh báo ngay khi rời khỏi ô nhập
        txtDeviceName.Validating += (s, e) => ValidateDeviceName();
        cboCategory.Validating += (s, e) => ValidateCategory();
        txtPrice.Validating += (s, e) => ValidatePrice(out _);
    }

    // ================= KHỞI TẠO =================
    private void frmDeviceManager_Load(object? sender, EventArgs e)
    {
        cboCategory.Items.AddRange(new object[] { "Điện thoại", "Laptop", "Máy tính bảng", "Tivi", "Phụ kiện" });

        SetupGridColumns();

        _bsDevices.DataSource = _devices;      // BindingList -> BindingSource
        dgvDevices.DataSource = _bsDevices;    // BindingSource -> DataGridView
        BindInputControls();                   // BindingSource -> các control nhập liệu

        ClearInput();                          // danh sách rỗng, form trống để người dùng tự nhập
    }

    /// <summary>Cấu hình DataGridView và tạo cột hoàn toàn bằng code.</summary>
    private void SetupGridColumns()
    {
        dgvDevices.AutoGenerateColumns = false;
        dgvDevices.Columns.Clear();
        dgvDevices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDevices.MultiSelect = false;
        dgvDevices.ReadOnly = true;
        dgvDevices.AllowUserToAddRows = false;
        dgvDevices.AllowUserToDeleteRows = false;
        dgvDevices.AllowUserToResizeRows = false;
        dgvDevices.RowHeadersVisible = false;
        dgvDevices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvDevices.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDevices.Font, FontStyle.Bold);
        dgvDevices.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

        // FillWeight = tỷ lệ độ rộng tương đối giữa các cột
        dgvDevices.Columns.Add(CreateColumn("colDeviceId", nameof(Device.DeviceId), "Mã thiết bị", 12));
        dgvDevices.Columns.Add(CreateColumn("colDeviceName", nameof(Device.DeviceName), "Tên thiết bị", 38));
        dgvDevices.Columns.Add(CreateColumn("colCategory", nameof(Device.Category), "Loại", 18));

        var colPrice = CreateColumn("colPrice", nameof(Device.Price), "Đơn giá", 20,
                                    DataGridViewContentAlignment.MiddleRight);
        colPrice.DefaultCellStyle.Format = "C0";              // định dạng tiền tệ
        colPrice.DefaultCellStyle.FormatProvider = VnCulture; // 15.000.000 ₫
        dgvDevices.Columns.Add(colPrice);

        var colQty = CreateColumn("colQuantity", nameof(Device.Quantity), "Số lượng", 12,
                                  DataGridViewContentAlignment.MiddleRight);
        colQty.DefaultCellStyle.Format = "N0";
        dgvDevices.Columns.Add(colQty);
    }

    private static DataGridViewTextBoxColumn CreateColumn(string name, string property, string header,
        float fillWeight, DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft)
    {
        var col = new DataGridViewTextBoxColumn
        {
            Name = name,
            DataPropertyName = property,
            HeaderText = header,
            FillWeight = fillWeight
        };
        col.DefaultCellStyle.Alignment = align;
        return col;
    }

    private void BindInputControls()
    {
        // Chiều Nguồn -> Control: tự động khi đổi dòng.
        // Chiều Control -> Nguồn: chỉ ghi khi bấm "Cập nhật" (WriteValue),
        // tránh việc gõ thử làm hỏng dữ liệu và cho phép dùng chung ô nhập cho "Thêm mới".
        const DataSourceUpdateMode mode = DataSourceUpdateMode.Never;
        txtDeviceId.DataBindings.Add("Text", _bsDevices, nameof(Device.DeviceId), true, mode);
        txtDeviceName.DataBindings.Add("Text", _bsDevices, nameof(Device.DeviceName), true, mode);
        cboCategory.DataBindings.Add("SelectedItem", _bsDevices, nameof(Device.Category), true, mode);
        txtPrice.DataBindings.Add("Text", _bsDevices, nameof(Device.Price), true, mode);
        numQuantity.DataBindings.Add("Value", _bsDevices, nameof(Device.Quantity), true, mode);
    }

    private string GenerateNextId()
    {
        int max = 0;
        foreach (var d in _devices)
            if (d.DeviceId.StartsWith("TB") && int.TryParse(d.DeviceId[2..], out int n) && n > max)
                max = n;
        return $"TB{max + 1:D3}";
    }

    // ================= VALIDATION =================
    private bool ValidateDeviceName()
    {
        bool ok = !string.IsNullOrWhiteSpace(txtDeviceName.Text);
        errProvider.SetError(txtDeviceName, ok ? "" : "Tên thiết bị không được để trống.");
        return ok;
    }

    private bool ValidateCategory()
    {
        bool ok = cboCategory.SelectedIndex >= 0;
        errProvider.SetError(cboCategory, ok ? "" : "Vui lòng chọn loại thiết bị.");
        return ok;
    }

    private bool ValidatePrice(out decimal price)
    {
        bool ok = decimal.TryParse(txtPrice.Text.Trim(), NumberStyles.Number,
                                   CultureInfo.CurrentCulture, out price) && price >= 0;
        errProvider.SetError(txtPrice, ok ? "" : "Đơn giá phải là số hợp lệ và không nhỏ hơn 0.");
        return ok;
    }

    private bool ValidateInput(out decimal price)
    {
        bool okName = ValidateDeviceName();
        bool okCategory = ValidateCategory();
        bool okPrice = ValidatePrice(out price);
        return okName && okCategory && okPrice;
    }

    // ================= CHỨC NĂNG =================
    private void btnAdd_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput(out decimal price)) return;

        var device = new Device
        {
            DeviceId = GenerateNextId(),
            DeviceName = txtDeviceName.Text.Trim(),
            Category = cboCategory.SelectedItem?.ToString() ?? "",
            Price = price,
            Quantity = (int)numQuantity.Value
        };

        _devices.Add(device);                             // BindingList báo ngay cho Grid, không cần nạp lại
        _bsDevices.Position = _bsDevices.IndexOf(device); // chọn dòng vừa thêm
        MessageBox.Show("Đã thêm thiết bị mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnUpdate_Click(object? sender, EventArgs e)
    {
        if (dgvDevices.SelectedRows.Count == 0 || _bsDevices.Current is not Device)
        {
            MessageBox.Show("Vui lòng chọn thiết bị cần cập nhật trên danh sách.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (!ValidateInput(out decimal price)) return;

        txtPrice.Text = price.ToString(CultureInfo.CurrentCulture); // chuẩn hóa chuỗi số trước khi ghi

        // Đẩy giá trị từ Control xuống đối tượng (chiều thứ 2 của binding)
        foreach (Control c in new Control[] { txtDeviceName, cboCategory, txtPrice, numQuantity })
            foreach (Binding b in c.DataBindings)
                b.WriteValue();

        _bsDevices.ResetCurrentItem();
        MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnDelete_Click(object? sender, EventArgs e)
    {
        if (dgvDevices.SelectedRows.Count == 0 || _bsDevices.Current is not Device device)
        {
            MessageBox.Show("Vui lòng chọn thiết bị cần xóa.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa thiết bị \"{device.DeviceName}\"?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

        if (result == DialogResult.Yes)
        {
            _bsDevices.Remove(device);
            if (_bsDevices.Count == 0) ClearInput();
        }
    }

    private void btnClear_Click(object? sender, EventArgs e) => ClearInput();

    private void ClearInput()
    {
        errProvider.Clear();
        txtDeviceId.Text = GenerateNextId();   // xem trước mã sẽ được cấp
        txtDeviceName.Clear();
        cboCategory.SelectedIndex = -1;
        txtPrice.Clear();
        numQuantity.Value = 0;
        dgvDevices.ClearSelection();           // về chế độ "thêm mới"
        txtDeviceName.Focus();
    }

    private void dgvDevices_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || _bsDevices.Current == null) return;
        errProvider.Clear();
        _bsDevices.ResetCurrentItem();  // đổ lại dữ liệu dòng đang chọn lên các control
    }
}
