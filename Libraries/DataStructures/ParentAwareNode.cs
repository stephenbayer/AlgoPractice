using System;
namespace DataStructures
{
    /// <summary>
    /// An implementation of the node that knows about it's parent.
    /// </summary>
    /// <typeparam name="T">Type of data contained in node</typeparam>
    public class ParentAwareNode<T> : Node<T>
    {
        Node<T> _parent = null;

        public ParentAwareNode(T value, Node<T> child, Node<T> parent) : base(value, child)
        {
            this._parent = parent;
        }

        public Node<T> Previous()
        {
            return _parent;
        }

        public void SetParent(Node<T> parent)
        {
            _parent = parent;
        }
    }
}
