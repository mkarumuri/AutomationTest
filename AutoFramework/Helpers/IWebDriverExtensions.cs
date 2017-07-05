using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace AutoFramework.Helpers
{
	public static class IWebDriverExtensions
	{
		public static void MoveMouseTo(this IWebDriver driver, IWebElement element)
		{
			var builder = new Actions(driver);
			builder.MoveToElement(element).Build().Perform();
		}

		public static void WaitForUrlToContain(this IWebDriver driver, string urlPart, TimeSpan? timeoutPeriodOverride = null)
		{
			var sw = Stopwatch.StartNew();
			var timeoutPeriod = TimeSpan.FromSeconds(1000);
			if (timeoutPeriodOverride.HasValue)
			{
				timeoutPeriod = timeoutPeriodOverride.Value;
			}
			while (!driver.Url.ToLowerInvariant().Contains(urlPart.ToLowerInvariant()) && sw.Elapsed < timeoutPeriod)
			{
				Console.WriteLine("...Waiting for '{2}' to be in URL - Current URL: {0} (Time elapsed: {1})", driver.Url, sw.Elapsed, urlPart);
				Thread.Sleep(TimeSpan.FromSeconds(1));
			}
			sw.Stop();

			if (!driver.Url.ToLowerInvariant().Contains(urlPart.ToLowerInvariant()))
			{
				throw new TimeoutException(String.Format("...Timeout waiting to be redirected to a page that contains url: {0}", urlPart));
			}
			else
			{
				Console.WriteLine("...Page loaded in: {0}.  URL: {1}", sw.Elapsed, driver.Url);
			}
		}

		public static IWebElement Find(this IWebDriver driver, By by, ExpectedCondition condition = ExpectedCondition.Visible, int waitTime = 15)
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
			wait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException), typeof(NoSuchElementException));

			switch (condition)
			{
				case ExpectedCondition.Clickable:
					{
						wait.Until(ExpectedConditions.ElementToBeClickable(by));
						break;
					}
				case ExpectedCondition.Visible:
					{
						wait.Until(ExpectedConditions.ElementIsVisible(by));
						break;
					}
				case ExpectedCondition.SwitchToFrame:
					{
						wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(by));
						break;
					}
			}

			return driver.FindElement(by);
		}

		public static IList<IWebElement> Finds(this IWebDriver driver, By by)
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
			wait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException), typeof(NoSuchElementException));
			wait.Until(ExpectedConditions.ElementIsVisible(by));

			return driver.FindElements(by);
		}

		public static void ClickNavigationLink(this IWebDriver driver, By topLink, By SubLink, By subSubLink = null)
		{
			Console.WriteLine("...If the navigation fails, move the cucrsor above the webpage.  Any movement will upset the HoverOver menu.");
			var action = new Actions(driver);
			action.MoveToElement(driver.Find(topLink)).Perform();
			Thread.Sleep(1000);
			if (SubLink != null && subSubLink == null)
			{
				driver.Find(SubLink).Click();
			}
			else
			{
				action.MoveToElement(driver.Find(SubLink)).Perform();
				Thread.Sleep(500);
				driver.Find(subSubLink).Click();
			}
		}

		public static IWebElement ScrollToElement(this IWebDriver driver, IWebElement element)
		{
			return (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
		}
		
		public static IWebElement WaitForElement(this IWebDriver driver, By elementSelector)
		{
			IWebElement element = null;

			TimingHelper.WaitForResult(() =>
			{
				try
				{
					element = driver.FindElement(elementSelector);
					return element.Displayed;
				}
				catch
				{
					return false;
				}
			});
			return element;
		}

		public static bool IsElementOnPage(this IWebDriver driver, By locator)
		{
			driver.LowerImplicitWaitTimeoutForNegativeAssertions();
			var e = driver.FindElements(locator);
			var count = e.Count;
			driver.SetTimeoutsToDefaults();

			return count > 0;
		}

		public static void LowerImplicitWaitTimeoutForNegativeAssertions(this IWebDriver driver)
		{
			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(0));
		}

		public static void SetTimeoutsToDefaults(this IWebDriver driver)
		{
			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
			driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(90));
		}

		public static void ScriptExecute(this IWebDriver driver, string script, params object[] args)
		{
			((IJavaScriptExecutor)driver).ExecuteScript(script, args);
		}

		public static T ScriptQuery<T>(this IWebDriver driver, string script, params object[] args)
		{
			return (T)((IJavaScriptExecutor)driver).ExecuteScript(script, args);
		}

		public static void WaitFor(this IWebDriver driver, string conditionExpression, int seconds = 15, params object[] args)
		{
			int cnt = 0;
			bool result;
			do
			{
				if (cnt >= seconds)
				{
					throw new TimeoutException("Wait until true exceeded wait limit.");
				}

				if (cnt++ > 0)
				{
					Thread.Sleep(1000);
				}

				string script = string.Format(@"return {0};", conditionExpression);
				result = driver.ScriptQuery<bool>(script, args);
			} while (result == false);
		}
		
		private static IAlert AlertIsPresent(this IWebDriver driver)
		{
			try
			{
				return driver.SwitchTo().Alert();
			}
			catch (OpenQA.Selenium.NoAlertPresentException)
			{
				return null;
			}
		}

		public static void WaitForAlert(this IWebDriver driver, int seconds = 30)
		{
			TimingHelper.WaitForResult(() => driver.AlertIsPresent() != null, seconds * 1000);
		}

		public static HomePage GoToHomePage(this IWebDriver driver)
		{
			driver.Navigate().GoToUrl(AppConfig.BaseUrl);

			return new HomePage(driver);
		}
		public static TodayDiscounts.HomePage GoToTodayDiscounts(this IWebDriver driver)
		{
			driver.Navigate().GoToUrl(AppConfig.BaseUrl);
			driver.Navigate().GoToUrl(AppConfig.BaseUrl + string.Format(TDConstants.LeftMenu, TDConstants.Products.Laptops, TDConstants.Products.Laptops));
			driver.Navigate().GoToUrl(AppConfig.BaseUrl + string.Format(TDConstants.LeftMenu, TDConstants.Products.Tablets, TDConstants.Products.Tablets));
			driver.Navigate().GoToUrl(AppConfig.BaseUrl + string.Format(TDConstants.LeftMenu, TDConstants.Products.Mobiles, TDConstants.Products.Mobiles));
			driver.Navigate().GoToUrl(AppConfig.BaseUrl + string.Format(TDConstants.LeftMenu, TDConstants.Products.Cameras, TDConstants.Products.Cameras));
			driver.Navigate().GoToUrl(AppConfig.BaseUrl + string.Format(TDConstants.LeftMenu, TDConstants.Products.Televisions, TDConstants.Products.Televisions));
			driver.Navigate().GoToUrl(AppConfig.BaseUrl + string.Format(TDConstants.LeftMenu, TDConstants.Products.HomeAppliances, "Home Appliances"));
			driver.Navigate().GoToUrl(AppConfig.BaseUrl + string.Format(TDConstants.LeftMenu, TDConstants.Products.AirConditioners, "Air Conditioners"));
			driver.Navigate().GoToUrl(AppConfig.BaseUrl + string.Format(TDConstants.LeftMenu, TDConstants.Products.WashingMachines, "Washing Machines"));
			driver.Navigate().GoToUrl(AppConfig.BaseUrl + string.Format(TDConstants.LeftMenu, TDConstants.Products.LuggageBags, "Luggage & Bags"));
			driver.Navigate().GoToUrl(AppConfig.BaseUrl + string.Format(TDConstants.LeftMenu, TDConstants.Products.MensFashion, "Men's Fashion"));
			driver.Navigate().GoToUrl(AppConfig.BaseUrl + string.Format(TDConstants.LeftMenu, TDConstants.Products.WomensFashion, "Women's Fashion"));
			driver.Navigate().GoToUrl(AppConfig.BaseUrl + string.Format(TDConstants.LeftMenu, TDConstants.Products.Books, TDConstants.Products.Books));
			driver.Navigate().GoToUrl(AppConfig.BaseUrl + string.Format(TDConstants.LeftMenu, TDConstants.Products.MusicalInstruments, "Musical Instruments"));
			driver.Navigate().GoToUrl(AppConfig.BaseUrl + string.Format(TDConstants.LeftMenu, TDConstants.Products.Furniture, TDConstants.Products.Furniture));
			driver.Navigate().GoToUrl(AppConfig.BaseUrl + string.Format(TDConstants.LeftMenu, TDConstants.Products.GamesConsoles, "Games & Consoles"));
			driver.Navigate().GoToUrl(AppConfig.BaseUrl + string.Format(TDConstants.LeftMenu, TDConstants.Products.ToysKids, "Toys & Kids"));
			return new TodayDiscounts.HomePage(driver);
		}
		public static Xavica.HomePage GoToXavica(this IWebDriver driver)
		{
			driver.Navigate().GoToUrl(AppConfig.BaseUrl);
			driver.Navigate().GoToUrl(AppConfig.BaseUrl + "/#about");
			driver.Navigate().GoToUrl(string.Format(AppConfig.BaseUrl + "/#" + XavConstants.path.services));
			driver.Navigate().GoToUrl(string.Format(AppConfig.BaseUrl + "/#" + XavConstants.path.mobileapps));
			driver.Navigate().GoToUrl(string.Format(AppConfig.BaseUrl + "/#" + XavConstants.path.webdesign));
			driver.Navigate().GoToUrl(string.Format(AppConfig.BaseUrl + "/#" + XavConstants.path.webdevelopment));
			driver.Navigate().GoToUrl(string.Format(AppConfig.BaseUrl + "/#" + XavConstants.path.seo));
			driver.Navigate().GoToUrl(string.Format(AppConfig.BaseUrl + "/#" + XavConstants.path.digital));
			driver.Navigate().GoToUrl(string.Format(AppConfig.BaseUrl + "/#" + XavConstants.path.analytics));
			driver.Navigate().GoToUrl(string.Format(AppConfig.BaseUrl + "/#" + XavConstants.path.process));
			driver.Navigate().GoToUrl(string.Format(AppConfig.BaseUrl + "/#" + XavConstants.path.RecentProjects));
			driver.Navigate().GoToUrl(string.Format(AppConfig.BaseUrl + "/#" + XavConstants.path.Blogs));
			driver.Navigate().GoToUrl(string.Format(AppConfig.BaseUrl + "/#" + XavConstants.path.teampage));
			driver.Navigate().GoToUrl(string.Format(AppConfig.BaseUrl + "/#" + XavConstants.path.contactus));
			return new Xavica.HomePage(driver);
		}
		
	}

	public enum ExpectedCondition
	{
		Clickable,
		Visible,
		SwitchToFrame
	}
}
