using System.Numerics;

namespace ModifiedSchemeElGamal.MathematicalOperators
{
    internal static partial class MathActions
    {
        public static int[,] ModPow(int[,] Matrix, int Degree, int P)
        {
            var numRows = Matrix.GetLength(0);
            var numCols = Matrix.GetLength(1);
            var Result = new int[numRows, numCols];
            for (var row = 0; row < numRows; ++row)
                for (var col = 0; col < numCols; ++col)
                    Result[row, col] = Matrix[row, col];
            for (var d = 1; d < Degree; ++d)
            {
                var temp = new int[numRows, numCols];
                for (var row = 0; row < numRows; ++row)
                    for (var col = 0; col < numCols; ++col)
                    {
                        BigInteger sum = 0;
                        for (var k = 0; k < numRows; k++)
                            sum += Result[row, k] * Matrix[k, col];
                        temp[row, col] = Mod(sum, P);
                    }
                Result = temp;
            }
            return Result;
        }
        public static int[,]? ModMatrixInv(int[,] Matrix, int P)
        {
            if (Matrix.GetLength(0) != Matrix.GetLength(1))
                throw new ArgumentException("Error: size matrix");
            var md = ModDet(Matrix, P);
            if (GCD(md, P) == 1)
            {
                var mdInv = MultInv(md, P);
                return ModMatrixInvCode(Matrix, (int)mdInv, P);
            }
            return null;
        }
        private static int[,] ModMatrixInvCode(int[,] Matrix, int MDInv, int P)
        {
            var sizeMatrix = Matrix.GetLength(0);
            var Result = new int[sizeMatrix, sizeMatrix];
            for (var row = 0; row < sizeMatrix; ++row)
                for (var col = 0; col < sizeMatrix; ++col)
                    Result[row, col] = (int)Math.Pow(-1, row + col + 2) * ModDet(GetMinorMatrix(Matrix, row, col), P);
            Result = MulMatrix(Transposition(Result), MDInv);
            for (var row = 0; row < Matrix.GetLength(0); ++row)
                for (var col = 0; col < Matrix.GetLength(1); ++col)
                    Result[row, col] = Mod(Result[row, col], P);
            return Result;
        }
        private static int ModDet(int[,] Matrix, int P)
        {
            var sizeMatrix = Matrix.GetLength(0);
            if (sizeMatrix == 1)
                return Matrix[0, 0];
            else
            {
                var det = 0;
                for (var row = 0; row < sizeMatrix; ++row)
                    det += (int)Math.Pow(-1, (row + 2)) * Matrix[row, 0] * ModDet(GetMinorMatrix(Matrix, row, 0), P);
                return Mod(det, P);
            }
        }
        public static int ModPow(int Value, int Degree, int P)
        {
            var Result = 1;
            Value = Mod(Value, P);
            if ((Degree & 1) == 1)
                Result = Value;
            while (Degree > 1)
            {
                Degree >>= 1;
                Value = (Value * Value) % P;
                if ((Degree & 1) == 1)
                    Result = Mod((Result * Value), P);
            }
            return Result;
        }
        public static int[,] Mod(int[,] Matrix, int P)
        {
            var numRows = Matrix.GetLength(0);
            var numCols = Matrix.GetLength(1);
            var Result = new int[numRows, numCols];
            for (var row = 0; row < numRows; ++row)
                for (var col = 0; col < numCols; ++col)
                    Result[row, col] = Mod(Matrix[row, col], P);
            return Result;
        }
        public static int Mod(int Value, int P)
        {
            var Result = (Value % P);
            return (Result < 0) ? Result + P : Result;
        }
        public static int Mod(BigInteger Value, int P)
        {
            var Result = (int)(Value % P);
            return (Result < 0) ? Result + P : Result;
        }
    }
}
