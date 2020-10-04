using System;
using Xunit;

namespace DataStructures.Test
{
    public class ParentAwareNodeTests
    {

        [Fact]
        public void CanCreateParentAwareNodeWithValueWithoutChild()
        {
            INode<int> cut = new ParentAwareNode<int>(42, null, null);
            Assert.NotNull(cut);
            Assert.Equal(42, cut.Value);
        }

        [Fact]
        public void CanCreateParentAwareNodeWithValueAndChild()
        {
            INode<int> grandchild = new ParentAwareNode<int>(0, null, null);
            INode<int> child = new ParentAwareNode<int>(1, grandchild, null);
            INode<int> parent = new ParentAwareNode<int>(2, child, null);

            Assert.Equal(parent.Next(), child);
            Assert.Equal(0, parent.Next().Next().Value);
            Assert.Equal(
                2,
                ((grandchild as ParentAwareNode<int>).Previous() as ParentAwareNode<int>).Previous().Value
            );

        }
    }
}
