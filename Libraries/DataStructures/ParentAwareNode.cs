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

        public ParentAwareNode(T value) : this(value, null)
        {
            
        }


        public ParentAwareNode(T value, Node<T> child) : this(value, child, null)
        {

        }

        public ParentAwareNode(T value, Node<T> child, Node<T> parent) : base(value, child)
        {
            INode<T> childsParent = null;
            if (child != null && child is ParentAwareNode<T>)
            {
                childsParent = (child as ParentAwareNode<T>).Previous();
                (child as ParentAwareNode<T>).SetParent(this);
            }
            this._parent = parent;
            if (parent != null)
            {
                var parentsChild = parent.Next();
                parent.SetChild(this);
                if (child == null)
                {
                    SetChild(parentsChild);
                }
            } else
            {
                SetParent(childsParent);
            }
        }

        public INode<T> Previous()
        {
            return _parent;
        }

        public void SetParent(INode<T> parent)
        {
            _parent = parent as ParentAwareNode<T>;
        }
    }
}
