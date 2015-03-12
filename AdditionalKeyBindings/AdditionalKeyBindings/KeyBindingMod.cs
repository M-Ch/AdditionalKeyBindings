using System.Collections.Generic;
using AdditionalKeyBindings.BindActions;

namespace AdditionalKeyBindings
{
	public class KeyBindingMod
	{
		private readonly IExecutableAction[] _actions;

		public KeyBindingMod()
		{
			_actions = new IExecutableAction[]
			{
				new RoadToolAction(NetTool.Mode.Straight),
				new RoadToolAction(NetTool.Mode.Curved),
				new RoadToolAction(NetTool.Mode.Freeform),
				new RoadToolAction(NetTool.Mode.Upgrade),
			};
		}

		public IEnumerable<IActionDescription> ActionDescriptions { get { return _actions; } }
	}
}