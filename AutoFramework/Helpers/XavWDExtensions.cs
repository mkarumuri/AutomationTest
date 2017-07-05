using OpenQA.Selenium;

namespace AutoFramework.Helpers
{
	public static class XavWDExtensions
	{
		public static HomePage GoToHome(this IWebDriver driver)
		{
			driver.Navigate().GoToUrl(AppConfig.BaseUrl);
			return new HomePage(driver);
		}

		public static HomePage GoToContact(this IWebDriver driver)
		{
			driver.Navigate().GoToUrl(string.Format(AppConfig.BaseUrl + "/#" + XavConstants.path.contactus));
			return new HomePage(driver);
		}
	}
}
