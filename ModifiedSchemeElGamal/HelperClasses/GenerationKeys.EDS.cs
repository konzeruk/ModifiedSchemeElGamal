using ModifiedSchemeElGamal.LinearAlgebra;
using ModifiedSchemeElGamal.MathematicalOperators;
using ModifiedSchemeElGamal.Model.EDS;

namespace ModifiedSchemeElGamal.HelperClasses
{
    internal static partial class GenerationKeys
    {
        /// <summary>
        /// Generates keys for digital signature
        /// </summary>
        /// <returns> class Keys (EDS) </returns>
        /// <exception cref="ArgumentException"></exception>
        public static Keys GetKeysEDS()
        {
            var groupLinear = GroupLinear.Instance; 
            var listPrimeP = MathActions.GetListPrimeValue(Constants.MinP, Constants.MaxP);
            var P = listPrimeP[CRNG.GenerationInt(0, listPrimeP.Count)];
            var G = groupLinear.FindPrimitiveRoot(P);
            if (G == null)
                throw new ArgumentException("Error: primitive root not found");
            var X = CRNG.GenerationInt(1, P - 1);
            var Y = MathActions.ModPow((int)G, X, P);
            return new Keys(new OpenKey(P, (int)G, Y), X);
        }
    }
}