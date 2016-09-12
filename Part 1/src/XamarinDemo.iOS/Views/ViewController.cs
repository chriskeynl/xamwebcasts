using System;
using CoreLocation;
using UIKit;
using XamarinDemo.Core;

namespace XamarinDemo.iOS
{
	public partial class ViewController : UIViewController
	{
		public static LocationManager Manager { get; set; }

		DemoService _demoService;
		protected ViewController(IntPtr handle) : base(handle)
		{

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Title = "Dashboard";
			NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB(68, 99, 215);
			Label.Hidden = true;
			ButtonUpload.Enabled = false;

			_demoService = new DemoService();

			Manager = new LocationManager();
			Manager.StartLocationUpdates();

			Manager.LocationUpdated += HandleLocationChanged;		
		}

		public async void HandleLocationChanged(object sender, LocationUpdatedEventArgs e)
		{
			CLLocation location = e.Location;

			var country = await _demoService.GetCountryFromLatLong(e.Location.Coordinate.Latitude, e.Location.Coordinate.Longitude);
			if (country == null)
				return;
			
			((AppDelegate)UIApplication.SharedApplication.Delegate).Country = country;
			Spinner.Hidden = true;
			ButtonUpload.Enabled = true;
			Label.Text = $"Location: {country}";
			Label.Hidden = false;

			Manager.StopLocationUpdates();
			Console.WriteLine(country);
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			LoadData();
		}

		async void LoadData()
		{
			var dashboardStatistics = await _demoService.GetDashboardStatistics();
			if (dashboardStatistics == null)
				return;

			LabelDevelopers.Text = dashboardStatistics.NumberOfDevelopers.ToString();
			LabelCountries.Text = dashboardStatistics.NumberOfCountries.ToString();
		}
	}
}