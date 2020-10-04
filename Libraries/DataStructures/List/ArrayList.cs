using System;
namespace DataStructures.List
{
    public class ArrayList<T> : List<T>
    {
        const int DEFAULT_INITIAL_SIZE = 8;
        T[] _backingArray;
        int _size;
        int _length;
        int _index;
        object _lock = new object();

        //a constructor for creating an empty list;
        public ArrayList()
        {
            _size = DEFAULT_INITIAL_SIZE;
            _length = 0;
            _backingArray = new T[_size];
        }

        public T Add(T item)
        {
            lock(_lock) {
                if (_length + 1 > _size)
                {
                    // double array
                    int newSize = _size * 2;
                    T[] newArray = new T[newSize];

                    int i = 0;
                    while (i < _size)
                    {
                        newArray[i] = _backingArray[i];
                        i++;
                    }
                    _backingArray = newArray;
                    _size = newSize;
                }
                _backingArray[_length++] = item;
            }

            return item;
        }

        public T AddFirst(T item)
        {
            throw new NotImplementedException();
        }

        public T Get(int index)
        {
            return _backingArray[index];
        }

        public T Head()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            return _length == 0;
        }

        public T Remove(int index)
        {
            throw new NotImplementedException();
        }

        public T Remove(T item)
        {
            throw new NotImplementedException();
        }

        public List<T> Tail()
        {
            throw new NotImplementedException();
        }
    }
}
