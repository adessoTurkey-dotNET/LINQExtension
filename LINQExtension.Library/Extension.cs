using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExtension.Library
{
    public static class Extension
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            if (list == null)
                throw new ArgumentNullException("source");

            if (predicate == null)
                throw new ArgumentNullException("predicate");

            foreach (T item in list)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static T WhereFirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");
            
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default(T);
        }

        public static T WhereLastOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");
            foreach (T item in source.Reverse())
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default(T);
        }

        public static IEnumerable<T> LazyReverse<T>(this IList<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            for (var i = source.Count - 1; i >= 0; i--)
                yield return source[i];
        }

        public static IEnumerable<T> Take<T>(this IEnumerable<T> source, int number)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int index = 1;
            foreach (T item in source)
            {
                if (index > number) break; ++index;
                yield return item;
            }
        }

        public static IEnumerable<T> Skip<T>(this IEnumerable<T> source, int number)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int index = 0;
            foreach (T item in source)
            {
                if (index < number)
                {
                    ++index;
                    continue;
                }

                yield return item;
            }
        }

        public static T Max<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            dynamic maxValue = typeof(T).GetField("MinValue").GetValue(null);
            foreach (T item in source)
            {
                if (item > maxValue)
                {
                    maxValue = item;
                }
            }
            return maxValue;
        }

        public static T Min<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            dynamic minValue = typeof(T).GetField("MaxValue").GetValue(null);
            foreach (T item in source)
            {
                if (item < minValue)
                {
                    minValue = item;
                }
            }
            return minValue;
        }

        public static T SUM<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            dynamic sum = default(T);
            foreach (T item in source)
            {
                sum += item;
            }
            return sum;
        }

        public static int Count<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int i = 0;
            foreach (T item in source)
            {
                ++i;
            }
            return i;
        }

        public static int Count<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            int i = 0;
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    ++i;
                }
            }
            return i;
        }

        public static int IndexOf<T>(this IEnumerable<T> source, T value)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int i = 0;
            foreach (T item in source)
            {
                if (EqualityComparer<T>.Default.Equals(item, value))
                {
                    return i;
                }
                ++i;
            }
            return -1;
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, IEnumerable<T> second)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (second == null)
                throw new ArgumentNullException("second");

            List<T> newList = new List<T>();
            newList.AddRange(source);
            newList.AddRange(second);
            return newList;
        }

        public static IEnumerable<T> Union<T>(this IEnumerable<T> source, IEnumerable<T> second)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (second == null)
                throw new ArgumentNullException("second");

            List<T> newList = new List<T>();
            foreach (T item in source)
            {
                if (!newList.Contains(item))
                {
                    newList.Add(item);
                }
            }
            foreach (T item in second)
            {
                if (!newList.Contains(item))
                {
                    newList.Add(item);
                }
            }
            return newList;
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, IEnumerable<T> second)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (second == null)
                throw new ArgumentNullException("second");

            List<T> list = new List<T>();
            foreach (T item in source)
            {
                if (!second.Contains(item) && !list.Contains(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public static double Average<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int count = 0;
            dynamic sum = 0;
            foreach (T item in source)
            {
                sum += item;
                count++;
            }
            return sum / count;
        }

        public static IEnumerable<T> Intersect<T>(this IEnumerable<T> source, IEnumerable<T> second)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (second == null)
                throw new ArgumentNullException("second");

            List<T> list = new List<T>();
            foreach (T item in source)
            {
                if (second.Contains(item) && !list.Contains(item))
                {
                    list.Add((T)item);
                }
            }
            return list;
        }

        public static T First<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
           
            foreach (T item in source)
            {
                return item;
            }
            return default(T);
        }

        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> property)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.GroupBy(property).Select(x => x.First());
        }

        public static string JoinStrings(this IEnumerable<string> source, string separator)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return string.Join(separator, source);
        }
    }


}
