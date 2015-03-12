using System;

namespace AdditionalKeyBindings
{
	internal static class Try
	{
		public static void Execute(Action code)
		{
			try
			{
				code();
			}
			catch (Exception e)
			{
				DebugUtil.WriteException(e);
			}
		}
	}
}