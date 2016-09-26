using Xamarin.Forms;

namespace XamLoc.FormsCore
{
	public class DevelopersPage : ContentPage
	{
		ListView listView;
		public DevelopersPage()
		{
			Title = "Developers";
			var cell = new DataTemplate(typeof(TextCell));
			cell.SetBinding(TextCell.TextProperty, "Name");
			cell.SetBinding(TextCell.DetailProperty, "Country");

			listView = new ListView
			{
				ItemTemplate =  cell
			};

			Content = new StackLayout
			{
				BackgroundColor = Color.White,
				Children = {
					listView
				}
			};
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			LoadData();
		}

		async void LoadData()
		{
			var demoservice = new DemoService();
			var result = await demoservice.GetDevelopers();
			listView.ItemsSource = result;
		}
	}
}