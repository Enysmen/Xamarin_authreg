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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            using (var firebase = new FirebaseClient("https://xfauth-b890f-default-rtdb.firebaseio.com/"))
            {
                var result = await firebase.Child("log").OnceSingleAsync<string>();
                await DisplayAlert("title", result, "OK");

            }


        }

       
    }
}