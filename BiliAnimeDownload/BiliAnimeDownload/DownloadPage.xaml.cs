using BiliAnime.Helpers;
using BiliAnimeDownload.Helpers;
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiliAnimeDownload
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DownloadPage : ContentPage
    {
        public DownloadPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
           




        }

        private async void btn_DownloadTest_Clicked(object sender, EventArgs e)
        {
          

            var play =await Util.GetVideoUrl("29319396", "https://www.bilibili.com/bangumi/play/ep164982", 4, "21728", 0);


            foreach (var item in play)
            {
                await DisplayAlert("", item.url, "ok");
                var headers = new Dictionary<string, string>();
                headers.Add("Referer", "https://www.bilibili.com/bangumi/play/ep164982");
                headers.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36");
                var d= CrossDownloadManager.Current.CreateDownloadFile(item.url, headers);
             

                CrossDownloadManager.Current.Start(d);
                d.PropertyChanged += D_PropertyChanged;
            }
            lv.ItemsSource = CrossDownloadManager.Current.Queue;
        }

        private void D_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            lv.ItemsSource = CrossDownloadManager.Current.Queue;

        }
    }




}