using System;

namespace ATFramework.WebElements.Utils
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
	public sealed class BindAttribute : Attribute
	{
		public How How { get; set; }
		public string Name { get; set; }
	}
}
