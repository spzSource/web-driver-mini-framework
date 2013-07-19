using System;
using OpenQA.Selenium;

namespace RealtAutomation.WebElements.Utils
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
	public sealed class FindAttribute : Attribute
	{
		public How How { get; set; }
	}
}
