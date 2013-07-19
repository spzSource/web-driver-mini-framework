﻿using ATFramework.Framework;
using ATFramework.WebElements;
using ATFramework.WebElements.Utils;
using NUnit.Framework;
using System.Linq;
using System.Configuration;
using ATFramework.Framework.Common;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TimeAndDateAutomation.WebPages.Blocks;
using System;

namespace TimeAndDateAutomation.WebPages
{
	public class HomePage : BasePage
	{
		[Bind(How = How.CssSelector, Name = "AppsAndApiLink")] 
		private Link linkAppsAndApi;

		Actions action;

		public HomePage()
		{
			PageFactory.InitElements(this);
			Assert.True(linkAppsAndApi.isPresent());

			action = new Actions(Driver);
		}

		public bool CheckPage(string chainMenu, string navigationLabel)
		{
	
			TestablePage page = ClickToItem(chainMenu);
			return page.CheckNavigationChain(navigationLabel);
		}

		public TestablePage ClickToItem(string chainMenu)
		{
			List<string> menuItems = CommonFunctions.Split(chainMenu).ToList();

			string itemLocator = string.Format(".//ul[@id='ht']/li/a[contains(., '{0}')]", menuItems.First());
			Link link = new Link(By.XPath(itemLocator));
		
			link.WaitPresent(TimeSpan.FromSeconds(10));

			action.MoveToElement(link.WebElement).Perform();

			string targetLinkLocator = string.Format(".//*[@id='ho']/li/a[contains(.,'{0}')]", menuItems.Last());
			Link targetLink = new Link(By.XPath(targetLinkLocator));
			targetLink.Click();

			return new TestablePage();
		}
	}
}