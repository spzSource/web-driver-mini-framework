using OpenQA.Selenium;
using RealtAutomation.Framework;
using RealtAutomation.Framework.Extensions;

namespace RealtAutomation.WebElements
{
	class Input : BaseElement
	{
		public Input(By by)
		{
			this.byLocator = by;
		}

		public Input(IWebElement element)
		{
			WebElement = element;
		}

		public Input SetText(string text)
		{
			WebElement = Browser.Driver.SafeFindElement(byLocator, WaitTimeInSeconds);
			WebElement.SendKeys(text);
			return this;
		}

		public Input ClearText()
		{
			WebElement = Browser.Driver.SafeFindElement(byLocator, WaitTimeInSeconds);
			WebElement.Clear();
			return this;
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
