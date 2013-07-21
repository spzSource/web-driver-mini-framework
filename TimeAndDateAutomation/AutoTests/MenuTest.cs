using ATFramework.Framework;
using NUnit.Framework;
using TimeAndDateAutomation.Utils;
using TimeAndDateAutomation.WebPages;

namespace TimeAndDateAutomation.AutoTests
{
	class MenuTest : BaseTest
	{
		[Test]
		[TestCaseSource("GetTestData")]
		public void TestMainMenuItem(string menuChain, string navString)
		{
			HomePage homePage = new HomePage();
			bool result = homePage.CheckPage(EnumFunctions.ParseName(menuChain), navString);

			Assert.IsTrue(result, "Wrong page. Navigation strings does not match");
		}
	}
}
