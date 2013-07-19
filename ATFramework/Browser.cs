using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ATFramework
{
    public class Browser
    {
		private static volatile Browser browser;
		private FirefoxBinary binary;
		private FirefoxProfile profile;
		public IWebDriver Driver { get; protected set; }


		private Browser()
		{
			//binary = new FirefoxBinary(ConfigurationManager.AppSettings["firefox_binary_path"]);
			binary = new FirefoxBinary();
			profile = new FirefoxProfile();
			profile.EnableNativeEvents = true;
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
			//Driver = new FirefoxDriver(binary, profile);
			Driver = new FirefoxDriver(profile);
			Driver.Manage().Window.Maximize();
			Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
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
