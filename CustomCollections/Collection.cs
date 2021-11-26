using System;

namespace CustomCollections
{
    public class Collection<T> where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        private T[] _array;
        private int _nextIndex;
        private int _lenght;

        public Collection()
        {
            _nextIndex = 0;
            _lenght = 4;
            _array = new T[_lenght];

            if (!IsNumericType(_array[0]))
                throw new TypeAccessException($"Type '{_array[0].GetType()}' is not a numerical type");
        }

        public int Count => _nextIndex;
        public T GetLast => _array[_nextIndex - 1];

        public T this [int index]
        {
            get
            {
                CheckIndexerIndex(index);
                return _array[index]; 
            }
            set 
            {
                CheckIndexerIndex(index);
                _array[index] = value; 
            }
        }

        public void Add(T item)
        {
            if (_nextIndex.Equals(_lenght))
                Resize();

            _array[_nextIndex++] = item;
        }

        public void Add(T item, int index)
        {
            if (_nextIndex.Equals(_lenght))
                Resize();

            CheckEnteredIndex(index);

            MoveArrRight(index);
            _array[index] = item;
        }

        private void MoveArrRight(int index)
        {
            for (int i = ++_nextIndex; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }
        }

        private void Resize()
        {
            Array.Resize(ref _array, _lenght *= 2);
        }

        public bool RemoveFirst(T item)
        {
            for (int i = 0; i < _nextIndex; i++)
            {
                if (_array[i].Equals(item))
                {
                    MoveArrLeft(i);
                    return true;
                }
            }

            return false;
        }

        public void Remove(int index)
        {
            CheckEnteredIndex(index);
            MoveArrLeft(index);
        }

        private void MoveArrLeft(int index)
        {
            for (int i = index; i < _nextIndex - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            _array[--_nextIndex] = default(T);
        }

        private bool IsNumericType(T item)
        {
            switch (Type.GetTypeCode(item.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        private void CheckIndexerIndex(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), index, "Indexer's index is less than zero");
            else if (index > _nextIndex - 1)
                throw new ArgumentOutOfRangeException(nameof(index), index, "Indexer's index exceeds number of elements");
        }

        private void CheckEnteredIndex(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), index, "Index is less than zero");
            else if (index > _nextIndex - 1)
                throw new ArgumentOutOfRangeException(nameof(index), index, "Index exceeds number of elements");
        }
     
        public Enumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }
    }
}