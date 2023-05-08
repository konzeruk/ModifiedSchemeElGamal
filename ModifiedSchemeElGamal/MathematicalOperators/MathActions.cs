namespace ModifiedSchemeElGamal.MathematicalOperators
{
    /// <summary>
    /// Mathematical operations necessary for calculations
    /// </summary>
    internal static partial class MathActions
    {
        public static int Pow(int A, int Degree) =>
            (int)Math.Pow(A, Degree);
        public static int InvMod(int A, int P)
        {
            (var g, var x, var y) = GCDEX(A, P);
            return g > 1 ? 0 : (x % P + P) % P;
        }
        private static (int, int, int) GCDEX(int A, int B)
        {
            if (A == 0)
                return (B, 0, 1);
            (var gcd, var x, var y) = GCDEX(B % A, A);
            return (gcd, y - (B / A) * x, x);
        }
        public static List<int> GetListPrimeValue(int MinValue, int MaxVal)
        {
            var ListPrimeValue = new List<int>();
            for (var val = MinValue; val <= MaxVal; ++val)
                if (IsPrime(val))
                    ListPrimeValue.Add(val);
            return ListPrimeValue;
        }
        public static bool IsPrime(int Value)
        {
            for (var i = 2; i < Value; i++)
                if (Value % i == 0)
                    return false;
            return true;
        }
        public static int GCD(int A, int B)
        {
            if (B == 0)
                return A;
            else
                return GCD(B, Mod(A, B));
        }
        private static int MultInv(int A, int N)
        {
            var r1 = N;
            var r2 = A;
            var t1 = 0;
            var t2 = 1;
            while (r2 > 0)
            {
                var q = Math.Floor((double)r1 / r2);
                var r = Mod(r1, r2);
                var t = t1 - q * t2;
                r1 = r2;
                r2 = r;
                t1 = t2;
                t2 = (int)t;
            }
            return t1;
        }

    }
}
