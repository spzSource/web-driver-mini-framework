using OpenQA.Selenium;

namespace RealtAutomation.Framework
{
    public abstract class BasePage : BaseEntity
    {
		public IWebDriver Driver
		{
			get { return Browser.Driver; }
		}
    }
}
