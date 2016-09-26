using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using UIKit;

namespace XamLoc.MVX.IOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : MvxApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			window = new UIWindow(UIScreen.MainScreen.Bounds);
			app.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
			UINavigationBar.Appearance.TintColor = UIColor.White;
			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
			{
				TextColor = UIColor.White
			});
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

			var presenter = new MvxIosViewPresenter(this, window);

			var setup = new Setup(this, presenter);
			setup.Initialize();

			var startup = Mvx.Resolve<IMvxAppStart>();
			startup.Start();

			window.MakeKeyAndVisible();

			return true;
		}
	}
}