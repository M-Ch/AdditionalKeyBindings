using ColossalFramework.UI;
using ICities;

namespace AdditionalKeyBindings
{
	public class ModEntryPoint : IUserMod
	{
		public static void SetupMainMenu()
		{
			var optionsPanel = UiUtil.GetUiElementLogged<OptionsKeymappingPanel>(GameUiParts.KeyMappingPanel);
			if (optionsPanel != null)
				Try.Execute(() => new KeyBindingMenuInitializer().AddKeyBindings(optionsPanel, new KeyBindingMod().ActionDescriptions));
		}

		public string Name => "Additional Key Bindings";
		public string Description => "Set key shortcuts for additional commands using options menu.";
	}

	public class LoadingPoint : ILoadingExtension
	{
		private readonly KeyBindingMod _mod = new KeyBindingMod();

		public void OnCreated(ILoading loading)
		{
		}

		public void OnReleased()
		{
		}

		public void OnLevelLoaded(LoadMode mode)
		{
			//it looks like OptionsPanel instance from main menu screen is different than one from game screen.
			ModEntryPoint.SetupMainMenu();
			_mod.Start();
		}

		public void OnLevelUnloading()
		{
			_mod.End();
		}
	}
}