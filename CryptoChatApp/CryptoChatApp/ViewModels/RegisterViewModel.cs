using CryptoChatApp.Resources;
using Firebase.Auth;
using Firebase.Auth.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CryptoChatApp.ViewModels
{
    class RegisterViewModel : INotifyPropertyChanged
    {

        private INavigation _navigation;
        private string email;
        private string password;
        private string repeatPassword;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string UserEmail
        {
            get => email;
            set
            {
                email = value;
                RaisePropertyChanged("UserEmail");
            }
        }

        public string UserPassword
        {
            get => password; set
            {
                password = value;
                RaisePropertyChanged("UserPassword");
            }
        }

        public string RepeatUserPassword
        {
            get => repeatPassword; set
            {
                repeatPassword = value;
                RaisePropertyChanged("RepeatUserPassword");
            }
        }


        public Command RegisterUserBtn { get; }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public RegisterViewModel(INavigation navigation)
        {
            this._navigation = navigation;

            RegisterUserBtn = new Command(RegisterUserTappedAsync);
        }

        

        private async void RegisterUserTappedAsync(object obj)
        {
            try
            {
                
                if(UserPassword != RepeatUserPassword)
                {
                    App.Current.MainPage.DisplayAlert("Ошибка", "Пароли не совпадают", "ОК");
                    return;
                }

                var authProvider = new FirebaseAuthClient(new FirebaseAuthConfig()
                {
                    ApiKey = APIKeys.LoginWebAPIKey,
                    AuthDomain = APIKeys.AuthDomain,
                    Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
                });

                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserEmail, UserPassword);

                var token = auth.User.GetIdTokenAsync();
                if (token != null)
                    await App.Current.MainPage.DisplayAlert("Alert", "Пользователь успешно зарегестрирован." +
                        " Теперь вы можете войти в аккаунт", "OK");
                await this._navigation.PopAsync();

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", ex.Message, "ОК");
                throw;
            }
        }

       
    }
}
