using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using XamarinDemo.Core;

namespace XamarinDemo.Android
{
	[Activity(Label = "XamLoc", MainLauncher = true, Icon = "@mipmap/icon" , ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : Activity,ILocationListener
	{
		DemoService _demoService;

		LocationManager _locationManager;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			FindViewById<global::Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar).Title = "Dashboard";
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

			FindViewById<Button>(Resource.Id.buttonUsers).Click += delegate
			{
				StartActivity(typeof(DevelopersActivity));
			};

			FindViewById<Button>(Resource.Id.buttonUpload).Click += delegate
			{
				var intent = new Intent(BaseContext, typeof(UploadActivity));
				intent.PutExtra("country",_country);
				StartActivity(intent);
			};

			_demoService = new DemoService();
			if ((int)Build.VERSION.SdkInt < 23)
			{
				InitializeLocationManager();
				return;
			} else {
				GetLocationPermissionAsync();
			}
		}

		readonly string[] PermissionsLocation =
		{
		 	Manifest.Permission.AccessCoarseLocation,
			Manifest.Permission.AccessFineLocation
		};

		const int RequestLocationId = 0;
		void GetLocationPermissionAsync()
		{
			//Check to see if any permission in our group is available, if one, then all are
			const string permission = Manifest.Permission.AccessFineLocation;
			if (CheckSelfPermission(permission) == (int)Permission.Granted)
			{
				InitializeLocationManager();
				return;
			}

			RequestPermissions(PermissionsLocation, RequestLocationId);
		}

		void InitializeLocationManager()
		{
			_locationManager = (LocationManager)GetSystemService(LocationService);
			_locationManager.RequestSingleUpdate(new Criteria { Accuracy = Accuracy.Low }, this, null);
		}

		protected override void OnResume()
		{
			base.OnResume();
			LoadData();
		}

		async void LoadData()
		{
			var dashboardStatistics = await _demoService.GetDashboardStatistics();
			if (dashboardStatistics == null)
				return;

			FindViewById<TextView>(Resource.Id.textDevelopers).Text = dashboardStatistics.NumberOfDevelopers.ToString();
			FindViewById<TextView>(Resource.Id.textCountries).Text = dashboardStatistics.NumberOfCountries.ToString();
			FindViewById<Button>(Resource.Id.buttonUpload).Enabled = true;
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
		{
			switch (requestCode)
			{
				case RequestLocationId:
					{
						if (grantResults[0] == Permission.Granted)
						{
							InitializeLocationManager();
						}
					}
					break;
			}
		}

		string _country;
		public async void OnLocationChanged(Location location)
		{
			_locationManager.RemoveUpdates(this);
			_locationManager.Dispose();
			_country = await _demoService.GetCountryFromLatLong(location.Latitude, location.Longitude);
			FindViewById<ProgressBar>(Resource.Id.progressbar).Visibility = global::Android.Views.ViewStates.Gone;
			FindViewById<TextView>(Resource.Id.textLocation).Text = $"Location: {_country}";
		}

		public void OnProviderDisabled(string provider)
		{
		
		}

		public void OnProviderEnabled(string provider)
		{
	
		}

		public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
		{

		}
	}
}