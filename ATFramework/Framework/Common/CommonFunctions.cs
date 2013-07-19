using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ATFramework.Framework.Common
{
	public static class CommonFunctions
	{
		public static string DoRegexSingle(string pattern, string source, int groupNumber)
		{
			if (string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(source))
				throw new ArgumentException("Pattern and source must be initialized");

			Regex regex = new Regex(pattern);
			Match match = regex.Match(source);

			string matchValue = match.Groups[groupNumber].Value;

			return matchValue;
		}

		public static IEnumerable<string> Split(string source, char separator = '>')
		{
			//char menuSeparator = ConfigurationManager.AppSettings["menu_separator"]
			//	.ToCharArray().First();

			string[] menuItems = source.Split(separator)
				.Select(e => e.Trim())
				.ToArray();
			return menuItems;
		}
	}
}
