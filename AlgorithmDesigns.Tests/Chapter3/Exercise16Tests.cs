using System;
using System.Linq;
using AlgorithmDesigns.Chapter3.Exercise16;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmDesigns.Tests.Chapter3
{
    [TestClass]
    public class Exercise16Tests
    {
        [TestMethod]
        public void Exercise16TestBSTText()
        {
            string bookContents = "One word two words three words";
            var punctuation = bookContents.Where(Char.IsPunctuation).Distinct().ToArray();
            var words = bookContents.Split(' ').Select(w => w.Trim(punctuation));

            IDictionaryAlgo<string> dictionary = new DictionaryBST<string>();
            foreach(var word in words)
            {
                if(!dictionary.ContainsKey(word))
                {
                    Console.Write(word);
                    dictionary.Insert(word);
                }
            }
        }
    }
}
