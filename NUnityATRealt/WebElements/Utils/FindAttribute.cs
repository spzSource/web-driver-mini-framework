using System;
using RealtAutomation.Annotations;

namespace RealtAutomation.WebElements.Utils
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false), MeansImplicitUse]
	public sealed class FindAttribute : Attribute
	{
		public How How { get; set; }
	}
}
