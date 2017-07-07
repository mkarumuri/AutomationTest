using AutoFramework.Base;
using AutoFramework.Helpers;
using AutoFramework.Xavica;
using NUnit.Framework;
using System;

namespace XavicaTestSuite
{
	public class TestXavica : TestBase
	{
		/// <summary>
		/// Check all urls loading thru debugguing
		/// </summary>		
		[Test]
		public void Xavica()
		{
			WebTest((driver) =>
			{
				driver.GoToXavica();
			}, "XavicaTestSuite");
		}

		/// <summary>
		/// Test to Verify home page is loaded using title is displayed
		/// </summary>
		[Test]
		public void TestHomePage()
		{
			WebTest((driver) =>
			{
				var homePage = new XavHomePage(driver);

				driver.GoToHome();
				Assert.IsTrue(homePage.Title().Displayed);
			}, "XavicaTestSuite");
		}

		/// <summary>
		/// Test to verify Contact link tab open in new window and check title is displayed
		/// </summary>
		[Test]
		public void TestContactPage()
		{
			WebTest((driver) =>
			{
				var homePage = new XavHomePage(driver);

				driver.GoToHome();
				driver.GoToContact();
				homePage.ClickTwitter();
				var browserTabs = driver.WindowHandles;
				driver.SwitchTo().Window(browserTabs[1]);

				Console.WriteLine("New Window Title: " + driver.Title);

				Assert.AreEqual("Xavica Services (@xavicaservices) | Twitter", driver.Title);

				driver.Close();
				driver.SwitchTo().Window(browserTabs[0]);
			}, "XavicaTestSuite");
		}
	}
}
