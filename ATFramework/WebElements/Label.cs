using OpenQA.Selenium;
using ATFramework.Framework;

namespace ATFramework.WebElements
{
	public class Label : BaseElement
	{
		public Label(By by)
		{
			this.ByLocator = by;
		}

		public string Text
		{
			get 
			{
				return WebElement.Text; 
			}
		}

		public bool IsSelected()
		{
			return WebElement.Selected;
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
