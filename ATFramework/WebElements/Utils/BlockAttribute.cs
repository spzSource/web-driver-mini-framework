using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATFramework.WebElements.Utils
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class BlockAttribute : Attribute
	{
		public How How { get; set; }
		public string Name { get; set; }
	}
}
