using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xamarinauthrg.Droid;
using DependencyAttribute = Xamarin.Forms.DependencyAttribute;

[assembly: Dependency(typeof(FirebaseAuthenticator))]

namespace xamarinauthrg.Droid
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        // FirebaseClient firebase = new FirebaseClient("https://xamarinauthregistr-default-rtdb.firebaseio.com/");
        public async Task<string> CreateUserWithEmailAndPasswordAsync(string email, string password)
        {
            var authResult = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);

            var getTokenResult = await authResult.User.GetIdTokenAsync(false);

            return getTokenResult.Token;

            // throw new NotImplementedException();
        }
        public async Task<string> SignInWithEmailAndPasswordAsync(string email, string password)
        {
            try
            {

                var authResult = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);

                var getTokenResult = await authResult.User.GetIdTokenAsync(false);

                return getTokenResult.Token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return "";
            }


            //throw new NotImplementedException();
        }





    }
}