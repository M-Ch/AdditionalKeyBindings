using AdditionalKeyBindings.BindActions;

namespace AdditionalKeyBindings
{
	internal class ExecutableActionWithDescription : IActionDescription, IExecutableAction
	{
		private readonly IActionDescription _description;
		private readonly IExecutableAction _action;

		private ExecutableActionWithDescription(IActionDescription description, IExecutableAction action)
		{
			_description = description;
			_action = action;
		}

		public static ExecutableActionWithDescription Create<T>(T action)
			where T : IActionDescription, IExecutableAction
		{
			return new ExecutableActionWithDescription(action, action);
		}

		public ActionCategory Category { get { return _description.Category; } }
		public string DisplayName { get { return _description.DisplayName; } }
		public string Command { get { return _description.Command; } }

		public void Execute()
		{
			_action.Execute();
		}
	}
}