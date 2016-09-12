using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using XamarinDemo.Core;

namespace XamarinDemo.iOS
{
    public partial class DevelopersViewController : UITableViewController
    {
        public DevelopersViewController (IntPtr handle) : base (handle)
        {
        }

		List<Developer> _developers;
		public async override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Title = "Developers";

			var demoService = new DemoService();
			_developers = await demoService.GetDevelopers();
			if (_developers != null)
			{
				TableView.Source = new TableSource(_developers);
				TableView.ReloadData();
			}
		}
    }

	public class TableSource : UITableViewSource
	{
		List<Developer> TableItems;
		string CellIdentifier = "DeveloperCell";

		public TableSource(List<Developer> items)
		{
			TableItems = items;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return TableItems.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			Developer item = TableItems[indexPath.Row];

			if (cell == null)
			{ 
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);
			}

			cell.TextLabel.Text = item.Name;
			cell.DetailTextLabel.Text = item.Country;

			return cell;
		}
	}
}