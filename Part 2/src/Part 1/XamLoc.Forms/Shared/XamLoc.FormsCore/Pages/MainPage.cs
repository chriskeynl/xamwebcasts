using Plugin.Geolocator;
using System;
using Xamarin.Forms;

namespace XamLoc.FormsCore
{
	public partial class MainPage : ContentPage
	{
		DemoService _demoService;
		string _country;

		public MainPage()
		{
			InitializeComponent();
			Title = "XamLoc";

			_demoService = new DemoService();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			LoadData();
			GetLocation();
		}

		async void LoadData()
		{
			var result = await _demoService.GetDashboardStatistics();
			if (result == null)
				return;

			TextDevelopers.Text = result.NumberOfDevelopers.ToString();
			TextCountries.Text = result.NumberOfCountries.ToString();
		}

		bool hasPosition = false;
		async void GetLocation()
		{
			if (hasPosition)
				return;

            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 5000;

                var position = await locator.GetPositionAsync(10000);
                hasPosition = true;

                _country = await _demoService.GetCountryFromLatLong(position.Latitude, position.Longitude);
                if (_country != null)
                {
                    Loader.IsVisible = false;
                    ButtonUpload.IsEnabled = true;
                    TextCountry.Text = $"Current location: {_country}";
                }
            }
            catch (Exception)
            {
            }
		}

		void HandleDevelopers_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new DevelopersPage());
		}

		void HandleUpload_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new UploadPage(_country));
		}
	}
}
