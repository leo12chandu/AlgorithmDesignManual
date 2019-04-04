using System;
using System.Linq;
using AlgorithmDesigns.Chapter3.Exercise26;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmDesigns.Tests.Chapter3
{
    [TestClass]
    public class Exercise26
    {
        [TestMethod]
        public void Exercise26TestReverse()
        {
            char[] inputStr = "My name is Chris".ToCharArray();
            ReverseStringWords.ReverseWord(inputStr);
            var reversedStr = new String(inputStr);
            Console.WriteLine(reversedStr);
        }
    }
}
