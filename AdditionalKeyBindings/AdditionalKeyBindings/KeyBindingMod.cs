using System.Collections.Generic;

namespace AdditionalKeyBindings
{
	public class KeyBindingMod
	{
		public KeyBindingMod()
		{
			ActionDescriptions = new[] {new ActionDescription(ActionCategory.Game)};
		}

		public IEnumerable<ActionDescription> ActionDescriptions { get; private set; }
	}
}