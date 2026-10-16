using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bai1_QuanLyThietBi;

public class Device : INotifyPropertyChanged
{
    private string _deviceId = "";
    private string _deviceName = "";
    private string _category = "";
    private decimal _price;
    private int _quantity;

    public string DeviceId   { get => _deviceId;   set => SetField(ref _deviceId, value); }
    public string DeviceName { get => _deviceName; set => SetField(ref _deviceName, value); }
    public string Category   { get => _category;   set => SetField(ref _category, value); }
    public decimal Price     { get => _price;      set => SetField(ref _price, value); }
    public int Quantity      { get => _quantity;   set => SetField(ref _quantity, value); }

    // Báo cho BindingList/DataGridView biết khi thuộc tính thay đổi -> Grid tự cập nhật
    public event PropertyChangedEventHandler? PropertyChanged;

    private void SetField<T>(ref T field, T value, [CallerMemberName] string? name = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return;
        field = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
