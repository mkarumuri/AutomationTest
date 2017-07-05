using AutoFramework.Prozyle;
using OpenQA.Selenium;

namespace AutoFramework.Helpers
{
	public static class ProzyleWDExtensions
	{
		public static PZHomePage GoToProzyleHome(this IWebDriver driver, string userName, string password, string urlPart)
		{
			driver.Navigate().GoToUrl(string.Format("{0}{1}", AppConfig.BaseUrl, urlPart));
			var loginPage = new PZLoginPage(driver);
			loginPage.Login(userName, password);

			return new PZHomePage(driver);
		}
		public static PZHomePage LogoutProzyleHome(this IWebDriver driver, string urlPart)
		{
			driver.Navigate().GoToUrl(string.Format("{0}{1}", AppConfig.BaseUrl, urlPart));
			var loginPage = new PZLoginPage(driver);
			loginPage.Logout();

			return new PZHomePage(driver);
		}

		public static PZHomePage GoToProzyleRegister(this IWebDriver driver, string urlPart, string fName, string lName, string email, string confirmEmail, string password, string confirmPassword, string country, string contactNumber)
		{
			driver.Navigate().GoToUrl(string.Format("{0}{1}", AppConfig.BaseUrl, urlPart));
			var registerPage = new PZRegisterPage(driver);
			registerPage.Register(fName, lName, email, confirmEmail, password, confirmPassword, country, contactNumber);

			return new PZHomePage(driver);
		}

		public static PZHomePage GoToForgotPassword(this IWebDriver driver, string userName, string urlPart)
		{
			driver.Navigate().GoToUrl(string.Format("{0}{1}", AppConfig.BaseUrl, urlPart));
			var loginPage = new PZLoginPage(driver);
			loginPage.ClickForgotPassword(userName);

			return new PZHomePage(driver);
		}

		public static PZHomePage GoToPersonalDetails(this IWebDriver driver, string urlPart)
		{
			driver.Navigate().GoToUrl(string.Format("{0}{1}", AppConfig.BaseUrl, urlPart));
			var loginPage = new PZLoginPage(driver);
			loginPage.ClickPersonalDetails();

			return new PZHomePage(driver);
		}

		public static PZHomePage GoToPaymentDetails(this IWebDriver driver, string urlPart)
		{
			driver.Navigate().GoToUrl(string.Format("{0}{1}", AppConfig.BaseUrl, urlPart));
			var loginPage = new PZLoginPage(driver);
			loginPage.ClickPaymentDetails();

			return new PZHomePage(driver);
		}

		public static PZHomePage GoToPropertiesInformation(this IWebDriver driver, string urlPart)
		{
			driver.Navigate().GoToUrl(string.Format("{0}{1}", AppConfig.BaseUrl, urlPart));
			var loginPage = new PZLoginPage(driver);
			loginPage.ClickPropertiesInformation();

			return new PZHomePage(driver);
		}
	}
}
