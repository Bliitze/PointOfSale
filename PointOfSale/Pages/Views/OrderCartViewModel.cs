using PointOfSale.Services;
using System;
namespace PointOfSale.Pages.Views;

[INotifyPropertyChanged]
public partial class OrderCartViewModel
{
    [ObservableProperty]
    Order order;

    public OrderCartViewModel()
    {
        Order = AppData.Orders.First();
        App.order = Order;

    }

    [RelayCommand]
    async Task PlaceOrder()
    {
        PosPrinter printer = new PosPrinter();
        await printer.PrintPlacedOrder();
        
        await App.Current.MainPage.DisplayAlert("Printing order", "Placed order", "Okay");
    }
}