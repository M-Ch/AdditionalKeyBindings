using System;

namespace AdditionalKeyBindings.BindActions
{
	public class ZoneToolAction : PanelValueSettingAction<ZoneToolMode>, IActionDescription
	{
		public ZoneToolAction(ZoneToolMode mode) : base(GameUiParts.ZoneToolStrip, mode)
		{
		}

		public ActionCategory Category { get { return ActionCategory.Shared; } }

		public string DisplayName { get { return String.Format("Zone tool mode: {0}", Value); } }
		public string Command { get { return String.Format("AKB-ZoningTool{0}", Value); } }
	}
}