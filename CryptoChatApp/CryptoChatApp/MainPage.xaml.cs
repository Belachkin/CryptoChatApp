using CryptoChatApp.ViewModels;

namespace CryptoChatApp
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
        }
  
    }

}
