using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using RealtAutomation.Framework;
using RealtAutomation.WebPages;

namespace RealtAutomation.AutoTests
{
	[TestFixture]
	class FlatsTest : BaseTest
	{
		[Test]
		[TestCaseSource("GetTestData")]
		public void CheckFlatsCountByLocation(string location, string count)
		{
			Log("Opening home page.");
			HomePage homePage = new HomePage();

			Log("Click to link with name 'Flats and rooms'");
			FilterFlatsPage filterPage = homePage.DoFlatLinkClick();

			Log("Click to tab 'Choice'");
			FlatPage flatPage = filterPage.FlatsLinkClick();

			Log("Searching flats by location: " + location);
			FlatsResultPage resultPage = flatPage.SearchFlatsByLocation(location);

			Log("Parse flats count");
			int flatsCount = resultPage.GetFlatsCount();

			Log(string.Format("Comparing number of flats {0} and {1}",
				flatsCount, count));
			Assert.Greater(flatsCount, Int32.Parse(count), 
				string.Format("Test failed. Number of flats to be more than {0}", count));
		}
	}
}
