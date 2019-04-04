using System;
namespace AlgorithmDesigns.Chapter3.Exercise26
{
    public class ReverseStringWords
    {
        public static void Reverse(char[] inputStr, int startIndex, int endIndex)
        {
            while(startIndex < endIndex)
            {
                // swap elements.
                char temp = inputStr[endIndex];
                inputStr[endIndex] = inputStr[startIndex];
                inputStr[startIndex] = temp;

                // update indexes.
                startIndex++;
                endIndex--;
            }

            //for (int cIndex = startIndex; cIndex < endIndex; cIndex++)
            //{
            //    int mirrorIndex = inputStr.Length - cIndex - 1;
            //    char temp = inputStr[mirrorIndex];
            //    inputStr[mirrorIndex] = inputStr[cIndex];
            //    inputStr[cIndex] = temp;
            //}

            //return inputStr;
        }

        public static void ReverseWord(char[] inputStr)
        {
            Reverse(inputStr, 0, inputStr.Length - 1);
            int startIndex = 0;
            for (int cIndex = 1; cIndex < inputStr.Length; cIndex++)
            {
                // last char or next is whitespace
                if(cIndex == inputStr.Length - 1 || char.IsWhiteSpace(inputStr[cIndex + 1]))
                {
                    Reverse(inputStr, startIndex, cIndex);
                    //this.Reverse(new ArraySegment<char>(inputStr, startIndex, endIndex));
                    startIndex = cIndex + 2;
                }
            }
        }
    }
}
