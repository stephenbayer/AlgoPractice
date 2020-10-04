using System;
using DataStructures.Common;
using Xunit;

namespace DataStructures.Test.Common
{
    public class NodeTests
    {
        [Fact]
        public void CanCreateNodeWithValueWithoutChild()
        {
            Node<int> cut = new Node<int>(42);
            Assert.NotNull(cut);
            Assert.Equal(42, cut.Value);
        }

        [Fact]
        public void CanCreatenodeWithValueAndChild()
        {
            Node<int> grandchild = new Node<int>(0);
            Node<int> child = new Node<int>(1, grandchild);
            Node<int> parent = new Node<int>(2, child);

            Assert.Equal(parent.Next(), child);
            Assert.Equal(0, parent.Next().Next().Value);
        }

    }
}
