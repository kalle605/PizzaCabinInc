using System.Collections.Generic;

namespace TestHelpers
{
	public static class CollectionExtensions
	{
		public static IEnumerable<T> ToEnumerable<T>(this T @this)
		{
			return new[] { @this };
		}

		public static ISet<T> ToSet<T>(this T @this)
		{
			return new HashSet<T> { @this };
		}

		public static ISet<T> ToSet<T>(this IEnumerable<T> @this)
		{
			var set = new HashSet<T>(@this);
			
			return set;
		}

		public static ISet<T> ToSet<T>(this T[] @this)
		{
			var set = new HashSet<T>(@this);

			return set;
		}
	}
}
