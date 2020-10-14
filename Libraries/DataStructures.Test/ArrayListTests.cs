using Xunit;
using DataStructures;

namespace DataStructures.Test
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
        public void CanGetLengthOfArrayList()
        {
            List<int> cut = new ArrayList<int>();
            for (int i = 0; i < 10; i++) { cut.Add(i); }
            Assert.Equal(10, cut.Length());
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

        [Fact]
        public void CanAddFirstMoreITemsThanDefaultArraySizeToArrayList()
        {
            List<int> cut = new ArrayList<int>();
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

        //an operation for determining the first component(or the "head") of a list
        [Fact]
        public void CanGetHeadOfArrayList()
        {
            List<int> cut = new ArrayList<int>();
            for (int i = 1; i < 10; i++)
            {
                cut.Add(i);
            }
            Assert.Equal(1, cut.Head());
        }
        //an operation for referring to the list consisting of all the components of a list except for its first(this is called the "tail" of the list.)
        [Fact]
        public void TailShouldBeOneLessItemsThanArray()
        {
            List<int> cut = new ArrayList<int>();
            for (int i = 1; i < 4; i++)
            {
                cut.Add(i);
            }
            List<int> tail = cut.Tail();

            Assert.Equal(2, tail.Length());
            Assert.Equal(2, tail.Get(0));
            Assert.Equal(3, tail.Get(1));

        }
        //an operation for accessing the element at a given index.
        [Fact]
        public void ShouldBeAbleToAccessItemAtASpecificIndexInArrayList()
        {

            List<int> cut = new ArrayList<int>();
            for (int i = 1; i < 4; i++)
            {
                cut.Add(i);
            }
            Assert.Equal(2, cut.Get(1));
        }

        // an operation for accessing the index of a given value.
        [Fact]
        public void ShouldFindIndexOfItemInArrayList()
        {

            List<int> cut = new ArrayList<int>(32);
            for (int i = 1; i < 20; i++)
            {
                cut.Add(i);
            }

            Assert.Equal(9, cut.IndexOf(10));

        }

        // an operation to remove an item at a given index
        [Fact]
        public void CanRemoveItemAtIndexFromArrayList()
        {

            List<int> cut = new ArrayList<int>();
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

            List<int> cut = new ArrayList<int>();
            for (int i = 1; i < 4; i++)
            {
                cut.Add(i);
            }
            Assert.Equal(-1, cut.IndexOf(42));
        }

        // an operation to remove a given item
        [Fact]
        public void CanRemoveItemFromArrayList()
        {

            List<dynamic> cut = new ArrayList<dynamic>();
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

        [Fact]
        public void CanAddNullToArrayList()
        {

            List<object> cut = new ArrayList<object>();

            cut.Add(new { val = 1 });
            cut.Add(null);
            cut.Add(new { val = 2 });

            Assert.Equal(1, cut.IndexOf(null));

        }
    }
}
