using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqFaroShuffle
{
    public static class Extensions
    {
        public static IEnumerable<T> InterleaveCards<T>(this IEnumerable<T> firstHalf, IEnumerable<T> secondHalf)
        {
            var firstIter = firstHalf.GetEnumerator();
            var secondIter = secondHalf.GetEnumerator();

            while (firstIter.MoveNext() && secondIter.MoveNext())
            {
                yield return firstIter.Current;
                yield return secondIter.Current;
            }
        }
    }
}
