using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBC.App.Extentions
{
    public static class FirebaseExtentions
    {
        public static MauiAppBuilder UseFirebaseAuth(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyCa79R9a4vPQJPWBeOiVFlf-UilcWftFmk",
                AuthDomain = "mysocial-f8ca2.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                },
                UserRepository = new FileUserRepository("UserSession")
            }));

            return builder;
        }
    }
}
