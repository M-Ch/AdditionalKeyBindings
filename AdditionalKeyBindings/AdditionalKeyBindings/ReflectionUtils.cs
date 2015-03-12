using System;
using System.Reflection;

namespace AdditionalKeyBindings
{
	internal static class ReflectionUtils
	{
		public static object GetPrivateFieldValue(object item, String field)
		{
			var info = item.GetType().GetField(field, BindingFlags.NonPublic | BindingFlags.Instance);
			return info.GetValue(item);
		}

		public static T GetPrivateFieldValue<T>(object item, String field) where T : class
		{
			var result = GetPrivateFieldValue(item, field);
			var asT = result as T;
			if(result != null && asT == null)
				DebugUtil.WriteLine("Reflection: private field type mismatch. Expected: {0}, but was {1}.", typeof(T).Name, result.GetType().Name);

			return asT;
		}

		public static void InvokePrivateMethod(object item, String method, params object[] arguments)
		{
			var info = item.GetType().GetMethod(method, BindingFlags.NonPublic | BindingFlags.Instance);
			info.Invoke(item, arguments);
		}		 
	}
}