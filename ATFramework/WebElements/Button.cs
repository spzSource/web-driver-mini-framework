using ATFramework.Framework;
using ATFramework.Framework.Extensions;
using OpenQA.Selenium;

namespace ATFramework.WebElements
{
	public class Button : BaseElement
	{
		public Button(By by)
		{
			this.byLocator = by;
		}

		public override void Click()
		{
			WebElement.Click();
		}

		public override bool IsDisplayed()
		{
			return WebElement.Displayed;
		}
	}
}
