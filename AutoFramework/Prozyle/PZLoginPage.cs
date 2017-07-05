﻿using AutoFramework.Base;
using AutoFramework.Helpers;
using OpenQA.Selenium;
using System.Threading;

namespace AutoFramework.Prozyle
{
	public class PZLoginPage : BasePage
	{
		public PZLoginPage(IWebDriver driver) : base(driver) { }

		public IWebElement UserId
		{
			get { return Driver.Find(By.Id("username"), ExpectedCondition.Clickable); }
		}

		public IWebElement Password
		{
			get { return Driver.Find(By.Id("password"), ExpectedCondition.Clickable); }
		}

		public IWebElement LogIn
		{
			get { return Driver.Find(By.XPath("//*[@id='l-login']/div[3]/span[1]/button"), ExpectedCondition.Clickable); }			// //*[@id="l-login"]/div[3]/span[1]/button
		}
		public IWebElement LogOut
		{
			get { return Driver.Find(By.XPath("//*[@id='header']/ul/li[4]/ul/li[2]/a"), ExpectedCondition.Clickable); }
		}

		public IWebElement ForgotPassword
		{
			get { return Driver.Find(By.XPath("//*[@id='l-login']/div[3]/span[2]/a"), ExpectedCondition.Clickable); }
		}

		public IWebElement SendButton
		{
			get { return Driver.Find(By.XPath("//*[@id='l-forget-password']/button"), ExpectedCondition.Clickable); }
		}
		public IWebElement PersonalDetailsLink
		{
			get { return Driver.Find(By.XPath("//*[@id='sidebar']/div/div/ul/li[2]/a"), ExpectedCondition.Clickable); }
		}
		public IWebElement PaymentDetailsLink
		{
			get { return Driver.Find(By.XPath("//*[@id='sidebar']/div/div/ul/li[3]/a"), ExpectedCondition.Clickable); }
		}
		public IWebElement PropertiesInformationLink
		{
			get { return Driver.Find(By.XPath("//*[@id='sidebar']/div/div/ul/li[4]/a"), ExpectedCondition.Clickable); }
		}
		//Method created to Log into Prozyle
		public PZHomePage Login(string userName, string password)
		{
			Thread.Sleep(500);
			UserId.SendKeys(userName);
			Password.SendKeys(password);
			LogIn.Click();
			return new PZHomePage(Driver);
		}
		//Method created to Log out Prozyle
		public PZHomePage Logout()
		{
			Thread.Sleep(500);
			LogOut.Click();
			return new PZHomePage(Driver);
		}

		public PZHomePage ClickForgotPassword(string userName)
		{
			Thread.Sleep(500);
			ForgotPassword.Click();
			UserId.SendKeys(userName);
			SendButton.Click();
			return new PZHomePage(Driver);
		}
		public PZHomePage ClickPersonalDetails()
		{
			Thread.Sleep(500);
			PersonalDetailsLink.Click();
			return new PZHomePage(Driver);
		}
		public PZHomePage ClickPaymentDetails()
		{
			Thread.Sleep(500);
			PaymentDetailsLink.Click();
			return new PZHomePage(Driver);
		}
		public PZHomePage ClickPropertiesInformation()
		{
			Thread.Sleep(500);
			PropertiesInformationLink.Click();
			return new PZHomePage(Driver);
		}
	}
	public class PZRegisterPage : BasePage
	{
		public PZRegisterPage(IWebDriver driver) : base(driver) { }

		public IWebElement FirstName
		{
			get { return Driver.Find(By.Id("firstName"), ExpectedCondition.Clickable); }
		}

		public IWebElement LastName
		{
			get { return Driver.Find(By.Id("lastName"), ExpectedCondition.Clickable); }
		}
		public IWebElement EmailID
		{
			get { return Driver.Find(By.Id("emailID"), ExpectedCondition.Clickable); }
		}
		public IWebElement ConfirmEmailId
		{
			get { return Driver.Find(By.Id("confirmEmailId"), ExpectedCondition.Clickable); }
		}
		public IWebElement Password
		{
			get { return Driver.Find(By.Id("password"), ExpectedCondition.Clickable); }
		}
		public IWebElement ConfirmPassword
		{
			get { return Driver.Find(By.Id("confirmPassword"), ExpectedCondition.Clickable); }
		}
		public IWebElement ContactNumber
		{
			get { return Driver.Find(By.Id("contactNumber"), ExpectedCondition.Clickable); }
		}
		public IWebElement Country
		{
			get { return Driver.Find(By.CssSelector("#l-login > div:nth-child(5) > div:nth-child(1) > div > select > option:nth-child(16)"), ExpectedCondition.Clickable); } //option 16 is united states
		}

		public IWebElement SignUp
		{
			get { return Driver.Find(By.Id("signUp"), ExpectedCondition.Clickable); }
		}

		//Method created to Register to Prozyle
		public PZRegisterPage Register(string firstName, string lastName, string email, string confirmEmail, string password, string confirmPassword, string country, string contactNumber)
		{
			Thread.Sleep(500);
			FirstName.SendKeys(firstName);
			LastName.SendKeys(lastName);
			EmailID.SendKeys(email);
			ConfirmEmailId.SendKeys(confirmEmail);
			Password.SendKeys(password);
			ConfirmPassword.SendKeys(confirmPassword);
			Country.Click();
			ContactNumber.SendKeys(contactNumber);
			SignUp.Click();
			return new PZRegisterPage(Driver);
		}

	}
}