using System.Numerics;
using System.Reflection;

namespace ModifiedSchemeElGamal
{
    internal static class MathActions
    {
        public static int ModPow(int Value, int Degree, int P)
        {
            var res = 1;
            Value %= P;
            if ((Degree & 1) == 1)
                res = Value;

            while (Degree > 1)
            {
                Degree >>= 1;
                Value = (Value * Value) % P;
                if ((Degree & 1) == 1)
                    res = (res * Value) % P;
            }
            return res;
        }
        public static double Pow(int Value, int Degree) =>
            Math.Pow(Value, Degree);
        public static bool IsPrime(int Value)
        {
            for (var i = 2; i < Value; i++)
                if (Value % i == 0)
                    return false;
            return true;
        }
    }
}
