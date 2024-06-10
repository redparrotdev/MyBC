using MyBC.App.MVVM.Views;

namespace MyBC.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            Routing.RegisterRoute(nameof(CardItemPage), typeof(CardItemPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(SignInPage), typeof(SignInPage));
            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.MinimumWidth = window.Width = 700;
            window.MinimumHeight = window.Height = 900;

            return window;
        }
    }
}
