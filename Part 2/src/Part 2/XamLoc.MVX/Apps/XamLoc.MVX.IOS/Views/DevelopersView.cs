using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;
using XamLoc.MVX.Core;

namespace XamLoc.MVX.IOS
{
	public partial class DevelopersView : MvxViewController
	{
		public DevelopersView() : base("DevelopersView", null)
		{

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Title = ((DevelopersViewModel)ViewModel).TitleText;
			SetBindings();
		}

		void SetBindings()
		{
			var source = new CountryTableSource(TableView);
			TableView.Source = source;

			var set = this.CreateBindingSet<DevelopersView, DevelopersViewModel>();
			set.Bind(source).For(x => x.ItemsSource).To(v => v.Developers);
			set.Apply();
		}
	}

	public class CountryTableSource : MvxTableViewSource
	{
		public CountryTableSource(UITableView tableView) : base(tableView)
		{
			tableView.RegisterNibForCellReuse(DeveloperCell.Nib, DeveloperCell.Key);
		}

		protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
		{
			return TableView.DequeueReusableCell("DeveloperCell", indexPath);
		}
	}
}