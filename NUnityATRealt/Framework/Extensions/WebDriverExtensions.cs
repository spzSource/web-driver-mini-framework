using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace RealtAutomation.Framework.Extensions
{
	public static class WebDriverExtensions
	{
		public static IWebElement SafeFindElement(this IWebDriver driver, By by, int seconds = 0)
		{
			WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
			return wait.Until<IWebElement>(drv => drv.FindElement(by));
		}

		public static IEnumerable<IWebElement> SafeFindElements(this IWebDriver driver, By by, int seconds = 0)
		{
			WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
			return wait.Until<IEnumerable<IWebElement>>(drv => drv.FindElements(by));
		}

		public static void WaitPresentation(this IWebDriver driver, Func<IWebDriver, bool> action, By by, int seconds = 0)
		{
			WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
			wait.Until(action);
		}
	}
}
