using Xamarin.Forms;

namespace XamLoc.FormsCore
{
	public class UploadPage : ContentPage
	{
		Entry _textName;
		Label _textCountry;
		Button _buttonUpload;
		string _country;

		public UploadPage(string country)
		{
			Title = "Upload";
			_country = country;

			_textName = new Entry
			{
				AutomationId = "TextFieldUsername",
				Placeholder = "Username (optional)"
			};

			_textCountry = new Label
			{
				Text = $"Current location: {_country}"
			};

			_buttonUpload = new Button
			{
				AutomationId = "ButtonUploadLocation",
				BackgroundColor = Color.FromRgb(255,127,0),
				TextColor = Color.White,
				Text = "Upload"
			};
			_buttonUpload.Clicked += (sender, e) => ButtonClicked();

			Content = new StackLayout
			{
				BackgroundColor = Color.White,
				Spacing = 10,
				Padding = new Thickness(20,10),
				Orientation = StackOrientation.Vertical,
				Children = {
					_textName,
					_textCountry,
					_buttonUpload
				}
			};
		}

		async void ButtonClicked()
		{
			var demoservice = new DemoService();
			var result = await demoservice.PostDeveloper(_textName.Text, _country);
			if (result)
			{
				await DisplayAlert("Upload", "Upload succeful", "Ok");
				await Navigation.PopAsync();
			}
			else {
				await DisplayAlert("Upload", "Upload failes", "Ok");
			}
		}
	}
}