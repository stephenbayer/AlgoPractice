using System;
using DataStructures;
using Xunit;

namespace Algorithms.Tests
{
    public class MergeSortTests
    {
        [Fact]
        public void CanSortIntegers()
        {
            int[] inputArray = new[] { 9, 6, 4, 2, 1 };

            ISort<int> cut = new MergeSort<int>();

            int[] actual = cut.Sort(inputArray);

            Assert.Equal(1, actual[0]);
            Assert.Equal(2, actual[1]);
            Assert.Equal(4, actual[2]);
            Assert.Equal(6, actual[3]);
            Assert.Equal(9, actual[4]);
        }

        [Fact]
        public void CanSortSortedIntegers()
        {
            int[] inputArray = new[] { 1, 2, 4, 6, 9 };

            ISort<int> cut = new MergeSort<int>();

            int[] actual = cut.Sort(inputArray);

            Assert.Equal(1, actual[0]);
            Assert.Equal(2, actual[1]);
            Assert.Equal(4, actual[2]);
            Assert.Equal(6, actual[3]);
            Assert.Equal(9, actual[4]);
        }


        [Fact]
        public void CanSortReverseSortedIntegers()
        {
            int[] inputArray = new[] { 9, 6, 4, 2, 1 };

            ISort<int> cut = new MergeSort<int>();

            int[] actual = cut.Sort(inputArray);

            Assert.Equal(1, actual[0]);
            Assert.Equal(2, actual[1]);
            Assert.Equal(4, actual[2]);
            Assert.Equal(6, actual[3]);
            Assert.Equal(9, actual[4]);
        }

        [Fact]
        public void CanSortArrayWithNegativeNumbers()
        {
            int[] inputArray = new[] { 1, 2, -10, 4, 6, 9 };

            ISort<int> cut = new MergeSort<int>();

            int[] actual = cut.Sort(inputArray);

            Assert.Equal(-10, actual[0]);
            Assert.Equal(1, actual[1]);
            Assert.Equal(2, actual[2]);
            Assert.Equal(4, actual[3]);
            Assert.Equal(6, actual[4]);
            Assert.Equal(9, actual[5]);
        }

        [Fact]
        public void CanSortStrings()
        {
            string[] inputArray = new[] { "ice", "fun", "dog", "bed", "apple" };

            ISort<string> cut = new MergeSort<string>();

            string[] actual = cut.Sort(inputArray);

            Assert.Equal("apple", actual[0]);
            Assert.Equal("bed", actual[1]);
            Assert.Equal("dog", actual[2]);
            Assert.Equal("fun", actual[3]);
            Assert.Equal("ice", actual[4]);
        }
    }
}
