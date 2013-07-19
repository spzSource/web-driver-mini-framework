using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RealtAutomation.WebElements.Utils;

namespace NUnitATRealt.WebElements.Utils
{
	class PageFactory
	{
		public PageFactory()
		{ }

		public static void InitElements(object page)
		{
			Type type = page.GetType();
			List<MemberInfo> members = new List<MemberInfo>();

			const BindingFlags PublicBindingOptions = BindingFlags.Instance | BindingFlags.Public;
			members.AddRange(type.GetFields(PublicBindingOptions));
			members.AddRange(type.GetProperties(PublicBindingOptions));

			while (type != null)
			{
				const BindingFlags NonPublicBindingOptions = BindingFlags.Instance | BindingFlags.NonPublic;
				members.AddRange(type.GetFields(NonPublicBindingOptions));
				members.AddRange(type.GetProperties(NonPublicBindingOptions));
				type = type.BaseType;
			}

			foreach (var member in members)
			{
				By by = null;
				string elementName = GetElementName(member);
				How how = GetHowValue(member);

				if (!string.IsNullOrEmpty(elementName) && how != How.Default)
				{ 
					by = ByFactory.From(how, elementName, page.GetType().Name); 
				}

				if (by != null)
				{
					object proxyObject = null;
					var field = member as FieldInfo;
					var property = member as PropertyInfo;
					if (field != null)
					{
						proxyObject = CreateProxyObject(field.FieldType, by);
						if (proxyObject == null)
						{
							throw new ArgumentException("Could not to create proxy object");
						}

						field.SetValue(page, proxyObject);
					}
					else if (property != null)
					{
						proxyObject = CreateProxyObject(property.PropertyType, by);
						if (proxyObject == null)
						{
							throw new ArgumentException("Could not to create proxy object");
						}

						property.SetValue(page, proxyObject, null);
					}
				}
			}
		}

		private static How GetHowValue(MemberInfo member)
		{
			How how = How.Default;
			Attribute attribute = Attribute.GetCustomAttribute(member, typeof(FindAttribute));
			if (attribute != null)
			{
				var castedAttribute = (FindAttribute)attribute;
				how = castedAttribute.How;

				if (how == How.Default)
				{
					throw new Exception("'How' value is not set");
				}
			}
			return how;
		}

		private static string GetElementName(MemberInfo member)
		{
			string elementName = string.Empty;
			Attribute attribute = Attribute.GetCustomAttribute(member, typeof(NameAttribute));
			NameAttribute castedAttribute = (NameAttribute)attribute;
			if (attribute != null)
			{
				elementName = castedAttribute.ElementName;
			}
			return elementName;
		}

		private static object CreateProxyObject(Type memberType, By by)
		{
			object instance = Activator.CreateInstance(memberType, by);
			return instance;
		}
	}
}
