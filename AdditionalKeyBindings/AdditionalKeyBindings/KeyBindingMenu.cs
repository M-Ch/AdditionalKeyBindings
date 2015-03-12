using System.Collections.Generic;
using System.Linq;
using ColossalFramework;
using ColossalFramework.UI;

namespace AdditionalKeyBindings
{
	public class KeyBindingMenu
	{
		private readonly OptionsPanel _optionsPanel;

		private static readonly Dictionary<ActionCategory, string> CategoryToFieldName = new Dictionary<ActionCategory, string>
		{
			{ ActionCategory.Shared, "m_SharedInputContainer" },
			{ ActionCategory.Game, "m_GameInputContainer" },
			{ ActionCategory.MapEditor, "m_MapEditorInputContainer" },
			{ ActionCategory.AssetsEditor, "m_DecorationInputContainer" },
		};

		public KeyBindingMenu([NotNull] OptionsPanel optionsPanel)
		{
			_optionsPanel = optionsPanel;
		}

		public IEnumerable<KeyBindingDescription> GetCurrentCategoryContent(ActionCategory key)
		{
			var panel = GetPanelForCategory(key);
			return panel.components.Select(ItemToDescription);
		}

		private static KeyBindingDescription ItemToDescription(UIComponent listItem)
		{
			var nameLabel = listItem.Find<UILabel>("Name");
			var bindingLabel = listItem.Find<UILabel>("Binding");
			var keyData = (SavedInputKey)bindingLabel.objectUserData;

			return new KeyBindingDescription
			{
				CommandName = keyData.name,
				DisplayName = nameLabel.text
			};
		}

		private UIScrollablePanel GetPanelForCategory(ActionCategory key)
		{
			var fieldName = CategoryToFieldName[key];
			return ReflectionUtils.GetPrivateFieldValue<UIScrollablePanel>(_optionsPanel, fieldName);
		}
	}
}