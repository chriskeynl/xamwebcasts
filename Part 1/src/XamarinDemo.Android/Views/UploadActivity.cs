using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using XamarinDemo.Core;

namespace XamarinDemo.Android
{
	[Activity(ScreenOrientation = ScreenOrientation.Portrait)]
	public class UploadActivity : Activity
	{
		string _country;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Upload);

			var toolbar = FindViewById<global::Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
			toolbar.Title = "Upload";

			var extras = Intent.Extras;
			if (extras != null)
			{
				_country = extras.GetString("country");
				FindViewById<TextView>(Resource.Id.textLocation).Text = $"Location: {_country}";
			}

			FindViewById<Button>(Resource.Id.buttonUpload).Click += delegate
			{
				Upload();
			};
		}

		async void Upload()
		{
			var service = new DemoService();
			var name = FindViewById<TextView>(Resource.Id.textName).Text;

			var result = await service.PostDeveloper(name,_country);
			if (result)
			{
				var builder = new AlertDialog.Builder(this);
				builder.SetMessage("Upload succesful");
				builder.SetCancelable(false);
				builder.SetPositiveButton("OK", delegate { Finish(); });
				builder.Show();	
			}
			else {
				var builder = new AlertDialog.Builder(this);
				builder.SetMessage("Upload failed");
				builder.SetCancelable(false);
				builder.SetPositiveButton("OK", delegate { Finish(); });
				builder.Show();
			}
		}
	}
}