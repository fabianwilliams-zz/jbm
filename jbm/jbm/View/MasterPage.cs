using System;
using Xamarin.Forms;

namespace jbm
{
	public class MasterPage : TabbedPage
	{
		public MasterPage ()
		{
			this.Children.Add (new HomePage () {Title = "All Our Beers", Icon = "Beer-30.png"});
			this.Children.Add (new WhatsOnTapPage () {Title = "What's On Tap", Icon = "Beer-30.png"});
		}
	}
}

