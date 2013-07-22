using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ATFramework.WebElements.Utils
{
	public class PageFactory
	{
		public PageFactory()
		{ }

		public static void InitElements(object page)
		{
			Type type = page.GetType();
			//List<MemberInfo> membersBasicList = new List<MemberInfo>();
			List<MemberInfo> members = new List<MemberInfo>();

			const BindingFlags publicBindingOptions = BindingFlags.Instance | BindingFlags.Public;
			members.AddRange(type.GetFields(publicBindingOptions));
			members.AddRange(type.GetProperties(publicBindingOptions));

			while (type != null)
			{
				const BindingFlags nonPublicBindingOptions = BindingFlags.Instance | BindingFlags.NonPublic;
				members.AddRange(type.GetFields(nonPublicBindingOptions));
				members.AddRange(type.GetProperties(nonPublicBindingOptions));
				type = type.BaseType;
			}

			

			//const BindingFlags publicAndNonPublicBindingOptions = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.NonPublic;

			//members.AddRange(membersBasicList);
			//foreach (MemberInfo memberInfo in membersBasicList)
			//{
			//	BlockAttribute blockAttribute = memberInfo.GetType().GetCustomAttribute(typeof (BlockAttribute), true) as BlockAttribute;
			//	if (blockAttribute != null)
			//	{
			//		members.AddRange(memberInfo.GetType().GetFields(publicAndNonPublicBindingOptions));
			//		members.AddRange(memberInfo.GetType().GetProperties(publicAndNonPublicBindingOptions));	
			//	}
			//}

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
			Attribute attribute = Attribute.GetCustomAttribute(member, typeof(BindAttribute));
			if (attribute != null)
			{
				var castedAttribute = (BindAttribute)attribute;
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
			Attribute attribute = Attribute.GetCustomAttribute(member, typeof(BindAttribute));
			BindAttribute castedAttribute = (BindAttribute)attribute;
			if (attribute != null)
			{
				elementName = castedAttribute.Name;
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
