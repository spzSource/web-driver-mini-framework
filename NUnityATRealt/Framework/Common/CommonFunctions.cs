using System;
using System.Text.RegularExpressions;

namespace RealtAutomation.Framework.Common
{
	public static class CommonFunctions
	{
		public static string DoRegexSingle(string pattern, string source, int groupNumber)
		{
			if (string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(source))
				throw new ArgumentException("Pattern and source must be initialized");

			Regex regex = new Regex(pattern);
			Match match = regex.Match(source);

			string matchValue = (match.Groups[groupNumber].Value);

			return matchValue;
		}
	}
}
