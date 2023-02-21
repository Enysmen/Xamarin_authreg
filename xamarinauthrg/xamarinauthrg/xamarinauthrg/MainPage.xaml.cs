using Firebase.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Runtime.InteropServices.ComTypes;

namespace xamarinauthrg
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        IFirebaseAuthenticator auth;
        public MainPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IFirebaseAuthenticator>();


        }

        private async void Button_Clicked_login_mainpage(object sender, EventArgs e)
        {
            // not working cod ...
            /* var email = EmailEntry.Text;
             var password = PasswordEntry.Text;
             if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) )
             {
                 await DisplayAlert("error","please fill in email and password","OK");

             }
             var firebase = DependencyService.Get<IFirebaseAuthenticator>();
             try
             {

                 var token = firebase.SignInWithEmailAndPasswordAsync(email, password);
                 await DisplayAlert("success", $"user with email {email} has logged in ", "OK");
                 await Navigation.PushAsync(new ProfilePage());


             }
             catch(Exception ex)
             {

                 await DisplayAlert("error", ex.Message, "OK");
             }*/
            var email = EmailEntry.Text; // read email  
            var password = PasswordEntry.Text; // read password
            string token = await auth.SignInWithEmailAndPasswordAsync(email, password); // get token user 
            if (token != "")  // look if token not have null  
            {
                await Navigation.PushAsync(new ProfilePage());
            }
            else
            {
                ShowError();
            }
            async void ShowError()
            {
                await DisplayAlert("Authentication Failed", "E-mail or password are incorrect. Try again!", "OK");
            }

        }

        private void Button_Clicked_Register_mainpage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
