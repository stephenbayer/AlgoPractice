﻿using Xunit;

namespace DataStructures.Test
{
    public class NodeTests
    {
        [Fact]
        public void CanCreateNodeWithValueWithoutChild()
        {
            INode<int> cut = new Node<int>(42);
            Assert.NotNull(cut);
            Assert.Equal(42, cut.Value);
        }

        [Fact]
        public void CanCreatenodeWithValueAndChild()
        {
            INode<int> grandchild = new Node<int>(0);
            INode<int> child = new Node<int>(1, grandchild);
            INode<int> parent = new Node<int>(2, child);

            Assert.Equal(parent.Next(), child);
            Assert.Equal(0, parent.Next().Next().Value);
        }

    }
}
