using PointOfSale.Services;

namespace PointOfSale.Pages.Handheld;

public partial class ReceiptPage : ContentPage
{
	public ReceiptPage()
	{
		InitializeComponent();
	}

	private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		
		PosPrinter printer = new PosPrinter();
		printer.Print("test", "1", "100");
		DisplayAlert("Print", "Printing sucessfully", "ok");
	}
}
