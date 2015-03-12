using System.Collections.Generic;
using AdditionalKeyBindings.BindActions;

namespace AdditionalKeyBindings
{
	public class KeyBindingMod
	{
		private readonly IExecutableAction[] _actions;
		private readonly ResettableBehavior<KeyListener> _listener;

		public KeyBindingMod()
		{
			_listener = new ResettableBehavior<KeyListener>("AKB-KeyListener");
			_actions = new IExecutableAction[]
			{
				new RoadToolAction(NetTool.Mode.Straight),
				new RoadToolAction(NetTool.Mode.Curved),
				new RoadToolAction(NetTool.Mode.Freeform),
				new RoadToolAction(NetTool.Mode.Upgrade),
			};
		}

		public IEnumerable<IActionDescription> ActionDescriptions { get { return _actions; } }

		public void Start()
		{
			_listener.Behavior.KeyEvent += OnKeyEvent;
		}

		public void End()
		{
			_listener.Behavior.KeyEvent -= OnKeyEvent;
			_listener.Reset();
		}

		private static void OnKeyEvent(object sender, KeyEventArgs e)
		{
			DebugUtil.WriteLine("Something was pressed");
		}
	}
}