using System;
namespace AlgorithmDesigns.Chapter3.Exercise16
{
    public interface IDictionaryAlgo<T> where T : IComparable
    {
        bool ContainsKey(T key);

        void Insert(T key);
    }
}
