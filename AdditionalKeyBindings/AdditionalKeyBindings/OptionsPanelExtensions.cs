using ColossalFramework.UI;

namespace AdditionalKeyBindings
{
	public static class OptionsPanelExtensions
	{
		public static UIScrollablePanel GetGameInputContainer(this OptionsPanel panel)
		{
			return (UIScrollablePanel)ReflectionUtils.GetPrivateFieldValue(panel, "m_GameInputContainer");
		}

		public static void OnBindingKeyDown(this OptionsPanel panel, UIComponent sender, UIKeyEventParameter e)
		{
			ReflectionUtils.InvokePrivateMethod(panel, "OnBindingKeyDown", sender, e);
		}

		public static void OnBindingMouseDown(this OptionsPanel panel, UIComponent sender, UIMouseEventParameter e)
		{
			ReflectionUtils.InvokePrivateMethod(panel, "OnBindingMouseDown", sender, e);
		}
	}
}