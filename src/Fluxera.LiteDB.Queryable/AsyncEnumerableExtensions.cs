namespace Fluxera.LiteDB.Queryable
{
	using System.Collections.Generic;
	using System.Linq;

	internal static class AsyncEnumerableExtensions
	{
		public static IAsyncEnumerable<TSource> ToAsyncEnumerable<TSource>(this IEnumerable<TSource> source)
		{
			return AsyncEnumerable.ToAsyncEnumerable(source);
		}
	}
}
