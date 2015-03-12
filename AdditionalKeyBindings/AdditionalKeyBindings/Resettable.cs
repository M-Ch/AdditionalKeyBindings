using System;

namespace AdditionalKeyBindings
{
	public class Resettable<T> where T : class
	{
		private readonly Func<T> _factory;
		private readonly Action<T> _disposingAction;
		private T _instance;

		public Resettable(Func<T> factory, [CanBeNull] Action<T> disposingAction)
		{
			_factory = factory;
			_disposingAction = disposingAction ?? (i => { });
		}

		public T Value
		{
			get { return _instance ?? (_instance = _factory()); }
		}

		public void Reset()
		{
			if (_instance == null)
				return;

			var instance = _instance;
			_instance = null;
			_disposingAction(instance);
		}

		public static implicit operator T(Resettable<T> resettable)
		{
			return resettable.Value;
		}
	}
}