using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarinauthrg
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
       // FirebaseClient firebase = new FirebaseClient("https://xamarinauthregistr-default-rtdb.firebaseio.com/");
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked_Register(object sender, EventArgs e)
        {
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;
            var passwordRepeat = PasswordRepeatEntry.Text;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordRepeat))
            {

                await DisplayAlert("error", "please fill in all fields and the same password", "OK");

            }

            if (password == passwordRepeat)
            {
                if (password.Length < 6)
                {
                    await DisplayAlert("error", "password must be at least 6 characters long ", "OK");

                }
                else
                {
                    var firebase = DependencyService.Get<IFirebaseAuthenticator>();
                    try
                    {

                        var token = firebase.CreateUserWithEmailAndPasswordAsync(email, password);
                        await DisplayAlert("success", $"User with email {email} has been registered", "OK");
                        await Navigation.PopAsync();
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("error", ex.Message, "ok");
                    }
                }

            }


            /*  var firebase = DependencyService.Get<IFirebaseAuthenticator>();
              try
              {
                  var token = firebase.CreateUserWithEmailAndPasswordAsync(email, password);
                  await DisplayAlert("success", $"User with email {email} has been registered", "OK");
                  await Navigation.PopAsync();
              }
              catch (Exception ex)
              {
                  await DisplayAlert("error", ex.Message, "ok");
              }*/
        }
    }
}