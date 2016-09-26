using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform.Platform;

namespace XamLoc.MVX.Android
{
	public class Setup : MvxAndroidSetup
	{
		public Setup(Context applicationContext) : base(applicationContext)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new Core.App();
		}

		protected override IMvxTrace CreateDebugTrace()
		{
			return new MvxDebugTrace();
		}

		protected override void InitializeFirstChance()
		{
			base.InitializeFirstChance();
		}
	}
}