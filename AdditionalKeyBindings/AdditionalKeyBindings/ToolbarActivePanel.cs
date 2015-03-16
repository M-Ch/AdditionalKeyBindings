using System;
using System.Collections.Generic;
using System.Linq;
using ColossalFramework.UI;

namespace AdditionalKeyBindings
{
	public class ToolbarActivePanel
	{
		private readonly string _panelName;
		private readonly UITabstrip _groupTabs;

		public ToolbarActivePanel(string panelName, UITabstrip parentTabStrip)
		{
			_panelName = panelName;
			_groupTabs = FindGroupTabs(parentTabStrip);
		}

		private UITabstrip FindGroupTabs(UITabstrip parentTabStrip)
		{
			var type = Type.GetType(_panelName+"GroupPanel, Assembly-CSharp");
			var button = parentTabStrip.components.First(i => i.name == _panelName);
			var groupPanel = (GeneratedGroupPanel) parentTabStrip.GetComponentInContainer(button, type);

			return ReflectionUtils.GetPrivateFieldValue<UITabstrip>(groupPanel, "m_Strip");
		}

		[CanBeNull]
		public ToolbarTab SelectedTab
		{
			get
			{
				var selected = _groupTabs.FindFocusedButton();
				if (selected == null)
					return null;
				var panelType = Type.GetType(_panelName + "Panel, Assembly-CSharp");
				var buttonsPanel = (GeneratedScrollPanel) _groupTabs.GetComponentInContainer(selected, panelType);
				return new ToolbarTab(buttonsPanel);
			}
		}
	}

	public class ToolbarTab
	{
		private readonly List<UIButton> _buttons;

		public ToolbarTab(GeneratedScrollPanel buttonsPanel)
		{
			_buttons = buttonsPanel.childComponents.OfType<UIButton>().Where(IsUnlocked).ToList();
		}

		private static bool IsUnlocked(UIButton arg)
		{
			var prefabInfo = arg.objectUserData as PrefabInfo;
			return prefabInfo == null || ToolsModifierControl.IsUnlocked(prefabInfo.GetUnlockMilestone());
		}

		public int Count
		{
			get { return _buttons.Count; }
		}

		public int Selected
		{
			get { return _buttons.FindIndex(i => i.state == UIButton.ButtonState.Focused); }
			set { _buttons[MathUtils.Clamp(value, 0, Count-1)].SimulateClick(); }
		}
	}
}