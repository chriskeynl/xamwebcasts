using Android;
using Android.App;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using XamLoc.FormsCore;

namespace HelloXamarinFormsWorld.Android
{
	[Activity(Label = "XamLoc", MainLauncher = true,
	          ConfigurationChanges  = global::Android.Content.PM.ConfigChanges.ScreenSize | 
	          global::Android.Content.PM.ConfigChanges.Orientation)]
	
	public class MainActivity :Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
            
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            Xamarin.Forms.Forms.Init(this, bundle);

			FormsAppCompatActivity.ToolbarResource = XamLoc.Forms.Android.Resource.Layout.toolbar;

			//this.ActionBar.SetIcon(global::Android.Resource.Color.Transparent);
			LoadApplication(new App());
		}
	}
}