using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutoFramework.Base
{
	public abstract class BasePage
	{
		protected IWebDriver Driver { get; private set; }

		public BasePage(IWebDriver driver)
		{
			Driver = driver;
			PageFactory.InitElements(Driver, this);
		}
		public BasePage(IWebDriver driver,string suiteName)
		{
			Driver = driver;
			PageFactory.InitElements(Driver, this);
		}
	}
}
