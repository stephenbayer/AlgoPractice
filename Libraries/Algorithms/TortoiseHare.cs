using System;
using DataStructures;

namespace Algorithms
{
    public class TortoiseHare<T>
    {
        /// <summary>
        /// Tortoise and Hare version of cycle detection
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool HasCycle(INode<T> node)
        {
            var tortoise = node;
            var hare = node;

            while (hare != null)
            {
                hare = hare.Next();
                if (hare == null) return false;
                if (hare.Value.Equals(tortoise.Value)) return true;
                hare = hare.Next();
                if (hare == null) return false;
                if (hare.Value.Equals(tortoise.Value)) return true;
                tortoise = tortoise.Next();
            }
            // if i got this far, there were no cycles
            return false;
        }
    }
}
