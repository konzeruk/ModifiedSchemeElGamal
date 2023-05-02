using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;

namespace ModifiedSchemeElGamal
{
    internal static partial class MathActions
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
            for (var row = 0; row < sizeMatrix; ++row)
                for (var col = 0; col < sizeMatrix; ++col)
                    powerMatrix[row, col] = Matrix[row, col];
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
                    result[row, col] = Mod((int)powerMatrix[row, col],P);
            return result;
        }
        public static int[,] MulMatrix(int[,] Matrix, int Value)
        {
            for(var row = 0; row < Matrix.GetLength(0);++row)
                for(var col = 0; col < Matrix.GetLength(1);++col)
                    Matrix[row, col] *= Value;
            return Matrix;
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
    }
    internal static partial class MathActions
    {
        public static int[,] ModMatrixInvCode(int[,] Matrix, int MDInv, int N)
        {
            if (Matrix.GetLength(0) != Matrix.GetLength(1))
                throw new ArgumentException("Error: size matrix");
            var sizeMatrix = Matrix.GetLength(0);
            var result = new int[sizeMatrix, sizeMatrix];
            for (var row = 0; row < sizeMatrix; ++row)
                for (var col = 0; col < sizeMatrix; ++col)
                    result[row, col] = (int)Math.Pow(-1, row + col + 2) * (int)ModDet(GetMinorMatrix(Matrix, row, col), N);
            result = MulMatrix(Transposition(result), MDInv);
            for (var row = 0; row < Matrix.GetLength(0); ++row)
                for (var col = 0; col < Matrix.GetLength(1); ++col)
                    result[row, col] = Mod(result[row, col],N);
            return result;
        }
        public static int Mod(int Value, int N) =>
            ((Value % N) < 0) ? (Value % N) + N : ((Value % N));
        public static double ModDet(int[,] Matrix, int P)
        {
            var sizeMatrix = Matrix.GetLength(0);
            if (sizeMatrix == 1)
                return Matrix[0, 0];
            else
            {
                var det = 0.0;
                for (var row = 0; row < sizeMatrix; ++row)
                    det += Math.Pow(-1, (row + 2)) * Matrix[row, 0] * ModDet(GetMinorMatrix(Matrix, row, 0), P);
                return Mod((int)det, P);
            }
        }
        private static int[,] GetMinorMatrix(int[,] Matrix, int Row, int Col)
        {
            var sizeRow = Matrix.GetLength(0);
            var sizeCol = Matrix.GetLength(1);
            var result = new int[sizeRow - 1, sizeCol - 1];
            var m = 0;
            for (int i = 0; i < sizeRow; ++i)
            {
                if (i == Row)
                    continue;
                var k = 0;
                for (int j = 0; j < sizeCol; ++j)
                {
                    if (j == Col)
                        continue;
                    result[m, k++] = Matrix[i, j];
                }
                ++m;
            }
            return result;
        }
        public static double GCD(double A, double B)
        {
            if (B == 0)
                return A;
            else
                return GCD(B, Math.IEEERemainder(A, B));
        }
        public static double MultInv(double A, double N)
        {
            var r1 = N;
            var r2 = A;
            var t1 = 0.0;
            var t2 = 1.0;
            while(r2>0)
            {
                var q = Math.Round(r1/ r2);
                var r = Mod((int)r1, (int)r2);
                var t = t1 - q * t2;
                r1 = r2;
                r2 = r;
                t1 = t2;
                t2 = t;
            }
            return t1;
        }
        private static int[,] Transposition(int[,] Matrix)
        {
            var sizeMatrix = Matrix.GetLength(0);
            var trans = new int[sizeMatrix, sizeMatrix];
            for (var row = 0; row < sizeMatrix; ++row)
                for (var col = 0; col < sizeMatrix; ++col)
                    trans[row, col] = Matrix[col, row];
            return trans;
        }
    }
}
