using System;
namespace AlgorithmDesigns.RamanujamNumbers
{
    public class RamanujamPair
    {
        public double Component1 { get; set; }
        public double Component2 { get; set; }
        public double Component1CubeRoot { get { return Math.Pow(this.Component1, 1.0 / 3); } }
        public double Component2CubeRoot { get { return Math.Pow(this.Component2, 1.0 / 3); } }
    }
}
