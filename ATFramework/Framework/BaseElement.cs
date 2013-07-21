using ATFramework.Framework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ATFramework.Framework
{
	public abstract class BaseElement : BaseEntity
	{
		private IWebElement element;
		protected By ByLocator;
	
		public IWebElement WebElement
		{
			get
			{
				element = Browser.Driver.SafeFindElement(ByLocator, WaitTimeInSeconds);
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

		public virtual bool IsPresent()
		{
			bool result = Browser.Driver.SafeFindElement(ByLocator, WaitTimeInSeconds) != null;
			return result;
		}

		public void WaitPresent(TimeSpan timeData)
		{
			WebDriverWait wait = new WebDriverWait(Browser.Driver, timeData);
			wait.Until(ExpectedConditions.ElementIsVisible(ByLocator));
		}
	}
}
