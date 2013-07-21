using System;

namespace RealtAutomation.Framework.Exceptions
{
	[Serializable]
	public class PageNotFoundException : Exception
	{
		public PageNotFoundException() { }
		public PageNotFoundException(string message) : base(message) { }
		public PageNotFoundException(string message, Exception inner) : base(message, inner) { }
	}
}
