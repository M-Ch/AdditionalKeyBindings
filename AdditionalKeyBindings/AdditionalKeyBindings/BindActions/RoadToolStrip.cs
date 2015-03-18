using System.Linq;
using ColossalFramework.UI;
using UnityEngine;

namespace AdditionalKeyBindings.BindActions
{
	public static class RoadToolStrip
	{
		private static UITabstrip GetToolStrip()
		{
			return Object.FindObjectsOfType<UITabstrip>().FirstOrDefault(i => i.name == "ToolMode" && i.isVisible);
		}

		public static NetTool.Mode ToolMode 
		{
			get
			{
				var toolstrip = GetToolStrip();
				return toolstrip != null ? (NetTool.Mode) toolstrip.selectedIndex : NetTool.Mode.Straight;
			}
			set 
			{
				var toolstrip = GetToolStrip();
				if (toolstrip != null)
					toolstrip.selectedIndex = (int) value;
			}
		}
	}
}