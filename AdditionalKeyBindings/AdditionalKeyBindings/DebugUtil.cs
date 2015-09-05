using System;
using System.Collections.Generic;
using System.Diagnostics;
using ColossalFramework.Plugins;

namespace AdditionalKeyBindings
{
	public static class DebugUtil
	{
		[Conditional("DEBUG")]
		public static void WriteLine(String format, params object[] parameters)
		{
			DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, String.Format(format, parameters));
		}

		[Conditional("DEBUG")]
		public static void WriteObject(object value)
		{
			DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, value?.ToString() ?? "null");
		}

		[Conditional("DEBUG")]
		public static void CheckReference(string referenceName, object value)
		{
			WriteLine(value != null 
				? $"{referenceName} type is {value.GetType().Name}"
				: $"{referenceName} is null");
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