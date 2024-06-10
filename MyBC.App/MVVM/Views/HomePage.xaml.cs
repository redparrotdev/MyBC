using MyBC.App.MVVM.ViewModels;

namespace MyBC.App.MVVM.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await ((HomePageViewModel)BindingContext).Appearing();
    }

}