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
            if(Text == string.Empty)
                return null;
            var m = TextToGL(Text, _OpenKey.GL.N);
            var p = _OpenKey.GL.P;
            var r = CRNG.GenerationInt(1, p);
            var Xr = MathActions.ModPow(_OpenKey.X, r, p);
            var C = MathActions.Mod(MathActions.MulMatrix(MathActions.ModPow(_OpenKey.Xa, r, p), m), p);
            return new Ciphertext(Xr, C);
        }
        private int[,] TextToGL(string Text, int N)
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
        public string Decryption(string EncryptedText)
        {
            throw new NotImplementedException();
        }
    }
}
