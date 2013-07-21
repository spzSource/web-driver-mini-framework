using OpenQA.Selenium;
using ATFramework.Framework;

namespace ATFramework.WebElements
{
	public class CheckBox : BaseElement
	{
		public CheckBox(By by)
		{
			this.ByLocator = by;
		}

		public bool IsSelected()
		{
			return WebElement.Selected;
		}

		public void Set(bool value)
		{
			if (value && !WebElement.Selected)
				WebElement.Click();
		}

		public void UnSet()
		{
			if (WebElement.Enabled)
				WebElement.Click();
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
