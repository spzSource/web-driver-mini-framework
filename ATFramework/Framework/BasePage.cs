using OpenQA.Selenium;
using ATFramework.Framework.Common;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using ATFramework.WebElements;
using OpenQA.Selenium.Interactions;
using System;

namespace ATFramework.Framework
{
    public abstract class BasePage : BaseEntity
    {
		protected IWebDriver Driver
		{
			get { return Browser.Driver; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="menuChain"> Calculators > Date Calculator </param>
		/// <returns>Page instance</returns>
		public T LoadPage<T>(string menuChain) where T : class
		{
			var subitems = menuChain.Split('>').Select(e => e.Trim()).ToList();

			List<Link> links = new List<Link>();
			subitems.ForEach(e => links.Add(new Link(By.LinkText(e))));

			var last = links.Last();
			links.Remove(links.Last());

			Actions action = new Actions(Driver);
			foreach (Link link in links)
			{
				action.MoveToElement(link.WebElement).Perform();
			}
			last.Click();
			return Activator.CreateInstance(typeof(T)) as T;
		}
    }
}
