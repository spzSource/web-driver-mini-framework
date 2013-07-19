using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace RealtAutomation
{
    public class Browser
    {
		private static volatile Browser browser;
		private FirefoxBinary binary;
		private FirefoxProfile profile;
		public IWebDriver Driver { get; protected set; }


		private Browser()
		{
			binary = new FirefoxBinary(ConfigurationManager.AppSettings["firefox_binary_path"]);
			profile = new FirefoxProfile();
		}

		public static Browser Instance
		{
			get
			{
				if (browser == null)
				{
					browser = new Browser();
				}
				return browser;
			}
		}

		public void Open()
		{
			Driver = new FirefoxDriver(binary, profile);
		}

        public void Navigate(Uri url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void Exit()
        {
            if (Driver != null)
            {
                Driver.Close();
				Driver.Quit();
                Driver = null;
            }
        }
    }
}
