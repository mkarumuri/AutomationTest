using AutoFramework.Base;
using AutoFramework.Helpers;
using OpenQA.Selenium;

namespace AutoFramework.Prozyle
{
	public class PZHomePage : BasePage
	{
		public PZHomePage(IWebDriver driver) : base(driver) { }
		public PZHomePage(IWebDriver driver, string suiteName) : base(driver) { }

		//    //*[@id="content"]/div/div/div/div/div/div/div/div[1]/h2
		public IWebElement Title()
		{
			return Driver.FindElement(By.XPath("//*[@id='content']/div/div/div/div/div/div/div/div[1]/h2"));
		}
		public IWebElement HeaderTitle()
		{
			return Driver.FindElement(By.XPath("//*[@id='header']/ul/li[2]/a"));
		}
		public IWebElement requiredUserNameMessage
		{
			get { return Driver.Find(By.XPath("//*[@id='l-login']/div[1]/div/span[2]")); }// //*[@id="l-login"]/div[1]/div/span[2]
		}
		public IWebElement requiredPasswordMessage
		{
			get { return Driver.Find(By.XPath("//*[@id='l-login']/div[2]/span[2]")); }//  //*[@id='l-login']/div[2]/span[2]
		}
		public IWebElement validEmail
		{
			get { return Driver.Find(By.XPath("//*[@id='l-login']/div[1]/div/span[2]")); }// //*[@id="l-login"]/div[1]/div/span[2]
		}
		// 
		public IWebElement passwordEmailSent
		{
			get { return Driver.Find(By.XPath("/html/body/div[4]/h2")); }// /html/body/div[4]/h2
		}
		public IWebElement SideMenuTitle
		{
			get { return Driver.Find(By.XPath("//*[@id='sidebar']/div/div/div[2]")); }
		}
		public IWebElement PersonalDetailsTitle
		{
			get { return Driver.Find(By.XPath("//*[@id='userProfileHeader']/h2")); }
		}
		public IWebElement PaymentDetailsTitle
		{
			get { return Driver.Find(By.XPath("//*[@id='content']/div/div/div[1]/h2")); }
		}
		public IWebElement PropertiesInformationTitle
		{
			get { return Driver.Find(By.XPath("//*[@id='content']/div/div/div[1]/h2")); }
		}
	}
}
