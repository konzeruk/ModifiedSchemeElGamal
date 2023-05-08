using ModifiedSchemeElGamal.HelperClasses;
using ModifiedSchemeElGamal.Interface;
using ModifiedSchemeElGamal.MathematicalOperators;
using ModifiedSchemeElGamal.Model.Encryption;

namespace ModifiedSchemeElGamal.SchemeElGamal
{
    public sealed partial class SEG : ISEG
    {
        public Keys GetKeysEncryption() => GenerationKeys.GetKeysEncryption();
        public Ciphertext? Encryption(string Text, OpenKey _OpenKey)
        {
            if (Text == string.Empty)
                return null;
            int[,] m = TextToGL(Text, _OpenKey.GL.N);
            var p = _OpenKey.GL.P;
            var r = CRNG.GenerationInt(1, p - 1);
            var Xr = MathActions.ModPow(_OpenKey.X, r, p);
            var C = MathActions.Mod(MathActions.MulMatrix(MathActions.ModPow(_OpenKey.Xa, r, p), m), p);
            return new Ciphertext(Xr, C);
        }   
        public string Decryption(Ciphertext _Ciphertext, Keys _Keys)
        {
            var p = _Keys.OpenKey.GL.P;
            var alfInv = MathActions.ModMatrixInv(MathActions.ModPow(_Ciphertext.Xr, _Keys.SecretKey, p), p);
            var m = MathActions.Mod(MathActions.MulMatrix(alfInv, _Ciphertext.C), p);
            return GLToText(m);
        }
    }
}
