using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.UI;
using XamLoc.MVX.Core.Services;

namespace XamLoc.MVX.Core
{
	public class UploadViewModel : MvxViewModel
	{
		public string TitleText { get; set; }
		public string NamePlaceHolderText { get; set; }

		public string NameText { get; set; }
		public string CurrentLocationText { get; set; }
		string _country { get; set; }
		public string ButtonUploadText { get; set; }

		public MvxCommand ButtonUploadCommand { get; set; }
		public MvxColor ButtonUploadColor { get; set; }

		IDemoService _demoService;

		public UploadViewModel()
		{
			TitleText = "Upload";
			ButtonUploadText = "Upload";
			NamePlaceHolderText = "Username (optional)";

			ButtonUploadCommand = new MvxCommand(HandleUploadCommand);
			ButtonUploadColor = new MvxColor(255, 127, 0);
			_demoService = Mvx.Resolve<IDemoService>();
		}

		protected override void InitFromBundle(IMvxBundle parameters)
		{
			base.InitFromBundle(parameters);
			if(parameters.Data.ContainsKey("Location")){
				_country = parameters.Data["Location"];
				CurrentLocationText = $"Current location: {_country}";
				RaisePropertyChanged(() => CurrentLocationText);
			}
		}

		async void HandleUploadCommand()
		{
			var result = await _demoService.PostDeveloper(NameText, _country);
			if (result)
			{
				await UserDialogs.Instance.AlertAsync("Upload", "Upload succeful", "Ok");
				Close(this);
			}
			else{
				await UserDialogs.Instance.AlertAsync("Upload", "Upload failed", "Ok");
			}
		}
	}
}