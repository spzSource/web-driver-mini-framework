using System;
using System.Linq;
using ATFramework.Framework.Common;

namespace TimeAndDateAutomation.Utils
{
	internal static class EnumFunctions
	{
		public static Enum ParseName(string menuChain)
		{
			string enumTypeName = CommonFunctions.Split(menuChain).First().Replace(" ", String.Empty);
			string enumValueName = CommonFunctions.Split(menuChain).Last().Replace(" ", String.Empty);
			Enum mEnum = Enum.Parse(Type.GetType("TimeAndDateAutomation.WebPages.Blocks." + enumTypeName), enumValueName) as Enum;
			return mEnum;
		}
	}
}
