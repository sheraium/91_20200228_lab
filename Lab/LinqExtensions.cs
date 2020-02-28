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

        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> urls,
            Func<TSource, TResult> selector)
        {
            foreach (var url in urls)
            {
                yield return selector(url);
            }
        }

        public static List<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> numbers,
            Func<TSource, int, bool> predicate)
        {
            var result = new List<TSource>();
            var index = 0;
            foreach (var item in numbers)
            {
                if (predicate(item, index))
                {
                    result.Add(item);
                }

                index++;
            }

            return result;
        }

        public static IEnumerable<TSource> JoeySelectWithIndex<TSource>(this IEnumerable<TSource> urls, Func<TSource, int, TSource> selector)
        {
            var index = 0;
            foreach (var url in urls)
            {
                yield return selector(url, index);
                index++;
            }
        }
    }
}