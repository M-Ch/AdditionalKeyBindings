using System;
using System.Linq;
using ColossalFramework.UI;
using Object = UnityEngine.Object;

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
			var toolStrip = Object.FindObjectsOfType<UITabstrip>().FirstOrDefault(i => i.name == "ToolMode");
			if (toolStrip != null && toolStrip.isVisible)
				toolStrip.selectedIndex = (int) _mode;
		}
	}
}