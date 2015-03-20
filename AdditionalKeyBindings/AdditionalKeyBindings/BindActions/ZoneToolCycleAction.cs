namespace AdditionalKeyBindings.BindActions
{
	public class ZoneToolCycleAction : PanelValueCyclingAction<NetTool.Mode>, IActionDescription
	{
		public ZoneToolCycleAction() : base(GameUiParts.ZoneToolStrip)
		{
		}

		public ActionCategory Category { get { return ActionCategory.Shared; } }

		public string DisplayName { get { return "Zone tool mode: cycle"; } }
		public string Command { get { return "AKB-ZoningToolCycle"; } }
	}
}