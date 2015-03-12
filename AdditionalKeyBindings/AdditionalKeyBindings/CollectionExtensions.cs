using System.Collections.Generic;

namespace AdditionalKeyBindings
{
	internal static class CollectionExtensions
	{
		public static HashSet<T> ToHashSet<T>(this IEnumerable<T> values)
		{
			return new HashSet<T>(values);
		}
	}
}