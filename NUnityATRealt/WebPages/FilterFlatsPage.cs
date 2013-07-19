using OpenQA.Selenium;
using RealtAutomation.Framework;
using RealtAutomation.WebElements;
using RealtAutomation.Framework.Exceptions;
using NUnit.Framework;
using RealtAutomation.WebElements.Utils;
using NUnitATRealt.WebElements.Utils;

namespace RealtAutomation.WebPages
{
	class FilterFlatsPage : BasePage
	{
		[Find(How = How.XPath)]
		[Name(ElementName = "ChooseFlatsLink")]
		private Link chooseFlatsLink;
 
		public FilterFlatsPage()
		{
			PageFactory.InitElements(this);
			Assert.True(chooseFlatsLink.isPresent());
		}

		public FlatPage FlatsLinkClick()
		{
			chooseFlatsLink.Click();
			return new FlatPage();
		}
	}
}
