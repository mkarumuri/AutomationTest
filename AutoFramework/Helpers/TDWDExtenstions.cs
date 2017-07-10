using AutoFramework.TodayDiscounts;
using AutoFramework.TodayDiscounts.Constants;
using OpenQA.Selenium;

namespace AutoFramework.Helpers
{
	public static class TDWDExtenstions
	{
		public static TDHomePage GoToTDHomePage(this IWebDriver driver)
		{
			driver.Navigate().GoToUrl(AppConfig.BaseUrl);
			return new TDHomePage(driver);
		}
		public static TDHomePage GoToLeftMenu(this IWebDriver driver, string categoryType,string categoryName)
		{
			driver.Navigate().GoToUrl(AppConfig.BaseUrl + string.Format(TDConstants.LeftMenu, categoryType, categoryName));
			return new TDHomePage(driver);
		}
	}
}
