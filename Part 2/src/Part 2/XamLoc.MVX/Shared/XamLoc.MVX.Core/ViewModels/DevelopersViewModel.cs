using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using XamLoc.MVX.Core.Models;
using XamLoc.MVX.Core.Services;

namespace XamLoc.MVX.Core
{
	public class DevelopersViewModel : MvxViewModel
	{
		public string TitleText { get; set; }
		protected override void InitFromBundle(IMvxBundle parameters)
		{
			base.InitFromBundle(parameters);
			TitleText = "Developers";
			_demoService = Mvx.Resolve<IDemoService>();
			LoadData();
		}

		IDemoService _demoService;
		public List<Developer> Developers { get; set; }
		async void LoadData()
		{
			Developers = await _demoService.GetDevelopers();
			RaisePropertyChanged(() => Developers);
		}
	}
}