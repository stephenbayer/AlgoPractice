using System;
using DataStructures.Common;

namespace DataStructures.List
{
    public class LinkedList<T> : List<T>
    {
        Node<T> _head = null;
        Node<T> _last = null;
        int _length = 0;
        object _lock = new object();

        /// <summary>
        /// Default constructor
        /// </summary>
        public LinkedList()
        {
        }

        /// <summary>
        /// setting head and length
        /// </summary>
        public LinkedList(Node<T> head, int length)
        {
            _head = head;
            _length = length;
        }


        /// <summary>
        /// Adds an item to the end of a lit
        /// </summary>
        /// <param name="item">Item to add</param>
        /// <returns>The item that was successfully added</returns>
        public T Add(T item)
        {
            lock(_lock)
            {
                Node<T> newNode = new Node<T>(item);

                if (_head == null)
                {
                    _head = _last = newNode;
                } else
                {
                    _last.SetChild(newNode);
                    _last = newNode;
                }
                _length++;
            }

            return item;
        }

        /// <summary>
        /// Prepends an item onto the list
        /// </summary>
        /// <param name="item">Item to prepend</param>
        /// <returns>Item that was successfully prepended.</returns>
        public T AddFirst(T item)
        {

            lock (_lock)
            {
                Node<T> newNode = new Node<T>(item);

                if (_head == null)
                {
                    _head = _last = newNode;
                }
                else
                {
                    newNode.SetChild(_head);
                    _head = newNode;
                }
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
            if (index > _length - 1) throw new IndexOutOfRangeException();

            Node<T> node = _head;

            int i = 0;

            while (i < index)
            {
                node = node.Next();
                i++;
            }
            return node.Value;
        }

        /// <summary>
        /// returns the first object in the list
        /// </summary>
        /// <returns>The first item in list</returns>
        public T Head()
        {
            if (_head == null) throw new IndexOutOfRangeException();
            return _head.Value;
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
            if (_length == 0) return -1;

            int index = 0;
            Node<T> currentNode = _head;
            while (currentNode != null)
            {
                if (item.Equals(currentNode.Value)) return index;
                index++;
                currentNode = currentNode.Next();
                
            }
            return -1;
        }

        /// <summary>
        /// reports whether list is empty
        /// </summary>
        /// <returns>true if List contains no items, false otherwise</returns>
        public bool IsEmpty()
        {
            return _head == null;
        }

        /// <summary>
        /// obtain the length of list
        /// </summary>
        /// <returns>number of items in the list</returns>
        public int Length()
        {
            return _length;
        }

        /// <summary>
        /// Removes item at specified index
        /// </summary>
        /// <param name="index">index of item to remove</param>
        /// <returns>item which was removed</returns>
        public T RemoveAt(int index)
        {
            if (index > _length - 1) throw new IndexOutOfRangeException();

            T item;

            lock(_lock)
            {
                int i = 0;
                Node<T> previousNode = null;
                Node<T> currentNode = _head;
                while (i < index)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.Next();
                    i++;
                }
                item = currentNode.Value;
                if (previousNode == null)
                {
                    _head = currentNode.Next();
                } else
                {
                    previousNode.SetChild(currentNode.Next());
                }
                _length--;
            }
            return item;

        }

        /// <summary>
        /// Remove item from list
        /// </summary>
        /// <param name="item">item to remove</param>
        /// <returns>Item, if it was successfully removed</returns>
        public T Remove(T item)
        {
            lock (_lock)
            {
                int i = 0;
                Node<T> previousNode = null;
                Node<T> currentNode = _head;
                while (i < _length && !item.Equals(currentNode.Value))
                {
                    previousNode = currentNode;
                    currentNode = currentNode.Next();
                    i++;
                }
                if (i == _length) throw new IndexOutOfRangeException();

                item = currentNode.Value;
                if (previousNode == null)
                {
                    _head = currentNode.Next();
                }
                else
                {
                    previousNode.SetChild(currentNode.Next());
                }
                _length--;
            }
            return item;
        }

        /// <summary>
        /// Returns the tail of the list
        /// </summary>
        /// <returns>The items after the first item in the list</returns>
        public List<T> Tail()
        {
            if (_length < 2) return new LinkedList<T>();
            return new LinkedList<T>(_head.Next(), _length - 1);
        }
    }
}
