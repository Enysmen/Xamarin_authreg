using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace xamarinauthrg
{
    public interface IFirebaseAuthenticator
    {
        Task<string> SignInWithEmailAndPasswordAsync(string email, string password);
        Task<string> CreateUserWithEmailAndPasswordAsync(string email, string password);

    }
}
