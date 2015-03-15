using System;

namespace AdditionalKeyBindings.BindActions
{
	public class RoadToolCycleAction : IExecutableAction
	{
		public ActionCategory Category { get { return ActionCategory.Shared; } }

		public string DisplayName { get { return "Road tool mode: cycle"; } }
		public string Command { get { return "AKB-RoadToolCycle"; } }

		public void Execute()
		{
			var modeCount = Enum.GetValues(typeof (NetTool.Mode)).Length;
			RoadToolStrip.ToolMode = (NetTool.Mode)((int) RoadToolStrip.ToolMode).CycleIncrement(0, modeCount - 1);
		}
	}
}