using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.UI;
using Plugin.Geolocator;
using XamLoc.MVX.Core.Models;
using XamLoc.MVX.Core.Services;

namespace XamLoc.MVX.Core
{
	public class MainViewModel : MvxViewModel
	{
		public string TitleText { get; set; }
		public string ButtonDevelopersText { get; set; }
		public string ButtonUploadText { get; set; }

		public IMvxCommand ButtonDevelopersCommand { get; set; }
		public IMvxCommand ButtonUploadCommand { get; set; }

		public MvxColor ButtonDevelopersColor { get; set; }
		public MvxColor ButtonUploadColor { get; set; }
		public MvxColor BackgroundColor { get; set; }

		public bool IsButtonUploadEnabled { get; set; }

		IDemoService _demoService;

		public MainViewModel()
		{
			TitleText = "Dashboard";
			ButtonUploadText = "Upload";
			ButtonDevelopersText = "Developers";

			ButtonDevelopersCommand = new MvxCommand(() => ShowViewModel<DevelopersViewModel>());
			ButtonUploadCommand = new MvxCommand(GoToUploadView);

			ButtonDevelopersColor = new MvxColor(127, 0, 127);
			ButtonUploadColor = new MvxColor(255, 127, 0);
			BackgroundColor = new MvxColor(102, 134, 255);

			_demoService = Mvx.Resolve<IDemoService>();
			GetLocation();
			LoadData();
		}

		public DashboardStatistics DashboardStatistics { get; set; }
		public async void LoadData()
		{
			DashboardStatistics = await _demoService.GetDashboardStatistics();
			RaisePropertyChanged(() => DashboardStatistics);
		}

		bool _hasPosition;
		public string CurrentLocationText { get; set; }
		string _country;
		async void GetLocation() { 
			if (_hasPosition)
				return;

			try
			{
				var locator = CrossGeolocator.Current;
				locator.DesiredAccuracy = 5000;

				var position = await locator.GetPositionAsync(10000);
				_hasPosition = true;

				_country = await _demoService.GetCountryFromLatLong(position.Latitude, position.Longitude);
				if (_country != null)
				{
					IsButtonUploadEnabled = true;
					CurrentLocationText = $"Current location: {_country}";
					RaisePropertyChanged(() => CurrentLocationText);
					RaisePropertyChanged(() => IsButtonUploadEnabled);
				}
			}
			catch (Exception)
			{
			}
		}

		void GoToUploadView()
		{
			var bundle = new MvxBundle();
			bundle.Data.Add("Location", _country);
			ShowViewModel<UploadViewModel>(bundle);
		}
	}
}