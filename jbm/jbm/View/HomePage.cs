using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

namespace jbm
{


	public class HomePage : ContentPage
	{
		ListView lv;

		public HomePage ()
		{
			Title = "Pulling JailBreak Beer from Mongo";

			lv = new ListView ();

//			If below is uncommented then we get all the elements in the row but its too big. 
//			lv = new ListView{
//				HasUnevenRows = true
//
//			};

			lv.ItemTemplate = new DataTemplate (typeof(ListofBeerCell)); 

//			lv.ItemSelected += (sender, e) => {
//				var eq = (Beer)e.SelectedItem;
//				DisplayAlert("Beer info", eq.ToString(), "OK", null);
//			};

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
			var gba = await jbms.GetBeersAsync();
			lv.ItemsSource = gba;
		}
			
	}

}



