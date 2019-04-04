using System;
namespace AlgorithmDesigns.Chapter3.Exercise13
{
    public class ArraySumHelper
    {
        private int[] DataArray { get; set; }
        private int[] sumArray;

        public ArraySumHelper(int[] dataArray)
        {
            if(dataArray == null || dataArray.Length == 0)
            {
                throw new ArgumentException("argument dataArray has no elements.");
            }

            this.DataArray = dataArray;

            int sumArrayLen = (int)Math.Pow(2, Math.Ceiling(Math.Log(dataArray.Length) / Math.Log(2))) - 1;
            this.sumArray = new int[sumArrayLen];
            this.ComputeSums();
        }

        public void Add(int i, int y)
        {
            // increase value in DataArray.
            this.DataArray[i - 1] += y;

            // recompute sumArray
            this.RecomputeSum((int)Math.Floor((decimal)(this.sumArray.Length + i - 2) / 2), y);
        }

        public int PartialSum(int i)
        {
            //var sum = 0;
            //var nextI = i;
            //var floor = Math.Floor(Math.Log(nextI) / Math.Log(2));

            //sum += this.sumArray[nextI];
            //nextI = nextI - floor;

            int leftIndex = 0, rightIndex = i - 1;
            int iteration = 0;
            int calculatedVal = this.DataArray[rightIndex];

            do
            {
                var pIndexLeft = this.GetParentIndex(leftIndex, iteration);
                var pIndexRight = this.GetParentIndex(rightIndex, iteration);
                //int pValRight = this.GetValue(pIndexRight, iteration);

                if(this.GetIndex(rightIndex, iteration) % 2 == 0)
                {
                    int currentVal = this.GetValue(rightIndex, iteration);
                    calculatedVal = this.sumArray[pIndexRight] - currentVal + calculatedVal;
                }

                leftIndex = pIndexLeft;
                rightIndex = pIndexRight;
                iteration++;
            }
            while (leftIndex != rightIndex);

            return calculatedVal;
        }

        private int GetParentIndex(int index, int iteration)
        {
            //return (int)Math.Floor((decimal)(index - 1) / 2);
            var pIndexDecimal = ((iteration == 0 ? (this.sumArray.Length + index) : index) - 1) / 2;
            return (int)Math.Floor((decimal)pIndexDecimal);
        }

        private int GetIndex(int index, int iteration)
        {
            return (iteration == 0) ? this.DataArray.Length - 1 + index : index;
        }

        private int GetValue(int index, int iteration)
        {
            return iteration == 0 ? this.DataArray[index] : this.sumArray[index];
        }

        private void ComputeSums()
        {
            var sIndex = (int)Math.Floor((decimal)(this.sumArray.Length) / 2);

            for (int dIndex = 0; dIndex < this.DataArray.Length; dIndex = dIndex + 2)
            {
                var left = this.DataArray[dIndex];
                var right = this.DataArray.Length > (dIndex + 1) ? this.DataArray[dIndex + 1] : 0;
                var sum = left + right;
                this.sumArray[sIndex++] = sum;
            }

            var sStartIndex = (this.sumArray.Length - 1) / 2;
            var sEndIndex = this.sumArray.Length - 1;
            var sNewIndex = (int)Math.Floor((decimal)(sStartIndex) / 2);

            // until parent is reached.
            while (sNewIndex >= 0 && sStartIndex > 0)
            {
                int iteration = 0;
                //sIndex = pIndex;
                for (int sCurrentIndex = sStartIndex; sCurrentIndex < sEndIndex; sCurrentIndex = sCurrentIndex + 2)
                {
                    var left = this.sumArray[sCurrentIndex];
                    var right = this.sumArray.Length > (sCurrentIndex + 1) ? this.sumArray[sCurrentIndex + 1] : 0;
                    var sum = left + right;
                    this.sumArray[sNewIndex + iteration++] = sum;
                }

                //sStartIndex = sStartIndex - (sEndIndex - sStartIndex) / 2;
                sEndIndex = sStartIndex - 1;
                sStartIndex = sNewIndex;
                sNewIndex = (int)Math.Floor((decimal)(sStartIndex) / 2);
            }
        }

        #region Commented
        //private void ComputeSums()
        //{
        //    var sIndexStart = this.sumArray.Length - (this.DataArray.Length / 2);
        //    int sIndexToUpdate = sIndexStart;

        //    // initialize sumArray with first binary sums form dataArray;
        //    for (int sIndex = 0; sIndex < this.DataArray.Length; sIndex = sIndex + 2)
        //    {
        //        var left = this.DataArray[sIndex];
        //        var right = this.DataArray.Length > (sIndex + 1) ? this.DataArray[sIndex + 1] : 0;
        //        var sum =  left + right;

        //        this.sumArray[sIndexToUpdate++] = sum;
        //    }

        //    // initiaze rest of sumArray recursively.
        //    ComputeSums(sIndexStart, this.DataArray.Length);
        //}

        //private void ComputeSums(int startIndex, int noOfElements)
        //{
        //    if(noOfElements < 1)
        //    {
        //        return;
        //    }

        //    int sIndexStart = (startIndex - noOfElements / 2);
        //    int sIndexToUpdate = sIndexStart;

        //    for (int sIndex = startIndex; sIndex < (startIndex + noOfElements); sIndex = sIndex + 2)
        //    {
        //        var left = this.sumArray[sIndex];
        //        var right = this.sumArray.Length > (sIndex + 1) ? this.sumArray[sIndex + 1] : 0;
        //        var sum = left + right;
        //        this.sumArray[sIndexToUpdate++] = sum;
        //    }

        //    ComputeSums(sIndexStart, noOfElements / 2);
        //}
        #endregion

        private void RecomputeSum(int i, int y)
        {
            if (i >= 0)
            {
                this.sumArray[i] += y;
                this.RecomputeSum((int)Math.Floor((decimal)(i - 1) / 2), y);
            }
        }
    }
}
