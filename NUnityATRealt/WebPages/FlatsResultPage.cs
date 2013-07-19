using System;
using NUnitATRealt.WebElements.Utils;
using OpenQA.Selenium;
using RealtAutomation.Framework;
using RealtAutomation.Framework.Common;
using RealtAutomation.Framework.Exceptions;
using RealtAutomation.WebElements;
using RealtAutomation.WebElements.Utils;

namespace RealtAutomation.WebPages
{
    class FlatsResultPage : BasePage
    {
		[Find(How = How.XPath)]
		[Name(ElementName = "FlatsInfo")]
		private Label flatsInfo;

		[Find(How = How.XPath)]
		[Name(ElementName = "ChooseFlatsLink")]
		private Link chooseFlatsLink;

        public FlatsResultPage()
        {
			PageFactory.InitElements(this);

			if (!flatsInfo.IsDisplayed())
				throw new PageNotFoundException("Page: " + GetType().Name + " not found");
        }

        public int GetFlatsCount()
        {
            int flatsCount = 0;
			string regexResult = CommonFunctions.DoRegexSingle(@"\s+(\d+)\s+", flatsInfo.Text, groupNumber: 1);
			flatsCount = string.IsNullOrEmpty(regexResult) ? 0 : Int32.Parse(regexResult);
            
            return flatsCount;
        }

		public FlatPage GoToFlatsPage()
		{
			chooseFlatsLink.Click();
			return new FlatPage();
		}
    }
}
