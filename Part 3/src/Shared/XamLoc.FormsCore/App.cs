using Xamarin.Forms;

namespace XamLoc.FormsCore
{
	public class App : Application
	{
		public App()
		{
			MainPage = new NavigationPage(new MainPage())
			{
	
			};
		}
	}
}