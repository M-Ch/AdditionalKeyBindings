using System;

namespace AdditionalKeyBindings.BindActions
{
	public class CyclePrefabAction : IExecutableAction, IActionDescription
	{
		private readonly CycleDirection _direction;

		public CyclePrefabAction(CycleDirection direction)
		{
			_direction = direction;
		}

		public ActionCategory Category { get { return ActionCategory.Shared; } }
		public string DisplayName { get { return String.Format("Cycle building/road slot {0}", _direction.ToString().ToLower()); } }
		public string Command { get { return String.Format("AKB-CyclePrefab{0}", _direction); } }

		public void Execute()
		{
			var activePanel = MainToolbar.GetActivePanel();
			if(activePanel == null)
				return;

			var tab = activePanel.SelectedTab;
			if (tab != null)
				tab.Selected = MathUtils.Cycle(tab.Selected, 0, tab.Count - 1, _direction);
		}
	}
}