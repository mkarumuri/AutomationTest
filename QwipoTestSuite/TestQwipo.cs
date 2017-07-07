using AutoFramework.Base;
using AutoFramework.Helpers;
using AutoFramework.Qwipo;
using NUnit.Framework;

namespace QwipoTestSuite
{
	public class TestQwipo : TestBase
	{
		[Test]
		public void TestHomePage()
		{
			WebTest((driver) =>
			{
				var homePage = new QwipoHomePage(driver);

				driver.GoToQwipoHome();
				Assert.IsTrue(homePage.Title().Displayed);
			}, "QwipoTestSuite");
		}
	}
}
