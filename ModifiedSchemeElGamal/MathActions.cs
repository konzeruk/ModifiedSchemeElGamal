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
        public static int[,] ModPowMatrix(int[,] Matrix, int Degree, int P)
        {
            var sizeMatrix = Matrix.GetLength(0);
            var powerMatrix = new BigInteger[sizeMatrix, sizeMatrix];
            for(var row = 0; row < sizeMatrix; ++row)
                for(var col = 0; col < sizeMatrix; ++col)
                    powerMatrix[row,col] = Matrix[row,col];
            for (var d = 1; d < Degree; ++d)
            {
                var temp = new BigInteger[sizeMatrix, sizeMatrix];
                for (var row = 0; row < sizeMatrix; ++row)
                    for (var col = 0; col < sizeMatrix; ++col)
                    {
                        BigInteger sum = 0;
                        for (var k = 0; k < sizeMatrix; k++)
                            sum += powerMatrix[row, k] * Matrix[k, col];
                        temp[row, col] = sum;
                    }
                powerMatrix = temp;
            }
            var result = new int[sizeMatrix, sizeMatrix];
            for (var row = 0; row < sizeMatrix; ++row)
                for (var col = 0; col < sizeMatrix; ++col)
                    result[row, col] = (int)(powerMatrix[row, col] % P);
            return result;
        }
        public static List<int> GetListPrimeValue(int MinValue, int MaxVal)
        {
            var ListPrimeValue = new List<int>();
            for(var val = MinValue; val <= MaxVal; ++val)
                if(IsPrime(val))
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
    }
}
