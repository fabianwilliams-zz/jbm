using System;
using Xamarin.Forms;

namespace jbm
{
	public class BeerDetail : ContentPage
	{
		public BeerDetail (Beer b)
		{
			Padding = new Thickness (0, Device.OnPlatform (10, 0, 0), 0, 0);
			this.Title = b.Name;

			var bottleImage = new Image {
				Aspect = Aspect.AspectFit,
				BackgroundColor = Color.Gray
			};

			var picBottleUrl = b.Smu;
			if (b.Smu != null) {
				bottleImage.Source = ImageSource.FromUri (new Uri (picBottleUrl));

			} else {
				bottleImage.Source = ImageSource.FromUri(new Uri("https://jailbreakbrewing.com/wp-content/uploads/2015/05/SRM-16"));
				//giftImage.Source = "infinite_xhalf.png";
			}
			var BeerNameLabel = new Label {
				FontAttributes = FontAttributes.Bold,
				Text = b.Name,
				FontSize = 15
			};

			var BeerTasteLabel = new Label {
				Text = b.Taste,
				Font = Font.SystemFontOfSize(NamedSize.Medium)
			};

			var tweetButton = new Button {
				Text = "Tweet about " + b.Name
			};

//			var txtView = new UITextView {
//				Text = "Current Status :-) Enjoying a " + b.Name + " from @jailbreakbrewing"
//			};
//
//
//			tweetButton.Clicked += (sender, e) => {
//				Navigation.PushAsync(new JBSocialPage(b as Beer));
//			};

			var drawingButton = new Button {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				Text = "Purchase " + b.Name
			};

			drawingButton.Clicked += async (sender, e) => {
				await DisplayAlert("TBD", "Tap into E-Commerce", "Ok");
			};

			Content = new ScrollView {
				Content = new StackLayout {
					Spacing = 10,
					Children = {bottleImage, BeerNameLabel, BeerTasteLabel, tweetButton, drawingButton}
				}
			};

		}
	}
}

