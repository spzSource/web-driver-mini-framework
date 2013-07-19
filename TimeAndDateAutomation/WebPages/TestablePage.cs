using ATFramework.Framework;
using ATFramework.WebElements;
using NUnit.Framework;
using ATFramework.WebElements.Utils;

namespace TimeAndDateAutomation.WebPages
{
	public class TestablePage : BasePage
	{
		[Bind(How = How.Id, Name = "NavigationChain")]
		private Label navigationChain;

		public TestablePage()
		{
			PageFactory.InitElements(this);
			Assert.True(navigationChain.isPresent());
		}

		public bool CheckNavigationChain(string navChain)
		{
			string navStr = navigationChain.Text;
			return navChain.Equals(navStr);
		}
	}
}
