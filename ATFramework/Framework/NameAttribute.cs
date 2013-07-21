using System;

namespace ATFramework.Framework.Attributes
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Enum, AllowMultiple = false)]
	public class NameAttribute : Attribute
	{
		public string ElementName { get; private set; }

		public NameAttribute(string elementName)
		{
			this.ElementName = elementName;
		}
	}
}
