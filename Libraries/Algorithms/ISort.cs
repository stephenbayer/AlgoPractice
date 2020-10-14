using System;
namespace Algorithms
{
    /// <summary>
    /// Sorting Algorithm Inteface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISort<T> where T: IComparable<T>
    {
        /// <summary>
        /// Sort Takes an array, and returns a sorted array.
        /// </summary>
        /// <param name="inArr">array to be sorted</param>
        /// <returns>sorted array, may be a pointer to the same array</returns>
        T[] Sort(T[] inArr);
    }
}
