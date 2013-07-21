using System;
using System.Reflection;
using System.Text;
using ATFramework.Framework.Attributes;

namespace ATFramework.Framework.Extensions
{
	public static class EnumExtension
	{
		public static string Name(this Enum enumValue)
		{
			StringBuilder resultBuilder = new StringBuilder();
			
			Type enumType = enumValue.GetType();
			FieldInfo field = enumType.GetField(enumValue.ToString());
			NameAttribute attribute = field.GetCustomAttribute<NameAttribute>();

			NameAttribute enumAttribute = enumType.GetCustomAttribute<NameAttribute>();

			if (attribute == null || enumAttribute == null)
				throw  new ArgumentException("Enum not marked by attribute.");

			resultBuilder.AppendFormat("{0} > {1}", enumAttribute.ElementName, attribute.ElementName);
			return resultBuilder.ToString();
		}
	}
}
