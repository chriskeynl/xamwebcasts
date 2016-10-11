using Foundation;
using UIKit;
using XamLoc.FormsCore;

namespace XamLoc.Forms.IOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			app.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
			UINavigationBar.Appearance.TintColor = UIColor.White;
			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
			{
				TextColor = UIColor.White
			});

			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
			global::Xamarin.Forms.Forms.Init();
			LoadApplication(new App());
			return base.FinishedLaunching(app, options);
		}
	}
}