using ATFramework.Framework;
using ATFramework.WebElements;
using ATFramework.WebElements.Utils;
using ATFramework.Framework.Exceptions;
using TimeAndDateAutomation.Annotations;

namespace TimeAndDateAutomation.WebPages.Blocks
{
	public class MenuBlock : BasePage
	{
		[Bind(How = How.CssSelector, Name = "MenuBlock"), UsedImplicitly]
		private Block menuBlock;

		[Bind(How = How.Id, Name = "DropDownSubMenuBlock"), UsedImplicitly]
		private Block dropDownSubMenuBlock;

		public MenuBlock()
		{
			PageFactory.InitElements(this);

			if (!menuBlock.IsDisplayed())
				throw new PageNotFoundException("Page: " + GetType().Name + " not found");	
		}
	}
}
