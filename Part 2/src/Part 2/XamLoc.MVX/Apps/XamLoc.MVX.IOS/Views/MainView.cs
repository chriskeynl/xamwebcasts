using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using XamLoc.MVX.Core;

namespace XamLoc.MVX.IOS
{
	public partial class MainView : MvxViewController
	{
		public MainView() : base("MainView", null){}

		protected MainView(IntPtr handle) : base(handle){}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Title = ((MainViewModel)ViewModel).TitleText;
			NavigationController.NavigationBar.Translucent = false;
			NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB(68, 99, 215);

			SetBindings();
		}

		void SetBindings() {
			var set = this.CreateBindingSet<MainView, MainViewModel>();
			set.Bind(ButtonUpload).For("Title").To(s => s.ButtonUploadText);
			set.Bind(ButtonUpload).To(s => s.ButtonUploadCommand);
			set.Bind(ButtonUpload).For(s => s.BackgroundColor).To(s => s.ButtonUploadColor).WithConversion("NativeColor");
			set.Bind(ButtonUpload).For(s => s.Enabled).To(s => s.IsButtonUploadEnabled);

			set.Bind(ButtonDevelopers).For("Title").To(s => s.ButtonDevelopersText);
			set.Bind(ButtonDevelopers).To(s => s.ButtonDevelopersCommand);
			set.Bind(ButtonDevelopers).For(s => s.BackgroundColor).To(s => s.ButtonDevelopersColor).WithConversion("NativeColor");

			set.Bind(TextDevelopersCount).For(s => s.Text).To(s => s.DashboardStatistics.NumberOfDevelopers);
			set.Bind(TextCountriesCount).For(s => s.Text).To(s => s.DashboardStatistics.NumberOfCountries);
			set.Bind(TextCurrentLocation).For(s => s.Text).To(s => s.CurrentLocationText);

			set.Bind(ActivityIndicator).For("Visibility").To(s => s.IsButtonUploadEnabled).WithConversion("InvertedVisibility");
			set.Bind(BackgroundView).For(s => s.BackgroundColor).To(s => s.BackgroundColor).WithConversion("NativeColor");
			set.Apply();
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			((MainViewModel)ViewModel).LoadData();
		}
	}
}