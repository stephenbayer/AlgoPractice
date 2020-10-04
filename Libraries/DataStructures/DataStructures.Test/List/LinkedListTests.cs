using System;
using Xunit;

namespace DataStructures.Test.List
{
    public class LinkedListTests
    {
        [Fact]
        public void LinkedListCanBeCreated()
        {
            DataStructures.List.List<int> cut = new DataStructures.List.LinkedList<int>();

            Assert.NotNull(cut);
        }

        [Fact]
        public void NewLinkedListCreatedEmpty()
        {
            DataStructures.List.List<int> cut = new DataStructures.List.LinkedList<int>();

            Assert.True(cut.IsEmpty());
        }
    }
}
