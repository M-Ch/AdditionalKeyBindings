using System;
using ColossalFramework.UI;
using UnityEngine;

namespace AdditionalKeyBindings
{
	internal static class UiUtil
	{
		[CanBeNull]
		public static T GetUiElementLogged<T>(String name) where T : MonoBehaviour
		{
			var element = UIView.library.Get<T>(name);
			DebugUtil.CheckReference(name, element);
			return element;
		}
	}
}