using BiliAnimeDownload.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BiliAnimeDownload.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistroyPage : ContentPage
	{
		public HistroyPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //List<HistroyModel> ls = new List<HistroyModel>() {
            //     new HistroyModel(){name="国家队",date="2018/03/13",id="21680",type="anime"},
            //};
            var historys =Util.GetHistroy().OrderByDescending(x=>Convert.ToDateTime(x.date));
            lv.ItemsSource = historys;
        }
   
        private  void lv_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
             var data = lv.SelectedItem as HistroyModel;

            (this.Navigation.NavigationStack[0] as MainPage).DoGetAnimeInfo(data.id);

            this.Navigation.RemovePage(this);
           
            //this.Navigation.RemovePage(this.Navigation.NavigationStack.First());
            //this.Navigation.PushAsync(new MainPage(data.id));
         
           // lv.SelectedItem = null;
        }
    }

    public class HistroyModel
    {
        public string name { get; set; }
        public string type { get; set; }//anime or video
        public string date { get; set; }
        public string id { get; set; }
    }


}