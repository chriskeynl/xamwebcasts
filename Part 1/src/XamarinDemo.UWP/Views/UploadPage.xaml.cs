using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using XamarinDemo.Core;
using System;
using Windows.UI.Xaml;

namespace XamarinDemo.UWP.Views
{

    public sealed partial class UploadPage : Page
    {
        public string _country;
        public UploadPage()
        {
            this.InitializeComponent();
            Loaded += UploadPage_Loaded;
            buttonUpload.Click += ButtonUpload_Click;
        }

        private async void ButtonUpload_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var demoService = new DemoService();
            var result = await demoService.PostDeveloper(textName.Text,_country);
            if (result)
            {
                var dialog = new MessageDialog("Upload succesful");
                await dialog.ShowAsync();
                Frame rootFrame = Window.Current.Content as Frame;

                if (rootFrame.CanGoBack)
                {
                    rootFrame.GoBack();
                }
            }
            else
            {
                var dialog = new MessageDialog("Upload failed");
                await dialog.ShowAsync();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _country = (string)e.Parameter;
            textCountry.Text = $"Location: {_country}";
        }

        private void UploadPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
    }
}