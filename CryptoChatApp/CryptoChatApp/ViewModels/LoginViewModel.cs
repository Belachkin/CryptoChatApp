using CryptoChatApp.Resources;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Newtonsoft.Json;
using System.ComponentModel;

namespace CryptoChatApp.ViewModels
{
    class LoginViewModel
    {
        private string webApiKey = APIKeys.LoginWebAPIKey;
        private INavigation _navigation;
        private string userName;
        private string userPassword;

        public event PropertyChangedEventHandler PropertyChanged;

        public Command RegisterBtn { get; }
        public Command LoginBtn { get; }

        public string UserName
        {
            get => userName; set
            {
                userName = value;
                RaisePropertyChanged("UserName");
            }
        }

        public string UserPassword
        {
            get => userPassword; set
            {
                userPassword = value;
                RaisePropertyChanged("UserPassword");
            }
        }

        public LoginViewModel(INavigation navigation)
        {
            this._navigation = navigation;
            RegisterBtn = new Command(RegisterBtnTappedAsync);
            LoginBtn = new Command(LoginBtnTappedAsync);
        }

        private async void LoginBtnTappedAsync(object obj)
        {       
            try
            {

                var authProvider = new FirebaseAuthClient(new FirebaseAuthConfig()
                {
                    ApiKey = APIKeys.LoginWebAPIKey,
                    AuthDomain = APIKeys.AuthDomain,
                    Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
                });

                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserName, UserPassword);

                var content = auth.User.Credential.IdToken;



                //var serializedContent = JsonConvert.SerializeObject(content);
                //Preferences.Set("FreshFirebaseToken", serializedContent);
                await this._navigation.PushAsync(new Dashboard());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                throw;
            }


        }

        private async void RegisterBtnTappedAsync(object obj)
        {
            await this._navigation.PushAsync(new RegisterPage());
        }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }

}

