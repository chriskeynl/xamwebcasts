using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using XamLoc.MVX.Core;

namespace XamLoc.MVX.IOS
{
	public partial class UploadView : MvxViewController
	{
		public UploadView() : base("UploadView", null)
		{
			
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			SetBindings();
		}

		void SetBindings()
		{
			var set = this.CreateBindingSet<UploadView, UploadViewModel>();
			set.Bind(ButtonUpload).For("Title").To(s => s.ButtonUploadText);
			set.Bind(ButtonUpload).To(s => s.ButtonUploadCommand);
			set.Bind(ButtonUpload).For(s => s.BackgroundColor).To(s => s.ButtonUploadColor).WithConversion("NativeColor");

			set.Bind(TextCurrentLocation).For(s => s.Text).To(s => s.CurrentLocationText);

			set.Bind(TextName).For("Text").To(s => s.NameText);
			set.Bind(TextName).For("Placeholder").To(s => s.NamePlaceHolderText);
			set.Apply();
		}
	}
}