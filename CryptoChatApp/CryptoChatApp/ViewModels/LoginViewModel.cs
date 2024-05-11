using CryptoChatApp.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChatApp.ViewModels
{
    class LoginViewModel
    {
        public string webAPIKey = APIKeys.LoginWebAPIKey;
        public LoginViewModel(INavigation navigation) 
        {
            this._navigation = navigation;
            RegisterBtn = new Command(RegisterBtnTappedAsync);
            LoginBtn = new Command(LoginBtnTappedAsunc);
        }

        private INavigation _navigation;

        public Command RegisterBtn {  get;}
        public Command LoginBtn { get;}

        private async void RegisterBtnTappedAsync(object obj)
        {
            await this._navigation.PushAsync(new RegisterPage());
        }
        private async void LoginBtnTappedAsunc(object obj)
        {
            await this._navigation.PushAsync(new Dashboard());
        }

    }
}
