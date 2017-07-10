using AutoFramework.Xavica;
using AutoFramework.Xavica.Constants;
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
		public static XavHomePage GoToContact(this IWebDriver driver, string name, string email, string message,string btnAction)
		{
			driver.Navigate().GoToUrl(string.Format(AppConfig.BaseUrl + "/#" + XavConstants.path.contactus));
			var homePage = new XavHomePage(driver);
			homePage.GoToContact(name, email, message,btnAction);
			return new XavHomePage(driver);
		}
	}
}
