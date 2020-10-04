using System;
namespace DataStructures.List
{
    /// <summary>
    /// Implementation of a List Data Structure using arrays
    /// </summary>
    /// <typeparam name="T">Type of elements contained in list</typeparam>
    public class ArrayList<T> : List<T> 
    {
        const int DEFAULT_INITIAL_SIZE = 8;
        T[] _backingArray;
        int _size;
        int _length;
        object _lock = new object();

        /// <summary>
        /// Default constructor
        /// </summary>
        public ArrayList() : this(DEFAULT_INITIAL_SIZE)
        {
        }

        /// <summary>
        /// Constructor to set an initial size of backing array
        /// </summary>
        /// <param name="initialSize">Size to set for backing array</param>
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

        /// <summary>
        /// Adds an item to the end of a list
        /// </summary>
        /// <param name="item">Item to add</param>
        /// <returns>The item that was successfully added</returns>
        public T Add(T item)
        {
            lock(_lock) {
                PrepareForAdd();
                _backingArray[_length++] = item;
            }

            return item;
        }

        /// <summary>
        /// Trying to stay Dry, needed to increase the size of the array for
        /// both Add and AddFirst
        /// </summary>
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

        /// <summary>
        /// Prepends an item onto the list
        /// </summary>
        /// <param name="item">Item to prepend</param>
        /// <returns>Item that was successfully prepended.</returns>
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

        /// <summary>
        /// Get Item at specified index
        /// </summary>
        /// <param name="index">the index to return item</param>
        /// <returns>item at the specified index</returns>
        public T Get(int index)
        {
            return _backingArray[index];
        }

        /// <summary>
        /// returns the first object in the list
        /// </summary>
        /// <returns>The first item in list</returns>
        public T Head()
        {
            return _backingArray[0];
        }

        /// <summary>
        /// Get index of the item
        /// </summary>
        /// <param name="item">Item to return index</param>
        /// <returns>index of the item, if it is in the list.
        /// If item is not in the list, returns -1
        /// </returns>
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

        /// <summary>
        /// reports whether list is empty
        /// </summary>
        /// <returns>true if List contains no items, false otherwise</returns>
        public bool IsEmpty()
        {
            return _length == 0;
        }

        /// <summary>
        /// Removes item at specified index
        /// </summary>
        /// <param name="index">index of item to remove</param>
        /// <returns>item which was removed</returns>
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

        /// <summary>
        /// Remove item from list
        /// </summary>
        /// <param name="item">item to remove</param>
        /// <returns>Item, if it was successfully removed</returns>
        public T Remove(T item)
        {
            int index = IndexOf(item);
            return RemoveAt(index);
        }

        /// <summary>
        /// Returns the tail of the list
        /// </summary>
        /// <returns>The items after the first item in the list</returns>
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

        /// <summary>
        /// obtain the length of list
        /// </summary>
        /// <returns>number of items in the list</returns>
        public int Length()
        {
            return _length;
        }
    }
}
