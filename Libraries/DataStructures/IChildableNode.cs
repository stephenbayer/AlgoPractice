using System;
namespace DataStructures
{
    public interface IChildableNode<T> : INode<T>
    {
        /// <summary>
        /// Sets new child for node
        /// </summary>
        /// <param name="child">New child node</param>
        void SetChild(INode<T> child);
    }
}
