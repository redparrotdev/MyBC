using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using MyBC.App.MVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBC.App.MVVM.ViewModels
{
    public partial class SignUpViewModel : ObservableValidator
    {
        private readonly FirebaseAuthClient _authClient;

        public SignUpViewModel(FirebaseAuthClient authClient)
        {
            _authClient = authClient;
        }

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        [MinLength(3)]
        private string _userName;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        [EmailAddress]
        private string _email;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        [MinLength(8)]
        private string _password;

        private string _confirmPassword;

        [Required]
        [MinLength(8)]
        [Compare(nameof(Password))]
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value, true);
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsErrorMessageVisible))]
        private string _errorMessage;

        public bool IsErrorMessageVisible => !string.IsNullOrEmpty(ErrorMessage);

        [RelayCommand]
        private async Task SignUp()
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
                await _authClient.CreateUserWithEmailAndPasswordAsync(Email, Password, UserName);
                // And goto main page
                await Shell.Current.GoToAsync(nameof(HomePage));
            }
            catch
            {
                ErrorMessage = "Some error occures while sing up. Try again!";
            }
        }

        [RelayCommand]
        private async Task GoToSignIn()
        {
            await Shell.Current.GoToAsync(nameof(SignInPage));
        }


    }
}
