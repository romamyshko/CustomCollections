using System;

namespace CustomCollections
{
    public class Enumerator<T> where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        int nIndex;
        Collection<T> collection;
        public Enumerator(Collection<T> coll)
        {
            collection = coll;
            nIndex = -1;
        }

        public bool MoveNext()
        {
            nIndex++;
            return (nIndex < collection.Count);
        }

        public T Current => collection[nIndex];
    }
}