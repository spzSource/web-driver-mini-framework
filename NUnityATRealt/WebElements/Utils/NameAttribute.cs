using System;

namespace RealtAutomation.WebElements.Utils
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
	class NameAttribute : Attribute
	{
		public string ElementName { get; set; }
	}
}
