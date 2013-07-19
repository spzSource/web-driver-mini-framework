using OpenQA.Selenium;
using RealtAutomation.Framework;
using RealtAutomation.Framework.Extensions;

namespace RealtAutomation.WebElements
{
	class Button : BaseElement
	{
		public Button(By by)
		{
			this.byLocator = by;
		}

		public Button(IWebElement element)
		{
			WebElement = element;
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
