using OpenQA.Selenium;
using RealtAutomation.Framework;
using RealtAutomation.Framework.Extensions;

namespace RealtAutomation.WebElements
{
	class CheckBox : BaseElement
	{
		public CheckBox(By by)
		{
			this.byLocator = by;
		}

		public CheckBox(IWebElement element)
		{
			WebElement = element;
		}

		public bool IsSelected()
		{
			WebElement = Browser.Driver.SafeFindElement(byLocator, WaitTimeInSeconds);
			return WebElement.Selected;
		}

		public void Set(bool value)
		{
			WebElement = Browser.Driver.SafeFindElement(byLocator, WaitTimeInSeconds);
			if (value && !WebElement.Selected)
				WebElement.Click();
		}

		public void UnSet()
		{
			WebElement = Browser.Driver.SafeFindElement(byLocator, WaitTimeInSeconds);
			if (WebElement.Enabled)
				WebElement.Click();
		}

		public override void Click()
		{
			WebElement = Browser.Driver.SafeFindElement(byLocator, WaitTimeInSeconds);
			WebElement.Click();
		}

		public override bool IsDisplayed()
		{
			WebElement = Browser.Driver.SafeFindElement(byLocator, WaitTimeInSeconds);
			return WebElement.Displayed;
		}
	}
}
