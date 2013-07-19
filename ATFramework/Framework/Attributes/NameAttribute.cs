using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
