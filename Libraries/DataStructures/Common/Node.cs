using System;
namespace DataStructures.Common
{
    public class Node<T>
    {
        T _value;
        private Node<T> _child = null;

        public Node(T value)
        {
            _value = value;
        }

        public Node(T value, Node<T> child)
        {
            this._value = value;
            this._child = child;
        }

        public T Value {
            get { return _value; }
            set { _value = value; }
        }

        public Node<T> Next()
        {
            return _child;
        }

        public void SetChild(Node<T> child)
        {
            _child = child;
        }
    }
}
