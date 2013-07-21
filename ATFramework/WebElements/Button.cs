using ATFramework.Framework;
using OpenQA.Selenium;

namespace ATFramework.WebElements
{
	public class Button : BaseElement
	{
		public Button(By by)
		{
			this.ByLocator = by;
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
