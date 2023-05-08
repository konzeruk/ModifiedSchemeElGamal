using ModifiedSchemeElGamal.HelperClasses;
using ModifiedSchemeElGamal.MathematicalOperators;

namespace ModifiedSchemeElGamal.LinearAlgebra
{
    internal sealed class GroupLinear
    {
        /// <summary>
        /// Initializes a new instance of the GroupLinear class
        /// </summary>
        public static GroupLinear Instance => new GroupLinear();
        private GroupLinear() { }
        /// <summary>
        /// Generation sub linear group (GLn(P))
        /// </summary>
        /// <param name="N">Order linear group</param>
        /// <param name="P">Modul</param>
        /// <returns>Matrix that is a linear group</returns>
        public int[,]? GenerationGL(int N, int P)
        {
            var g = FindPrimitiveRoot(P);
            if (g != null)
            {
                var GL = new int[N, N];
                var rand = new RandomNotRepeat(1, N * N * N);
                for (var i = 0; i < N; ++i)
                    for (var j = 0; j < N; ++j)
                        GL[i, j] = MathActions.ModPow((int)g, rand.Next(), P);
                return GL;
            }
            return null;
        }
        /// <summary>
        /// Find primitive root
        /// </summary>
        /// <param name="P">Modul</param>
        /// <returns>Value primitive root or null</returns>
        public int? FindPrimitiveRoot(int P)
        {
            List<int> fact = new();
            var phi = P - 1;
            var n = phi;
            for (var it = 2; it * it <= n; ++it)
                if (n % it == 0)
                {
                    fact.Add(it);
                    while (n % it == 0)
                        n /= it;
                }
            if (n > 1)
                fact.Add(n);
            for (var res = 2; res <= P; ++res)
            {
                var ok = true;
                for (var it = 0; it < fact.Count && ok; ++it)
                    ok &= MathActions.ModPow(res, phi / fact[it], P) != 1;
                if (ok)
                    return res;
            }
            return null;
        }
    }
}
