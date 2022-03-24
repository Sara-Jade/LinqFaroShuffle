namespace LinqFaroShuffle
{
    public static class Extensions
    {
        public static bool AreSequencesEqual<T>(this IEnumerable<T> firstSequence, IEnumerable<T> secondSequence)
        {
            // Check parameters

            if (firstSequence.Count() != secondSequence.Count()) return false;

            var firstIter = firstSequence.GetEnumerator();
            var secondIter = secondSequence.GetEnumerator();
            int iterationCounter = 0;
                                                                    // Make sure we're not in an infinite loop
            while (firstIter.MoveNext() && secondIter.MoveNext() && iterationCounter < firstSequence.Count() * 10)
            {
                if (firstIter.Current != null && secondIter.Current != null & !firstIter.Current.Equals(secondIter.Current))
                {
                    return false;
                }
            }

            return iterationCounter < firstSequence.Count() * 10;
        }

        public static IEnumerable<T> InterleaveCards<T>(this IEnumerable<T> firstHalf, IEnumerable<T> secondHalf)
        {
            // Check parameters

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
