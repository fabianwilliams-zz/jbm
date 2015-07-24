using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

namespace jbm
{
	public class WhatsOnTapPage : ContentPage
	{
		ListView lv;

		public WhatsOnTapPage ()
		{
			Title = "Whats On Tap Today";

			lv = new ListView ();

			lv.ItemTemplate = new DataTemplate (typeof(ListofBeerCell)); 

			lv.ItemSelected += (sender, e) => {
				Navigation.PushAsync(new BeerDetail(e.SelectedItem as Beer));
			};

			Content = new StackLayout { 
				Padding = new Thickness (0, Device.OnPlatform (0, 0, 0), 0, 0),
				Spacing = 3,
				Orientation = StackOrientation.Vertical,
				Children = {
					lv
				}
			};
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing ();
			await this.CallMongoDatabaseAsync ();
		}

		public async Task CallMongoDatabaseAsync()
		{
			var jbms = new JailBreakBeerMongoService();
			var gba = await jbms.GetOnTapBeersAsync();
			lv.ItemsSource = gba;
		}

	}
}

