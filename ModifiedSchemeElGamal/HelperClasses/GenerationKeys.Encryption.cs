using ModifiedSchemeElGamal.LinearAlgebra;
using ModifiedSchemeElGamal.Model.Encryption;
using ModifiedSchemeElGamal.MathematicalOperators;

namespace ModifiedSchemeElGamal.HelperClasses
{
    internal static partial sealed class GenerationKeys
    {
        /// <summary>
        /// Generates keys for encryption (line groups are used)
        /// </summary>
        /// <returns> class Keys (Encryption) </returns>
        /// <exception cref="ArgumentException"></exception>
        public static Keys GetKeysEncryption()
        {
            var groupLinear = GroupLinear.Instance;
            var listPrimeP = MathActions.GetListPrimeValue(Constants.MinP, Constants.MaxP);
            var P = listPrimeP[CRNG.GenerationInt(0, listPrimeP.Count)];
            var N = CRNG.GenerationInt(Constants.MinN, Constants.MaxN);
            var bufX = groupLinear.GenerationGL(N, P);
            if (bufX == null)
                throw new ArgumentException("Error: primitive root not found");
            var X = bufX;
            var A = CRNG.GenerationInt(2, P - 1);
            var Xa = MathActions.ModPow(X, A, P);
            return new Keys(new OpenKey(new G(N, P), X, Xa), A);
        }
    }
}
