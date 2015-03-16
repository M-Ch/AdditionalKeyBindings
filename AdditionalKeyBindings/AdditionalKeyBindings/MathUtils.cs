using AdditionalKeyBindings.BindActions;

namespace AdditionalKeyBindings
{
	public static class MathUtils
	{
		public static int CycleIncrement(this int value, int min, int max)
		{
			var result = value + 1;
			if(result > max || result < min)
				return min;
			return result;
		}

		public static int CycleDecrement(this int value, int min, int max)
		{
			var result = value - 1;
			if(result < min || result > max)
				return max;
			return result;
		}

		public static int Cycle(int value, int min, int max, CycleDirection direction)
		{
			return direction == CycleDirection.Up ? CycleIncrement(value, min, max) : CycleDecrement(value, min, max);
		}

		public static int Clamp(int value, int min, int max)
		{
			if (value < min)
				return min;
			if (value > max)
				return max;
			return value;
		}
	}
}