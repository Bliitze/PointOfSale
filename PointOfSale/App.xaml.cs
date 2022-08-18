namespace PointOfSale;

public partial class App : Application
{
    public static Order order = new Order();
    public App()
	{
		InitializeComponent();

        App.Current.UserAppTheme = AppTheme.Dark;

        if (DeviceInfo.Idiom == DeviceIdiom.Phone)
        {
            MainPage = new AppShellMobile();
        }
        else
        {
            MainPage = new AppShell();
        }
	}
}