using System;
using System.Collections.Generic;

namespace AlgorithmDesigns.Common
{
    public static class Extensions
    {
        public static int[] CombineArrays(this int[] array1, int[] array2)
        {
            int[] newArray = new int[array1.Length + array2.Length];
            Array.Copy(array1, newArray, array1.Length);
            Array.Copy(array2, 0, newArray, array1.Length, array2.Length);

            return newArray;
        }

        public static void AddNewOrExisting<K, V>(this Dictionary<K, List<V>> dict, K key, V value)
        {
            if(dict.ContainsKey(key))
            {
                dict[key].Add(value);
            }
            else
            {
                dict[key] = new List<V>() { value };
            }
        }
    }
}
