using System;

namespace AdditionalKeyBindings.BindActions
{
	public interface IActionDescription
	{
		ActionCategory Category { get; }
		String DisplayName { get; }
		String Command { get; }
	}
}