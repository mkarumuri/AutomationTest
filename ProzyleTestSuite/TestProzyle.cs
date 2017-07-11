using AutoFramework.Base;
using AutoFramework.Helpers;
using AutoFramework.Prozyle;
using AutoFramework.Prozyle.Constants;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProzyleTestSuite
{
	public class TestProzyle : TestBase
	{
		private Dictionary<TestScenarios, IList<Tuple<Customer, string, string, string>>> testData = new Dictionary<TestScenarios, IList<Tuple<Customer, string, string, string>>>();
		//public TestProzyle()
		//{
		//	testData.Add(TestScenarios.AddProperty,GetAddPropertyValidationAsserts(
		//}	

		/// <summary>
		/// Test to Register user
		/// </summary>
		//[Test]
		//public void TestRegistration()
		//{
		//	WebTest((driver) =>
		//	{
		//		var homePage = new PZHomePage(driver);

		//		driver.GoToProzyleRegister("wpweb/#/user-registration", "Test", "Test", "spmamidi@gmail.com", "spmamidi@gmail.com", "Pr0zy!eTest", "Pr0zy!eTest", "United states", "5129219933");
		//		Assert.IsTrue(homePage.Title().Displayed);
		//	},"ProzyleTestSuite");
		//}

		/// <summary>
		/// Test to Verify home page is loaded using title is displayed
		/// </summary>
		[Test]
		public void TestHomePage()
		{
			WebTest((driver) =>
			{
				var homePage = new PZHomePage(driver);
				CheckLoginValidations(driver, homePage);
				TestLogin(driver, homePage);
				TestLogout(driver, homePage);
			}, "ProzyleTestSuite");
		}

		[Test]
		public void TestPersonalDetails()
		{
			WebTest((driver) =>
			{
				var homePage = new PZHomePage(driver);
				TestLogin(driver, homePage);
				CheckSideMenu(driver, homePage);
				TestLogout(driver, homePage);
			}, "ProzyleTestSuite");
		}

		[Test]
		public void TestForgotPassword()
		{
			WebTest((driver) =>
			{
				var homePage = new PZHomePage(driver);

				driver.GoToForgotPassword("mani.karumuri@gmail.com", PageNameConstants.Login);
				Assert.AreEqual("Email sent", homePage.passwordEmailSent.Text);
			}, "ProzyleTestSuite");
		}

		[Test]
		public void TestAddProperty()
		{
			WebTest((driver) =>
			{
				var homePage = new PZHomePage(driver);
				TestLogin(driver, homePage);

				driver.GoToAddProperty(PageNameConstants.CustomerLanding);
				Assert.AreEqual("ADD PROPERTY", homePage.AddPropertyTabTitle.Text, "Add Property Tab Title do not match");

				CheckAddPropertyValidations(driver, homePage);

				IList<Customer> customers = new List<Customer>(){
					new Customer()
					{
						Title = "Home",
						FullName = "Test",
						PropertyType = "Land",
						Address1 = "Test",
						Address2 = "",
						City = "Test",
						Pincode = "4444",
						State = "Telangana",
						Landmark = "",
						Latitude = "",
						Longitude = "",
						ContactName = "Test",
						ContactNumber = "123456789012"
					}
				};
				IList<Tuple<string, string, string>> asserts = new List<Tuple<string, string, string>>()
				{
					new Tuple<string, string, string>("Land -- BASIC - 500 INR , ADDITIONALLY EACH ADD ONS COSTS 50 INR.", homePage.ChecklistHeader.Text, "Checklist Tab Title do not match")
				};

				ExecuteAddPropertyAsserts(driver, customers, asserts);

				TestLogout(driver, homePage);
			}, "ProzyleTestSuite");
		}

		#region "Properties"
		private IList<Customer> Customers
		{
			get
			{
				IList<Customer> customers = new List<Customer>()
				{
						new Customer()
						{
							Title = "",
							FullName = "Test",
							PropertyType = "Land",
							Address1 = "Test",
							Address2 = "",
							City = "Test",
							Pincode = "4444",
							State = "Telangana",
							Landmark = "",
							Latitude = "",
							Longitude = "",
							ContactName = "Test",
							ContactNumber = "123456789012"
						},
						new Customer()
						{
							Title = "Test",
							FullName = "",
							PropertyType = "Land",
							Address1 = "Test",
							Address2 = "",
							City = "Test",
							Pincode = "4444",
							State = "Telangana",
							Landmark = "",
							Latitude = "",
							Longitude = "",
							ContactName = "Test",
							ContactNumber = "123456789012"
						},
						new Customer()
						{
							Title = "Test",
							FullName = "Test",
							PropertyType = "",
							Address1 = "Test",
							Address2 = "",
							City = "Test",
							Pincode = "4444",
							State = "Telangana",
							Landmark = "",
							Latitude = "",
							Longitude = "",
							ContactName = "Test",
							ContactNumber = "123456789012"
						},
						new Customer()
						{
							Title = "Test",
							FullName = "Test",
							PropertyType = "Land",
							Address1 = "",
							Address2 = "",
							City = "Test",
							Pincode = "4444",
							State = "Telangana",
							Landmark = "",
							Latitude = "",
							Longitude = "",
							ContactName = "Test",
							ContactNumber = "123456789012"
						},
						new Customer()
						{
							Title = "Test",
							FullName = "Test",
							PropertyType = "Land",
							Address1 = "Test",
							Address2 = "",
							City = "",
							Pincode = "4444",
							State = "Telangana",
							Landmark = "",
							Latitude = "",
							Longitude = "",
							ContactName = "Test",
							ContactNumber = "123456789012"
						},
						new Customer()
						{
							Title = "Test",
							FullName = "Test",
							PropertyType = "Land",
							Address1 = "Test",
							Address2 = "",
							City = "Test",
							Pincode = "",
							State = "Telangana",
							Landmark = "",
							Latitude = "",
							Longitude = "",
							ContactName = "Test",
							ContactNumber = "123456789012"
						},
						new Customer()
						{
							Title = "Test",
							FullName = "Test",
							PropertyType = "Land",
							Address1 = "Test",
							Address2 = "",
							City = "Test",
							Pincode = "Test",
							State = "Telangana",
							Landmark = "",
							Latitude = "",
							Longitude = "",
							ContactName = "Test",
							ContactNumber = "123456789012"
						},
						new Customer()
						{
							Title = "Test",
							FullName = "Test",
							PropertyType = "Land",
							Address1 = "Test",
							Address2 = "",
							City = "Test",
							Pincode = "Test",
							State = "",
							Landmark = "",
							Latitude = "",
							Longitude = "",
							ContactName = "Test",
							ContactNumber = "123456789012"
						},
						new Customer()
						{
							Title = "Test",
							FullName = "Test",
							PropertyType = "Land",
							Address1 = "Test",
							Address2 = "",
							City = "Test",
							Pincode = "Test",
							State = "Telangana",
							Landmark = "",
							Latitude = "",
							Longitude = "",
							ContactName = "Test",
							ContactNumber = "1234567890123"
						},
						new Customer()
						{
							Title = "Test",
							FullName = "Test",
							PropertyType = "Land",
							Address1 = "Test",
							Address2 = "",
							City = "Test",
							Pincode = "Test",
							State = "Telangana",
							Landmark = "",
							Latitude = "",
							Longitude = "",
							ContactName = "Test",
							ContactNumber = "test"
						}
				};
				return customers;
			}
		}
		private IList<Tuple<string, string, string>> GetAddPropertyValidationAsserts(PZHomePage homePage)
		{
			IList<Tuple<string, string, string>> asserts = new List<Tuple<string, string, string>>()
			{
				new Tuple<string, string, string>(
					"This information is required", homePage.ReqTitleMessage.Text, "Title should not be empty - Failed"),
				new Tuple<string, string, string>(
					"This information is required", homePage.ReqHolderNameMessage.Text, "Holder Name should not be empty - Failed"),
				new Tuple<string, string, string>(
					"This information is required", homePage.ReqTypeMessage.Text, "Property Type should not be empty - Failed"),
				new Tuple<string, string, string>(
					"This information is required", homePage.ReqAddressMessage.Text, "Address1 should not be empty - Failed"),
				new Tuple<string, string, string>(
					"This information is required", homePage.ReqCityMessage.Text, "City should not be empty - Failed"),
				new Tuple<string, string, string>(
					"This information is required", homePage.ReqPinCodeMessage.Text, "PinCode should not be empty - Failed"),
				new Tuple<string, string, string>(
					"Enter Valid pincode", homePage.ReqValidPinCodeMessage.Text, "PinCode is not Valid - Failed"),
				new Tuple<string, string, string>(
					"This information is required", homePage.ReqStateMessage.Text, "State should not be empty - Failed"),
				new Tuple<string, string, string>(
					"Mobile Number(maximum 12 characters)", homePage.ReqMaxContactNumberMessage.Text, "Number max 12 characters - Failed"),
				new Tuple<string, string, string>(
					"Enter Valid Mobile Number", homePage.ReqValidContactNumberMessage.Text, "Number is not Valid - Failed")
			};
			return asserts;
		}
		#endregion

		#region "Methods"
		private void CheckLoginValidations(IWebDriver driver, PZHomePage homePage)
		{
			//UserName empty
			driver.GoToProzyleHome(PageNameConstants.Login, "", AppConfig.testPassword);
			Assert.AreEqual("This information is required", homePage.requiredUserNameMessage.Text, "UserName Should not be empty - Failed");

			//password empty
			driver.GoToProzyleHome(PageNameConstants.Login, AppConfig.ProzyleUserName, "");
			Assert.AreEqual("This information is required", homePage.requiredPasswordMessage.Text, "Password Should not be empty - Failed");

			//Enter Valid Username
			driver.GoToProzyleHome(PageNameConstants.Login, "test", AppConfig.testPassword);
			Assert.AreEqual("Enter Valid Email", homePage.validEmail.Text, "Not Valid Username - Failed");
		}

		private void TestLogin(IWebDriver driver, PZHomePage homePage)
		{
			//Login Success and go to home page
			driver.GoToProzyleHome(PageNameConstants.Login, "dev@dev.com", "Test@123");
			Assert.AreEqual("WWP User WWPUser", homePage.SideMenuTitle.Text, "Title do not match");
		}

		private void TestLogout(IWebDriver driver, PZHomePage homePage)
		{
			//Login Success and go to home page
			driver.LogoutProzyleHome(PageNameConstants.CustomerLanding);
			Assert.AreEqual("PROZYLE", homePage.HeaderTitle().Text, "Logout - Failed");
		}

		private void CheckSideMenu(IWebDriver driver, PZHomePage homePage)
		{
			//Side Menu Personal Details
			driver.GoToPersonalDetails(PageNameConstants.PersonalProfile);
			Assert.AreEqual("Personal Details", homePage.PersonalDetailsTitle.Text, "Personal Details - Failed");

			//Side Menu Payment Details
			driver.GoToPaymentDetails(PageNameConstants.MyAccount);
			Assert.AreEqual("Payment Details", homePage.PaymentDetailsTitle.Text, "Payment Details - Failed");

			//Side Menu Properties Information
			driver.GoToPropertiesInformation(PageNameConstants.PropertiesList);
			Assert.AreEqual("Properties Information", homePage.PropertiesInformationTitle.Text, "Properties Information - Failed");
		}

		private void CheckAddPropertyValidations(IWebDriver driver, PZHomePage homePage)
		{
			ExecuteAddPropertyAsserts(driver, Customers, GetAddPropertyValidationAsserts(homePage));
		}
		private void ExecuteAddPropertyAsserts(IWebDriver driver, IList<Customer> customers, IList<Tuple<string, string, string>> asserts)
		{
			int i = 0;
			foreach (var item in asserts)
			{
				driver.GoToAddPropertyDetails(PageNameConstants.AddProperty, customers[i]);
				Assert.AreEqual(item.Item1, item.Item2, item.Item3);
				i++;
			}
		}
		#endregion
	}
}
