using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using XamarinDemo.Core;

namespace XamarinDemo.UWP.Views
{
    public sealed partial class DevelopersPage : Page
    {
        public DevelopersPage()
        {
            this.InitializeComponent();
            this.Loaded += DevelopersPage_Loaded;
        }

        private void DevelopersPage_Loaded(object sender, RoutedEventArgs e)
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            LoadData();
        }

        async void LoadData()
        {
            var demoService = new DemoService();
            var items = await demoService.GetDevelopers();
            ListView.ItemsSource = items;
        }
    }
}