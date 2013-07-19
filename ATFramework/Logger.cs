using System;
using System.Configuration;
using System.IO;

namespace ATFramework
{
	public class Logger
	{
		private static volatile Logger instance;
		private string logPath;
		
		public static Logger Instance
		{
			get
			{
				if (instance == null)
				{
					string logPath = ConfigurationManager.AppSettings["log_path"];
					instance = new Logger(logPath);
				}
				return instance;
			}
		}

		private Logger(string logPath)
		{
			this.logPath = logPath;
		}

		public void Log(object message)
		{
			File.AppendAllText(logPath, message + Environment.NewLine);
		}
	}
}
