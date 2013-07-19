using NUnitATRealt.WebElements.Utils;
using OpenQA.Selenium;
using RealtAutomation.Framework;
using RealtAutomation.Framework.Exceptions;
using RealtAutomation.WebElements;
using RealtAutomation.WebElements.Utils;

namespace RealtAutomation.WebPages
{
    class FlatPage : BasePage
    {
		[Find(How = How.XPath)]
		[Name(ElementName = "LocationInput")]
		private ComboBox locationInput;

		[Find(How = How.XPath)]
		[Name(ElementName = "RegionComboBox")]
		private ComboBox regionComboBox;

		[Find(How = How.XPath)]
		[Name(ElementName = "SearchButton")]
		private Button searchButton;

		[Find(How = How.Id)]
		[Name(ElementName = "FirstFloorCheckBox")]
		private CheckBox firstFloorCheckBox;

		[Find(How = How.Id)]
		[Name(ElementName = "LastFloorCheckBox")]
		private CheckBox lastFloorCheckBox;

		[Find(How = How.Name)]
		[Name(ElementName = "FromCostValueInput")]
		private Input fromCostValueInput;

		[Find(How = How.Name)]
		[Name(ElementName = "ToCostValueInput")]
		private Input toCostValueInput;

		public FlatPage()
        {
			PageFactory.InitElements(this);

			if (!searchButton.IsDisplayed())
				throw new PageNotFoundException("Page: " + GetType().Name + " not found");
		}

        public FlatsResultPage SearchFlatsByLocation(string location)
        {
            locationInput.SendKeys(location);
            searchButton.Click();

            return new FlatsResultPage();
        }

		public FlatsResultPage SearchFlatsByRegion(string region)
		{
			regionComboBox.SendKeys(region);
			searchButton.Click();

			return new FlatsResultPage();
		}

		public FlatsResultPage SearchFlatsByFirstFloor(bool notFirstFloor)
		{
			firstFloorCheckBox.Set(notFirstFloor);
			searchButton.Click();

			return new FlatsResultPage();
		}

		public FlatsResultPage SearchFlatsByLastFloor(bool notLastFloor)
		{
			lastFloorCheckBox.Set(notLastFloor);
			searchButton.Click();

			return new FlatsResultPage();
		}

		public FlatsResultPage SearchFlatsByCost(int from, int to)
		{
			fromCostValueInput.ClearText().SetText(from.ToString());
			toCostValueInput.ClearText().SetText(to.ToString());
			searchButton.Click();

			return new FlatsResultPage();
		}
    }
}
