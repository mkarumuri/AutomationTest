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
		public IWebElement AddPropertyTabTitle
		{
			get { return Driver.Find(By.XPath("//*[@id='content']/div/div/div/div/div/compose/ul/li[1]/a")); }
		}

		//Add Property page
		public IWebElement ChecklistHeader
		{
			get { return Driver.Find(By.XPath("//*[@id='content']/div/div/div[2]/div[1]/h4")); }
		}
		public IWebElement ReqTitleMessage { get { return Driver.Find(By.XPath("//*[@id='content']/div/div/div/div/div/div/div[1]/div[1]/div/div/div[1]/span")); } }
		public IWebElement ReqHolderNameMessage { get { return Driver.Find(By.XPath("//*[@id='content']/div/div/div/div/div/div/div[1]/div[1]/div/div/div[2]/span")); } }
		public IWebElement ReqTypeMessage { get { return Driver.Find(By.XPath("//*[@id='content']/div/div/div/div/div/div/div[1]/div[1]/div/div/div[3]/span")); } }
		public IWebElement ReqAddressMessage { get { return Driver.Find(By.XPath("//*[@id='content']/div/div/div/div/div/div/div[1]/div[2]/div/div/dl[1]/span")); } }
		public IWebElement ReqCityMessage { get { return Driver.Find(By.XPath("//*[@id='content']/div/div/div/div/div/div/div[1]/div[2]/div/div/dl[3]/span")); } }
		public IWebElement ReqPinCodeMessage { get { return Driver.Find(By.XPath("//*[@id='content']/div/div/div/div/div/div/div[1]/div[2]/div/div/dl[4]/span")); } }
		public IWebElement ReqValidPinCodeMessage { get { return Driver.Find(By.XPath("//*[@id='content']/div/div/div/div/div/div/div[1]/div[2]/div/div/dl[4]/span")); } }
		public IWebElement ReqStateMessage { get { return Driver.Find(By.XPath("//*[@id='content']/div/div/div/div/div/div/div[1]/div[2]/div/div/div/span")); } }
		public IWebElement ReqMaxContactNumberMessage { get { return Driver.Find(By.XPath("//*[@id='content']/div/div/div/div/div/div/div[2]/div[2]/div/div/dl[2]/dd/div/span")); } }
		public IWebElement ReqValidContactNumberMessage { get { return Driver.Find(By.XPath("//*[@id='content']/div/div/div/div/div/div/div[2]/div[2]/div/div/dl[2]/dd/div/span")); } }
		
	}
}
