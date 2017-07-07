using AutoFramework.Base;
using AutoFramework.Helpers;
using OpenQA.Selenium;

namespace AutoFramework.TodayDiscounts
{
	public class TDHomePage : BasePage
	{
		public TDHomePage(IWebDriver driver) : base(driver) { }
		public IWebElement Title()
		{
			return Driver.FindElement(By.XPath("//*[@id='header']/div/nav/div/h1/a/img"));
		}
		public IWebElement sideMenu
		{
			get { return Driver.Find(By.XPath("//*[@id='main']/div/div/div/div/div/h6")); } 
		}
		public IWebElement luggageSideMenu
		{
			get { return Driver.Find(By.XPath("//*[@id='main']/div/div/div/div/div/h6")); } 
		}

		public TDHomePage ClickItem()
		{
			var elem = Driver.FindElement(By.XPath("//*[@id='main']/div/div/div/div/div/div[2]/div/div[2]/a")); // second item path			
			Driver.MoveMouseTo(elem);
			elem.Click();
			return new TDHomePage(Driver);
		}
	}
}
