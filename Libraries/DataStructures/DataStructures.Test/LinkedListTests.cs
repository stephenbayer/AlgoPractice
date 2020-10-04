using System;
using Xunit;
using DataStructures;

namespace DataStructures.Test
{
    public class LinkedListTests
    {
        [Fact]
        public void LinkedListCanBeCreated()
        {
            List<int> cut = new LinkedList<int>();

            Assert.NotNull(cut);
        }

        [Fact]
        public void NewLinkedListCreatedEmpty()
        {
            List<int> cut = new LinkedList<int>();

            Assert.True(cut.IsEmpty());
        }


        [Fact]
        public void LinkedListWithItemIsNotEmpty()
        {
            List<int> cut = new LinkedList<int>();
            cut.Add(1);
            Assert.False(cut.IsEmpty());
        }

        [Fact]
        public void CanGetLengthOfLinkedList()
        {
            List<int> cut = new LinkedList<int>();

            for(int i = 0; i < 10; i++)
            {
                cut.Add(i);
            }
            Assert.Equal(10, cut.Length());
        }

        [Fact]
        public void CanAddAnItemToLinkedList()
        {

            List<int> cut = new LinkedList<int>();

            cut.Add(1);

            int actual = cut.Get(0);

            Assert.Equal(1, actual);
        }

        [Fact]
        public void CanAddMoreITemsToLinkedList()
        {
            List<int> cut = new LinkedList<int>();

            for(int i = 0; i < 4; i++)
            {
                cut.Add(i);
            }

            //[0, 1, 2, 3]
            Assert.Equal(4, cut.Length());
            Assert.Equal(0, cut.Get(0));
            Assert.Equal(1, cut.Get(1));
            Assert.Equal(2, cut.Get(2));
            Assert.Equal(3, cut.Get(3));
        }

        [Fact]
        public void CanPrependItemToList()
        {

            List<int> cut = new LinkedList<int>();
            cut.Add(1);
            cut.AddFirst(2);

            // [2, 1]
            Assert.Equal(2, cut.Length());
            Assert.Equal(2, cut.Get(0));
            Assert.Equal(1, cut.Get(1));
        }

        [Fact]
        public void CanAddFirstMoreItemsToLinkedList()
        {
            List<int> cut = new LinkedList<int>();
            for (int i = 1; i < 10; i++)
            {
                cut.AddFirst(i);
            }

            // last index should be the first in (1)
            Assert.Equal(1, cut.Get(8));
            // second to last index should be the second in (2)
            Assert.Equal(2, cut.Get(7));
            // first index should be the last in (9)
            Assert.Equal(9, cut.Get(0));
            // second index should be the second to last in (8)
            Assert.Equal(8, cut.Get(1));

        }

        [Fact]
        public void CanGetHeadOfLinkedList()
        {

            List<int> cut = new LinkedList<int>();
            for (int i = 1; i < 10; i++)
            {
                cut.Add(i);
            }
            Assert.Equal(1, cut.Head());
        }

        [Fact]
        public void TailShouldBeOneLessItemsThanList()
        {
            List<int> cut = new LinkedList<int>();

            for (int i = 1; i < 4; i++)
            {
                cut.Add(i);
            }
            List<int> tail = cut.Tail();

            Assert.Equal(2, tail.Length());
            Assert.Equal(2, tail.Get(0));
            Assert.Equal(3, tail.Get(1));
        }
       
        [Fact]
        public void ShouldBeAbleToAccessItemAtASpecificIndex()
        {
            List<int> cut = new LinkedList<int>();
            for (int i = 1; i < 4; i++)
            {
                cut.Add(i);
            }
            Assert.Equal(2, cut.Get(1));

        }

        [Fact]
        public void ShouldFindIndexOfItem()
        {
            List<int> cut = new LinkedList<int>();

            for (int i = 1; i < 20; i++)
            {
                cut.Add(i);
            }

            Assert.Equal(9, cut.IndexOf(10));

        }

        [Fact]
        public void CanRemoveItemAtIndexFromLinkedList()
        {
            List<int> cut = new LinkedList<int>();
            for (int i = 1; i < 4; i++)
            {
                cut.Add(i);
            }
            // [1, 2, 3]
            cut.RemoveAt(1);
            // [1, 3]
            Assert.Equal(2, cut.Length());
            Assert.Equal(1, cut.Get(0));
            Assert.Equal(3, cut.Get(1));

        }
        [Fact]
        public void IndexOfShouldReturnNegativeOneForNonExistingItem()
        {
            List<int> cut = new LinkedList<int>();

            for (int i = 1; i < 4; i++)
            {
                cut.Add(i);
            }
            Assert.Equal(-1, cut.IndexOf(42));
        }

        // an operation to remove a given item
        [Fact]
        public void CanRemoveItemFromLinkedList()
        {
            List<dynamic> cut = new LinkedList<dynamic>();
            dynamic objectToRemove = new { val = 42 };
            for (int i = 1; i < 4; i++)
            {
                cut.Add(new { val = i });
            }
            cut.Add(objectToRemove);
            for (int i = 1; i < 4; i++)
            {
                cut.Add(new { val = i });
            }

            // Length should be 7
            Assert.Equal(7, cut.Length());
            // object to remove should be at index 3
            Assert.Equal(3, cut.IndexOf(objectToRemove));

            cut.Remove(objectToRemove);

            // Length should now be 6
            Assert.Equal(6, cut.Length());
            // object to remove should return index -1
            Assert.Equal(-1, cut.IndexOf(objectToRemove));
        }

    }
}
