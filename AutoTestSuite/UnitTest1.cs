using AutoFramework.Base;
using AutoFramework.Helpers;
using NUnit.Framework;

namespace AutoTestSuite
{
	public class UnitTest1 : TestBase
	{
		[Test]
		public void TestMethod1()
		{
			WebTest((driver) => {
				driver.GoToHomePage();
			}, "AutoTestSuite");
		}

		[Test]
		public void TodayDiscounts()
		{
			WebTest((driver) => {
				driver.GoToTodayDiscounts();
			}, "AutoTestSuite");
		}
		[Test]
		public void Xavica()
		{
			WebTest((driver) => {
				driver.GoToXavica();
			},"AutoTestSuite");
		}
	}
}
