using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using XamLoc.MVX.Core.Models;

namespace XamLoc.MVX.IOS
{
	public partial class DeveloperCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("DeveloperCell");
		public static readonly UINib Nib;

		static DeveloperCell()
		{
			Nib = UINib.FromName("DeveloperCell", NSBundle.MainBundle);
		}

		protected DeveloperCell(IntPtr handle) : base(handle)
		{
			this.DelayBind(() =>
			{
				var set = this.CreateBindingSet<DeveloperCell, Developer>();
				set.Bind(TextLabel).To(s => s.Name);
				set.Bind(DetailTextLabel).To(s => s.Country);
				set.Apply();
			});
		}
	}
}