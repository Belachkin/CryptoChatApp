using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChatApp.ViewModels
{
    class RegisterViewModel
    {

        public RegisterViewModel(INavigation navigation) 
        { 
            this._navigation = navigation;

            RegisterUser = new Command(RegisterUserTappedAsync);
        }

        private INavigation _navigation;

        public Command RegisterUser { get; }

        private void RegisterUserTappedAsync(object obj)
        {
            throw new NotImplementedException();
        }

       
    }
}
