using System;
using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> JoeyWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current))
                {
                    yield return current;
                }
            }
        }

        public static IEnumerable<T> JoeyWhere<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current, index))
                {
                    yield return current;
                }

                index++;
            }
        }

        public static IEnumerable<string> JoeySelect(this IEnumerable<string> source, Func<string, int, string> selector)
        {
            var enumerator = source.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                yield return selector(current, index);
                index++;
            }
        }

        public static IEnumerable<string> JoeySelect(this IEnumerable<string> source, Func<string, string> selector)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                yield return selector(current);
            }
        }

        public static IEnumerable<string> JoeySelect(this IEnumerable<Employee> source, Func<Employee, string> selector)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                yield return selector(current);
            }
        }
    }
}