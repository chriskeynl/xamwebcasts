using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamLoc.Forms.UITest
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void AppLaunches()
		{
			app.Screenshot("Main screen.");
		}

		[Test]
		public void UploadLocation()
		{
			app.WaitFor(() => app.Query(e => e.Button("UploadButton")).First().Enabled);
			app.Tap("UploadButton");
			app.EnterText(c => c.Marked("TextFieldUsername"), "Chris");
			app.Screenshot("Upload screen.");
			app.Tap("ButtonUploadLocation");
			app.Tap("button2");
		}

		[Test]
		public void GoToDevelopers()
		{
			app.WaitFor(() => app.Query(e => e.Button("ButtonDevelopers")).First().Enabled);
			app.Tap("ButtonDevelopers");
			app.Screenshot("Developers screen.");
		}
	}
}

