using System;
using Xunit;
using DataStructures.List;

namespace DataStructures.Test.List
{
    public class ArrayListTests
    {
        [Fact]
        public void ArrayListCanBeCreated()
        {
            List<int> cut = new ArrayList<int>();

            Assert.NotNull(cut);
        }

        [Fact]
        public void NewArrayListCreatedEmpty()
        {
            List<int> cut = new ArrayList<int>();

            Assert.True(cut.IsEmpty());
        }

        [Fact]
        public void CanAddAnItemToArrayList()
        {
            List<int> cut = new ArrayList<int>();

            cut.Add(1);

            int actual = cut.Get(0);

            Assert.Equal(1, actual);
        }

        [Fact]
        public void CanAddMoreITemsThanDefaultArraySizeToArrayList()
        {
            List<int> cut = new ArrayList<int>();
            for (int i = 1; i < 10; i++)
            {
                cut.Add(i);
            }

            int actual = cut.Get(8);

            Assert.Equal(9, actual);
        }

        [Fact]
        public void ArrayListWithItemIsNotEmpty()
        {
            List<int> cut = new ArrayList<int>();

            cut.Add(1);

            Assert.False(cut.IsEmpty());
        }

        [Fact]
        public void CanPrependItemToList()
        {
            List<int> cut = new ArrayList<int>();

            cut.Add(1);

            cut.AddFirst(2);

            Assert.Equal(2, cut.Get(0));
            Assert.Equal(1, cut.Get(1));
        }

        //an operation for testing whether or not a list is empty;

        //an operation for prepending an entity to a list
        //an operation for determining the first component(or the "head") of a list
        //an operation for referring to the list consisting of all the components of a list except for its first(this is called the "tail" of the list.)
        //an operation for accessing the element at a given index.
    }
}
