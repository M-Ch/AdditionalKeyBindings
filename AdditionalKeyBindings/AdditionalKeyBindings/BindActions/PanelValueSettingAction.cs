using System;

namespace AdditionalKeyBindings.BindActions
{
	public abstract class PanelValueSettingAction<TEnum> : IExecutableAction where TEnum : struct
	{
		protected readonly TEnum Value;
		private readonly ToolStripWrapper<TEnum> _toolStrip;

		protected PanelValueSettingAction(String panelName, TEnum value)
		{
			Value = value;
			_toolStrip = new ToolStripWrapper<TEnum>(panelName);
		}

		public void Execute()
		{
			_toolStrip.Value = Value;
		}
	}
}