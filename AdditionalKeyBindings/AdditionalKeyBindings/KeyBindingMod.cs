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
		private readonly ExecutableActionWithDescription[] _actions;
		private readonly ResettableBehavior<KeyListener> _listener;
		private readonly List<Tuple<ExecutableActionWithDescription, SavedInputKey>> _keyBinds;

		public KeyBindingMod()
		{
			_listener = new ResettableBehavior<KeyListener>("AKB-KeyListener");
			_actions = new[]
			{
				ExecutableActionWithDescription.Create(new RoadToolAction(NetTool.Mode.Straight)),
				ExecutableActionWithDescription.Create(new RoadToolAction(NetTool.Mode.Curved)),
				ExecutableActionWithDescription.Create(new RoadToolAction(NetTool.Mode.Freeform)),
				ExecutableActionWithDescription.Create(new RoadToolAction(NetTool.Mode.Upgrade)),
				ExecutableActionWithDescription.Create(new RoadToolCycleAction()),
				ExecutableActionWithDescription.Create(new RoadToolSnapAction()),

				ExecutableActionWithDescription.Create(new ZoneToolAction(ZoneToolMode.Fill)),
				ExecutableActionWithDescription.Create(new ZoneToolAction(ZoneToolMode.Select)),
				ExecutableActionWithDescription.Create(new ZoneToolAction(ZoneToolMode.SmallBrush)),
				ExecutableActionWithDescription.Create(new ZoneToolAction(ZoneToolMode.LargeBrush)),
				ExecutableActionWithDescription.Create(new ZoneToolCycleAction()),

				ExecutableActionWithDescription.Create(new CyclePrefabTabAction(CycleDirection.Up)),
				ExecutableActionWithDescription.Create(new CyclePrefabTabAction(CycleDirection.Down)),
				ExecutableActionWithDescription.Create(new CyclePrefabAction(CycleDirection.Up)),
				ExecutableActionWithDescription.Create(new CyclePrefabAction(CycleDirection.Down)),

				ExecutableActionWithDescription.Create(new SelectPrefabAction(0)),
				ExecutableActionWithDescription.Create(new SelectPrefabAction(1)),
				ExecutableActionWithDescription.Create(new SelectPrefabAction(2)),
				ExecutableActionWithDescription.Create(new SelectPrefabAction(3)),
				ExecutableActionWithDescription.Create(new SelectPrefabAction(4)),
				ExecutableActionWithDescription.Create(new SelectPrefabAction(5)),
				ExecutableActionWithDescription.Create(new SelectPrefabAction(6))
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
			var actions = _keyBinds.Where(i => i.Item2.IsPressed(e.EventType, e.KeyCode, e.Modifiers));

			foreach (var action in actions)
			{
				DebugUtil.WriteLine("Action to run: {0}", action.Item1.DisplayName);
				action.Item1.Execute();
			}
		}
	}
}