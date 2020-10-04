using System;
using DataStructures;

namespace Algorithms
{
    public class TortoiseHare<T>
    {
        public bool HasCycle(INode<T> node)
        {
            // until I put in the cycle detection, have a kill switch
            int i = 0;
            var tortoise = node;
            var hare = node;

            while (hare != null && i++ < 100)
            {
                hare = hare.Next();
                if (hare == null) return false;
                if (tortoise == hare) return true;
                hare = hare.Next();
                if (tortoise == hare) return true;
                tortoise = tortoise.Next();
            }
            // if i got this far, there were no cycles
            return false;
        }
    }
}
