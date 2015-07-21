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
		private ListView beerList;
		private BeerService beerService;
		public List<Beer> Items { get; private set; }

		public HomePage ()
		{
			Title = "Pulling JailBreak Beer from Mongo";
			var l = new Label { Text = "Beers", Font = Font.BoldSystemFontOfSize(NamedSize.Large) };

			var beerList = new ListView () {
				
			};

			Content = new StackLayout { 
				Children = {
					beerList
				}
			};
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing ();
			await this.RefreshAsync ();
		}

		private async Task RefreshAsync()
		{

			var jbms = new JailBreakBeerMongoService();
			var es = await jbms.GetBeersAsync();
			Xamarin.Forms.Device.BeginInvokeOnMainThread( () => {
				Debug.WriteLine("found " + es.Length + " beers");
				//l.Text = es.Length + " beers";
				beerList.ItemsSource = es;
			});
			var cell = new DataTemplate (typeof(TextCell));
			//use the two lines below if you want to use the default text property
			cell.SetBinding(TextCell.TextProperty, "Name"); //the word Text here represents the field in the Database we want returned
			beerList.ItemTemplate = cell;
			//end two lines commentary
			}
		}

}



