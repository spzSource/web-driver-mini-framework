using System;
using System.Reflection;
using System.Text;
using ATFramework.Framework.Attributes;

namespace ATFramework.Framework.Extensions
{
	public static class EnumExtensions
	{
		public static string ToChainString(this Enum enumValue)
		{
			StringBuilder chainName = new StringBuilder();
 
			Type enumType = enumValue.GetType();
			FieldInfo info = enumType.GetField(enumValue.ToString());

			NameAttribute attribute = info.GetCustomAttribute<NameAttribute>();
			if (attribute == null)
			{
				throw new ArgumentException("Enum value: " + enumValue.ToString() + " must have an NameAttribute.");
			}

			NameAttribute menuAttribute = enumType.GetCustomAttribute<NameAttribute>();
			if (menuAttribute == null)
			{
				throw new ArgumentException("Enum : " + enumType.Name + " must have an NameAttribute.");
			}


			chainName.AppendFormat("{0} > {1}", menuAttribute.ElementName, attribute.ElementName);

			return chainName.ToString();
		}
	}
}
