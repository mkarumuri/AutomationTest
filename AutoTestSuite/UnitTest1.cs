﻿using AutoFramework.Base;
using AutoFramework.Helpers;
using NUnit.Framework;

namespace AutoTestSuite
{
	public class UnitTest1 : TestBase
	{
		[Test]
		public void TestMethod1()
		{
			WebTest((driver) => {
				driver.GoToHomePage();
			});
		}

		[Test]
		public void TodayDiscounts()
		{
			WebTest((driver) => {
				driver.GoToTodayDiscounts();
			});
		}
		[Test]
		public void Xavica()
		{
			WebTest((driver) => {
				driver.GoToXavica();
			});
		}
	}
}
