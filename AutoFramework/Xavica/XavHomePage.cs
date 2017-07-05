using AutoFramework.Base;
using AutoFramework.Helpers;
using OpenQA.Selenium;

namespace AutoFramework.Xavica
{
	public class XavHomePage : BasePage
	{
		public XavHomePage(IWebDriver driver) : base(driver) { }

		public IWebElement Title()
		{
			return Driver.FindElement(By.XPath("//*[@id='header']/a/img"));
		}
		public IWebElement TwitterTitle()
		{
			return Driver.FindElement(By.XPath("//*[@id='page - container']/div[2]/div/div/div[1]/div/div/div/div[1]/h1/a"));
		}

		public XavHomePage ClickTwitter()
		{
			var elem = Driver.FindElement(By.XPath("//*[@id='contact']/div/div[2]/ul/li[4]/a"));
			Driver.MoveMouseTo(elem);
			elem.Click();
			return new XavHomePage(Driver);
		}
	}
}
