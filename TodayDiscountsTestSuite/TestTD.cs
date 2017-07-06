using AutoFramework.Base;
using AutoFramework.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayDiscountsTestSuite
{
	public class TestTD : TestBase
	{

		[Test]
		public void TodayDiscounts()
		{
			WebTest((driver) =>
			{
				driver.GoToTodayDiscounts();
			}, "TodayDiscountsTestSuite");
		}
	}
}
