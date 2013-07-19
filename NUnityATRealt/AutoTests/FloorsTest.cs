using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using RealtAutomation.Framework;
using RealtAutomation.WebPages;

namespace RealtAutomation.AutoTests
{
	[TestFixture]
	class FloorsTest : BaseTest
	{
		[Test]
		[TestCaseSource("GetTestData")]
		public void CheckFlatsCountByLocationAndFloor(string location, string notFirstFloor)
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

			Log("Searching flats by floor (not first floor): " + notFirstFloor);
			resultPage = flatPage.SearchFlatsByFirstFloor(bool.Parse(notFirstFloor));

			Log("Parse flats count");
			int flatsCountByFloor = resultPage.GetFlatsCount();

			Log(string.Format("Comparing number of flats {0} and {1}", 
				flatsCountByLocation, flatsCountByFloor));
			Assert.Greater(flatsCountByLocation, flatsCountByFloor,
				"Test failed. Number of apartments by region must be less than by floor");
		}
	}
}
