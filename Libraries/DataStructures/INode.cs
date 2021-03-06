﻿using System;
namespace DataStructures
{
    /// <summary>
    /// Inteface for a node
    /// </summary>
    /// <typeparam name="T">Type of the node value</typeparam>
    public interface INode<T>
    {
        /// <summary>
        /// Return value of node
        /// </summary>
        T Value { get; set; }

        /// <summary>
        /// Next child of node
        /// </summary>
        /// <returns>Next child of node</returns>
        INode<T> Next();

    }
}
