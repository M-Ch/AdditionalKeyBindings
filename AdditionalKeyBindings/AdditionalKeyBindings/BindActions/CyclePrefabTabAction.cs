using System;

namespace AdditionalKeyBindings.BindActions
{
	public class CyclePrefabTabAction : IExecutableAction, IActionDescription
	{
		private readonly CycleDirection _direction;

		public CyclePrefabTabAction(CycleDirection direction)
		{
			_direction = direction;
		}

		public ActionCategory Category { get { return ActionCategory.Shared; } }
		public string DisplayName { get { return String.Format("Cycle tool tab {0}", _direction.ToString().ToLower()); } }
		public string Command { get { return String.Format("AKB-CyclePrefabTab{0}", _direction); } }

		public void Execute()
		{
			var activePanel = MainToolbar.GetActivePanel();
			if(activePanel != null)
				activePanel.SelectedTabIndex = MathUtils.Cycle(activePanel.SelectedTabIndex, 0, activePanel.TabCount - 1, _direction);
		}
	}
}