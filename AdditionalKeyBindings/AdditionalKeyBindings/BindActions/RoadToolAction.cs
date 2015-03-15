using System;

namespace AdditionalKeyBindings.BindActions
{
	public class RoadToolAction : IExecutableAction
	{
		private readonly NetTool.Mode _mode;

		public RoadToolAction(NetTool.Mode mode)
		{
			_mode = mode;
		}

		public ActionCategory Category { get { return ActionCategory.Shared; } }

		public string DisplayName { get { return String.Format("Road tool mode: {0}", _mode); } }
		public string Command { get { return String.Format("AKB-RoadTool{0}", _mode); } }

		public void Execute()
		{
			RoadToolStrip.ToolMode = _mode;
		}
	}
}