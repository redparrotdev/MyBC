using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using MyBC.App.MVVM.Models;
using MyBC.App.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBC.App.MVVM.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _authClient;

        public HomePageViewModel(FirebaseAuthClient authClient)
        {
            _authClient = authClient;

            Items = new ObservableCollection<CardItemViewModel>(GetBulkData());
        }

        public string UserName => _authClient?.User?.Info?.DisplayName ?? "Username";

        public ObservableCollection<CardItemViewModel> Items { get; private set; }

        private List<CardItemViewModel> GetBulkData()
        {
            return new List<CardItemViewModel>()
            {
                new CardItemViewModel(new CardItemModel() {SocialName = "Social 1", SocialLink = "https://google.com"}),
                new CardItemViewModel(new CardItemModel() {SocialName = "Social 2", SocialLink = "https://google.com"}),
                new CardItemViewModel(new CardItemModel() {SocialName = "Social 3", SocialLink = "https://google.com"}),
                new CardItemViewModel(new CardItemModel() {SocialName = "Social 4", SocialLink = "https://google.com"}),
                new CardItemViewModel(new CardItemModel() {SocialName = "Social 5", SocialLink = "https://google.com"}),
                new CardItemViewModel(new CardItemModel() {SocialName = "Social 6", SocialLink = "https://google.com"}),
                new CardItemViewModel(new CardItemModel() {SocialName = "Social 7", SocialLink = "https://google.com"}),
                new CardItemViewModel(new CardItemModel() {SocialName = "Social 8", SocialLink = "https://google.com"}),
                new CardItemViewModel(new CardItemModel() {SocialName = "Social 9", SocialLink = "https://google.com"}),
                new CardItemViewModel(new CardItemModel() {SocialName = "Social 10", SocialLink = "https://google.com"}),
                new CardItemViewModel(new CardItemModel() {SocialName = "Social 11", SocialLink = "https://google.com"}),
                new CardItemViewModel(new CardItemModel() {SocialName = "Social 12", SocialLink = "https://google.com"})
            };
        }

        [RelayCommand]
        private async Task AddNewCard()
        {
            await Shell.Current.GoToAsync(nameof(CardItemPage));
        }

        [RelayCommand]
        private async Task SignOut()
        {
            _authClient.SignOut();

            await Shell.Current.GoToAsync(nameof(SignInPage));
        }

        public async Task Appearing()
        {
            OnPropertyChanged(nameof(UserName));

            if (_authClient.User == null)
            {
                await Shell.Current.GoToAsync(nameof(SignInPage));
            }
        }
    }
}
