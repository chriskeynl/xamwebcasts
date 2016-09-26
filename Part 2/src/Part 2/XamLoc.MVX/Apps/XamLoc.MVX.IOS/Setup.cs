using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using XamLoc.MVX.Core;

namespace XamLoc.MVX.IOS
{
	public class Setup : MvxIosSetup
	{
		public Setup(MvxApplicationDelegate appDelegate, IMvxIosViewPresenter presenter)
			: base(appDelegate, presenter)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}
	}
}