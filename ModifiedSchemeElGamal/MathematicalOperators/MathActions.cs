namespace ModifiedSchemeElGamal.MathematicalOperators
{
    internal static partial class MathActions
    {
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
        private static int GCD(int A, int B)
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
            var t1 = 0.0;
            var t2 = 1.0;
            while (r2 > 0)
            {
                var q = Math.Round((double)r1 / r2);
                var r = Mod(r1, r2);
                var t = t1 - q * t2;
                r1 = r2;
                r2 = r;
                t1 = t2;
                t2 = t;
            }
            return (int)t1;
        }

    }
}
