using System.Collections.Generic;
using System.Linq;
using AdditionalKeyBindings.BindActions;

namespace AdditionalKeyBindings
{
	public class KeyBindingMenuInitializer
	{
		public void AddKeyBindings([NotNull]OptionsPanel optionsPanel, IEnumerable<IActionDescription> actions)
		{
			var keyBindingMenu = new KeyBindingMenu(optionsPanel);

			var byCategory = actions.GroupBy(i => i.Category);
			foreach (var category in byCategory)
				AddActionsToCategory(keyBindingMenu, category.Key, category);
		}

		private void AddActionsToCategory(KeyBindingMenu keyBindingMenu, ActionCategory category, IEnumerable<IActionDescription> actions)
		{
			var values = keyBindingMenu.GetCurrentCategoryContent(category).ToList();
			DebugUtil.WriteList(values, i => i.CommandName);

			var actualValues = values.Select(i => i.CommandName).Distinct().ToHashSet();
			foreach (var action in actions.Where(i => !actualValues.Contains(i.Command)))
				keyBindingMenu.AddCommand(action);
		}
	}
}