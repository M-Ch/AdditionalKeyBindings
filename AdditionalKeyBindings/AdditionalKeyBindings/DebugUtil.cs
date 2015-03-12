using System;
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
	}
}