
namespace ImageViewer.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    private void Button_Clicked(object sender, EventArgs e)
	{
		DateTime expiry = new DateTime(2026, 6, 15, 10, 0, 0);
		if(DateTime.Now< expiry && usernameEntry.Text == "1admin" && passwordEntry.Text == "password")
			Shell.Current.GoToAsync("xrayview");
		else
			DisplayAlert("License Expired", "Your license to use this application has expired. Please contact support.", "OK");
	}
}
