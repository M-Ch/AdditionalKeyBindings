using System;

namespace AdditionalKeyBindings.BindActions
{
	public class RoadToolAction : PanelValueSettingAction<NetTool.Mode>, IActionDescription
	{
		public RoadToolAction(NetTool.Mode mode) : base(GameUiParts.RoadToolStrip, mode)
		{
		}

		public ActionCategory Category { get { return ActionCategory.Shared; } }

		public string DisplayName { get { return String.Format("Road tool mode: {0}", Value); } }
		public string Command { get { return String.Format("AKB-RoadTool{0}", Value); } }
	}
}