using ATFramework.Framework;
using ATFramework.WebElements;
using NUnit.Framework;
using ATFramework.WebElements.Utils;
using TimeAndDateAutomation.Annotations;

namespace TimeAndDateAutomation.WebPages
{
	public class TestablePage : BasePage
	{
		[Bind(How = How.Id, Name = "NavigationChain"), UsedImplicitly]
		private Label navigationChain;

		public string NavString
		{
			get { return navigationChain.Text; }
		}

		public TestablePage()
		{
			PageFactory.InitElements(this);
			Assert.True(navigationChain.IsPresent());
		}

		public bool CheckNavigationChain(string navChain)
		{
			navigationChain.Click();
			string navStr = navigationChain.Text;
			return navChain.Equals(navStr);
		}
	}
}
