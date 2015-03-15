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
	}
}