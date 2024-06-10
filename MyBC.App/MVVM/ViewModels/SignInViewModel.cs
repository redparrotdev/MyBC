using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using MyBC.App.MVVM.Views;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBC.App.MVVM.ViewModels
{
    public partial class SignInViewModel : ObservableValidator
    {
        private readonly FirebaseAuthClient _authClient;

        public SignInViewModel(FirebaseAuthClient authClient)
        {
            _authClient = authClient;
        }

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        [EmailAddress]
        private string _email;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        private string _password;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsErrorMessageVisible))]
        private string _errorMessage;

        public bool IsErrorMessageVisible => !string.IsNullOrEmpty(ErrorMessage);

        [RelayCommand]
        private async Task SignIn()
        {
            ValidateAllProperties();

            if (HasErrors)
            {
                ErrorMessage = string.Join(Environment.NewLine, GetErrors().Select(e => e.ErrorMessage));
                return;
            }
            //Else

            ErrorMessage = string.Empty;

            try
            {
                // Add firebase validation here
                await _authClient.SignInWithEmailAndPasswordAsync(Email, Password);

                // And goto main page
                await Shell.Current.GoToAsync(nameof(HomePage));
            }
            catch (Exception ex)
            {
                ErrorMessage = "Error during login. Check data and try again";
                Log.Debug(ex.ToString());
            }
        }

        [RelayCommand]
        private async Task GoToSignUp()
        {
            await Shell.Current.GoToAsync(nameof(SignUpPage));
        }


    }
}
