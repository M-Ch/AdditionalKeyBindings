namespace AdditionalKeyBindings
{
	public class ActionDescription
	{
		public ActionDescription(ActionCategory category)
		{
			Category = category;
		}

		public ActionCategory Category { get; private set; }
	}
}