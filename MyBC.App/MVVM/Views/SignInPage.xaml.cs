using MyBC.App.MVVM.ViewModels;

namespace MyBC.App.MVVM.Views;

public partial class SignInPage : ContentPage
{
	public SignInPage(SignInViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}