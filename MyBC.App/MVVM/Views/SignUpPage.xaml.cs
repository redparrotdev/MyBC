using MyBC.App.MVVM.ViewModels;

namespace MyBC.App.MVVM.Views;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(SignUpViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}