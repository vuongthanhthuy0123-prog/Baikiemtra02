# BÁO CÁO BÀI TẬP / ĐỒ ÁN

## THÔNG TIN SINH VIÊN

- **Họ và tên:** Vương Thanh Thúy
- **Mã số sinh viên:** 24810310270
- **Lớp:** D19CNPM3
- **Tên môn học:** Lập trình .Net
- **Tên bài tập:** Bài kiểm tra 02 – Windows Forms (Bài 1, Bài 2, Bài 3)

---

## KẾT QUẢ THỰC HÀNH

### 1. Ảnh màn hình Giao diện chính
![Giao diện chính](./screenshots/main_ui.png)

### 2. Ảnh màn hình Chức năng thực thi / Kết quả
![Thực thi chức năng](./screenshots/execution_result.png)

### 3. Ảnh màn hình Kiểm tra lỗi (Validation)
![Kiểm tra lỗi](./screenshots/validation_error.png)

---

## HƯỚNG DẪN CHẠY PROJECT

### Cách mở và chạy
1. Cài Visual Studio 2022 với workload **.NET desktop development** (có .NET 8 SDK).
2. Giải nén, double-click `Test02.sln`.
3. Chuột phải project muốn chạy → **Set as Startup Project** → nhấn **F5**.

| Project | Form chính | Nội dung |
|---|---|---|
| Bai1_QuanLyThietBi | frmDeviceManager | DataGridView cấu hình bằng code, BindingSource + BindingList<T>, ErrorProvider |
| Bai2_QuanLyKho | frmInventoryManager | MenuStrip, ToolStrip, StatusStrip, OpenFileDialog, SaveFileDialog, CSV/JSON/TXT, PictureBox |
| Bai3_MdiSieuThi | frmMain (MDI) | Form con frmProductCatalog (kế thừa Bài 2), frmAsyncReport (async/await, Invoke), frmImportExport |

Bài 3 đã có sẵn Project Reference tới Bài 2 để kế thừa form.

### Cấu trúc file mỗi Form
- `frmXxx.Designer.cs`: phần giao diện (control, vị trí, thuộc tính) – mở bằng `frmXxx.cs [Design]` để xem/sửa bằng kéo thả.
- `frmXxx.cs`: phần code xử lý. Mọi sự kiện được gắn trong constructor, **không double-click control** trên Designer.

### Ghi chú
- Icon trên ToolStrip/Menu của Bài 2 được vẽ bằng code từ font hệ thống *Segoe MDL2 Assets* (có sẵn trên Windows 10/11).
  Muốn dùng ảnh riêng: chọn nút trên Designer → thuộc tính **Image** → Import, rồi xóa hàm `SetupIcons()` trong code.
- Nếu đổi tên project/namespace, phải sửa dòng `namespace ...` ở cả file `.cs` và `.Designer.cs` cho khớp.
