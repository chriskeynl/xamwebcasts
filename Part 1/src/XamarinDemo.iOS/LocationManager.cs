using System;
using CoreLocation;
using UIKit;

namespace XamarinDemo.iOS
{
	public class LocationManager
	{
		protected CLLocationManager locMgr;

		public event EventHandler<LocationUpdatedEventArgs> LocationUpdated = delegate { };

		public LocationManager()
		{
			this.locMgr = new CLLocationManager();
			this.locMgr.PausesLocationUpdatesAutomatically = false;

			// iOS 8 has additional permissions requirements
			if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
			{
				locMgr.RequestWhenInUseAuthorization(); // works in background
													 //locMgr.RequestWhenInUseAuthorization (); // only in foreground
			}

			// iOS 9 requires the following for background location updates
			// By default this is set to false and will not allow background updates
			if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
			{
				locMgr.AllowsBackgroundLocationUpdates = true;
			}
		}

		public CLLocationManager LocMgr
		{
			get { return this.locMgr; }
		}

		public void StartLocationUpdates()
		{

			if (CLLocationManager.LocationServicesEnabled)
			{
				LocMgr.DesiredAccuracy = 100;

				LocMgr.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
				{
						// fire our custom Location Updated event
						LocationUpdated(this, new LocationUpdatedEventArgs(e.Locations[e.Locations.Length - 1]));
				};

				LocMgr.StartUpdatingLocation();
			}
		}

		public void StopLocationUpdates()
		{
			locMgr.StopUpdatingLocation();
		}
	}

	public class LocationUpdatedEventArgs : EventArgs
	{
		CLLocation location;

		public LocationUpdatedEventArgs(CLLocation location)
		{
			this.location = location;
		}

		public CLLocation Location
		{
			get { return location; }
		}
	}
}
