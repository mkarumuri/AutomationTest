using AutoFramework.Base;
using AutoFramework.Helpers;
using OpenQA.Selenium;
using System.Threading;

namespace AutoFramework.Xavica
{
	public class XavHomePage : BasePage
	{
		public XavHomePage(IWebDriver driver) : base(driver) { }

		public IWebElement Title() { return Driver.FindElement(By.XPath("//*[@id='header']/a/img")); }
		public IWebElement TwitterTitle() { return Driver.FindElement(By.XPath("//*[@id='page - container']/div[2]/div/div/div[1]/div/div/div/div[1]/h1/a")); }
		public IWebElement contactName { get { return Driver.Find(By.Id("name"), ExpectedCondition.Clickable); } }
		public IWebElement contactEmail { get { return Driver.Find(By.Id("email"), ExpectedCondition.Clickable); } }
		public IWebElement contactMessage { get { return Driver.Find(By.Id("comments"), ExpectedCondition.Clickable); } }
		public IWebElement contactSend { get { return Driver.Find(By.XPath("//*[@id='contactUs']/div[4]/div/ul/li[1]/input"), ExpectedCondition.Clickable); } }
		public IWebElement contactReset { get { return Driver.Find(By.XPath("//*[@id='contactUs']/div[4]/div/ul/li[2]/input"), ExpectedCondition.Clickable); } }
		public IWebElement reqContactName { get { return Driver.Find(By.Id("name-error"), ExpectedCondition.Clickable); } }
		public IWebElement reqValidContactEmail { get { return Driver.Find(By.Id("email-error"), ExpectedCondition.Clickable); } }
		public IWebElement reqContactMessage { get { return Driver.Find(By.Id("comments-error"), ExpectedCondition.Clickable); } }
		
		public XavHomePage ClickTwitter()
		{
			var elem = Driver.FindElement(By.XPath("//*[@id='contact']/div/div[2]/ul/li[4]/a"));
			Driver.MoveMouseTo(elem);
			elem.Click();
			return new XavHomePage(Driver);
		}
		public XavHomePage GoToContact(string name, string email, string message, string btnAction)
		{
			Thread.Sleep(500);
			contactName.SendKeys(name);
			contactEmail.SendKeys(email);
			contactMessage.SendKeys(message);
			if (btnAction == "reset")
			{
				contactReset.Click();
			}
			else if (btnAction == "send")
			{
				contactSend.Click();
			}
			return new XavHomePage(Driver);
		}
	}
}
