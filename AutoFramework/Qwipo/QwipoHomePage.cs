using AutoFramework.Base;
using OpenQA.Selenium;

namespace AutoFramework.Qwipo
{
	public class QwipoHomePage: BasePage
	{
		public QwipoHomePage(IWebDriver driver) : base(driver) { }

		public IWebElement Title()
		{
			return Driver.FindElement(By.XPath("/html/body/header/div[1]"));
		}

	}
}
