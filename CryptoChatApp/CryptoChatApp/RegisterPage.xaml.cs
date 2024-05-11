using CryptoChatApp.ViewModels;

namespace CryptoChatApp;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
		BindingContext = new RegisterViewModel(Navigation);

    }
}