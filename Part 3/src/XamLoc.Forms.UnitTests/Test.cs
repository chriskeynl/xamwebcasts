using NUnit.Framework;
using XamLoc.FormsCore;

namespace XamLoc.Forms.UnitTests
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void DashboardStats()
		{
			var developer = new Developer();
			var description = developer.Description;

			Assert.IsNullOrEmpty(description);
		}
	}
}
