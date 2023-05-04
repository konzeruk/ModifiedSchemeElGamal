using ModifiedSchemeElGamal.HelperClasses;
using ModifiedSchemeElGamal.Interface;
using ModifiedSchemeElGamal.MathematicalOperators;
using ModifiedSchemeElGamal.Model;

namespace ModifiedSchemeElGamal.SchemeElGamal
{
    /// <summary>
    /// Encryption and Decryption text
    /// </summary>
    public sealed partial class SEG : ISEG
    {
        public Ciphertext? Encryption(string Text, OpenKey _OpenKey)
        {
            if (Text == string.Empty)
                return null;
            int[,] m = TextToGL(Text, _OpenKey.GL.N, _OpenKey.GL.P);
            var p = _OpenKey.GL.P;
            var r = CRNG.GenerationInt(1, p - 1);
            var Xr = MathActions.ModPow(_OpenKey.X, r, p);
            var C = MathActions.Mod(MathActions.MulMatrix(MathActions.ModPow(_OpenKey.Xa, r, p), m), p);
            return new Ciphertext(Xr, C);
        }
        private int[,] TextToGL(string Text, int N, int P)
        {
            var lengthText = Text.Length;
            int numCols;
            if (N == 0 || N > lengthText)
                numCols = 1;
            else
                numCols = (lengthText % N == 0) ? lengthText / N : (lengthText / N) + 1;
            var GL = new int[N, numCols];
            var indT = 0;
            for (var row = 0; row < N; ++row)
                for (var col = 0; col < numCols; ++col)
                    GL[row, col] = (indT < lengthText) ? Text[indT++] : Constants.CompSymbol;
            return GL;
        }
        public string Decryption(Ciphertext _Ciphertext, Keys _Keys)
        {
            var p = _Keys.OpenKey.GL.P;
            var alfInv = MathActions.ModMatrixInv(MathActions.ModPow(_Ciphertext.Xr, _Keys.SecretKey, p), p);
            var m = MathActions.Mod(MathActions.MulMatrix(alfInv, _Ciphertext.C), p);
            return GLToText(m, _Keys.OpenKey.GL.N);
        }
        private string GLToText(int[,] M, int N)
        {
            var Text = string.Empty;
            var numRows = M.GetLength(0);
            var numCols = M.GetLength(1);
            var isCompSymbol = true;
            for (var row = numRows - 1; row >= 0; --row)
                for (var col = numCols - 1; col >= 0; --col)
                {
                    if (M[row, col] != Constants.CompSymbol && isCompSymbol)
                        isCompSymbol = false;
                    if (!isCompSymbol)
                        Text += (char)M[row, col];
                }
            var arrayCharText = Text.ToCharArray();
            Array.Reverse(arrayCharText);
            return new string(arrayCharText);
        }
    }
}
