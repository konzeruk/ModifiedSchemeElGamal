using ModifiedSchemeElGamal.HelperClasses;
using ModifiedSchemeElGamal.MathematicalOperators;

namespace ModifiedSchemeElGamal.LinearAlgebra
{
    internal sealed class GroupLinear
    {
        public static GroupLinear Instance => new GroupLinear();
        public List<int[,]>? GenerationGL(int N, int P)
        {
            var g = FindPrimitiveRoot(P);
            if (g != null)
            {
                var ListGL = new List<int[,]>();
                var rand = new RandomNotRepeat(1, N * N * N);
                for (int it = 0; it < N; ++it)
                {
                    var GL = new int[N, N];
                    for (var i = 0; i < N; ++i)
                        for (var j = 0; j < N; ++j)
                            GL[i, j] = MathActions.ModPow((int)g, rand.Next(), P);
                    ListGL.Add(GL);
                }
                return ListGL;
            }
            return null;
        }
        private int? FindPrimitiveRoot(int P)
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
