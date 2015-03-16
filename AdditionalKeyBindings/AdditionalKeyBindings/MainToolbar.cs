using System.Linq;
using ColossalFramework.UI;

namespace AdditionalKeyBindings
{
	public class MainToolbar
	{
		[CanBeNull]
		public static ToolbarActivePanel GetActivePanel()
		{
			var toolsTabStrip = (UITabstrip)ToolsModifierControl.mainToolbar.component;
			var mainMenuButtons = toolsTabStrip.components.OfType<UIButton>().ToList();
			var activePanelButton = mainMenuButtons.FirstOrDefault(i => i.state == UIButton.ButtonState.Focused);

			return activePanelButton != null ? new ToolbarActivePanel(activePanelButton.name, toolsTabStrip) : null;
		}
	}
}