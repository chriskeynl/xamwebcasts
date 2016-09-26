using Windows.UI.Xaml.Controls;

namespace XamLoc.MVX.UWP
{
    public class Setup : MvvmCross.WindowsUWP.Platform.MvxWindowsSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {

        }

        protected override MvvmCross.Core.ViewModels.IMvxApplication CreateApp()
        {
            return new Core.App();
        }
    }
}