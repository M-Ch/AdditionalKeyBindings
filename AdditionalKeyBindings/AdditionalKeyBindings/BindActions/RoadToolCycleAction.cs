namespace AdditionalKeyBindings.BindActions
{
	public class RoadToolCycleAction : PanelValueCyclingAction<NetTool.Mode>, IActionDescription
	{
		public RoadToolCycleAction() : base(GameUiParts.RoadToolStrip)
		{
		}

		public ActionCategory Category { get { return ActionCategory.Shared; } }

		public string DisplayName { get { return "Road tool mode: cycle"; } }
		public string Command { get { return "AKB-RoadToolCycle"; } }
	}
}