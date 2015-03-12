using ICities;

namespace AdditionalKeyBindings
{
	public class ModEntryPoint : IUserMod
	{
		public ModEntryPoint()
		{
			//hack: It seems like the game is only creating one instance this class.
			//we can use this place to call a one time initialization code
			//it would be nice to have something like this in ICities API:
			//IUserMod.Enable() - called when mod is turned on or right after game start if it is already enabled
			//IUserMod.Disable() - called when mod is uninstalled/ turned off/ deleted

			SetupMainMenu();
			DebugUtil.WriteLine("AdditionalKeyBindings: initialized.");
		}

		public static void SetupMainMenu()
		{
			var optionsPanel = UiUtil.GetUiElementLogged<OptionsPanel>(GameUiParts.OptionsPanel);
			if (optionsPanel != null)
				Try.Execute(() => new KeyBindingMenuInitializer().AddKeyBindings(optionsPanel, new KeyBindingMod().ActionDescriptions));
		}

		public string Name
		{
			get { return "Additional Key Bindings"; }
		}

		public string Description 
		{
			get { return "Set key shortcuts for additional commands through game options menu."; }
		}
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