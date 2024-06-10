using MyBC.App.MVVM.ViewModels;
using MyBC.App.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBC.App.Extentions
{
    public static class MVVMExtentions
    {
        public static MauiAppBuilder AddMVVM(this MauiAppBuilder builder)
        {

            builder.Services
                .AddSingleton<HomePage>()
                .AddSingleton<SignInPage>()
                .AddSingleton<SignUpPage>();

            builder.Services
                .AddSingleton<HomePageViewModel>()
                .AddSingleton<SignInViewModel>()
                .AddSingleton<SignUpViewModel>();

            return builder;
        }

    }
}
