using AutoFramework.Base;
using AutoFramework.Helpers;
using AutoFramework.TodayDiscounts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayDiscountsTestSuite
{
	public class TestTD : TestBase
	{

		[Test]
		public void TodayDiscounts()
		{
			WebTest((driver) =>
			{
				driver.GoToTodayDiscounts();
			}, "TodayDiscountsTestSuite");
		}
		/// <summary>
		/// Test to Verify home page is loaded using title is displayed
		/// </summary>
		[Test]
		public void TestHomePage()
		{
			WebTest((driver) =>
			{
				var homePage = new TDHomePage(driver);

				driver.GoToTDHomePage();
				Assert.IsTrue(homePage.Title().Displayed);
			}, "TodayDiscountsTestSuite");
		}
		/// <summary>
		/// Test to Verify Side Menu Click 
		/// </summary>
		[Test]
		public void TestSideMenu()
		{
			WebTest((driver) =>
			{
				var homePage = new TDHomePage(driver);
				CheckSideMenu(driver, homePage);

			}, "TodayDiscountsTestSuite");
		}

		private static void CheckSideMenu(OpenQA.Selenium.IWebDriver driver, TDHomePage homePage)
		{
			driver.GoToLeftMenu(TDConstants.Products.Laptops.ToString(), TDConstants.Products.Laptops.ToString());
			Assert.AreEqual(TDConstants.Products.Laptops.ToString(), homePage.sideMenu.Text, "Laptops Failed");

			driver.GoToLeftMenu(TDConstants.Products.Tablets.ToString(), TDConstants.Products.Tablets.ToString());
			Assert.AreEqual(TDConstants.Products.Tablets.ToString(), homePage.sideMenu.Text, "Tablets Failed");

			driver.GoToLeftMenu(TDConstants.Products.Mobiles.ToString(), TDConstants.Products.Mobiles.ToString());
			Assert.AreEqual(TDConstants.Products.Mobiles.ToString(), homePage.sideMenu.Text, "Mobiles Failed");

			driver.GoToLeftMenu(TDConstants.Products.Cameras.ToString(), TDConstants.Products.Cameras.ToString());
			Assert.AreEqual(TDConstants.Products.Cameras.ToString(), homePage.sideMenu.Text, "Cameras Failed");

			driver.GoToLeftMenu(TDConstants.Products.Televisions.ToString(), TDConstants.Products.Televisions.ToString());
			Assert.AreEqual(TDConstants.Products.Televisions.ToString(), homePage.sideMenu.Text, "Televisions Failed");

			driver.GoToLeftMenu(TDConstants.Products.HomeAppliances.ToString(), "Home Appliances");
			Assert.AreEqual("Home Appliances", homePage.sideMenu.Text, "HomeAppliances Failed");

			driver.GoToLeftMenu(TDConstants.Products.AirConditioners.ToString(), "Air Conditioners");
			Assert.AreEqual("Air Conditioners", homePage.sideMenu.Text, "AirConditioners Failed");

			driver.GoToLeftMenu(TDConstants.Products.WashingMachines.ToString(), "Washing Machines");
			Assert.AreEqual("Washing Machines", homePage.sideMenu.Text, "WashingMachines Failed");

			driver.GoToLeftMenu(TDConstants.Products.LuggageBags.ToString(), "Luggage & Bags");
			Assert.AreEqual("Luggage", homePage.sideMenu.Text, "LuggageBags Failed");

			driver.GoToLeftMenu(TDConstants.Products.MensFashion.ToString(), "Men's Fashion");
			Assert.AreEqual("Men's Fashion", homePage.sideMenu.Text, "MensFashion Failed");

			driver.GoToLeftMenu(TDConstants.Products.WomensFashion.ToString(), "Women's Fashion");
			Assert.AreEqual("Women's Fashion", homePage.sideMenu.Text, "WomensFashion Failed");

			//driver.GoToLeftMenu(TDConstants.Products.Books.ToString(), TDConstants.Products.Books.ToString());
			//Assert.AreEqual(TDConstants.Products.Books.ToString(), homePage.sideMenu.Text, "Books Failed");

			driver.GoToLeftMenu(TDConstants.Products.MusicalInstruments.ToString(), "Musical Instruments");
			Assert.AreEqual("Musical Instruments", homePage.sideMenu.Text, "MusicalInstruments Failed");

			driver.GoToLeftMenu(TDConstants.Products.Furniture.ToString(), TDConstants.Products.Furniture.ToString());
			Assert.AreEqual(TDConstants.Products.Furniture.ToString(), homePage.sideMenu.Text, "Furniture Failed");

			driver.GoToLeftMenu(TDConstants.Products.GamesConsoles.ToString(), "Games & Consoles");
			Assert.AreEqual("Games", homePage.sideMenu.Text, "GamesConsoles Failed");

			driver.GoToLeftMenu(TDConstants.Products.ToysKids.ToString(), "Toys & Kids");
			Assert.AreEqual("Toys", homePage.sideMenu.Text, "ToysKids Failed");
		}
	}
}
