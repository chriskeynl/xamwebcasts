using Windows.Devices.Geolocation;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using XamarinDemo.Core;
using XamarinDemo.UWP.Views;
using System;
using Windows.UI.ViewManagement;
using Windows.UI;
using Windows.Foundation.Metadata;

namespace XamarinDemo.UWP
{
    public sealed partial class MainPage : Page
    {
        DemoService _demoService;

        public MainPage()
        {
            InitializeComponent();
            _demoService = new DemoService();
            Loaded += MainPage_Loaded;
        }

        string _country;
        private async void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            btnDevelopers.Click += BtnDevelopers_Click;
            btnUpload.Click += BtnUpload_Click;
            SetStatusBar();

            var accessStatus = await Geolocator.RequestAccessAsync();
            if (accessStatus == GeolocationAccessStatus.Allowed)
            {
                Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = 100 };
                var result = await geolocator.GetGeopositionAsync();

                _country = await _demoService.GetCountryFromLatLong(result.Coordinate.Point.Position.Latitude, result.Coordinate.Point.Position.Longitude);
                Loader.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                textLocation.Text = $"Location: {_country}";
                btnUpload.IsEnabled = true;
            }
        }

        void SetStatusBar()
        {
            //windows title bar      
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar.BackgroundColor = Color.FromArgb(255, 69, 107, 251);
            ApplicationView.GetForCurrentView().TitleBar.ForegroundColor = Colors.White;
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar.ButtonBackgroundColor = Color.FromArgb(255, 69, 107, 251);
            ApplicationView.GetForCurrentView().TitleBar.ButtonForegroundColor = Colors.White;

            //StatusBar for Mobile

            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                Windows.UI.ViewManagement.StatusBar.GetForCurrentView().BackgroundColor = Color.FromArgb(255, 69, 107, 251);
                StatusBar.GetForCurrentView().BackgroundOpacity = 1;
            }
        }
        private void BtnUpload_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(UploadPage), _country);
        }

        private void BtnDevelopers_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DevelopersPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _demoService = new DemoService();
            LoadData();

            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        async void LoadData()
        {
            var dashboardStatistics = await _demoService.GetDashboardStatistics();
            if (dashboardStatistics == null)
                return;

            textDevelopers.Text = dashboardStatistics.NumberOfDevelopers.ToString();
            textCountries.Text = dashboardStatistics.NumberOfCountries.ToString();
        }
    }
}
