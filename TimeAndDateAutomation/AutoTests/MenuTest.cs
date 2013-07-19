using System.Collections.Generic;
using ATFramework.Framework;
using NUnit.Framework;
using TimeAndDateAutomation.WebPages;

namespace TimeAndDateAutomation.AutoTests
{
	class MenuTest : BaseTest
	{
		[Test]
		[TestCaseSource("GetData")]
		public void TestMainMenuItem(string menuChain, string navString)
		{
			HomePage homePage = new HomePage();
			bool result = homePage.CheckPage(menuChain, navString);

			Assert.IsTrue(result, "Wrong page. Navigation strings does not match");
		}

		private IEnumerable<string[]> GetData()
		{
			return new[]
			{
				new string[] { "Home > Newsletter", "Home > Site information > Newsletter" },
				new string[] { "Home > Site Map", "Home > Site information > Sitemap" },
				new string[] { "World Clock > Main World Clock", "Home > Time Zones > World Clock" },
				new string[] { "World Clock > Extended World Clock", "Home > Time Zones > World Clock > Extended Version" },
				new string[] { "World Clock > Personal World Clock", "Home > Time Zones > World Clock > Personal World Clock" },
				new string[] { "World Clock > Event Time Announcer", "Home > Time Zones > World Clock > Event Time Announcer" },
				new string[] { "Time Zones > Time Zone Abbreviations", "Home > Time Zones > Time Zone abbreviations" }
			};
		}
	}
}
