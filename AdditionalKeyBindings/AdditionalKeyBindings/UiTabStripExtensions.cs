using System.Linq;
using ColossalFramework.UI;

namespace AdditionalKeyBindings
{
	public static class UiTabStripExtensions
	{
		[CanBeNull]
		public static UIButton FindFocusedButton(this UITabstrip tabStrip)
		{
			return tabStrip.components.OfType<UIButton>().FirstOrDefault(i => i.state == UIButton.ButtonState.Focused);
		}
	}
}