using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AdditionalKeyBindings.BindActions;
using ColossalFramework;
using ColossalFramework.UI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AdditionalKeyBindings
{
	public class KeyBindingMenu
	{
		private readonly OptionsKeymappingPanel _optionsPanel;

		private static readonly Dictionary<ActionCategory, string> CategoryToFieldName = new Dictionary<ActionCategory, string>
		{
			{ ActionCategory.Shared, "m_SharedInputContainer" },
			{ ActionCategory.Game, "m_GameInputContainer" },
			{ ActionCategory.MapEditor, "m_MapEditorInputContainer" },
			{ ActionCategory.AssetsEditor, "m_DecorationInputContainer" },
		};

		private static readonly Dictionary<ActionCategory, string> CategoryToGroupName = new Dictionary<ActionCategory, string>
		{
			{ ActionCategory.Shared, String.Empty },
			{ ActionCategory.Game, "Game" },
			{ ActionCategory.MapEditor, "MapEditor" },
			{ ActionCategory.AssetsEditor, "Decoration" },
		};

		public KeyBindingMenu([NotNull] OptionsKeymappingPanel optionsPanel)
		{
			_optionsPanel = optionsPanel;
		}

		public IEnumerable<KeyBindingDescription> GetCurrentCategoryContent(ActionCategory key)
		{
			var panel = GetPanelForCategory(key);
			DebugUtil.CheckNotNull(panel, $"Panel for key {key} is null");
            return panel.components.Select(ItemToDescription);
		}

		private UIScrollablePanel GetPanelForCategory(ActionCategory key)
		{
			var fieldName = CategoryToFieldName[key];
			return ReflectionUtils.GetPrivateFieldValue<UIScrollablePanel>(_optionsPanel, fieldName);
		}

		public void AddCommand(IActionDescription action)
		{
			var panel = GetPanelForCategory(action.Category);
			var item = panel.AttachUIComponent(UITemplateManager.GetAsGameObject("KeyBindingTemplate"));
			FillItemFromDescription(item, action);
		}

		private void FillItemFromDescription(UIComponent item, IActionDescription description)
		{
			var nameLabel = item.Find<UILabel>("Name");
			var bindingLabel = item.Find<UITextComponent>("Binding");
			var input = new SavedInputKey(description.Command, Settings.gameSettingsFile, (int)KeyCode.None, true);

			bindingLabel.eventKeyDown += OnBindingKeyDown;
			bindingLabel.eventMouseDown += OnBindingMouseDown;

			nameLabel.text = description.DisplayName;
			bindingLabel.text = input.ToLocalizedString("KEYNAME");
			bindingLabel.objectUserData = input;
			bindingLabel.stringUserData = CategoryToGroupName[description.Category];
		}

		private void OnBindingMouseDown(UIComponent component, UIMouseEventParameter eventparam)
		{
			typeof (OptionsKeymappingPanel).GetMethod("OnBindingMouseDown", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(_optionsPanel, new object[] { component, eventparam });
		}

		private void OnBindingKeyDown(UIComponent component, UIKeyEventParameter eventparam)
		{
			typeof (OptionsKeymappingPanel).GetMethod("OnBindingKeyDown", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(_optionsPanel, new object[] { component, eventparam });
		}

		private static KeyBindingDescription ItemToDescription(UIComponent listItem)
		{
			var nameLabel = listItem.Find<UILabel>("Name");
			var bindingLabel = listItem.Find<UITextComponent>("Binding");
			var keyData = (SavedInputKey)bindingLabel.objectUserData;

			return new KeyBindingDescription
			{
				CommandName = keyData.name,
				DisplayName = nameLabel.text
			};
		}
	}
}