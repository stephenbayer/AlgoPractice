using System;
using DataStructures;

namespace DataStructures
{
    public class DoublyLinkedList<T> : List<T>
    {
        ParentAwareNode<T> _head = null;
        ParentAwareNode<T> _last = null;
        int _length = 0;
        object _lock = new object();

        /// <summary>
        /// Default constructor
        /// </summary>
        public DoublyLinkedList()
        {
        }

        /// <summary>
        /// setting head and length
        /// </summary>
        public DoublyLinkedList(ParentAwareNode<T> head, ParentAwareNode<T> last, int length)
        {
            _head = head;
            _last = last;
            _length = length;
        }


        /// <summary>
        /// Adds an item to the end of a list
        /// </summary>
        /// <param name="item">Item to add</param>
        /// <returns>The item that was successfully added</returns>
        public T Add(T item)
        {
            lock (_lock)
            {
                ParentAwareNode<T> newNode = new ParentAwareNode<T>(item, null, null);

                if (_head == null)
                {
                    _head = _last = newNode;
                }
                else
                {
                    _last.SetChild(newNode);
                    newNode.SetParent(_last);
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
                ParentAwareNode<T> newNode = new ParentAwareNode<T>(item, null, null);

                if (_head == null)
                {
                    _head = _last = newNode;
                }
                else
                {
                    newNode.SetChild(_head);
                    _head.SetParent(newNode);
                    _head = newNode;
                }
                _length++;
            }

            return item;
        }

        public int GetMidPointIndex()
        {
            return _length / 2;
        }

        /// <summary>
        /// Get Item at specified index
        /// </summary>
        /// <param name="index">the index to return item</param>
        /// <returns>item at the specified index</returns>
        public T Get(int index)
        {
            if (index > _length - 1) throw new IndexOutOfRangeException();

            ParentAwareNode<T> node = _head;

            int i = 0;
            int midpoint = GetMidPointIndex();

            if (index > midpoint)
            {
                node = _last;
                // find starting at end
                i = _length - 1;
                while (i > index)
                {
                    node = node.Previous() as ParentAwareNode<T>;
                    i--;
                }
            } else
            {
                while (i < index)
                {
                    node = node.Next() as ParentAwareNode<T>;
                    i++;
                }

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
            INode<T> currentNode = _head;
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

            lock (_lock)
            {
                int i = 0;
                ParentAwareNode<T> currentNode;
                int midpoint = GetMidPointIndex();
                if (index > midpoint)
                {
                    currentNode = _last;
                    i = _length - 1;
                    while (i > index)
                    {
                        currentNode = currentNode.Previous() as ParentAwareNode<T>;
                        i--;
                    }
                }
                else
                {
                    currentNode = _head;
                    while (i < index)
                    {
                        currentNode = currentNode.Next() as ParentAwareNode<T>;
                        i++;
                    }
                }
                item = currentNode.Value;

                DeleteNode(currentNode);
            }
            return item;

        }

        private void DeleteNode(ParentAwareNode<T> node)
        {

            if (node.Previous() == null)
            {
                _head = node;
            }
            else
            {
                node.Previous().SetChild(node.Next());
            }

            if (node.Next() == null)
            {
                _last = node;
            }
            else
            {
                (node.Next() as ParentAwareNode<T>).SetParent(node.Previous());
            }
            _length--;
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
                ParentAwareNode<T> currentNode = _head;

                while (currentNode != null && (!item.Equals(currentNode.Value)))
                {
                    currentNode = currentNode.Next() as ParentAwareNode<T>;
                }

                if (currentNode == null) throw new IndexOutOfRangeException();

                item = currentNode.Value;
                DeleteNode(currentNode);
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
