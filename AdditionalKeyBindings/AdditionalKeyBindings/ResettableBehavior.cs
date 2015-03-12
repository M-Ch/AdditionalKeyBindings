using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AdditionalKeyBindings
{
	public class ResettableBehavior<T> : Resettable<GameObject> where T : MonoBehaviour
	{
		public ResettableBehavior(String name) : base(() => new GameObject(name, typeof (T)), Object.Destroy)
		{
		}

		public T Behavior
		{
			get { return Value.GetComponent<T>(); }
		}
	}
}