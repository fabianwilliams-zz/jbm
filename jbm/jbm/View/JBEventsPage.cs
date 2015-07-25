using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

namespace jbm
{
	public class JBEventsPage : ContentPage
	{
		ListView lv;

		public JBEventsPage ()
		{
			Title = "List of Jailbreak Events";

			lv = new ListView ();

			var cell = new DataTemplate (typeof(TextCell));
			//use the two lines below if you want to use the default text property
			cell.SetBinding(TextCell.TextProperty, "summary"); //the word Text here represents the field in the Database we want returned
			lv.ItemTemplate = cell;
			//end two lines commentary

			//lv.ItemTemplate = new DataTemplate (typeof(ListofBeerCell)); 

			lv.ItemSelected += (sender, e) => {
				//Navigation.PushAsync(new BeerDetail(e.SelectedItem as Beer));
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
			await this.CallJBGoogleCalendarAsync ();
		}

		public async Task CallJBGoogleCalendarAsync ()
		{
			var jbges = new JailBreakGoogleEventsService();
			var gba = await jbges.GetJBEventsAsync();
			lv.ItemsSource = gba.items;
		}

	}
}

