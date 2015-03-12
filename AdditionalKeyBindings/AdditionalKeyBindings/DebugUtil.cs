using System;
using System.Collections.Generic;
using System.Diagnostics;
using ColossalFramework.Plugins;

namespace AdditionalKeyBindings
{
	public class DebugUtil
	{
		[Conditional("DEBUG")]
		public static void WriteLine(String format, params object[] parameters)
		{
			DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, String.Format(format, parameters));
		}

		[Conditional("DEBUG")]
		public static void CheckReference(string referenceName, object value)
		{
			WriteLine(String.Format("{0} is {1}", referenceName, value != null ? "not null" : "null"));
		}

		[Conditional("DEBUG")]
		public static void WriteList<T>(IEnumerable<T> values, Func<T, String> formatter = null) where T : class
		{
			formatter = formatter ?? (i => i.ToString());
			foreach (var value in values)
				WriteLine(value != null ? formatter(value) : "null");
		}

		[Conditional("DEBUG")]
		public static void CheckNotNull(object value, string message)
		{
			if (value == null)
				WriteLine(message);
		}

		public static void WriteException(Exception exception)
		{
			DebugOutputPanel.AddMessage(PluginManager.MessageType.Error, exception.ToString());
		}
	}
}