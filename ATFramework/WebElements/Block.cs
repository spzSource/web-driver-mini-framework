using OpenQA.Selenium;
using ATFramework.Framework;
using ATFramework.Framework.Extensions;

namespace ATFramework.WebElements
{
	public class Block : BaseElement
	{
		public Block(By by)
		{
			this.byLocator = by;
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
