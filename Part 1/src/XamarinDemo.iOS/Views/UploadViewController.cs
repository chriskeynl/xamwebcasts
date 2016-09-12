using System;
using UIKit;
using XamarinDemo.Core;

namespace XamarinDemo.iOS
{
	public partial class UploadViewController : UIViewController
    {
        public UploadViewController (IntPtr handle) : base (handle)
        {
			
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Title = "Upload";
			TextLocation.Text = $"Location: {((AppDelegate)UIApplication.SharedApplication.Delegate).Country}";
		
			ButtonUpload.TouchUpInside += (sender, e) => Upload();
		}

		async void Upload()
		{
			var service = new DemoService();
			var result = await service.PostDeveloper(TextUsername.Text, ((AppDelegate)UIApplication.SharedApplication.Delegate).Country);
			if (result)
			{
				var alert = new UIAlertView()
				{
					Message = "Upload succesful"
				};
				alert.AddButton("OK");
				alert.Show();

				NavigationController.PopViewController(true);
			}else {
				var alert = new UIAlertView()
				{
					Message = "Upload failed"
				};
				alert.AddButton("OK");
				alert.Show();
			}
		}
    }
}