using ModifiedSchemeElGamal.HelperClasses;
using ModifiedSchemeElGamal.Interface;
using ModifiedSchemeElGamal.MathematicalOperators;
using ModifiedSchemeElGamal.Model;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace ModifiedSchemeElGamal.SchemeElGamal
{
    /// <summary>
    /// Electronic digital signature and Digital signature verification
    /// </summary>
    public sealed partial class SEG : ISEG
    {
        public Ciphertext? EDS(string Text, OpenKey _OpenKey)
        {
            if (Text == string.Empty)
                return null;
            var p = _OpenKey.GL.P;
            var r = CRNG.GenerationInt(1, p - 1);
            var Xr = MathActions.ModPow(_OpenKey.X, r, p);
            var m = TextToGL(Text,_OpenKey.GL.N, p);
            var digest = GetDigestMatrix(m);
            var C = MathActions.Mod(MathActions.MulMatrix(MathActions.ModPow(_OpenKey.Xa, r, p), digest), p);
            return new Ciphertext(Xr, C);
        }
        private BigInteger[,] GetDigestMatrix(int[,] MatrixText)
        {
            var numRows = MatrixText.GetLength(0);
            var numCols = MatrixText.GetLength(1);
            var indexHashFunc = CRNG.GenerationInt(0, Constants.NumHashFunctions);
            var digestMatrix = new BigInteger[numRows, numCols];
            for (var row = 0; row < numRows; ++row)
                for (var col = 0; col < numCols; ++col)
                    digestMatrix[row, col] = HashFunctions.GetHash(indexHashFunc, BitConverter.GetBytes(MatrixText[row, col]));
            return digestMatrix;
        }
        public bool DSV(string Text, Ciphertext _Ciphertext, Keys _Keys)
        {
            return true;
        }
    }
}
