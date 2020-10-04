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
            (firstNode.Next() as IChildableNode<object>).SetChild(new Node<object>(new object()));
            (firstNode.Next().Next() as Node<object>).SetChild(new Node<object>(new object()));

            Assert.False(_algo.HasCycle(firstNode));
        }

        [Fact]
        public void CanDetermineChainHasCycles()
        {

            Node<object> firstNode = new Node<object>(new { val = 1 });
            Node<object> secondChild = new Node<object>(new { val = 2 });

            firstNode.SetChild(secondChild); 
            (firstNode.Next() as Node<object>).SetChild(new Node<object>(new { val = 3 }));
            (firstNode.Next().Next() as Node<object>).SetChild(new Node<object>(new { val = 4 }));
            (firstNode.Next().Next().Next() as Node<object>).SetChild(secondChild);

            Assert.True(_algo.HasCycle(firstNode));
        }

        [Fact]
        public void CanDeterminFunctionHasCycles()
        {
            TortoiseHare<int> algo = new TortoiseHare<int>();
            FunctionalNode<int> fNode = new FunctionalNode<int>(x => (x + 1) % 10, 0);

            Assert.True(algo.HasCycle(fNode));
        }


    }
}
