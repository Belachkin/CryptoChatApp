
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

        

        // �������������� ��������� FirebaseAuth � ������� ������
        var authProvider = new FirebaseAuthClient(new FirebaseAuthConfig()
        {
            ApiKey = APIKeys.LoginWebAPIKey,
            AuthDomain = APIKeys.AuthDomain,
        });

        // �������� ���������� � ������� ������������ � �������������� ������
        var userData = 
        UserEmail.Text = "Email" + userEmail;
		
    }
}