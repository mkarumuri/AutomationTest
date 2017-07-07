using AutoFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Diagnostics;
using System.IO;

namespace AutoFramework.Base
{
	public abstract class TestBase
	{
		protected void WebTest(Action<IWebDriver> test, string suiteName, string userAgentOverride)
		{
			var testTime = Stopwatch.StartNew();
			using (var driver = GetWebDriver(userAgentOverride, suiteName))
			{
				Console.WriteLine("...elapsed time: {0}", testTime.Elapsed);
				try
				{
					driver.Manage().Window.Maximize();
					test.Invoke(driver);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					var now = DateTime.Now;
					WriteCurrentUrlSafe(driver);
					throw;
				}
				finally
				{
					var sw = Stopwatch.StartNew();
					driver.Close();
					sw.Stop();
					Console.WriteLine("...Driver.Close() elapsed time: {0}", sw.Elapsed);
					sw.Restart();
					driver.Quit();
					sw.Stop();
					Console.WriteLine("...Driver.Quit() elapsed time: {0}", sw.Elapsed);
					Console.WriteLine("...Total test time: {0}", testTime.Elapsed);
				}
			}
		}
		protected void WebTest(Action<IWebDriver> test)
		{
			WebTest(test, null);
		}
		protected void WebTest(Action<IWebDriver> test, string suiteName)
		{
			WebTest(test, suiteName, null);
		}
		private IWebDriver GetWebDriver(string userAgentOverride, string suiteName)
		{
			var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
			var actualPath = pth.Substring(0, pth.LastIndexOf(suiteName));
			var projectPath = new Uri(actualPath).LocalPath;
			var DriverPath = Path.GetFullPath(Path.Combine(projectPath, @".\AutoFramework\Drivers\"));
			var selectedBrowser = AppConfig.WebDriver;
			Console.WriteLine("...Opening {0}", selectedBrowser);
			switch (selectedBrowser)
			{
				case "firefox":
					FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(DriverPath);
					service.FirefoxBinaryPath = @"C:\Program Files(x86)\Mozilla Firefox\firefox.exe";
					FirefoxOptions options2 = new FirefoxOptions();
					TimeSpan time = TimeSpan.FromSeconds(10);
					return new FirefoxDriver(service, options2, time);
				//DesiredCapabilities options2 = DesiredCapabilities.Firefox();
				//return new RemoteWebDriver((new Uri("http://10.200.11.177:5555/wd/hub")), options2);
				case "ie":
					InternetExplorerOptions options = new InternetExplorerOptions();
					options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
					options.EnableNativeEvents = true;
					options.UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Accept;
					options.BrowserCommandLineArguments = "-private";
					options.RequireWindowFocus = true; //Required for it to run propertly maybe
					return new InternetExplorerDriver(DriverPath, options);
				case "chrome":
					return new ChromeDriver(DriverPath);
				default:
					throw new Exception(String.Format("...Web driver not found: {0}", selectedBrowser));
			}
		}
		private void WriteCurrentUrlSafe(IWebDriver driver)
		{
			try
			{
				Console.WriteLine("...Test failed at URL: {0}", driver.Url);
			}
			catch (Exception exception)
			{
				Console.WriteLine("...Could not report URL test failed at.  Exception: {0}\n{1}", exception.Message, exception.StackTrace);
			}
		}
	}
}
