using ATFramework.Framework;
using ATFramework.WebElements;
using ATFramework.WebElements.Utils;

namespace TimeAndDateAutomation.WebPages.Blocks
{
	[Block(How = How.Id, Name = "Some Name")]
	class Block1 : BasePage
	{
		[Bind(How = How.Id, Name = "Link1")]
		private Link link1;

		[Bind(How = How.Id, Name = "Button1")]
		private Button button1;
	}
}
