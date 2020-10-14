using System;
using System.Collections.Generic;
using Xunit;

namespace Problems
{
    public class LargestSumOfNonAjancent
    {
        /*
        Given a list of integers, write a function that returns
        the largest sum of non-adjacent numbers.
        Numbers can be 0 or negative.
        */

        // Naive solve is horrible O(n³) but constant space
        private int SolveProblemNaively(int[] inArr)
        {
            int ret = 0;

            int i = 0;
            while (i < inArr.Length)  // n * n
            {
                int v = NaiveSolve(inArr, i++);
                if (v > ret) ret = v;
            }

            return ret;
        }
        private int NaiveSolve(int[] inArr, int index)
        {
            if (index + 3 > inArr.Length) return inArr[index];
            int value = inArr[index];

            int max = 0;
            int i = index + 2;
            while (i < inArr.Length)
            {
                int rest = NaiveSolve(inArr, i++);
                if (rest > max) max = rest;
            }

            return value + max;
        }

        // time O(n) but space O(n), not constant space
        private int SolveeProblemBetter(int[]inArr)
        {
            int ret = 0;

            if (inArr.Length == 0) return 0;
            if (inArr.Length == 1) return inArr[0];

            int i = inArr.Length;
            Dictionary<int, int> htBest = new Dictionary<int, int>();

            while (i > 0)
            {
                i--;

                if (i >= inArr.Length - 2)
                {
                    // max of 1 item is that item
                    htBest[i] = (inArr[i] > 0) ? inArr[i] : 0;
                    
                } else 
                {
                    // find the max between 0, inArr[i + 2], inArr[i + 3]
                    int max = 0;
                    if (htBest[i + 2] > max) max = htBest[i + 2];
                    if (i < inArr.Length - 3 && htBest[i + 3] > max) max = htBest[i + 3];
                    htBest[i] = max + (inArr[i] > 0 ? inArr[i] : 0);
                }
                if (htBest[i] > ret) ret = htBest[i];

            }
            

            return ret;

        }

        /*
        For example, [2, 4, 6, 2, 5] should return 13, since we
        pick 2, 6, and 5.
        */

        [Fact]
        public void CanSolveProblemNaively()
        {
            int[] inArr = new[] { 2, 4, 6, 2, 5 };
            int actual = SolveProblemNaively(inArr);

            Assert.Equal(13, actual);

        }
        [Fact]
        public void CanSolveProblemBetter()
        {
            int[] inArr = new[] { 2, 4, 6, 2, 5 };
            int actual = SolveeProblemBetter(inArr);

            Assert.Equal(13, actual);

        }
        /*
        [5, 1, 1, 5] should return 10, since we pick 5 and 5.
        Follow-up: Can you do this in O(N) time and constant space?
        
        */
        [Fact]
        public void CanSolveProblem2Naively()
        {
            int[] inArr = new[] { 5, 1, 1, 5 };
            int actual = SolveProblemNaively(inArr);

            Assert.Equal(10, actual);

        }
        [Fact]
        public void CanSolveProblem2Better()
        {
            int[] inArr = new[] { 5, 1, 1, 5 };
            int actual = SolveeProblemBetter(inArr);

            Assert.Equal(10, actual);

        }

        /* 
         * ran of time, couldn't come up with O(n) time with O(1) space
         * ... looking up solution and haven't tested 0 or negatives
         */

        [Fact]
        public void CanSolveProblemWithSolution()
        {
            int[] inArr = new[] { 2, 4, 6, 2, 5 };
            int actual = LargestNonAdjacent(inArr);

            Assert.Equal(13, actual);

        }

        [Fact]
        public void CanSolveProblem2WithSolution()
        {
            int[] inArr = new[] { 5, 1, 1, 5 };
            int actual = LargestNonAdjacent(inArr);

            Assert.Equal(10, actual);

        }

        [Fact]
        public void CanSolveProblemWithNegativesWithSolution()
        {
            int[] inArr = new[] {  0, 2, -2, -5, -1, 1, -5 };
            int actual = LargestNonAdjacent(inArr);

            Assert.Equal(3, actual);

        }
        /*
        // solution
        // This doesn't really handle all negative numbers if at least one
        // number needs to be chosen, or if at least two needs to be
        // considered for a "sum",
        This solution only pays attention to the previous and the item just
        before the previous, gets the max from those and adjusts the
        one before the previous to that number + the current number, if it is
        more.

        */
        int LargestNonAdjacent(int[] arr)
        {
            if (arr.Length == 0) return 0;
            if (arr.Length == 1) return Math.Max(0, arr[0]);
            if (arr.Length == 2) return Math.Max(Math.Max(0, arr[0]), arr[1]);

            int maxExcludingLast = Math.Max(0, arr[0]);
            int maxIncludingLast = Math.Max(maxExcludingLast, arr[1]);

            int i = 2;

            while (i < arr.Length)
            {
                int num = arr[i];
                int prevMaxIncludingLast = maxIncludingLast;
                maxIncludingLast = Math.Max(maxIncludingLast, maxExcludingLast + num);
                maxExcludingLast = prevMaxIncludingLast;
                i++;
            }
            return Math.Max(maxIncludingLast, maxExcludingLast);
        }
    }
}
