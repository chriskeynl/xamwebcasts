using System.Collections.Generic;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using XamarinDemo.Core;

namespace XamarinDemo.Android
{
	[Activity(ScreenOrientation = ScreenOrientation.Portrait)]
	public class DevelopersActivity:Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Developers);

			var toolbar = FindViewById<global::Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
			toolbar.Title = "Developers";

			LoadData();
		}

		async void LoadData()
		{
			var items = await new DemoService().GetDevelopers();
			if (items != null)
			{
				FindViewById<ListView>(Resource.Id.listView).Adapter = new DevelopersAdapter(this, items);
			}
		}
	}

	public class DevelopersAdapter : BaseAdapter<Developer>
	{
		List<Developer> items;
		Activity context;
		public DevelopersAdapter(Activity context, List<Developer> items)
			: base()
		{
			this.context = context;
			this.items = items;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override Developer this[int position]
		{
			get { return items[position]; }
		}
		public override int Count
		{
			get { return items.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = items[position];

			View view = convertView;
			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.ItemDeveloper, null);
		
			var textTop = (TextView)((LinearLayout)view).GetChildAt(0);
			textTop.Text = item.Name;

			var textBottom = (TextView)((LinearLayout)view).GetChildAt(1);
			textBottom.Text = item.Country;

			return view;
		}
	}
}