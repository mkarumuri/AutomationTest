using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFramework.Helpers
{
	public class TDConstants
	{
		private static string leftMenuUrl = "/home/Products?categoryType={0}&categoryName={1}";

		public static string LeftMenu
		{
			set { leftMenuUrl = value; }
			get { return leftMenuUrl; }
		}

		public enum Products
		{
			Laptops = 1,
			Tablets = 2,
			Mobiles = 3,
			Cameras = 4,
			Televisions = 5,
			HomeAppliances = 6,
			AirConditioners = 7,
			WashingMachines = 8,
			LuggageBags = 9,
			MensFashion = 10,
			WomensFashion = 11,
			Books = 12,
			MusicalInstruments = 13,
			Furniture = 14,
			GamesConsoles = 15,
			ToysKids = 16
		}
	}
}
