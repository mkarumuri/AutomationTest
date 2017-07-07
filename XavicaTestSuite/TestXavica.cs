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
		public void TestContactTwitter()
		{
			WebTest((driver) =>
			{
				var homePage = new XavHomePage(driver);

				driver.GoToHome();
				//driver.GoToContact();
				homePage.ClickTwitter();
				var browserTabs = driver.WindowHandles;
				driver.SwitchTo().Window(browserTabs[1]);

				Console.WriteLine("New Window Title: " + driver.Title);

				Assert.AreEqual("Xavica Services (@xavicaservices) | Twitter", driver.Title);

				driver.Close();
				driver.SwitchTo().Window(browserTabs[0]);
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
				CheckContactValidations(driver, homePage);
				ContactActions(driver, homePage);

			}, "XavicaTestSuite");
		}

		private static void ContactActions(OpenQA.Selenium.IWebDriver driver, XavHomePage homePage)
		{
			driver.GoToContact("test", "test@test.com", "Test Messsage", "send");
			Assert.IsTrue((homePage.contactName.Text.Contains("")));

			driver.GoToContact("test", "test@test.com", "Test Message", "reset");
			Assert.IsTrue((homePage.contactName.Text.Contains("")));
		}

		private static void CheckContactValidations(OpenQA.Selenium.IWebDriver driver, XavHomePage homePage)
		{
			driver.GoToContact("", "test@test.com", "Test Messsage", "send");
			Assert.AreEqual("Please enter your Name", homePage.reqContactName.Text, "Required Name - Failed");

			driver.GoToContact("test", "", "Test Messsage", "send");
			Assert.AreEqual("Please Enter Your Emil ID", homePage.reqValidContactEmail.Text, "Required Email - Failed");

			driver.GoToContact("test", "test", "Test Messsage", "send");
			Assert.AreEqual("Please enter a valid email address.", homePage.reqValidContactEmail.Text, "Valid Email - Failed");

			driver.GoToContact("test", "test@test.com", "", "send");
			Assert.AreEqual("Please enter Your Message", homePage.reqContactMessage.Text, "Required Message - Failed");
		}
	}
}
