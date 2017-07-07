using AutoFramework.Qwipo;
using OpenQA.Selenium;

namespace AutoFramework.Helpers
{
	public static class QpWDExtensions
	{
		public static QwipoHomePage GoToQwipoHome(this IWebDriver driver)
		{
			driver.Navigate().GoToUrl(AppConfig.BaseUrl);
			return new QwipoHomePage(driver);
		}
	}
}
