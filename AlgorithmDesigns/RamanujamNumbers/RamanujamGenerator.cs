using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmDesigns.Common;

namespace AlgorithmDesigns.RamanujamNumbers
{
    public class RamanujamGenerator
    {

        // 1) Generate cubes
        // 2) Generate sum of 2 cubes
        // Requires SUPER HIGH memory for Dictionary.
        public static Dictionary<double, List<RamanujamPair>> GeneratePairs(int n)
        {
            var cubes = GenerateCubes(n);

            var sumPairOfCubes = SumPairOfCubes(cubes);

            return sumPairOfCubes; //.Where(d => d.Value.Count > 1).
                                // ToDictionary<double, List<RamanujamPair>>(d => d.K);
        }

        private static double[] GenerateCubes(int n)
        {
            double[] cubes = new double[n];
            for (int i = 1; i <= n; i++)
            {
                cubes[i - 1] = Math.Pow(i, 3);
            }

            return cubes;
        }

        private static Dictionary<double, List<RamanujamPair>> SumPairOfCubes(double[] cubes)
        {
            //int sumIndex = 0;
            //int sumArrayLength = cubes.Length * (cubes.Length + 1) / 2;
            //double[] sumArray = new double[sumArrayLength];
            Dictionary<double, List<RamanujamPair>> sumPairOfCubes = new Dictionary<double, List<RamanujamPair>>();

            for (int i = 0; i < cubes.Length; i++)
            {
                for (int j = i + 1; j < cubes.Length; j++)
                {
                    var sumOfCube = cubes[i] + cubes[j];
                    sumPairOfCubes.AddNewOrExisting(sumOfCube,
                                                    new RamanujamPair()
                                                    {
                                                        Component1 = cubes[i],
                                                        Component2 = cubes[j]
                                                    });
                }
            }

            return sumPairOfCubes;
        }
    }
}
