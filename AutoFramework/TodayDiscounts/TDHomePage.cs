using AutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AutoFramework.Helpers;

namespace AutoFramework.TodayDiscounts
{
	public class TDHomePage : BasePage
	{
		public TDHomePage(IWebDriver driver) : base(driver) { }
		public IWebElement Title()
		{
			return Driver.FindElement(By.XPath("//*[@id='header']/div/nav/div/h1/a/img"));
		}
		public IWebElement sideMenu
		{
			get { return Driver.Find(By.XPath("//*[@id='main']/div/div/div/div/div/h6")); } 
		}
		public IWebElement luggageSideMenu
		{
			get { return Driver.Find(By.XPath("//*[@id='main']/div/div/div/div/div/h6")); } 
		}
	}
}
