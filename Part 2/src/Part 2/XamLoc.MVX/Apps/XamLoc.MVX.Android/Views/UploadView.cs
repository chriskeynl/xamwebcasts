using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using XamLoc.MVX.Core;

namespace XamLoc.MVX.Android
{
	[Activity]
	public class UploadView : MvxAppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.UploadView);
			FindViewById<Toolbar>(Resource.Id.toolbar).Title = ((UploadViewModel)ViewModel).TitleText;
		}
	}
}