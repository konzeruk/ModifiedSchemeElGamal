using ModifiedSchemeElGamal.LinearAlgebra;
using ModifiedSchemeElGamal.Model;
using ModifiedSchemeElGamal.MathematicalOperators;

namespace ModifiedSchemeElGamal.HelperClasses
{
    internal static class GenerationKeys
    {
        public static Keys GetKeys()
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
