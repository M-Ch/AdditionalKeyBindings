using System;
using System.Collections.Generic;
using System.Linq;
using AdditionalKeyBindings.BindActions;
using ColossalFramework;
using UnityEngine;

namespace AdditionalKeyBindings
{
	public class KeyBindingMod
	{
		private readonly IExecutableAction[] _actions;
		private readonly ResettableBehavior<KeyListener> _listener;
		private readonly List<Tuple<IExecutableAction, SavedInputKey>> _keyBinds;

		public KeyBindingMod()
		{
			_listener = new ResettableBehavior<KeyListener>("AKB-KeyListener");
			_actions = new IExecutableAction[]
			{
				new RoadToolAction(NetTool.Mode.Straight),
				new RoadToolAction(NetTool.Mode.Curved),
				new RoadToolAction(NetTool.Mode.Freeform),
				new RoadToolAction(NetTool.Mode.Upgrade),
				new RoadToolCycleAction(),
				new RoadToolSnapAction(),
				new CyclePrefabAction(CycleDirection.Up),
				new CyclePrefabAction(CycleDirection.Down),
				new SelectPrefabAction(0),
				new SelectPrefabAction(1),
				new SelectPrefabAction(2),
				new SelectPrefabAction(3),
				new SelectPrefabAction(4),
				new SelectPrefabAction(5),
				new SelectPrefabAction(6)
			};

			_keyBinds = _actions
				.Select(i => Tuple.Create(i, new SavedInputKey(i.Command, Settings.gameSettingsFile, (int)KeyCode.None, true)))
				.ToList();
		}

		public IEnumerable<IActionDescription> ActionDescriptions { get { return _actions; } }

		public void Start()
		{
			DebugUtil.WriteLine("AdditionalKeyBindigs: Start");
			Try.Execute(() =>
			{
				var behavior = _listener.Behavior;
				DebugUtil.CheckReference("behavior", behavior);
				if(behavior != null)
					behavior.KeyEvent += OnKeyEvent;
			});
		}

		public void End()
		{
			_listener.Behavior.KeyEvent -= OnKeyEvent;
			_listener.Reset();
			DebugUtil.WriteLine("AdditionalKeyBindigs: End");
		}

		private void OnKeyEvent(object sender, KeyEventArgs e)
		{
			DebugUtil.WriteLine("Key event handler called");
			var action = _keyBinds.FirstOrDefault(i => i.Item2.IsPressed(e.EventType, e.KeyCode, e.Modifiers));
			if (action == null) return;

			DebugUtil.WriteLine("Action to run: {0}", action.Item1.DisplayName);
			action.Item1.Execute();
		}
	}
}