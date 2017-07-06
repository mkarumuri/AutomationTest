using AutoFramework.Base;
using AutoFramework.Helpers;
using AutoFramework.Prozyle;
using NUnit.Framework;

namespace ProzyleTestSuite
{
	public class TestProzyle : TestBase
	{
		/// <summary>
		/// Test to Verify home page is loaded using title is displayed
		/// </summary>
		[Test]
		public void TestHomePage()
		{
			//WebTest((driver) =>
			//{
			//	var homePage = new PZHomePage(driver);
			//	CheckValidations(driver, homePage);
			//	TestLogin(driver, homePage);
			//});
			WebTest((driver) =>
			{
				var homePage = new PZHomePage(driver);
				CheckValidations(driver, homePage);
				TestLogin(driver, homePage);
				TestLogout(driver, homePage);
			}, "ProzyleTestSuite");
		}

		private static void TestLogin(OpenQA.Selenium.IWebDriver driver, PZHomePage homePage)
		{

			//Login Success and go to home page
			driver.GoToProzyleHome("dev@dev.com", "Test@123", "/wpweb/#/user-login");
			Assert.AreEqual("WWP User WWPUser", homePage.SideMenuTitle.Text, "Title do not match");
		}

		private static void TestLogout(OpenQA.Selenium.IWebDriver driver, PZHomePage homePage)
		{

			//Login Success and go to home page
			driver.LogoutProzyleHome("wpweb/#/customer-landing-page");
			Assert.AreEqual("PROZYLE", homePage.HeaderTitle().Text, "Logout - Failed");
		}

		private static void CheckValidations(OpenQA.Selenium.IWebDriver driver, PZHomePage homePage)
		{
			//UserName empty
			driver.GoToProzyleHome("", AppConfig.testPassword, "/wpweb/#/user-login");
			Assert.AreEqual("This information is required", homePage.requiredUserNameMessage.Text, "UserName Should not be empty - Failed");

			//password empty
			driver.GoToProzyleHome(AppConfig.ProzyleUserName, "", "/wpweb/#/user-login");
			Assert.AreEqual("This information is required", homePage.requiredPasswordMessage.Text, "Password Should not be empty - Failed");

			//Enter Valid Username
			driver.GoToProzyleHome("test", AppConfig.testPassword, "/wpweb/#/user-login");
			Assert.AreEqual("Enter Valid Email", homePage.validEmail.Text, "Not Valid Username - Failed");
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

		private static void CheckSideMenu(OpenQA.Selenium.IWebDriver driver, PZHomePage homePage)
		{

			//Side Menu Personal Details
			driver.GoToPersonalDetails("wpweb/#/user-personal-profile");
			Assert.AreEqual("Personal Details", homePage.PersonalDetailsTitle.Text, "Personal Details - Failed");

			//Side Menu Payment Details
			driver.GoToPaymentDetails("wpweb/#/user-my-account");
			Assert.AreEqual("Payment Details", homePage.PaymentDetailsTitle.Text, "Payment Details - Failed");

			//Side Menu Properties Information
			driver.GoToPropertiesInformation("wpweb/#/properties-list");
			Assert.AreEqual("Properties Information", homePage.PropertiesInformationTitle.Text, "Properties Information - Failed");
		}

		[Test]
		public void TestForgotPassword()
		{
			WebTest((driver) =>
			{
				var homePage = new PZHomePage(driver);

				driver.GoToForgotPassword("mani.karumuri@gmail.com", "/wpweb/#/user-login");
				Assert.AreEqual("Email sent", homePage.passwordEmailSent.Text);
			});
		}

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

		[Test]
		public void TestAddProperty()
		{
			WebTest((driver) =>
			{
				var homePage = new PZHomePage(driver);
				TestLogin(driver, homePage);

				driver.GoToAddProperty("/wpweb/#/customer-landing-page");
				Assert.AreEqual("ADD PROPERTY", homePage.AddPropertyTabTitle.Text, "Add Property Tab Title do not match");

				CheckAddPropertyValidations(driver, homePage);

				driver.GoToAddPropertyDetails("/wpweb/#/addproperty", "Home", "Test", "Land", "Test", "", "Test", "4444", "Telangana", "", "", "", "Test", "123456789012");
				Assert.AreEqual("Land -- BASIC - 500 INR , ADDITIONALLY EACH ADD ONS COSTS 50 INR.", homePage.ChecklistHeader.Text, "Checklist Tab Title do not match");

				TestLogout(driver, homePage);
			}, "ProzyleTestSuite");
		}

		private static void CheckAddPropertyValidations(OpenQA.Selenium.IWebDriver driver, PZHomePage homePage)
		{
			driver.GoToAddPropertyDetails("/wpweb/#/addproperty", "", "Test", "Land", "Test", "", "Test", "4444", "Telangana", "", "", "", "Test", "123456789012");
			Assert.AreEqual("This information is required", homePage.ReqTitleMessage.Text, "Title should not be empty - Failed");

			driver.GoToAddPropertyDetails("/wpweb/#/addproperty", "Test", "", "Land", "Test", "", "Test", "4444", "Telangana", "", "", "", "Test", "123456789012");
			Assert.AreEqual("This information is required", homePage.ReqHolderNameMessage.Text, "Holder Name should not be empty - Failed");

			driver.GoToAddPropertyDetails("/wpweb/#/addproperty", "Test", "Test", "", "Test", "", "Test", "4444", "Telangana", "", "", "", "Test", "123456789012");
			Assert.AreEqual("This information is required", homePage.ReqTypeMessage.Text, "Property Type should not be empty - Failed");

			driver.GoToAddPropertyDetails("/wpweb/#/addproperty", "Test", "Test", "Land", "", "", "Test", "4444", "Telangana", "", "", "", "Test", "123456789012");
			Assert.AreEqual("This information is required", homePage.ReqAddressMessage.Text, "Address1 should not be empty - Failed");

			driver.GoToAddPropertyDetails("/wpweb/#/addproperty", "Test", "Test", "Land", "Test", "", "", "4444", "Telangana", "", "", "", "Test", "123456789012");
			Assert.AreEqual("This information is required", homePage.ReqCityMessage.Text, "City should not be empty - Failed");

			driver.GoToAddPropertyDetails("/wpweb/#/addproperty", "Test", "Test", "Land", "Test", "", "Test", "", "Telangana", "", "", "", "Test", "123456789012");
			Assert.AreEqual("This information is required", homePage.ReqPinCodeMessage.Text, "PinCode should not be empty - Failed");

			driver.GoToAddPropertyDetails("/wpweb/#/addproperty", "Test", "Test", "Land", "Test", "", "Test", "Test", "Telangana", "", "", "", "Test", "123456789012");
			Assert.AreEqual("Enter Valid pincode", homePage.ReqValidPinCodeMessage.Text, "PinCode is not Valid - Failed");

			driver.GoToAddPropertyDetails("/wpweb/#/addproperty", "Test", "Test", "Land", "Test", "", "Test", "4444", "", "", "", "", "Test", "123456789012");
			Assert.AreEqual("This information is required", homePage.ReqStateMessage.Text, "State should not be empty - Failed");

			driver.GoToAddPropertyDetails("/wpweb/#/addproperty", "Test", "Test", "Land", "Test", "", "Test", "4444", "Telangana", "", "", "", "Test", "1234567890123");
			Assert.AreEqual("Mobile Number(maximum 12 characters)", homePage.ReqMaxContactNumberMessage.Text, "State should not be empty - Failed");

			driver.GoToAddPropertyDetails("/wpweb/#/addproperty", "Test", "Test", "Land", "Test", "", "Test", "4444", "Telangana", "", "", "", "Test", "test");
			Assert.AreEqual("Enter Valid Mobile Number", homePage.ReqValidContactNumberMessage.Text, "Number is not Valid - Failed");
		}
	}
}
