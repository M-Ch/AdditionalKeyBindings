using System;
using UnityEngine;

namespace AdditionalKeyBindings
{
	internal static class UiUtil
	{
		[CanBeNull]
		public static T GetUiElementLogged<T>(String name) where T : MonoBehaviour
		{
			return GameObject.Find(name).GetComponent<T>();
		}
	}
}