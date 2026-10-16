using System.ComponentModel;
using System.Drawing.Text;
using System.Globalization;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Bai2_QuanLyKho;

public partial class frmInventoryManager : Form
{
    private const char CsvSeparator = ';';
    private static readonly CultureInfo VnCulture = new("vi-VN");

    private readonly BindingList<Product> _products = new();
    private readonly BindingSource _bsProducts = new();
    private string _imagePath = "";   // đường dẫn ảnh đang hiển thị trên PictureBox

    public frmInventoryManager()
    {
        InitializeComponent();
        SetupIcons();

        Load += frmInventoryManager_Load;
        FormClosing += frmInventoryManager_FormClosing;

        // MenuStrip
        mnuOpenFile.Click += mnuOpenFile_Click;
        mnuSaveReport.Click += mnuSaveReport_Click;
        mnuExit.Click += (s, e) => Close();
        mnuImportCsv.Click += mnuImportCsv_Click;
        mnuExportCsv.Click += mnuExportCsv_Click;

        // ToolStrip dùng chung hàm xử lý với MenuStrip
        tsbOpen.Click += mnuOpenFile_Click;
        tsbSave.Click += mnuSaveReport_Click;
        tsbImport.Click += mnuImportCsv_Click;
        tsbExport.Click += mnuExportCsv_Click;
        tsbExit.Click += (s, e) => Close();

        btnChooseImage.Click += btnChooseImage_Click;
        btnAdd.Click += btnAdd_Click;
        btnUpdate.Click += btnUpdate_Click;
        btnDelete.Click += btnDelete_Click;
        btnClear.Click += (s, e) => ClearInput();
        dgvProducts.CellClick += dgvProducts_CellClick;
        tmrClock.Tick += (s, e) => lblClock.Text = DateTime.Now.ToString("HH:mm:ss  dd/MM/yyyy");

        txtProductName.Validating += (s, e) => ValidateProductName();
        cboCategory.Validating += (s, e) => ValidateCategory();
        txtPrice.Validating += (s, e) => ValidatePrice(out _);
    }

    // ================= ICON =================
    // Vẽ icon 16x16 từ font biểu tượng có sẵn của Windows (Segoe MDL2 Assets),
    // nên không cần file ảnh ngoài. Có thể thay bằng ảnh riêng qua thuộc tính Image trên Designer.
    private void SetupIcons()
    {
        var open = CreateGlyphIcon('\uE8E5', Color.DarkGoldenrod);
        var save = CreateGlyphIcon('\uE74E', Color.SteelBlue);
        var import = CreateGlyphIcon('\uE896', Color.SeaGreen);
        var export = CreateGlyphIcon('\uE898', Color.DarkOrange);
        var exit = CreateGlyphIcon('\uE7E8', Color.Firebrick);

        tsbOpen.Image = open;     mnuOpenFile.Image = open;
        tsbSave.Image = save;     mnuSaveReport.Image = save;
        tsbImport.Image = import; mnuImportCsv.Image = import;
        tsbExport.Image = export; mnuExportCsv.Image = export;
        tsbExit.Image = exit;     mnuExit.Image = exit;
    }

    private static Bitmap CreateGlyphIcon(char glyph, Color color)
    {
        var bmp = new Bitmap(16, 16);
        using var g = Graphics.FromImage(bmp);
        g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        using var font = new Font("Segoe MDL2 Assets", 11f, FontStyle.Regular, GraphicsUnit.Pixel);
        using var brush = new SolidBrush(color);
        using var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        g.DrawString(glyph.ToString(), font, brush, new RectangleF(0, 0, 16, 16), sf);
        return bmp;
    }

    // ================= KHỞI TẠO =================
    private void frmInventoryManager_Load(object? sender, EventArgs e)
    {
        cboCategory.Items.AddRange(new object[] { "Điện thoại", "Laptop", "Máy tính bảng", "Tivi", "Phụ kiện" });
        SetupGridColumns();

        _products.ListChanged += (s, ev) => UpdateStatusBar();          // Thêm/Sửa/Xóa/Import đều đi qua đây
        _bsProducts.CurrentItemChanged += (s, ev) => ShowCurrentProductImage();

        _bsProducts.DataSource = _products;
        dgvProducts.DataSource = _bsProducts;
        BindInputControls();

        UpdateStatusBar();
        ClearInput();                          // danh sách rỗng, form trống để người dùng tự nhập
        lblClock.Text = DateTime.Now.ToString("HH:mm:ss  dd/MM/yyyy");
        tmrClock.Start();
    }

    private void SetupGridColumns()
    {
        dgvProducts.AutoGenerateColumns = false;
        dgvProducts.Columns.Clear();
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.MultiSelect = false;
        dgvProducts.ReadOnly = true;
        dgvProducts.AllowUserToAddRows = false;
        dgvProducts.AllowUserToDeleteRows = false;
        dgvProducts.AllowUserToResizeRows = false;
        dgvProducts.RowHeadersVisible = false;
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font(dgvProducts.Font, FontStyle.Bold);
        dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

        var right = DataGridViewContentAlignment.MiddleRight;
        dgvProducts.Columns.Add(CreateColumn("colId", nameof(Product.ProductId), "Mã SP", 9));
        dgvProducts.Columns.Add(CreateColumn("colName", nameof(Product.ProductName), "Tên sản phẩm", 27));
        dgvProducts.Columns.Add(CreateColumn("colCategory", nameof(Product.Category), "Loại", 13));
        dgvProducts.Columns.Add(CreateColumn("colPrice", nameof(Product.Price), "Đơn giá", 14, right, "C0"));
        dgvProducts.Columns.Add(CreateColumn("colQty", nameof(Product.Quantity), "SL", 7, right, "N0"));
        dgvProducts.Columns.Add(CreateColumn("colTotal", nameof(Product.TotalValue), "Thành tiền", 15, right, "C0"));
        // Chỉ hiển thị TÊN FILE ảnh, không nạp ảnh vào Grid để tránh giảm hiệu năng
        dgvProducts.Columns.Add(CreateColumn("colImage", nameof(Product.ImageFileName), "Ảnh", 15));
    }

    private static DataGridViewTextBoxColumn CreateColumn(string name, string property, string header,
        float fillWeight, DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft,
        string? format = null)
    {
        var col = new DataGridViewTextBoxColumn
        {
            Name = name,
            DataPropertyName = property,
            HeaderText = header,
            FillWeight = fillWeight
        };
        col.DefaultCellStyle.Alignment = align;
        if (format != null)
        {
            col.DefaultCellStyle.Format = format;
            col.DefaultCellStyle.FormatProvider = VnCulture;
        }
        return col;
    }

    private void BindInputControls()
    {
        const DataSourceUpdateMode mode = DataSourceUpdateMode.Never;
        txtProductId.DataBindings.Add("Text", _bsProducts, nameof(Product.ProductId), true, mode);
        txtProductName.DataBindings.Add("Text", _bsProducts, nameof(Product.ProductName), true, mode);
        cboCategory.DataBindings.Add("SelectedItem", _bsProducts, nameof(Product.Category), true, mode);
        txtPrice.DataBindings.Add("Text", _bsProducts, nameof(Product.Price), true, mode);
        numQuantity.DataBindings.Add("Value", _bsProducts, nameof(Product.Quantity), true, mode);
    }

    private string GenerateNextId()
    {
        int max = 0;
        foreach (var p in _products)
            if (p.ProductId.StartsWith("SP") && int.TryParse(p.ProductId[2..], out int n) && n > max)
                max = n;
        return $"SP{max + 1:D3}";
    }

    // ================= STATUS STRIP =================
    private void UpdateStatusBar()
    {
        int totalQty = _products.Sum(p => p.Quantity);
        decimal totalValue = _products.Sum(p => p.TotalValue);
        lblTotalQuantity.Text = $"Tổng số lượng: {totalQty:N0} ({_products.Count} mặt hàng)";
        lblTotalValue.Text = $"Tổng giá trị kho: {totalValue.ToString("C0", VnCulture)}";
    }

    // ================= HÌNH ẢNH (OpenFileDialog) =================
    private void btnChooseImage_Click(object? sender, EventArgs e)
    {
        if (ofdImage.ShowDialog(this) != DialogResult.OK) return;
        _imagePath = ofdImage.FileName;   // được lưu vào Product.ImagePath khi bấm Thêm/Cập nhật
        ShowImage(_imagePath);
    }

    private void ShowCurrentProductImage()
    {
        if (_bsProducts.Current is Product p)
        {
            _imagePath = p.ImagePath;
            ShowImage(_imagePath);
        }
    }

    private void ShowImage(string? path)
    {
        var old = picProductImage.Image;
        picProductImage.Image = null;
        old?.Dispose();

        if (string.IsNullOrWhiteSpace(path) || !File.Exists(path)) return;
        try
        {
            // Copy ảnh ra Bitmap mới để không khóa file gốc
            using var img = Image.FromFile(path);
            picProductImage.Image = new Bitmap(img);
        }
        catch
        {
            // file không phải ảnh hợp lệ -> bỏ qua
        }
    }

    // ================= VALIDATION =================
    private bool ValidateProductName()
    {
        bool ok = !string.IsNullOrWhiteSpace(txtProductName.Text);
        errProvider.SetError(txtProductName, ok ? "" : "Tên sản phẩm không được để trống.");
        return ok;
    }

    private bool ValidateCategory()
    {
        bool ok = cboCategory.SelectedIndex >= 0;
        errProvider.SetError(cboCategory, ok ? "" : "Vui lòng chọn loại sản phẩm.");
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
        bool a = ValidateProductName();
        bool b = ValidateCategory();
        bool c = ValidatePrice(out price);
        return a && b && c;
    }

    // ================= THÊM / SỬA / XÓA =================
    private void btnAdd_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput(out decimal price)) return;

        var product = new Product
        {
            ProductId = GenerateNextId(),
            ProductName = txtProductName.Text.Trim(),
            Category = cboCategory.SelectedItem?.ToString() ?? "",
            Price = price,
            Quantity = (int)numQuantity.Value,
            ImagePath = _imagePath
        };
        _products.Add(product);
        _bsProducts.Position = _bsProducts.IndexOf(product);
    }

    private void btnUpdate_Click(object? sender, EventArgs e)
    {
        if (dgvProducts.SelectedRows.Count == 0 || _bsProducts.Current is not Product p)
        {
            MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (!ValidateInput(out decimal price)) return;

        p.ImagePath = _imagePath;   // gán ảnh TRƯỚC khi WriteValue
        txtPrice.Text = price.ToString(CultureInfo.CurrentCulture);
        foreach (Control c in new Control[] { txtProductName, cboCategory, txtPrice, numQuantity })
            foreach (Binding b in c.DataBindings)
                b.WriteValue();

        _bsProducts.ResetCurrentItem();
        MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnDelete_Click(object? sender, EventArgs e)
    {
        if (dgvProducts.SelectedRows.Count == 0 || _bsProducts.Current is not Product p)
        {
            MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm \"{p.ProductName}\"?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        {
            _bsProducts.Remove(p);
            if (_bsProducts.Count == 0) ClearInput();
        }
    }

    private void ClearInput()
    {
        errProvider.Clear();
        txtProductId.Text = GenerateNextId();
        txtProductName.Clear();
        cboCategory.SelectedIndex = -1;
        txtPrice.Clear();
        numQuantity.Value = 0;
        _imagePath = "";
        ShowImage(null);
        dgvProducts.ClearSelection();
        txtProductName.Focus();
    }

    private void dgvProducts_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || _bsProducts.Current == null) return;
        errProvider.Clear();
        _bsProducts.ResetCurrentItem();
        ShowCurrentProductImage();
    }

    // Thay toàn bộ danh sách (dùng cho Import CSV / Open File)
    private void ReplaceAllProducts(IEnumerable<Product> items)
    {
        _products.RaiseListChangedEvents = false;
        _products.Clear();
        foreach (var p in items)
        {
            _products.Add(p);
            if (!string.IsNullOrEmpty(p.Category) && !cboCategory.Items.Contains(p.Category))
                cboCategory.Items.Add(p.Category);
        }
        _products.RaiseListChangedEvents = true;
        _products.ResetBindings();   // 1 sự kiện Reset -> Grid + StatusStrip cập nhật
        if (_products.Count == 0) ClearInput();
    }

    // ================= EXPORT CSV (SaveFileDialog) =================
    private void mnuExportCsv_Click(object? sender, EventArgs e)
    {
        using var sfd = new SaveFileDialog
        {
            Title = "Xuất danh sách sản phẩm ra CSV",
            Filter = "File CSV (*.csv)|*.csv",
            DefaultExt = "csv",
            AddExtension = true,
            OverwritePrompt = true,
            FileName = $"KhoHang_{DateTime.Now:yyyyMMdd_HHmm}.csv"
        };
        if (sfd.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Join(CsvSeparator, "MaSP", "TenSP", "Loai", "DonGia", "SoLuong", "DuongDanAnh"));
            foreach (var p in _products)
            {
                sb.AppendLine(string.Join(CsvSeparator,
                    CsvEscape(p.ProductId), CsvEscape(p.ProductName), CsvEscape(p.Category),
                    p.Price.ToString(CultureInfo.InvariantCulture),
                    p.Quantity.ToString(CultureInfo.InvariantCulture),
                    CsvEscape(p.ImagePath)));
            }
            // UTF-8 có BOM để Excel hiển thị đúng tiếng Việt
            File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
            MessageBox.Show($"Đã xuất {_products.Count} sản phẩm ra file:\n{sfd.FileName}", "Xuất CSV",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ================= IMPORT CSV (OpenFileDialog) =================
    private void mnuImportCsv_Click(object? sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog
        {
            Title = "Chọn file CSV cần nhập",
            Filter = "File CSV (*.csv)|*.csv|Tất cả file (*.*)|*.*"
        };
        if (ofd.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            string[] lines = File.ReadAllLines(ofd.FileName, Encoding.UTF8);
            if (lines.Length <= 1)
            {
                MessageBox.Show("File không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            char sep = lines[0].Contains(';') ? ';' : ',';   // tự nhận dấu phân cách từ dòng tiêu đề
            var imported = new List<Product>();
            int errorLines = 0;

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;
                var f = ParseCsvLine(lines[i], sep);

                if (f.Count < 5
                    || !decimal.TryParse(f[3], NumberStyles.Number, CultureInfo.InvariantCulture, out var price)
                    || !int.TryParse(f[4], NumberStyles.Integer, CultureInfo.InvariantCulture, out var qty)
                    || price < 0 || qty < 0 || qty > (int)numQuantity.Maximum)
                {
                    errorLines++;
                    continue;
                }

                imported.Add(new Product
                {
                    ProductId = f[0].Trim(),
                    ProductName = f[1].Trim(),
                    Category = f[2].Trim(),
                    Price = price,
                    Quantity = qty,
                    ImagePath = f.Count > 5 ? f[5].Trim() : ""
                });
            }

            ReplaceAllProducts(imported);
            MessageBox.Show($"Đã nhập {imported.Count} sản phẩm."
                            + (errorLines > 0 ? $"\nBỏ qua {errorLines} dòng sai định dạng." : ""),
                            "Nhập CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static string CsvEscape(string? value)
    {
        value ??= "";
        if (value.IndexOfAny(new[] { CsvSeparator, ',', '"', '\r', '\n' }) >= 0)
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        return value;
    }

    private static List<string> ParseCsvLine(string line, char sep)
    {
        var fields = new List<string>();
        var cur = new StringBuilder();
        bool inQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (inQuotes)
            {
                if (c == '"')
                {
                    if (i + 1 < line.Length && line[i + 1] == '"') { cur.Append('"'); i++; }
                    else inQuotes = false;
                }
                else cur.Append(c);
            }
            else if (c == '"') inQuotes = true;
            else if (c == sep) { fields.Add(cur.ToString()); cur.Clear(); }
            else cur.Append(c);
        }
        fields.Add(cur.ToString());
        return fields;
    }

    // ================= OPEN FILE (JSON) =================
    private void mnuOpenFile_Click(object? sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog
        {
            Title = "Mở file dữ liệu kho",
            Filter = "Dữ liệu JSON (*.json)|*.json"
        };
        if (ofd.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            string json = File.ReadAllText(ofd.FileName, Encoding.UTF8);
            var list = JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
            ReplaceAllProducts(list);
            MessageBox.Show($"Đã mở {list.Count} sản phẩm.", "Mở file", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("File không hợp lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // ================= SAVE REPORT (TXT hoặc JSON) =================
    private void mnuSaveReport_Click(object? sender, EventArgs e)
    {
        using var sfd = new SaveFileDialog
        {
            Title = "Lưu báo cáo tổng hợp",
            Filter = "Báo cáo văn bản (*.txt)|*.txt|Dữ liệu JSON (*.json)|*.json",
            DefaultExt = "txt",
            AddExtension = true,
            FileName = $"BaoCaoKho_{DateTime.Now:yyyyMMdd_HHmm}"
        };
        if (sfd.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            if (sfd.FilterIndex == 2)
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // giữ nguyên tiếng Việt
                };
                File.WriteAllText(sfd.FileName, JsonSerializer.Serialize(_products.ToList(), options), Encoding.UTF8);
            }
            else
            {
                File.WriteAllText(sfd.FileName, BuildTextReport(), new UTF8Encoding(true));
            }
            MessageBox.Show("Đã lưu: " + sfd.FileName, "Lưu báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private string BuildTextReport()
    {
        var sb = new StringBuilder();
        sb.AppendLine("BÁO CÁO TỔNG HỢP KHO HÀNG");
        sb.AppendLine($"Thời điểm lập: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
        sb.AppendLine(new string('=', 92));
        sb.AppendLine($"{"Mã",-8}{"Tên sản phẩm",-30}{"Loại",-16}{"SL",8}{"Đơn giá",14}{"Thành tiền",16}");
        sb.AppendLine(new string('-', 92));

        foreach (var p in _products)
        {
            string name = p.ProductName.Length > 28 ? p.ProductName[..28] : p.ProductName;
            sb.AppendLine($"{p.ProductId,-8}{name,-30}{p.Category,-16}{p.Quantity,8:N0}{p.Price,14:N0}{p.TotalValue,16:N0}");
        }

        sb.AppendLine(new string('-', 92));
        sb.AppendLine("TỔNG HỢP THEO LOẠI:");
        foreach (var g in _products.GroupBy(p => p.Category))
            sb.AppendLine($"  - {g.Key,-20}: {g.Sum(p => p.Quantity),8:N0} sản phẩm | {g.Sum(p => p.TotalValue),18:N0} đ");

        sb.AppendLine(new string('=', 92));
        sb.AppendLine($"Số mặt hàng     : {_products.Count}");
        sb.AppendLine($"Tổng số lượng   : {_products.Sum(p => p.Quantity):N0}");
        sb.AppendLine($"Tổng giá trị kho: {_products.Sum(p => p.TotalValue).ToString("C0", VnCulture)}");
        return sb.ToString();
    }

    // ================= THOÁT =================
    private void frmInventoryManager_FormClosing(object? sender, FormClosingEventArgs e)
    {
        // Khi Form cha MDI (Bài 3) đóng thì Form cha sẽ tự hỏi, không hỏi lại ở đây
        if (e.CloseReason is CloseReason.MdiFormClosing or CloseReason.WindowsShutDown) return;

        var r = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        if (r == DialogResult.No) e.Cancel = true;
    }
}
