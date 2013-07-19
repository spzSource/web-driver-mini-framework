using OpenQA.Selenium;
using ATFramework.Framework;
using ATFramework.Framework.Extensions;

namespace ATFramework.WebElements
{
	public class Input : BaseElement
	{
		public Input(By by)
		{
			this.byLocator = by;
		}

		public Input SetText(string text)
		{
			WebElement.SendKeys(text);
			return this;
		}

		public Input ClearText()
		{
			WebElement.Clear();
			return this;
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
