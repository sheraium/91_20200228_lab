using System;
using System.Collections.Generic;

namespace Lab
{
    public static class LinqExtensions
    {
        public static List<TSource> JoeyWhere<TSource>(this List<TSource> products, Func<TSource, bool> predicate)
        {
            var list = new List<TSource>();
            foreach (var product in products)
            {
                if (predicate(product))
                {
                    list.Add(product);
                }
            }

            return list;
        }

        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> urls, Func<TSource, TResult> selector)
        {
            foreach (var url in urls)
            {
                yield return selector(url);
            }
        }
    }
}