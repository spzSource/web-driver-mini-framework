using OpenQA.Selenium;
using RealtAutomation.Framework;
using RealtAutomation.Framework.Extensions;

namespace RealtAutomation.WebElements
{
	class Label : BaseElement
	{
		public Label(By by)
		{
			this.byLocator = by;
		}

		public Label(IWebElement element)
		{
			WebElement = element;
		}

		public string Text
		{
			get 
			{
				WebElement = Browser.Driver.SafeFindElement(byLocator, WaitTimeInSeconds);
				return WebElement.Text; 
			}
		}

		public bool IsSelected()
		{
			WebElement = Browser.Driver.SafeFindElement(byLocator, WaitTimeInSeconds);
			return WebElement.Selected;
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
