using System.Collections.Generic;
using System.Linq;
using ATFramework.Framework;
using ATFramework.Framework.Attributes;
using ATFramework.Framework.Common;
using ATFramework.WebElements;
using ATFramework.WebElements.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ATFramework.Framework.Extensions;
using ATFramework.Framework.Exceptions;
using System;

namespace TimeAndDateAutomation.WebPages.Blocks
{
	public class MenuBlock : BasePage
	{
		[Bind(How = How.CssSelector, Name = "MenuBlock")]
		private Block menuBlock;

		[Bind(How = How.Id, Name = "DropDownSubMenuBlock")]
		private Block dropDownSubMenuBlock;

		public MenuBlock()
		{
			PageFactory.InitElements(this);

			if (!menuBlock.IsDisplayed())
				throw new PageNotFoundException("Page: " + GetType().Name + " not found");
		}

		
	}
}
