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
    }
}