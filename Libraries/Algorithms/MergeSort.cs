using System;
using System.Linq;

namespace Algorithms
{
    /// <summary>
    /// Merge Sort takes input array and uses divide and conquer to
    /// break the array and half and reassemble in order. 
    /// </summary>
    /// <typeparam name="T">type of the elements to be sorted</typeparam>
    public class MergeSort<T> : ISort<T> where T: IComparable<T>
    {
        /// <summary>
        /// Sort the passed array using a Merge Sort
        /// </summary>
        /// <param name="inArr">Array to sort</param>
        /// <returns>Sorted Array, which is the passed in array</returns>
        public T[] Sort(T[] inArr)
        {
            Sort(inArr, 0, inArr.Length - 1);

            return inArr;
        }

        private void Merge(T[] inArr, T[] leftArray, T[] rightArray, int startIndex)
        {
            // merge the two halves using "2 finger" approach
            int leftIndex = 0;
            int rightIndex = 0;
            int arrIndex = startIndex;

            while (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
            {
                if (leftArray[leftIndex].CompareTo(rightArray[rightIndex]) <= 0)
                {
                    // left is smaller (or same) add left item to array 
                    inArr[arrIndex++] = leftArray[leftIndex++];
                }
                else
                {
                    // right is smaller, add right to array
                    inArr[arrIndex++] = rightArray[rightIndex++];
                }
            }

            // add the items remaining in left array
            while (leftIndex < leftArray.Length) inArr[arrIndex++] = leftArray[leftIndex++];
            // add teh items remaining in right array
            while (rightIndex < rightArray.Length) inArr[arrIndex++] = rightArray[rightIndex++];
        }

        /// <summary>
        /// Recursive method to cut the passed in section in half,
        /// sort those halves, and merge them back together sorted
        /// </summary>
        /// <param name="inArr">passed in array</param>
        /// <param name="startIndex">index of the array to start sort</param>
        /// <param name="endIndex">index of the array to end sort</param>
        private void Sort(T[] inArr, int startIndex, int endIndex)
        {
            int length = (endIndex - startIndex) + 1;
            // if array has 1 or 0 items, it's already sorted
            if (length <= 1) return;

            // cut in half and sort the halves
            int half = length / 2;

            int arr1start = startIndex;
            int arr1end = (startIndex + half) - 1;
            int arr1len = (arr1end - arr1start) + 1;
            int arr2start = startIndex + half;
            int arr2end = endIndex;
            int arr2len = (arr2end - arr2start) + 1;

            Sort(inArr, arr1start, arr1end);
            Sort(inArr, arr2start, arr2end);

            T[] arr1 = inArr.Skip(startIndex).Take(arr1len).ToArray();
            T[] arr2 = inArr.Skip(startIndex + arr1len).Take(arr2len).ToArray();

            Merge(inArr, arr1, arr2, startIndex);
        }
    }
}
