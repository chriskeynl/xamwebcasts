using Windows.Devices.Geolocation;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System;
using Windows.UI.ViewManagement;
using Windows.UI;
using Windows.Foundation.Metadata;

namespace XamLoc.Forms.UWP
{

    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            SetStatusBar();
            LoadApplication(new XamLoc.FormsCore.App());
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
    }
}