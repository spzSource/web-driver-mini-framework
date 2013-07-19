using System;
using System.Configuration;
using System.Globalization;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace RealtAutomation.WebElements.Utils
{
	internal static class ByFactory
	{
		public static By From(How how, string elementName, string className)
		{
			string locator = GetLocatorString(elementName, className);
			switch (how)
			{
				case How.Id:
					return By.Id(locator);
				case How.Name:
					return By.Name(locator);
				case How.TagName:
					return By.TagName(locator);
				case How.ClassName:
					return By.ClassName(locator);
				case How.CssSelector:
					return By.CssSelector(locator);
				case How.LinkText:
					return By.LinkText(locator);
				case How.PartialLinkText:
					return By.PartialLinkText(locator);
				case How.XPath:
					return By.XPath(locator);
			}

			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture,
				"Did not know how to construct How from how {0}, locator{1}", how, locator));
		}

		private static string GetLocatorString(string elementName, string className)
		{		  
			string fileLocation = ConfigurationManager.AppSettings["locators_path"];
			XDocument document = XDocument.Load(fileLocation);

			var classSection = from sct in document.Descendants("class")
							   where sct.Attribute("name").Value.Equals(className)
							   select sct;
			
			if (classSection == null || classSection.Count() == 0)
			{
				throw new Exception(string.Format("Element with name: {0} in class: {1} not found in file by location: {2}", 
					elementName, className, fileLocation));
			}
			string locator = classSection.Descendants("field")
				.ToList()
				.Find(e => e.Attribute("field_name").Value.Equals(elementName))
				.Attribute("locator").Value;

			if (string.IsNullOrEmpty(locator))
			{
				throw new Exception(string.Format("Element with name: {0} in class: {1} not found in file by location: {2}",
					elementName, className, fileLocation));
			}
			return locator;
		}
	}
}
