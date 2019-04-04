using System;
using System.Collections.Generic;

namespace AlgorithmDesigns.Chapter4.Exercise37
{
    public interface ISortingAlgo<T>
    {
        List<T> Sort(List<T> input);
    }
}
