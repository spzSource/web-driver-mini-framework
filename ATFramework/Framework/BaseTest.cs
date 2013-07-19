using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;

namespace ATFramework.Framework
{
	public class BaseTest : BaseEntity
	{
		[TestFixtureSetUp]
		public void BeforeClass()
		{
			Browser.Open();
		}

		[SetUp]
		public void BeforeTest()
		{
			Browser.Navigate(new Uri(ConfigurationManager.AppSettings["start_url"]));
		}

		[TestFixtureTearDown]
		public void AfterClass()
		{
			Browser.Exit();
		}

		public void Log(object message)
		{
			Logger.Log(message);
		}

		public IEnumerable<object[]> GetTestData()
		{
			XDocument document = XDocument.Load("test_data.xml");
			var section = from sct in document.Descendants("test_data")
						  where sct.Attribute("name").Value.Equals(GetType().Name)
						  select sct;

			return section.Descendants("data_item")
						  .Select(e => e.Attributes().Select(el => el.Value).Cast<object>().ToArray());
		}
	}
}
