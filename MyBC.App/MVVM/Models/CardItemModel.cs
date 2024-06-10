using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBC.App.MVVM.Models
{
    public class CardItemModel
    {
        public int Id { get; set; }
        public string SocialName { get; set; }
        public string SocialLink { get; set; }

        public async Task CopyToClipboard()
        {
            await Clipboard.Default.SetTextAsync(this.SocialLink);
        }

        public async Task ShareLink()
        {
            await Share.Default.RequestAsync(new ShareTextRequest()
            {
                Uri = this.SocialLink,
                Title = "Share Web Link"
            });
        }

        public async Task OpenInBrowser()
        {
            await Browser.OpenAsync(this.SocialLink);
        }


    }
}
