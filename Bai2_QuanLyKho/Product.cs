using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Bai2_QuanLyKho;

public class Product : INotifyPropertyChanged
{
    private string _productId = "";
    private string _productName = "";
    private string _category = "";
    private decimal _price;
    private int _quantity;
    private string _imagePath = "";

    public string ProductId   { get => _productId;   set => SetField(ref _productId, value); }
    public string ProductName { get => _productName; set => SetField(ref _productName, value); }
    public string Category    { get => _category;    set => SetField(ref _category, value); }

    public decimal Price
    {
        get => _price;
        set { if (SetField(ref _price, value)) OnPropertyChanged(nameof(TotalValue)); }
    }

    public int Quantity
    {
        get => _quantity;
        set { if (SetField(ref _quantity, value)) OnPropertyChanged(nameof(TotalValue)); }
    }

    // Chỉ lưu ĐƯỜNG DẪN ảnh, không lưu ảnh vào đối tượng
    public string ImagePath
    {
        get => _imagePath;
        set { if (SetField(ref _imagePath, value ?? "")) OnPropertyChanged(nameof(ImageFileName)); }
    }

    [JsonIgnore] public decimal TotalValue => Price * Quantity;
    [JsonIgnore] public string ImageFileName => string.IsNullOrEmpty(ImagePath) ? "" : Path.GetFileName(ImagePath);

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? name = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(name ?? "");
        return true;
    }
}
