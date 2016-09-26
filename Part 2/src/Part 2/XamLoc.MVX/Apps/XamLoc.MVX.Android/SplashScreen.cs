using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Views;
using Acr.UserDialogs;

namespace XamLoc.Mvx.Android
{
	[Activity(
		Label = "XamLoc"
		, MainLauncher = true
		, Icon = "@mipmap/icon"
		, Theme = "@style/Theme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
	public class SplashScreen : MvxSplashScreenActivity
	{
		public SplashScreen() : base(XamLoc.MVX.Android.Resource.Layout.SplashScreen)
		{

		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			View decorView = Window.DecorView;
			decorView.SystemUiVisibility = StatusBarVisibility.Hidden;

			UserDialogs.Init(this);
		}
	}
}