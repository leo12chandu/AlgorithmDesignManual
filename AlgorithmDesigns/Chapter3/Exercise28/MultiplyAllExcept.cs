using System;
namespace AlgorithmDesigns.Chapter3.Exercise28
{
    /*
     * You have an unordered array X of n integers. 
     * Find the array M containing n elements where Mi is the product 
     * of all integers in X except for Xi. You may not use division. 
     * You can use extra memory. (Hint: There are solutions faster than O(n2).)
     */

    public class MultipleAllExcept
    {
        public int[] Multiple(int[] inputArray)
        {
            int[] forwardMultiples = new int[inputArray.Length];
            int[] backwardMultiples = new int[inputArray.Length];
            int[] indexMultiples = new int[inputArray.Length];

            int fMultiple = 1, bMultiple = 1;

            // calculate multiplications forward.
            for (int i = 0; i < inputArray.Length; i++)
            {
                fMultiple *= inputArray[i];
                forwardMultiples[i] = fMultiple;
            }

            // calculate multiplications backward.
            for (int i = inputArray.Length;  i >= 0; i--)
            {
                bMultiple *= inputArray[i];
                backwardMultiples[i] = bMultiple;
            }

            // caculate multiplations for each index.
            for (int i = 0; i < inputArray.Length; i++)
            {
                indexMultiples[i] = forwardMultiples[i - 1] * backwardMultiples[i + 1];
            }

            return indexMultiples;
        }
    }
}
