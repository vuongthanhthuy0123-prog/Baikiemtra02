using Bai2_QuanLyKho;

namespace Bai3_MdiSieuThi;

/// <summary>
/// Form con 1: kế thừa toàn bộ giao diện + chức năng của Bài 2 (frmInventoryManager).
/// Khi chạy trong MDI, MenuStrip của form này tự gộp vào thanh menu của frmMain.
/// </summary>
public class frmProductCatalog : frmInventoryManager
{
    public frmProductCatalog()
    {
        Text = "Danh mục sản phẩm";
    }
}
