using RealtAutomation.Annotations;
using RealtAutomation.Framework;
using RealtAutomation.WebElements;
using NUnit.Framework;
using RealtAutomation.WebElements.Utils;
using NUnitATRealt.WebElements.Utils;

namespace RealtAutomation.WebPages
{
	class FilterFlatsPage : BasePage
	{
		[Find(How = How.XPath)]
		[Name(ElementName = "ChooseFlatsLink"), UsedImplicitly]
		private Link chooseFlatsLink;
 
		public FilterFlatsPage()
		{
			PageFactory.InitElements(this);
			Assert.True(chooseFlatsLink.IsPresent());
		}

		public FlatPage FlatsLinkClick()
		{
			chooseFlatsLink.Click();
			return new FlatPage();
		}
	}
}
