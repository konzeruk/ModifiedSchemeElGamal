using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    internal class Pow
    {
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
                    result[row, col] = (int)(powerMatrix[row, col]%P);
            return result;
        }
        
    }
}
