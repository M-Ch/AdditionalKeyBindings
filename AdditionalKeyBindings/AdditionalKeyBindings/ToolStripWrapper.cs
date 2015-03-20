using System;
using System.Linq;
using ColossalFramework.UI;
using GameZoneTool = ZoneTool;
using Object = UnityEngine.Object;

namespace AdditionalKeyBindings
{
	public class ToolStripWrapper
	{
		private readonly string _name;

		public ToolStripWrapper(String name)
		{
			_name = name;
		}

		[CanBeNull]
		private UITabstrip GetToolStrip()
		{
			return Object.FindObjectsOfType<UITabstrip>().FirstOrDefault(i => i.name == _name && i.isVisible);
		}

		public int Index
		{
			get
			{
				var toolStrip = GetToolStrip();
				return toolStrip != null ? toolStrip.selectedIndex : 0;
			}
			set
			{
				var toolstrip = GetToolStrip();
				if(toolstrip != null)
					toolstrip.selectedIndex = value;
			}
		}
	}

	public class ToolStripWrapper<TEnum> : ToolStripWrapper where TEnum : struct
	{
		public ToolStripWrapper(string name) : base(name)
		{
		}

		public TEnum Value
		{
			get { return (TEnum) ((object) Index); }
			set { Index = (int) ((object) value); }
		}
	}
}