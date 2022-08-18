using ZXing.OneD.RSS.Expanded.Decoders;

namespace PointOfSale.Pages.Handheld;

[INotifyPropertyChanged]
[QueryProperty("Order","Order")]
public partial class ReceiptViewModel
{
    [ObservableProperty]
    Order order;
    bool IsPrintReceipt = false;
    public  ReceiptViewModel()
    {
        order = new Order();
        
    }
[RelayCommand]
    async void Done()
    {
        await Shell.Current.GoToAsync("///orders");
    }
}
