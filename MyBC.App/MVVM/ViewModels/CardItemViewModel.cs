using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyBC.App.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyBC.App.MVVM.ViewModels
{
    public class CardItemViewModel : ObservableObject
    {
        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private CardItemModel _model = new CardItemModel();

        public string SocialName
        {
            get => _model.SocialName;
            set => SetProperty(_model.SocialName, value, _model, (model, value) => model.SocialName = value);
        }

        public string SocialLink
        {
            get => _model.SocialLink;
            set => SetProperty(_model.SocialLink, value, _model, (model, value) => model.SocialLink = value);
        }

        #region Commands
        public ICommand CopyToClipboardCommand { get; private set; }
        public ICommand ShareCommand { get; private set; }
        public ICommand OpenInBrowserCommand { get; private set; }
        public ICommand GetQRCodeCommand { get; private set; }
        #endregion

        public CardItemViewModel()
        {
            _model = new CardItemModel();

            Title = "Create new social card";

            CopyToClipboardCommand = new AsyncRelayCommand(CopyToClipboard);
            ShareCommand = new AsyncRelayCommand(ShareLink);
            OpenInBrowserCommand = new AsyncRelayCommand(OpenInBrowser);
            GetQRCodeCommand = new AsyncRelayCommand(GenerateQrCode);
        }

        public CardItemViewModel(CardItemModel model) : this()
        {
            _model = model;

            Title = $"Edit {model.SocialName}";
        }

        private async Task CopyToClipboard()
        {
            await _model.CopyToClipboard();
        }

        private async Task ShareLink()
        {
            await _model.ShareLink();
        }

        private async Task OpenInBrowser()
        {
            await _model.OpenInBrowser();
        }

        private async Task GenerateQrCode()
        {

        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {

        }
    }
}
