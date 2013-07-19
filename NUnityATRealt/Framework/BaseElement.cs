using OpenQA.Selenium;

namespace RealtAutomation.Framework
{
	public abstract class BaseElement : BaseEntity
	{
		protected By byLocator;
		protected IWebElement WebElement{ get; set; }
		protected readonly int WaitTimeInSeconds = 10;

		public abstract bool IsDisplayed();
		public abstract void Click();

		public virtual bool isPresent()
		{
			bool result = false;
			if (Browser.Driver.FindElements(byLocator).Count > 0)
			{
				result = true;
			}
			return result;
		}
	}
}
