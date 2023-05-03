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
        public Ciphertext Encryption(string Text, OpenKey _OpenKey)
        {
            int[,] m = { { 1 }, { 1 }, { 2 } };
            var p = _OpenKey.GL.P;
            var r = CRNG.GenerationInt(1, p);
            var Xr = MathActions.ModPow(_OpenKey.X, r, p);
            var C = MathActions.Mod(MathActions.MulMatrix(MathActions.ModPow(_OpenKey.Xa, r, p), m), p);
            return new Ciphertext(Xr, C);
        }
        public string Decryption(string EncryptedText)
        {
            throw new NotImplementedException();
        }
    }
}
