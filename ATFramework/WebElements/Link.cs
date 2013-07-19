using OpenQA.Selenium;
using ATFramework.Framework;
using ATFramework.Framework.Extensions;
using OpenQA.Selenium.Interactions;

namespace ATFramework.WebElements
{
	public class Link : BaseElement
	{
		public Link(By by)
		{
			this.byLocator = by;
		}

		public override void Click()
		{
			WebElement.Click();
		}

		public void MoveToElement(Actions action)
		{
			action.MoveToElement(WebElement);
		}

		public override bool IsDisplayed()
		{
			return WebElement.Displayed;
		}
	}
}
