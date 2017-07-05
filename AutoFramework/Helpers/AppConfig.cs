using System;
using System.Configuration;

namespace AutoFramework.Helpers
{
	public static class AppConfig
	{
		public static string WebDriver
		{
			get
			{
				return ConfigurationManager.AppSettings["WebDriver"];
			}
		}

		public static string ProzyleUserName
		{
			get
			{
				return ConfigurationManager.AppSettings["ProzyleUserName"];
			}
		}

		public static string testPassword
		{
			get
			{
				return ConfigurationManager.AppSettings["testPassword"];
			}
		}
		
		public static string DBTestUsername
		{
			get
			{
				return ConfigurationManager.AppSettings["TestDBUserName"];
			}
		}

		public static string DBTestPassword
		{
			get
			{
				return ConfigurationManager.AppSettings["TestDBPassword"];
			}
		}
		public static bool TakeScreenShots
		{
			get
			{
				bool takeScreenShots = false;

				switch (ConfigurationManager.AppSettings["TakeScreenShots"])
				{
					case "Yes":
						takeScreenShots = true;
						break;
					case "No":
						takeScreenShots = false;
						break;
				}

				return takeScreenShots;
			}
		}

		public static string BaseUrl
		{
			get
			{
				var url = string.Empty;

				switch (ConfigurationManager.AppSettings["Environment"])
				{
					case "google":
						url = "https://google.com";
						break;
					case "todayDiscounts":
						url = "http://test-todaydiscounts.azurewebsites.net/";
						break;
					case "prozyle":
						url = "http://test-prozyle.azurewebsites.net/";
						break;
					case "qwipo":
						url = "http://test-qwipo.azurewebsites.net/";
						break;
					case "xavica":
						url = "http://test-xavica.azurewebsites.net";
						break;
				}

				return url;
			}
		}

		public static string SqlConnectionString
		{
			get
			{
				var connectionString = string.Empty;

				switch (ConfigurationManager.AppSettings["Environment"])
				{
					case "sbx05":
						connectionString = String.Format(@"Data Source=HSA-SBX-05.amer.reisystems.com\txn;Initial Catalog=GEMS;User ID={0};Password={1};", DBTestUsername, DBTestPassword);
						break;
					case "utl5":
						connectionString = String.Format(@"Data Source=hsa-db-utl5.amer.reisystems.com\txn;Initial Catalog=GEMS;User ID={0};Password={1};", DBTestUsername, DBTestPassword);
						break;
					case "uat4":
						connectionString = String.Format(@"Data Source=hsa-db-uAt4.amer.reisystems.com\txn;Initial Catalog=GEMS;User ID={0};Password={1};", DBTestUsername, DBTestPassword);
						break;
				}

				return connectionString;
			}
		}
	}
}
