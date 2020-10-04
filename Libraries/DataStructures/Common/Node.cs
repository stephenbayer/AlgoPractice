namespace DataStructures.Common
{
    /// <summary>
    /// An impleentation of a Node class
    /// </summary>
    /// <typeparam name="T">Type of the data contained in node class</typeparam>
    public class Node<T> : INode<T>
    {
        T _value;
        private INode<T> _child = null;

        /// <summary>
        /// Constructor with node value
        /// </summary>
        /// <param name="value">Value of the node</param>
        public Node(T value)
        {
            _value = value;
        }

        /// <summary>
        /// Constructor with node value and child
        /// </summary>
        /// <param name="value">Node value</param>
        /// <param name="child">Child</param>
        public Node(T value, INode<T> child)
        {
            this._value = value;
            this._child = child;
        }

        /// <summary>
        /// Return value of node
        /// </summary>
        public T Value {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        /// Next child of node
        /// </summary>
        /// <returns>Next child of node</returns>
        public INode<T> Next()
        {
            return _child;
        }

        /// <summary>
        /// Sets new child for node
        /// </summary>
        /// <param name="child">New child node</param>
        /// <remarks>
        ///   This and the value property makes the node class mutable,
        ///   which may not be good in every situation. The alternative would
        ///   be to generate a new Node when values or children change.
        /// </remarks>
        public void SetChild(INode<T> child)
        {
            _child = child;
        }
    }
}
