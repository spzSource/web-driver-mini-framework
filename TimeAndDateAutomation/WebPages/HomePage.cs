using ATFramework.Framework;
using ATFramework.WebElements;
using ATFramework.WebElements.Utils;
using NUnit.Framework;
using System.Linq;
using ATFramework.Framework.Common;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using TimeAndDateAutomation.Annotations;
using ATFramework.Framework.Extensions;
using TimeAndDateAutomation.WebPages.Blocks;

namespace TimeAndDateAutomation.WebPages
{
	public class HomePage : BasePage
	{
		[Bind(How = How.CssSelector, Name = "AppsAndApiLink"), UsedImplicitly] 
		private Link linkAppsAndApi;

		private const string MenuLocator = ".//ul[@id='ht']/li/a[contains(., '{0}')]";
		private const string DropMenuLocator = ".//*[@id='ho']/li/a[contains(.,'{0}')]";

		public HomePage()
		{
			PageFactory.InitElements(this);
			Assert.True(linkAppsAndApi.IsPresent());
		}

		public TestablePage GoToPage(Enum chainMenu)
		{
			TestablePage page = ClickToItem(chainMenu.Name());
			return page;
		}

		public TestablePage ClickToItem(string chainMenu)
		{
			List<string> menuItems = CommonFunctions.Split(chainMenu).ToList();

			if (menuItems.Count != 2)
				throw  new ArgumentException("Argument 'chainMenu' must contain two elements.");

			string mainMenuItem = menuItems.First();
			string dropDownMenuItem = menuItems.Last();

			string mainItemLocator = string.Format(MenuLocator, mainMenuItem);
			string dropDownItemLocator = string.Format(DropMenuLocator, dropDownMenuItem);
			
			Link mainLink = new Link(By.XPath(mainItemLocator));
			Link dropDownLink = new Link(By.XPath(dropDownItemLocator));

			Actions action = new Actions(Driver);
			action.MoveToElement(mainLink.WebElement).Perform();

			dropDownLink.Click();

			return new TestablePage();
		}
	}
}
