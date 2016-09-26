using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using XamLoc.MVX.Core;

namespace XamLoc.MVX.Android
{
	[Activity]
	public class MainView : MvxAppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.MainView);
			FindViewById<Toolbar>(Resource.Id.toolbar).Title = ((MainViewModel)ViewModel).TitleText;
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

		}
	}
}