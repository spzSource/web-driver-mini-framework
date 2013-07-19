using System.Linq;
using ATFramework.Framework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ATFramework.Framework
{
	public abstract class BaseElement : BaseEntity
	{
		private IWebElement element;
		protected By byLocator;
	
		public IWebElement WebElement
		{
			get
			{
				element = Browser.Driver.SafeFindElement(byLocator, WaitTimeInSeconds);
				return element;
			}
			set 
			{ 
				element = value; 
			}
		}
		protected readonly int WaitTimeInSeconds = 10;

		public abstract bool IsDisplayed();
		public abstract void Click();

		public virtual bool isPresent()
		{
			bool result = false;
			if (Browser.Driver.SafeFindElement(byLocator, WaitTimeInSeconds) != null)
			{
				result = true;
			}
			return result;
		}

		public void WaitPresent(TimeSpan timeData)
		{
			WebDriverWait wait = new WebDriverWait(Browser.Driver, timeData);
			wait.Until(ExpectedConditions.ElementIsVisible(byLocator));
		}
	}
}
