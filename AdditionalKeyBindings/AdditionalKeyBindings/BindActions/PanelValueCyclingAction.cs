using System;

namespace AdditionalKeyBindings.BindActions
{
	public abstract class PanelValueCyclingAction<TEnum> : IExecutableAction where TEnum : struct
	{
		private readonly ToolStripWrapper _toolStrip;

		protected PanelValueCyclingAction(String panelName)
		{
			_toolStrip = new ToolStripWrapper<TEnum>(panelName);
		}

		public void Execute()
		{
			var modeCount = Enum.GetValues(typeof(TEnum)).Length;
			_toolStrip.Index = _toolStrip.Index.CycleIncrement(0, modeCount - 1);
		}
	}
}