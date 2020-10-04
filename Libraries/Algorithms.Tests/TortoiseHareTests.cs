using System;
using DataStructures;
using Xunit;

namespace Algorithms.Tests
{
    public class TortoiseHareTests
    {
        TortoiseHare<object> _algo = new TortoiseHare<object>();

        [Fact]
        public void CanDetermineNullHasNoCycles()
        {
            Assert.False(_algo.HasCycle(null));
        }

        [Fact]
        public void CanDetermineSingleNodeHasNoCycles()
        {

            Node<object> firstNode = new Node<object>(new object());

            Assert.False(_algo.HasCycle(firstNode));
        }

        [Fact]
        public void CanDetermineChainHasNoCycles()
        {

            Node<object> firstNode = new Node<object>(new object());
            firstNode.SetChild(new Node<object>(new object()));
            firstNode.Next().SetChild(new Node<object>(new object()));
            firstNode.Next().Next().SetChild(new Node<object>(new object()));

            Assert.False(_algo.HasCycle(firstNode));
        }
        [Fact]
        public void CanDetermineChainHasCycles()
        {

            Node<object> firstNode = new Node<object>(new { val = 1 });
            Node<object> secondChild = new Node<object>(new { val = 2 });

            firstNode.SetChild(secondChild); 
            firstNode.Next().SetChild(new Node<object>(new { val = 3 }));
            firstNode.Next().Next().SetChild(new Node<object>(new { val = 4 }));
            firstNode.Next().Next().Next().SetChild(secondChild);

            Assert.True(_algo.HasCycle(firstNode));
        }

    }
}
