using System.Collections.Generic;
using System.Linq;

namespace AdditionalKeyBindings
{
	public class KeyBindingMenuInitializer
	{
		public void Initialize([NotNull]OptionsPanel optionsPanel, IEnumerable<ActionDescription> actions)
		{
			var keyBindingMenu = new KeyBindingMenu(optionsPanel);

			var byCategory = actions.GroupBy(i => i.Category);
			foreach (var category in byCategory)
				AddActionsToCategory(keyBindingMenu, category.Key, category);
		}

		private void AddActionsToCategory(KeyBindingMenu keyBindingMenu, ActionCategory category, IEnumerable<ActionDescription> actions)
		{
			var values = keyBindingMenu.GetCurrentCategoryContent(category).ToList();
			DebugUtil.WriteList(values, i => i.CommandName);
		}
	}
}