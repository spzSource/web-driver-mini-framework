using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using RealtAutomation.Framework;
using RealtAutomation.WebPages;

namespace RealtAutomation.AutoTests
{
	[TestFixture]
	class RegionsTest : BaseTest
	{
		[Test]
		[TestCaseSource("GetTestData")]
		public void CheckFlatsCountByLocationAndRegion(string location, string region)
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
			int flatsCountByLocation = resultPage.GetFlatsCount();

			Log("Click to tab 'Choice'");
			flatPage = resultPage.GoToFlatsPage();

			Log("Searching flats by region: " + region);
			resultPage = flatPage.SearchFlatsByRegion(region);

			Log("Parse flats count");
			int flatsCountByRegion = resultPage.GetFlatsCount();

			Log(string.Format("Comparing number of flats {0} and {1}",
				flatsCountByLocation, flatsCountByRegion));
			Assert.Greater(flatsCountByLocation, flatsCountByRegion,
				"Test failed. Number of apartments by region must be less than by location");
		}
	}
}
