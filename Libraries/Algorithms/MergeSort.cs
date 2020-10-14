using System;
using System.Linq;

namespace Algorithms
{
    public class MergeSort<T> : ISort<T> where T: IComparable<T>
    {

        public T[] Sort(T[] inArr)
        {
            Sort(inArr, 0, inArr.Length - 1);

            return inArr;
        }

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

            // merge the two halves using "2 finger" approach
            int index1 = 0;
            int index2 = 0;
            int arrIndex = startIndex;
            while (index1 < arr1.Length && index2 < arr2.Length)
            {
                if (arr1[index1].CompareTo(arr2[index2]) <= 0)
                {
                    inArr[arrIndex++] = arr1[index1++];
                } else
                {
                    inArr[arrIndex++] = arr2[index2++];
                }
            }

            while (index1 < arr1.Length)
            {
                inArr[arrIndex++] = arr1[index1++];
            }
            while (index2 < arr2.Length)
            {
                inArr[arrIndex++] = arr2[index2++];
            }

        }
    }
}
