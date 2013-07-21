using OpenQA.Selenium;
using ATFramework.Framework;

namespace ATFramework.WebElements
{
	public class ComboBox : BaseElement
	{
		public ComboBox(By by)
		{
			this.ByLocator = by;
		}

		public void SendKeys(string key)
		{
			WebElement.SendKeys(key);
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
