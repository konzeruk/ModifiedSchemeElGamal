using System.Numerics;

namespace ModifiedSchemeElGamal.MathematicalOperators
{
    internal static partial class MathActions
    {
        public static int[,] MulMatrix(int[,] Matrix, int Value)
        {
            var sizeMatrix = Matrix.GetLength(0);
            var Result = new int[sizeMatrix, sizeMatrix];
            for (var row = 0; row < Matrix.GetLength(0); ++row)
                for (var col = 0; col < Matrix.GetLength(1); ++col)
                    Result[row, col] = Matrix[row, col] * Value;
            return Result;
        }
        public static BigInteger[,] MulMatrix(int[,] Matrix, BigInteger Value)
        {
            var sizeMatrix = Matrix.GetLength(0);
            var Result = new BigInteger[sizeMatrix, sizeMatrix];
            for (var row = 0; row < Matrix.GetLength(0); ++row)
                for (var col = 0; col < Matrix.GetLength(1); ++col)
                    Result[row, col] = Matrix[row, col] * Value;
            return Result;
        }
        public static int[,] MulMatrix(int[,] A, int[,] B)
        {
            var numRowsA = A.GetLength(0);
            var numRowsB = B.GetLength(0);
            var numColsB = B.GetLength(1);
            var Result = new int[numRowsA, numColsB];
            for (int i = 0; i < numRowsA; ++i)
                for (int j = 0; j < numColsB; ++j)
                    for (int k = 0; k < numRowsB; ++k)
                        Result[i, j] += A[i, k] * B[k, j];
            return Result;
        }
        public static BigInteger[,] MulMatrix(int[,] A, BigInteger[,] B)
        {
            var numRowsA = A.GetLength(0);
            var numRowsB = B.GetLength(0);
            var numColsB = B.GetLength(1);
            var Result = new BigInteger[numRowsA, numColsB];
            for (int i = 0; i < numRowsA; ++i)
                for (int j = 0; j < numColsB; ++j)
                    for (int k = 0; k < numRowsB; ++k)
                        Result[i, j] += A[i, k] * B[k, j];
            return Result;
        }
        private static int[,] GetMinorMatrix(int[,] Matrix, int Row, int Col)
        {
            var sizeRow = Matrix.GetLength(0);
            var sizeCol = Matrix.GetLength(1);
            var Result = new int[sizeRow - 1, sizeCol - 1];
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
                    Result[m, k++] = Matrix[i, j];
                }
                ++m;
            }
            return Result;
        }
        private static int[,] Transposition(int[,] Matrix)
        {
            var sizeMatrix = Matrix.GetLength(0);
            var Trans = new int[sizeMatrix, sizeMatrix];
            for (var row = 0; row < sizeMatrix; ++row)
                for (var col = 0; col < sizeMatrix; ++col)
                    Trans[row, col] = Matrix[col, row];
            return Trans;
        }
    }
}
