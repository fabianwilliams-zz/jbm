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
			var l = new Label { Text = "Beers", Font = Font.BoldSystemFontOfSize(NamedSize.Large) };

			lv = new ListView ();
			lv.ItemTemplate = new DataTemplate(typeof(TextCell));
			lv.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
			lv.ItemSelected += (sender, e) => {
				var eq = (Beer)e.SelectedItem;
				DisplayAlert("Beer info", eq.ToString(), "OK", null);
			};

			var b = new Button { Text = "Get Earthquakes" };
			b.Clicked += async (sender, e) => {
				var sv = new JailBreakBeerMongoService();
				var es = await sv.GetBeersAsync();
				Xamarin.Forms.Device.BeginInvokeOnMainThread( () => {
					Debug.WriteLine("found " + es.Length + " beers");
					l.Text = es.Length + " beers";
					lv.ItemsSource = es;
				});
			};


			Content = new StackLayout { 
				Children = {
					b,
					lv
				}
			};
		}

		protected async override void OnAppearing()
		{
			//base.OnAppearing ();
			//await this.RefreshAsync ();
		}

		private async Task RefreshAsync()
		{
//
//			var jbms = new JailBreakBeerMongoService();
//			var es = await jbms.GetBeersAsync();
//			Xamarin.Forms.Device.BeginInvokeOnMainThread( () => {
//				//Debug.WriteLine("found " + es.Length + " beers");
//				//l.Text = es.Length + " beers";
//				beerList.ItemsSource = es;
//			});
			var cell = new DataTemplate (typeof(TextCell));
			//use the two lines below if you want to use the default text property
			cell.SetBinding(TextCell.TextProperty, "Name"); //the word Text here represents the field in the Database we want returned
			lv.ItemTemplate = cell;
			//end two lines commentary
			}
		}

}



