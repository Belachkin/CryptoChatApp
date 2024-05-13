
using CryptoChatApp.Resources;
using Firebase.Auth;
using Newtonsoft.Json;

namespace CryptoChatApp;

public partial class Dashboard : ContentPage
{
	public Dashboard()
	{
		InitializeComponent();
		GetProfileInfo();
	}

    private async void GetProfileInfo()
    {

        

        // Инициализируем экземпляр FirebaseAuth с помощью токена
        var authProvider = new FirebaseAuthClient(new FirebaseAuthConfig()
        {
            ApiKey = APIKeys.LoginWebAPIKey,
            AuthDomain = APIKeys.AuthDomain,
        });

        // Получаем информацию о текущем пользователе с использованием токена
        var userData = 
        UserEmail.Text = "Email" + userEmail;
		
    }
}