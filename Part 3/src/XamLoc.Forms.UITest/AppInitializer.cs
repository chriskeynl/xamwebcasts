using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamLoc.Forms.UITest
{
	public class AppInitializer
	{
		public static IApp StartApp(Platform platform)
		{
			// TODO: If the iOS or Android app being tested is included in the solution 
			// then open the Unit Tests window, right click Test Apps, select Add App Project
			// and select the app projects that should be tested.
			//
			// The iOS project should have the Xamarin.TestCloud.Agent NuGet package
			// installed. To start the Test Cloud Agent the following code should be
			// added to the FinishedLaunching method of the AppDelegate:
			//
			//    #if ENABLE_TEST_CLOUD
			//    Xamarin.Calabash.Start();
			//    #endif
			if (platform == Platform.Android)
			{
				//var path = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
				//var info = new FileInfo(path);
				//var directory = info.Directory.Parent.Parent.Parent.FullName;

				//var pathToSdk = Path.Combine(directory, "Apps", "XamLoc.Forms.Android", "bin", "Release", "com.webcast.xamloc-Signed.apk");

				//return ConfigureApp
				//	.Android
				//	.EnableLocalScreenshots()
				//	// TODO: Update this path to point to your Android app and uncomment the
				//	//.ApkFile (pathToSdk)
				//	.StartApp(Xamarin.UITest.Configuration.AppDataMode.Clear);

				return ConfigureApp.Android.EnableLocalScreenshots().StartApp();
			}

			return ConfigureApp
				.iOS
				// TODO: Update this path to point to your iOS app and uncomment the
				// code if the app is not included in the solution.
				//.AppBundle ("../../../iOS/bin/iPhoneSimulator/Debug/XamarinForms.iOS.app")
				.StartApp();
		}
	}
}

