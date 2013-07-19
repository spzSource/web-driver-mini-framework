using OpenQA.Selenium;
using RealtAutomation.Framework;
using RealtAutomation.WebElements;
using RealtAutomation.Framework.Exceptions;
using RealtAutomation.WebElements.Utils;
using NUnitATRealt.WebElements.Utils;

namespace RealtAutomation.WebPages
{
	class HomePage : BasePage
	{
		[Find(How = How.LinkText)]
		[Name(ElementName = "FlatLink")]
		private Link flatLink;

		public HomePage()
		{
			PageFactory.InitElements(this);
			if (!flatLink.IsDisplayed())
				throw new PageNotFoundException("Page: " + GetType().Name + " not found");
		}

		public FilterFlatsPage DoFlatLinkClick()
		{
			flatLink.Click();
			return new FilterFlatsPage();
		}
	}
}
