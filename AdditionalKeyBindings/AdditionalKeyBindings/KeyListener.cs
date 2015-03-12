using System;
using UnityEngine;

namespace AdditionalKeyBindings
{
	public class KeyListener : MonoBehaviour
	{
		public event EventHandler<KeyEventArgs> KeyEvent;

		[UsedImplicitly]
		private void OnGUI()
		{
			var current = Event.current;
			if (!current.isKey)
				return;
			var handler = KeyEvent;
			if (handler != null)
				handler(this, new KeyEventArgs(current.type, current.keyCode, current.modifiers));
		}
	}

	public class KeyEventArgs : EventArgs
	{
		public EventType EventType { get; private set; }
		public KeyCode KeyCode { get; private set; }
		public EventModifiers Modifiers { get; private set; }

		public KeyEventArgs(EventType eventType, KeyCode keyCode, EventModifiers modifiers)
		{
			EventType = eventType;
			KeyCode = keyCode;
			Modifiers = modifiers;
		}
	}
}