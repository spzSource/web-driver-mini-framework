
namespace RealtAutomation.Framework
{
	public class BaseEntity
	{
		protected Browser Browser { get; private set; }
		protected Logger Logger { get; private set; }

		public BaseEntity()
		{
			Browser = Browser.Instance;
			Logger = Logger.Instance;
		}
	}
}
