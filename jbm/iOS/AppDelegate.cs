using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Foundation;
using UIKit;

namespace jbm.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
			SQLitePCL.CurrentPlatform.Init(); 


			window = new UIWindow(UIScreen.MainScreen.Bounds);
			window.RootViewController = App.GetMainPage().CreateViewController();
			window.MakeKeyAndVisible();


			App.UIContext = window.RootViewController;
			return true;

//			LoadApplication (new App ());
//
//			return base.FinishedLaunching (app, options);
		}
	}
}

