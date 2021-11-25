using System;

namespace CustomCollections
{
    public class Collection<T>
    {
        private T[] _array;
        private int _nextIndex;
        private int _lenght;

        public Collection()
        {
            _nextIndex = 0;
            _lenght = 4;
            _array = new T[_lenght];
        }

        public int Count { get { return _nextIndex == 0 ? 0 : _nextIndex - 1; } }

        public T this [int element]
        {
            get { return _array[element]; }
            set { _array[element] = value;  }
        }

        public void Add(T item)
        {
            if (!IsNumericType(item))
                throw new ArgumentException($"Type '{item.GetType()}' is not a numerical type");
            if (_nextIndex.Equals(_lenght))
                Resize();

            _array[_nextIndex++] = item;
        }

        public void Add(T item, int index)
        {
            if (!IsNumericType(item))
                throw new ArgumentException($"Type '{item.GetType()}' is not a numerical type");
            if (_nextIndex.Equals(_lenght))
                Resize();
            if (index < 0 || index > _nextIndex - 1)
                throw new ArgumentOutOfRangeException(nameof(index));

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

        public bool Remove(T item)
        {
            if (!IsNumericType(item))
                throw new ArgumentException($"Type '{item.GetType()}' is not a numerical type");

            for (int i = 0; i < _nextIndex; i++)
            {
                if (_array[i].Equals(item))
                {
                    _array[i] = default(T);
                    MoveArrLeft(i);
                    return true;
                }
            }

            return false;
        }

        public void Remove(int index)
        {
            if (index < 0 || index > _nextIndex - 1)
                throw new ArgumentOutOfRangeException(nameof(index));

            MoveArrLeft(index);
        }

        private void MoveArrLeft(int index)
        {
            for (int i = index; i < _nextIndex; i++)
            {
                _array[i] = _array[i + 1];
            }

            _array[_nextIndex--] = default(T);
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
    }
}
