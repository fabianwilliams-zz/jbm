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
		private BeerService beerService;
		public List<Beer> Items { get; private set; }

		public HomePage ()
		{
			Title = "Pulling JailBreak Beer from Mongo";
//			var l = new Label { Text = "Beers", Font = Font.BoldSystemFontOfSize(NamedSize.Large) };

			lv = new ListView ();
			lv.ItemTemplate = new DataTemplate(typeof(TextCell));
			lv.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
//			lv.ItemSelected += (sender, e) => {
//				var eq = (Beer)e.SelectedItem;
//				DisplayAlert("Beer info", eq.ToString(), "OK", null);
//			};

//			var b = new Button { Text = "Get Jailbreak Beers" };
//			b.Clicked += async (sender, e) => {
//				var sv = new JailBreakBeerMongoService();
//				var es = await sv.GetBeersAsync();
//				Xamarin.Forms.Device.BeginInvokeOnMainThread( () => {
//					Debug.WriteLine("found " + es.Length + " beers");
//					l.Text = es.Length + " beers";
//					lv.ItemsSource = es;
//				});
//			};


			Content = new StackLayout { 
				Children = {
//					l,
//					b,
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



