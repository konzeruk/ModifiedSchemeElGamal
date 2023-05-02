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
            var n = CRNG.GenerationInt(Constants.MinN, Constants.MaxN);
            var GL = groupLinear.GenerationGL(n, P);
            if (GL == null)
                throw new ArgumentException("Error: primitive root not found");
            var X = GL[CRNG.GenerationInt(0, GL.Count)];
            var A = CRNG.GenerationInt(2, P - 1);
            var Xa = MathActions.ModPowMatrix(X, A, P);
            return new Keys(new OpenKey(GL, X, Xa), A, P);
        }
    }
}
