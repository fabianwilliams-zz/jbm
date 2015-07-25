using System;
using Xamarin.Forms;

namespace jbm
{
	public class MasterPage : TabbedPage
	{
		public MasterPage ()
		{
			this.Children.Add (new HomePage () {Title = "All Our Beers", Icon = "Beer-30.png"});
			this.Children.Add (new WhatsOnTapPage () {Title = "What's On Tap", Icon = "BeerGlass-30.png"});
			this.Children.Add (new JBEventsPage () {Title = "Events", Icon = "Calendar-30.png"});
		}
	}
}

