using System;
namespace DataStructures
{
    /// <summary>
    /// List interface
    /// </summary>
    /// <typeparam name="T">Type of objects held within list</typeparam>
    public interface List<T>
    {

        /// <summary>
        /// reports whether list is empty
        /// </summary>
        /// <returns>true if List contains no items, false otherwise</returns>
        bool IsEmpty();

        /// <summary>
        /// Prepends an item onto the list
        /// </summary>
        /// <param name="item">Item to prepend</param>
        /// <returns>Item that was successfully prepended.</returns>
        T AddFirst(T item);

        /// <summary>
        /// Adds an item to the end of a list
        /// </summary>
        /// <param name="item">Item to add</param>
        /// <returns>The item that was successfully added</returns>
        T Add(T item);

        /// <summary>
        /// returns the first object in the list
        /// </summary>
        /// <returns>The first item in list</returns>
        T Head();

        /// <summary>
        /// obtain the length of list
        /// </summary>
        /// <returns>number of items in the list</returns>
        int Length();

        /// <summary>
        /// Returns the tail of the list
        /// </summary>
        /// <returns>The items after the first item in the list</returns>
        List<T> Tail();

        /// <summary>
        /// Get Item at specified index
        /// </summary>
        /// <param name="index">the index to return item</param>
        /// <returns>item at the specified index</returns>
        T Get(int index);

        /// <summary>
        /// Get index of the item
        /// </summary>
        /// <param name="item">Item to return index</param>
        /// <returns>index of the item, if it is in the list.
        /// If item is not in the list, returns -1
        /// </returns>
        int IndexOf(T item);

        /// <summary>
        /// Removes item at specified index
        /// </summary>
        /// <param name="index">index of item to remove</param>
        /// <returns>item which was removed</returns>
        T RemoveAt(int index);

        /// <summary>
        /// Remove item from list
        /// </summary>
        /// <param name="item">item to remove</param>
        /// <returns>Item, if it was successfully removed</returns>
        T Remove(T item);
    }
}
