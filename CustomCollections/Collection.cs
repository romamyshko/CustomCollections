using System;

namespace CustomCollections
{
    public class Collection<T>
    {
        private T[] _array;
        private int _lastElemIndex;
        private int _lenght;

        public Collection()
        {
            _lastElemIndex = 0;
            _lenght = 4;
            _array = new T[_lenght];
        }

        private T this [int element]
        {
            get { return _array[element]; }
            set { _array[element] = value;  }
        }


        private void Resize()
        {
            Array.Resize(ref _array, _lenght *= 2);
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
