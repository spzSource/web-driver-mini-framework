using ATFramework.Framework;
using NUnit.Framework;
using TimeAndDateAutomation.Utils;
using TimeAndDateAutomation.WebPages;
using TimeAndDateAutomation.WebPages.Blocks;

namespace TimeAndDateAutomation.AutoTests
{
	class MenuTest : BaseTest
	{
		[Test]
		[TestCaseSource("GetTestData")]
		public void TestMainMenuItem(string menuChain, string navString)
		{
			Log("Open home page.");
			HomePage homePage = new HomePage();

			Log("Go to page: " + EnumFunctions.ParseName(menuChain));
			TestablePage resultPage = homePage.GoToPage(EnumFunctions.ParseName(menuChain));
			
			Log("Compare navigations strings: " + navString + " and " + resultPage.NavString);
			bool result = resultPage.CheckNavigationChain(navString);

			Assert.IsTrue(result, "Wrong page. Navigation strings does not match");
		}
	}
}
