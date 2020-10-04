using System;
namespace DataStructures.List
{
    public class ArrayList<T> : List<T> 
    {
        const int DEFAULT_INITIAL_SIZE = 8;
        T[] _backingArray;
        int _size;
        int _length;
        object _lock = new object();

        //a constructor for creating an empty list;
        public ArrayList() : this(DEFAULT_INITIAL_SIZE)
        {
        }
        //a constructor for creating an empty list;
        public ArrayList(int initialSize)
        {
            initialSize =
                initialSize < DEFAULT_INITIAL_SIZE ?
                    DEFAULT_INITIAL_SIZE :
                    initialSize;

            _size = initialSize;
            _length = 0;
            _backingArray = new T[_size];
        }

        public T Add(T item)
        {
            lock(_lock) {
                PrepareForAdd();
                _backingArray[_length++] = item;
            }

            return item;
        }

        private void PrepareForAdd()
        {
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
        }

        public T AddFirst(T item)
        {
            // This is  Ω(1), for empty array, but O(n) otherwise
            // I was contemplating having a shifting start and end
            // index similar to a circular buffer, but grows like an
            // array list.  But deletes in the middle will still be O(n)
            // deletes from the beginning or end would be constant time.

            // For now, I'll do the naive approach
            lock(_lock)
            {
                PrepareForAdd();
                for(int i = _length; i > 0; i--)
                {
                    _backingArray[i] = _backingArray[i - 1];
                }

                _backingArray[0] = item;
                _length++;
            }
            return item;
        }

        public T Get(int index)
        {
            return _backingArray[index];
        }

        public T Head()
        {
            return _backingArray[0];
        }

        public int IndexOf(T item)
        {
            // O(n) is what I can do
            int i = 0;
            while (i < _length)
            {
                if (item.Equals(_backingArray[i])) return i;
                i++;
            }
            return -1;
        }

        public bool IsEmpty()
        {
            return _length == 0;
        }

        public T RemoveAt(int index)
        {
            if (index >= _length || index < 0) { throw new IndexOutOfRangeException(); }

            lock (_lock)
            { 
                // This is going to be O(n)
                T item = _backingArray[index];

                int i = index + 1;
                while (i < _length)
                {
                    _backingArray[i - 1] = _backingArray[i];
                    i++;
                }
                _length--;
                return item;
            }
        }

        public T Remove(T item)
        {
            int index = IndexOf(item);
            return RemoveAt(index);
        }

        public List<T> Tail()
        {
            if (_length < 2) return new ArrayList<T>();
            int initialSize = FindGoodInitialSize(_length);
            List<T> tail = new ArrayList<T>(initialSize);
            for (int i = 1; i < _length; i++)
            {
                tail.Add(_backingArray[i]);
            }
            return tail;
        }

        private int FindGoodInitialSize(int size)
        {
            // TODO: I'd like to find the smallest power of 2 that is
            // larger than length in a better way.
            // That's going to be an interesting problem
            // to solve. but for now, I'll do a naive solution
            int n = 2;

            while (n < size) n *= 2;

            return n;

        }

        public int Length()
        {
            return _length;
        }
    }
}
