using System;

namespace AdditionalKeyBindings.BindActions
{
	public class SelectPrefabAction : IExecutableAction, IActionDescription
	{
		private readonly int _slot;

		public SelectPrefabAction(int slot)
		{
			_slot = slot;
		}

		public ActionCategory Category { get { return ActionCategory.Shared; } }
		public string DisplayName { get { return String.Format("Select building/road slot {0}", _slot+1); } }
		public string Command { get { return String.Format("AKB-SelectPrefab{0}", _slot+1); } }

		public void Execute()
		{
			var activePanel = MainToolbar.GetActivePanel();
			if (activePanel == null)
				return;

			var tab = activePanel.SelectedTab;
			if (tab != null)
				tab.Selected = _slot;
		}
	}
}