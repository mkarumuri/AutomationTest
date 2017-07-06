using AutoFramework.Xavica;
using OpenQA.Selenium;

namespace AutoFramework.Helpers
{
	public static class XavWDExtensions
	{
		public static XavHomePage GoToHome(this IWebDriver driver)
		{
			driver.Navigate().GoToUrl(AppConfig.BaseUrl);
			return new XavHomePage(driver);
		}

		public static XavHomePage GoToContact(this IWebDriver driver)
		{
			driver.Navigate().GoToUrl(string.Format(AppConfig.BaseUrl + "/#" + XavConstants.path.contactus));
			return new XavHomePage(driver);
		}
	}
}
